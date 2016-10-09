using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using SubSonic;


namespace DianDang
{
    public partial class QueryByClassForm : DockContent
    {
        public QueryByClassForm(int type)
        {
            InitializeComponent();
            InitTabText(type);
            InitGridTable();
        }

        private int m_ClassType;
        private void InitTabText(int type)
        {
            m_ClassType = type;
            switch (type)
            {
                case 0:
                    this.TabText = "当品标准分类统计";
                    this.Text = "当品标准分类统计";
                    break;
                case 1:
                    this.TabText = "当品统计分类统计";
                    this.Text = "当品统计分类统计";
                    break;
                default:
                    break;
            }
        }

        private DataTable m_GridTable = new DataTable();
        private void InitGridTable()
        {
            //set columns names
            m_GridTable.Columns.Add("Class", typeof(System.String));
            m_GridTable.Columns.Add("StartCount", typeof(System.String));
            m_GridTable.Columns.Add("StartWeight", typeof(System.String));
            m_GridTable.Columns.Add("StartAmount", typeof(System.String));

         
            m_GridTable.Columns.Add("StartUnclearCount", typeof(System.String));
            m_GridTable.Columns.Add("StartUnclearWeight", typeof(System.String));
            m_GridTable.Columns.Add("StartUnclearAmount", typeof(System.String));

           
            m_GridTable.Columns.Add("ClearCount", typeof(System.String));
            m_GridTable.Columns.Add("ClearWeight", typeof(System.String));
            m_GridTable.Columns.Add("ClearAmount", typeof(System.String));
            
            m_GridTable.Columns.Add("NewCount", typeof(System.String));
            m_GridTable.Columns.Add("NewWeight", typeof(System.String));
            m_GridTable.Columns.Add("NewAmount", typeof(System.String));
            
            m_GridTable.Columns.Add("RedeemCount", typeof(System.String));
            m_GridTable.Columns.Add("RedeemWeight", typeof(System.String));
            m_GridTable.Columns.Add("RedeemAmount", typeof(System.String));
            
            m_GridTable.Columns.Add("RenewCount", typeof(System.String));
            m_GridTable.Columns.Add("RenewWeight", typeof(System.String));
            m_GridTable.Columns.Add("RenewAmount", typeof(System.String));
            
            m_GridTable.Columns.Add("CloseCount", typeof(System.String));
            m_GridTable.Columns.Add("CloseWeight", typeof(System.String));
            m_GridTable.Columns.Add("CloseAmount", typeof(System.String));
            
            m_GridTable.Columns.Add("EndInScheduleCount", typeof(System.String));
            m_GridTable.Columns.Add("EndInScheduleWeight", typeof(System.String));
            m_GridTable.Columns.Add("EndInScheduleAmount", typeof(System.String));
            
            m_GridTable.Columns.Add("EndOverdueCount", typeof(System.String));
            m_GridTable.Columns.Add("EndOverdueWeight", typeof(System.String));
            m_GridTable.Columns.Add("EndOverdueAmount", typeof(System.String));

            m_GridTable.Columns.Add("EndCount", typeof(System.String));
            m_GridTable.Columns.Add("EndWeight", typeof(System.String));
            m_GridTable.Columns.Add("EndAmount", typeof(System.String));

            m_GridTable.Columns.Add("EndUnclearCount", typeof(System.String));
            m_GridTable.Columns.Add("EndUnclearWeight", typeof(System.String));
            m_GridTable.Columns.Add("EndUnclearAmount", typeof(System.String));

            m_GridTable.Columns.Add("EndStoredCount", typeof(System.String));
            m_GridTable.Columns.Add("EndStoredWeight", typeof(System.String));
            m_GridTable.Columns.Add("EndStoredAmount", typeof(System.String));
        }

        private int textBoxNumber;

        private void tbxStartDate_Click(object sender, EventArgs e)
        {
            textBoxNumber = 1;
            this.monthCalendar1.Visible = true;
        }

        private void tbxEndDate_Click(object sender, EventArgs e)
        {
            textBoxNumber = 2;
            this.monthCalendar1.Visible = true;
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
                switch (textBoxNumber)
                {
                    case 1:
                        this.tbxStartDate.Text = _date;
                        break;
                    case 2:
                        this.tbxEndDate.Text = _date;
                        break;
                    default:
                        break;
                }
                //如果选中日期就自动隐藏MonthCalendar控件
                monthCalendar1.Hide();
            }
        }


        //private void InitStandardClassSource()
        //{
        //    DateTime startDate = Convert.ToDateTime(this.tbxStartDate.Text.Trim());
        //    DateTime endDate = Convert.ToDateTime(this.tbxEndDate.Text.Trim());

        //    Query queryClass = new Query(DDPawnageClass.Schema);
        //    queryClass.AddWhere("ParentID", 0);
        //    DataTable dtClass = queryClass.ExecuteDataSet().Tables[0];
        //    if (dtClass.Rows.Count > 0)
        //    {
        //        int parentClassID;
        //        string parentClassName;
        //        for (int i = 0; i < dtClass.Rows.Count; i++)
        //        {
        //            parentClassID = Convert.ToInt32(dtClass.Rows[i]["ClassID"]);
        //            parentClassName = dtClass.Rows[i]["ClassName"].ToString();

        //            double startCount = 0, startWeight = 0, startAmount = 0;
        //            double startUnclearCount = 0, startUnclearWeight = 0, startUnclearAmount = 0;
        //            double clearCount = 0, clearWeight = 0, clearAmount = 0;
        //            double newCount = 0, newWeight = 0, newAmount = 0;
        //            double redeemCount = 0, redeemWeight = 0, redeemAmount = 0;
        //            double renewCount = 0, renewWeight = 0, renewAmount = 0;
        //            double closeCount = 0, closeWeight = 0, closeAmount = 0;
        //            double endInScheduleCount = 0, endInScheduleWeight = 0, endInScheduleAmount = 0;
        //            double endOverdueCount = 0, endOverdueWeight = 0, endOverdueAmount = 0;
        //            double endCount = 0, endWeight = 0, endAmount = 0;
        //            double endUnclearCount = 0, endUnclearWeight = 0, endUnclearAmount = 0;
        //            double endStoredCount = 0, endStoredWeight = 0, endStoredAmount = 0;

