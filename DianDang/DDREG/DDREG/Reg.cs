using System;
using System.Collections.Generic;
using System.Text;
using System.Management;

namespace DDReg
{
    class Reg
    {
        //取CPU编号
        public string GetCpuID()
        {


            try
            {
                ManagementClass mc = new ManagementClass("Win32_Processor");
                ManagementObjectCollection moc = mc.GetInstances();

                String strCpuID = null;
                foreach (ManagementObject mo in moc)
                {
                    strCpuID = mo.Properties["ProcessorId"].Value.ToString();
                    break;
                }
                return strCpuID;
            }
            catch
            {
                return "";
            }

        }//end method

        //取第一块硬盘编号，因为移动硬盘的复杂性，所以不建议加密时同时对CPUID和HDID操作，如果用户把移动硬盘设为启动盘，就会造成注册码和机器码经过运算后不符合的错误。
        public string GetHardDiskID()
        {
            string HDid = "";
            try
            {

                ManagementClass cimobject1 = new ManagementClass("Win32_DiskDrive");
                ManagementObjectCollection moc1 = cimobject1.GetInstances();
                foreach (ManagementObject mo in moc1)
                {
                    HDid = (string)mo.Properties["Model"].Value;


                }
                return HDid;
            }
            catch
            {
                return "";
            }
        }

        public string getMd5(string md5)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] value, hash;
            value = System.Text.Encoding.UTF8.GetBytes(md5);
            hash = md.ComputeHash(value);
            md.Clear();
            string temp = "";
            for (int i = 0, len = hash.Length; i < len; i++)
            {
                temp += hash[i].ToString("x").PadLeft(2, '0');
            }
            return temp;
        }
    }
}
