using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using SkinSharp;

namespace DianDang
{
    public partial class ConnectForm : Form
    {
        public SkinH_Net skinh;

        public ConnectForm()
        {
            InitializeComponent();

            skinh = new SkinH_Net();
            skinh.Attach();
        }

        public bool ConnectTest()　　　　　　　　　　　　//连接数据库服务器
        {
            CConn conn = new CConn();
            conn.DBAddress = tbxServerName.Text.Trim();
            conn.DBName = tbxDBName.Text.Trim();
            conn.SqlUser = tbxSqlUserName.Text.Trim();
            conn.SqlPwd = tbxSqlPwd.Text.Trim();

            string connectString;
            SqlConnection sqlcon;
            connectString = "packet size=4096;user id=" + conn.SqlUser + ";data source=" + conn.DBAddress + ";persist security info=True;initial catalog=" + conn.DBName + ";password=" + conn.SqlPwd;
            sqlcon = new SqlConnection(connectString);
           
            try
            {
                sqlcon.Open();
                MessageBox.Show("连接成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                sqlcon.Close();
                return true;
            }
            catch
            {
                MessageBox.Show("连接失败！\n请检查服务器是否开启或者用户及密码是否正确！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ConnectTest();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}