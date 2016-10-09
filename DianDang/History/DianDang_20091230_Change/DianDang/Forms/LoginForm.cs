using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using SubSonic;

namespace DianDang
{
    public partial class LoginForm : DockContent
    {
        public LoginForm()
        {
            InitializeComponent();
            //this.btnConfig.Visible = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (this.tbxUserName.Text.Trim().Length==0)
            {
                MessageBox.Show(this, "�������û�����", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.tbxUserName.Focus();
                return;
            }
            if (this.tbxPwd.Text.Trim().Length==0)
            {
                MessageBox.Show(this, "���������룡", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.tbxPwd.Focus();
                return;
            }

            Query query = new Query(DDUser.Schema);
            query.AddWhere("AccountName", tbxUserName.Text);
            DataTable dt = query.ExecuteDataSet().Tables[0];
            if (dt.Rows.Count > 0)
            {
                if(dt.Rows[0]["UserPassword"].ToString()!=tbxPwd.Text)
                {
                    MessageBox.Show(this, "����������������룡", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.tbxPwd.Focus();
                    return;
                }
                else
                {
                    MainForm.AccountName = tbxUserName.Text;
                    this.DialogResult = DialogResult.OK;
                    return;
                }
            }
            else
            {
                MessageBox.Show(this, "���û������ڣ����������룡", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.tbxUserName.Focus();
                return;
            }        
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            ConnectForm frmConn = new ConnectForm();
            frmConn.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbxPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnLogin_Click(this, null);
            }
        }
    }
}