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
    public partial class CustomerHistoryForm : DockContent
    {
        int m_CustomerID = 0;

        public CustomerHistoryForm()
        {
            InitializeComponent();
            InitTicketStatus();
        }

        public CustomerHistoryForm(int iCustomerID)
        {
            InitializeComponent();
            InitTicketStatus();
            this.m_CustomerID = iCustomerID;
            InitGridSource();
            Summery();
        }

        private void InitTicketStatus()
        {
            Query query = new Query(DDTicketStatus.Schema);
            DataTable dt = query.ExecuteDataSet().Tables[0];
            this.StatusID.DataSource = dt;
            this.StatusID.DisplayMember = "Description";
            this.StatusID.ValueMember = "StatusID";
        }

        private void InitGridSource()
        {
            DDCustomerInfo customer = new DDCustomerInfo("CustomerID", m_CustomerID);
            Query query = new Query(DDPawnTicket.Schema);
            query.AddWhere("CustomerID", customer.CustomerID);
            DataTable dt = query.ExecuteDataSet().Tables[0];
            this.dataGridView1.Rows.Clear();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    this.dataGridView1.Rows.Add(1);
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["CustomerName"].Value = customer.CustomerName;
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["TicketID"].Value = dt.Rows[i]["TicketID"];
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["TicketNumber"].Value = dt.Rows[i]["TicketNumber"];
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["StartDate"].Value = dt.Rows[i]["StartDate"];
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["EndDate"].Value = dt.Rows[i]["EndDate"];
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["StatusID"].Value = dt.Rows[i]["StatusID"];
                }
            }
        }

        private void QueryByNumber()
        {
            try
            {
                DDCustomerInfo newInfo = new DDCustomerInfo("CertNumber", this.tbxCardNumber.Text.Trim());
                m_CustomerID = newInfo.CustomerID;
                InitGridSource();
            }
            catch
            {
                MessageBox.Show("不存在改客户", "提示信息");
            }

        }

        private DialogResult CheckCartNumber()
        {
            if (this.tbxCardNumber.Text.Trim().Length > 0)
            {
                return DialogResult.OK;
            }
            else
            {
                return DialogResult.No;
            }
        }

        private void btnQueryByInput_Click(object sender, EventArgs e)
        {
            if (CheckCartNumber() != DialogResult.OK)
            {
                MessageBox.Show("证件号不能为空！", "提示信息");
            }
            else
            {
                QueryByNumber();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {
                DataGridView dgv = (DataGridView)sender;
                if (dgv.Columns[e.ColumnIndex].Name == "BtnOperation")
                {
                    int intTicketID = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells["TicketID"].Value);
                    ViewPawnTicketForm frmViewPawnTicket = new ViewPawnTicketForm(intTicketID);
                    frmViewPawnTicket.Show((DockPanel)MainForm.pCurrentWin.Controls["dockPanel1"]);
                }
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow CurrentRow = this.dataGridView1.Rows[e.RowIndex];
            CurrentRow.HeaderCell.Value = Convert.ToString(e.RowIndex + 1);
        }

        private void btnQueryByCard_Click(object sender, EventArgs e)
        {
            Int32 result;
            Int32 port = 1001;    //USB接口
            UInt32 flag = 0;

            result = CardRecognise.OpenCardReader(port, flag);

            if (result != 0)
            {
                MessageBox.Show(this, "设备初始化失败，请检查设备是否已连接？", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                CardRecognise.PERSONINFOW newInfo = new CardRecognise.PERSONINFOW();
                result = CardRecognise.GetPersonMsgW(ref newInfo, "");
                if (result != 0)
                {
                    MessageBox.Show(this, "读卡错误，请重新操作！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    this.tbxCardNumber.Text = newInfo.cardId;
                    if (CheckCartNumber() != DialogResult.OK)
                    {
                        MessageBox.Show("证件号不能为空！", "提示信息");
                    }
                    else
                    {
                        QueryByNumber();
                    }
                }
            }
            CardRecognise.CloseCardReader();
        }

        private void Summery()
        {
            double[] Result = new double[2];
            double InHouseAmount = 0;
            int InHouseCount = 0;
            double RedeenAmout = 0;
            int RedeenCount = 0;
            double CloseAmount = 0;
            int CloseCount = 0;
            double TotalAmount = 0;
            double TotalCount = 0;


            //在库金额
            Result = GetAmountByStatus(new int[] { 1, 3, 4, 5 });
            InHouseAmount = Result[0];
            InHouseCount = Convert.ToInt32(Result[1]);

            //赎回金额
            Result = GetAmountByStatus(new int[] { 2 });
            RedeenAmout = Result[0];
            RedeenCount = Convert.ToInt32(Result[1]);

            //绝当金额
            Result = GetAmountByStatus(new int[] { 4, 7 });
            CloseAmount = Result[0];
            CloseCount = Convert.ToInt32(Result[1]);

            //全部金额
            Result = GetAmountByStatus(new int[] { 1, 2, 3, 4, 5, 7 });
            TotalAmount = Result[0];
            TotalCount = Convert.ToInt32(Result[1]);

            //输出
            lblTotalAmount.Text = TotalAmount.ToString();
            lblTotalCount.Text = TotalCount.ToString();

            lblInHouseAmount.Text = InHouseAmount.ToString();
            lblInHouseAmountPercent.Text = DianDangFunction.myRound((InHouseAmount / TotalAmount * 100), MainForm.AmountAccuracy).ToString() + "%";
            lblInHouseCount.Text = InHouseCount.ToString();
            lblInHouseCountPercent.Text = DianDangFunction.myRound((InHouseCount / TotalCount * 100), MainForm.AmountAccuracy).ToString() + "%";

            lblRedeenAmount.Text = RedeenAmout.ToString();
            lblRedeenAmountPercent.Text = DianDangFunction.myRound((RedeenAmout / TotalAmount * 100), MainForm.AmountAccuracy).ToString() + "%";
            lblRedeenCount.Text = RedeenCount.ToString();
            lblRedeenCountPercent.Text = DianDangFunction.myRound((RedeenCount / TotalCount * 100), MainForm.AmountAccuracy).ToString() + "%";

            lblCloseAmount.Text = CloseAmount.ToString();
            lblCloseAmountPercent.Text = DianDangFunction.myRound((CloseAmount / TotalAmount * 100), MainForm.AmountAccuracy).ToString() + "%";
            lblCloseCount.Text = CloseCount.ToString();
            lblCloseCountPercent.Text = DianDangFunction.myRound((CloseCount / TotalCount * 100), MainForm.AmountAccuracy).ToString() + "%";

            Result = GetTotalFee();
            lblTotalServiceFee.Text = Result[0].ToString();
            lblTotalInterestFee.Text = Result[1].ToString();

            DDCustomerInfo newInfo = new DDCustomerInfo("CustomerID", m_CustomerID);
            this.lblStartDate.Text = DianDangFunction.ChangeDateFormat(newInfo.CreatDate);

            Query queryTicket = new Query(DDPawnTicket.Schema);
            queryTicket.AddWhere("CustomerID", m_CustomerID);
            queryTicket.AddWhere("StatusID", Comparison.In, new int[] { 1, 2, 3 });
            DataTable dtTicket = queryTicket.ExecuteDataSet().Tables[0];
            int[] TicketIDList = new int[dtTicket.Rows.Count];
            for (int j = 0; j < dtTicket.Rows.Count; j++)
            {
                TicketIDList[j] = Convert.ToInt32(dtTicket.Rows[j]["TicketID"].ToString());
            }
            Query queryOperation = new Query(DDOperation.Schema);
            queryOperation.AddWhere("TicketID", Comparison.In, TicketIDList);
            queryOperation.AddWhere("NextOperationID", 0);
            queryOperation.ORDER_BY("OperationDate", "desc");
            DataTable dtOperation = queryOperation.ExecuteDataSet().Tables[0];
            lblLastDate.Text = DianDangFunction.ChangeDateFormat(dtOperation.Rows[0]["OperationDate"].ToString());
        }

        private double[] GetAmountByStatus(int[] iStatus)
        {
            double[] Result = new double[2];
            Result[0] = 0; Result[1] = 0;
            Query queryTicket = new Query(DDPawnTicket.Schema);
            queryTicket.AddWhere("CustomerID", m_CustomerID);
            queryTicket.AddWhere("StatusID", Comparison.In, iStatus);
            DataTable dtTicket = queryTicket.ExecuteDataSet().Tables[0];
            int[] TicketIDList = new int[dtTicket.Rows.Count];
            if (dtTicket.Rows.Count > 0)
            {
                for (int j = 0; j < dtTicket.Rows.Count; j++)
                {
                    TicketIDList[j] = Convert.ToInt32(dtTicket.Rows[j]["TicketID"].ToString());
                    Result[1]++;
                }
                Query queryOperation = new Query(DDOperation.Schema);
                queryOperation.AddWhere("TicketID", Comparison.In, TicketIDList);
                queryOperation.AddWhere("NextOperationID", 0);
                DataTable dtOperation = queryOperation.ExecuteDataSet().Tables[0];
                for (int j = 0; j < dtOperation.Rows.Count; j++)
                {
                    Result[0] = Result[0] + Convert.ToInt32(dtOperation.Rows[j]["Amount"].ToString());
                }
                Result[0] = DianDangFunction.myRound(Result[0], MainForm.AmountAccuracy);
            }


            return Result;
        }

        private double[] GetTotalFee()
        {
            double[] Result = new double[2];
            Result[0] = 0; Result[1] = 0;

            Query queryTicket = new Query(DDPawnTicket.Schema);
            queryTicket.AddWhere("StatusID", Comparison.NotEquals, 6);
            queryTicket.AddWhere("CustomerID", m_CustomerID);
            DataTable dtTicket = queryTicket.ExecuteDataSet().Tables[0];
            int[] TicketIDList = new int[dtTicket.Rows.Count];
            for (int i = 0; i < dtTicket.Rows.Count; i++)
            {
                TicketIDList[i] = Convert.ToInt32(dtTicket.Rows[i]["TicketID"].ToString());
            }

            Query queryOperation = new Query(DDOperation.Schema);
            queryOperation.AddWhere("OperationType", Comparison.In, new int[] { 1, 2, 3 });
            queryOperation.AddWhere("TicketID", Comparison.In, TicketIDList);
            DataTable dtOperation = queryOperation.ExecuteDataSet().Tables[0];
            for (int i = 0; i < dtOperation.Rows.Count; i++)
            {
                Result[0] = Result[0] + Convert.ToDouble(dtOperation.Rows[i]["ServiceFee"].ToString())
                                      + Convert.ToDouble(dtOperation.Rows[i]["OverdueFee"].ToString())
                                      - Convert.ToDouble(dtOperation.Rows[i]["ReturnFee"].ToString());
                Result[1] = Result[1] + Convert.ToDouble(dtOperation.Rows[i]["InterestFee"].ToString());
            }

            Result[0] = DianDangFunction.myRound(Result[0], MainForm.AmountAccuracy);
            Result[1] = DianDangFunction.myRound(Result[1], MainForm.AmountAccuracy);

            return Result;
        }

    }
}
