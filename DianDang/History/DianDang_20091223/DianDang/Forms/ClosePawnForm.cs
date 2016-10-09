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
    public partial class ClosePawnForm : DockContent
    {
        public ClosePawnForm()
        {
            InitializeComponent();
            InitTicketSearchRange(); 
            InitGridTableColumn();
        }

        private string CaculateString(string strCode)
        {
            string strChar = string.Empty;
            string strRight, strMiddle, strLeft;
            strRight = string.Empty;
            strMiddle = string.Empty;
            strLeft = string.Empty;

            int j = 0;

            strChar = string.IsNullOrEmpty(strCode) ? "001" : strCode;

            if (strCode.Substring(strChar.Length - 1).Equals("9"))
            {
                for (int i = 0; i < strCode.Length; i++)
                {
                    if (strCode.Substring((strCode.Length - i - 1), 1).Equals("9"))
                        j++;
                    else
                        break;

                }
                strRight = strRight.PadRight(j, '0');   //�ж��ٸ�9�����ٸ���
                strMiddle = Convert.ToString(int.Parse(strCode.Substring(strCode.Length - j - 1, 1)) + 1);   //��1���ֵ
                strLeft = strCode.Substring(0, strCode.Length - j - 1); //
                strChar = strLeft + strMiddle + strRight;

            }
            else
            {
                strRight = Convert.ToString(int.Parse(strCode.Substring(strCode.Length - 1)) + 1);
                strLeft = strCode.Substring(0, strCode.Length - 1);
                strChar = strLeft + strRight;
            }
            return strChar;
        }

        private string m_OperationNumber;
        private void LoadOperationNumber()
        {
            DDGeneralParemeter newParam = new DDGeneralParemeter("ParamName", "OperationNumber");
            m_OperationNumber = newParam.ParamValue.Trim();
        }
        private void UpdateOperationNumber()
        {
            DDGeneralParemeter newParam = new DDGeneralParemeter("ParamName", "OperationNumber");
            newParam.ParamValue = CaculateString(newParam.ParamValue.Trim());
            newParam.Save();
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
            m_GridTable.Columns.Add("OperationDate", typeof(System.String));
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
                DateTime operateDate = DateTime.Now;
                string strDate = operateDate.Year.ToString() + "-" + operateDate.Month.ToString() + "-" + operateDate.Day.ToString();

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
                    drow["OperationDate"] = strDate;
                    m_GridTable.Rows.Add(drow);
                }
            }
        }

        private ClsDataGridViewPage dgvPage;

        private void SetForGridViewPage()
        {
            //DataGridView��ҳ
            dgvPage = new ClsDataGridViewPage();
            dgvPage.GetDataGridView = this.dataGridView1;    //��Ҫ��ҳ���� dataGridView1
            dgvPage.RowsPerPage = 15; //ÿҳ��ʾ��������¼              
            dgvPage.SetDataView = m_GridTable.DefaultView;
            dgvPage.Paging();    //���÷�ҳ���Paging ������ʼ��ҳ

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
            SetForGridViewPage();    //���÷�ҳ���ú���
        }

        private void UpdateOperation()
        {
            DataGridViewRow dgr = dataGridView1.CurrentRow;
            int intStatusID = Convert.ToInt32(dgr.Cells["StatusID"].Value);

            if (intStatusID == 1||intStatusID==3)
            {
                int iTicketID = Convert.ToInt32(dgr.Cells["TicketID"].Value);
                DDPawnTicket newTicket = new DDPawnTicket("TicketID", iTicketID);

                Query queryOperations = new Query(DDOperation.Schema);
                queryOperations.AddWhere("TicketID", iTicketID);
                queryOperations.AddWhere("NextOperationID", 0);
                queryOperations.AddWhere("OperationType",Comparison.NotEquals,6);
                DataTable dtOperations = queryOperations.ExecuteDataSet().Tables[0];
                if (dtOperations.Rows.Count > 0)
                {
                    newTicket.StatusID = 4;
                    newTicket.Save();
                    int preOperationID = 0;

                    for (int i = 0; i < dtOperations.Rows.Count; i++)
                    {
                        DDOperation newOperation = new DDOperation();
                        preOperationID = Convert.ToInt32(dtOperations.Rows[i]["OperationID"]);
                        newOperation.TicketID = iTicketID;
                        newOperation.PawnageID = Convert.ToInt32(dtOperations.Rows[i]["PawnageID"]);
                        newOperation.OperationType = 4;   //4 ������
                        newOperation.OperationNumber = m_OperationNumber;
                        newOperation.ServiceFee = "0";
                        newOperation.InterestFee = "0";
                        newOperation.ReturnFee = "0";
                        newOperation.OverdueFee = "0";
                        newOperation.Amount = dtOperations.Rows[i]["Amount"].ToString();
                        newOperation.ReckonAmount = "0";
                        newOperation.OperationDate = dgr.Cells["OperationDate"].Value.ToString();
                        newOperation.OperaterName = MainForm.AccountName;
                        newOperation.PreOperationID = preOperationID;
                        newOperation.NextOperationID = 0;
                        newOperation.Save();

                        DDOperation oldOperation = new DDOperation("OperationID", preOperationID);
                        oldOperation.NextOperationID = newOperation.OperationID;
                        oldOperation.Save();
                    }

                    InitGridSource();
                    dataGridView1.DataSource = m_GridTable;
                    MessageBox.Show("��������ɹ���", "����");
                }

            }
            else
            {
                MessageBox.Show("�õ�Ʊ���ܽ��о���������", "����");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {
                DataGridView dgv = (DataGridView)sender;
                if (dgv.Columns[e.ColumnIndex].Name == "BtnClose")
                {
                    DataGridViewRow dgr = dataGridView1.CurrentRow;

                    int intStatusID = Convert.ToInt32(dgr.Cells["StatusID"].Value);

                    if (intStatusID == 1 || intStatusID == 3)
                    {
                        int intTicketID = Convert.ToInt32(dgr.Cells["TicketID"].Value);
                        DDPawnTicket oldTicket = new DDPawnTicket("TicketID", intTicketID);

                        DialogResult dialogResult = MessageBox.Show("ȷ�����о�������", "����", MessageBoxButtons.OKCancel);
                        if (dialogResult == DialogResult.OK)
                        {
                            LoadOperationNumber();
                            UpdateOperation();
                            UpdateOperationNumber();
                        }
                    }
                    else
                    {
                        MessageBox.Show("�õ�Ʊ���ܽ��о�������", "����");
                    }

                }
            }

        }

    }
}