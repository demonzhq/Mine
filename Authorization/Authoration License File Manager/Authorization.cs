using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Runtime.InteropServices;
using System.Management;
using System.Xml;
using System.Threading;


// LocalLiceseFormat:  ProjectName|CPUID|AuthoDay|CurrentDate|ExpireDate|UpdateServer|isValid|Message

namespace Authorization
{

    public delegate void AuthoPassEvent();
    public delegate void AuthoFailedEvent();
    public delegate void AuthoMessageEvent(string mMessage);

    public class Autho
    {


        public event AuthoPassEvent AuthoPass;
        public event AuthoFailedEvent AuthoFailed;
        public event AuthoMessageEvent AuthoMessage;


        public bool isRead = false;
        public string iv = "ZHQLICIV";
        public string key;
        public string DefaultServer = "http://autho.klaid.cn/index.php";
        public string ProjectName = "";
        public string LicProjectName = "";
        public string CPUID = "";
        public int AuthoDay = 0;
        public string LastUpdateDate = "";
        public string ExpireDate = "";
        public string UpdateServer = "";
        public string LicenseFile = "Autho.lic";
        public string Message = "";
        public bool isValid = false;

        string ErrorMessage = "";
        public string Encrypt(string sourceString, string key, string iv)
        {
            try
            {
                byte[] btKey = Encoding.UTF8.GetBytes(key);

                byte[] btIV = Encoding.UTF8.GetBytes(iv);

                DESCryptoServiceProvider des = new DESCryptoServiceProvider();

                using (MemoryStream ms = new MemoryStream())
                {
                    byte[] inData = Encoding.UTF8.GetBytes(sourceString);
                    try
                    {
                        using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(btKey, btIV), CryptoStreamMode.Write))
                        {
                            cs.Write(inData, 0, inData.Length);

                            cs.FlushFinalBlock();
                        }

                        return Convert.ToBase64String(ms.ToArray());
                    }
                    catch
                    {
                        return sourceString;
                    }
                }
            }
            catch { }

