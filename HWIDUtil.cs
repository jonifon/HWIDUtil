using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHWID
{
    internal class HWIDUtil
    {   // motherboard id + cpu id + ram id + disk id = HWID
        public static string HWID = GetComponent("Win32_BaseBoard", "SerialNumber") + GetComponent("win32_processor", "processorID") + GetComponent("Win32_PhysicalMemory", "SerialNumber") + GetComponent("Win32_DiskDrive", "SerialNumber");

        // https://learn.microsoft.com/ru-ru/windows/win32/cimwin32prov/computer-system-hardware-classes?redirectedfrom=MSDN
        public static string GetComponent(string hwclass, string syntax)
        {
            var output = string.Empty;
            ManagementObjectSearcher mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM " + hwclass);
            foreach (ManagementObject mj in mos.Get())
            {
                output = Convert.ToString(mj[syntax]);
            }
            return output;
        }
    }
}
