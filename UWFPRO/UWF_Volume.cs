using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace UWFCMD
{
    internal class UWF_Volume
    {
        private readonly string namespacePath = @"root\standardcimv2\embedded";
        public Dictionary<string, List<string>> Dic_FileExclusion = new Dictionary<string, List<string>>();
        public List<ManagementObject> managementObjects = new List<ManagementObject>();
        public bool CurrentSession;
        public string DriveLetter;
        public string VolumeName;
        public bool BindByDriveLetter;
        public bool CommitPending;
        public bool Protected;
        public UWF_Volume(bool currentSession)
        {
            CurrentSession = currentSession;
        }


        public bool CommitFile(string FileName)
        {
            var objUWFInstances = Get_UWF_Volume();
            if (objUWFInstances == null)
            {
                Console.WriteLine("无法检索 统一写入筛选器 (UWF)  设置。");
                return false;
            }
            string driveLetter = Path.GetPathRoot(FileName).Replace("\\", "");
            string FileNamenew = FileName.Remove(0, 2);

            foreach (var objUWFInstance in objUWFInstances)
            {
                if (driveLetter.ToUpper() == objUWFInstance["DriveLetter"].ToString().ToUpper())
                {
                    ManagementBaseObject inParams = objUWFInstance.GetMethodParameters("CommitFile");
                    foreach (var DATA in inParams.Properties)
                    {
                        Console.WriteLine(DATA.Name);
                    }
                    inParams["FileName"] = FileNamenew;
                    // 调用方法
                    ManagementBaseObject outParams = objUWFInstance.InvokeMethod("CommitFile", inParams, null);

                    // 检查返回值是否成功（0表示成功）
                    uint returnValue = (uint)(outParams?["ReturnValue"] ?? 1);
                    if (returnValue == 0)
                    {
                        Console.WriteLine(FileName + "提交成功!");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine(FileName + "提交失败!");
                        return false;
                    }
                }
            }
            return false;
        }
        public bool CommitFileDeletion(string FileName)
        {
            var objUWFInstances = Get_UWF_Volume();
            if (objUWFInstances == null)
            {
                Console.WriteLine("无法检索 统一写入筛选器 (UWF)  设置。");
                return false;
            }
            string driveLetter = Path.GetPathRoot(FileName).Replace("\\", "");
            string FileNamenew = FileName.Remove(0, 2);
            if (File.Exists(FileName))
            {
                File.Delete(FileName);
            }
            foreach (var objUWFInstance in objUWFInstances)
            {
                ManagementBaseObject inParams = objUWFInstance.GetMethodParameters("CommitFileDeletion");
                inParams["FileName"] = FileNamenew;
                if (driveLetter.ToUpper() == objUWFInstance["DriveLetter"].ToString().ToUpper())
                {
                    // 调用方法
                    ManagementBaseObject outParams = objUWFInstance.InvokeMethod("CommitFileDeletion", inParams, null);

                    // 检查返回值是否成功（0表示成功）
                    uint returnValue = (uint)(outParams?["ReturnValue"] ?? 1);
                    if (returnValue == 0)
                    {
                        Console.WriteLine(FileName + "删除提交成功!");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine(FileName + "删除提交失败!");
                        return false;
                    }
                }
            }
            return false;
        }
        public bool Protect(string driveLetter)
        {
            var objUWFInstances = Get_UWF_Volume();
            if (objUWFInstances == null)
            {
                Console.WriteLine("无法检索 统一写入筛选器 (UWF)  设置。");
                return false;
            }
            foreach (var objUWFInstance in objUWFInstances)
            {
                if (driveLetter.ToUpper() == objUWFInstance["DriveLetter"].ToString().ToUpper())
                {
                    objUWFInstance["CurrentSession"] = "False";
                    objUWFInstance.Put();
                    ManagementBaseObject outParams = objUWFInstance.InvokeMethod("Protect", null, null);

                    // 检查返回值是否成功（0表示成功）
                    uint returnValue = (uint)(outParams?["ReturnValue"] ?? 1);
                    if (returnValue == 0)
                    {
                        Console.WriteLine(DriveLetter + "保护成功!");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine(DriveLetter + "保护失败!");
                        return false;
                    }
                }
            }
            return false;
        }
        public bool Unprotect(string driveLetter)
        {
            var objUWFInstances = Get_UWF_Volume();
            if (objUWFInstances == null)
            {
                Console.WriteLine("无法检索 统一写入筛选器 (UWF)  设置。");
                return false;
            }
            foreach (var objUWFInstance in objUWFInstances)
            {
                if (driveLetter.ToUpper() == objUWFInstance["DriveLetter"].ToString().ToUpper())
                {
                    objUWFInstance["CurrentSession"] = "False";
                    objUWFInstance.Put();
                    ManagementBaseObject outParams = objUWFInstance.InvokeMethod("Unprotect", null, null);
                    // 检查返回值是否成功（0表示成功）
                    uint returnValue = (uint)(outParams?["ReturnValue"] ?? 1);
                    if (returnValue == 0)
                    {
                        Console.WriteLine(DriveLetter + "取消保护成功!");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine(DriveLetter + "取消保护失败!");
                        return false;
                    }
                }
            }
            return false;
        }
        public bool SetBindByDriveLetter(string driveLetter, bool bBindByVolumeName)
        {
            var objUWFInstances = Get_UWF_Volume();
            if (objUWFInstances == null)
            {
                Console.WriteLine("无法检索 统一写入筛选器 (UWF)  设置。");
                return false;
            }
            foreach (var objUWFInstance in objUWFInstances)
            {
                if (driveLetter.ToUpper() == objUWFInstance["DriveLetter"].ToString().ToUpper())
                {
                    ManagementBaseObject inParams = objUWFInstance.GetMethodParameters("SetBindByDriveLetter");
                    inParams["bBindByDriveLetter"] = bBindByVolumeName;
                    // 调用方法
                    ManagementBaseObject outParams = objUWFInstance.InvokeMethod("SetBindByDriveLetter", inParams, null);

                    // 检查返回值是否成功（0表示成功）
                    uint returnValue = (uint)(outParams?["ReturnValue"] ?? 1);
                    if (returnValue == 0)
                    {
                        Console.WriteLine("修改磁盘绑定类型成功!");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("修改磁盘绑定类型失败!");
                        return false;
                    }
                }
            }
            return false;
        }
        public bool AddExclusion(string FileName)
        {
            try
            {
                var objUWFInstances = Get_UWF_Volume();
                if (objUWFInstances == null)
                {
                    Console.WriteLine("无法检索 统一写入筛选器 (UWF)  设置。");
                    return false;
                }
                string driveLetter = Path.GetPathRoot(FileName).Replace("\\", "");
                string FileNamenew = FileName.Remove(0, 2);
                foreach (var objUWFInstance in objUWFInstances)
                {
                    if (driveLetter.ToUpper() == objUWFInstance["DriveLetter"].ToString().ToUpper())
                    {
                        ManagementBaseObject inParams = objUWFInstance.GetMethodParameters("AddExclusion");
                        inParams["FileName"] = FileNamenew;
                        // 调用方法
                        ManagementBaseObject outParams = objUWFInstance.InvokeMethod("AddExclusion", inParams, null);
                        // 检查返回值是否成功（0表示成功）
                        uint returnValue = (uint)(outParams?["ReturnValue"] ?? 1);
                        if (returnValue == 0)
                        {
                            Console.WriteLine("添加文件保护例外成功!");
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("添加文件保护例外失败!");
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            return false;
        }
        public bool RemoveExclusion(string FileName)
        {
            var objUWFInstances = Get_UWF_Volume();
            if (objUWFInstances == null)
            {
                Console.WriteLine("无法检索 统一写入筛选器 (UWF)  设置。");
                return false;
            }
            string driveLetter = Path.GetPathRoot(FileName).Replace("\\", "");
            string FileNamenew = FileName.Remove(0, 2);

            foreach (var objUWFInstance in objUWFInstances)
            {
                if (driveLetter.ToUpper() == objUWFInstance["DriveLetter"].ToString().ToUpper())
                {
                    ManagementBaseObject inParams = objUWFInstance.GetMethodParameters("RemoveExclusion");
                    inParams["FileName"] = FileNamenew;

                    // 调用方法
                    ManagementBaseObject outParams = objUWFInstance.InvokeMethod("RemoveExclusion", inParams, null);

                    // 检查返回值是否成功（0表示成功）
                    uint returnValue = (uint)(outParams?["ReturnValue"] ?? 1);
                    if (returnValue == 0)
                    {
                        Console.WriteLine("移除文件保护例外成功!");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("移除文件保护例外失败!");
                        return false;
                    }
                }
            }
            return false;
        }
        public bool RemoveAllExclusions(string driveLetter)
        {
            var objUWFInstances = Get_UWF_Volume();
            if (objUWFInstances == null)
            {
                Console.WriteLine("无法检索 统一写入筛选器 (UWF)  设置。");
                return false;
            }
            foreach (var objUWFInstance in objUWFInstances)
            {
                if (driveLetter.ToUpper() == objUWFInstance["DriveLetter"].ToString().ToUpper())
                {
                    // 调用方法
                    ManagementBaseObject outParams = objUWFInstance.InvokeMethod("RemoveAllExclusions", null, null);
                    // 检查返回值是否成功（0表示成功）
                    uint returnValue = (uint)(outParams?["ReturnValue"] ?? 1);
                    if (returnValue == 0)
                    {
                        Console.WriteLine("移除所有文件保护例外成功!");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("移除所有文件保护例外失败!");
                        return false;
                    }
                }
            }
            return false;
        }
        public void GetExclusions()
        {
            Dic_FileExclusion.Clear();
            var objUWFInstances = Get_UWF_Volume();
            if (objUWFInstances == null)
            {
                Console.WriteLine("无法检索 统一写入筛选器 (UWF)  设置。");
                return;
            }
            foreach (var objUWFInstance in objUWFInstances)
            {
                if (objUWFInstance["DriveLetter"].ToString() == "" || objUWFInstance["DriveLetter"] == null) continue;
                try
                {
                    ManagementBaseObject outParams = objUWFInstance.InvokeMethod("GetExclusions", null, null);
                    // 检查返回值是否成功（0表示成功）
                    uint returnValue = (uint)(outParams?["ReturnValue"] ?? 1);
                    if (returnValue == 0)
                    {
                        // 提取 OverlayFiles 数组
                        if (outParams["ExcludedFiles"] is ManagementBaseObject[] ExcludedFiles)
                        {
                            string[] fileNames = new string[ExcludedFiles.Length];

                            for (int i = 0; i < ExcludedFiles.Length; i++)
                            {
                                if (Dic_FileExclusion.ContainsKey(objUWFInstance["DriveLetter"].ToString()))
                                {
                                    Dic_FileExclusion[objUWFInstance["DriveLetter"].ToString()].Add(ExcludedFiles[i]["FileName"].ToString());
                                }
                                else
                                {
                                    Dic_FileExclusion[objUWFInstance["DriveLetter"].ToString()] = new List<string>() { ExcludedFiles[i]["FileName"].ToString() };
                                }
                                // 假设每个 ManagementBaseObject 具有一个 "FileName" 属性
                                fileNames[i] = objUWFInstance["DriveLetter"] + ExcludedFiles[i]["FileName"].ToString();
                                Console.WriteLine(fileNames[i]);
                                Dic_FileExclusion = Dic_FileExclusion.OrderBy(kvp => kvp.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                            }
                        }

                    }
                }
                catch (ManagementException ex)
                {
                    Console.WriteLine(objUWFInstance["DriveLetter"].ToString() + ex.Message + " " + ex.ErrorCode);
                    continue;
                }
            }
            return;
        }

        public Dictionary<string, bool> GetDriverLetters()
        {
            Dictionary<string, bool> Dic_DriverLetter = new Dictionary<string, bool>();
            var objUWFInstances = Get_UWF_Volume();
            if (objUWFInstances == null)
            {
                Console.WriteLine("无法检索 统一写入筛选器 (UWF)  设置。");
                return null;
            }
            foreach (var objUWFInstance in objUWFInstances)
            {
                if (objUWFInstance["DriveLetter"].ToString() == "" || objUWFInstance["DriveLetter"] == null) continue;
                if (Dic_DriverLetter.ContainsKey(objUWFInstance["DriveLetter"].ToString()) == false)
                    Dic_DriverLetter[objUWFInstance["DriveLetter"].ToString()] = objUWFInstance["Protected"] == null ? false : (bool)objUWFInstance["Protected"];
                else if (Dic_DriverLetter[objUWFInstance["DriveLetter"].ToString()] == false)
                    Dic_DriverLetter[objUWFInstance["DriveLetter"].ToString()] = objUWFInstance["Protected"] == null ? false : (bool)objUWFInstance["Protected"];
            }
            return Dic_DriverLetter;
        }



        List<ManagementObject> Get_UWF_Volume()
        {
            string className = "UWF_Volume";
            // 创建 ManagementClass 对象
            ManagementClass managementClass = new ManagementClass(namespacePath + ":" + className);
            MethodDataCollection methods = managementClass.Methods;
            // 列出所有方法的名称
            foreach (MethodData method in methods)
            {
                Console.WriteLine("Method Name: " + method.Name);
            }
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(namespacePath, $"SELECT * FROM UWF_Volume WHERE CurrentSession = {CurrentSession}");
            ManagementObjectCollection results = searcher.Get();
            managementObjects.Clear();
            foreach (ManagementObject obj in results.Cast<ManagementObject>())
            {
                managementObjects.Add(obj);
            }
            managementObjects.Sort((x, y) => x["DriveLetter"].ToString().CompareTo(y["DriveLetter"].ToString()));

            return managementObjects;
        }
    }
}
