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
    public partial class TransformPawnForm : DockContent
    {
        public TransformPawnForm()
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
            query.AddWhere("StatusID", Comparison.In, new int[] { 1, 3 });
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (e.ColumnIndex > 0)
            {
                if (dgv.Columns[e.ColumnIndex].Name == "BtnTransform")
                {
                    DataGridViewRow dgr = dataGridView1.CurrentRow;
                    int iTicketID = Convert.ToInt32(dgr.Cells["TicketID"].Value);
                    TransformPawnOperationForm frmTransformPawnOperation = new TransformPawnOperationForm(iTicketID);
                    frmTransformPawnOperation.Show((DockPanel)MainForm.pCurrentWin.Controls["dockPanel1"]);
                }
            }
        }
        void tbxKeyWord_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                btnSearch_Click(sender, e);
        }

    }
}