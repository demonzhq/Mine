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
            InitUnit();
        }

        private DataTable dtTreeParentClass;

        private void InitTreeClass()
        {
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
                for (int i = 0; i < dtTreeParentClass.Rows.Count; i++)
                {
                    tempParentNode = new TreeNode(dtTreeParentClass.Rows[i]["ClassName"].ToString());                    
                    treeClass.Nodes.Add(tempParentNode);

                    intParentID = Convert.ToInt32(dtTreeParentClass.Rows[i]["ClassID"]);
                    queryClass = new Query(DDPawnageClass.Schema);   
                    queryClass.AddWhere("ParentID",intParentID);
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
            this.UnitName.DataSource = dtUnit;
            this.UnitName.DisplayMember = "UnitName";
            this.UnitName.ValueMember = "UnitID";
        }

        private void InitParentClass()
        {
            this.ParentClass.DataSource = dtTreeParentClass;
            this.ParentClass.DisplayMember = "ClassName";
            this.ParentClass.ValueMember = "ClassID"; 
        }

        private void treeClass_AfterSelect(object sender, TreeViewEventArgs e)
        {
            DataTable dt;
            Query queryClassInfo = new Query(DDPawnageClass.Schema);
            queryClassInfo.AddWhere("ClassName",treeClass.SelectedNode.Text);
            dt = queryClassInfo.ExecuteDataSet().Tables[0];
            dgvClassInfo.AutoGenerateColumns = false;
            dgvClassInfo.DataSource = dt;
        }

        private void dgvClassInfo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvClassInfo.RowCount; i++)
            {
                if (this.dgvClassInfo.Rows[i].Cells["Operation"].Value != null && this.dgvClassInfo.Rows[i].Cells["Operation"].Value.ToString() == "1")
                {
                    dgvClassInfo.Rows[i].Selected = true;
                }
                else
                {
                    dgvClassInfo.Rows[i].Selected = false;
                }
            }
            if (dgvClassInfo.SelectedRows.Count > 0)
            {
                for (int i = dgvClassInfo.SelectedRows.Count - 1; i > -1; i--)
                {
                    object objParentID;
                    try
                    {
                        DDPawnageClass newClass = new DDPawnageClass();
                        newClass.ClassName = dgvClassInfo.SelectedRows[i].Cells["ClassName"].Value.ToString();
                        objParentID = dgvClassInfo.SelectedRows[i].Cells["ParentClass"].Value;
                        if (objParentID != null)
                        {
                            newClass.ParentID = Convert.ToInt32(objParentID.ToString());
                        }
                        else
                        {
                            newClass.ParentID = 0;
                        }
                        newClass.UnitID = Convert.ToInt32(dgvClassInfo.SelectedRows[i].Cells["UnitName"].Value.ToString());
                        newClass.MonthFeeRate = dgvClassInfo.SelectedRows[i].Cells["FeeRate"].Value.ToString();
                        newClass.InterestRate = dgvClassInfo.SelectedRows[i].Cells["InterestRate"].Value.ToString();
                        newClass.Save();
                    }
                    catch
                    {
                        MessageBox.Show("请填写完整的分类信息！");
                    }
                }
                MessageBox.Show("数据添加成功！");
                InitTreeClass();
            }
            else
            {
                MessageBox.Show("请选择需要添加的数据！");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvClassInfo.RowCount; i++)
            {
                if (this.dgvClassInfo.Rows[i].Cells["Operation"].Value != null && this.dgvClassInfo.Rows[i].Cells["Operation"].Value.ToString() == "1")
                {
                    dgvClassInfo.Rows[i].Selected = true;
                }
                else
                {
                    dgvClassInfo.Rows[i].Selected = false;
                }
            }
            if (dgvClassInfo.SelectedRows.Count > 0)
            {
                for (int i = dgvClassInfo.SelectedRows.Count - 1; i > -1; i--)
                {
                    try
                    {
                        int intClassID = Convert.ToInt32(dgvClassInfo.SelectedRows[i].Cells["ClassID"].Value);
                        DDPawnageClass newClass = new DDPawnageClass("ClassID", intClassID);
                        newClass.ClassName = dgvClassInfo.SelectedRows[i].Cells["ClassName"].Value.ToString();
                        newClass.ParentID = Convert.ToInt32(dgvClassInfo.SelectedRows[i].Cells["ParentClass"].Value.ToString());
                        newClass.UnitID = Convert.ToInt32(dgvClassInfo.SelectedRows[i].Cells["UnitName"].Value.ToString());
                        newClass.MonthFeeRate = dgvClassInfo.SelectedRows[i].Cells["FeeRate"].Value.ToString();
                        newClass.InterestRate = dgvClassInfo.SelectedRows[i].Cells["InterestRate"].Value.ToString();
                        newClass.Save();
                    }
                    catch
                    {
                        MessageBox.Show("请填写完整的分类信息！");
                    }
                }
                MessageBox.Show("数据更新成功！");
                InitTreeClass();
            }
            else
            {
                MessageBox.Show("请选择需要更新的数据 ！");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvClassInfo.RowCount; i++)
            {
                if (this.dgvClassInfo.Rows[i].Cells["Operation"].Value != null && this.dgvClassInfo.Rows[i].Cells["Operation"].Value.ToString() == "1")
                {
                    dgvClassInfo.Rows[i].Selected = true;
                }
                else
                {
                    dgvClassInfo.Rows[i].Selected = false;
                }
            }
            if (dgvClassInfo.SelectedRows.Count > 0)
            {
                int intClassID;
                int intParentID;
                Query query;
                for (int i = dgvClassInfo.SelectedRows.Count - 1; i > -1; i--)
                {
                   
                    intParentID = Convert.ToInt32(dgvClassInfo.SelectedRows[i].Cells["ParentClass"].Value);
                    intClassID = Convert.ToInt32(dgvClassInfo.SelectedRows[i].Cells["ClassID"].Value);
                    if (intParentID == 0)
                    {
                        DialogResult dr= MessageBox.Show("此操作将会删除该分类下所有子分类，确定删除吗？", "删除确认", MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {
                            query = new Query(DDPawnageClass.Schema);
                            query.QueryType = QueryType.Delete;
                            query.AddWhere("ParentID", intClassID);
                            query.Execute();
                        }
                        else
                        {
                            return;
                        }
                    }                    
                    query = new Query(DDPawnageClass.Schema);
                    query.QueryType = QueryType.Delete;
                    query.AddWhere("ClassID", intClassID);
                    query.Execute();

                    DataRowView drv = dgvClassInfo.SelectedRows[i].DataBoundItem as DataRowView;
                    drv.Delete();
                }
                MessageBox.Show("数据删除成功！");
                InitTreeClass();
            }
            else
            {
                MessageBox.Show("请选择需要删除的数据！");
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            InitTreeClass();
        }

    }
}