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
    public partial class SetPawnageClassForm : DockContent
    {
        public SetPawnageClassForm()
        {
            InitializeComponent();
            InitTreeClass();
            InitParentClass();
            InitStatisticClass();
            InitUnit();
        }

        private void InitTreeClass()
        {
            DataTable dtTreeParentClass;
            treeClass.Nodes.Clear();
            DataTable dtTreeClass;           
            Query queryClass;
            TreeNode tempParentNode;
            int intParentID;

            Query queryParentClass = new Query(DDPawnageClass.Schema);
            queryParentClass.AddWhere("ParentID", 0);
            dtTreeParentClass = queryParentClass.ExecuteDataSet().Tables[0];
            if (dtTreeParentClass.Rows.Count > 0)
            {
                string strClassName;   
                for (int i = 0; i < dtTreeParentClass.Rows.Count; i++)
                {
                    strClassName = dtTreeParentClass.Rows[i]["ClassName"].ToString();

                    tempParentNode = new TreeNode(strClassName);
                    treeClass.Nodes.Add(tempParentNode);

                    intParentID = Convert.ToInt32(dtTreeParentClass.Rows[i]["ClassID"]);
                    queryClass = new Query(DDPawnageClass.Schema);
                    queryClass.AddWhere("ParentID", intParentID);
                    dtTreeClass = queryClass.ExecuteDataSet().Tables[0];
                    if (dtTreeClass.Rows.Count > 0)
                    {
                        TreeNode tempNode;
                        for (int j = 0; j < dtTreeClass.Rows.Count; j++)
                        {
                            tempNode = new TreeNode(dtTreeClass.Rows[j]["ClassName"].ToString());
                            tempParentNode.Nodes.Add(tempNode);
                        }
                    }
                }
            }            

        }

        private DataTable dtUnit;

        private void InitUnit()
        {
            Query queryUnit = new Query(DDMesureUnit.Schema);
            dtUnit=queryUnit.ExecuteDataSet().Tables[0];
            this.cbxUnitName.DataSource = dtUnit;
            this.cbxUnitName.DisplayMember = "UnitName";
            this.cbxUnitName.ValueMember = "UnitID";
        }

        private void InitStatisticClass()
        {
            Query query = new Query(DDStatisticClass.Schema);
            DataTable dt = query.ExecuteDataSet().Tables[0];
            this.cbxStatisticClass.DataSource = dt;
            this.cbxStatisticClass.DisplayMember = "ClassName";
            this.cbxStatisticClass.ValueMember = "ClassID";
        }

        private void InitParentClass()
        {
            Query query = new Query(DDPawnageClass.Schema);
            query.AddWhere("IsRoot",1);
            DataTable dt = query.ExecuteDataSet().Tables[0];

            this.cbxParentClass.DataSource = dt;
            this.cbxParentClass.DisplayMember = "ClassName";
            this.cbxParentClass.ValueMember = "ClassID"; 
        }

        private int ClassID;

        private void treeClass_AfterSelect(object sender, TreeViewEventArgs e)
        {
            DataTable dt;
            Query queryClassInfo = new Query(DDPawnageClass.Schema);
            queryClassInfo.AddWhere("ClassName",treeClass.SelectedNode.Text);
            dt = queryClassInfo.ExecuteDataSet().Tables[0];

            this.tbxClassName.Text = dt.Rows[0]["ClassName"].ToString();

            int intParentID = Convert.ToInt32(dt.Rows[0]["ParentID"]);
            if (intParentID == 0)
            {
                intParentID = 1;
            }
            this.cbxParentClass.SelectedValue = intParentID;
            this.cbxStatisticClass.SelectedValue = Convert.ToInt32(dt.Rows[0]["StatisticClassID"]);            
            this.cbxUnitName.SelectedValue=dt.Rows[0]["UnitID"];
            this.tbxFeeRate.Text=dt.Rows[0]["MonthFeeRate"].ToString();
            this.tbxMaxFeeRate.Text = dt.Rows[0]["MaxFeeRate"].ToString();
            this.tbxMinFeeRate.Text = dt.Rows[0]["MinFeeRate"].ToString();
            this.tbxInterestRate.Text=dt.Rows[0]["InterestRate"].ToString();
            ClassID = Convert.ToInt32(dt.Rows[0]["ClassID"]);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Query query = new Query(DDPawnageClass.Schema);
            query.AddWhere("ClassName",this.tbxClassName.Text);
            DataTable dt = query.ExecuteDataSet().Tables[0];
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show(this, "该分类已存在，请重新输入！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                DDPawnageClass newClass = new DDPawnageClass();
                newClass.ClassName = this.tbxClassName.Text;
                if (this.cbxParentClass.Text != "无上级分类")
                {
                    newClass.ParentID = Convert.ToInt32(this.cbxParentClass.SelectedValue);
                    newClass.IsRoot = 0;
                }
                else
                {
                    newClass.ParentID = 0;
                    newClass.IsRoot = 1;
                }
                newClass.StatisticClassID = Convert.ToInt32(this.cbxStatisticClass.SelectedValue);
                newClass.UnitID = Convert.ToInt32(this.cbxUnitName.SelectedValue);
                newClass.MonthFeeRate = this.tbxFeeRate.Text;
                newClass.MaxFeeRate = this.tbxMaxFeeRate.Text;
                newClass.MinFeeRate = this.tbxMinFeeRate.Text;
                newClass.InterestRate = this.tbxInterestRate.Text;
                newClass.Save();
                MessageBox.Show("数据添加成功！", "添加数据");
                InitTreeClass();
                InitParentClass();
            }
            catch
            {
                MessageBox.Show("数据添加错误！","添加数据");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DDPawnageClass newClass = new DDPawnageClass("ClassID",ClassID);
                newClass.ClassName = this.tbxClassName.Text;
                if (this.cbxParentClass.Text != "无上级分类")
                {
                    newClass.ParentID = Convert.ToInt32(this.cbxParentClass.SelectedValue);
                    newClass.IsRoot = 0;
                }
                else
                {
                    newClass.ParentID = 0;
                    newClass.IsRoot = 1;
                }
                newClass.StatisticClassID = Convert.ToInt32(this.cbxStatisticClass.SelectedValue);
                newClass.UnitID = Convert.ToInt32(this.cbxUnitName.SelectedValue);
                newClass.MonthFeeRate = this.tbxFeeRate.Text;
                newClass.MaxFeeRate = this.tbxMaxFeeRate.Text;
                newClass.MinFeeRate = this.tbxMinFeeRate.Text;
                newClass.InterestRate = this.tbxInterestRate.Text;
                newClass.Save();
                MessageBox.Show("数据修改成功！", "修改数据");
                InitTreeClass();
                InitParentClass();
            }
            catch
            {
                MessageBox.Show("数据修改错误！", "修改数据");
            }            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Query query = new Query(DDPawnageClass.Schema);
            query.AddWhere("ParentID",ClassID);
            DataTable dt=query.ExecuteDataSet().Tables[0];
            if (dt.Rows.Count > 0)
            {
                DialogResult diaRes= MessageBox.Show(this, "该分类为一级分类，确定删除吗?", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (diaRes != DialogResult.OK)
                {
                    return;
                }
                else
                {
                    Query delChildQuery = new Query(DDPawnageClass.Schema);
                    delChildQuery.QueryType = QueryType.Delete;
                    delChildQuery.WHERE("ParentID", ClassID);
                    delChildQuery.Execute();
                    
                    Query delQuery = new Query(DDPawnageClass.Schema);
                    delQuery.QueryType = QueryType.Delete;
                    delQuery.WHERE("ClassID", ClassID);
                    delQuery.Execute();
                    MessageBox.Show("数据删除成功！", "删除数据");
                    InitTreeClass();
                    if (this.treeClass.Nodes.Count > 0)
                    {
                        this.treeClass.SelectedNode = this.treeClass.Nodes[0];
                    }
                }
            }
            else
            {
                try
                {
                    Query delQuery = new Query(DDPawnageClass.Schema);
                    delQuery.QueryType = QueryType.Delete;
                    delQuery.WHERE("ClassID", ClassID);
                    delQuery.Execute();
                    MessageBox.Show("数据删除成功！", "删除数据");
                    InitTreeClass();
                    this.treeClass.SelectedNode = this.treeClass.Nodes[0];
                }
                catch
                {
                    MessageBox.Show("数据删除错误！", "删除数据");
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            InitTreeClass();
        }
    }
}