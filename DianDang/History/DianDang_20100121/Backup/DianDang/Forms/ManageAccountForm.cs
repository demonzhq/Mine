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
    public partial class ManageAccountForm : DockContent
    {
        public ManageAccountForm()
        {
            InitializeComponent();
            InitUserSearchOption();
            InitComboRole();
        }

        private void InitUserSearchOption()
        {
            DataSet comboOptionDataset;
            Query query = new Query(DDSearchOption.Schema);
            query.AddWhere("SearchTypeID", 3);
            comboOptionDataset = query.ExecuteDataSet();
            cbxSearchOption.DisplayMember = "OptionName";
            cbxSearchOption.ValueMember = "FieldName";
            cbxSearchOption.DataSource = comboOptionDataset.Tables[0];
        }

        private void InitComboRole()
        {
            Query query = new Query(DDRole.Schema);
            DataTable dt = query.ExecuteDataSet().Tables[0];
            this.cbxRoleID.DisplayMember = "RoleName";
            this.cbxRoleID.ValueMember = "RoleID";
            this.cbxRoleID.DataSource = dt;

            this.RoleID.DisplayMember = "RoleName";
            this.RoleID.ValueMember = "RoleID";
            this.RoleID.DataSource = dt.Copy();
        }

        private DialogResult CheckAllDate()
        {
            if (this.tbxAccountName.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, "帐户名不能为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.tbxAccountName.Focus();
                return DialogResult.No;
            }
            if (this.tbxUserName.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, "姓名不能为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.tbxUserName.Focus();
                return DialogResult.No;
            }
            if (this.tbxPassword.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, "密码不能为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.tbxPassword.Focus();
                return DialogResult.No;
            }

            return DialogResult.OK;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckAllDate() != DialogResult.OK)
            {
                return;
            }
            else
            {
                Query query = new Query(DDUser.Schema);
                query.AddWhere("AccountName", this.tbxAccountName.Text);
                DataTable dt = query.ExecuteDataSet().Tables[0];
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show(this, "该帐户已存在，请重新输入！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.tbxAccountName.Focus();
                    return;
                }

                try
                {
                    this.dataGridView1.Rows.Add(1);
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["AccountName"].Value = this.tbxAccountName.Text;
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["UserPassword"].Value = this.tbxPassword.Text;
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["UserName"].Value = this.tbxUserName.Text;
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["PhoneNumber"].Value = this.tbxPhoneNumber.Text;
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Email"].Value = this.tbxEmail.Text;
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["CertNumber"].Value = this.tbxCertNumber.Text;
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["RoleID"].Value = this.cbxRoleID.SelectedValue;

                    DDUser newUser = new DDUser();
                    newUser.AccountName = this.tbxAccountName.Text;
                    newUser.UserPassword = this.tbxPassword.Text;
                    newUser.UserName = this.tbxUserName.Text;
                    newUser.PhoneNumber = this.tbxPhoneNumber.Text;
                    newUser.Email = this.tbxEmail.Text;
                    newUser.CertNumber = this.tbxCertNumber.Text;
                    newUser.RoleID = Convert.ToInt32(this.cbxRoleID.SelectedValue);
                    newUser.Save();
                }
                catch
                {
                    MessageBox.Show(this, "数据添加失败,请检查数据库是否连接正确？", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Query query = new Query(DDUser.Schema);
            string strOption = this.cbxSearchOption.SelectedValue.ToString();
            string strKey = "%" + this.tbxKeyWord.Text + "%";
            query.AddWhere(strOption, Comparison.Like, strKey);
            DataTable dt = query.ExecuteDataSet().Tables[0];

            this.dataGridView1.Rows.Clear();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    this.dataGridView1.Rows.Add(1);
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["UserID"].Value = dt.Rows[i]["UserID"];
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["AccountName"].Value = dt.Rows[i]["AccountName"];
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["UserPassword"].Value = dt.Rows[i]["UserPassword"];
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["UserName"].Value = dt.Rows[i]["UserName"];
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["PhoneNumber"].Value = dt.Rows[i]["PhoneNumber"];
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Email"].Value = dt.Rows[i]["Email"];
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["CertNumber"].Value = dt.Rows[i]["CertNumber"];
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["RoleID"].Value = dt.Rows[i]["RoleID"];
                }
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow CurrentRow = this.dataGridView1.Rows[e.RowIndex];
            CurrentRow.HeaderCell.Value = Convert.ToString(e.RowIndex + 1);
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.dataGridView1.Rows.Count > 0)
            {
                DataGridViewRow dgr = dataGridView1.CurrentRow;
                this.tbxAccountName.Text = dgr.Cells["AccountName"].Value.ToString();
                this.tbxPassword.Text = dgr.Cells["UserPassword"].Value.ToString();
                this.tbxUserName.Text = dgr.Cells["UserName"].Value.ToString();
                this.tbxPhoneNumber.Text = dgr.Cells["PhoneNumber"].Value.ToString();
                this.tbxEmail.Text = dgr.Cells["Email"].Value.ToString();
                this.tbxCertNumber.Text = dgr.Cells["CertNumber"].Value.ToString();
                this.cbxRoleID.SelectedValue = dgr.Cells["RoleID"].Value;  
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (CheckAllDate() != DialogResult.OK)
            {
                return;
            }
            else
            {
                try
                {
                    DataGridViewRow dgr = dataGridView1.CurrentRow;
                    dgr.Cells["AccountName"].Value = this.tbxAccountName.Text;
                    dgr.Cells["UserPassword"].Value = this.tbxPassword.Text;
                    dgr.Cells["UserName"].Value = this.tbxUserName.Text;
                    dgr.Cells["PhoneNumber"].Value = this.tbxPhoneNumber.Text;
                    dgr.Cells["Email"].Value = this.tbxEmail.Text;
                    dgr.Cells["CertNumber"].Value = this.tbxCertNumber.Text;
                    dgr.Cells["RoleID"].Value = this.cbxRoleID.SelectedValue;

                    DDUser newUser = new DDUser("UserID", Convert.ToInt32(dgr.Cells["UserID"].Value));
                    newUser.AccountName = this.tbxAccountName.Text;
                    newUser.UserPassword = this.tbxPassword.Text;
                    newUser.UserName = this.tbxUserName.Text;
                    newUser.PhoneNumber = this.tbxPhoneNumber.Text;
                    newUser.Email = this.tbxEmail.Text;
                    newUser.CertNumber = this.tbxCertNumber.Text;
                    newUser.RoleID = Convert.ToInt32(this.cbxRoleID.SelectedValue);
                    newUser.Save();

                    MessageBox.Show("数据修改成功！", "修改数据");
                }
                catch
                {
                    MessageBox.Show(this, "数据修改失败,请检查数据库是否连接正确！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (this.dataGridView1.Rows[i].Cells["Operation"].Value != null && this.dataGridView1.Rows[i].Cells["Operation"].Value.ToString() == "1")
                {
                    dataGridView1.Rows[i].Selected = true;
                }
                else
                {
                    dataGridView1.Rows[i].Selected = false;
                }
            }
            if (dataGridView1.SelectedRows.Count > 0)
            {
                for (int i = dataGridView1.SelectedRows.Count - 1; i > -1; i--)
                {
                    int rowIndex = dataGridView1.SelectedRows[i].Index;
                    DataGridViewRow dgr = dataGridView1.Rows[rowIndex];

                    try
                    {
                        Query query = new Query(DDUser.Schema);
                        query.AddWhere("AccountName",dgr.Cells["AccountName"].Value.ToString());
                        query.QueryType = QueryType.Delete;
                        query.Execute();
                        dataGridView1.Rows.Remove(dgr);
                    }
                    catch
                    {
                        MessageBox.Show(this, "数据删除失败,请检查数据库是否连接正确！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择需要删除的数据！");
            }
        }
    }
}