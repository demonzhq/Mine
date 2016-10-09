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
    public partial class RedeemPawnOperationForm : DockContent
    {
        private string OldValue = "";

        public int LoadingStatus = 0;

        public RedeemPawnOperationForm(int iTicketID)
        {
            m_TicketID = iTicketID;
            LoadingStatus = 1;
            InitializeComponent();
            InitGridTableColumn();
            LoadOperationNumber();

            DateTime currentDate = DateTime.Now;
            string strDate = currentDate.Year.ToString() + "-" + currentDate.Month.ToString() + "-" + currentDate.Day.ToString();
            this.tbxOperationDate.Text = strDate;
            m_TicketID = iTicketID;
            LoadTicketInfo();
            LoadingStatus = 0;
        }

        private DateTime m_OperationDate;
        private DateTime m_StartDate;
        private DateTime m_EndDate;
        private bool isOperationSuccess = false;

        private double CaculateOverdueFee(double amount, double feeRate, double interestRate)
        {
            double overdueFee = 0;
            TimeSpan overdueTimeSpan = m_OperationDate.Subtract(m_EndDate);
            //TimeSpan termTimeSpan = m_EndDate.Subtract(m_StartDate);
            //int termDays = termTimeSpan.Days;
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
            /*
            double TotalServiceFee = 0;
            double TotalInterestFee = 0;

            Query queryOperation = new Query(DDOperation.Schema);
            queryOperation.AddWhere("TicketID", m_TicketID);
            queryOperation.AddWhere("OperationType", Comparison.In, new int[] { 1, 3 });
            queryOperation.AddWhere("Deleted", Comparison.NotEquals, 1);
            DataTable dtOperation = queryOperation.ExecuteDataSet().Tables[0];
            if (dtOperation.Rows.Count > 0)
            {
                for (int i = 0; i < dtOperation.Rows.Count; i++)
                {
                    TotalServiceFee += Convert.ToDouble(dtOperation.Rows[i]["ServiceFee"]);
                    TotalInterestFee += Convert.ToDouble(dtOperation.Rows[i]["InterestFee"]);
                }
            }

            feeRate++;
            */
            
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

        private void LoadTicketInfo()
        {
            this.m_GridTable.Rows.Clear();
            
            DDPawnTicket newTicket = new DDPawnTicket("TicketID", m_TicketID);

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

                    DDPawnageInfo pawnageInfo = new DDPawnageInfo("PawnageID", Convert.ToInt32(dtOperations.Rows[i]["PawnageID"]));

                    #region 费用计算
                    //判断当票状态
                    int PawnTicketStatus = 0;  //0:正好，1:提前，2:过期

                    //DDPawnTicket theTicket = new DDPawnTicket("TicketID", m_TicketID);
                    if (m_OperationDate <= DateTime.Parse(dtOperations.Rows[i]["EndDate"].ToString()))
                    {
                        PawnSpan Span = DianDangFunction.GetPawnSpan(m_OperationDate, DateTime.Parse(dtOperations.Rows[i]["StartDate"].ToString()), FeeType.ServiceFee, PeridType.Within);
                        PawnSpan LastSpan = DianDangFunction.GetPawnSpan(DateTime.Parse(dtOperations.Rows[i]["StartDate"].ToString()), DateTime.Parse(dtOperations.Rows[i]["EndDate"].ToString()),FeeType.ServiceFee, PeridType.Within);
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

                            PawnSpan OverdueServiceSpan = DianDangFunction.GetPawnSpan(DateTime.Parse(dtOperations.Rows[i]["EndDate"].ToString()), m_OperationDate, FeeType.ServiceFee, PeridType.Overdue);
                            overdueFee = (OverdueServiceSpan.Months + OverdueServiceSpan.CountDays / 30) * amount * Convert.ToDouble(dtOperations.Rows[i]["ServiceFeeRate"].ToString()) / 100;
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
            try
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
            }
            catch (Exception ex)
            {
                throw ex;
            }

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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            using (TransactionScope Scope = new TransactionScope())
            {
                try
                {
                    LoadOperationNumber();
                    UpdateOperation(m_TicketID);
                    UpdateOperationNumber();
                    UpdateTicketStatus(m_TicketID);

                    DDPrintParam newParam = new DDPrintParam("PrintOption", 5);
                    if (newParam.OptionValue == 1)
                    {
                        PrintReceipt();
                    }
                    LoadOperationNumber();
                    this.btnPrint.Enabled = false;
                    Scope.Complete();
                    //MessageBox.Show(this, "赎当成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.isOperationSuccess = true;
                }
                catch
                {
                    Scope.Dispose();
                    //MessageBox.Show(this, "操作失败，请检查数据库是否连接正确！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.isOperationSuccess = false;
                }
            }

            if (this.isOperationSuccess == true)
            {
                this.isOperationSuccess = false;
                MessageBox.Show(this, "赎当成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(this, "操作失败，请检查数据库是否连接正确！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void tbxOperationDate_Click(object sender, EventArgs e)
        {
            this.monthCalendar1.Visible = true;
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
                this.tbxOperationDate.Text = _date;
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
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
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
            if (LoadingStatus == 0)
            {
                try
                {
                    Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    CaculateDatagridAmount();
                }
                catch
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = OldValue;
                    MessageBox.Show("请输入正确的金额", "提示信息");
                }
                
            }
        }

    }
}