        //            Query queryPawnageInfo = new Query(DDPawnageInfo.Schema);
        //            queryPawnageInfo.AddWhere("ParentID", parentClassID);
        //            DataTable dtPawnageInfo = queryPawnageInfo.ExecuteDataSet().Tables[0];
        //            if (dtPawnageInfo.Rows.Count > 0)
        //            {
        //                for (int j = 0; j < dtPawnageInfo.Rows.Count; j++)
        //                {
        //                    Query queryTicketPawnage = new Query(DDTicketPawnage.Schema);
        //                    queryTicketPawnage.AddWhere("PawnageID", Convert.ToInt32(dtPawnageInfo.Rows[j]["PawnageID"]));
        //                    DataTable dtTicketPawnage = queryTicketPawnage.ExecuteDataSet().Tables[0];
        //                    if (dtTicketPawnage.Rows.Count > 0)
        //                    {
        //                        for (int k = 0; k < dtTicketPawnage.Rows.Count; k++)
        //                        {
        //                            DDPawnTicket pawnTicket = new DDPawnTicket("TicketID", Convert.ToInt32(dtTicketPawnage.Rows[k]["TicketID"]));
        //                            DateTime operateDate = Convert.ToDateTime(pawnTicket.OperateDate);
        //                            int startValue = operateDate.CompareTo(startDate);
        //                            if (startValue < 0)   //operateDate<startDate,期初
        //                            {
        //                                switch (pawnTicket.StatusID)
        //                                {
        //                                    case 1:
        //                                        startCount += Convert.ToDouble(dtPawnageInfo.Rows[j]["CountNumber"]);
        //                                        startWeight += Convert.ToDouble(dtPawnageInfo.Rows[j]["Weight"]);
        //                                        startAmount += Convert.ToDouble(dtPawnageInfo.Rows[j]["Amount"]);
        //                                        break;
        //                                    case 2:
        //                                        startCount += Convert.ToDouble(dtPawnageInfo.Rows[j]["CountNumber"]);
        //                                        startWeight += Convert.ToDouble(dtPawnageInfo.Rows[j]["Weight"]);
        //                                        startAmount += Convert.ToDouble(dtPawnageInfo.Rows[j]["Amount"]);
        //                                        break;
        //                                    case 4:
        //                                        startUnclearCount += Convert.ToDouble(dtPawnageInfo.Rows[j]["CountNumber"]);
        //                                        startUnclearWeight += Convert.ToDouble(dtPawnageInfo.Rows[j]["Weight"]);
        //                                        startUnclearAmount += Convert.ToDouble(dtPawnageInfo.Rows[j]["Amount"]);
        //                                        break;
        //                                    default:
        //                                        break;
        //                                }
        //                            }

        //                            int endValue = operateDate.CompareTo(endDate);
        //                            if (startValue >= 0 && endValue <= 0)    //期内
        //                            {
        //                                switch (pawnTicket.StatusID)
        //                                {
        //                                    case 1:
        //                                        newCount += Convert.ToDouble(dtPawnageInfo.Rows[j]["CountNumber"]);
        //                                        newWeight += Convert.ToDouble(dtPawnageInfo.Rows[j]["Weight"]);
        //                                        newAmount += Convert.ToDouble(dtPawnageInfo.Rows[j]["Amount"]);
        //                                        break;
        //                                    case 2:
        //                                        redeemCount += Convert.ToDouble(dtPawnageInfo.Rows[j]["CountNumber"]);
        //                                        redeemWeight += Convert.ToDouble(dtPawnageInfo.Rows[j]["Weight"]);
        //                                        redeemAmount += Convert.ToDouble(dtPawnageInfo.Rows[j]["Amount"]);
        //                                        break;
        //                                    case 3:
        //                                        renewCount += Convert.ToDouble(dtPawnageInfo.Rows[j]["CountNumber"]);
        //                                        renewWeight += Convert.ToDouble(dtPawnageInfo.Rows[j]["Weight"]);
        //                                        renewAmount += Convert.ToDouble(dtPawnageInfo.Rows[j]["Amount"]);
        //                                        break;
        //                                    case 4:
        //                                        closeCount += Convert.ToDouble(dtPawnageInfo.Rows[j]["CountNumber"]);
        //                                        closeWeight += Convert.ToDouble(dtPawnageInfo.Rows[j]["Weight"]);
        //                                        closeAmount += Convert.ToDouble(dtPawnageInfo.Rows[j]["Amount"]);
        //                                        break;
        //                                    case 7:
        //                                        clearCount += Convert.ToDouble(dtPawnageInfo.Rows[j]["CountNumber"]);
        //                                        clearWeight += Convert.ToDouble(dtPawnageInfo.Rows[j]["Weight"]);
        //                                        clearAmount += Convert.ToDouble(dtPawnageInfo.Rows[j]["Amount"]);
        //                                        break;
        //                                    default:
        //                                        break;
        //                                }
        //                            }

