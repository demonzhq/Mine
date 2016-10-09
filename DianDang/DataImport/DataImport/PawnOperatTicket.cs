using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Collections;

namespace DataImport
{

    class PawnInfo
    {
        public int PawnageID = 0;
        public int ClassID = 0;
        public int ParentID = 0;
        public int StatusID = 0; // Not Used
        public int CountNumber = 0;
        public double Weight = 0;
        public double Price = 0;  //Not Used
        public double FeeRate = 0;
        public double InterestRate = 0;
        public double DiscountPercent = 0;
        public string Description = "";
        public string Remark = "";
        public string StartDate = "";
        public string EndDate = "";
        public double PrecentByTicket = 0;
        
    }

    partial class Main
    {
        private void PawnOperatTicket()
        {
            //ReadTicket
            int SqlExecResult = 0;
            string SqlExecString = "";
            int NumofTickets = 0;
            int TicketNow = 0;
            string DateNone = "1899/12/300:00:00";

            #region Tick参数定义区域
            int TicketID = 0;
            int CustomerID = 0;
            string TicketNumber = "";
            string TicketStartDate = "";
            string TicketEndDate = "";
            int TicketStatusID = 0;
            double TicketFeeRate = 0;
            double TicketInterestRate = 0;
            string TicketRemark = "";
            double TicketAmount = 0;
            int TicketOperationStep = 0;
            #endregion

            #region 当品参数区域
            MyDBFConnection DBFConnectionP = new MyDBFConnection();
            DBFQueryResult DBFResultP = new DBFQueryResult();
            OleDbDataReader DBFDataP;
            PawnInfo thePawnage;
            List<PawnInfo> PawnList= new List<PawnInfo>();
            #endregion

            #region 操作参数区域
            MyDBFConnection DBFConnectionO = new MyDBFConnection();
            DBFQueryResult DBFResultO = new DBFQueryResult();
            OleDbDataReader DBFDataO;
            int OperationType = 0;
            int NextOperationType = 0;
            double OperationServiceFee = 0;
            double NextOperationServiceFee = 0;
            double OperationInterestFee = 0;
            double NextOperationInterestFee = 0;
            double OperationReturnFee = 0;
            double NextOperationReturnFee = 0;
            double OperationOverdueFee = 0;
            double NextOperationOverdueFee = 0;
            double ReckonAmount = 0;
            double NextReckonAmount = 0;
            string OperationDate = "";
            string NextOperationDate = "";
            string OperationStartDate = "";
            string NextOperationStartDate = "";
            string OperationEndDate = "";
            string NextOperationEndDate = "";
            string OperatorName = "";
            string NextOperatorName = "";
            double Fee = 0;
            double NextFee = 0;
            int LastOperationID = 0;
            int NewOperationID = 0;
            double RestOperationServiceFee = 0;
            double RestOperationInterestFee = 0;
            double RestOperationReturnFee = 0;
            double RestOperationOverdueFee = 0;
            #endregion

            #region 读取当票总数
            DBFConnection.SetFile(this.DBFPath + "CUST_RCD.DBF");
            DBFConnection.Connect();
            DBFResult = DBFConnection.Query("select count(Name) from CUST_RCD.DBF");
            DBFData = DBFResult.GetResult();
            while (DBFData.Read())
            {
                NumofTickets = Convert.ToInt32(DBFData[0].ToString());
            }
            DBFData.Close();
            DBFConnection.DisConnect();
            this.MainProgressBar.Maximum = NumofTickets;
            #endregion

            

            DBFConnection.SetFile(this.DBFPath + "CUST_RCD.DBF");
            DBFConnection.Connect();
            DBFResult = DBFConnection.Query("select NAME, SFZ_ID, B_NO, DATE, END_DATE, FREE1, FREE2, ABSTRACT, D_JE from CUST_RCD.DBF");
            DBFData = DBFResult.GetResult();
            while (DBFData.Read())
            {
                int stop = 0;
                if (DBFData[2].ToString() == "11025189")
                {
                    stop++;
                }

                #region 存取当票信息
                TicketOperationStep = 0;
                CustomerID = GetSqlCustomerIDbyNameCertNumber(CutSpace(DBFData[0].ToString()), CutSpace(DBFData[1].ToString()));
                TicketNumber = CutSpace(DBFData[2].ToString());
                TicketStartDate = ChangeDateFormat(DateTime.Parse(DBFData[3].ToString()).ToShortDateString());
                TicketEndDate = ChangeDateFormat(DateTime.Parse(DBFData[4].ToString()).ToShortDateString());
                TicketStatusID = GetSqlTicketStatusIDbyDBFB_NO(CutSpace(DBFData[2].ToString()));
                TicketFeeRate = Convert.ToDouble(CutSpace(DBFData[5].ToString()));
                TicketInterestRate = Convert.ToDouble(CutSpace(DBFData[6].ToString()));
                TicketRemark = CutSpace(DBFData[7].ToString());
                TicketAmount = Convert.ToDouble(CutSpace(DBFData[8].ToString()));


                SqlExecString = "insert into DDPawnTicket (CustomerID, TicketNumber, StartDate, EndDate, StatusID) VALUES("
                                + "'" + CustomerID.ToString() + "', "
                                + "'" + TicketNumber + "', "
                                + "'" + TicketStartDate + "', "
                                + "'" + TicketEndDate + "', "
                                + "'" + TicketStatusID.ToString() + "')";
                SqlExecResult = SqlConnection.Exec(SqlExecString);

                SqlResult = SqlConnection.Query("select TicketID from DDPawnTicket where "
                                                + "CustomerID='" + CustomerID.ToString() + "' and "
                                                + "TicketNumber='" + TicketNumber + "' and "
                                                + "StartDate='" + TicketStartDate + "' and "
                                                + "EndDate='" + TicketEndDate + "'");
                SqlData = SqlResult.GetResult();
                SqlData.Read();
                TicketID = Convert.ToInt32(SqlData[0].ToString());
                SqlData.Close();
                #endregion

                TicketNow++;
                this.MainProgressBar.Value = TicketNow;
                
                

                #region 存取当品信息表
                DBFConnectionP.SetFile(this.DBFPath + "DDRECORD.DBF");
                DBFConnectionP.Connect();
                DBFResultP = DBFConnectionP.Query("select TYPE_NO, SL, ZL, D_JE, ABSTRACT from DDRECORD.DBF where B_NO='" + TicketNumber + "'");
                DBFDataP = DBFResultP.GetResult();
                while (DBFDataP.Read())
                {
                    thePawnage = new PawnInfo();
                    thePawnage.ClassID = GetClassIDByDD_TYPE(CutSpace(DBFDataP[0].ToString()));
                    thePawnage.ParentID = GetParentIDByDD_TYPE(CutSpace(DBFDataP[0].ToString()));
                    thePawnage.StatusID = TicketStatusID;
                    thePawnage.CountNumber = Convert.ToInt32(CutSpace(DBFDataP[1].ToString()));
                    thePawnage.Weight = Convert.ToDouble(CutSpace(DBFDataP[2].ToString()));
                    thePawnage.Price = Convert.ToDouble(CutSpace(DBFDataP[3].ToString()));
                    thePawnage.FeeRate = TicketFeeRate;
                    thePawnage.InterestRate = TicketInterestRate;
                    if (thePawnage.Weight != 0)
                    {
                        thePawnage.Description = thePawnage.Weight.ToString() + GetUnitNameByClassID(thePawnage.ClassID);
                    }
                    else thePawnage.Description = GetUnitNameByClassID(thePawnage.ClassID);
                    thePawnage.Remark = CutSpace(DBFDataP[4].ToString());
                    thePawnage.StartDate = TicketStartDate;
                    thePawnage.EndDate = TicketEndDate;
                    

                    SqlExecString = "insert into DDPawnageInfo (ClassID, ParentID, StatusID, CountNumber, Weight, Price, FeeRate, InterestRate, DiscountPercent, Description, Remark, StartDate, EndDate) VALUES ("
                                    + "'" + thePawnage.ClassID.ToString() + "', "
                                    + "'" + thePawnage.ParentID.ToString() + "', "
                                    + "'" + thePawnage.StatusID.ToString() + "', "
                                    + "'" + thePawnage.CountNumber.ToString() + "', "
                                    + "'" + thePawnage.Weight.ToString() + "', "
                                    + "'" + thePawnage.Price.ToString() + "', "
                                    + "'" + thePawnage.FeeRate.ToString() + "', "
                                    + "'" + thePawnage.InterestRate.ToString() + "', "
                                    + "'" + "0" + "', "
                                    + "'" + thePawnage.Description + "', "
                                    + "'" + thePawnage.Remark + "', "
                                    + "'" + thePawnage.StartDate + "', "
                                    + "'" + thePawnage.EndDate + "')";
                    SqlExecResult = SqlConnection.Exec(SqlExecString);


                    SqlResult = SqlConnection.Query("select PawnageID from DDPawnageInfo where "
                                                    + "ClassID='" + thePawnage.ClassID.ToString() + "' and "
                                                    + "ParentID='" + thePawnage.ParentID.ToString() + "' and "
                                                    + "StatusID='" + thePawnage.StatusID.ToString() + "' and "
                                                    + "CountNumber='" + thePawnage.CountNumber.ToString() + "' and "
                                                    + "Weight='" + thePawnage.Weight + "' and "
                                                    + "Price='" + thePawnage.Price + "' and "
                                                    + "FeeRate='" + thePawnage.FeeRate + "' and "
                                                    + "InterestRate='" + thePawnage.InterestRate + "' and "
                                                    + "Description='" + thePawnage.Description + "' and "
                                                    + "Remark='" + thePawnage.Remark + "' and "
                                                    + "StartDate='" + thePawnage.StartDate + "' and "
                                                    + "EndDate='" + thePawnage.EndDate + "'"
                                                    );
                    SqlData = SqlResult.GetResult();
                    while (SqlData.Read())
                    {
                        thePawnage.PawnageID = Convert.ToInt32(CutSpace(SqlData[0].ToString()));
                    }
                    SqlData.Close();
                    thePawnage.PrecentByTicket = (thePawnage.Price) / (TicketAmount);
                    PawnList.Add(thePawnage); 
                }
                DBFDataP.Close();
                DBFConnectionP.DisConnect();
                #endregion

                #region 操作记录表
                DBFConnectionO.SetFile(this.DBFPath + "OP_RCD.DBF");
                DBFConnectionO.Connect();
                DBFResultO = DBFConnectionO.Query("select OP_TYPE, F_JE, LX_JE, F_JE_1, DATE, SQ_DATE, END_DATE, OPERATOR from OP_RCD.DBF where B_NO='" + TicketNumber + "'");
                DBFDataO = DBFResultO.GetResult();

                #region 读取当前数据
                if (DBFDataO.Read())
                {
                    
                    OperationType = GetSqlOperationTypebyDBFOP_TYPE(CutSpace(DBFDataO[0].ToString()));
                    if (OperationType == GetSqlOperationTypebyDBFOP_TYPE("6"))
                    {
                        ReckonAmount = Convert.ToDouble(CutSpace(DBFDataO[1].ToString()));
                        OperationServiceFee = 0;
                    }
                    else
                    {
                        OperationServiceFee = Convert.ToDouble(CutSpace(DBFDataO[1].ToString()));
                    }
                    OperationInterestFee = Convert.ToDouble(CutSpace(DBFDataO[2].ToString()));
                    Fee = Convert.ToDouble(CutSpace(DBFDataO[3].ToString()));
                    if (Fee > 0)
                    {
                        OperationOverdueFee = Fee;
                        OperationReturnFee = 0;
                    }
                    else
                    {
                        OperationOverdueFee = 0;
                        OperationReturnFee = 0 - Fee;
                    }

                    if (CutSpace(DBFDataO[4].ToString()) != DateNone)
                    {
                        OperationDate = ChangeDateFormat(DateTime.Parse(DBFDataO[4].ToString()).ToShortDateString());
                    }
                    else
                    {
                        OperationDate = "";
                    }

                    if (CutSpace(DBFDataO[5].ToString()) != DateNone)
                    {
                        OperationStartDate = ChangeDateFormat(DateTime.Parse(DBFDataO[5].ToString()).ToShortDateString());
                    }
                    else
                    {
                        OperationStartDate = "";
                    }

                    if (CutSpace(DBFDataO[6].ToString()) != DateNone)
                    {
                        OperationEndDate = ChangeDateFormat(DateTime.Parse(DBFDataO[6].ToString()).ToShortDateString());
                    }
                    else
                    {
                        OperationEndDate = "";
                    }

                    if (OperationStartDate == "")
                    {
                        OperationStartDate = TicketStartDate;
                    }
                    if (OperationEndDate == "")
                    {
                        OperationEndDate = TicketEndDate;
                    }
                    OperationStartDate = TicketStartDate;
                    OperationEndDate = TicketEndDate;

                    OperatorName = GetOperatorNameByDBFOperator(CutSpace(DBFDataO[7].ToString()));
                }
                #endregion


                while (DBFDataO.Read())
                {
                    #region 读取Next数据
                    NextOperationType = GetSqlOperationTypebyDBFOP_TYPE(CutSpace(DBFDataO[0].ToString()));
                    if (NextOperationType == GetSqlOperationTypebyDBFOP_TYPE("6"))
                    {
                        NextReckonAmount = Convert.ToDouble(CutSpace(DBFDataO[1].ToString()));
                        NextOperationServiceFee = 0;
                    }
                    else
                    {
                        NextOperationServiceFee = Convert.ToDouble(CutSpace(DBFDataO[1].ToString()));
                    }
                    NextOperationInterestFee = Convert.ToDouble(CutSpace(DBFDataO[2].ToString()));
                    NextFee = Convert.ToDouble(CutSpace(DBFDataO[3].ToString()));
                    if (NextFee > 0)
                    {
                        NextOperationOverdueFee = NextFee;
                        NextOperationReturnFee = 0;
                    }
                    else
                    {
                        NextOperationOverdueFee = 0;
                        NextOperationReturnFee = 0 - NextFee;
                    }
                    if (CutSpace(DBFDataO[4].ToString()) != DateNone)
                    {
                        NextOperationDate = ChangeDateFormat(DateTime.Parse(DBFDataO[4].ToString()).ToShortDateString());
                    }
                    else
                    {
                        NextOperationDate = "";
                    }
                    if (CutSpace(DBFDataO[5].ToString()) != DateNone)
                    {
                        NextOperationStartDate = ChangeDateFormat(DateTime.Parse(DBFDataO[5].ToString()).ToShortDateString());
                    }
                    else
                    {
                        NextOperationStartDate = "";
                    }
                    if (CutSpace(DBFDataO[6].ToString()) != DateNone)
                    {
                        NextOperationEndDate = ChangeDateFormat(DateTime.Parse(DBFDataO[6].ToString()).ToShortDateString());
                    }
                    else
                    {
                        NextOperationEndDate = "";
                    }

                    NextOperatorName = GetOperatorNameByDBFOperator(CutSpace(DBFDataO[7].ToString()));

                    #endregion

                    #region 当前数据与Next数据整合
                    //后一次又日期立即补齐
                    if (NextOperationStartDate != "")
                    {
                        OperationStartDate = NextOperationStartDate;
                    }
                    else
                    {
                        //如果是续当操作，则开始时间即为结束时间
                        if (OperationType == GetSqlOperationTypebyDBFOP_TYPE("2"))
                        {
                            OperationStartDate = OperationEndDate;
                        }
                    }
                    if (NextOperationEndDate != "")
                    {
                        OperationEndDate = NextOperationEndDate;
                    }
                    else
                    {
                        if (OperationType == GetSqlOperationTypebyDBFOP_TYPE("2"))
                        {
                            OperationEndDate = TicketEndDate;
                        }
                    }
                    #endregion

                    #region 将每个当品插入当前操作，存入数据库
                    RestOperationInterestFee = OperationInterestFee;
                    RestOperationOverdueFee = OperationOverdueFee;
                    RestOperationReturnFee = OperationReturnFee;
                    RestOperationServiceFee = OperationServiceFee;
                    for (int i = 0; i < PawnList.Count; i++)
                    {
                        LastOperationID = GetLastOperationIDbyPawnageID(PawnList[i].PawnageID);
                        if (i != PawnList.Count - 1)
                        {
                            SqlExecString = "insert into DDOperation (TicketID, PawnageID, OperationTYPE, OperationNumber, ServiceFee, InterestFee, ReturnFee, OverdueFee, Amount, ReckonAmount, OperationDate, StartDate, EndDate, OperaterName, PreOperationID, NextOperationID, ServiceFeeRate, InterestFeeRate) VALUES ("
                                            + "'" + TicketID.ToString() + "', "
                                            + "'" + PawnList[i].PawnageID + "', "
                                            + "'" + OperationType + "', "
                                            + "'" + GetNewOperationNumber() + "', "
                                            + "'" + FormatDigital((OperationServiceFee * PawnList[i].PrecentByTicket), Convert.ToInt32(numericUpDown1.Value)) + "', "
                                            + "'" + FormatDigital((OperationInterestFee * PawnList[i].PrecentByTicket), Convert.ToInt32(numericUpDown1.Value)) + "', "
                                            + "'" + FormatDigital((OperationReturnFee * PawnList[i].PrecentByTicket), Convert.ToInt32(numericUpDown1.Value)) + "', "
                                            + "'" + FormatDigital((OperationOverdueFee * PawnList[i].PrecentByTicket), Convert.ToInt32(numericUpDown1.Value)) + "', "
                                            + "'" + PawnList[i].Price + "', "
                                            + "'" + ReckonAmount.ToString() + "', "
                                            + "'" + OperationDate + "', "
                                            + "'" + OperationStartDate + "', "
                                            + "'" + OperationEndDate + "', "
                                            + "'" + OperatorName + "', "
                                            + "'" + LastOperationID + "', "
                                            + "'" + "0', "
                                            + "'" + TicketFeeRate + "', "
                                            + "'" + TicketInterestRate + "')";
                            RestOperationServiceFee = RestOperationServiceFee - FormatDigital((OperationServiceFee * PawnList[i].PrecentByTicket), Convert.ToInt32(numericUpDown1.Value));
                            RestOperationInterestFee = RestOperationInterestFee - FormatDigital((OperationInterestFee * PawnList[i].PrecentByTicket), Convert.ToInt32(numericUpDown1.Value));
                            RestOperationReturnFee = RestOperationReturnFee - FormatDigital((OperationReturnFee * PawnList[i].PrecentByTicket), Convert.ToInt32(numericUpDown1.Value));
                            RestOperationOverdueFee = RestOperationOverdueFee - FormatDigital((OperationOverdueFee * PawnList[i].PrecentByTicket), Convert.ToInt32(numericUpDown1.Value));
                        }
                        else
                        {
                            SqlExecString = "insert into DDOperation (TicketID, PawnageID, OperationTYPE, OperationNumber, ServiceFee, InterestFee, ReturnFee, OverdueFee, Amount, ReckonAmount, OperationDate, StartDate, EndDate, OperaterName, PreOperationID, NextOperationID, ServiceFeeRate, InterestFeeRate) VALUES ("
                                            + "'" + TicketID.ToString() + "', "
                                            + "'" + PawnList[i].PawnageID + "', "
                                            + "'" + OperationType + "', "
                                            + "'" + GetNewOperationNumber() + "', "
                                            + "'" + FormatDigital(RestOperationServiceFee, Convert.ToInt32(numericUpDown1.Value)) + "', "
                                            + "'" + FormatDigital(RestOperationInterestFee, Convert.ToInt32(numericUpDown1.Value)) + "', "
                                            + "'" + FormatDigital(RestOperationReturnFee, Convert.ToInt32(numericUpDown1.Value)) + "', "
                                            + "'" + FormatDigital(RestOperationOverdueFee, Convert.ToInt32(numericUpDown1.Value)) + "', "
                                            + "'" + PawnList[i].Price + "', "
                                            + "'" + ReckonAmount.ToString() + "', "
                                            + "'" + OperationDate + "', "
                                            + "'" + OperationStartDate + "', "
                                            + "'" + OperationEndDate + "', "
                                            + "'" + OperatorName + "', "
                                            + "'" + LastOperationID + "', "
                                            + "'" + "0', "
                                            + "'" + TicketFeeRate + "', "
                                            + "'" + TicketInterestRate + "')";
                        }

                        SqlExecResult = SqlConnection.Exec(SqlExecString);

                        //临时区域注意注意！！！！！
                        /*
                        SqlResult = SqlConnection.Query("select OperationID from DDOperation where "  
                                        + "TicketID='" + TicketID.ToString() + "' and "
                                        + "PawnageID='" + PawnList[i].PawnageID + "' and "
                                        + "OperationTYPE='" + OperationType + "' and "
                                        + "OperationNumber='" + GetNewOperationNumber() + "' and "
                                        + "ServiceFee='" + (OperationServiceFee * PawnList[i].PrecentByTicket) + "' and "
                                        + "InterestFee='" + (OperationInterestFee * PawnList[i].PrecentByTicket) + "' and "
                                        + "ReturnFee='" + (OperationReturnFee * PawnList[i].PrecentByTicket) + "' and "
                                        + "OverdueFee='" + (OperationOverdueFee * PawnList[i].PrecentByTicket) + "' and "
                                        + "Amount='" + PawnList[i].Price + "' and "
                                        + "ReckonAmount='" + ReckonAmount.ToString() + "' and "
                                        + "OperationDate='" + OperationDate + "' and "
                                        + "StartDate='" + OperationStartDate + "' and "
                                        + "EndDate='" + OperationEndDate + "' and "
                                        + "OperaterName='" + OperatorName + "' and "
                                        + "PreOperationID='" + LastOperationID + "' and "
                                        + "NextOperationID='" + "0'"
                            );
                         
                        SqlData = SqlResult.GetResult();
                        while (SqlData.Read())
                        {
                            NewOperationID = Convert.ToInt32(CutSpace(SqlData[0].ToString()));
                        }
                         */
                        //Replace
                        SqlResult = SqlConnection.Query("select OperationID from DDOperation where TicketID=" + TicketID.ToString());
                        SqlData = SqlResult.GetResult();
                        while (SqlData.Read())
                        {
                            NewOperationID = Convert.ToInt32(CutSpace(SqlData[0].ToString()));
                        }

                        SqlData.Close();

                        SqlExecString = "update DDOperation set NextOperationID='" + NewOperationID + "' where OperationID='" + LastOperationID + "'";
                        SqlExecResult = SqlConnection.Exec(SqlExecString);
                    }
                    TicketOperationStep++;
                    UpdateOperationNumber();
                    #endregion

                    #region Next变为当前
                    OperationType = NextOperationType;
                    OperationServiceFee = NextOperationServiceFee;
                    OperationInterestFee = NextOperationInterestFee;
                    OperationReturnFee = NextOperationReturnFee;
                    OperationOverdueFee = NextOperationOverdueFee;
                    ReckonAmount = NextReckonAmount;
                    OperationDate = NextOperationDate;
                    OperationStartDate = NextOperationStartDate;
                    OperationEndDate = NextOperationEndDate;
                    OperatorName = NextOperatorName;
                    Fee = NextFee;
                    #endregion
                }

                #region 将最后一次读取记录存入数据库

                //如果为续当，则起始时间为上一次结束时间，结束时间为当票结束时间
                if (OperationType == GetSqlOperationTypebyDBFOP_TYPE("2"))
                {
                    OperationStartDate = OperationEndDate;
                    OperationEndDate = TicketEndDate;
                }


                RestOperationInterestFee = OperationInterestFee;
                RestOperationOverdueFee = OperationOverdueFee;
                RestOperationReturnFee = OperationReturnFee;
                RestOperationServiceFee = OperationServiceFee;
                for (int i = 0; i < PawnList.Count; i++)
                {
                    LastOperationID = GetLastOperationIDbyPawnageID(PawnList[i].PawnageID);
                    if (i != PawnList.Count - 1)
                    {
                        SqlExecString = "insert into DDOperation (TicketID, PawnageID, OperationTYPE, OperationNumber, ServiceFee, InterestFee, ReturnFee, OverdueFee, Amount, ReckonAmount, OperationDate, StartDate, EndDate, OperaterName, PreOperationID, NextOperationID, ServiceFeeRate, InterestFeeRate) VALUES ("
                                        + "'" + TicketID.ToString() + "', "
                                        + "'" + PawnList[i].PawnageID + "', "
                                        + "'" + OperationType + "', "
                                        + "'" + GetNewOperationNumber() + "', "
                                        + "'" + FormatDigital((OperationServiceFee * PawnList[i].PrecentByTicket), Convert.ToInt32(numericUpDown1.Value)) + "', "
                                        + "'" + FormatDigital((OperationInterestFee * PawnList[i].PrecentByTicket), Convert.ToInt32(numericUpDown1.Value)) + "', "
                                        + "'" + FormatDigital((OperationReturnFee * PawnList[i].PrecentByTicket), Convert.ToInt32(numericUpDown1.Value)) + "', "
                                        + "'" + FormatDigital((OperationOverdueFee * PawnList[i].PrecentByTicket), Convert.ToInt32(numericUpDown1.Value)) + "', "
                                        + "'" + PawnList[i].Price + "', "
                                        + "'" + ReckonAmount.ToString() + "', "
                                        + "'" + OperationDate + "', "
                                        + "'" + OperationStartDate + "', "
                                        + "'" + OperationEndDate + "', "
                                        + "'" + OperatorName + "', "
                                        + "'" + LastOperationID + "', "
                                        + "'" + "0', "
                                        + "'" + TicketFeeRate + "', "
                                        + "'" + TicketInterestRate + "')";
                        RestOperationServiceFee = RestOperationServiceFee - FormatDigital((OperationServiceFee * PawnList[i].PrecentByTicket), Convert.ToInt32(numericUpDown1.Value));
                        RestOperationInterestFee = RestOperationInterestFee - FormatDigital((OperationInterestFee * PawnList[i].PrecentByTicket), Convert.ToInt32(numericUpDown1.Value));
                        RestOperationReturnFee = RestOperationReturnFee - FormatDigital((OperationReturnFee * PawnList[i].PrecentByTicket), Convert.ToInt32(numericUpDown1.Value));
                        RestOperationOverdueFee = RestOperationOverdueFee - FormatDigital((OperationOverdueFee * PawnList[i].PrecentByTicket), Convert.ToInt32(numericUpDown1.Value));
                    }
                    else
                    {
                        SqlExecString = "insert into DDOperation (TicketID, PawnageID, OperationTYPE, OperationNumber, ServiceFee, InterestFee, ReturnFee, OverdueFee, Amount, ReckonAmount, OperationDate, StartDate, EndDate, OperaterName, PreOperationID, NextOperationID, ServiceFeeRate, InterestFeeRate) VALUES ("
                                        + "'" + TicketID.ToString() + "', "
                                        + "'" + PawnList[i].PawnageID + "', "
                                        + "'" + OperationType + "', "
                                        + "'" + GetNewOperationNumber() + "', "
                                        + "'" + FormatDigital(RestOperationServiceFee, Convert.ToInt32(numericUpDown1.Value)) + "', "
                                        + "'" + FormatDigital(RestOperationInterestFee, Convert.ToInt32(numericUpDown1.Value)) + "', "
                                        + "'" + FormatDigital(RestOperationReturnFee, Convert.ToInt32(numericUpDown1.Value)) + "', "
                                        + "'" + FormatDigital(RestOperationOverdueFee, Convert.ToInt32(numericUpDown1.Value)) + "', "
                                        + "'" + PawnList[i].Price + "', "
                                        + "'" + ReckonAmount.ToString() + "', "
                                        + "'" + OperationDate + "', "
                                        + "'" + OperationStartDate + "', "
                                        + "'" + OperationEndDate + "', "
                                        + "'" + OperatorName + "', "
                                        + "'" + LastOperationID + "', "
                                        + "'" + "0', "
                                        + "'" + TicketFeeRate + "', "
                                        + "'" + TicketInterestRate + "')";
                    }
                    SqlExecResult = SqlConnection.Exec(SqlExecString);

                    //临时区域注意注意！！！！！
                    /*
                    SqlResult = SqlConnection.Query("select OperationID from DDOperation where "
                                    + "TicketID='" + TicketID.ToString() + "' and "
                                    + "PawnageID='" + PawnList[i].PawnageID + "' and "
                                    + "OperationTYPE='" + OperationType + "' and "
                                    + "OperationNumber='" + GetNewOperationNumber() + "' and "
                                    + "ServiceFee='" + (OperationServiceFee * PawnList[i].PrecentByTicket) + "' and "
                                    + "InterestFee='" + (OperationInterestFee * PawnList[i].PrecentByTicket) + "' and "
                                    + "ReturnFee='" + (OperationReturnFee * PawnList[i].PrecentByTicket) + "' and "
                                    + "OverdueFee='" + (OperationOverdueFee * PawnList[i].PrecentByTicket) + "' and "
                                    + "Amount='" + PawnList[i].Price + "' and "
                                    + "ReckonAmount='" + ReckonAmount + "' and "
                                    + "OperationDate='" + OperationDate + "' and "
                                    + "StartDate='" + OperationStartDate + "' and "
                                    + "EndDate='" + OperationEndDate + "' and "
                                    + "OperaterName='" + OperatorName + "' and "
                                    + "PreOperationID='" + LastOperationID + "' and "
                                    + "NextOperationID='" + "0'"
                        );
                    SqlData = SqlResult.GetResult();
                    while (SqlData.Read())
                    {
                        NewOperationID = Convert.ToInt32(CutSpace(SqlData[0].ToString()));
                    }
                    SqlData.Close();
                    */
                    SqlResult = SqlConnection.Query("select OperationID from DDOperation where TicketID=" + TicketID.ToString());
                    SqlData = SqlResult.GetResult();
                    while (SqlData.Read())
                    {
                        NewOperationID = Convert.ToInt32(CutSpace(SqlData[0].ToString()));
                    }
                    SqlData.Close();


                    SqlExecString = "update DDOperation set NextOperationID='" + NewOperationID + "' where OperationID='" + LastOperationID + "'";
                    SqlExecResult = SqlConnection.Exec(SqlExecString);

                }
                UpdateOperationNumber();

                
                #endregion


                #region 清空参数
                OperationType = 0;
                NextOperationType = 0;
                OperationServiceFee = 0;
                NextOperationServiceFee = 0;
                OperationInterestFee = 0;
                NextOperationInterestFee = 0;
                OperationReturnFee = 0;
                NextOperationReturnFee = 0;
                OperationOverdueFee = 0;
                NextOperationOverdueFee = 0;
                ReckonAmount = 0;
                NextReckonAmount = 0;
                OperationDate = "";
                NextOperationDate = "";
                OperationStartDate = "";
                NextOperationStartDate = "";
                OperationEndDate = "";
                NextOperationEndDate = "";
                OperatorName = "";
                NextOperatorName = "";
                Fee = 0;
                NextFee = 0;
                LastOperationID = 0;
                NewOperationID = 0;
                #endregion

                
                PawnList.Clear();
                DBFDataO.Close();
                DBFConnectionO.DisConnect();
                #endregion

               
            }
            
            DBFData.Close();
            DBFConnection.DisConnect();
        }

