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
        public ViewOperations(int iTicketID)
        {
            InitializeComponent();
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

        private void InitGridTable(int iTicketID)
        {
            m_GridTable.Columns.Add("TicketNumber", typeof(System.String));
            m_GridTable.Columns.Add("PawnageClass", typeof(System.String));
            m_GridTable.Columns.Add("OperationDate", typeof(System.String));
            m_GridTable.Columns.Add("OperationType", typeof(System.String));
            m_GridTable.Columns.Add("Operater", typeof(System.String));
            m_GridTable.Columns.Add("OperationNumber", typeof(System.Int32));
            m_GridTable.Columns.Add("StartDate", typeof(System.String));
            m_GridTable.Columns.Add("EndDate", typeof(System.String));
            

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
                        DDTicketStatus newStatus = new DDTicketStatus("StatusID", dt.Rows[i]["OperationType"]);
                        drow["OperationType"] = newStatus.Description;
                        drow["Operater"] = dt.Rows[i]["OperaterName"];
                        drow["OperationNumber"] = dt.Rows[i]["OperationNumber"];
                        drow["StartDate"] = dt.Rows[i]["StartDate"];
                        drow["EndDate"] = dt.Rows[i]["EndDate"];
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
    }
}