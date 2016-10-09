using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Configuration;
using System.Xml;
using System.Xml.Serialization;
using SubSonic;
using SubSonic.Utilities;

namespace DianDang
{
    public partial class DataBackupRestoreForm : Form
    {
        public DataBackupRestoreForm()
        {
            InitializeComponent();
            this.selectBackupFileDialog.InitialDirectory = Application.StartupPath + @"\Backup";
            this.openFileDialog1.InitialDirectory = Application.StartupPath + @"\Backup";
        }

        private void btnBackupFileBrowser_Click(object sender, EventArgs e)
        {
            this.selectBackupFileDialog.ShowDialog();
        }

        private void btnRestoreFileBrowser_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.ShowDialog();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                string queryString = "Backup database DD to disk='" + this.tbxBackupFile.Text + "'";
                InlineQuery query = DB.Query();
                query.Execute(queryString);
                MessageBox.Show("备份成功","提示信息");
            }
            catch
            {
                MessageBox.Show("备份失败", "提示信息");
            }
        }

        void selectBackupFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.tbxBackupFile.Text = selectBackupFileDialog.FileName;
        }


        void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.tbxRestoreFile.Text = openFileDialog1.FileName;
        }


        private void btnRestore_Click(object sender, EventArgs e)
        {
            string queryString = "use [master]\r\n select * from sysprocesses where dbid=DB_ID('dd')\r\n ";
            InlineQuery query = DB.Query();
            IDataReader SidList = query.ExecuteReader(queryString);
            while (SidList.Read())
            {
                try
                {
                    queryString = "kill " + SidList["spid"].ToString();
                    query.Execute(queryString);
                }
                catch
                {
                }
            }

            try
            {
                queryString = "use [master]\r\n  RESTORE DATABASE DD FROM disk='" + this.tbxRestoreFile.Text + "'";
                query.Execute(queryString);
                MessageBox.Show("恢复成功", "提示信息");
            }
            catch
            {
                MessageBox.Show("恢复失败", "提示信息");
            }
        }

    }
}