        private int GetSqlTicketStatusIDbyDBFB_NO(string theB_NO)
        {
            int SqlTicketStatus = 0;
            string OP_TYPE = "0";
            DBFTemp.SetFile(this.DBFPath + "OP_RCD.DBF");
            DBFTemp.Connect();
            DBFResultTemp = DBFTemp.Query("select OP_TYPE from OP_RCD.DBF where B_NO='" + theB_NO + "'");
            DBFDataTemp = DBFResultTemp.GetResult();
            while (DBFDataTemp.Read())
            {
                OP_TYPE = CutSpace(DBFDataTemp[0].ToString());
            }
            DBFDataTemp.Close();

            SqlResultTemp = SqlTemp.Query("select StatusID from DDTicketStatus where Description='" + DBFTicketStatus_TYPEMapping(OP_TYPE) + "'");
            SqlDataTemp = SqlResultTemp.GetResult();
            SqlDataTemp.Read();
            SqlTicketStatus = Convert.ToInt32(CutSpace(SqlDataTemp[0].ToString()));
            SqlDataTemp.Close();

            DBFTemp.DisConnect();
            return SqlTicketStatus;

        }

        private int GetSqlOperationTypebyDBFOP_TYPE(string theOP_TYPE)
        {
            int OperationType = 0;
            SqlResultTemp = SqlTemp.Query("select StatusID from DDTicketStatus where Description='" + DBFOP_TYPEMapping(theOP_TYPE) + "'");
            SqlDataTemp = SqlResultTemp.GetResult();
            SqlDataTemp.Read();
            OperationType = Convert.ToInt32(CutSpace(SqlDataTemp[0].ToString()));
            SqlDataTemp.Close();
            return OperationType;
        }

