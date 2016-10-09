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
    public partial class ManageNewsForm : DockContent
    {
        public ManageNewsForm()
        {
            InitializeComponent();
        }

        private void InitComboClass()
        {
            Query query = new Query(DDNewsClass.Schema);
            DataTable dt = query.ExecuteDataSet().Tables[0];
            this.cbxClass.DisplayMember = "ClassName";
            this.cbxClass.ValueMember = "ClassID";
            this.cbxClass.DataSource = dt;            
        }

        private void ManageNewsForm_Load(object sender, EventArgs e)
        {
            InitComboClass();
        }

        private DialogResult CheckAllDate()
        {
            if (this.tbxTitle.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, "标题不能为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return DialogResult.No;
            }
            if (this.rtbContent.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, "内容不能为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            try
            {
                DDNews news = new DDNews();
                news.Title = this.tbxTitle.Text;
                news.ClassID = Convert.ToInt32(this.cbxClass.SelectedValue);
                news.Content = this.rtbContent.Text;
                //news.OperaterName = MainForm.AccountName;
                news.Save();
                MessageBox.Show(this, "添加成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show(this, "添加失败！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}