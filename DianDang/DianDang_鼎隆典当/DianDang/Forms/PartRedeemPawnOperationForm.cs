using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using SubSonic;
using System.Transactions;

namespace DianDang
{
    public partial class PartRedeemPawnOperationForm : DockContent
    {
        private string OldValue = "";

        bool isLoading = false;

        public int LoadingStatus = 0;

        public PartRedeemPawnOperationForm(int iTicketID)
        {
            m_TicketID = iTicketID;
            LoadingStatus = 1;
            InitializeComponent();
            InitGridTableColumn();
            LoadOperationNumber();
            LoadTicketNumber();

            DateTime currentDate = DateTime.Now;
            string strDate = currentDate.Year.ToString() + "-" + currentDate.Month.ToString() + "-" + currentDate.Day.ToString();
            this.tbxOperationDate.Text = strDate;
            m_TicketID = iTicketID;
            LoadTicketInfo();
            LoadingStatus = 0;

            DateTime dt = DateTime.Now;
            this.tbxStartDate.Text = dt.Year.ToString() + "-" + dt.Month.ToString() + "-" + dt.Day.ToString();
            this.tbxPawnTerm.Text = "1";
            dt = dt.AddMonths(1);
            this.tbxEndDate.Text = dt.Year.ToString() + "-" + dt.Month.ToString() + "-" + dt.Day.ToString();
            this.cbxTermType.SelectedIndex = 0;
            LoadNewTicketInfo();
            InitParentClass();
        }

        private void LoadTicketNumber()
        {
            DDGeneralParemeter newParam = new DDGeneralParemeter("ParamName", "CurrentTicketNumber");
            this.tbxTicketNumber.Text = newParam.ParamValue.Trim();
        }
        private void UpdateTicketNumber()
        {
            string iTicketNumber = this.tbxTicketNumber.Text;
            DDGeneralParemeter newParam = new DDGeneralParemeter("ParamName", "CurrentTicketNumber");

            if (this.tbxTicketNumber.Text.Length > 9)
            {
                newParam.ParamValue = CaculateString(newParam.ParamValue.Trim());
            }
            else
            {
                for (int i = 0; i < 9 - tbxTicketNumber.Text.Length; i++)
                {
                    iTicketNumber = "0" + iTicketNumber;
                }
                newParam.ParamValue = CaculateString(iTicketNumber);
            }
            newParam.Save();
        }
        private void InitParentClass()
        {
            Query query = new Query(DDPawnageClass.Schema);
            query.AddWhere("ParentID", 0);
            DataTable dt = query.ExecuteDataSet().Tables[0];

            if (dt.Rows.Count > 0)
            {
                this.cbxParentClass.DisplayMember = "ClassName";
                this.cbxParentClass.ValueMember = "ClassID";
                this.cbxParentClass.DataSource = dt;
            }
        }

        private void InitChildClass(int intParentID)
        {
            Query query = new Query(DDPawnageClass.Schema);
            query.AddWhere("ParentID", intParentID);
            DataTable dt = query.ExecuteDataSet().Tables[0];

            if (dt.Rows.Count > 0)
            {
                this.cbxChildClass.DisplayMember = "ClassName";
                this.cbxChildClass.ValueMember = "ClassID";
                this.cbxChildClass.DataSource = dt;
            }
        }

        private DateTime m_OperationDate;
        private DateTime m_StartDate;
        private DateTime m_EndDate;

        private double CaculateOverdueFee(double amount, double feeRate, double interestRate)
        {
            double overdueFee = 0;
            TimeSpan overdueTimeSpan = m_OperationDate.Subtract(m_EndDate);
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
            m_GridTable.Columns.Add("ReturnInterestFee", typeof(System.String));
            m_GridTable.Columns.Add("OverdueFee", typeof(System.String));
            m_GridTable.Columns.Add("PaidInterestFee", typeof(System.String));
            m_GridTable.Columns.Add("ChargedServiceFee", typeof(System.String));
            m_GridTable.Columns.Add("ChargedInterestFee", typeof(System.String));
            m_GridTable.Columns.Add("PawnageID", typeof(System.Int32));
            m_GridTable.Columns.Add("ServiceFeeRate", typeof(System.String));
            m_GridTable.Columns.Add("InterestFeeRate", typeof(System.String));
        }

        private int m_CustomerID = 0;