        //                            DateTime ticketEndDate = Convert.ToDateTime(pawnTicket.EndDate);
        //                            int intOverdue = ticketEndDate.CompareTo(endDate);
        //                            if (endValue <= 0)   //期末
        //                            {
        //                                switch (pawnTicket.StatusID)
        //                                {
        //                                    case 1:
        //                                        endCount += Convert.ToDouble(dtPawnageInfo.Rows[j]["CountNumber"]);
        //                                        endWeight += Convert.ToDouble(dtPawnageInfo.Rows[j]["Weight"]);
        //                                        endAmount += Convert.ToDouble(dtPawnageInfo.Rows[j]["Amount"]);
        //                                        if (intOverdue >= 0)   //期末在期
        //                                        {
        //                                            endInScheduleCount += Convert.ToDouble(dtPawnageInfo.Rows[j]["CountNumber"]);
        //                                            endInScheduleWeight += Convert.ToDouble(dtPawnageInfo.Rows[j]["Weight"]);
        //                                            endInScheduleAmount += Convert.ToDouble(dtPawnageInfo.Rows[j]["Amount"]);
        //                                        }
        //                                        else
        //                                        {
        //                                            endOverdueCount += Convert.ToDouble(dtPawnageInfo.Rows[j]["CountNumber"]);
        //                                            endOverdueWeight += Convert.ToDouble(dtPawnageInfo.Rows[j]["Weight"]);
        //                                            endOverdueAmount += Convert.ToDouble(dtPawnageInfo.Rows[j]["Amount"]);
        //                                        }
        //                                        break;
        //                                    case 2:
        //                                        endCount += Convert.ToDouble(dtPawnageInfo.Rows[j]["CountNumber"]);
        //                                        endWeight += Convert.ToDouble(dtPawnageInfo.Rows[j]["Weight"]);
        //                                        endAmount += Convert.ToDouble(dtPawnageInfo.Rows[j]["Amount"]);
        //                                        if (intOverdue >= 0)   //期末在期
        //                                        {
        //                                            endInScheduleCount += Convert.ToDouble(dtPawnageInfo.Rows[j]["CountNumber"]);
        //                                            endInScheduleWeight += Convert.ToDouble(dtPawnageInfo.Rows[j]["Weight"]);
        //                                            endInScheduleAmount += Convert.ToDouble(dtPawnageInfo.Rows[j]["Amount"]);
        //                                        }
        //                                        else
        //                                        {
        //                                            endOverdueCount += Convert.ToDouble(dtPawnageInfo.Rows[j]["CountNumber"]);
        //                                            endOverdueWeight += Convert.ToDouble(dtPawnageInfo.Rows[j]["Weight"]);
        //                                            endOverdueAmount += Convert.ToDouble(dtPawnageInfo.Rows[j]["Amount"]);
        //                                        }
        //                                        break;
        //                                    case 4:
        //                                        endUnclearCount += Convert.ToDouble(dtPawnageInfo.Rows[j]["CountNumber"]);
        //                                        endUnclearWeight += Convert.ToDouble(dtPawnageInfo.Rows[j]["Weight"]);
        //                                        endUnclearAmount += Convert.ToDouble(dtPawnageInfo.Rows[j]["Amount"]);
        //                                        break;
        //                                    default:
        //                                        break;
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //                endStoredAmount = endAmount + endUnclearAmount;
        //                endStoredCount = endCount + endUnclearCount;
        //                endStoredWeight = endWeight + endStoredWeight;
        //            }

        //            //Add Rows
        //            DataRow drow = m_GridTable.NewRow();
        //            drow["Class"] = parentClassName;
        //            drow["StartCount"] = startCount;
        //            drow["StartWeight"] = startWeight;
        //            drow["StartAmount"] = startAmount;

        //            drow["StartUnclearCount"] = startUnclearCount;
        //            drow["StartUnclearWeight"] = startUnclearWeight;
        //            drow["StartUnclearAmount"] = startUnclearAmount;

        //            drow["ClearCount"] = clearCount;
        //            drow["ClearWeight"] = clearWeight;
        //            drow["ClearAmount"] = clearAmount;

        //            drow["NewCount"] = newCount;
        //            drow["NewWeight"] = newWeight;
        //            drow["NewAmount"] = newAmount;

        //            drow["RedeemCount"] = redeemCount;
        //            drow["RedeemWeight"] = redeemWeight;
        //            drow["RedeemAmount"] = redeemAmount;

        //            drow["RenewCount"] = renewCount;
        //            drow["RenewWeight"] = renewWeight;
        //            drow["RenewAmount"] = renewAmount;

        //            drow["CloseCount"] = closeCount;
        //            drow["CloseWeight"] = closeWeight;
        //            drow["CloseAmount"] = closeAmount;

        //            drow["EndInScheduleCount"] = endInScheduleCount;
        //            drow["EndInScheduleWeight"] = endInScheduleWeight;
        //            drow["EndInScheduleAmount"] = endInScheduleAmount;

        //            drow["EndOverdueCount"] = endOverdueCount;
        //            drow["EndOverdueWeight"] = endOverdueWeight;
        //            drow["EndOverdueAmount"] = endOverdueAmount;

        //            drow["EndCount"] = endCount;
        //            drow["EndWeight"] = endWeight;
        //            drow["EndAmount"] = endAmount;

        //            drow["EndUnclearCount"] = endUnclearCount;
        //            drow["EndUnclearWeight"] = endUnclearWeight;
        //            drow["EndUnclearAmount"] = endUnclearAmount;

        //            drow["EndStoredCount"] = endStoredCount;
        //            drow["EndStoredWeight"] = endStoredWeight;
        //            drow["EndStoredAmount"] = endStoredAmount;
        //            m_GridTable.Rows.Add(drow);

        //        }

        //    }
        //}


