using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace UWFCMD
{
    internal class UWF_Filter
    {
        private readonly string namespacePath = @"root\standardcimv2\embedded";
        public string Id;
        public bool CurrentEnabled;
        public bool NextEnabled;

        public UWF_Filter()
        {
            Get_Value();
        }

        public int Enable()
        {
            EnableUWF();
            Get_Value();
            return 0;
        }
        public int Disable()
        {
            DisableUWF();
            Get_Value();
            return 0;
        }
        public int ResetSettings()
        {
            ResetSettingsUWF();
            Get_Value();
            return 0;
        }
        public int ShutdownSystem()
        {
            ShutdownUWF();
            Get_Value();
            return 0;
        }
        public int RestartSystem()
        {
            RestartUWF();
            Get_Value();
            return 0;
        }
        public void GetConfig()
        {
            Get_Value();
            Console.WriteLine();
            Console.WriteLine("统一写入筛选器 (UWF) 当前状态: " + CurrentEnabled);
            Console.WriteLine();
            Console.WriteLine("统一写入筛选器 (UWF) 下次状态: " + NextEnabled);
        }

        #region UWF_Filter
        ManagementObject Get_UWF_Filter()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(namespacePath, "SELECT * FROM UWF_Filter");
            ManagementObjectCollection results = searcher.Get();
            List<ManagementObject> lst_ManagementObject = new List<ManagementObject>();
            foreach (ManagementObject obj in results.Cast<ManagementObject>())
            {
                lst_ManagementObject.Add(obj);
            }
            if (lst_ManagementObject.Count == 1) return lst_ManagementObject[0];
            return null;
        }

        void DisableUWF()
        {
            var objUWFInstance = Get_UWF_Filter();
            if (objUWFInstance == null)
            {
                Console.WriteLine("无法检索 统一写入筛选器 (UWF) 设置。");
                return;
            }

            // 调用禁用 UWF 的方法
            var retval = objUWFInstance.InvokeMethod("Disable", null, null);

            // 检查返回值以验证禁用是否成功
            if (Convert.ToUInt32(retval["ReturnValue"]) == 0)
            {
                Console.WriteLine("统一写入筛选器 (UWF) 将在下次系统重启后禁用。");
            }
            else
            {
                Console.WriteLine("uwfcmd filter disable 未知错误: " + string.Format("{0:x0}", retval["ReturnValue"]));
            }
        }

        void ResetSettingsUWF()
        {
            var objUWFInstance = Get_UWF_Filter();
            if (objUWFInstance == null)
            {
                Console.WriteLine("无法检索 统一写入筛选器 (UWF) 设置。");
                return;
            }

            // 调用禁用 UWF 的方法
            var retval = objUWFInstance.InvokeMethod("ResetSettings", null, null);

            // 检查返回值以验证禁用是否成功
            if (Convert.ToUInt32(retval["ReturnValue"]) == 0)
            {
                //todo: some out put
                Console.WriteLine("统一写入筛选器 (UWF) 将在下次系统重启后禁用。");
            }
            else
            {
                Console.WriteLine("uwfcmd filter resetsettings 未知错误: " + string.Format("{0:x0}", retval["ReturnValue"]));
            }
        }

        void EnableUWF()
        {
            var objUWFInstance = Get_UWF_Filter();
            if (objUWFInstance == null)
            {
                Console.WriteLine("无法检索 统一写入筛选器 (UWF)  设置。");
                return;
            }

            // 调用启用 UWF 的方法
            var retval = objUWFInstance.InvokeMethod("Enable", null, null);

            // 检查返回值以验证启用是否成功
            if (Convert.ToUInt32(retval["ReturnValue"]) == 0)
            {
                Console.WriteLine("统一写入筛选器 (UWF) 将在下次系统重启后启用。");
            }
            else
            {
                Console.WriteLine("uwfcmd filter enable 未知错误: " + string.Format("{0:x0}", retval["ReturnValue"]));
            }
        }

        void ShutdownUWF()
        {
            var objUWFInstance = Get_UWF_Filter();
            if (objUWFInstance == null)
            {
                Console.WriteLine("无法检索 统一写入筛选器 (UWF)  设置。");
                return;
            }
            // 调用启用 UWF 的方法
            objUWFInstance.InvokeMethod("ShutdownSystem", null, null);
        }

        void RestartUWF()
        {
            var objUWFInstance = Get_UWF_Filter();
            if (objUWFInstance == null)
            {
                Console.WriteLine("无法检索 统一写入筛选器 (UWF)  设置。");
                return;
            }
            // 调用启用 UWF 的方法
            objUWFInstance.InvokeMethod("RestartSystem", null, null);
        }

        void Get_Value()
        {
            var objUWFInstance = Get_UWF_Filter();
            if (objUWFInstance == null)
            {
                Console.WriteLine("无法检索 统一写入筛选器 (UWF) 设置。");
                return;
            }

            Id = objUWFInstance["Id"].ToString();
            CurrentEnabled = (bool)objUWFInstance["CurrentEnabled"];
            NextEnabled = (bool)objUWFInstance["NextEnabled"];
        }
        #endregion

    }
}
