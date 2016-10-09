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
    public partial class DeletePawnForm : DockContent
    {
        public DeletePawnForm()
        {
            InitializeComponent();
            InitTicketSearchRange();
            InitGridTableColumn();
        }

        private void InitTicketSearchRange()
        {
            DataSet comboRangeDataset;
            Query query = new Query(DDTicketStatus.Schema);
            comboRangeDataset = query.ExecuteDataSet();

            StatusID.DisplayMember = "Description";
            StatusID.ValueMember = "StatusID";
            StatusID.DataSource = comboRangeDataset.Tables[0];
        }

        private DataTable m_GridTable = new DataTable();

        private void InitGridTableColumn()
        {
            m_GridTable.Columns.Add("TicketID", typeof(System.Int32));
            m_GridTable.Columns.Add("TicketNumber", typeof(System.String));
            m_GridTable.Columns.Add("StartDate", typeof(System.String));
            m_GridTable.Columns.Add("EndDate", typeof(System.String));
            m_GridTable.Columns.Add("StatusID", typeof(System.Int32));
            m_GridTable.Columns.Add("CustomerName", typeof(System.String));
            m_GridTable.Columns.Add("OperaterName", typeof(System.String));
        }

        private void InitGridSource()
        {
            m_GridTable.Rows.Clear();
            Query query = new Query(DDPawnTicket.Schema);
            string strKey = "%" + this.tbxKeyWord.Text + "%";
            query.AddWhere("TicketNumber", Comparison.Like, strKey);
            query.AddWhere("StatusID", Comparison.NotEquals, 6);
            DataTable dt = query.ExecuteDataSet().Tables[0];
            if (dt.Rows.Count > 0)
            {                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow drow = m_GridTable.NewRow();
                    drow["TicketID"] = dt.Rows[i]["TicketID"];
                    drow["TicketNumber"] = dt.Rows[i]["TicketNumber"];
                    drow["StartDate"] = dt.Rows[i]["StartDate"];
                    drow["EndDate"] = dt.Rows[i]["EndDate"];
                    drow["StatusID"] = dt.Rows[i]["StatusID"];
                    DDCustomerInfo customerInfo = new DDCustomerInfo("CustomerID", Convert.ToInt32(dt.Rows[i]["CustomerID"]));
                    DDOperation operation = new DDOperation("TicketID", Convert.ToInt32(dt.Rows[i]["TicketID"]));
                    drow["CustomerName"] = customerInfo.CustomerName;
                    drow["OperaterName"] = operation.OperaterName;
                    m_GridTable.Rows.Add(drow);
                }
            }
        }

        private ClsDataGridViewPage dgvPage;

        private void SetForGridViewPage()
        {
            //DataGridView分页
            dgvPage = new ClsDataGridViewPage();
            dgvPage.GetDataGridView = this.dataGridView1;    //需要分页的是 dataGridView1
            dgvPage.RowsPerPage = 15; //每页显示多少条记录              
            dgvPage.SetDataView = m_GridTable.DefaultView;
            dgvPage.Paging();    //调用分页类的Paging 方法开始分页

            if (dgvPage.TotalPage > 0)
            {
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
                this.btnFirst.Enabled = false;
                this.btnLast.Enabled = false;
                this.btnPre.Enabled = false;
                this.btnNext.Enabled = false;
                this.tbxCurrPage.Text = "0";
                this.tbxCurrPage.Enabled = false;
                this.lblTotalPage.Text = "0";
            }
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            InitGridSource();

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = m_GridTable;
            SetForGridViewPage();    //调用分页设置函数
        }

        private void DeleteOperation()
        {
            DataGridViewRow dgr = dataGridView1.CurrentRow;
            int intTicketID = Convert.ToInt32(dgr.Cells["TicketID"].Value);
            DDPawnTicket newTicket = new DDPawnTicket("TicketID",intTicketID);

            Query query = new Query(DDOperation.Schema);
            query.AddWhere("TicketID",intTicketID);
            query.AddWhere("NextOperationID",0);
            DataTable dt = query.ExecuteDataSet().Tables[0];
            if (dt.Rows.Count > 0)
            {
                DateTime operateDate = DateTime.Now;
                string strDate = operateDate.Year.ToString() + "-" + operateDate.Month.ToString() + "-" + operateDate.Day.ToString();

                //DDOperation newOperation = new DDOperation();
                //newOperation.TicketID = operation.TicketID;
                //newOperation.PawnageID = operation.PawnageID;
                //newOperation.OperationType = 6;
                //newOperation.OperationNumber = operation.OperationNumber;
                //newOperation.OperationDate = strDate;
                //newOperation.OperaterName = MainForm.AccountName;
                //newOperation.PreOperationID = operation.OperationID;
                //newOperation.NextOperationID = 0;
                //newOperation.Save();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DDOperation newOperation = new DDOperation("OperationID", Convert.ToInt32(dt.Rows[i]["OperationID"]));
                    
                    if (newOperation.PreOperationID != 0)
                    {
                        DDOperation preOperation = new DDOperation("OperationID", newOperation.PreOperationID);
                        preOperation.NextOperationID =0;
                        preOperation.Save();
                        newTicket.StatusID = preOperation.OperationType;
                        if (newOperation.OperationType == 3)
                        {
                            newTicket.EndDate = preOperation.EndDate;
                        }
                    }
                    else
                    {
                        newTicket.StatusID = 6;
                    }
                    newOperation.OperationType = 6;//6:删除
                    newOperation.NextOperationID = -1;
                    newOperation.OperationDate = strDate;
                    newOperation.Save();
                }
            }
            
            newTicket.Save();

            InitGridSource();
            dataGridView1.DataSource = m_GridTable;
            MessageBox.Show("删除成功！", "删除");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {
                DataGridView dgv = (DataGridView)sender;
                if (dgv.Columns[e.ColumnIndex].Name == "BtnDelete")
                {
                    DialogResult dialogResult = MessageBox.Show("确定删除？", "删除", MessageBoxButtons.OKCancel);
                    if (dialogResult == DialogResult.OK)
                    {
                        DeleteOperation();
                    }

                }
            }
        }

    }
}