        private void InitStandardClassSource()
        {
            DateTime startDate = Convert.ToDateTime(this.tbxStartDate.Text.Trim());
            DateTime endDate = Convert.ToDateTime(this.tbxEndDate.Text.Trim());

            Query queryClass = new Query(DDPawnageClass.Schema);
            queryClass.AddWhere("ParentID", 0);
            DataTable dtClass = queryClass.ExecuteDataSet().Tables[0];
            if (dtClass.Rows.Count > 0)
            {
                int parentClassID;
                string parentClassName;
                for (int i = 0; i < dtClass.Rows.Count; i++)
                {
                    parentClassID = Convert.ToInt32(dtClass.Rows[i]["ClassID"]);
                    parentClassName = dtClass.Rows[i]["ClassName"].ToString();

                    double startCount = 0, startWeight = 0, startAmount = 0;
                    double startNewCount = 0, startNewWeight = 0, startNewAmount = 0;
                    double startRedeemCount = 0, startRedeemWeight = 0, startRedeemAmount = 0;
                    double startCloseCount = 0, startCloseWeight = 0, startCloseAmount = 0;
                    double startClearCount = 0, startClearWeight = 0, startClearAmount = 0;
                    double startUnclearCount = 0, startUnclearWeight = 0, startUnclearAmount = 0;
                    double clearCount = 0, clearWeight = 0, clearAmount = 0;
                    double newCount = 0, newWeight = 0, newAmount = 0;
                    double redeemCount = 0, redeemWeight = 0, redeemAmount = 0;
                    double renewCount = 0, renewWeight = 0, renewAmount = 0;
                    double closeCount = 0, closeWeight = 0, closeAmount = 0;
                    double endInScheduleCount = 0, endInScheduleWeight = 0, endInScheduleAmount = 0;
                    double endOverdueCount = 0, endOverdueWeight = 0, endOverdueAmount = 0;
                    double endCount = 0, endWeight = 0, endAmount = 0;
                    double endCloseCount = 0, endCloseWeight = 0, endCloseAmount = 0;
                    double endClearCount = 0, endClearWeight = 0, endClearAmount = 0;
                    double endUnclearCount = 0, endUnclearWeight = 0, endUnclearAmount = 0;
                    double endStoredCount = 0, endStoredWeight = 0, endStoredAmount = 0;

                    Query queryPawnageInfo = new Query(DDPawnageInfo.Schema);
                    queryPawnageInfo.AddWhere("ParentID", parentClassID);
                    DataTable dtPawnageInfo = queryPawnageInfo.ExecuteDataSet().Tables[0];
                    if (dtPawnageInfo.Rows.Count > 0)
                    {
                        for (int j = 0; j < dtPawnageInfo.Rows.Count; j++)
                        {
                            Query queryOperations = new Query(DDOperation.Schema);
                            queryOperations.AddWhere("PawnageID", Convert.ToInt32(dtPawnageInfo.Rows[j]["PawnageID"]));
                            DataTable dtOperations = queryOperations.ExecuteDataSet().Tables[0];

                            if (dtOperations.Rows.Count > 0)
                            {
                                for (int k = 0; k < dtOperations.Rows.Count; k++)
                                {
                                    DateTime operateDate = Convert.ToDateTime(dtOperations.Rows[k]["OperationDate"]);
                                    int startValue = operateDate.CompareTo(startDate);
                                    int operationType = Convert.ToInt32(dtOperations.Rows[k]["OperationType"]);
                                    if (startValue < 0)   //operateDate<startDate,期初
                                    {

                                        switch (operationType)
                                        {
                                            case 1:
                                                startNewCount += Convert.ToDouble(dtPawnageInfo.Rows[j]["CountNumber"]);
                                                startNewWeight += Convert.ToDouble(dtPawnageInfo.Rows[j]["Weight"]);
                                                startNewAmount += Convert.ToDouble(dtOperations.Rows[k]["Amount"]);
                                                break;
                                            case 2:
                                                startRedeemCount += Convert.ToDouble(dtPawnageInfo.Rows[j]["CountNumber"]);
                                                startRedeemWeight += Convert.ToDouble(dtPawnageInfo.Rows[j]["Weight"]);
                                                startRedeemAmount += Convert.ToDouble(dtOperations.Rows[k]["Amount"]);
                                                break;
                                            case 4:
                                                startCloseCount += Convert.ToDouble(dtPawnageInfo.Rows[j]["CountNumber"]);
                                                startCloseWeight += Convert.ToDouble(dtPawnageInfo.Rows[j]["Weight"]);
                                                startCloseAmount += Convert.ToDouble(dtOperations.Rows[k]["Amount"]);
                                                break;
                                            case 7:
                                                startClearCount += Convert.ToDouble(dtPawnageInfo.Rows[j]["CountNumber"]);
                                                startClearWeight += Convert.ToDouble(dtPawnageInfo.Rows[j]["Weight"]);
                                                startClearAmount += Convert.ToDouble(dtOperations.Rows[k]["Amount"]);
                                                break;
                                            default:
                                                break;
                                        }
                                    }

                                    int endValue = operateDate.CompareTo(endDate);
                                    if (startValue >= 0 && endValue <= 0)    //期内
                                    {
                                        switch (operationType)
                                        {
                                            case 1:
                                                newCount += Convert.ToDouble(dtPawnageInfo.Rows[j]["CountNumber"]);
                                                newWeight += Convert.ToDouble(dtPawnageInfo.Rows[j]["Weight"]);
                                                newAmount += Convert.ToDouble(dtOperations.Rows[k]["Amount"]);
                                                break;
                                            case 2:
                                                redeemCount += Convert.ToDouble(dtPawnageInfo.Rows[j]["CountNumber"]);
                                                redeemWeight += Convert.ToDouble(dtPawnageInfo.Rows[j]["Weight"]);
                                                redeemAmount += Convert.ToDouble(dtOperations.Rows[k]["Amount"]);
                                                break;
                                            case 3:
                                                renewCount += Convert.ToDouble(dtPawnageInfo.Rows[j]["CountNumber"]);
                                                renewWeight += Convert.ToDouble(dtPawnageInfo.Rows[j]["Weight"]);
                                                renewAmount += Convert.ToDouble(dtOperations.Rows[k]["Amount"]);
                                                break;
                                            case 4:
                                                closeCount += Convert.ToDouble(dtPawnageInfo.Rows[j]["CountNumber"]);
                                                closeWeight += Convert.ToDouble(dtPawnageInfo.Rows[j]["Weight"]);
                                                closeAmount += Convert.ToDouble(dtOperations.Rows[k]["Amount"]);
                                                break;
                                            case 7:
                                                clearCount += Convert.ToDouble(dtPawnageInfo.Rows[j]["CountNumber"]);
                                                clearWeight += Convert.ToDouble(dtPawnageInfo.Rows[j]["Weight"]);
                                                clearAmount += Convert.ToDouble(dtOperations.Rows[k]["Amount"]);
                                                break;
                                            default:
                                                break;
                                        }
                                    }

                                    
                                    if (endValue <= 0)   //期末
                                    {
                                        DDPawnTicket newTicket = new DDPawnTicket("TicketID", Convert.ToInt32(dtOperations.Rows[k]["TicketID"]));
                                        DateTime ticketEndDate = Convert.ToDateTime(newTicket.EndDate);
                                        int intOverdue = ticketEndDate.CompareTo(endDate);
                                        switch (operationType)
                                        {
                                            case 1:
                                                if (intOverdue >= 0)   //期末在期
                                                {
                                                    endInScheduleCount += Convert.ToDouble(dtPawnageInfo.Rows[j]["CountNumber"]);
                                                    endInScheduleWeight += Convert.ToDouble(dtPawnageInfo.Rows[j]["Weight"]);
                                                    endInScheduleAmount += Convert.ToDouble(dtOperations.Rows[k]["Amount"]);
                                                }
                                                else
                                                {
                                                    endOverdueCount += Convert.ToDouble(dtPawnageInfo.Rows[j]["CountNumber"]);
                                                    endOverdueWeight += Convert.ToDouble(dtPawnageInfo.Rows[j]["Weight"]);
                                                    endOverdueAmount += Convert.ToDouble(dtOperations.Rows[k]["Amount"]);
                                                }
                                                break;
                                            case 2:
                                                if (intOverdue >= 0)   //期末在期
                                                {
                                                    endInScheduleCount -= Convert.ToDouble(dtPawnageInfo.Rows[j]["CountNumber"]);
                                                    endInScheduleWeight -= Convert.ToDouble(dtPawnageInfo.Rows[j]["Weight"]);
                                                    endInScheduleAmount -= Convert.ToDouble(dtOperations.Rows[k]["Amount"]);
                                                }
                                                else
                                                {
                                                    endOverdueCount -= Convert.ToDouble(dtPawnageInfo.Rows[j]["CountNumber"]);
                                                    endOverdueWeight -= Convert.ToDouble(dtPawnageInfo.Rows[j]["Weight"]);
                                                    endOverdueAmount -= Convert.ToDouble(dtOperations.Rows[k]["Amount"]);
                                                }
                                                break;
                                            case 4:
                                                if (intOverdue >= 0)   //期末在期
                                                {
                                                    endInScheduleCount -= Convert.ToDouble(dtPawnageInfo.Rows[j]["CountNumber"]);
                                                    endInScheduleWeight -= Convert.ToDouble(dtPawnageInfo.Rows[j]["Weight"]);
                                                    endInScheduleAmount -= Convert.ToDouble(dtOperations.Rows[k]["Amount"]);
                                                }
                                                else
                                                {
                                                    endOverdueCount -= Convert.ToDouble(dtPawnageInfo.Rows[j]["CountNumber"]);
                                                    endOverdueWeight -= Convert.ToDouble(dtPawnageInfo.Rows[j]["Weight"]);
                                                    endOverdueAmount -= Convert.ToDouble(dtOperations.Rows[k]["Amount"]);
                                                }
                                                endCloseCount += Convert.ToDouble(dtPawnageInfo.Rows[j]["CountNumber"]);
                                                endCloseWeight += Convert.ToDouble(dtPawnageInfo.Rows[j]["Weight"]);
                                                endCloseAmount += Convert.ToDouble(dtOperations.Rows[k]["Amount"]);
                                                break;
                                            case 7:
                                                endClearCount += Convert.ToDouble(dtPawnageInfo.Rows[j]["CountNumber"]);
                                                endClearWeight += Convert.ToDouble(dtPawnageInfo.Rows[j]["Weight"]);
                                                endClearAmount += Convert.ToDouble(dtOperations.Rows[k]["Amount"]);
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                }
                                
                            }
                        }                        
                    }

                    //Add Rows
                    DataRow drow = m_GridTable.NewRow();
                    drow["Class"] = parentClassName;

                    startCount = startNewCount - startCloseCount-startRedeemCount;
                    startWeight = startNewWeight - startCloseWeight-startRedeemWeight;
                    startAmount = startNewAmount - startCloseAmount-startRedeemAmount;
                    drow["StartCount"] = startCount;
                    drow["StartWeight"] = startWeight;
                    drow["StartAmount"] = startAmount;

                    startUnclearAmount = startCloseAmount - startClearAmount;
                    startUnclearCount = startCloseCount - startClearCount;
                    startUnclearWeight = startCloseWeight - startClearWeight;
                    drow["StartUnclearCount"] = startUnclearCount;
                    drow["StartUnclearWeight"] = startUnclearWeight;
                    drow["StartUnclearAmount"] = startUnclearAmount;

                    drow["ClearCount"] = clearCount;
                    drow["ClearWeight"] = clearWeight;
                    drow["ClearAmount"] = clearAmount;

                    drow["NewCount"] = newCount;
                    drow["NewWeight"] = newWeight;
                    drow["NewAmount"] = newAmount;

                    drow["RedeemCount"] = redeemCount;
                    drow["RedeemWeight"] = redeemWeight;
                    drow["RedeemAmount"] = redeemAmount;

                    drow["RenewCount"] = renewCount;
                    drow["RenewWeight"] = renewWeight;
                    drow["RenewAmount"] = renewAmount;

                    drow["CloseCount"] = closeCount;
                    drow["CloseWeight"] = closeWeight;
                    drow["CloseAmount"] = closeAmount;

                    drow["EndInScheduleCount"] = endInScheduleCount;
                    drow["EndInScheduleWeight"] = endInScheduleWeight;
                    drow["EndInScheduleAmount"] = endInScheduleAmount;

                    drow["EndOverdueCount"] = endOverdueCount;
                    drow["EndOverdueWeight"] = endOverdueWeight;
                    drow["EndOverdueAmount"] = endOverdueAmount;

                    endAmount = endInScheduleAmount + endOverdueAmount;
                    endCount = endInScheduleCount + endOverdueCount;
                    endWeight = endInScheduleWeight + endOverdueWeight;
                    drow["EndCount"] = endCount;
                    drow["EndWeight"] = endWeight;
                    drow["EndAmount"] = endAmount;

                    endUnclearAmount = endCloseAmount - endClearAmount;
                    endUnclearCount = endCloseCount - endClearCount;
                    endUnclearWeight = endCloseWeight - endClearWeight;
                    drow["EndUnclearCount"] = endUnclearCount;
                    drow["EndUnclearWeight"] = endUnclearWeight;
                    drow["EndUnclearAmount"] = endUnclearAmount;

                    endStoredAmount = endInScheduleAmount + endOverdueAmount + endUnclearAmount;
                    endStoredCount = endInScheduleCount + endOverdueCount + endUnclearCount;
                    endStoredWeight = endInScheduleWeight + endOverdueWeight + endUnclearWeight;
                    drow["EndStoredCount"] = endStoredCount;
                    drow["EndStoredWeight"] = endStoredWeight;
                    drow["EndStoredAmount"] = endStoredAmount;
                    m_GridTable.Rows.Add(drow);

                }

            }
        }

        private void InitStatisticClassSource()
        {
            DateTime startDate = Convert.ToDateTime(this.tbxStartDate.Text.Trim());
            DateTime endDate = Convert.ToDateTime(this.tbxEndDate.Text.Trim());

            Query queryStatisticClass = new Query(DDStatisticClass.Schema);
            DataTable dtStatisticClass = queryStatisticClass.ExecuteDataSet().Tables[0];
            if (dtStatisticClass.Rows.Count > 0)
            {
                int statisticClassID;
                string statisticClassName;

                for (int m = 0; m < dtStatisticClass.Rows.Count; m++)
                {
                    statisticClassID = Convert.ToInt32(dtStatisticClass.Rows[m]["ClassID"]);
                    statisticClassName = dtStatisticClass.Rows[m]["ClassName"].ToString();

                    double startCount = 0, startWeight = 0, startAmount = 0;
                    double startNewCount = 0, startNewWeight = 0, startNewAmount = 0;
                    double startRedeemCount = 0, startRedeemWeight = 0, startRedeemAmount = 0;
                    double startCloseCount = 0, startCloseWeight = 0, startCloseAmount = 0;
                    double startClearCount = 0, startClearWeight = 0, startClearAmount = 0;
                    double startUnclearCount = 0, startUnclearWeight = 0, startUnclearAmount = 0;
                    double clearCount = 0, clearWeight = 0, clearAmount = 0;
                    double newCount = 0, newWeight = 0, newAmount = 0;
                    double redeemCount = 0, redeemWeight = 0, redeemAmount = 0;
                    double renewCount = 0, renewWeight = 0, renewAmount = 0;
                    double closeCount = 0, closeWeight = 0, closeAmount = 0;
                    double endInScheduleCount = 0, endInScheduleWeight = 0, endInScheduleAmount = 0;
                    double endOverdueCount = 0, endOverdueWeight = 0, endOverdueAmount = 0;
                    double endCount = 0, endWeight = 0, endAmount = 0;
                    double endCloseCount = 0, endCloseWeight = 0, endCloseAmount = 0;
                    double endClearCount = 0, endClearWeight = 0, endClearAmount = 0;
                    double endUnclearCount = 0, endUnclearWeight = 0, endUnclearAmount = 0;
                    double endStoredCount = 0, endStoredWeight = 0, endStoredAmount = 0;
                    
                    Query queryClass = new Query(DDPawnageClass.Schema);
                    queryClass.AddWhere("StatisticClassID", statisticClassID);
                    DataTable dtClass = queryClass.ExecuteDataSet().Tables[0];
                    if (dtClass.Rows.Count > 0)
                    {
                        int parentClassID;
                        for (int i = 0; i < dtClass.Rows.Count; i++)
                        {
                            parentClassID = Convert.ToInt32(dtClass.Rows[i]["ClassID"]);                      

                            Query queryPawnageInfo = new Query(DDPawnageInfo.Schema);
                            queryPawnageInfo.AddWhere("ParentID", parentClassID);
                            DataTable dtPawnageInfo = queryPawnageInfo.ExecuteDataSet().Tables[0];
                            if (dtPawnageInfo.Rows.Count > 0)
                            {
                                for (int j = 0; j < dtPawnageInfo.Rows.Count; j++)
                                {
                                    Query queryOperations = new Query(DDOperation.Schema);
                                    queryOperations.AddWhere("PawnageID", Convert.ToInt32(dtPawnageInfo.Rows[j]["PawnageID"]));
                                    DataTable dtOperations = queryOperations.ExecuteDataSet().Tables[0];

                                    if (dtOperations.Rows.Count > 0)
                                    {
                                        for (int k = 0; k < dtOperations.Rows.Count; k++)
                                        {
                                            DateTime operateDate = Convert.ToDateTime(dtOperations.Rows[k]["OperationDate"]);
                                            int startValue = operateDate.CompareTo(startDate);
                                            int operationType = Convert.ToInt32(dtOperations.Rows[k]["OperationType"]);
                                            if (startValue < 0)   //operateDate<startDate,期初
                                            {

                                                switch (operationType)
                                                {
                                                    case 1:
                                                        startNewCount += Convert.ToDouble(dtPawnageInfo.Rows[j]["CountNumber"]);
                                                        startNewWeight += Convert.ToDouble(dtPawnageInfo.Rows[j]["Weight"]);
                                                        startNewAmount += Convert.ToDouble(dtOperations.Rows[k]["Amount"]);
                                                        break;
                                                    case 2:
                                                        startRedeemCount += Convert.ToDouble(dtPawnageInfo.Rows[j]["CountNumber"]);
                                                        startRedeemWeight += Convert.ToDouble(dtPawnageInfo.Rows[j]["Weight"]);
                                                        startRedeemAmount += Convert.ToDouble(dtOperations.Rows[k]["Amount"]);
                                                        break;
                                                    case 4:
                                                        startCloseCount += Convert.ToDouble(dtPawnageInfo.Rows[j]["CountNumber"]);
                                                        startCloseWeight += Convert.ToDouble(dtPawnageInfo.Rows[j]["Weight"]);
                                                        startCloseAmount += Convert.ToDouble(dtOperations.Rows[k]["Amount"]);
                                                        break;
                                                    case 7:
                                                        startClearCount += Convert.ToDouble(dtPawnageInfo.Rows[j]["CountNumber"]);
                                                        startClearWeight += Convert.ToDouble(dtPawnageInfo.Rows[j]["Weight"]);
                                                        startClearAmount += Convert.ToDouble(dtOperations.Rows[k]["Amount"]);
                                                        break;
                                                    default:
                                                        break;
                                                }
                                            }

                                            int endValue = operateDate.CompareTo(endDate);
                                            if (startValue >= 0 && endValue <= 0)    //期内
                                            {
                                                switch (operationType)
                                                {
                                                    case 1:
                                                        newCount += Convert.ToDouble(dtPawnageInfo.Rows[j]["CountNumber"]);
                                                        newWeight += Convert.ToDouble(dtPawnageInfo.Rows[j]["Weight"]);
                                                        newAmount += Convert.ToDouble(dtOperations.Rows[k]["Amount"]);
                                                        break;
                                                    case 2:
                                                        redeemCount += Convert.ToDouble(dtPawnageInfo.Rows[j]["CountNumber"]);
                                                        redeemWeight += Convert.ToDouble(dtPawnageInfo.Rows[j]["Weight"]);
                                                        redeemAmount += Convert.ToDouble(dtOperations.Rows[k]["Amount"]);
                                                        break;
                                                    case 3:
                                                        renewCount += Convert.ToDouble(dtPawnageInfo.Rows[j]["CountNumber"]);
                                                        renewWeight += Convert.ToDouble(dtPawnageInfo.Rows[j]["Weight"]);
                                                        renewAmount += Convert.ToDouble(dtOperations.Rows[k]["Amount"]);
                                                        break;
                                                    case 4:
                                                        closeCount += Convert.ToDouble(dtPawnageInfo.Rows[j]["CountNumber"]);
                                                        closeWeight += Convert.ToDouble(dtPawnageInfo.Rows[j]["Weight"]);
                                                        closeAmount += Convert.ToDouble(dtOperations.Rows[k]["Amount"]);
                                                        break;
                                                    case 7:
                                                        clearCount += Convert.ToDouble(dtPawnageInfo.Rows[j]["CountNumber"]);
                                                        clearWeight += Convert.ToDouble(dtPawnageInfo.Rows[j]["Weight"]);
                                                        clearAmount += Convert.ToDouble(dtOperations.Rows[k]["Amount"]);
                                                        break;
                                                    default:
                                                        break;
                                                }
                                            }


                                            if (endValue <= 0)   //期末
                                            {
                                                DDPawnTicket newTicket = new DDPawnTicket("TicketID", Convert.ToInt32(dtOperations.Rows[k]["TicketID"]));
                                                DateTime ticketEndDate = Convert.ToDateTime(newTicket.EndDate);
                                                int intOverdue = ticketEndDate.CompareTo(endDate);
                                                switch (operationType)
                                                {
                                                    case 1:                                                        
                                                        if (intOverdue >= 0)   //期末在期
                                                        {
                                                            endInScheduleCount += Convert.ToDouble(dtPawnageInfo.Rows[j]["CountNumber"]);
                                                            endInScheduleWeight += Convert.ToDouble(dtPawnageInfo.Rows[j]["Weight"]);
                                                            endInScheduleAmount += Convert.ToDouble(dtOperations.Rows[k]["Amount"]);
                                                        }
                                                        else
                                                        {
                                                            endOverdueCount += Convert.ToDouble(dtPawnageInfo.Rows[j]["CountNumber"]);
                                                            endOverdueWeight += Convert.ToDouble(dtPawnageInfo.Rows[j]["Weight"]);
                                                            endOverdueAmount += Convert.ToDouble(dtOperations.Rows[k]["Amount"]);
                                                        }
                                                        break;
                                                    case 2:                                                        
                                                        if (intOverdue >= 0)   //期末在期
                                                        {
                                                            endInScheduleCount -= Convert.ToDouble(dtPawnageInfo.Rows[j]["CountNumber"]);
                                                            endInScheduleWeight -= Convert.ToDouble(dtPawnageInfo.Rows[j]["Weight"]);
                                                            endInScheduleAmount -= Convert.ToDouble(dtOperations.Rows[k]["Amount"]);
                                                        }
                                                        else
                                                        {
                                                            endOverdueCount -= Convert.ToDouble(dtPawnageInfo.Rows[j]["CountNumber"]);
                                                            endOverdueWeight -= Convert.ToDouble(dtPawnageInfo.Rows[j]["Weight"]);
                                                            endOverdueAmount -= Convert.ToDouble(dtOperations.Rows[k]["Amount"]);
                                                        }
                                                        break;
                                                    case 4:
                                                        if (intOverdue >= 0)   //期末在期
                                                        {
                                                            endInScheduleCount -= Convert.ToDouble(dtPawnageInfo.Rows[j]["CountNumber"]);
                                                            endInScheduleWeight -= Convert.ToDouble(dtPawnageInfo.Rows[j]["Weight"]);
                                                            endInScheduleAmount -= Convert.ToDouble(dtOperations.Rows[k]["Amount"]);
                                                        }
                                                        else
                                                        {
                                                            endOverdueCount -= Convert.ToDouble(dtPawnageInfo.Rows[j]["CountNumber"]);
                                                            endOverdueWeight -= Convert.ToDouble(dtPawnageInfo.Rows[j]["Weight"]);
                                                            endOverdueAmount -= Convert.ToDouble(dtOperations.Rows[k]["Amount"]);
                                                        }
                                                        endCloseCount += Convert.ToDouble(dtPawnageInfo.Rows[j]["CountNumber"]);
                                                        endCloseWeight += Convert.ToDouble(dtPawnageInfo.Rows[j]["Weight"]);
                                                        endCloseAmount += Convert.ToDouble(dtOperations.Rows[k]["Amount"]);
                                                        break;
                                                    case 7:
                                                        endClearCount += Convert.ToDouble(dtPawnageInfo.Rows[j]["CountNumber"]);
                                                        endClearWeight += Convert.ToDouble(dtPawnageInfo.Rows[j]["Weight"]);
                                                        endClearAmount += Convert.ToDouble(dtOperations.Rows[k]["Amount"]);
                                                        break;
                                                    default:
                                                        break;
                                                }
                                            }
                                        }

                                    }
                                }
                            }                            

                        }     
                    }
                    //Add Rows
                    DataRow drow = m_GridTable.NewRow();
                    drow["Class"] = statisticClassName;

                    startCount = startNewCount - startRedeemCount-startCloseCount;
                    startWeight = startNewWeight - startRedeemWeight-startCloseWeight;
                    startAmount = startNewAmount - startRedeemAmount-startCloseAmount;
                    drow["StartCount"] = startCount;
                    drow["StartWeight"] = startWeight;
                    drow["StartAmount"] = startAmount;

                    startUnclearAmount = startCloseAmount - startClearAmount;
                    startUnclearCount = startCloseCount - startClearCount;
                    startUnclearWeight = startCloseWeight - startClearWeight;
                    drow["StartUnclearCount"] = startUnclearCount;
                    drow["StartUnclearWeight"] = startUnclearWeight;
                    drow["StartUnclearAmount"] = startUnclearAmount;

                    drow["ClearCount"] = clearCount;
                    drow["ClearWeight"] = clearWeight;
                    drow["ClearAmount"] = clearAmount;

                    drow["NewCount"] = newCount;
                    drow["NewWeight"] = newWeight;
                    drow["NewAmount"] = newAmount;

                    drow["RedeemCount"] = redeemCount;
                    drow["RedeemWeight"] = redeemWeight;
                    drow["RedeemAmount"] = redeemAmount;

                    drow["RenewCount"] = renewCount;
                    drow["RenewWeight"] = renewWeight;
                    drow["RenewAmount"] = renewAmount;

                    drow["CloseCount"] = closeCount;
                    drow["CloseWeight"] = closeWeight;
                    drow["CloseAmount"] = closeAmount;

                    drow["EndInScheduleCount"] = endInScheduleCount;
                    drow["EndInScheduleWeight"] = endInScheduleWeight;
                    drow["EndInScheduleAmount"] = endInScheduleAmount;

                    drow["EndOverdueCount"] = endOverdueCount;
                    drow["EndOverdueWeight"] = endOverdueWeight;
                    drow["EndOverdueAmount"] = endOverdueAmount;

                    endAmount = endInScheduleAmount + endOverdueAmount;
                    endCount = endInScheduleCount + endOverdueCount;
                    endWeight = endInScheduleWeight + endOverdueWeight;
                    drow["EndCount"] = endCount;
                    drow["EndWeight"] = endWeight;
                    drow["EndAmount"] = endAmount;

                    endUnclearAmount = endCloseAmount - endClearAmount;
                    endUnclearCount = endCloseCount - endClearCount;
                    endUnclearWeight = endCloseWeight - endClearWeight;
                    drow["EndUnclearCount"] = endUnclearCount;
                    drow["EndUnclearWeight"] = endUnclearWeight;
                    drow["EndUnclearAmount"] = endUnclearAmount;

                    endStoredAmount = endAmount + endUnclearAmount;
                    endStoredCount = endCount + endUnclearCount;
                    endStoredWeight = endWeight + endUnclearWeight;
                    drow["EndStoredCount"] = endStoredCount;
                    drow["EndStoredWeight"] = endStoredWeight;
                    drow["EndStoredAmount"] = endStoredAmount;
                    m_GridTable.Rows.Add(drow);
                }
            }
        }

        private void ClearDataGridView()
        {
            for (int i =multiColHeaderDgv1.Rows.Count - 1; i > -1; i--)
            {
                DataGridViewRow dgr = multiColHeaderDgv1.Rows[i];
                multiColHeaderDgv1.Rows.Remove(dgr);
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (this.tbxStartDate.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, "请选择起始日期！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.tbxEndDate.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, "请选择终止日期！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ClearDataGridView();
            switch (m_ClassType)
            {
                case 0:
                    InitStandardClassSource();
                    break;
                case 1:
                    InitStatisticClassSource();
                    //CreateChart(this.zedGraphControl1);
                    break;
                default:
                    break;
            }              
            this.multiColHeaderDgv1.DataSource = m_GridTable;    
            

        }

        private DataGridViewPrinter MyDataGridViewPrinter;

        private bool SetupThePrinting()
        {
            PrintDialog MyPrintDialog = new PrintDialog();
            MyPrintDialog.AllowCurrentPage = false;
            MyPrintDialog.AllowPrintToFile = false;
            MyPrintDialog.AllowSelection = false;
            MyPrintDialog.AllowSomePages = false;
            MyPrintDialog.PrintToFile = false;
            MyPrintDialog.ShowHelp = false;
            MyPrintDialog.ShowNetwork = false;

            if (MyPrintDialog.ShowDialog() != DialogResult.OK)
                return false;

            MyPrintDocument.DocumentName = this.TabText;
            MyPrintDocument.PrinterSettings =
                                MyPrintDialog.PrinterSettings;
            MyPrintDocument.DefaultPageSettings =
            MyPrintDialog.PrinterSettings.DefaultPageSettings;
            MyPrintDocument.DefaultPageSettings.Margins =
                             new Margins(40, 40, 40, 40);

            string strTitle = this.TabText + "(" + this.tbxStartDate.Text + "至" + this.tbxEndDate.Text + ")";
            MyDataGridViewPrinter = new DataGridViewPrinter(multiColHeaderDgv1, MyPrintDocument, true, true, strTitle, new Font("Tahoma", 12, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            return true;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (SetupThePrinting())
            {
                MyPrintDocument.Print();
            }

        }

        private void MyPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            bool more = MyDataGridViewPrinter.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;

        }
    }
}