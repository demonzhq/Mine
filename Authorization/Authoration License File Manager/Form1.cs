using Authorization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Management;
using XForm;



namespace Authoration_License_File_Manager
{
    public partial class Main : XForm.XForm
    {

        Authorization.Autho mAutho = new Autho("");
        public Main()
        {
            InitializeComponent();
            InitialzeData();
        }



        private void btn_browse_Click(object sender, EventArgs e)
        {
            ofd_Main.FileName = this.tbx_File.Text;
            if (ofd_Main.ShowDialog() == DialogResult.OK)
                this.tbx_File.Text = ofd_Main.FileName;       
        }


        private void btn_ReadInfo_Click(object sender, EventArgs e)
        {
            try
            {
                mAutho = new Autho(tbx_ProjectName.Text, tbx_File.Text, tbx_key.Text, tbx_IV.Text);
                bool ReadResult = mAutho.GetDataFromLic();
                if (!ReadResult)
                    throw (new Exception());
                else
                {
                    tbx_ProjectName.Text = mAutho.LicProjectName;
                    tbx_ID.Text = mAutho.CPUID;
                    num_AuthoDay.Value = mAutho.AuthoDay;
                    dtp_CurrentDate.Value = DateTime.Parse(mAutho.LastUpdateDate);
                    dtp_ExpireDate.Value = DateTime.Parse(mAutho.LastUpdateDate);
                    tbx_AuthoServer.Text = mAutho.UpdateServer;
                    cbx_Valid.SelectedIndex = Convert.ToInt32(mAutho.isValid);
                    tbxMessage.Text = mAutho.Message;
                    MessageBox.Show("Info Read");
                }
            }
            catch
            {
                MessageBox.Show("Wrong License File or Key");
            }
        }


        private void btn_RenewID_Click(object sender, EventArgs e)
        {
            try
            {
                this.tbx_ID.Text = GetCPUID();
            }
            catch
            {
                MessageBox.Show("Get Computer ID Failed");
            }
        }


        private static string GetCPUID()
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

        private void btn_Update_Click(object sender, EventArgs e)
        {
            sfd_Main.FileName = this.tbx_File.Text;
            if (sfd_Main.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    mAutho.ProjectName = tbx_ProjectName.Text;
                    mAutho.LicenseFile = sfd_Main.FileName;
                    mAutho.AuthoDay = (int)num_AuthoDay.Value;
                    mAutho.CPUID = this.tbx_ID.Text;
                    mAutho.LastUpdateDate = dtp_CurrentDate.Value.ToString("yyyy - MM - dd");
                    mAutho.ExpireDate = dtp_ExpireDate.Value.ToString("yyyy - MM - dd");
                    mAutho.UpdateServer = tbx_AuthoServer.Text;
                    if (cbx_Valid.SelectedIndex == 1)
                    {
                        mAutho.isValid = true;
                    }
                    else mAutho.isValid = false;
                    mAutho.Message = tbxMessage.Text;
                    mAutho.iv = tbx_IV.Text;
                    mAutho.key = tbx_key.Text;


                    bool result = mAutho.GenerateLic();
                    if (result)
                    {
                        MessageBox.Show("License Created");
                    }
                    else MessageBox.Show("License Error");
                }
                catch
                {
                    MessageBox.Show("License Error");
                }
            }
                
        }







    }
}
