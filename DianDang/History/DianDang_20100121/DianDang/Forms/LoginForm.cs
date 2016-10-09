using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using SubSonic;
using SkinSharp;

namespace DianDang
{
    public partial class LoginForm : DockContent
    {
        public SkinH_Net skinh;

        public LoginForm()
        {
            InitializeComponent();

            skinh = new SkinH_Net();
            skinh.Attach();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (this.tbxUserName.Text.Trim().Length==0)
            {
                MessageBox.Show(this, "请输入用户名！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.tbxUserName.Focus();
                return;
            }
            if (this.tbxPwd.Text.Trim().Length==0)
            {
                MessageBox.Show(this, "请输入密码！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.tbxPwd.Focus();
                return;
            }

            Query query = new Query(DDUser.Schema);
            query.AddWhere("AccountName", tbxUserName.Text);
            try
            {
                DataTable dt = query.ExecuteDataSet().Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["UserPassword"].ToString() != tbxPwd.Text)
                    {
                        MessageBox.Show(this, "密码错误，请重新输入！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show(this, "该用户不存在，请重新输入！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.tbxUserName.Focus();
                    return;
                }
            }
            catch
            {
                MessageBox.Show("数据库连接失败，请与系统管理员联系！", "提示信息");
            }
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            Query query = new Query(DDUser.Schema);
            try
            {
                query.Execute();
                MessageBox.Show("数据库连接成功！", "提示信息");
            }
            catch
            {
                MessageBox.Show("数据库连接失败，请与系统管理员联系！","提示信息");
            }
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