        private void LoadTicketInfo()
        {
            this.m_GridTable.Rows.Clear();
            
            DDPawnTicket newTicket = new DDPawnTicket("TicketID", m_TicketID);
            m_CustomerID = Convert.ToInt32(newTicket.CustomerID);

            Query queryOperations = new Query(DDOperation.Schema);
            queryOperations.AddWhere("TicketID", m_TicketID);
            queryOperations.AddWhere("OperationType", Comparison.In, new int[] { 1, 3 });
            queryOperations.AddWhere("OperationType", Comparison.NotEquals, 6);
            queryOperations.AddWhere("NextOperationID", 0);

            DataTable dtOperations = queryOperations.ExecuteDataSet().Tables[0];

            m_StartDate = Convert.ToDateTime(newTicket.StartDate);
            m_EndDate = Convert.ToDateTime(newTicket.EndDate);
            try
            {
                m_OperationDate = Convert.ToDateTime(this.tbxOperationDate.Text.Trim());
            }
            catch
            {
                MessageBox.Show("请输入正确的日期", "提示信息");
            }

            if (dtOperations.Rows.Count > 0)
            {
                for (int i = 0; i < dtOperations.Rows.Count; i++)
                {

                    double amount = 0;
                    double serviceFee = 0, interestFee = 0, paidInterestFee = 0;
                    double chargedServiceFee = 0, chargedInterestFee = 0;
                    double singleChargedServiceFee = 0, singleChargedInterestFee = 0;
                    double returnServiceFee = 0, returnInterestFee = 0;
                    double singleReturnServiceFee = 0, singleReturnInterestFee = 0;
                    double serviceFeeRate = 0, interestFeeRate = 0;

                    double overdueFee = 0;
                    amount = Convert.ToDouble(dtOperations.Rows[i]["Amount"]);
                    #region 原先错误的算法
                    /*
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
                    //overdueFee = CaculateOverdueFee(amount, Convert.ToDouble(pawnageInfo.FeeRate), Convert.ToDouble(pawnageInfo.InterestRate))
                    //returnFee = serviceFee + interestFee - CaculatePaidFee(amount, Convert.ToDouble(pawnageInfo.FeeRate), Convert.ToDouble(pawnageInfo.InterestRate));
                    //returnFee = CaculateReturnFee(amount, Convert.ToDouble(pawnageInfo.FeeRate), Convert.ToDouble(pawnageInfo.InterestRate));
                    if (returnFee < 0)
                    {
                        returnFee = 0;
                    }
                    totalOverdueFee += overdueFee;
                    totalReturnFee += returnFee;
                     */
                    #endregion

                    DDPawnageInfo pawnageInfo = new DDPawnageInfo("PawnageID", Convert.ToInt32(dtOperations.Rows[i]["PawnageID"]));

                    #region 费用计算
                    //判断当票状态
                    int PawnTicketStatus = 0;  //0:正好，1:提前，2:过期

                    //DDPawnTicket theTicket = new DDPawnTicket("TicketID", m_TicketID);
                    if (m_OperationDate <= DateTime.Parse(dtOperations.Rows[i]["EndDate"].ToString()))
                    {
                        PawnSpan Span = DianDangFunction.GetPawnSpan(m_OperationDate, DateTime.Parse(dtOperations.Rows[i]["StartDate"].ToString()), FeeType.ServiceFee, PeridType.Within);
                        PawnSpan LastSpan = DianDangFunction.GetPawnSpan(DateTime.Parse(dtOperations.Rows[i]["StartDate"].ToString()), DateTime.Parse(dtOperations.Rows[i]["EndDate"].ToString()), FeeType.ServiceFee, PeridType.Within);
                        if (Span.Months == LastSpan.Months && Span.CountDays == LastSpan.CountDays && m_OperationDate >= DateTime.Parse(dtOperations.Rows[i]["StartDate"].ToString()))
                        {
                            PawnTicketStatus = 0;
                        }
                        else PawnTicketStatus = 1;
                    }
                    else PawnTicketStatus = 2;


                    if (DateTime.Parse(newTicket.StartDate) == m_OperationDate)//当天建当，当天还
                    {
                        int ifReturn = 0;

                        double InOperationServiceFee = 0, InOperationInterestFee = 0;
                        double InOPerationChargedServiceFee = 0, InOperationChargedInterestFee = 0;

                        //总计征收的费用
                        Query queryPaidOperation = new Query(DDOperation.Schema);
                        queryPaidOperation.AddWhere("PawnageID", pawnageInfo.PawnageID);
                        queryPaidOperation.AddWhere("OperationType", Comparison.NotEquals, 6);
                        queryPaidOperation.AddWhere("Deleted", 0);
                        DataTable dtPaidOperation = queryPaidOperation.ExecuteDataSet().Tables[0];
                        for (int j = 0; j < dtPaidOperation.Rows.Count; j++)
                        {
                            singleChargedServiceFee = Convert.ToDouble(dtPaidOperation.Rows[j]["ServiceFee"].ToString());
                            singleChargedServiceFee = DianDangFunction.myRound(singleChargedServiceFee, MainForm.AmountAccuracy);
                            chargedServiceFee += singleChargedServiceFee;
                            singleChargedInterestFee = Convert.ToDouble(dtPaidOperation.Rows[j]["InterestFee"].ToString());
                            singleChargedInterestFee = DianDangFunction.myRound(singleChargedInterestFee, MainForm.AmountAccuracy);
                            chargedInterestFee += singleChargedInterestFee;
                        }

                        //计算争议的服务费
                        Query queryInOperation = new Query(DDOperation.Schema);
                        queryInOperation.AddBetweenAnd("EndDate", m_OperationDate, new DateTime(9998, 12, 31));
                        queryInOperation.AddBetweenAnd("StartDate", new DateTime(1755, 1, 1), m_OperationDate);
                        queryInOperation.AddWhere("PawnageID", pawnageInfo.PawnageID);
                        queryInOperation.AddWhere("OperationType", Comparison.NotEquals, 6);
                        queryInOperation.AddWhere("Deleted", 0);
                        DataTable dtInOperation = queryInOperation.ExecuteDataSet().Tables[0];
                        if (dtInOperation.Rows.Count > 0)
                        {

                            InOPerationChargedServiceFee = Convert.ToDouble(dtInOperation.Rows[0]["ServiceFee"].ToString());

                            PawnSpan OperationServiceSpan = DianDangFunction.GetPawnSpan(DateTime.Parse(dtInOperation.Rows[0]["StartDate"].ToString()), DateTime.Parse(dtInOperation.Rows[0]["EndDate"].ToString()), FeeType.ServiceFee, PeridType.Within);
                            PawnSpan ServiceSpan = DianDangFunction.GetPawnSpan(DateTime.Parse(dtInOperation.Rows[0]["StartDate"].ToString()), m_OperationDate, FeeType.ServiceFee, PeridType.Within);
                            double DayFeeRate = InOPerationChargedServiceFee / OperationServiceSpan.CountDaysAll / amount * 100;

                            if (ServiceSpan.CountDaysAll > OperationServiceSpan.CountDaysAll)
                            {
                                ServiceSpan.CountDaysAll = OperationServiceSpan.CountDaysAll;
                            }
                            InOperationServiceFee = (ServiceSpan.CountDaysAll) * amount * DayFeeRate / 100;
                            InOperationServiceFee = DianDangFunction.myRound(InOperationServiceFee, MainForm.AmountAccuracy);

                        }

                        //计算肯定要返还的费用
                        Query queryReturnOperation = new Query(DDOperation.Schema);
                        queryReturnOperation.AddBetweenAnd("StartDate", m_OperationDate.AddDays(1), new DateTime(9998, 12, 31));
                        queryReturnOperation.AddWhere("PawnageID", pawnageInfo.PawnageID);
                        queryReturnOperation.AddWhere("OperationType", Comparison.NotEquals, 6);
                        queryReturnOperation.AddWhere("Deleted", 0);
                        DataTable dtReturnOperation = queryReturnOperation.ExecuteDataSet().Tables[0];
                        for (int j = 0; j < dtReturnOperation.Rows.Count; j++)
                        {
                            //计算争议的利息费，因为本次收取的利息为上月利息，即为争议利息
                            if (j == 0 && dtInOperation.Rows.Count > 0)
                            {
                                InOperationChargedInterestFee = Convert.ToDouble(dtReturnOperation.Rows[0]["InterestFee"].ToString());
                                PawnSpan OperationInterestSpan = DianDangFunction.GetPawnSpan(DateTime.Parse(dtInOperation.Rows[0]["StartDate"].ToString()), DateTime.Parse(dtInOperation.Rows[0]["EndDate"].ToString()), FeeType.InterestFee, PeridType.Within);
                                PawnSpan InterestSpan = DianDangFunction.GetPawnSpan(DateTime.Parse(dtInOperation.Rows[0]["StartDate"].ToString()), m_OperationDate, FeeType.InterestFee, PeridType.Within);

                                double DayInterestFeeRate = InOperationChargedInterestFee / OperationInterestSpan.CountDaysAll / amount * 100;
                                if (InterestSpan.CountDaysAll > OperationInterestSpan.CountDaysAll)
                                {
                                    InterestSpan.CountDaysAll = OperationInterestSpan.CountDaysAll;
                                }
                                InOperationInterestFee = (InterestSpan.CountDaysAll) * amount * DayInterestFeeRate / 100;
                                InOperationInterestFee = DianDangFunction.myRound(InOperationInterestFee, MainForm.AmountAccuracy);
                            }


                            ifReturn++;
                            singleReturnServiceFee = Convert.ToDouble(dtReturnOperation.Rows[j]["ServiceFee"].ToString());
                            singleReturnServiceFee = DianDangFunction.myRound(singleReturnServiceFee, MainForm.AmountAccuracy);
                            returnServiceFee += singleReturnServiceFee;
                            if (j != 0 || dtInOperation.Rows.Count == 0)
                            {
                                singleReturnInterestFee = Convert.ToDouble(dtReturnOperation.Rows[j]["InterestFee"].ToString());
                                singleReturnInterestFee = DianDangFunction.myRound(singleReturnInterestFee, MainForm.AmountAccuracy);
                                returnInterestFee += singleReturnInterestFee;
                            }

                        }





                        if (m_OperationDate > DateTime.Parse(dtOperations.Rows[i]["StartDate"].ToString())) //操作日期大于最后一次操作开始日期，则收取利息
                        {
                            PawnSpan InterestSpan = DianDangFunction.GetPawnSpan(DateTime.Parse(dtOperations.Rows[i]["StartDate"].ToString()), m_OperationDate, FeeType.InterestFee, PeridType.Within);
                            paidInterestFee = 0;
                            paidInterestFee = (InterestSpan.Months + InterestSpan.Days / 30) * Convert.ToDouble(dtOperations.Rows[i]["InterestFeeRate"].ToString()) * amount / 100;
                            paidInterestFee = DianDangFunction.myRound(paidInterestFee, MainForm.AmountAccuracy);
                        }





                        returnServiceFee = returnServiceFee + InOPerationChargedServiceFee - InOperationServiceFee;
                        returnServiceFee = DianDangFunction.myRound(returnServiceFee, MainForm.AmountAccuracy);
                        returnInterestFee = returnInterestFee + InOperationChargedInterestFee - InOperationInterestFee;
                        returnInterestFee = DianDangFunction.myRound(returnInterestFee, MainForm.AmountAccuracy);


                        serviceFee = chargedServiceFee - returnServiceFee;
                        serviceFee = DianDangFunction.myRound(serviceFee, MainForm.AmountAccuracy);
                        interestFee = chargedInterestFee + paidInterestFee - returnInterestFee;
                        interestFee = DianDangFunction.myRound(interestFee, MainForm.AmountAccuracy);


                    }

                    else
                    {

                        if (PawnTicketStatus == 0)  //收取上期服务费
                        {
                            //计算上期利息
                            PawnSpan LastInterestSpan = DianDangFunction.GetPawnSpan(DateTime.Parse(dtOperations.Rows[i]["StartDate"].ToString()), DateTime.Parse(dtOperations.Rows[i]["EndDate"].ToString()), FeeType.InterestFee, PeridType.Within);
                            paidInterestFee = (LastInterestSpan.Months + LastInterestSpan.CountDays / 30) * amount * Convert.ToDouble(dtOperations.Rows[i]["InterestFeeRate"].ToString()) / 100;
                            paidInterestFee = DianDangFunction.myRound(paidInterestFee, MainForm.AmountAccuracy);

                            //计算已经付出的服务费和利息
                            Query queryPaidOperation = new Query(DDOperation.Schema);
                            queryPaidOperation.AddWhere("TicketID", m_TicketID);
                            queryPaidOperation.AddWhere("PawnageID", pawnageInfo.PawnageID);
                            queryPaidOperation.AddWhere("OperationType", Comparison.NotEquals, 6);
                            queryPaidOperation.AddWhere("Deleted", 0);
                            DataTable dtPaidOperation = queryPaidOperation.ExecuteDataSet().Tables[0];
                            if (dtPaidOperation.Rows.Count > 0)
                            {
                                for (int j = 0; j < dtPaidOperation.Rows.Count; j++)
                                {
                                    singleChargedServiceFee = Convert.ToDouble(dtPaidOperation.Rows[j]["ServiceFee"].ToString());
                                    singleChargedServiceFee = DianDangFunction.myRound(singleChargedServiceFee, MainForm.AmountAccuracy);
                                    chargedServiceFee += singleChargedServiceFee;
                                    singleChargedInterestFee = Convert.ToDouble(dtPaidOperation.Rows[j]["InterestFee"].ToString());
                                    singleChargedInterestFee = DianDangFunction.myRound(singleChargedInterestFee, MainForm.AmountAccuracy);
                                    chargedInterestFee += singleChargedInterestFee;
                                }

                            }

                            //当品应收的利息等于之前收过的利息+上期利息
                            interestFee = chargedInterestFee + paidInterestFee;
                            serviceFee = chargedServiceFee;
                        }
                        else if (PawnTicketStatus == 2)  //过期状态，收取
                        {
                            //计算上期利息+过期利息，计算过期服务费
                            PawnSpan LastInterestSpan = DianDangFunction.GetPawnSpan(DateTime.Parse(dtOperations.Rows[i]["StartDate"].ToString()), m_OperationDate, FeeType.InterestFee, PeridType.Overdue);
                            paidInterestFee = (LastInterestSpan.Months + LastInterestSpan.CountDays / 30) * amount * Convert.ToDouble(dtOperations.Rows[i]["InterestFeeRate"].ToString()) / 100;
                            paidInterestFee = DianDangFunction.myRound(paidInterestFee, MainForm.AmountAccuracy);

                            PawnSpan OverdueSpan = DianDangFunction.GetPawnSpan(DateTime.Parse(dtOperations.Rows[i]["EndDate"].ToString()), m_OperationDate, FeeType.ServiceFee, PeridType.Overdue);
                            overdueFee = (OverdueSpan.Months + OverdueSpan.CountDays / 30) * amount * Convert.ToDouble(dtOperations.Rows[i]["ServiceFeeRate"].ToString()) / 100;
                            overdueFee = DianDangFunction.myRound(overdueFee, MainForm.AmountAccuracy);


                            //计算已经付出的服务费和利息
                            Query queryPaidOperation = new Query(DDOperation.Schema);
                            queryPaidOperation.AddWhere("TicketID", m_TicketID);
                            queryPaidOperation.AddWhere("PawnageID", pawnageInfo.PawnageID);
                            queryPaidOperation.AddWhere("OperationType", Comparison.NotEquals, 6);
                            queryPaidOperation.AddWhere("Deleted", 0);
                            DataTable dtPaidOperation = queryPaidOperation.ExecuteDataSet().Tables[0];
                            if (dtPaidOperation.Rows.Count > 0)
                            {
                                for (int j = 0; j < dtPaidOperation.Rows.Count; j++)
                                {
                                    singleChargedServiceFee = Convert.ToDouble(dtPaidOperation.Rows[j]["ServiceFee"].ToString());
                                    singleChargedServiceFee = DianDangFunction.myRound(singleChargedServiceFee, MainForm.AmountAccuracy);
                                    chargedServiceFee += singleChargedServiceFee;
                                    singleChargedInterestFee = Convert.ToDouble(dtPaidOperation.Rows[j]["InterestFee"].ToString());
                                    singleChargedInterestFee = DianDangFunction.myRound(singleChargedInterestFee, MainForm.AmountAccuracy);
                                    chargedInterestFee += singleChargedInterestFee;
                                }

                            }

                            //当品应收的利息等于之前收过的利息+应付利息
                            interestFee = chargedInterestFee + paidInterestFee;
                            //服务费应该等于所有已经收取的服务费+过期服务费
                            serviceFee = chargedServiceFee + overdueFee;
                        }
                        else if (PawnTicketStatus == 1)  //提前赎当
                        {
                            int ifReturn = 0;

                            double InOperationServiceFee = 0, InOperationInterestFee = 0;
                            double InOPerationChargedServiceFee = 0, InOperationChargedInterestFee = 0;

                            //总计征收的费用
                            Query queryPaidOperation = new Query(DDOperation.Schema);
                            queryPaidOperation.AddWhere("PawnageID", pawnageInfo.PawnageID);
                            queryPaidOperation.AddWhere("OperationType", Comparison.NotEquals, 6);
                            queryPaidOperation.AddWhere("Deleted", 0);
                            DataTable dtPaidOperation = queryPaidOperation.ExecuteDataSet().Tables[0];
                            for (int j = 0; j < dtPaidOperation.Rows.Count; j++)
                            {
                                singleChargedServiceFee = Convert.ToDouble(dtPaidOperation.Rows[j]["ServiceFee"].ToString());
                                singleChargedServiceFee = DianDangFunction.myRound(singleChargedServiceFee, MainForm.AmountAccuracy);
                                chargedServiceFee += singleChargedServiceFee;
                                singleChargedInterestFee = Convert.ToDouble(dtPaidOperation.Rows[j]["InterestFee"].ToString());
                                singleChargedInterestFee = DianDangFunction.myRound(singleChargedInterestFee, MainForm.AmountAccuracy);
                                chargedInterestFee += singleChargedInterestFee;
                            }

                            //计算争议的服务费
                            Query queryInOperation = new Query(DDOperation.Schema);
                            queryInOperation.AddBetweenAnd("EndDate", m_OperationDate.AddDays(1), new DateTime(9998, 12, 31));
                            queryInOperation.AddBetweenAnd("StartDate", new DateTime(1755, 1, 1), m_OperationDate.AddDays(-1));
                            queryInOperation.AddWhere("PawnageID", pawnageInfo.PawnageID);
                            queryInOperation.AddWhere("OperationType", Comparison.NotEquals, 6);
                            queryInOperation.AddWhere("Deleted", 0);
                            DataTable dtInOperation = queryInOperation.ExecuteDataSet().Tables[0];
                            if (dtInOperation.Rows.Count > 0)
                            {

                                InOPerationChargedServiceFee = Convert.ToDouble(dtInOperation.Rows[0]["ServiceFee"].ToString());

                                PawnSpan OperationServiceSpan = DianDangFunction.GetPawnSpan(DateTime.Parse(dtInOperation.Rows[0]["StartDate"].ToString()), DateTime.Parse(dtInOperation.Rows[0]["EndDate"].ToString()), FeeType.ServiceFee, PeridType.Within);
                                PawnSpan ServiceSpan = DianDangFunction.GetPawnSpan(DateTime.Parse(dtInOperation.Rows[0]["StartDate"].ToString()), m_OperationDate, FeeType.ServiceFee, PeridType.Within);
                                double DayFeeRate = InOPerationChargedServiceFee / OperationServiceSpan.CountDaysAll / amount * 100;

                                if (ServiceSpan.CountDaysAll > OperationServiceSpan.CountDaysAll)
                                {
                                    ServiceSpan.CountDaysAll = OperationServiceSpan.CountDaysAll;
                                }
                                InOperationServiceFee = (ServiceSpan.CountDaysAll) * amount * DayFeeRate / 100;
                                InOperationServiceFee = DianDangFunction.myRound(InOperationServiceFee, MainForm.AmountAccuracy);

                            }

                            //计算肯定要返还的费用
                            Query queryReturnOperation = new Query(DDOperation.Schema);
                            queryReturnOperation.AddBetweenAnd("StartDate", m_OperationDate, new DateTime(9998, 12, 31));
                            queryReturnOperation.AddWhere("PawnageID", pawnageInfo.PawnageID);
                            queryReturnOperation.AddWhere("OperationType", Comparison.NotEquals, 6);
                            queryReturnOperation.AddWhere("Deleted", 0);
                            DataTable dtReturnOperation = queryReturnOperation.ExecuteDataSet().Tables[0];
                            for (int j = 0; j < dtReturnOperation.Rows.Count; j++)
                            {
                                //计算争议的利息费，因为本次收取的利息为上月利息，即为争议利息
                                if (j == 0 && dtInOperation.Rows.Count > 0)
                                {
                                    InOperationChargedInterestFee = Convert.ToDouble(dtReturnOperation.Rows[0]["InterestFee"].ToString());
                                    PawnSpan OperationInterestSpan = DianDangFunction.GetPawnSpan(DateTime.Parse(dtInOperation.Rows[0]["StartDate"].ToString()), DateTime.Parse(dtInOperation.Rows[0]["EndDate"].ToString()), FeeType.InterestFee, PeridType.Within);
                                    PawnSpan InterestSpan = DianDangFunction.GetPawnSpan(DateTime.Parse(dtInOperation.Rows[0]["StartDate"].ToString()), m_OperationDate, FeeType.InterestFee, PeridType.Within);

                                    double DayInterestFeeRate = InOperationChargedInterestFee / OperationInterestSpan.CountDaysAll / amount * 100;
                                    if (InterestSpan.CountDaysAll > OperationInterestSpan.CountDaysAll)
                                    {
                                        InterestSpan.CountDaysAll = OperationInterestSpan.CountDaysAll;
                                    }
                                    InOperationInterestFee = (InterestSpan.CountDaysAll) * amount * DayInterestFeeRate / 100;
                                    InOperationInterestFee = DianDangFunction.myRound(InOperationInterestFee, MainForm.AmountAccuracy);
                                }


                                ifReturn++;
                                singleReturnServiceFee = Convert.ToDouble(dtReturnOperation.Rows[j]["ServiceFee"].ToString());
                                singleReturnServiceFee = DianDangFunction.myRound(singleReturnServiceFee, MainForm.AmountAccuracy);
                                returnServiceFee += singleReturnServiceFee;
                                if (j != 0 || dtInOperation.Rows.Count == 0)
                                {
                                    singleReturnInterestFee = Convert.ToDouble(dtReturnOperation.Rows[j]["InterestFee"].ToString());
                                    singleReturnInterestFee = DianDangFunction.myRound(singleReturnInterestFee, MainForm.AmountAccuracy);
                                    returnInterestFee += singleReturnInterestFee;
                                }

                            }




                            if (m_OperationDate > DateTime.Parse(dtOperations.Rows[i]["StartDate"].ToString())) //操作日期大于最后一次操作开始日期，则收取利息
                            {
                                PawnSpan InterestSpan = DianDangFunction.GetPawnSpan(DateTime.Parse(dtOperations.Rows[i]["StartDate"].ToString()), m_OperationDate, FeeType.InterestFee, PeridType.Within);
                                paidInterestFee = 0;
                                paidInterestFee = (InterestSpan.Months + InterestSpan.Days / 30) * Convert.ToDouble(dtOperations.Rows[i]["InterestFeeRate"].ToString()) * amount / 100;
                                paidInterestFee = DianDangFunction.myRound(paidInterestFee, MainForm.AmountAccuracy);
                            }





                            returnServiceFee = returnServiceFee + InOPerationChargedServiceFee - InOperationServiceFee;
                            returnServiceFee = DianDangFunction.myRound(returnServiceFee, MainForm.AmountAccuracy);
                            returnInterestFee = returnInterestFee + InOperationChargedInterestFee - InOperationInterestFee;
                            returnInterestFee = DianDangFunction.myRound(returnInterestFee, MainForm.AmountAccuracy);


                            serviceFee = chargedServiceFee - returnServiceFee;
                            serviceFee = DianDangFunction.myRound(serviceFee, MainForm.AmountAccuracy);
                            interestFee = chargedInterestFee + paidInterestFee - returnInterestFee;
                            interestFee = DianDangFunction.myRound(interestFee, MainForm.AmountAccuracy);

                        }

                    }


                    

                    //Query queryOperation = new Query(DDOperation.Schema);
                    //queryOperations.AddWhere("TicketID", m_TicketID);
                    
                    #endregion

                    serviceFeeRate = Convert.ToDouble(dtOperations.Rows[i]["ServiceFeeRate"].ToString());
                    interestFeeRate = Convert.ToDouble(dtOperations.Rows[i]["InterestFeeRate"].ToString());

                    interestFee = DianDangFunction.myRound(interestFee, MainForm.AmountAccuracy);
                    serviceFee = DianDangFunction.myRound(serviceFee, MainForm.AmountAccuracy);
                    amount = DianDangFunction.myRound(amount, MainForm.AmountAccuracy);
                    returnServiceFee = DianDangFunction.myRound(returnServiceFee, MainForm.AmountAccuracy);
                    returnInterestFee = DianDangFunction.myRound(returnInterestFee, MainForm.AmountAccuracy);
                    overdueFee = DianDangFunction.myRound(overdueFee, MainForm.AmountAccuracy);
                    paidInterestFee = DianDangFunction.myRound(paidInterestFee, MainForm.AmountAccuracy);
                    chargedServiceFee = DianDangFunction.myRound(chargedServiceFee, MainForm.AmountAccuracy);
                    chargedInterestFee = DianDangFunction.myRound(chargedInterestFee, MainForm.AmountAccuracy);


                    DataRow drow = m_GridTable.NewRow();
                    DDPawnageClass pawnageClass = new DDPawnageClass("ClassID",pawnageInfo.ClassID);
                    drow["ClassName"] = pawnageClass.ClassName;
                    drow["Amount"] = amount;
                    drow["ServiceFee"] = serviceFee;
                    drow["InterestFee"] = interestFee;
                    drow["ReturnFee"] = returnServiceFee;
                    drow["ReturnInterestFee"] = returnInterestFee;
                    drow["OverdueFee"] = overdueFee;
                    drow["PaidInterestFee"] = paidInterestFee;
                    drow["ChargedServiceFee"] = chargedServiceFee;
                    drow["ChargedInterestFee"] = chargedInterestFee;
                    drow["PawnageID"] = dtOperations.Rows[i]["PawnageID"].ToString();
                    drow["ServiceFeeRate"] = serviceFeeRate;
                    drow["InterestFeeRate"] = interestFeeRate;
                    m_GridTable.Rows.Add(drow);
                }
            }


            this.dataGridView1.DataSource = m_GridTable;
            CaculateDatagridAmount();

        }

