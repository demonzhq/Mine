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
    public partial class SearchCustomerForm : DockContent
    {

        public SearchCustomerForm()
        {
            InitializeComponent();
            InitGridDataset();
            this.monthCalendar1.Visible = false;
            this.ShowDetail.Text = "查看历史";
            #region Check Permission
            DDUser user = new DDUser("AccountName", MainForm.AccountName);
            DDModule module = new DDModule("ModuleName", "修改客户信息");
            Query query = new Query(DDPermission.Schema);
            query.AddWhere("RoleID", user.RoleID);
            query.AddWhere("ModuleID", module.ModuleID);
            DataTable dt = query.ExecuteDataSet().Tables[0];
            if (dt.Rows.Count > 0)
            {
                this.btnDelete.Visible = true;
                this.btnUpdate.Visible = true;
                this.DataSelect.Visible = true;
            }
            else
            {
                this.btnDelete.Visible = false;
                this.btnUpdate.Visible = false;
                this.DataSelect.Visible = false;
            }   
            #endregion

            InitCustomerSearchOption();
        }

        int DateSelector = 1;
        private DataTable gridDataset = new DataTable();
        private DataSet comboCertTypeDataset;

        private void InitGridDataset()
        {
            gridDataset.Columns.Add("DataSelect", typeof(bool));
            gridDataset.Columns.Add("CustomerID", typeof(string));
            gridDataset.Columns.Add("CustomerName", typeof(string));
            gridDataset.Columns.Add("PhoneNumber", typeof(string));
            gridDataset.Columns.Add("CertTypeID", typeof(int));
            gridDataset.Columns.Add("CertNumber", typeof(string));
            //gridDataset.Columns.Add("TotalAmount", typeof(string));
            //gridDataset.Columns.Add("ClosePercent", typeof(string));
            gridDataset.Columns.Add("CreatDate", typeof(string));
            gridDataset.Columns.Add("Address", typeof(string));
            gridDataset.Columns.Add("ContactPerson", typeof(string));
        }

        private void InitCustomerSearchOption()
        {
            DataSet comboOptionDataset;
            Query query = new Query(DDSearchOption.Schema);
            query.AddWhere("SearchTypeID", 1);
            comboOptionDataset = query.ExecuteDataSet();            
            cbxSearchOption.DisplayMember = "OptionName";
            cbxSearchOption.ValueMember = "FieldName";
            cbxSearchOption.DataSource = comboOptionDataset.Tables[0];
        }

        private void InitComboboxCertTypeSource()
        {
            Query query = new Query(DDCertType.Schema);
            comboCertTypeDataset = query.ExecuteDataSet();
        }


        private void InitGridSource()
        {
            this.gridDataset.Clear();
            Query query = new Query(DDCustomerInfo.Schema);

            #region Date
            if (tbxStartDate.Text != "" && tbxEndDate.Text != "")
            {
                try
                {
                    DateTime iStartDate = DateTime.Parse(this.tbxStartDate.Text);
                    DateTime iEndDate = DateTime.Parse(this.tbxEndDate.Text);
                    query.AddBetweenAnd("CreatDate", iStartDate, iEndDate);
                }
                catch
                {
                }
            }
            #endregion

            string strOption = this.cbxSearchOption.SelectedValue.ToString();
            string strKey = "%" + this.tbxKeyWord.Text + "%";
            query.AddWhere(strOption, Comparison.Like, strKey);
            DataTable dtCustomer = query.ExecuteDataSet().Tables[0];
            for (int i = 0; i < dtCustomer.Rows.Count; i++)
            {
                DataRow dRow = gridDataset.NewRow();
                dRow["DataSelect"] = false;
                dRow["CustomerID"] = dtCustomer.Rows[i]["CustomerID"];
                dRow["CustomerName"] = dtCustomer.Rows[i]["CustomerName"];
                dRow["PhoneNumber"] = dtCustomer.Rows[i]["PhoneNumber"];
                dRow["CertTypeID"] = dtCustomer.Rows[i]["CertTypeID"];
                dRow["CertNumber"] = dtCustomer.Rows[i]["CertNumber"];
                dRow["CreatDate"] = dtCustomer.Rows[i]["CreatDate"];
                dRow["Address"] = dtCustomer.Rows[i]["Address"];
                dRow["ContactPerson"] = dtCustomer.Rows[i]["ContactPerson"];

                gridDataset.Rows.Add(dRow);
            }
            dataGridView1.DataSource = gridDataset;
            this.lblSummery.Text = "总计客户" + gridDataset.Rows.Count + "人";
        }

        private ClsDataGridViewPage dgvPage;

        private void SetForGridViewPage()
        {
            //DataGridView分页
            dgvPage = new ClsDataGridViewPage();
            dgvPage.GetDataGridView = this.dataGridView1;    //需要分页的是 dataGridView1
            dgvPage.RowsPerPage = 15; //每页显示多少条记录              
            dgvPage.SetDataView = gridDataset.DefaultView;
            dgvPage.Paging();    //调用分页类的Paging 方法开始分页

            if (dgvPage.TotalPage > 0)
            {
                this.btnDelete.Enabled = true;
                this.btnUpdate.Enabled = true;

                this.btnFirst.Enabled = true;
                this.btnLast.Enabled = true;
                this.btnPre.Enabled = true;
                this.btnNext.Enabled = true;
                this.tbxCurrPage.Enabled = true;
                this.tbxCurrPage.Text = (dgvPage.curPage + 1).ToString();
                this.lblTotalPage.Text = dgvPage.TotalPage.ToString();
            }
            else
            {
                this.btnDelete.Enabled = false;
                this.btnUpdate.Enabled = false;

                this.btnFirst.Enabled = false;
                this.btnLast.Enabled = false;
                this.btnPre.Enabled = false;
                this.btnNext.Enabled = false;
                this.tbxCurrPage.Text = "0";
                this.tbxCurrPage.Enabled = false;
                this.lblTotalPage.Text = "0";
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            InitComboboxCertTypeSource();
            


            this.CertTypeID.DataSource = comboCertTypeDataset.Tables[0];
            this.CertTypeID.DisplayMember = "TypeName";
            this.CertTypeID.ValueMember = "TypeID";

            dataGridView1.AutoGenerateColumns = false;
            InitGridSource();
            SetForGridViewPage();    //调用分页设置函数
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow CurrentRow = this.dataGridView1.Rows[e.RowIndex];
            CurrentRow.HeaderCell.Value = Convert.ToString(e.RowIndex + 1);
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            dgvPage.GoFirstPage();
            this.tbxCurrPage.Text = (dgvPage.curPage + 1).ToString();
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            dgvPage.GoPrevPage();
            this.tbxCurrPage.Text = (dgvPage.curPage + 1).ToString();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            dgvPage.GoNextPage();
            this.tbxCurrPage.Text = (dgvPage.curPage + 1).ToString();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            dgvPage.GoLastPage();
            this.tbxCurrPage.Text = (dgvPage.curPage + 1).ToString();
        }

        //删除所选行数据
        private void btnDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (this.dataGridView1.Rows[i].Cells["DataSelect"].Value != null && this.dataGridView1.Rows[i].Cells["DataSelect"].Value.ToString() == "1")
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
                    int intCustomerID = Convert.ToInt32(dataGridView1.SelectedRows[i].Cells["CustomerID"].Value);
                    Query query = new Query(DDCustomerInfo.Schema);
                    query.QueryType = QueryType.Delete;
                    query.AddWhere("CustomerID", intCustomerID);
                    query.Execute();

                    DataRowView drv = dataGridView1.SelectedRows[i].DataBoundItem as DataRowView;
                    drv.Delete();
                }
                MessageBox.Show("数据删除成功！");
            }
            else
            {
                MessageBox.Show("请选择需要删除的数据！");
            }

        }

        //更新所选行数据
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (this.dataGridView1.Rows[i].Cells["DataSelect"].Value != null && this.dataGridView1.Rows[i].Cells["DataSelect"].Value.ToString() == "1")
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
                    int intCustomerID = Convert.ToInt32(dataGridView1.SelectedRows[i].Cells["CustomerID"].Value);
                    DDCustomerInfo newCustomer = new DDCustomerInfo("CustomerID", intCustomerID);
                    newCustomer.CustomerName = dataGridView1.SelectedRows[i].Cells["CustomerName"].Value.ToString();
                    newCustomer.PhoneNumber = dataGridView1.SelectedRows[i].Cells["PhoneNumber"].Value.ToString();
                    newCustomer.Address = dataGridView1.SelectedRows[i].Cells["Address"].Value.ToString();
                    newCustomer.ContactPerson = dataGridView1.SelectedRows[i].Cells["ContactPerson"].Value.ToString();
                    newCustomer.CertTypeID = Convert.ToInt32(dataGridView1.SelectedRows[i].Cells["CertTypeID"].Value);
                    newCustomer.CertNumber = dataGridView1.SelectedRows[i].Cells["CertNumber"].Value.ToString(); ;
                    newCustomer.Save();
                }
                MessageBox.Show("数据更新成功！");
            }
            else
            {
                MessageBox.Show("请选择需要更新的数据！");
            }
        }

        private void tbxStartDate_TextChanged(object sender, EventArgs e)
        {
            this.monthCalendar1.Visible = false;
        }

        private void tbxEndDate_TextChanged(object sender, EventArgs e)
        {
            this.monthCalendar1.Visible = false;
        }

        void tbxEndDate_Click(object sender, System.EventArgs e)
        {
            DateSelector = 2;
            this.monthCalendar1.Visible = true;
        }

        void tbxStartDate_Click(object sender, System.EventArgs e)
        {
            DateSelector = 1;
            this.monthCalendar1.Visible = true;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            string iDate = "";
            iDate = DianDangFunction.ChangeDateFormat(e.Start.ToShortDateString());
            switch (DateSelector)
            {
                case 1:
                    this.tbxStartDate.Text = iDate;
                    break;
                case 2:
                    this.tbxEndDate.Text = iDate;
                    break;
                default:
                    break;
            }
            this.monthCalendar1.Visible = false;

        }


        void dataGridView1_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["ShowDetail"].Index && e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                CustomerHistoryForm frmCustomerHistory = new CustomerHistoryForm(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["CustomerID"].Value.ToString()));

                frmCustomerHistory.Show((DockPanel)MainForm.pCurrentWin.Controls["dockPanel1"]);
            }
        }

    }
}