        private string DBFTicketStatus_TYPEMapping(string theOP_TYPE)
        {
            if (theOP_TYPE == "0")
            {
                return "新当";
            }
            else if (theOP_TYPE == "1")
            {
                return "赎当";
            }
            else if (theOP_TYPE == "2")
            {
                return "续当";
            }
            else if (theOP_TYPE == "3")
            {
                return "绝当";
            }
            else if (theOP_TYPE == "4")
            {
                return "冻结";
            }
            else if (theOP_TYPE == "5")
            {
                return "在库";
            }
            else if (theOP_TYPE == "5")
            {
                return ("清算");
            }
            else return "全部";
        }

        private string DBFOP_TYPEMapping(string theOP_TYPE)
        {
            if (theOP_TYPE == "0")
            {
                return "新当";
            }
            else if (theOP_TYPE == "1")
            {
                return "赎当";
            }
            else if (theOP_TYPE == "2")
            {
                return "续当";
            }
            else if (theOP_TYPE == "3")
            {
                return "绝当";
            }
            else if (theOP_TYPE == "4")
            {
                return "冻结";
            }
            else if (theOP_TYPE == "5")
            {
                return "删除";
            }
            else if (theOP_TYPE == "6")
            {
                return ("清算");
            }
            else return "全部";
        }

