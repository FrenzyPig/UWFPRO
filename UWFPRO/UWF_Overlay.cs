using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace UWFCMD
{
    internal class UWF_Overlay
    {
        private readonly string namespacePath = @"root\standardcimv2\embedded";
        public string Id;
        public uint OverlayConsumption;
        public uint AvailableSpace;
        public uint CriticalOverlayThreshold;
        public uint WarningOverlayThreshold;

        public uint GetOverlayFiles(string Volume)
        {
            Get_OverlayFiles(Volume);
            return 0;
        }

        public uint SetWarningThreshold(uint size)
        {
            Set_OverlayWarningSize(size);
            return 0;
        }
        public uint SetCriticalThreshold(uint size)
        {
            Set_OverlayCriticalSize(size);
            return 0;
        }

        void Set_OverlayWarningSize(uint WarningSize)
        {
            var objUWFInstance = Get_UWF_Overlay();
            if (objUWFInstance == null)
            {
                Console.WriteLine("无法检索 统一写入筛选器 (UWF)  设置。");
                return;
            }
            ManagementBaseObject inParams = objUWFInstance.GetMethodParameters("SetWarningThreshold");
            inParams["size"] = WarningSize;
            objUWFInstance.InvokeMethod("SetWarningThreshold", inParams, null);
            Get_Value();
            Console.WriteLine("该覆盖警告阈值已设置为 " + WarningOverlayThreshold + " MB。");
        }

        void Set_OverlayCriticalSize(uint CriticalSize)
        {
            var objUWFInstance = Get_UWF_Overlay();
            if (objUWFInstance == null)
            {
                Console.WriteLine("无法检索 统一写入筛选器 (UWF)  设置。");
                return;
            }
            ManagementBaseObject inParams = objUWFInstance.GetMethodParameters("SetCriticalThreshold");
            inParams["size"] = CriticalSize;
            objUWFInstance.InvokeMethod("SetCriticalThreshold", inParams, null);
            Get_Value();
            Console.WriteLine("该覆盖严重阈值已设置为 " + CriticalOverlayThreshold + " MB。");
        }

        public void GetConfig()
        {
            Get_Value();

            //Get_OverlayFiles("C:");
            Console.WriteLine("Id: " + Id);
            Console.WriteLine("AvailableSpace: " + AvailableSpace);
            Console.WriteLine("WarningOverlayThreshold: " + WarningOverlayThreshold);
            Console.WriteLine("CriticalOverlayThreshold: " + CriticalOverlayThreshold);
            Console.WriteLine("OverlayConsumption: " + OverlayConsumption);
        }


        ManagementObject Get_UWF_Overlay()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(namespacePath, "SELECT * FROM UWF_Overlay");
            ManagementObjectCollection results = searcher.Get();
            List<ManagementObject> lst_ManagementObject = new List<ManagementObject>();
            foreach (ManagementObject obj in results.Cast<ManagementObject>())
            {
                lst_ManagementObject.Add(obj);
            }
            if (lst_ManagementObject.Count == 1)
                return lst_ManagementObject[0];
            return null;
        }

        void Get_Value()
        {
            var objUWFInstance = Get_UWF_Overlay();
            if (objUWFInstance == null)
            {
                Console.WriteLine("无法检索 统一写入筛选器 (UWF) 设置。");
                return;
            }

            Id = objUWFInstance["Id"].ToString();
            AvailableSpace = (uint)objUWFInstance["AvailableSpace"];
            CriticalOverlayThreshold = (uint)objUWFInstance["CriticalOverlayThreshold"];
            WarningOverlayThreshold = (uint)objUWFInstance["WarningOverlayThreshold"];
            OverlayConsumption = (uint)objUWFInstance["OverlayConsumption"];
        }
        //有问题.
        private void Get_OverlayFiles(string Volume)
        {

            var objUWFInstance = Get_UWF_Overlay();
            if (objUWFInstance == null)
            {
                Console.WriteLine("无法检索 统一写入筛选器 (UWF) 设置。");
                return;
            }
            ManagementBaseObject inParams = objUWFInstance.GetMethodParameters("GetOverlayFiles");
            inParams["Volume"] = Volume;

            // 调用方法
            ManagementBaseObject outParams = objUWFInstance.InvokeMethod("GetOverlayFiles", inParams, null);

            // 检查返回值是否成功（0表示成功）
            uint returnValue = (uint)(outParams?["ReturnValue"] ?? 1);
            if (returnValue == 0)
            {
                var overlayFiles = outParams["OverlayFiles"] as ManagementBaseObject[];
                // 提取 OverlayFiles 数组
                if (overlayFiles != null)
                {
                    string[] fileNames = new string[overlayFiles.Length];

                    for (int i = 0; i < overlayFiles.Length; i++)
                    {
                        // 假设每个 ManagementBaseObject 具有一个 "FileName" 属性
                        fileNames[i] = Volume + overlayFiles[i]["FileName"].ToString() + "[" + (ulong)overlayFiles[i]["FileSize"] + "]";
                        Console.WriteLine(fileNames[i]);
                    }
                }
            }

            return;

        }

    }
}
