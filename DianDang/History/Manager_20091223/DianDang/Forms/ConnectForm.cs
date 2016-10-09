using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DianDang
{
    public partial class ConnectForm : Form
    {
        public ConnectForm()
        {
            InitializeComponent();
        }

        private string strDBAddress;

        public bool ConnectTest()������������������������//�������ݿ������
        {
            CConn conn = new CConn();
            conn.DBAddress = strDBAddress;
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
                MessageBox.Show("���ӳɹ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                sqlcon.Close();
                return true;
            }
            catch
            {
                MessageBox.Show("����ʧ�ܣ�\n����������Ƿ��������û��������Ƿ���ȷ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void comboDBAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboDBAddress.SelectedIndex != 0)
            {
                strDBAddress = "114.80.193.23";
                tbxDBName.Text = "DianDang";
                tbxSqlUserName.Text = "DianDang";
                tbxSqlPwd.Text = "dd123456";
            }
            else
            {
                strDBAddress = "(local)";
                tbxDBName.Text = "DianDang";
                tbxSqlUserName.Text = "sa";
                tbxSqlPwd.Text = "gu123456"; 
            }
        }
    }
}