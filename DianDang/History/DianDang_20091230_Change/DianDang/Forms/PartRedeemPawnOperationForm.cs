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
    public partial class PartRedeemPawnOperationForm : DockContent
    {
        public PartRedeemPawnOperationForm(int iTicketID)
        {
            InitializeComponent();
            InitGridTableColumn();

            this.btnPrint.Enabled = true;

            LoadOperationNumber();

            DateTime currentDate = DateTime.Now;
            string strDate = currentDate.Year.ToString() + "-" + currentDate.Month.ToString() + "-" + currentDate.Day.ToString();
            this.tbxOperationDate.Text = strDate;
            m_TicketID = iTicketID;
            LoadTicketInfo();
        }

        private DateTime m_OperationDate;
        private DateTime m_StartDate;
        private DateTime m_EndDate;

        private double CaculateOverdueFee(double amount, double feeRate, double interestRate)
        {
            double overdueFee = 0;
            TimeSpan overdueTimeSpan = m_OperationDate.Subtract(m_EndDate);
            TimeSpan termTimeSpan = m_EndDate.Subtract(m_StartDate);
            int termDays = termTimeSpan.Days;
            int overdueDays = overdueTimeSpan.Days;
            if (overdueDays > 0)
            {
                overdueFee = (feeRate + interestRate) * amount * overdueDays / 30 / 100;
            }
            overdueFee = DianDangFunction.myRound(overdueFee, MainForm.AmountAccuracy);
            return overdueFee;
        }

        private double CaculateReturnFee(double amount, double feeRate, double interestRate)
        {
            double returnFee = 0;
            TimeSpan returnTimeSpan = m_EndDate.Subtract(m_OperationDate);
            int returnDays = returnTimeSpan.Days;
            int months = returnDays / 30;
            returnDays = returnDays - 30 * months;

            if (returnDays < 16)
            {
                returnFee = (feeRate + interestRate) * amount * months / 100;
            }
            else if (returnDays < 26)
            {
                returnFee = (feeRate + interestRate) * amount * (15 + months * 30) / 100 / 30;
            }
            else
            {
                returnFee = (feeRate + interestRate) * amount * (25 + months * 30) / 100 / 30;
            }

            returnFee = DianDangFunction.myRound(returnFee, MainForm.AmountAccuracy);
            return returnFee;
        }

        private double CaculatePaidFee(double amount, double feeRate, double interestRate)
        {
            double paidFee = 0;

            TimeSpan timeSpanFromStart = m_OperationDate.Subtract(m_StartDate);
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
            paidFee = DianDangFunction.myRound(paidFee, MainForm.AmountAccuracy);
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

        private int m_TicketID = 0;
        private int m_NewTicketID = 0;

        private DataTable m_GridTable = new DataTable();

        private void InitGridTableColumn()
        {
            m_GridTable.Columns.Add("PawnageID", typeof(System.Int32));
            m_GridTable.Columns.Add("ClassName", typeof(System.String));
            m_GridTable.Columns.Add("Amount", typeof(System.String));
            m_GridTable.Columns.Add("ServiceFee", typeof(System.String));
            m_GridTable.Columns.Add("InterestFee", typeof(System.String));
            m_GridTable.Columns.Add("ReturnFee", typeof(System.String));
            m_GridTable.Columns.Add("OverdueFee", typeof(System.String));

        }

        private void LoadTicketInfo()
        {
            this.m_GridTable.Rows.Clear();
            
            DDPawnTicket newTicket = new DDPawnTicket("TicketID", m_TicketID);

            Query queryOperations = new Query(DDOperation.Schema);
            queryOperations.AddWhere("TicketID", m_TicketID);
            queryOperations.AddWhere("OperationType", 1);
            DataTable dtOperations = queryOperations.ExecuteDataSet().Tables[0];

            double amount = 0;
            double serviceFee = 0, interestFee = 0;
            double overdueFee = 0, returnFee = 0;
            double totalServiceFee = 0, totalInterestFee = 0, totalAmount = 0;
            double totalOverdueFee = 0, totalReturnFee = 0;

            m_StartDate = Convert.ToDateTime(newTicket.StartDate);
            m_EndDate = Convert.ToDateTime(newTicket.EndDate);
            m_OperationDate = Convert.ToDateTime(this.tbxOperationDate.Text.Trim());

            if (dtOperations.Rows.Count > 0)
            {
                for (int i = 0; i < dtOperations.Rows.Count; i++)
                {
                    amount = Convert.ToDouble(dtOperations.Rows[i]["Amount"]);
                    serviceFee = Convert.ToDouble(dtOperations.Rows[i]["ServiceFee"]);
                    interestFee = Convert.ToDouble(dtOperations.Rows[i]["InterestFee"]);

                    Query queryRenewPawn = new Query(DDOperation.Schema);
                    queryRenewPawn.AddWhere("TicketID",m_TicketID);
                    queryRenewPawn.AddWhere("PawnageID",Convert.ToInt32(dtOperations.Rows[i]["PawnageID"]));
                    queryRenewPawn.AddWhere("OperationType",3);
                    DataTable dtRenewPawn = queryRenewPawn.ExecuteDataSet().Tables[0];
                    if (dtRenewPawn.Rows.Count > 0)
                    {
                        for (int j = 0; j < dtRenewPawn.Rows.Count; j++)
                        {
                            serviceFee += Convert.ToDouble(dtRenewPawn.Rows[j]["ServiceFee"]);
                            interestFee += Convert.ToDouble(dtRenewPawn.Rows[j]["InterestFee"]);
                        }
                    }

                    totalServiceFee += serviceFee;
                    totalInterestFee += interestFee;
                    totalAmount += amount;
                    DDPawnageInfo pawnageInfo = new DDPawnageInfo("PawnageID", Convert.ToInt32(dtOperations.Rows[i]["PawnageID"]));
                    overdueFee = CaculateOverdueFee(amount, Convert.ToDouble(pawnageInfo.FeeRate), Convert.ToDouble(pawnageInfo.InterestRate));
                    //returnFee = serviceFee + interestFee - CaculatePaidFee(amount, Convert.ToDouble(pawnageInfo.FeeRate), Convert.ToDouble(pawnageInfo.InterestRate));
                    returnFee = CaculateReturnFee(amount, Convert.ToDouble(pawnageInfo.FeeRate), Convert.ToDouble(pawnageInfo.InterestRate));
                   
                    if (returnFee < 0)
                    {
                        returnFee = 0;
                    }
                    totalOverdueFee += overdueFee;
                    totalReturnFee += returnFee;

                    DataRow drow = m_GridTable.NewRow();
                    DDPawnageClass pawnageClass = new DDPawnageClass("ClassID",pawnageInfo.ClassID);
                    drow["PawnageID"] = Convert.ToInt32(dtOperations.Rows[i]["PawnageID"]);
                    drow["ClassName"] = pawnageClass.ClassName;
                    drow["Amount"] = amount;
                    drow["ServiceFee"] = serviceFee;
                    drow["InterestFee"] = interestFee;
                    drow["ReturnFee"] = returnFee;
                    drow["OverdueFee"] = overdueFee;
                    m_GridTable.Rows.Add(drow);
                }
            }
            //���������ͳ��
            //Query queryRenewOperations = new Query(DDOperation.Schema);
            //queryRenewOperations.AddWhere("TicketID", iTicketID);
            //queryRenewOperations.AddWhere("OperationType", 3);
            //DataTable dtRenewOperations = queryRenewOperations.ExecuteDataSet().Tables[0];
            //if (dtRenewOperations.Rows.Count > 0)
            //{
            //    for (int j = 0; j < dtRenewOperations.Rows.Count; j++)
            //    {
            //        serviceFee = Convert.ToDouble(dtRenewOperations.Rows[j]["ServiceFee"]);
            //        interestFee = Convert.ToDouble(dtRenewOperations.Rows[j]["InterestFee"]);
            //        totalServiceFee += serviceFee;
            //        totalInterestFee += interestFee;
            //        DDPawnageInfo pawnageInfo = new DDPawnageInfo("PawnageID", Convert.ToInt32(dtRenewOperations.Rows[j]["PawnageID"]));
            //        overdueFee = CaculateOverdueFee(amount, Convert.ToDouble(pawnageInfo.FeeRate), Convert.ToDouble(pawnageInfo.InterestRate));
            //        returnFee = serviceFee + interestFee - CaculatePaidFee(amount, Convert.ToDouble(pawnageInfo.FeeRate), Convert.ToDouble(pawnageInfo.InterestRate));
            //        totalOverdueFee += overdueFee;
            //        totalReturnFee += returnFee;

            //        DataRow drow = m_GridTable.NewRow();
            //        DDPawnageClass pawnageClass = new DDPawnageClass("ClassID", pawnageInfo.ClassID);
            //        drow["ClassName"] = pawnageClass.ClassName;
            //        drow["Amount"] = amount;
            //        drow["ServiceFee"] = serviceFee;
            //        drow["InterestFee"] = interestFee;
            //        drow["ReturnFee"] = returnFee;
            //        drow["OverdueFee"] = overdueFee;
            //        m_GridTable.Rows.Add(drow);
            //    }
            //}

            this.dataGridView1.DataSource = m_GridTable;

            double paidFee = totalAmount + totalInterestFee + totalOverdueFee - totalReturnFee;
            
            //string strMessage = "�����굱���ƣ�" + totalAmount.ToString() + ",�ۺϷ���ѣ�" + totalServiceFee.ToString() + ",�䵱��Ϣ��" + totalInterestFee.ToString() + ",���ڷ���ѣ�" + totalOverdueFee.ToString() + ",���ط���ѣ�" + totalReturnFee.ToString() + ",�ͻ�Ӧ����" + paidFee.ToString();
            string strDate = m_OperationDate.Year.ToString() + "-" + m_OperationDate.Month.ToString() + "-" + m_OperationDate.Day.ToString();
            this.tbxOperationDate.Text = strDate;
            
            this.tbxAmount.Text = totalAmount.ToString();
            this.tbxServiceFee.Text = totalServiceFee.ToString();
            this.tbxInterestFee.Text = totalInterestFee.ToString();
            this.tbxReturnFee.Text = totalReturnFee.ToString();
            this.tbxOverdueFee.Text = totalOverdueFee.ToString();
            this.tbxPaidFee.Text = paidFee.ToString();
        }

        private void RedeemOperation(int iTicketID)
        {
            DDPawnTicket newTicket = new DDPawnTicket("TicketID", iTicketID);

            Query queryOperations = new Query(DDOperation.Schema);
            queryOperations.AddWhere("TicketID", iTicketID);
            queryOperations.AddWhere("OperationType", Comparison.In, new int[] { 1, 3 });
            queryOperations.AddWhere("NextOperationID",0);
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
            //�������µ�-���굱
            for (int i = 0; i < dtOperations.Rows.Count; i++)
            {
                DDOperation newOperation = new DDOperation();
                preOperationID = Convert.ToInt32(dtOperations.Rows[i]["OperationID"]);
                newOperation.TicketID = iTicketID;
                newOperation.PawnageID = Convert.ToInt32(dtOperations.Rows[i]["PawnageID"]);
                newOperation.OperationType = 2;   //2 ���굱
                newOperation.OperationNumber = m_OperationNumber;
                newOperation.ServiceFee = "0";
                newOperation.InterestFee = "0";
                amount = Convert.ToDouble(dtOperations.Rows[i]["Amount"]);

                serviceFee =0;
                interestFee =0;
                Query queryRenewPawn = new Query(DDOperation.Schema);
                queryRenewPawn.AddWhere("TicketID", m_TicketID);
                queryRenewPawn.AddWhere("PawnageID", Convert.ToInt32(dtOperations.Rows[i]["PawnageID"]));
                queryRenewPawn.AddWhere("OperationType", Comparison.In, new int[] { 1, 3 });
                DataTable dtRenewPawn = queryRenewPawn.ExecuteDataSet().Tables[0];
                if (dtRenewPawn.Rows.Count > 0)
                {
                    for (int j = 0; j < dtRenewPawn.Rows.Count; j++)
                    {
                        serviceFee += Convert.ToDouble(dtRenewPawn.Rows[j]["ServiceFee"]);
                        interestFee += Convert.ToDouble(dtRenewPawn.Rows[j]["InterestFee"]);
                    }
                }

                DDPawnageInfo pawnageInfo = new DDPawnageInfo("PawnageID", Convert.ToInt32(dtOperations.Rows[i]["PawnageID"]));
                overdueFee = CaculateOverdueFee(amount, Convert.ToDouble(pawnageInfo.FeeRate), Convert.ToDouble(pawnageInfo.InterestRate));
                //returnFee = serviceFee + interestFee - CaculatePaidFee(amount, Convert.ToDouble(pawnageInfo.FeeRate), Convert.ToDouble(pawnageInfo.InterestRate));
                returnFee = CaculateReturnFee(amount, Convert.ToDouble(pawnageInfo.FeeRate), Convert.ToDouble(pawnageInfo.InterestRate));                 
                newOperation.ReturnFee = returnFee.ToString();
                newOperation.OverdueFee = overdueFee.ToString();
                newOperation.Amount = dtOperations.Rows[i]["Amount"].ToString();
                newOperation.ReckonAmount = "0";
                newOperation.OperationDate = strDate;
                newOperation.OperaterName = MainForm.AccountName;
                newOperation.PreOperationID = preOperationID;
                newOperation.NextOperationID = 0;
                newOperation.Deleted = 0;
                newOperation.Save();

                DDOperation oldOperation = new DDOperation("OperationID", preOperationID);
                if (oldOperation.NextOperationID == 0)
                {
                    oldOperation.NextOperationID = newOperation.OperationID;
                    oldOperation.Save();
                }
            }

            //Query queryRenewOperations = new Query(DDOperation.Schema);
            //queryRenewOperations.AddWhere("TicketID", iTicketID);
            //queryRenewOperations.AddWhere("OperationType", 3);
            //DataTable dtRenewOperations = queryRenewOperations.ExecuteDataSet().Tables[0];
            ////����������-���굱
            //for (int i = 0; i < dtRenewOperations.Rows.Count; i++)
            //{
            //    DDOperation newOperation = new DDOperation();
            //    preOperationID = Convert.ToInt32(dtRenewOperations.Rows[i]["OperationID"]);
            //    newOperation.TicketID = iTicketID;
            //    newOperation.PawnageID = Convert.ToInt32(dtRenewOperations.Rows[i]["PawnageID"]);
            //    newOperation.OperationType = 2;   //2 ���굱
            //    newOperation.OperationNumber = "0";
            //    newOperation.ServiceFee = "0";
            //    newOperation.InterestFee = "0";
            //    amount = Convert.ToDouble(dtRenewOperations.Rows[i]["Amount"]);
            //    serviceFee = Convert.ToDouble(dtRenewOperations.Rows[i]["ServiceFee"]);
            //    interestFee = Convert.ToDouble(dtRenewOperations.Rows[i]["InterestFee"]);
            //    DDPawnageInfo pawnageInfo = new DDPawnageInfo("PawnageID", Convert.ToInt32(dtRenewOperations.Rows[i]["PawnageID"]));
            //    overdueFee = CaculateOverdueFee(amount, Convert.ToDouble(pawnageInfo.FeeRate), Convert.ToDouble(pawnageInfo.InterestRate));
            //    returnFee = serviceFee + interestFee - CaculatePaidFee(amount, Convert.ToDouble(pawnageInfo.FeeRate), Convert.ToDouble(pawnageInfo.InterestRate));
            //    newOperation.ReturnFee = returnFee.ToString();
            //    newOperation.OverdueFee = overdueFee.ToString();
            //    newOperation.Amount = dtRenewOperations.Rows[i]["Amount"].ToString();
            //    newOperation.ReckonAmount = "0";
            //    newOperation.OperationDate = strDate;
            //    newOperation.OperaterName = MainForm.AccountName;
            //    newOperation.PreOperationID = preOperationID;
            //    newOperation.NextOperationID = 0;
            //    newOperation.Save();

            //    DDOperation oldOperation = new DDOperation("OperationID", preOperationID);
            //    if (oldOperation.NextOperationID == 0)
            //    {
            //        oldOperation.NextOperationID = newOperation.OperationID;
            //        oldOperation.Save();
            //    }
            //}
            ////MessageBox.Show("�굱����ɹ���", "�굱");

        }

        private void PrintReceipt()
        {
            ReceiptPrintViewForm frmReceiptPrintView = new ReceiptPrintViewForm(m_TicketID);
            //frmReceiptPrintView.Show();
        }

        private string LoadTicketNumber()
        {
            DDGeneralParemeter newParam = new DDGeneralParemeter("ParamName", "CurrentTicketNumber");
            return newParam.ParamValue.Trim();
        }
        private void UpdateTicketNumber()
        {
            DDGeneralParemeter newParam = new DDGeneralParemeter("ParamName", "CurrentTicketNumber");
            newParam.ParamValue = CaculateString(newParam.ParamValue.Trim());
            newParam.Save();
        }

        private void CreateTicketInfo()
        {
            DDPawnTicket oldTicket = new DDPawnTicket("TicketID",m_TicketID);
            try
            {
                DDPawnTicket newTicket = new DDPawnTicket();
                newTicket.CustomerID = oldTicket.CustomerID;
                newTicket.TicketNumber = LoadTicketNumber();
                newTicket.StartDate = this.tbxOperationDate.Text;
                newTicket.EndDate = oldTicket.EndDate;
                newTicket.StatusID = 1;
                newTicket.Save();
                UpdateTicketNumber();
                m_NewTicketID = newTicket.TicketID;
            }
            catch
            {
                MessageBox.Show(this, "��Ʊ��Ϣ����ʧ�ܣ��������ݿ��Ƿ�������ȷ��", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        private int CreatePawnageInfo(int iPawnageID)
        {
            DDPawnageInfo oldPawnage = new DDPawnageInfo("PawnageID",iPawnageID);
            DDPawnageInfo newInfo = new DDPawnageInfo();
            newInfo.ClassID = oldPawnage.ClassID;
            newInfo.ParentID = oldPawnage.ParentID;
            newInfo.CountNumber = oldPawnage.CountNumber;
            newInfo.Weight = oldPawnage.Weight;
            newInfo.FeeRate = oldPawnage.FeeRate;
            newInfo.InterestRate = oldPawnage.InterestRate;
            newInfo.DiscountPercent = oldPawnage.DiscountPercent;
            newInfo.Description = oldPawnage.Description;
            newInfo.StartDate = this.tbxOperationDate.Text;
            newInfo.EndDate = oldPawnage.EndDate;
            newInfo.Remark = oldPawnage.Remark;
            newInfo.Save();
            return newInfo.PawnageID;
        }

        private void CreateOperation()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int iPawnageID = 0;
                double totalServiceFee=0, totalInterestFee=0, totalAmount=0;
                //DateTime endDate = Convert.ToDateTime(this.tbxOperationDate.Text).AddMonths(Convert.ToInt32(this.tbxPawnTerm.Text));
                for (int i = dataGridView1.SelectedRows.Count - 1; i > -1; i--)
                {
                    int rowIndex = dataGridView1.SelectedRows[i].Index;
                    DataGridViewRow dgr = dataGridView1.Rows[rowIndex];
                    iPawnageID = CreatePawnageInfo(Convert.ToInt32(dgr.Cells["PawnageID"].Value));
                    DDPawnageInfo oldPawnageInfo = new DDPawnageInfo("PawnageID", Convert.ToInt32(dgr.Cells["PawnageID"].Value));

                    DDOperation newOperation = new DDOperation();
                    newOperation.TicketID = m_NewTicketID;
                    newOperation.PawnageID = iPawnageID;
                    newOperation.OperationType = 1;   //1 ���µ�
                    newOperation.OperationNumber = m_OperationNumber;
                    //��������
                    //serviceFee = Convert.ToDouble(dgr.Cells["Amount"].Value) * Convert.ToInt32(this.tbxPawnTerm.Text) * Convert.ToDouble(oldPawnageInfo.FeeRate) / 100;
                    //serviceFee = DianDangFunction.myRound(serviceFee, MainForm.AmountAccuracy);
                    //totalServiceFee += serviceFee;
                    //newOperation.ServiceFee = serviceFee.ToString();
                    newOperation.ServiceFee = "0";
                    //����䵱��Ϣ
                    //interestFee = Convert.ToDouble(dgr.Cells["Amount"].Value) * Convert.ToInt32(this.tbxPawnTerm.Text) * Convert.ToDouble(oldPawnageInfo.InterestRate) / 100;
                    //interestFee = DianDangFunction.myRound(interestFee, MainForm.AmountAccuracy);
                    //totalInterestFee += interestFee;
                    //newOperation.InterestFee = interestFee.ToString();
                    newOperation.InterestFee = "0";
                    newOperation.ReturnFee = "0";
                    newOperation.OverdueFee = "0";
                    newOperation.Amount = dgr.Cells["Amount"].Value.ToString();
                    totalAmount += Convert.ToDouble(dgr.Cells["Amount"].Value);
                    newOperation.ReckonAmount = "0";
                    newOperation.OperationDate = this.tbxOperationDate.Text;
                    newOperation.StartDate = this.tbxOperationDate.Text;
                    newOperation.EndDate = oldPawnageInfo.EndDate;
                    newOperation.OperaterName = MainForm.AccountName;
                    newOperation.PreOperationID = 0;
                    newOperation.NextOperationID = 0;
                    newOperation.Deleted = 0;
                    newOperation.Save();   
                }
                this.tbxNewAmount.Text = totalAmount.ToString();
                this.tbxNewInterest.Text = totalInterestFee.ToString();
                this.tbxNewServiceFee.Text = totalServiceFee.ToString();
                double totalPaidFee=Convert.ToDouble(this.tbxPaidFee.Text)-Convert.ToDouble(this.tbxNewAmount.Text)+Convert.ToDouble(this.tbxNewServiceFee.Text);
                this.tbxTotalPaidFee.Text = totalPaidFee.ToString();
            }
            else
            {
                MessageBox.Show(this, "��Ʒ��ȫ����أ�", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (this.dataGridView1.Rows[i].Cells["IsRedeem"].Value != null && this.dataGridView1.Rows[i].Cells["IsRedeem"].Value.ToString() == "1")
                {
                    dataGridView1.Rows[i].Selected = false;
                }
                else
                {
                    dataGridView1.Rows[i].Selected = true;
                }
            }

            if (this.dataGridView1.Rows.Count == this.dataGridView1.SelectedRows.Count)
            {
                MessageBox.Show("��ѡ����Ҫ��صĵ�Ʒ��", "��ʾ��Ϣ");
                return;
            }

            try
            {
                RedeemOperation(m_TicketID);
                UpdateOperationNumber();
                DDPrintParam newParam = new DDPrintParam("PrintOption", 6);
                if (newParam.OptionValue == 1)
                {
                    PrintReceipt();
                }

                if (this.dataGridView1.SelectedRows.Count >0)
                {
                    CreateTicketInfo();
                    LoadOperationNumber();
                    CreateOperation();
                    UpdateOperationNumber();
                    ViewPawnTicketForm frmViewPawnTicket = new ViewPawnTicketForm(m_NewTicketID);
                    frmViewPawnTicket.Show((DockPanel)MainForm.pCurrentWin.Controls["dockPanel1"]);
                }

                this.btnPrint.Enabled = false;
            }
            catch 
            {
                MessageBox.Show(this, "����ʧ�ܣ��������ݿ��Ƿ�������ȷ��", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private int DateTextNumber = 0;

        private void tbxOperationDate_Click(object sender, EventArgs e)
        {
            DateTextNumber = 1;
            this.monthCalendar1.Visible = true;
        }

        private void tbxOperationDate_TextChanged(object sender, EventArgs e)
        {
            LoadTicketInfo();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            //���û���MonthCalendar�ϵ��������ת�����û������꣬�����������õ������
            string s = System.Convert.ToString(monthCalendar1.HitTest(this.PointToClient(MonthCalendar.MousePosition)).HitArea);

            string _year, _month, _day, _date;
            //����û���������������ı�����и�ֵ���˳�
            if (s.Equals("Nowhere"))
            {
                //���¼�¼ѡ�е����ڵĸ���ֵ
                _year = System.Convert.ToString(e.Start.Year);
                _month = System.Convert.ToString(e.Start.Month);
                _day = System.Convert.ToString(e.Start.Day);
                _date = _year + "-" + _month + "-" + _day;
                if (DateTextNumber == 1)
                {
                    this.tbxOperationDate.Text = _date;
                }
                //���ѡ�����ھ��Զ�����MonthCalendar�ؼ�
                monthCalendar1.Hide();
            }
        }

        private void CaculateFee()
        {
            if (this.dataGridView1.Rows.Count > 0)
            {
                double totalServiceFee = 0, totalInterestFee = 0, totalAmount = 0;
                double totalOverdueFee = 0, totalReturnFee = 0;
                for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
                {
                    try
                    {
                        totalAmount += Convert.ToDouble(this.dataGridView1.Rows[i].Cells["Amount"].Value);
                        totalServiceFee += Convert.ToDouble(this.dataGridView1.Rows[i].Cells["ServiceFee"].Value);
                        totalInterestFee += Convert.ToDouble(this.dataGridView1.Rows[i].Cells["InterestFee"].Value);
                        totalOverdueFee += Convert.ToDouble(this.dataGridView1.Rows[i].Cells["OverdueFee"].Value);
                        totalReturnFee += Convert.ToDouble(this.dataGridView1.Rows[i].Cells["ReturnFee"].Value);
                    }
                    catch
                    {
                        MessageBox.Show("�����������","��ʾ��Ϣ");
                    }
                }

                double paidFee = totalAmount + totalInterestFee + totalOverdueFee - totalReturnFee;
                this.tbxAmount.Text = totalAmount.ToString();
                this.tbxServiceFee.Text = totalServiceFee.ToString();
                this.tbxInterestFee.Text = totalInterestFee.ToString();
                this.tbxOverdueFee.Text = totalOverdueFee.ToString();
                this.tbxReturnFee.Text = totalReturnFee.ToString();
                this.tbxPaidFee.Text = paidFee.ToString();
            }
            
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            CaculateFee();
        }



   }
}