        private ToChineseValue newChinese = new ToChineseValue();
        private void LoadNewTicketInfo()
        {
            isLoading = true;
            double serviceFee = 0;
            double serviceFeeRate = 0;
            double interestFeeRate = 0;
            double interestFee = 0;
            double amount = 0;
            PawnSpan ServiceSpan = DianDangFunction.GetPawnSpan(DateTime.Parse(tbxStartDate.Text), DateTime.Parse(tbxEndDate.Text), FeeType.ServiceFee, PeridType.Within);
            PawnSpan InterestSpan = DianDangFunction.GetPawnSpan(DateTime.Parse(tbxStartDate.Text), DateTime.Parse(tbxEndDate.Text), FeeType.InterestFee, PeridType.Within);


            Query query = new Query(DDOperation.Schema);
            query.AddWhere("TicketID", m_TicketID);
            query.AddWhere("OperationType", 1);
            DataTable dt = query.ExecuteDataSet().Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DDPawnageInfo pawnageInfo = new DDPawnageInfo("PawnageID", dt.Rows[i]["PawnageID"]);
                this.dataGridView2.Rows.Add(1);
                dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells["ParentClassID"].Value = pawnageInfo.ParentID;
                DDPawnageClass parentClass = new DDPawnageClass("ClassID", pawnageInfo.ParentID);
                dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells["ParentClass"].Value = parentClass.ClassName;
                dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells["ChildClassID"].Value = pawnageInfo.ClassID;
                DDPawnageClass childClass = new DDPawnageClass("ClassID", pawnageInfo.ClassID);
                dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells["ChildClass"].Value = childClass.ClassName;
                dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells["FeeRate"].Value = pawnageInfo.FeeRate;
                dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells["InterestRate"].Value = pawnageInfo.InterestRate;
                dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells["Description"].Value = pawnageInfo.Description;
                dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells["CountNumber"].Value = pawnageInfo.CountNumber;
                dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells["Weight"].Value = pawnageInfo.Weight;
                dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells["DiscountPercent"].Value = pawnageInfo.DiscountPercent;
                dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells["PawnageAmount"].Value = dt.Rows[i]["Amount"];
                dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells["Remark"].Value = pawnageInfo.Remark;
                dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells["PhotoPath"].Value = pawnageInfo.PhotoPath;

                amount = Convert.ToDouble(dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells["PawnageAmount"].Value.ToString());

                if (pawnageInfo.ParentID == 11)
                {
                    DDHouseInfo newHouseInfo = new DDHouseInfo("PawnageID", pawnageInfo.PawnageID);
                    dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells["HouseAddress"].Value = newHouseInfo.Address;
                    dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells["HouseCompactNumber"].Value = newHouseInfo.CompactNumber;
                    dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells["HouseArea"].Value = newHouseInfo.Area;
                    dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells["HouseRegisterDate"].Value = newHouseInfo.RegisterDate;
                    dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells["HouseInsuranceDate"].Value = newHouseInfo.InsuranceDate;
                    dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells["HouseNotarizationDate"].Value = newHouseInfo.NotarizationDate;
                }

                if (pawnageInfo.ParentID == 10)
                {
                    DDCarInfo newCarInfo = new DDCarInfo("PawnageID", pawnageInfo.PawnageID);
                    dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells["CarLicenceNumber"].Value = newCarInfo.LicenseNumber;
                    dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells["CarType"].Value = newCarInfo.CarType;
                    dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells["CarEngineNumber"].Value = newCarInfo.EngineNumber;
                    dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells["CarcaseNumber"].Value = newCarInfo.CarcaseNumber;
                    dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells["CarInsuranceDate"].Value = newCarInfo.InsuranceDate;
                    dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells["CarRoadtollDate"].Value = newCarInfo.RoadtollDate;
                    dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells["CarCheckDate"].Value = newCarInfo.CheckDate;
                }

                serviceFeeRate = Convert.ToDouble(dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells["FeeRate"].Value.ToString());
                serviceFee = (ServiceSpan.Months + ServiceSpan.CountDays / 30) * amount * serviceFeeRate / 100;
                serviceFee = DianDangFunction.myRound(serviceFee, MainForm.AmountAccuracy);
                interestFeeRate = Convert.ToDouble(dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells["InterestRate"].Value.ToString());
                interestFee = (InterestSpan.Months + InterestSpan.CountDays / 30) * amount * interestFeeRate / 100;
                interestFee = DianDangFunction.myRound(interestFee, MainForm.AmountAccuracy);
                dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells["NewServiceFee"].Value = serviceFee;
                dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells["NewInterestFee"].Value = interestFee;

            }

