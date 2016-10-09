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
    public partial class ViewOperations : DockContent
    {
        int m_TicketID = 0;

        public ViewOperations(int iTicketID)
        {
            InitializeComponent();
            m_TicketID = iTicketID;
            InitOperationType();
            InitGridTable(iTicketID);
        }

        private DataTable m_GridTable = new DataTable();

        private List<string> SearchStatus = new List<string>();

        private bool isInSearchStatusList(string iOperationNumber)
        {
            for (int i = 0; i < SearchStatus.Count; i++)
            {
                if (SearchStatus[i] == iOperationNumber)
                    return true;
            }
            return false;
        }

        private void InitOperationType()
        {
            Query queryTicketStatus = new Query(DDTicketStatus.Schema);
            DataTable dtTicketStatus = queryTicketStatus.ExecuteDataSet().Tables[0];
            this.OperationType.ValueMember = "StatusID";
            this.OperationType.DisplayMember = "Description";
            this.OperationType.DataSource = dtTicketStatus;
        }

        private void InitGridTable(int iTicketID)
        {
            m_GridTable.Columns.Add("TicketNumber", typeof(System.String));
            m_GridTable.Columns.Add("PawnageClass", typeof(System.String));
            m_GridTable.Columns.Add("OperationDate", typeof(System.String));
            m_GridTable.Columns.Add("OperationType", typeof(System.Int32));
            m_GridTable.Columns.Add("Operater", typeof(System.String));
            m_GridTable.Columns.Add("OperationNumber", typeof(String));
            m_GridTable.Columns.Add("StartDate", typeof(System.String));
            m_GridTable.Columns.Add("EndDate", typeof(System.String));
            m_GridTable.Columns.Add("ServiceFee", typeof(System.String));
            m_GridTable.Columns.Add("InterestFee", typeof(System.String));
            m_GridTable.Columns.Add("ReturnServiceFee", typeof(System.String));
            m_GridTable.Columns.Add("OverdueServiceFee", typeof(System.String));
            

            DDPawnTicket newTicket = new DDPawnTicket("TicketID",iTicketID);

            Query query = new Query(DDOperation.Schema);
            query.AddWhere("TicketID",iTicketID);
            query.AddWhere("OperationType",Comparison.NotEquals,6);
            DataTable dt = query.ExecuteDataSet().Tables[0];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string Item = dt.Rows[i]["OperationNumber"].ToString();
                    if (!isInSearchStatusList(Item))
                    {
                        DataRow drow = m_GridTable.NewRow();
                        drow["TicketNumber"] = newTicket.TicketNumber;
                        DDPawnageInfo newInfo = new DDPawnageInfo("PawnageID", Convert.ToInt32(dt.Rows[i]["PawnageID"]));
                        DDPawnageClass newClass = new DDPawnageClass("ClassID", newInfo.ClassID);
                        drow["PawnageClass"] = newClass.ClassName;
                        drow["OperationDate"] = dt.Rows[i]["OperationDate"];
                        drow["OperationType"] = dt.Rows[i]["OperationType"];
                        drow["Operater"] = dt.Rows[i]["OperaterName"];
                        drow["OperationNumber"] = dt.Rows[i]["OperationNumber"];
                        drow["StartDate"] = dt.Rows[i]["StartDate"];
                        drow["EndDate"] = dt.Rows[i]["EndDate"];
                        drow["ServiceFee"] = dt.Rows[i]["ServiceFee"];
                        drow["InterestFee"] = dt.Rows[i]["InterestFee"];
                        drow["ReturnServiceFee"] = dt.Rows[i]["ReturnFee"];
                        drow["OverdueServiceFee"] = dt.Rows[i]["OverdueFee"];
                        m_GridTable.Rows.Add(drow);
                        SearchStatus.Add(Item);
                    }

                }
            }
            this.dataGridView1.DataSource = m_GridTable;
        }



        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow CurrentRow = this.dataGridView1.Rows[e.RowIndex];
            CurrentRow.HeaderCell.Value = Convert.ToString(e.RowIndex + 1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                int intStatusID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["OperationType"].Value);
                switch (intStatusID)
                {
                    case 1:
                        this.btnPrint.Enabled = true;
                        this.btnPrintTicket.Enabled = true;
                        break;
                    case 2:
                        this.btnPrint.Enabled = true;
                        this.btnPrintTicket.Enabled = false;
                        break;
                    case 3:
                        this.btnPrint.Enabled = true;
                        this.btnPrintTicket.Enabled = true;
                        break;
                    default:
                        this.btnPrint.Enabled = false;
                        this.btnPrintTicket.Enabled = false;
                        break;
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string strOperationNumber = dataGridView1.CurrentRow.Cells["OperationNumber"].Value.ToString();
            ReceiptPrintViewForm frmReceiptPrintView = new ReceiptPrintViewForm(m_TicketID, strOperationNumber);
        }

        private void btnPrintTicket_Click(object sender, EventArgs e)
        {
            string strOperationNumber = dataGridView1.CurrentRow.Cells["OperationNumber"].Value.ToString();
            int intStatusID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["OperationType"].Value);
            switch (intStatusID)
            {
                case 1:
                    PawnTicketPrintPreviewForm frmTicketPrint = new PawnTicketPrintPreviewForm(m_TicketID, strOperationNumber);
                    break;
                case 3:
                    RenewPawnPrintPreviewForm frmRenewPrint = new RenewPawnPrintPreviewForm(m_TicketID, strOperationNumber);
                    break;
                default:
                    break;
            }
        }


    }
}