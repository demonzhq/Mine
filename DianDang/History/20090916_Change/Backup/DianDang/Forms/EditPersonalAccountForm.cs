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
    public partial class EditPersonalAccountForm : DockContent
    {
        public EditPersonalAccountForm()
        {
            InitializeComponent();
            LoadAccountInfo();
        }

        private void LoadAccountInfo()
        {
            DDUser newUser=new DDUser("AccountName",MainForm.AccountName);
            this.tbxUserName.Text = newUser.UserName;
            this.tbxPhoneNumber.Text = newUser.PhoneNumber;
            this.tbxEmail.Text = newUser.Email;
            this.tbxCertNumber.Text = newUser.CertNumber;
            this.tbxRoleName.Text = newUser.RoleID.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DDUser newUser = new DDUser("AccountName", MainForm.AccountName);
                newUser.UserName = this.tbxUserName.Text;
                newUser.PhoneNumber = this.tbxPhoneNumber.Text;
                newUser.Email = this.tbxEmail.Text;
                newUser.CertNumber = this.tbxCertNumber.Text;
                newUser.Save();
                MessageBox.Show(this, "信息修改成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show(this, "信息修改失败,请检查数据库连接是否正确！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEditPwd_Click(object sender, EventArgs e)
        {
            if (this.tbxOldPassword.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, "请输入原密码！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.tbxOldPassword.Focus();
                return;
            }
            if (this.tbxNewPassword.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, "请输入新密码！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.tbxNewPassword.Focus();
                return;
            }
            if (this.tbxRepeatedPassword.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, "请重复输入新密码！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.tbxRepeatedPassword.Focus();
                return;
            }
            if(this.tbxNewPassword.Text.Trim()!=this.tbxRepeatedPassword.Text.Trim())
            {
                MessageBox.Show(this, "两次输入的密码不一致！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.tbxRepeatedPassword.Focus();
                return;
            }
            DDUser newUser = new DDUser("AccountName", MainForm.AccountName);
            if (this.tbxOldPassword.Text.Trim() != newUser.UserPassword)
            {
                MessageBox.Show(this, "原密码输入错误！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.tbxOldPassword.Focus();
                return;
            }
            else
            {
                newUser.UserPassword = this.tbxNewPassword.Text.Trim();
                newUser.Save();
                MessageBox.Show(this, "密码修改成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}