            CaculateAmount();
            isLoading = false;

        }

        private void CaculateDatagridAmount()
        {

            LoadingStatus = 1;
            double PaidFee = 0;
            double totalServiceFee = 0, totalInterestFee = 0, totalReturnFee = 0, totalOverdueFee = 0, totalPaidInterestFee = 0, totalAmount = 0, totalReturnInterestFee = 0;
            
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                try
                {
                    dataGridView1.Rows[i].Cells["ServiceFee"].Value = DianDangFunction.myRound(Convert.ToDouble(dataGridView1.Rows[i].Cells["ChargedServiceFee"].Value.ToString()) + Convert.ToDouble(dataGridView1.Rows[i].Cells["OverdueFee"].Value.ToString()) - Convert.ToDouble(dataGridView1.Rows[i].Cells["ReturnFee"].Value.ToString()), MainForm.AmountAccuracy);
                    dataGridView1.Rows[i].Cells["InterestFee"].Value = DianDangFunction.myRound(Convert.ToDouble(dataGridView1.Rows[i].Cells["ChargedInterestFee"].Value.ToString()) + Convert.ToDouble(dataGridView1.Rows[i].Cells["PaidInterestFee"].Value.ToString()) - Convert.ToDouble(dataGridView1.Rows[i].Cells["ReturnInterestFee"].Value.ToString()), MainForm.AmountAccuracy);

                    totalAmount += Convert.ToDouble(dataGridView1.Rows[i].Cells["Amount"].Value);
                    totalServiceFee += Convert.ToDouble(dataGridView1.Rows[i].Cells["ServiceFee"].Value);
                    totalInterestFee += Convert.ToDouble(dataGridView1.Rows[i].Cells["InterestFee"].Value);
                    totalReturnFee += Convert.ToDouble(dataGridView1.Rows[i].Cells["ReturnFee"].Value);
                    totalOverdueFee += Convert.ToDouble(dataGridView1.Rows[i].Cells["OverdueFee"].Value);
                    totalPaidInterestFee += Convert.ToDouble(dataGridView1.Rows[i].Cells["PaidInterestFee"].Value);
                    totalReturnInterestFee += Convert.ToDouble(dataGridView1.Rows[i].Cells["ReturnInterestFee"].Value);
                }
                catch
                {
                    MessageBox.Show("请输入正确的金额", "警告！！");
                }
            }

