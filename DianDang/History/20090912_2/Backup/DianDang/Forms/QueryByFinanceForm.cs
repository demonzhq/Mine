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
    public partial class QueryByFinanceForm : DockContent
    {
        public QueryByFinanceForm()
        {
            InitializeComponent();
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
            OperationAmount();
            OperationCount();
        }

        private void OperationAmount()
        {
            DateTime startDate = Convert.ToDateTime(this.tbxStartDate.Text.Trim());
            DateTime endDate = Convert.ToDateTime(this.tbxEndDate.Text.Trim());

            double newPawnAmount = 0;
            double closeOfNewAmount = 0;
            double redeemPawnAmount = 0;
            double renewPawnAmount = 0;
            double closePawnAmount = 0;
            double goldOfClosePawnAmount = 0;
            double clearPawnAmount = 0;
            double clearPawnReckonAmount = 0;
            double reckoningPL = 0;      //清算盈亏
            double unclearPawnAmount = 0;
            double newPawnServiceFee = 0;//建当服务费
            double renewPawnServiceFee = 0;//续当服务费
            double interestFee = 0;    //典当利息
            double overDueFee = 0;     //逾期服务费
            double returnFee = 0;      //返回服务费
            double totalFee = 0;       //总计营收

            int operationType = 0;
            double amount = 0;

            Query queryOperations = new Query(DDOperation.Schema);
            queryOperations.AddBetweenAnd("OperationDate", startDate, endDate);
            DataTable dtOperations = queryOperations.ExecuteDataSet().Tables[0];
            if (dtOperations.Rows.Count > 0)
            {

                for (int i = 0; i < dtOperations.Rows.Count; i++)
                {
                    operationType = Convert.ToInt32(dtOperations.Rows[i]["OperationType"]);
                    amount = Convert.ToDouble(dtOperations.Rows[i]["Amount"]);

                    switch (operationType)
                    {
                        case 1:
                            newPawnAmount += amount;
                            DDPawnTicket newTicket = new DDPawnTicket("TicketID", Convert.ToInt32(dtOperations.Rows[i]["TicketID"]));
                            if (newTicket.StatusID == 4 || newTicket.StatusID == 7)
                            {
                                closeOfNewAmount += amount;
                            }
                            newPawnServiceFee += Convert.ToDouble(dtOperations.Rows[i]["ServiceFee"]);
                            interestFee += Convert.ToDouble(dtOperations.Rows[i]["InterestFee"]);
                            break;
                        case 2:
                            redeemPawnAmount += amount;
                            overDueFee += Convert.ToDouble(dtOperations.Rows[i]["OverdueFee"]);
                            returnFee += Convert.ToDouble(dtOperations.Rows[i]["ReturnFee"]);
                            break;
                        case 3:
                            renewPawnAmount += amount;
                            renewPawnServiceFee += Convert.ToDouble(dtOperations.Rows[i]["ServiceFee"]);
                            interestFee += Convert.ToDouble(dtOperations.Rows[i]["InterestFee"]);
                            break;
                        case 4:
                            closePawnAmount += amount;
                            DDPawnageInfo newPawnage = new DDPawnageInfo("PawnageID", Convert.ToInt32(dtOperations.Rows[i]["PawnageID"]));
                            if (newPawnage.ParentID == 109)  //109:黄金类ClassID
                            {
                                goldOfClosePawnAmount += amount;
                            }
                            break;
                        case 7:
                            clearPawnAmount += amount;
                            clearPawnReckonAmount += Convert.ToDouble(dtOperations.Rows[i]["ReckonAmount"]);
                            break;
                        default:
                            break;
                    }
                }
                reckoningPL = clearPawnReckonAmount - clearPawnAmount;   //清算盈亏
                unclearPawnAmount = closePawnAmount - clearPawnAmount;   //未清算金额
                totalFee = newPawnServiceFee + renewPawnServiceFee + interestFee + overDueFee - returnFee;
            }

            double allNewPawnAmount = 0;
            double closeOfAllNewPawnAmount = 0;

            DDCompanyInfo company = new DDCompanyInfo("CompanyID", 1);
            DateTime setupDate = Convert.ToDateTime(company.SetupDate);
            Query queryAllOperations = new Query(DDOperation.Schema);
            queryAllOperations.AddBetweenAnd("OperationDate", setupDate, endDate);  //所有的操作记录
            DataTable dtAllOperations = queryAllOperations.ExecuteDataSet().Tables[0];
            if (dtAllOperations.Rows.Count > 0)
            {
                for (int j = 0; j < dtAllOperations.Rows.Count; j++)
                {
                    operationType = Convert.ToInt32(dtAllOperations.Rows[j]["OperationType"]);
                    if (operationType == 1)
                    {
                        amount = Convert.ToDouble(dtAllOperations.Rows[j]["Amount"]);
                        allNewPawnAmount += amount;
                        DDPawnTicket newTicket = new DDPawnTicket("TicketID", Convert.ToInt32(dtAllOperations.Rows[j]["TicketID"]));
                        if (newTicket.StatusID == 4 || newTicket.StatusID == 7)
                        {
                            closeOfAllNewPawnAmount += amount;
                        }
                    }

                }
            }
            double startTotalAmount = 0;
            double endTotalAmount = 0;
            double increAmount = 0;
            double totalAmount = 0;

            endTotalAmount = allNewPawnAmount - closeOfAllNewPawnAmount;
            increAmount = newPawnAmount - closeOfNewAmount;
            startTotalAmount = endTotalAmount - increAmount;
            totalAmount = endTotalAmount + unclearPawnAmount;

            double percentCloseOfNewPawn = 0;
            double percentIncreOfStart = 0;
            double percentIncreOfEnd = 0;
            double percentNewPawnServiceFeeOfTotal = 0;
            double percentRenewPawnServiceFeeOfTotal = 0;
            double percentInterestFeeOfTotal = 0;
            double percentRetureFeeOfTotal = 0;
            double percentOverdueFeeOfTotal = 0;

            if (newPawnAmount != 0)
            {
                percentCloseOfNewPawn = closeOfNewAmount*100 / newPawnAmount;
                percentCloseOfNewPawn = Math.Round(percentCloseOfNewPawn, 2);
            }

            if (startTotalAmount != 0)
            {
                percentIncreOfStart = increAmount * 100 / startTotalAmount;
                percentIncreOfStart = Math.Round(percentIncreOfStart, 2);
            }

            if (endTotalAmount != 0)
            {
                percentIncreOfEnd = increAmount * 100 / endTotalAmount;
                percentIncreOfEnd = Math.Round(percentIncreOfEnd, 2);
            }

            if (totalFee != 0)
            {
                percentNewPawnServiceFeeOfTotal = newPawnServiceFee * 100 / totalFee;
                percentNewPawnServiceFeeOfTotal = Math.Round(percentNewPawnServiceFeeOfTotal, 2);
                percentRenewPawnServiceFeeOfTotal = renewPawnServiceFee * 100 / totalFee;
                percentRenewPawnServiceFeeOfTotal = Math.Round(percentRenewPawnServiceFeeOfTotal, 2);
                percentInterestFeeOfTotal = interestFee * 100 / totalFee;
                percentInterestFeeOfTotal = Math.Round(percentInterestFeeOfTotal, 2);
                percentRetureFeeOfTotal = returnFee * 100 / totalFee;
                percentRetureFeeOfTotal = Math.Round(percentRetureFeeOfTotal, 2);
                percentOverdueFeeOfTotal = overDueFee * 100 / totalFee;
                percentOverdueFeeOfTotal = Math.Round(percentOverdueFeeOfTotal, 2);
            }

            this.lblNewPawnAmount.Text = newPawnAmount.ToString();
            this.lblCloseOfNewAmount.Text = closeOfNewAmount.ToString();
            this.lblRenewPawnAmount.Text = renewPawnAmount.ToString();
            this.lblRedeemPawnAmount.Text = redeemPawnAmount.ToString();
            this.lblClosePawnAmount.Text = closePawnAmount.ToString();
            this.lblGoldOfCloseAmount.Text = goldOfClosePawnAmount.ToString();
            this.lblStartTotalAmount.Text = startTotalAmount.ToString();
            this.lblEndTotalAmount.Text = endTotalAmount.ToString();
            this.lblIncreAmount.Text = increAmount.ToString();
            this.lblTotalFee.Text = totalFee.ToString();
            this.lblNewPawnServiceFee.Text = newPawnServiceFee.ToString();
            this.lblRenewPawnServiceFee.Text = renewPawnServiceFee.ToString();
            this.lblInterestFee.Text = interestFee.ToString();
            this.lblOverDueFee.Text = overDueFee.ToString();
            this.lblReturnFee.Text = returnFee.ToString();
            this.lblCloseClearAmount.Text = clearPawnAmount.ToString();  //绝当处理金额
            this.lblClearAmount.Text = clearPawnReckonAmount.ToString(); //清算金额
            this.lblReckoningPL.Text = reckoningPL.ToString();
            this.lblUnclearAmount.Text = unclearPawnAmount.ToString();
            this.lblTotalAmount.Text = totalAmount.ToString();

            this.lblCloseOfNewPercent.Text = percentCloseOfNewPawn.ToString();
            this.lblIncreOfStartPercent.Text = percentIncreOfStart.ToString();
            this.lblIncreOfEndPercent.Text = percentIncreOfEnd.ToString();
            this.lblNewServiceFeeOfTotal.Text = percentNewPawnServiceFeeOfTotal.ToString();
            this.lblRenewServiceFeeOfTotal.Text = percentRenewPawnServiceFeeOfTotal.ToString();
            this.lblInterestFeeOfTotal.Text = percentInterestFeeOfTotal.ToString();
            this.lblReturnfeeOfTotal.Text = percentRetureFeeOfTotal.ToString();
            this.lblOverdueFeeOfTotal.Text = percentOverdueFeeOfTotal.ToString();
        }

        private void OperationCount()
        {
            try
            {
                DateTime startDate = Convert.ToDateTime(this.tbxStartDate.Text.Trim());
                DateTime endDate = Convert.ToDateTime(this.tbxEndDate.Text.Trim());

                int newPawnCount = 0;
                int closeOfNewCount = 0;
                int redeemPawnCount = 0;
                int renewPawnCount = 0;
                int closePawnCount = 0;
                int goldOfClosePawnCount = 0;

                int operationType = 0;

                string selectList = string.Format("{0},{1},{2},{3},{4}", DDOperation.OperationNumberColumn.ColumnName, DDOperation.OperationTypeColumn.ColumnName,DDOperation.PawnageIDColumn.ColumnName,DDOperation.TicketIDColumn.ColumnName,DDOperation.OperationDateColumn.ColumnName);
                Query queryOperations = new Query(DDOperation.Schema).SetSelectList(selectList).AddBetweenAnd("OperationDate", startDate, endDate).ORDER_BY(DDOperation.OperationNumberColumn.ColumnName);
                DataTable dtOperations = queryOperations.ExecuteDataSet().Tables[0];
                if (dtOperations.Rows.Count > 0)
                {
                    string operationNumber = "0";
                    string preOperationNumber = "0";
                    for (int i = 0; i < dtOperations.Rows.Count; i++)
                    {
                        operationNumber=dtOperations.Rows[i]["OperationNumber"].ToString();

                        if (operationNumber != preOperationNumber)
                        {
                            operationType = Convert.ToInt32(dtOperations.Rows[i]["OperationType"]);
                            switch (operationType)
                            {
                                case 1:
                                    newPawnCount++;
                                    DDPawnTicket newTicket = new DDPawnTicket("TicketID", Convert.ToInt32(dtOperations.Rows[i]["TicketID"]));
                                    if (newTicket.StatusID == 4 || newTicket.StatusID == 7)
                                    {
                                        closeOfNewCount++;
                                    }
                                    break;
                                case 2:
                                    redeemPawnCount++;
                                    break;
                                case 3:
                                    renewPawnCount++;
                                    break;
                                case 4:
                                    closePawnCount++;
                                    DDPawnageInfo newPawnage = new DDPawnageInfo("PawnageID", Convert.ToInt32(dtOperations.Rows[i]["PawnageID"]));
                                    if (newPawnage.ParentID == 109)  //109:黄金类ClassID
                                    {
                                        goldOfClosePawnCount++;
                                    }
                                    break;
                                default:
                                    break;
                            }
                            preOperationNumber = operationNumber;
                        }
                    }
                }

                double allNewPawnCount = 0;
                double closeOfAllNewPawnCount = 0;

                DDCompanyInfo company = new DDCompanyInfo("CompanyID", 1);
                DateTime setupDate = Convert.ToDateTime(company.SetupDate);
                Query queryAllOperations = new Query(DDOperation.Schema).SetSelectList(selectList).DISTINCT().ORDER_BY(DDOperation.OperationNumberColumn.ColumnName);
                queryAllOperations.AddBetweenAnd("OperationDate", setupDate, endDate);  //所有的操作记录
                DataTable dtAllOperations = queryAllOperations.ExecuteDataSet().Tables[0];
                if (dtAllOperations.Rows.Count > 0)
                {
                    string operationNumber = "0";
                    string preOperationNumber = "0";

                    for (int j = 0; j < dtAllOperations.Rows.Count; j++)
                    {
                        operationNumber = dtOperations.Rows[j]["OperationNumber"].ToString();
                        if (operationNumber != preOperationNumber)
                        {
                            operationType = Convert.ToInt32(dtAllOperations.Rows[j]["OperationType"]);
                            if (operationType == 1)
                            {
                                allNewPawnCount++;
                                DDPawnTicket newTicket = new DDPawnTicket("TicketID", Convert.ToInt32(dtAllOperations.Rows[j]["TicketID"]));
                                if (newTicket.StatusID == 4 || newTicket.StatusID == 7)
                                {
                                    closeOfAllNewPawnCount++;
                                }
                            }
                            preOperationNumber = operationNumber;
                        }

                    }
                }

                double startTotalCount = 0;
                double endTotalCount = 0;
                double increCount = 0;
                endTotalCount = allNewPawnCount - closeOfAllNewPawnCount;
                increCount = newPawnCount - closeOfNewCount;
                startTotalCount = endTotalCount - increCount;

                this.lblNewPawnCount.Text = newPawnCount.ToString();
                this.lblCloseOfNewCount.Text = closeOfNewCount.ToString();
                this.lblRenewPawnCount.Text = renewPawnCount.ToString();
                this.lblRedeemPawnCount.Text = redeemPawnCount.ToString();
                this.lblClosePawnCount.Text = closePawnCount.ToString();
                this.lblGoldOfCloseCount.Text = goldOfClosePawnCount.ToString();
                this.lblStartTotalCount.Text = startTotalCount.ToString();
                this.lblEndTotalCount.Text = endTotalCount.ToString();
                this.lblIncreCount.Text = increCount.ToString();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private int textBoxNumber = 0;

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

        //打印

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern long BitBlt (IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);
        private Bitmap memoryImage;
        private void CaptureScreen()
        {
            Graphics mygraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, mygraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            IntPtr dc1 = mygraphics.GetHdc();
            IntPtr dc2 = memoryGraphics.GetHdc();
            BitBlt(dc2, 0, 0, this.ClientRectangle.Width, 410, dc1, 0, 0, 13369376);
            mygraphics.ReleaseHdc(dc1);
            memoryGraphics.ReleaseHdc(dc2);
        }
        private void printDocument1_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                CaptureScreen();
                printDocument1.Print();
                MessageBox.Show(this, "打印成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show(this, "打印失败，请检查打印机是否连接正确！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }          
        }
    }
}