        private int GetLastOperationIDbyPawnageID(int PawnageID)
        {
            int i = 0;
            int LastOperationID = 0;
            List <int> OpertaionIDList = new List<int>();
            List<int> NextOperationIDList = new List<int>();

            SqlResultTemp = SqlTemp.Query("select OperationID, NextOperationID from DDOperation where PawnageID='"+PawnageID.ToString()+"'");
            SqlDataTemp = SqlResultTemp.GetResult();
            while (SqlDataTemp.Read())
            {
                OpertaionIDList.Add(Convert.ToInt32(CutSpace(SqlDataTemp[0].ToString())));
                NextOperationIDList.Add(Convert.ToInt32(CutSpace(SqlDataTemp[1].ToString())));
            }
            SqlDataTemp.Close();

            for (i = 0; i < NextOperationIDList.Count; i++)
            {
                if (NextOperationIDList[i] == 0)
                {
                    LastOperationID = OpertaionIDList[i];
                }
            }

            return LastOperationID;
        }

        private int GetTicketIDbyTicketNumber(string TicketNumber)
        {
            int TicketID = 0;
            SqlResultTemp = SqlTemp.Query("select TicketID from DDPawnTicket where TicketNumber='" + TicketNumber + "'");
            SqlDataTemp = SqlResultTemp.GetResult();
            while (SqlDataTemp.Read())
            {
                TicketID = Convert.ToInt32(CutSpace(SqlDataTemp[0].ToString()));
            }
            SqlDataTemp.Close();
            return TicketID;
        }

    }
}
