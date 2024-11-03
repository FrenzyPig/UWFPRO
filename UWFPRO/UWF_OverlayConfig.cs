using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace UWFCMD
{
    internal class UWF_OverlayConfig
    {
        private readonly string namespacePath = @"root\standardcimv2\embedded";

        public bool CurrentSession;
        public uint Type;
        public uint MaximumSize;

        public UWF_OverlayConfig(bool currentSession)
        {
            CurrentSession = currentSession;
        }

        public uint SetType(uint type)
        {
            Set_OverlayType(type);
            return 0;
        }
        public uint SetMaximumSize(uint size)
        {
            Set_MaximumSize(size);
            return 0;
        }

        public void GetConfig()
        {
            Get_Value();
            Console.WriteLine("CurrentSession: " + CurrentSession);
            Console.WriteLine("Type: " + (Type == 0 ? "内存" : "磁盘"));
            Console.WriteLine("MaximumSize: " + MaximumSize);
        }

        ManagementObject Get_UWF_OverlayConfig()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(namespacePath, $"SELECT * FROM UWF_OverlayConfig WHERE CurrentSession = {CurrentSession}");
            ManagementObjectCollection results = searcher.Get();
            foreach (ManagementObject obj in results.Cast<ManagementObject>())
            {
                return obj;
            }
            return null;
        }


        void Set_MaximumSize(uint size)
        {
            var objUWFInstance = Get_UWF_OverlayConfig();
            if (objUWFInstance == null)
            {
                Console.WriteLine("无法检索 统一写入筛选器 (UWF)  设置。");
                return;
            }
            ManagementBaseObject inParams = objUWFInstance.GetMethodParameters("SetMaximumSize");
            inParams["size"] = size;
            objUWFInstance.InvokeMethod("SetMaximumSize", inParams, null);
            Get_Value();
            Console.WriteLine("该覆盖最大大小已设置为 " + MaximumSize + " MB。");
        }

        void Set_OverlayType(uint type)
        {
            var objUWFInstance = Get_UWF_OverlayConfig();
            if (objUWFInstance == null)
            {
                Console.WriteLine("无法检索 统一写入筛选器 (UWF)  设置。");
                return;
            }
            ManagementBaseObject inParams = objUWFInstance.GetMethodParameters("SetType");
            inParams["type"] = type;
            objUWFInstance.InvokeMethod("SetType", inParams, null);
            Get_Value();
            Console.WriteLine("该覆盖类型已设置为 " + (type == 0 ? "内存" : "磁盘"));
        }

        void Get_Value()
        {
            var objUWFInstance = Get_UWF_OverlayConfig();
            if (objUWFInstance == null)
            {
                Console.WriteLine("无法检索 统一写入筛选器 (UWF)  设置。");
                return;
            }
            CurrentSession = (bool)objUWFInstance["CurrentSession"];
            Type = (uint)objUWFInstance["Type"];
            MaximumSize = (uint)objUWFInstance["MaximumSize"];
        }


    }
}