            return "DES加密出错";
        }

        public string Decrypt(string encryptedString, string key, string iv)
        {
            byte[] btKey = Encoding.UTF8.GetBytes(key);

            byte[] btIV = Encoding.UTF8.GetBytes(iv);

            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            using (MemoryStream ms = new MemoryStream())
            {
                byte[] inData = Convert.FromBase64String(encryptedString);
                try
                {
                    using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(btKey, btIV), CryptoStreamMode.Write))
                    {
                        cs.Write(inData, 0, inData.Length);

                        cs.FlushFinalBlock();
                    }

                    return Encoding.UTF8.GetString(ms.ToArray());
                }
                catch
                {
                    return encryptedString;
                }
            }
        }

        public Autho(string ProjectName)
        {
            this.ProjectName = ProjectName;
            this.key = ProjectName;
        }

        public Autho(string ProjectName, string LicenseFile)
        {
            this.ProjectName = ProjectName;
            this.LicenseFile = LicenseFile;
            this.key = ProjectName;
        }

        public Autho(string ProjectName, string LicenseFile, string key)
        {
            this.ProjectName = ProjectName;
            this.LicenseFile = LicenseFile;
            this.key = ProjectName;
        }

        public Autho(string ProjectName, string LicenseFile, string key, string iv)
        {
            this.ProjectName = ProjectName;
            this.LicenseFile = LicenseFile;
            this.iv = iv;
            this.key = key;
        }

        public bool isLocalAuthorised()
        {
            bool Result = GetDataFromLic();
            if (Result)
            {
                Result = UpdateValidStatus();
                if (Result)
                {
                    return isValid;
                }
            }
            isValid = false;
            return isValid;
        }

        public bool UpdateValidStatus()
        {
            bool Result = false;
            isValid = false;

            try
            {
                DateTime LicLastUpdateDate = DateTime.Parse(LastUpdateDate);
                DateTime LicDTExpire = DateTime.Parse(ExpireDate);
                //LicLastUpdateDate = DateTime.Parse(LastUpdateDate);
                //LicDTExpire = DateTime.Parse(ExpireDate);

                if (!isValid)
                    isValid = false;
                else if (LicProjectName != ProjectName)
                    isValid = false;
                else if (CPUID != GetCPUID())
                    isValid = false;
                else if (LicDTExpire < DateTime.Now)
                    isValid = false;
                else if (DateTime.Now.Subtract(LicLastUpdateDate) >= System.TimeSpan.FromDays(AuthoDay))
                    isValid = false;
                else isValid = true;

                Result = true;
            }
            catch
            {
                this.isValid = false;
                Result = false;
            }

            return Result;
        }

        public bool UpdateStatus()
        {
            try
            {
                this.LastUpdateDate = DateTime.Now.ToString("yyyy-MM-dd");
                this.CPUID = GetCPUID();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool GenerateLic()
        {
            try
            {
                string ResultPlain = ProjectName + "|" + CPUID + "|" + AuthoDay + "|" + LastUpdateDate + "|" + ExpireDate + "|" + UpdateServer + "|" + isValid.ToString() + "|" + Message;
                string ResultEncrypt = Encrypt(ResultPlain, key, iv);
                string Plan = Decrypt(ResultEncrypt, key, iv);



                if (File.Exists(LicenseFile))
                    File.Delete(LicenseFile);
                FileStream fsLic = new FileStream(LicenseFile, FileMode.OpenOrCreate);
                BinaryWriter bwLic = new BinaryWriter(fsLic);
                byte[] target = GetByteArray(ResultEncrypt);
                bwLic.Write(target);
                fsLic.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public byte[] GetByteArray(string shex)
        {
            char[] ssArray = shex.ToCharArray();
            List<byte> bytList = new List<byte>();
            foreach (var s in ssArray)
            {
                //将十六进制的字符串转换成数值
                bytList.Add(Convert.ToByte(0xff - s));
            }
            //返回字节数组
            return bytList.ToArray();
        }

        public string GetStringFromByteArray(byte[] ByteArray)
        {
            string Result = "";
            foreach (byte q in ByteArray)
                Result += Convert.ToChar(0xFF - q);
            return Result;
        }

        public bool RenewLicense()
        {
            GetDataFromLic();
            string ServerBase = "";
            string ServerRequest = "?";
            if (UpdateServer == "")
            {
                ServerBase = DefaultServer;
            }
            else
            {
                ServerBase = UpdateServer;
            }

            ServerRequest = ServerRequest + "Project=" + ProjectName;
            ServerRequest = ServerRequest + "&" + "CPU=" + GetCPUID();
            ServerRequest = ServerRequest + "&" + "Machine=" + System.Environment.MachineName;
            ServerRequest = ServerRequest + "&" + "Domin=" + System.Environment.UserDomainName;
            ServerRequest = ServerRequest + "&" + "User=" + System.Environment.UserName;
            ServerRequest = ServerRequest + "&" + "OS=" + System.Environment.OSVersion;

            XmlDocument Root = new XmlDocument();
            try
            {
                isRead = false;
                Root.Load(ServerBase + ServerRequest);
                //Get parameter

                LastUpdateDate = Convert.ToDateTime(Root.GetElementsByTagName("CurrentDate")[0].InnerText).ToString("yyyy-MM-dd");
                ExpireDate = Convert.ToDateTime(Root.GetElementsByTagName("ExpireDate")[0].InnerText).ToString("yyyy-MM-dd");
                AuthoDay = Convert.ToInt32(Root.GetElementsByTagName("AuthoDay")[0].InnerText);
                UpdateServer = Root.GetElementsByTagName("UpdateServer")[0].InnerText;
                Message = Root.GetElementsByTagName("Message")[0].InnerText;
                isRead = true;
                int TempValid = Convert.ToInt32(Root.GetElementsByTagName("isValid")[0].InnerText);
                if (TempValid == 1)
                    this.isValid = true;
                else this.isValid = false;
                bool GenResult = GenerateLic();
                if (GenResult)
                    return true;
                else return false;
            }
            catch
            {
                return false;
            }
        }

        public bool GetDataFromLic()
        {
            try
            {
                isRead = false;
                FileStream fsLic = new FileStream(LicenseFile, FileMode.Open);
                BinaryReader brLic = new BinaryReader(fsLic);
                byte[] byteLic = new byte[fsLic.Length];
                brLic.Read(byteLic, 0, Convert.ToInt32(fsLic.Length));
                fsLic.Close();
                string LicResult = GetStringFromByteArray(byteLic);
                string[] Result = Decrypt(LicResult, key, iv).Split('|');
                if (Result != null)
                {
                    if (Result.Length < 7)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        this.LicProjectName = Result[0];
                        this.CPUID = Result[1];
                        this.AuthoDay = Convert.ToInt32(Result[2]);
                        this.LastUpdateDate = Result[3];
                        this.ExpireDate = Result[4];
                        this.UpdateServer = Result[5];
                        string strTempValid = Result[6];
                        if (strTempValid.ToUpper() == "TRUE" || strTempValid.ToUpper() == "1")
                        {
                            isValid = true;
                        }
                        else
                        {
                            isValid = false;
                        }
                        if (Result.Length == 8)
                        {
                            Message = Result[7];
                        }
                        isRead = true;
                    }
                }
                else
                {
                    throw new Exception();
                }
                return true;
            }
            catch (Exception error)
            {
                ErrorMessage = error.Message;
                isRead = false;
                isValid = false;
                return false;
            }
        }


        public string GetCPUID()
        {
            //GetCPUID
            string CPUID = "";
            ManagementClass mc = new ManagementClass("Win32_BaseBoard");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                CPUID = mo.Properties["SerialNumber"].Value.ToString();
                CPUID = CPUID.Replace('/', '-');
                //break;
            }
            return CPUID;
        }

        public bool AuthoProcess()
        {
            bool RenewResult = RenewLicense();
            UpdateStatus();
            GenerateLic();
            if (Message != "void")
            {
                AuthoMessage(this.Message);
            }
            if (isLocalAuthorised())
            {
                AuthoPass();
                return true;
            }
            else
            {
                AuthoFailed();
                return false;
            }


        }

        public string GetMessage()
        {
            return Message;
        }




    }
}
