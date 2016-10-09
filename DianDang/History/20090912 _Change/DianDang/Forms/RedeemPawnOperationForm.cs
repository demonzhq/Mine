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
    public partial class RedeemPawnOperationForm : DockContent
    {
        public RedeemPawnOperationForm(int iTicketID)
        {
            InitializeComponent();
            InitGridTableColumn();
            LoadOperationNumber();
            LoadTicketInfo(iTicketID);
        }

        private DateTime m_CurrentDate = DateTime.Now;
        private DateTime m_StartDate;
        private DateTime m_EndDate;

        private double CaculateOverdueFee(double amount, double feeRate, double interestRate)
        {
            double overdueFee = 0;
            TimeSpan overdueTimeSpan = m_CurrentDate.Subtract(m_EndDate);
            TimeSpan termTimeSpan = m_EndDate.Subtract(m_StartDate);
            int termDays = termTimeSpan.Days;
            int overdueDays = overdueTimeSpan.Days;
            if (overdueDays > 0)
            {
                overdueFee = (feeRate + interestRate) * amount * overdueDays / 30 / 100;
            }
            overdueFee = Math.Round(overdueFee, 2);
            return overdueFee;
        }

        private double CaculatePaidFee(double amount, double feeRate, double interestRate)
        {
            double paidFee = 0;

            TimeSpan timeSpanFromStart = m_CurrentDate.Subtract(m_StartDate);
            int spanDaysFromStart = timeSpanFromStart.Days;
            int months = spanDaysFromStart / 30;
            int returnDays = spanDaysFromStart - 30 * months;

            if (returnDays < 6)
            {
                paidFee = (feeRate + interestRate) * amount * (5 + months * 30) / 100 / 30;
            }
            else if (returnDays < 16)
            {
                paidFee = (feeRate + interestRate) * amount * (15 + months * 30) / 100 / 30;
            }
            else
            {
                paidFee = (feeRate + interestRate) * amount * (30 + months * 30) / 100 / 30;
            }
            paidFee = Math.Round(paidFee, 2);
            return paidFee;
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
                strRight = strRight.PadRight(j, '0');   //有多少个9补多少个零
                strMiddle = Convert.ToString(int.Parse(strCode.Substring(strCode.Length - j - 1, 1)) + 1);   //加1后的值
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

        private int m_TicketID = 0;

        private DataTable m_GridTable = new DataTable();

        private void InitGridTableColumn()
        {
            m_GridTable.Columns.Add("ClassName", typeof(System.String));
            m_GridTable.Columns.Add("Amount", typeof(System.String));
            m_GridTable.Columns.Add("ServiceFee", typeof(System.String));
            m_GridTable.Columns.Add("InterestFee", typeof(System.String));
            m_GridTable.Columns.Add("ReturnFee", typeof(System.String));
            m_GridTable.Columns.Add("OverdueFee", typeof(System.String));

        }

        private void LoadTicketInfo(int iTicketID)
        {
            m_TicketID = iTicketID;
            DDPawnTicket newTicket = new DDPawnTicket("TicketID", iTicketID);

            Query queryOperations = new Query(DDOperation.Schema);
            queryOperations.AddWhere("TicketID", iTicketID);
            queryOperations.AddWhere("OperationType", 1);
            DataTable dtOperations = queryOperations.ExecuteDataSet().Tables[0];

            double amount = 0;
            double serviceFee = 0, interestFee = 0;
            double overdueFee = 0, returnFee = 0;
            double totalServiceFee = 0, totalInterestFee = 0, totalAmount = 0;
            double totalOverdueFee = 0, totalReturnFee = 0;

            m_StartDate = Convert.ToDateTime(newTicket.StartDate);
            m_EndDate = Convert.ToDateTime(newTicket.EndDate);

            if (dtOperations.Rows.Count > 0)
            {
                for (int i = 0; i < dtOperations.Rows.Count; i++)
                {
                    amount = Convert.ToDouble(dtOperations.Rows[i]["Amount"]);
                    serviceFee = Convert.ToDouble(dtOperations.Rows[i]["ServiceFee"]);
                    interestFee = Convert.ToDouble(dtOperations.Rows[i]["InterestFee"]);
                    totalServiceFee += serviceFee;
                    totalInterestFee += interestFee;
                    totalAmount += amount;
                    DDPawnageInfo pawnageInfo = new DDPawnageInfo("PawnageID", Convert.ToInt32(dtOperations.Rows[i]["PawnageID"]));
                    overdueFee = CaculateOverdueFee(amount, Convert.ToDouble(pawnageInfo.FeeRate), Convert.ToDouble(pawnageInfo.InterestRate));
                    returnFee = serviceFee + interestFee - CaculatePaidFee(amount, Convert.ToDouble(pawnageInfo.FeeRate), Convert.ToDouble(pawnageInfo.InterestRate));
                    totalOverdueFee += overdueFee;
                    totalReturnFee += returnFee;

                    DataRow drow = m_GridTable.NewRow();
                    DDPawnageClass pawnageClass = new DDPawnageClass("ClassID",pawnageInfo.ClassID);
                    drow["ClassName"] = pawnageClass.ClassName;
                    drow["Amount"] = amount;
                    drow["ServiceFee"] = serviceFee;
                    drow["InterestFee"] = interestFee;
                    drow["ReturnFee"] = returnFee;
                    drow["OverdueFee"] = overdueFee;
                    m_GridTable.Rows.Add(drow);
                }
            }
            //续当服务费统计
            Query queryRenewOperations = new Query(DDOperation.Schema);
            queryRenewOperations.AddWhere("TicketID", iTicketID);
            queryRenewOperations.AddWhere("OperationType", 3);
            DataTable dtRenewOperations = queryRenewOperations.ExecuteDataSet().Tables[0];
            if (dtRenewOperations.Rows.Count > 0)
            {
                for (int j = 0; j < dtRenewOperations.Rows.Count; j++)
                {
                    serviceFee = Convert.ToDouble(dtRenewOperations.Rows[j]["ServiceFee"]);
                    interestFee = Convert.ToDouble(dtRenewOperations.Rows[j]["InterestFee"]);
                    totalServiceFee += serviceFee;
                    totalInterestFee += interestFee;
                    DDPawnageInfo pawnageInfo = new DDPawnageInfo("PawnageID", Convert.ToInt32(dtRenewOperations.Rows[j]["PawnageID"]));
                    overdueFee = CaculateOverdueFee(amount, Convert.ToDouble(pawnageInfo.FeeRate), Convert.ToDouble(pawnageInfo.InterestRate));
                    returnFee = serviceFee + interestFee - CaculatePaidFee(amount, Convert.ToDouble(pawnageInfo.FeeRate), Convert.ToDouble(pawnageInfo.InterestRate));
                    totalOverdueFee += overdueFee;
                    totalReturnFee += returnFee;

                    DataRow drow = m_GridTable.NewRow();
                    DDPawnageClass pawnageClass = new DDPawnageClass("ClassID", pawnageInfo.ClassID);
                    drow["ClassName"] = pawnageClass.ClassName;
                    drow["Amount"] = amount;
                    drow["ServiceFee"] = serviceFee;
                    drow["InterestFee"] = interestFee;
                    drow["ReturnFee"] = returnFee;
                    drow["OverdueFee"] = overdueFee;
                    m_GridTable.Rows.Add(drow);
                }
            }

            this.dataGridView1.DataSource = m_GridTable;

            double paidFee = totalAmount + totalInterestFee + totalOverdueFee - totalReturnFee;
            
            //string strMessage = "本次赎当金额共计：" + totalAmount.ToString() + ",综合服务费：" + totalServiceFee.ToString() + ",典当利息：" + totalInterestFee.ToString() + ",逾期服务费：" + totalOverdueFee.ToString() + ",返回服务费：" + totalReturnFee.ToString() + ",客户应付：" + paidFee.ToString();
            string strDate = m_CurrentDate.Year.ToString() + "-" + m_CurrentDate.Month.ToString() + "-" + m_CurrentDate.Day.ToString();
            this.tbxOperationDate.Text = strDate;
            
            this.tbxAmount.Text = totalAmount.ToString();
            this.tbxServiceFee.Text = totalServiceFee.ToString();
            this.tbxInterestFee.Text = totalInterestFee.ToString();
            this.tbxReturnFee.Text = totalReturnFee.ToString();
            this.tbxOverdueFee.Text = totalOverdueFee.ToString();
            this.tbxPaidFee.Text = paidFee.ToString();
        }

        private void UpdateOperation(int iTicketID)
        {

            DDPawnTicket newTicket = new DDPawnTicket("TicketID", iTicketID);

            Query queryOperations = new Query(DDOperation.Schema);
            queryOperations.AddWhere("TicketID", iTicketID);
            queryOperations.AddWhere("OperationType", 1);
            DataTable dtOperations = queryOperations.ExecuteDataSet().Tables[0];

            double amount = 0;
            double serviceFee = 0, interestFee = 0;
            double overdueFee = 0, returnFee = 0;
            //double totalServiceFee = 0, totalInterestFee = 0, totalAmount = 0;
            //double totalOverdueFee = 0, totalReturnFee = 0;

            newTicket.StatusID = 2;
            newTicket.Save();
            string strDate = this.tbxOperationDate.Text.Trim();
            int preOperationID = 0;
            //操作：新当-〉赎当
            for (int i = 0; i < dtOperations.Rows.Count; i++)
            {
                DDOperation newOperation = new DDOperation();
                preOperationID = Convert.ToInt32(dtOperations.Rows[i]["OperationID"]);
                newOperation.TicketID = iTicketID;
                newOperation.PawnageID = Convert.ToInt32(dtOperations.Rows[i]["PawnageID"]);
                newOperation.OperationType = 2;   //2 ：赎当
                newOperation.OperationNumber = m_OperationNumber;
                newOperation.ServiceFee = "0";
                newOperation.InterestFee = "0";
                amount = Convert.ToDouble(dtOperations.Rows[i]["Amount"]);
                serviceFee = Convert.ToDouble(dtOperations.Rows[i]["ServiceFee"]);
                interestFee = Convert.ToDouble(dtOperations.Rows[i]["InterestFee"]);
                DDPawnageInfo pawnageInfo = new DDPawnageInfo("PawnageID", Convert.ToInt32(dtOperations.Rows[i]["PawnageID"]));
                overdueFee = CaculateOverdueFee(amount, Convert.ToDouble(pawnageInfo.FeeRate), Convert.ToDouble(pawnageInfo.InterestRate));
                returnFee = serviceFee + interestFee - CaculatePaidFee(amount, Convert.ToDouble(pawnageInfo.FeeRate), Convert.ToDouble(pawnageInfo.InterestRate));
                newOperation.ReturnFee = returnFee.ToString();
                newOperation.OverdueFee = overdueFee.ToString();
                newOperation.Amount = dtOperations.Rows[i]["Amount"].ToString();
                newOperation.ReckonAmount = "0";
                newOperation.OperationDate = strDate;
                newOperation.OperaterName = MainForm.AccountName;
                newOperation.PreOperationID = preOperationID;
                newOperation.NextOperationID = 0;
                newOperation.Save();

                DDOperation oldOperation = new DDOperation("OperationID", preOperationID);
                if (oldOperation.NextOperationID == 0)
                {
                    oldOperation.NextOperationID = newOperation.OperationID;
                    oldOperation.Save();
                }
            }

            Query queryRenewOperations = new Query(DDOperation.Schema);
            queryRenewOperations.AddWhere("TicketID", iTicketID);
            queryRenewOperations.AddWhere("OperationType", 3);
            DataTable dtRenewOperations = queryRenewOperations.ExecuteDataSet().Tables[0];
            //操作：续当-〉赎当
            for (int i = 0; i < dtRenewOperations.Rows.Count; i++)
            {
                DDOperation newOperation = new DDOperation();
                preOperationID = Convert.ToInt32(dtRenewOperations.Rows[i]["OperationID"]);
                newOperation.TicketID = iTicketID;
                newOperation.PawnageID = Convert.ToInt32(dtRenewOperations.Rows[i]["PawnageID"]);
                newOperation.OperationType = 2;   //2 ：赎当
                newOperation.OperationNumber = "0";
                newOperation.ServiceFee = "0";
                newOperation.InterestFee = "0";
                amount = Convert.ToDouble(dtRenewOperations.Rows[i]["Amount"]);
                serviceFee = Convert.ToDouble(dtRenewOperations.Rows[i]["ServiceFee"]);
                interestFee = Convert.ToDouble(dtRenewOperations.Rows[i]["InterestFee"]);
                DDPawnageInfo pawnageInfo = new DDPawnageInfo("PawnageID", Convert.ToInt32(dtRenewOperations.Rows[i]["PawnageID"]));
                overdueFee = CaculateOverdueFee(amount, Convert.ToDouble(pawnageInfo.FeeRate), Convert.ToDouble(pawnageInfo.InterestRate));
                returnFee = serviceFee + interestFee - CaculatePaidFee(amount, Convert.ToDouble(pawnageInfo.FeeRate), Convert.ToDouble(pawnageInfo.InterestRate));
                newOperation.ReturnFee = returnFee.ToString();
                newOperation.OverdueFee = overdueFee.ToString();
                newOperation.Amount = dtRenewOperations.Rows[i]["Amount"].ToString();
                newOperation.ReckonAmount = "0";
                newOperation.OperationDate = strDate;
                newOperation.OperaterName = MainForm.AccountName;
                newOperation.PreOperationID = preOperationID;
                newOperation.NextOperationID = 0;
                newOperation.Save();

                DDOperation oldOperation = new DDOperation("OperationID", preOperationID);
                if (oldOperation.NextOperationID == 0)
                {
                    oldOperation.NextOperationID = newOperation.OperationID;
                    oldOperation.Save();
                }
            }
            //MessageBox.Show("赎当处理成功！", "赎当");

        }

        private void PrintReceipt()
        {
            ReceiptPrintViewForm frmReceiptPrintView = new ReceiptPrintViewForm(m_TicketID);
            frmReceiptPrintView.Show();
            //frmReceiptPrintView.Show();
            //frmReceiptPrintView.PrintOut();
            //frmReceiptPrintView.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateOperation(m_TicketID);
                UpdateOperationNumber();
                PrintReceipt();
            }
            catch 
            {
                MessageBox.Show(this, "操作失败，请检查数据库是否连接正确！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tbxOperationDate_Click(object sender, EventArgs e)
        {

        }
    }
}