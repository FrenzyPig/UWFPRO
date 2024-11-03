using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace UWFCMD
{
    internal class UWF_RegistryFilter
    {
        private readonly string namespacePath = @"root\standardcimv2\embedded";
        public bool CurrentSession;
        public bool PersistDomainSecretKey;
        public bool PersistTSCAL;
        public List<string> List_RegistryExclusions = new List<string>();

        public UWF_RegistryFilter(bool currentSession)
        {
            CurrentSession = currentSession;
        }

        public bool AddExclusion(string RegistryKey)
        {
            return Add_Reg_Exclusion(RegistryKey);
        }
        public uint RemoveExclusion(string RegistryKey)
        {
            Remove_Reg_Exclusion(RegistryKey);
            return 0;
        }
        public uint FindExclusion(string RegistryKey, out bool bFound)
        {
            bFound = false;
            return 0;
        }

        public bool GetExclusions()
        {
            List_RegistryExclusions.Clear();
            var objUWFInstance = Get_UWF_RegistryFilter();
            if (objUWFInstance == null)
            {
                Console.WriteLine("无法检索 统一写入筛选器 (UWF)  设置。");
                return false;
            }
            ManagementBaseObject outParams = objUWFInstance.InvokeMethod("GetExclusions", null, null);
            uint returnValue = (uint)(outParams?["ReturnValue"] ?? 1);
            if (returnValue == 0)
            {
                if (outParams["ExcludedKeys"] is ManagementBaseObject[] ExcludedFiles)
                {
                    string[] fileNames = new string[ExcludedFiles.Length];

                    for (int i = 0; i < ExcludedFiles.Length; i++)
                    {
                        List_RegistryExclusions.Add(ExcludedFiles[i]["RegistryKey"].ToString());
                        Console.WriteLine(ExcludedFiles[i]["RegistryKey"].ToString());
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CommitRegistry(string fullRegistryPath)
        {
            var objUWFInstance = Get_UWF_RegistryFilter();
            if (objUWFInstance == null)
            {
                Console.WriteLine("无法检索 统一写入筛选器 (UWF)  设置。");
                return false;
            }
            string RegistryKey = "";
            string ValueName = "";
            int lastBackslashIndex = fullRegistryPath.LastIndexOf('\\');
            if (lastBackslashIndex != -1)
            {
                // 提取 RegistryKey 和 ValueName
                RegistryKey = fullRegistryPath.Substring(0, lastBackslashIndex);
                ValueName = fullRegistryPath.Substring(lastBackslashIndex + 1);
                Console.WriteLine("RegistryKey: " + RegistryKey);
                Console.WriteLine("ValueName: " + ValueName);
            }
            else
            {
                Console.WriteLine("无效的注册表路径。");
                return false;
            }
            ManagementBaseObject inParams = objUWFInstance.GetMethodParameters("CommitRegistry");
            inParams["RegistryKey"] = RegistryKey;
            inParams["ValueName"] = ValueName;
            ManagementBaseObject outParams = objUWFInstance.InvokeMethod("CommitRegistry", inParams, null);
            uint returnValue = (uint)(outParams?["ReturnValue"] ?? 1);
            if (returnValue == 0)
            {
                Console.WriteLine(RegistryKey + ValueName + " 提交成功!");
                return true;
            }
            else
            {
                Console.WriteLine(RegistryKey + ValueName + " 提交失败!");
                return false;
            }
        }
        public uint CommitRegistryDeletion(string Registrykey, string ValueName)
        {
            return 0;
        }



        void Commit_Reg_Value(string RegistryKey, string ValueName)
        {

        }

        bool Add_Reg_Exclusion(string RegistryKey)
        {
            var objUWFInstance = Get_UWF_RegistryFilter();
            if (objUWFInstance == null)
            {
                Console.WriteLine("无法检索 统一写入筛选器 (UWF)  设置。");
                return false;
            }
            ManagementBaseObject inParams = objUWFInstance.GetMethodParameters("AddExclusion");
            inParams["RegistryKey"] = RegistryKey;
            ManagementBaseObject outParams = objUWFInstance.InvokeMethod("AddExclusion", inParams, null);
            uint returnValue = (uint)(outParams?["ReturnValue"] ?? 1);
            if (returnValue == 0)
            {
                Console.WriteLine(RegistryKey + " 例外添加成功!");
                return true;
            }
            else
            {
                Console.WriteLine(RegistryKey + " 例外添加失败!");
                return false;
            }
        }
        void Remove_Reg_Exclusion(string RegistryKey)
        {
            var objUWFInstance = Get_UWF_RegistryFilter();
            if (objUWFInstance == null)
            {
                Console.WriteLine("无法检索 统一写入筛选器 (UWF)  设置。");
                return;
            }
            ManagementBaseObject inParams = objUWFInstance.GetMethodParameters("RemoveExclusion");
            inParams["RegistryKey"] = RegistryKey;
            ManagementBaseObject outParams = objUWFInstance.InvokeMethod("RemoveExclusion", inParams, null);
            Get_Value();
        }

        void Get_Value()
        {
            var objUWFInstance = Get_UWF_RegistryFilter();
            if (objUWFInstance == null)
            {
                Console.WriteLine("无法检索 统一写入筛选器 (UWF)  设置。");
                return;
            }
            CurrentSession = (bool)objUWFInstance["CurrentSession"];
            PersistDomainSecretKey = (bool)objUWFInstance["PersistDomainSecretKey"];
            PersistTSCAL = (bool)objUWFInstance["PersistTSCAL"];
        }

        ManagementObject Get_UWF_RegistryFilter()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(namespacePath, "SELECT * FROM UWF_RegistryFilter");
            ManagementObjectCollection results = searcher.Get();
            foreach (ManagementObject obj in results.Cast<ManagementObject>())
            {
                if ((bool)obj["CurrentSession"] == CurrentSession)
                    return obj;
            }
            return null;
        }


    }
}