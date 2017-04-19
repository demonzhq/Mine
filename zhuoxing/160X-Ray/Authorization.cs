using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Runtime.InteropServices;
//using System.Management;
using System.Xml;
using System.Threading;
using System.Net;


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

        private bool isRead = false;
        private string iv = "ZHQLICIV";
        private string key;
        private string DefaultServer = "http://autho.klaid.cn/index.php";
        private string ProjectName = "";
        private string LicProjectName = "";
        private string CPUID = "";
        private int AuthoDay = 0;
        private string LastUpdateDate = "";
        private string ExpireDate = "";
        private string UpdateServer = "";
        private string LicenseFile = "Autho.lic";
        private string Message = "";
        private bool isValid = false;

        private string SrvDESDeCode(string pToDecrypt)
        {
            //    HttpContext.Current.Response.Write(pToDecrypt + "<br>" + sKey);     
            //    HttpContext.Current.Response.End();     
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
            for (int x = 0; x < pToDecrypt.Length / 2; x++)
            {
                int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
                inputByteArray[x] = (byte)i;
            }

            des.Key = ASCIIEncoding.ASCII.GetBytes(this.iv);
            des.IV = ASCIIEncoding.ASCII.GetBytes(this.iv);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            StringBuilder ret = new StringBuilder();

            return System.Text.Encoding.Default.GetString(ms.ToArray());
        }

        public string HttpGet(string Url, string postDataStr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }
        private string Encrypt(string sourceString, string key, string iv)
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

        private string Decrypt(string encryptedString, string key, string iv)
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
            key = ProjectName;
            while (key.Length < 8)
            {
                key = key + "Z";
            }

        }

        public Autho(string ProjectName, string LicenseFile)
        {
            this.ProjectName = ProjectName;
            this.LicenseFile = LicenseFile;
            this.key = ProjectName;
            while (key.Length < 8)
            {
                key = key + "Z";
            }
        }

        public Autho(string ProjectName, string LicenseFile, string key)
        {
            this.ProjectName = ProjectName;
            this.LicenseFile = LicenseFile;
            this.key = key;
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

        private bool UpdateValidStatus()
        {
            bool Result = false;

            try
            {

                DateTime LicLastUpdateDate = DateTime.Parse(LastUpdateDate);
                DateTime LicDTExpire = DateTime.Parse(ExpireDate);

               // LicLastUpdateDate = DateTime.Parse(LastUpdateDate);
               // LicDTExpire = DateTime.Parse(ExpireDate);

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

        private bool UpdateStatus()
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

        private bool GenerateLic()
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

        private byte[] GetByteArray(string shex)
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

        private string GetStringFromByteArray(byte[] ByteArray)
        {
            string Result = "";
            foreach (byte q in ByteArray)
                Result += Convert.ToChar(0xFF - q);
            return Result;
        }

        private bool RenewLicense()
        {
            GetDataFromLic();
            string ServerBase = "";
            string ServerRequest = "";
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
            ServerRequest = ServerRequest + "&" + "Encrypt=Y";

            XmlDocument Root = new XmlDocument();
            try
            {
                this.isRead = false;
                try
                {
                    string HttpResult = HttpGet(ServerBase, ServerRequest).Trim();
                    Root.LoadXml(SrvDESDeCode(HttpResult));
                }
                catch
                {
                    string HttpResult = HttpGet(DefaultServer, ServerRequest);
                    Root.LoadXml(SrvDESDeCode(HttpResult));
                }
                
                //Get parameter

                this.LastUpdateDate = Convert.ToDateTime(Root.GetElementsByTagName("CurrentDate")[0].InnerText).ToString("yyyy-MM-dd");
                this.ExpireDate = Convert.ToDateTime(Root.GetElementsByTagName("ExpireDate")[0].InnerText).ToString("yyyy-MM-dd");
                this.AuthoDay = Convert.ToInt32(Root.GetElementsByTagName("AuthoDay")[0].InnerText);
                this.UpdateServer = Root.GetElementsByTagName("UpdateServer")[0].InnerText;
                this.Message = Root.GetElementsByTagName("Message")[0].InnerText;
                this.isRead = true;
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
                        string StrTempValid = Result[6];
                        if (StrTempValid == "1" || StrTempValid.ToUpper() == "TRUE")
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
            catch
            {
                isRead = false;
                isValid = false;
                return false;
            }
        }


        private string GetCPUID()
        {
            //GetCPUID
            string CPUID = "";
            
            System.Management.ManagementClass mc = new System.Management.ManagementClass("Win32_BaseBoard");
            System.Management.ManagementObjectCollection moc = mc.GetInstances();
            foreach (System.Management.ManagementObject mo in moc)
            {
                CPUID = mo.Properties["SerialNumber"].Value.ToString();
                CPUID = CPUID.Replace('/','-');
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
                //AuthoMessage(this.Message);
            }
            if (isLocalAuthorised())
            {
                //AuthoPass();
                return true;
            }
            else
            {
                //AuthoFailed();
                return false;
            }
        }


        public string isNetworkAuthorized()
        {
            string Result = "";
            string ServerBase = "";
            string ServerRequest = "";
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
            ServerRequest = ServerRequest + "&" + "Encrypt=Y";

            XmlDocument Root = new XmlDocument();
            try
            {
                this.isRead = false;
                try
                {
                    string HttpResult = HttpGet(ServerBase, ServerRequest).Trim();
                    Root.LoadXml(SrvDESDeCode(HttpResult));
                }
                catch
                {
                    string HttpResult = HttpGet(DefaultServer, ServerRequest);
                    Root.LoadXml(SrvDESDeCode(HttpResult));
                }

                //Get parameter

                this.LastUpdateDate = Convert.ToDateTime(Root.GetElementsByTagName("CurrentDate")[0].InnerText).ToString("yyyy-MM-dd");
                this.ExpireDate = Convert.ToDateTime(Root.GetElementsByTagName("ExpireDate")[0].InnerText).ToString("yyyy-MM-dd");
                this.AuthoDay = Convert.ToInt32(Root.GetElementsByTagName("AuthoDay")[0].InnerText);
                this.UpdateServer = Root.GetElementsByTagName("UpdateServer")[0].InnerText;
                this.Message = Root.GetElementsByTagName("Message")[0].InnerText;
                this.isRead = true;
                int TempValid = Convert.ToInt32(Root.GetElementsByTagName("isValid")[0].InnerText);
                if (TempValid == 1)
                    this.isValid = true;
                else this.isValid = false;
                Result = Result + TempValid.ToString() + "|" + this.Message;
            }
            catch
            {
                return "0|null";
            }
            return Result;
        }

        public string GetMessage()
        {
            return Message;
        }

    }
}