            totalAmount = DianDangFunction.myRound(totalAmount, MainForm.AmountAccuracy);
            totalServiceFee = DianDangFunction.myRound(totalServiceFee, MainForm.AmountAccuracy);
            totalInterestFee = DianDangFunction.myRound(totalInterestFee, MainForm.AmountAccuracy);
            totalReturnFee = DianDangFunction.myRound(totalReturnFee, MainForm.AmountAccuracy);
            totalOverdueFee = DianDangFunction.myRound(totalOverdueFee, MainForm.AmountAccuracy);
            totalPaidInterestFee = DianDangFunction.myRound(totalPaidInterestFee, MainForm.AmountAccuracy);
            totalReturnInterestFee = DianDangFunction.myRound(totalReturnInterestFee, MainForm.AmountAccuracy);

            this.tbxAmount.Text = totalAmount.ToString();
            this.tbxServiceFee.Text = totalServiceFee.ToString();
            this.tbxInterestFee.Text = totalInterestFee.ToString();
            this.tbxReturnFee.Text = totalReturnFee.ToString();
            this.tbxOverdueFee.Text = totalOverdueFee.ToString();
            PaidFee = (totalAmount + totalPaidInterestFee + totalOverdueFee - totalReturnFee - totalReturnInterestFee);
            if (PaidFee >= 0)
            {
                this.lblFinalString.Text = "客户应付：";
                this.tbxPaidFee.Text = DianDangFunction.myRound(PaidFee, MainForm.AmountAccuracy).ToString();
            }
            else
            {
                this.lblFinalString.Text = "典当行应付：";
                this.tbxPaidFee.Text = DianDangFunction.myRound((0 - PaidFee), MainForm.AmountAccuracy).ToString();
            }
            this.tbxPaidInterestFee.Text = totalPaidInterestFee.ToString();
            this.tbxReturnInterestFee.Text = totalReturnInterestFee.ToString();
            LoadingStatus = 0;
        }

        private void UpdateOperation(int iTicketID)
        {
            Query query = new Query(DDOperation.Schema);
            query.AddWhere("TicketID", iTicketID);
            query.AddWhere("OperationType", Comparison.In, new int[] { 1, 3 });
            query.AddWhere("NextOperationID", 0);
            query.AddWhere("OperationType", Comparison.NotEquals, 6);
            DataTable dt = query.ExecuteDataSet().Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                DDOperation oldOperation = new DDOperation("OperationID", Convert.ToInt32(dt.Rows[i]["OperationID"].ToString()));
                DDOperation newOperation = new DDOperation();
                int dataGridRow = 0;
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    if (dataGridView1.Rows[j].Cells["PawnageID"].Value.ToString() == oldOperation.PawnageID.ToString())
                    {
                        dataGridRow = j;
                    }
                }
                newOperation.TicketID = m_TicketID;
                newOperation.PawnageID = Convert.ToInt32(dataGridView1.Rows[dataGridRow].Cells["PawnageID"].Value.ToString());
                newOperation.OperationType = 2;
                newOperation.OperationNumber = m_OperationNumber;
                newOperation.ServiceFee = "0";
                newOperation.InterestFee = (Convert.ToDouble(dataGridView1.Rows[dataGridRow].Cells["PaidInterestFee"].Value.ToString()) - Convert.ToDouble(dataGridView1.Rows[dataGridRow].Cells["ReturnInterestFee"].Value.ToString())).ToString();
                newOperation.ReturnFee = dataGridView1.Rows[dataGridRow].Cells["ReturnFee"].Value.ToString();
                newOperation.OverdueFee = dataGridView1.Rows[dataGridRow].Cells["OverdueFee"].Value.ToString();
                newOperation.Amount = dataGridView1.Rows[dataGridRow].Cells["Amount"].Value.ToString();
                newOperation.ReckonAmount = "0";
                newOperation.ServiceFeeRate = dataGridView1.Rows[dataGridRow].Cells["ServiceFeeRate"].Value.ToString();
                newOperation.InterestFeeRate = dataGridView1.Rows[dataGridRow].Cells["InterestFeeRate"].Value.ToString();
                newOperation.OperationDate = tbxOperationDate.Text;
                DDUser newUser = new DDUser("AccountName", MainForm.AccountName);
                newOperation.OperaterName = newUser.UserName;
                newOperation.PreOperationID = oldOperation.OperationID;
                newOperation.NextOperationID = 0;
                newOperation.Save();

                oldOperation.NextOperationID = newOperation.OperationID;
                oldOperation.Save();

                DDPawnageInfo newInfo = new DDPawnageInfo("PawnageID", Convert.ToInt32(dataGridView1.Rows[dataGridRow].Cells["PawnageID"].Value.ToString()));
                newInfo.StatusID = 2;  //赎当
                newInfo.Save();
            }


            /*
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
            */
            //Query queryRenewOperations = new Query(DDOperation.Schema);
            //queryRenewOperations.AddWhere("TicketID", iTicketID);
            //queryRenewOperations.AddWhere("OperationType", 3);
            //DataTable dtRenewOperations = queryRenewOperations.ExecuteDataSet().Tables[0];
            ////操作：续当-〉赎当
            //for (int i = 0; i < dtRenewOperations.Rows.Count; i++)
            //{
            //    DDOperation newOperation = new DDOperation();
            //    preOperationID = Convert.ToInt32(dtRenewOperations.Rows[i]["OperationID"]);
            //    newOperation.TicketID = iTicketID;
            //    newOperation.PawnageID = Convert.ToInt32(dtRenewOperations.Rows[i]["PawnageID"]);
            //    newOperation.OperationType = 2;   //2 ：赎当
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
            ////MessageBox.Show("赎当处理成功！", "赎当");

        }

        private void UpdateTicketStatus(int iTicketID)
        {
            DDPawnTicket newTicket= new DDPawnTicket("TicketID", iTicketID);
            newTicket.StatusID = 2;
            newTicket.Save();
        }

        private void PrintReceipt()
        {
            ReceiptPrintViewForm frmReceiptPrintView = new ReceiptPrintViewForm(m_TicketID,m_OperationNumber);
            //frmReceiptPrintView.Show();
        }

        private int UpdatePawnTicket()
        {
            try
            {
                DDPawnTicket newTicket = new DDPawnTicket();
                newTicket.CustomerID = m_CustomerID;
                newTicket.TicketNumber = this.tbxTicketNumber.Text;
                newTicket.StartDate = this.tbxStartDate.Text;
                newTicket.EndDate = this.tbxEndDate.Text;
                newTicket.StatusID = 1;
                newTicket.Save();
                UpdateTicketNumber();
                m_TicketID = newTicket.TicketID;
                return newTicket.TicketID;
            }
            catch
            {
                MessageBox.Show(this, "当票信息更新失败，请检查数据库是否连接正确！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;
            }
        }

        private int UpdatePawages(int i)
        {

            DataGridViewRow dgr = dataGridView2.Rows[i];

            try
            {
                DDPawnageInfo newInfo = new DDPawnageInfo();
                newInfo.ClassID = Convert.ToInt32(dgr.Cells["ChildClassID"].Value);
                newInfo.ParentID = Convert.ToInt32(dgr.Cells["ParentClassID"].Value);
                newInfo.StatusID = 1; //新当
                newInfo.CountNumber = dgr.Cells["CountNumber"].Value.ToString();
                newInfo.Price = dgr.Cells["PawnageAmount"].Value.ToString();
                newInfo.Weight = dgr.Cells["Weight"].Value.ToString();
                newInfo.FeeRate = dgr.Cells["FeeRate"].Value.ToString();
                newInfo.InterestRate = dgr.Cells["InterestRate"].Value.ToString();
                newInfo.DiscountPercent = dgr.Cells["DiscountPercent"].Value.ToString();
                newInfo.Description = dgr.Cells["Description"].Value.ToString();
                newInfo.StartDate = this.tbxStartDate.Text;
                newInfo.EndDate = this.tbxEndDate.Text;
                newInfo.Remark = dgr.Cells["Remark"].Value.ToString();
                //newInfo.PhotoPath = dgr.Cells["PhotoPath"].Value.ToString();
                newInfo.Save();
                if (Convert.ToInt32(newInfo.ParentID) == 11)
                {
                    DDHouseInfo newHouseInfo = new DDHouseInfo();
                    newHouseInfo.Address = dgr.Cells["HouseAddress"].Value.ToString();
                    newHouseInfo.CompactNumber = dgr.Cells["HouseCompactNumber"].Value.ToString();
                    newHouseInfo.Area = dgr.Cells["HouseArea"].Value.ToString();
                    newHouseInfo.RegisterDate = dgr.Cells["HouseRegisterDate"].Value.ToString();
                    newHouseInfo.InsuranceDate = dgr.Cells["HouseInsuranceDate"].Value.ToString();
                    newHouseInfo.NotarizationDate = dgr.Cells["HouseNotarizationDate"].Value.ToString();
                    newHouseInfo.PawnageID = newInfo.PawnageID;
                    newHouseInfo.Save();
                }
                if (Convert.ToInt32(newInfo.ParentID) == 10)
                {
                    DDCarInfo newCarInfo = new DDCarInfo();
                    newCarInfo.LicenseNumber = dgr.Cells["CarLicenceNumber"].Value.ToString();
                    newCarInfo.CarType = dgr.Cells["CarType"].Value.ToString();
                    newCarInfo.EngineNumber = dgr.Cells["CarEngineNumber"].Value.ToString();
                    newCarInfo.CarcaseNumber = dgr.Cells["CarcaseNumber"].Value.ToString();
                    newCarInfo.InsuranceDate = dgr.Cells["CarInsuranceDate"].Value.ToString();
                    newCarInfo.RoadtollDate = dgr.Cells["CarRoadtollDate"].Value.ToString();
                    newCarInfo.CheckDate = dgr.Cells["CarCheckDate"].Value.ToString();
                    newCarInfo.PawnageID = newInfo.PawnageID;
                    newCarInfo.Save();
                }
                return newInfo.PawnageID;
            }
            catch
            {
                MessageBox.Show(this, "当品信息更新失败，请检查数据库是否连接正确！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;
            }
        }

        private void UpdateNewOperation()
        {
            //
            if (dataGridView1.Rows.Count > 0)
            {
                int iTicketID = UpdatePawnTicket();
                int iPawnageID = 0;
                double serviceFee = 0;

                for (int i = dataGridView2.Rows.Count - 1; i > -1; i--)
                {
                    DataGridViewRow dgr = dataGridView2.Rows[i];
                    try
                    {
                        iPawnageID = UpdatePawages(i);
                        DDOperation newOperation = new DDOperation();
                        newOperation.TicketID = iTicketID;
                        newOperation.PawnageID = iPawnageID;
                        newOperation.OperationType = 1;   //1 ：新当
                        newOperation.OperationNumber = m_OperationNumber;
                        //计算服务费
                        serviceFee = Convert.ToDouble(dgr.Cells["NewServiceFee"].Value);
                        serviceFee = DianDangFunction.myRound(serviceFee, MainForm.AmountAccuracy);
                        newOperation.ServiceFee = serviceFee.ToString();
                        //计算典当利息
                        //interestFee = Convert.ToDouble(dgr.Cells["Amount"].Value) * Convert.ToInt32(this.tbxPawnTerm.Text) * Convert.ToDouble(dgr.Cells["InterestRate"].Value) / 100;
                        //interestFee = DianDangFunction.myRound(interestFee, MainForm.AmountAccuracy);
                        //建当时，利息不收
                        //newOperation.InterestFee = interestFee.ToString();
                        newOperation.InterestFee = "0";
                        newOperation.ReturnFee = "0";
                        newOperation.OverdueFee = "0";
                        newOperation.Amount = dgr.Cells["PawnageAmount"].Value.ToString();
                        newOperation.ReckonAmount = "0";
                        newOperation.OperationDate = this.tbxStartDate.Text;
                        newOperation.StartDate = this.tbxStartDate.Text;
                        newOperation.EndDate = this.tbxEndDate.Text;
                        newOperation.ServiceFeeRate = dgr.Cells["FeeRate"].Value.ToString();
                        newOperation.InterestFeeRate = dgr.Cells["InterestRate"].Value.ToString();
                        //存入操作人
                        DDUser newOperater = new DDUser("AccountName", MainForm.AccountName);
                        newOperation.OperaterName = newOperater.UserName;
                        newOperation.PreOperationID = 0;
                        newOperation.NextOperationID = 0;
                        newOperation.Deleted = 0;
                        newOperation.Save();
                    }
                    catch
                    {
                        MessageBox.Show(this, "建当操作失败，请检查数据库是否连接正确！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

        }

        private void PrintPawnTicket()
        {
            PawnTicketPrintPreviewForm frmPawnTicketPrint = new PawnTicketPrintPreviewForm(this, m_TicketID, m_OperationNumber);
            //frmPawnTicketPrint.Show();
        }

        private DialogResult CheckTicketNumber()
        {
            if (this.dataGridView1.Rows.Count < 1)
            {
                MessageBox.Show("当品不能为空！", "提示信息");
                return DialogResult.No;
            }
            string strTicketNumber = this.tbxTicketNumber.Text.Trim();
            if (strTicketNumber.Length == 0)
            {
                MessageBox.Show(this, "当票号不能为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.tbxTicketNumber.Focus();
                return DialogResult.No;
            }
            Query query = new Query(DDPawnTicket.Schema);
            query.AddWhere("TicketNumber", strTicketNumber);
            query.AddWhere("StatusID", Comparison.NotEquals, 6);
            DataTable dt = query.ExecuteDataSet().Tables[0];
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show(this, "该当票号已经存在，请重新输入！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.tbxTicketNumber.Focus();
                return DialogResult.No;
            }
            return DialogResult.OK;

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DialogResult dataCheckDlg = CheckTicketNumber();
            if (dataCheckDlg != DialogResult.OK)
            {
                return;
            }

            using (TransactionScope Scope = new TransactionScope())
            {
                try
                {
                    /*赎当操作*/
                    LoadOperationNumber();
                    UpdateOperation(m_TicketID);
                    UpdateTicketStatus(m_TicketID);
                    DDPrintParam newParam = new DDPrintParam("PrintOption", 5);
                    if (newParam.OptionValue == 1)
                    {
                        PrintReceipt();
                    }


                    /*建当操作*/
                    UpdateOperationNumber();
                    LoadOperationNumber();
                    UpdateNewOperation();

                    newParam = new DDPrintParam("PrintOption", 1);
                    if (newParam.OptionValue == 1)
                    {
                        PrintPawnTicket();
                    }

                    newParam = new DDPrintParam("PrintOption", 2);
                    if (newParam.OptionValue == 1)
                    {
                        PrintReceipt();
                    }

                    UpdateOperationNumber();
                    LoadOperationNumber();
                    this.btnPrint.Enabled = false;
                    Scope.Complete();
                    MessageBox.Show(this, "部分赎回操作成功");
                }
                catch
                {
                    Scope.Dispose();
                    MessageBox.Show(this, "操作失败，请检查数据库是否连接正确！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }


            
        }

        private int m_DateTextboxNumber=0;

        private void tbxOperationDate_Click(object sender, EventArgs e)
        {
            this.monthCalendar1.Visible = true;
            m_DateTextboxNumber = 1;
        }

        private void tbxOperationDate_TextChanged(object sender, EventArgs e)
        {
            LoadingStatus = 1;
            this.monthCalendar1.Hide();
            LoadTicketInfo();
            LoadingStatus = 0;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            //将用户在MonthCalendar上点击的坐标转换程用户区坐标，并根据坐标获得点击类型
            string s = System.Convert.ToString(monthCalendar1.HitTest(this.PointToClient(MonthCalendar.MousePosition)).HitArea);

            string _year, _month, _day, _date;
            //如果用户点中了日期则对文本框进行赋值并退出
            if (s.Equals("Nowhere"))
            {
                //以下记录选中的日期的各个值
                _year = System.Convert.ToString(e.Start.Year);
                _month = System.Convert.ToString(e.Start.Month);
                _day = System.Convert.ToString(e.Start.Day);
                _date = _year + "-" + _month + "-" + _day;
                switch(m_DateTextboxNumber)
                {
                    case 1:
                        this.tbxOperationDate.Text = _date;
                        break;
                    case 2:
                        this.tbxStartDate.Text = _date;
                        break;
                    default:
                        break;
                }
                //如果选中日期就自动隐藏MonthCalendar控件
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
                        MessageBox.Show("数据输入错误！","提示信息");
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

        void dataGridView1_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                try
                {
                    OldValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }
                catch
                {
                }
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (LoadingStatus == 0 && e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                try
                {
                    Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    CaculateDatagridAmount();
                }
                catch
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = OldValue.ToString();
                    MessageBox.Show("请输入正确的金额", "提示信息");
                }
            }
        }

        private void cbxParentClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            int intParentID = Convert.ToInt32(this.cbxParentClass.SelectedValue);
            InitChildClass(intParentID);
            GetRateByClass(intParentID);
        }

        private double m_MaxFeeRate = 0;
        private double m_MinFeeRate = 0;
        private void GetRateByClass(int intClassID)
        {
            DDPawnageClass newClass = new DDPawnageClass("ClassID", intClassID);
            this.tbxFeeRate.Text = newClass.MonthFeeRate;
            m_MaxFeeRate = Convert.ToDouble(newClass.MaxFeeRate);
            m_MinFeeRate = Convert.ToDouble(newClass.MinFeeRate);
            this.tbxInterestRate.Text = newClass.InterestRate;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                if (this.dataGridView2.Rows[i].Cells["Operation"].Value != null && this.dataGridView2.Rows[i].Cells["Operation"].Value.ToString() == "1")
                {
                    dataGridView2.Rows[i].Selected = true;
                }
                else
                {
                    dataGridView2.Rows[i].Selected = false;
                }
            }
            if (dataGridView2.SelectedRows.Count > 0)
            {
                for (int i = dataGridView2.SelectedRows.Count - 1; i > -1; i--)
                {
                    int rowIndex = dataGridView2.SelectedRows[i].Index;
                    DataGridViewRow dgr = dataGridView2.Rows[rowIndex];
                    dataGridView2.Rows.Remove(dgr);
                }
                CaculateAmount();
            }
            else
            {
                MessageBox.Show(this, "请选择需要删除的数据！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CaculateAmount()
        {

            double amount = 0, totalAmount = 0, serviceFee = 0, totalServiceFee = 0, interestFee = 0, totalInterestFee = 0, paidFee = 0;
            for (int i = dataGridView2.Rows.Count - 1; i > -1; i--)
            {
                amount = Convert.ToDouble(dataGridView2.Rows[i].Cells["PawnageAmount"].Value.ToString());
                serviceFee = Convert.ToDouble(dataGridView2.Rows[i].Cells["NewServiceFee"].Value.ToString());
                interestFee = Convert.ToDouble(dataGridView2.Rows[i].Cells["NewInterestFee"].Value.ToString());
                serviceFee = DianDangFunction.myRound(serviceFee, MainForm.AmountAccuracy);
                interestFee = DianDangFunction.myRound(interestFee, MainForm.AmountAccuracy);

                totalAmount += amount;
                totalServiceFee += serviceFee;
                totalInterestFee += interestFee;
            }

            paidFee = totalAmount - totalServiceFee;

            this.tbxTotalAmount.Text = totalAmount.ToString();
            this.tbxNewServiceFee.Text = totalServiceFee.ToString();
            this.tbxNewInterestFee.Text = totalInterestFee.ToString();
            this.tbxNewPaidFee.Text = paidFee.ToString();

            this.lblTotalAmount.Text = newChinese.toChineseChar(Convert.ToDecimal(totalAmount));
            this.lblServiceFee.Text = newChinese.toChineseChar(Convert.ToDecimal(totalServiceFee));
            this.lblInterestFee.Text = newChinese.toChineseChar(Convert.ToDecimal(totalInterestFee));
            this.lblPaidFee.Text = newChinese.toChineseChar(Convert.ToDecimal(paidFee));
        }

        private void CaculateNewGridAmount()
        {
            isLoading = true;
            try
            {
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    double serviceFee = 0;
                    double serviceFeeRate = Convert.ToDouble(dataGridView2.Rows[i].Cells["FeeRate"].Value.ToString());
                    double interestFeeRate = Convert.ToDouble(dataGridView2.Rows[i].Cells["InterestRate"].Value.ToString());
                    double interestFee = 0;
                    double amount = Convert.ToDouble(dataGridView2.Rows[i].Cells["PawnageAmount"].Value.ToString());

                    PawnSpan ServiceSpan = DianDangFunction.GetPawnSpan(DateTime.Parse(tbxStartDate.Text), DateTime.Parse(tbxEndDate.Text), FeeType.ServiceFee, PeridType.Within);
                    PawnSpan InterestSpan = DianDangFunction.GetPawnSpan(DateTime.Parse(tbxStartDate.Text), DateTime.Parse(tbxEndDate.Text), FeeType.InterestFee, PeridType.Within);

                    serviceFeeRate = Convert.ToDouble(this.tbxFeeRate.Text.ToString());
                    serviceFee = (ServiceSpan.Months + ServiceSpan.CountDays / 30) * amount * serviceFeeRate / 100;
                    serviceFee = DianDangFunction.myRound(serviceFee, MainForm.AmountAccuracy);
                    interestFeeRate = Convert.ToDouble(this.tbxInterestRate.Text.ToString());
                    interestFee = (InterestSpan.Months + InterestSpan.CountDays / 30) * amount * interestFeeRate / 100;
                    interestFee = DianDangFunction.myRound(interestFee, MainForm.AmountAccuracy);
                    dataGridView2.Rows[i].Cells["NewServiceFee"].Value = serviceFee;
                    dataGridView2.Rows[i].Cells["NewInterestFee"].Value = interestFee;
                }

            }
            catch
            {
                MessageBox.Show("请输入正确的数值", "提示信息");
            }

            isLoading = false;

        }

        void dataGridView2_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                try
                {
                    this.OldValue = dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }
                catch
                {
                }
            }
            if (this.dataGridView2.Rows.Count > 0)
            {
                DataGridViewRow dgr = dataGridView2.CurrentRow;
                this.cbxParentClass.Text = dgr.Cells["ParentClass"].Value.ToString();
                this.cbxChildClass.Text = dgr.Cells["ChildClass"].Value.ToString();
                this.tbxFeeRate.Text = dgr.Cells["Feerate"].Value.ToString();
                this.tbxInterestRate.Text = dgr.Cells["InterestRate"].Value.ToString();
                this.tbxDescription.Text = dgr.Cells["Description"].Value.ToString();
                this.tbxCountNumber.Text = dgr.Cells["CountNumber"].Value.ToString();
                this.tbxWeight.Text = dgr.Cells["Weight"].Value.ToString();
                this.tbxPrice.Text = dgr.Cells["PawnageAmount"].Value.ToString();
                this.tbxDiscountPercent.Text = dgr.Cells["DiscountPercent"].Value.ToString();
                this.tbxRemark.Text = dgr.Cells["Remark"].Value.ToString();
            }
        }

        private DialogResult CheckAllData()
        {
            if (this.tbxPrice.Text == "0" || this.tbxPrice.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, "价格输入错误，请重新输入！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return DialogResult.No;
            }
            if (this.tbxCountNumber.Text == "0" || this.tbxCountNumber.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, "件数输入错误，请重新输入！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return DialogResult.No;
            }

            double feeRate = 0;
            try
            {
                feeRate = Convert.ToDouble(this.tbxFeeRate.Text);
                if (feeRate < m_MinFeeRate || feeRate > m_MaxFeeRate)
                {
                    MessageBox.Show("费率超过规定范围，请重新输入！", "提示信息");
                    return DialogResult.No;
                }
            }
            catch
            {
                MessageBox.Show("费率输入错误，请重新输入！", "提示信息");
                return DialogResult.No;
            }
            return DialogResult.OK;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isLoading = true;
            double serviceFee = 0;
            double serviceFeeRate = 0;
            double interestFeeRate = 0;
            double interestFee = 0;
            PawnSpan ServiceSpan = DianDangFunction.GetPawnSpan(DateTime.Parse(tbxStartDate.Text), DateTime.Parse(tbxEndDate.Text), FeeType.ServiceFee, PeridType.Within);
            PawnSpan InterestSpan = DianDangFunction.GetPawnSpan(DateTime.Parse(tbxStartDate.Text), DateTime.Parse(tbxEndDate.Text), FeeType.InterestFee, PeridType.Within);

            DialogResult diaRes = CheckAllData();
            if (diaRes != DialogResult.OK)
            {
                return;
            }

            double price, percent, amount;

            try
            {
                price = Convert.ToDouble(this.tbxPrice.Text);
                percent = Convert.ToDouble(this.tbxDiscountPercent.Text);
            }
            catch
            {
                MessageBox.Show("数据格式不正确！", "输入数据");
                return;
            }

            amount = price * percent / 100;
            amount = DianDangFunction.myRound(amount, MainForm.AmountAccuracy);

            this.dataGridView2.Rows.Add(1);
            dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells["ParentClassID"].Value = this.cbxParentClass.SelectedValue;
            dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells["ParentClass"].Value = this.cbxParentClass.Text;
            dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells["ChildClassID"].Value = this.cbxChildClass.SelectedValue;
            dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells["ChildClass"].Value = this.cbxChildClass.Text;
            dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells["FeeRate"].Value = this.tbxFeeRate.Text;
            dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells["InterestRate"].Value = this.tbxInterestRate.Text;
            dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells["Description"].Value = this.tbxDescription.Text;
            dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells["CountNumber"].Value = this.tbxCountNumber.Text;
            dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells["Weight"].Value = this.tbxWeight.Text;
            dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells["DiscountPercent"].Value = this.tbxDiscountPercent.Text;
            dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells["Amount"].Value = amount;
            dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells["Remark"].Value = this.tbxRemark.Text;
            serviceFeeRate = Convert.ToDouble(this.tbxFeeRate.Text.ToString());
            serviceFee = (ServiceSpan.Months + ServiceSpan.CountDays / 30) * amount * serviceFeeRate / 100;
            serviceFee = DianDangFunction.myRound(serviceFee, MainForm.AmountAccuracy);
            interestFeeRate = Convert.ToDouble(this.tbxInterestRate.Text.ToString());
            interestFee = (InterestSpan.Months + InterestSpan.CountDays / 30) * amount * interestFeeRate / 100;
            interestFee = DianDangFunction.myRound(interestFee, MainForm.AmountAccuracy);
            dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells["NewServiceFee"].Value = serviceFee;
            dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells["NewInterestFee"].Value = interestFee;

            CaculateAmount();
            isLoading = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            isLoading = true;
            double serviceFee = 0;
            double serviceFeeRate = 0;
            double interestFeeRate = 0;
            double interestFee = 0;
            PawnSpan ServiceSpan = DianDangFunction.GetPawnSpan(DateTime.Parse(tbxStartDate.Text), DateTime.Parse(tbxEndDate.Text), FeeType.ServiceFee, PeridType.Within);
            PawnSpan InterestSpan = DianDangFunction.GetPawnSpan(DateTime.Parse(tbxStartDate.Text), DateTime.Parse(tbxEndDate.Text), FeeType.InterestFee, PeridType.Within);



            DialogResult diaRes = CheckAllData();
            if (diaRes != DialogResult.OK)
            {
                return;
            }
            double price, percent, amount;

            try
            {
                price = Convert.ToDouble(this.tbxPrice.Text);
                percent = Convert.ToDouble(this.tbxDiscountPercent.Text);
            }
            catch
            {
                MessageBox.Show("数据格式不正确！", "输入数据");
                return;
            }

            amount = price;
            amount = DianDangFunction.myRound(amount, MainForm.AmountAccuracy);

            DataGridViewRow dgr = new DataGridViewRow();

            for (int i = dataGridView2.Rows.Count - 1; i >= 0; i--)
            {
                if (this.dataGridView2.Rows[i].Cells["Operation"].Value != null)
                {
                    dgr = dataGridView2.Rows[i];
                }
            }

            try
            {
                dgr.Cells["ParentClassID"].Value = this.cbxParentClass.SelectedValue;
                dgr.Cells["ParentClass"].Value = this.cbxParentClass.Text;
                dgr.Cells["ChildClassID"].Value = this.cbxChildClass.SelectedValue;
                dgr.Cells["ChildClass"].Value = this.cbxChildClass.Text;
                dgr.Cells["FeeRate"].Value = this.tbxFeeRate.Text;
                dgr.Cells["InterestRate"].Value = this.tbxInterestRate.Text;
                dgr.Cells["Description"].Value = this.tbxDescription.Text;
                dgr.Cells["CountNumber"].Value = this.tbxCountNumber.Text;
                dgr.Cells["Weight"].Value = this.tbxWeight.Text;
                dgr.Cells["DiscountPercent"].Value = this.tbxDiscountPercent.Text;
                dgr.Cells["PawnageAmount"].Value = amount;
                dgr.Cells["Remark"].Value = this.tbxRemark.Text;

                serviceFeeRate = Convert.ToDouble(this.tbxFeeRate.Text.ToString());
                serviceFee = (ServiceSpan.Months + ServiceSpan.CountDays / 30) * amount * serviceFeeRate / 100;
                serviceFee = DianDangFunction.myRound(serviceFee, MainForm.AmountAccuracy);
                interestFeeRate = Convert.ToDouble(this.tbxInterestRate.Text.ToString());
                interestFee = (InterestSpan.Months + InterestSpan.CountDays / 30) * amount * interestFeeRate / 100;
                interestFee = DianDangFunction.myRound(interestFee, MainForm.AmountAccuracy);
                dgr.Cells["NewServiceFee"].Value = serviceFee;
                dgr.Cells["NewInterestFee"].Value = interestFee;

                CaculateAmount();

                MessageBox.Show(this, "数据修改成功！", "提示信息");
            }
            catch
            {
                MessageBox.Show(this, "数据修改失败！", "提示信息");
            }
            isLoading = false;
        }

        private void tbxPawnTerm_TextChanged(object sender, EventArgs e)
        {
            if (this.cbxTermType.SelectedIndex != -1)
            {
                int spanTime = 0;
                try
                {
                    spanTime = Convert.ToInt32(this.tbxPawnTerm.Text);

                    DateTime startDate = Convert.ToDateTime(this.tbxStartDate.Text);
                    DateTime endDate;
                    if (this.cbxTermType.SelectedIndex == 0)
                    {
                        endDate = startDate.AddMonths(spanTime);
                        //二月份特殊处理
                        if (DateTime.IsLeapYear(startDate.Year) == true && startDate.Month == 2 && startDate.Day == 29 ||
                            DateTime.IsLeapYear(startDate.Year) == false && startDate.Month == 2 && startDate.Day == 28)
                        {
                            endDate = new DateTime(endDate.Year, endDate.Month, DateTime.DaysInMonth(endDate.Year, endDate.Month));
                        }
                    }
                    else
                    {
                        endDate = startDate.AddDays(spanTime);
                        //this.lblPawnTerm.Text = spanTime.ToString();
                    }




                    this.tbxEndDate.Text = endDate.Year.ToString() + "-" + endDate.Month.ToString() + "-" + endDate.Day.ToString();
                    CaculateNewGridAmount();
                    CaculateAmount();
                }
                catch
                {
                    MessageBox.Show("典当期限输入不正确！", "提示信息");
                    return;
                }

            }
        }

        private void cbxTermType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int spanTime = 0;
            int count = 0;
            try
            {
                spanTime = Convert.ToInt32(this.tbxPawnTerm.Text);
            }
            catch
            {
                MessageBox.Show("典当期限输入不正确！", "提示信息");
                return;
            }

            DateTime startDate = Convert.ToDateTime(this.tbxStartDate.Text);
            DateTime endDate;
            if (this.cbxTermType.SelectedIndex == 0)
            {
                endDate = startDate.AddMonths(spanTime);
                //二月份特殊处理
                if (DateTime.IsLeapYear(startDate.Year) == true && startDate.Month == 2 && startDate.Day == 29 ||
                    DateTime.IsLeapYear(startDate.Year) == false && startDate.Month == 2 && startDate.Day == 28)
                {
                    endDate = new DateTime(endDate.Year, endDate.Month, DateTime.DaysInMonth(endDate.Year, endDate.Month));
                }
            }
            else
            {
                if (spanTime > 0)
                {
                    count = spanTime / 30;
                    spanTime = spanTime - 30 * count;
                    if (0 < spanTime && spanTime < 6)
                    {
                        spanTime = 5;
                    }
                    else if (5 < spanTime && spanTime < 16)
                    {
                        spanTime = 15;
                    }
                    else if (15 < spanTime && spanTime < 30)
                    {
                        spanTime = 30;
                    }
                    spanTime = 30 * count + spanTime;
                }
                endDate = startDate.AddDays(spanTime);

                this.tbxPawnTerm.Text = spanTime.ToString();
            }
            this.tbxEndDate.Text = endDate.Year.ToString() + "-" + endDate.Month.ToString() + "-" + endDate.Day.ToString();
            CaculateNewGridAmount();
            CaculateAmount();
        }

        private void tbxStartDate_Click(object sender, EventArgs e)
        {
            this.monthCalendar1.Visible = true;
            m_DateTextboxNumber = 2;
        }


        void dataGridView2_CellValueChanged(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && !isLoading)
            {
                if (e.ColumnIndex == dataGridView2.Columns["NewServiceFee"].Index)
                {
                    double serviceFee = 0;
                    try
                    {
                        serviceFee = Convert.ToDouble(dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        CaculateAmount();
                    }
                    catch
                    {
                        dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = OldValue;
                        MessageBox.Show("请输入正确的服务费", "提示信息");
                    }
                }

            }
        }

        private void tbxStartDate_TextChanged(object sender, EventArgs e)
        {
            this.monthCalendar1.Hide();
            try
            {
                DateTime startDate = Convert.ToDateTime(this.tbxStartDate.Text);
                DateTime endDate = new DateTime();
                int spanTime = Convert.ToInt32(this.tbxPawnTerm.Text);
                if (this.cbxTermType.SelectedIndex == 0)
                {
                    endDate = startDate.AddMonths(spanTime);
                    //二月份特殊处理
                    if (DateTime.IsLeapYear(startDate.Year) == true && startDate.Month == 2 && startDate.Day == 29 ||
                        DateTime.IsLeapYear(startDate.Year) == false && startDate.Month == 2 && startDate.Day == 28)
                    {
                        endDate = new DateTime(endDate.Year, endDate.Month, DateTime.DaysInMonth(endDate.Year, endDate.Month));
                    }
                }
                else
                {
                    endDate = startDate.AddDays(spanTime);
                }
                this.tbxEndDate.Text = endDate.Year.ToString() + "-" + endDate.Month.ToString() + "-" + endDate.Day.ToString();
                CaculateNewGridAmount();
                CaculateAmount();
            }
            catch
            {
            }
        }


    }
}