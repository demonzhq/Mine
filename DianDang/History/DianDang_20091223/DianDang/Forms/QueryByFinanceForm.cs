using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MSExcel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;
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
                MessageBox.Show(this, "��ѡ����ʼ���ڣ�", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.tbxEndDate.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, "��ѡ����ֹ���ڣ�", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            double reckoningPL = 0;      //����ӯ��
            double unclearPawnAmount = 0;
            double newPawnServiceFee = 0;//���������
            double renewPawnServiceFee = 0;//���������
            double interestFee = 0;    //�䵱��Ϣ
            double overDueFee = 0;     //���ڷ����
            double returnFee = 0;      //���ط����
            double totalFee = 0;       //�ܼ�Ӫ��

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
                            interestFee += Convert.ToDouble(dtOperations.Rows[i]["InterestFee"]);
                            break;
                        case 3:
                            renewPawnAmount += amount;
                            renewPawnServiceFee += Convert.ToDouble(dtOperations.Rows[i]["ServiceFee"]);
                            interestFee += Convert.ToDouble(dtOperations.Rows[i]["InterestFee"]);
                            break;
                        case 4:
                            closePawnAmount += amount;
                            DDPawnageInfo newPawnage = new DDPawnageInfo("PawnageID", Convert.ToInt32(dtOperations.Rows[i]["PawnageID"]));
                            if (newPawnage.ParentID == 2)  //2:�ƽ���ClassID
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
                reckoningPL = clearPawnReckonAmount - clearPawnAmount;   //����ӯ��
                unclearPawnAmount = closePawnAmount - clearPawnAmount;   //δ������
                totalFee = newPawnServiceFee + renewPawnServiceFee + interestFee + overDueFee - returnFee;
            }

            double allNewPawnAmount = 0;
            //double closeOfAllNewPawnAmount = 0;
            double allRedeemPawnAmount = 0;
            double allClosePawnAmount = 0;

            DDCompanyInfo company = new DDCompanyInfo("CompanyID", 1);
            DateTime setupDate = Convert.ToDateTime(company.SetupDate);
            Query queryAllOperations = new Query(DDOperation.Schema);
            queryAllOperations.AddBetweenAnd("OperationDate", setupDate, endDate);  //���еĲ�����¼
            DataTable dtAllOperations = queryAllOperations.ExecuteDataSet().Tables[0];
            if (dtAllOperations.Rows.Count > 0)
            {
                for (int j = 0; j < dtAllOperations.Rows.Count; j++)
                {
                    operationType = Convert.ToInt32(dtAllOperations.Rows[j]["OperationType"]);
                    amount = Convert.ToDouble(dtAllOperations.Rows[j]["Amount"]);
                    if (operationType == 1)
                    {                       
                        allNewPawnAmount += amount;
                        //DDPawnTicket newTicket = new DDPawnTicket("TicketID", Convert.ToInt32(dtAllOperations.Rows[j]["TicketID"]));
                        //if (newTicket.StatusID == 4 || newTicket.StatusID == 7)
                        //{
                        //    closeOfAllNewPawnAmount += amount;
                        //}
                    }
                    if (operationType == 2)
                    {
                        allRedeemPawnAmount += amount;
                    }
                    if (operationType == 4)
                    {
                        allClosePawnAmount += amount;
                    }

                }
            }
            double startTotalAmount = 0;
            double endTotalAmount = 0;
            double increAmount = 0;
            double totalAmount = 0;

            endTotalAmount = allNewPawnAmount - allClosePawnAmount-allRedeemPawnAmount;
            increAmount = newPawnAmount - closePawnAmount - redeemPawnAmount;
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
                percentCloseOfNewPawn = DianDangFunction.myRound(percentCloseOfNewPawn, 2);
            }

            if (startTotalAmount != 0)
            {
                percentIncreOfStart = increAmount * 100 / startTotalAmount;
                percentIncreOfStart = DianDangFunction.myRound(percentIncreOfStart, 2);
            }

            if (endTotalAmount != 0)
            {
                percentIncreOfEnd = increAmount * 100 / endTotalAmount;
                percentIncreOfEnd = DianDangFunction.myRound(percentIncreOfEnd, 2);
            }

            if (totalFee != 0)
            {
                percentNewPawnServiceFeeOfTotal = newPawnServiceFee * 100 / totalFee;
                percentNewPawnServiceFeeOfTotal = DianDangFunction.myRound(percentNewPawnServiceFeeOfTotal, 2);
                percentRenewPawnServiceFeeOfTotal = renewPawnServiceFee * 100 / totalFee;
                percentRenewPawnServiceFeeOfTotal = DianDangFunction.myRound(percentRenewPawnServiceFeeOfTotal, 2);
                percentInterestFeeOfTotal = interestFee * 100 / totalFee;
                percentInterestFeeOfTotal = DianDangFunction.myRound(percentInterestFeeOfTotal, 2);
                percentRetureFeeOfTotal = returnFee * 100 / totalFee;
                percentRetureFeeOfTotal = DianDangFunction.myRound(percentRetureFeeOfTotal, 2);
                percentOverdueFeeOfTotal = overDueFee * 100 / totalFee;
                percentOverdueFeeOfTotal = DianDangFunction.myRound(percentOverdueFeeOfTotal, 2);
            }

            this.lblNewPawnAmount.Text = newPawnAmount.ToString();
            this.lblCloseOfNewAmount.Text = closeOfNewAmount.ToString();
            this.lblRenewPawnAmount.Text = renewPawnAmount.ToString();
            this.lblSalesSize.Text = (newPawnAmount + renewPawnAmount).ToString();
            this.lblRedeemPawnAmount.Text = redeemPawnAmount.ToString();
            this.lblClosePawnAmount.Text = closePawnAmount.ToString();
            this.lblGoldOfCloseAmount.Text = goldOfClosePawnAmount.ToString();
            this.lblStartTotalAmount.Text = startTotalAmount.ToString();
            this.lblEndTotalAmount.Text = endTotalAmount.ToString();
            this.lblIncreAmount.Text = increAmount.ToString();
            this.lblTotalFee.Text = totalFee.ToString();
            newPawnServiceFee = DianDangFunction.myRound(newPawnServiceFee, 2);
            this.lblNewPawnServiceFee.Text = newPawnServiceFee.ToString();
            this.lblRenewPawnServiceFee.Text = renewPawnServiceFee.ToString();
            this.lblInterestFee.Text = interestFee.ToString();
            this.lblOverDueFee.Text = overDueFee.ToString();
            this.lblReturnFee.Text = returnFee.ToString();
            this.lblCloseClearAmount.Text = clearPawnAmount.ToString();  //����������
            this.lblClearAmount.Text = clearPawnReckonAmount.ToString(); //������
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
                                    if (newPawnage.ParentID == 2)  //109:�ƽ���ClassID
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
                //double closeOfAllNewPawnCount = 0;
                double allRedeemPawnCount=0;
                double allClosePawnCount =0;

                DDCompanyInfo company = new DDCompanyInfo("CompanyID", 1);
                DateTime setupDate = Convert.ToDateTime(company.SetupDate);
                Query queryAllOperations = new Query(DDOperation.Schema).SetSelectList(selectList).DISTINCT().ORDER_BY(DDOperation.OperationNumberColumn.ColumnName);
                queryAllOperations.AddBetweenAnd("OperationDate", setupDate, endDate);  //���еĲ�����¼
                DataTable dtAllOperations = queryAllOperations.ExecuteDataSet().Tables[0];
                if (dtAllOperations.Rows.Count > 0)
                {
                    string operationNumber = "0";
                    string preOperationNumber = "0";

                    for (int j = 0; j < dtAllOperations.Rows.Count; j++)
                    {
                        operationNumber = dtAllOperations.Rows[j]["OperationNumber"].ToString();
                        if (operationNumber != preOperationNumber)
                        {
                            operationType = Convert.ToInt32(dtAllOperations.Rows[j]["OperationType"]);
                            if (operationType == 1)
                            {
                                allNewPawnCount++;
                            //    DDPawnTicket newTicket = new DDPawnTicket("TicketID", Convert.ToInt32(dtAllOperations.Rows[j]["TicketID"]));
                            //    if (newTicket.StatusID == 4 || newTicket.StatusID == 7)
                            //    {
                            //        closeOfAllNewPawnCount++;
                            //    }
                            }
                            if (operationType == 2)
                            {
                                allRedeemPawnCount ++;
                            }
                            if (operationType == 4)
                            {
                                allClosePawnCount++;
                            }
                            preOperationNumber = operationNumber;
                        }

                    }
                }

                double startTotalCount = 0;
                double endTotalCount = 0;
                double increCount = 0;
                endTotalCount = allNewPawnCount -allRedeemPawnCount-allClosePawnCount;
                increCount = newPawnCount-redeemPawnCount-closePawnCount ;
                startTotalCount = endTotalCount - increCount;

                this.lblNewPawnCount.Text = newPawnCount.ToString();
                this.lblCloseOfNewCount.Text = closeOfNewCount.ToString();
                this.lblRenewPawnCount.Text = renewPawnCount.ToString();
                this.lblSalesCount.Text = (newPawnCount + renewPawnCount).ToString();
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
                //���ѡ�����ھ��Զ�����MonthCalendar�ؼ�
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

        //��ӡ

        private void LoadTemplate()
        {
            object path;
            path = Application.StartupPath + @"FinanceTemplate.dd";
            MSExcel.Application excelApp; //ExcelӦ�ó������
            MSExcel.Workbook excelDoc; //Excel�ĵ�����
            excelApp = new MSExcel.ApplicationClass();  //��ʼ��
            //����ʹ�õ���COM�⣬�������������Ҫ��Nothing����
            Object Nothing = Missing.Value;
            excelDoc = excelApp.Workbooks._Open(Application.StartupPath + @"\\FinanceTemplate.dd", Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

            //ʹ�õ�һ����������Ϊ�������ݵĹ�����
            MSExcel.Worksheet ws = (MSExcel.Worksheet)excelDoc.Sheets[1];

            //����һ��MSExcel.Range ���͵ı���r
            MSExcel.Range r;

            r = ws.get_Range(("B" + 2), ("B" + 2)); r.Value2 = this.tbxStartDate.Text;
            r = ws.get_Range(("D" + 2), ("D" + 2)); r.Value2 = this.tbxEndDate.Text;

            r = ws.get_Range(("B" + 4), ("B" + 4)); r.Value2 = this.lblNewPawnAmount.Text;            
            r = ws.get_Range(("B" + 5), ("B" + 5)); r.Value2 = this.lblCloseOfNewAmount.Text;
            r = ws.get_Range(("B" + 6), ("B" + 6)); r.Value2 = this.lblRenewPawnAmount.Text;
            r = ws.get_Range(("B" + 7), ("B" + 7)); r.Value2 = this.lblSalesSize.Text;
            r = ws.get_Range(("B" + 8), ("B" + 8)); r.Value2 = this.lblRedeemPawnAmount.Text;
            r = ws.get_Range(("B" + 9), ("B" + 9)); r.Value2 = this.lblClosePawnAmount.Text;
            r = ws.get_Range(("B" + 10), ("B" + 10)); r.Value2 = this.lblGoldOfCloseAmount.Text;
            r = ws.get_Range(("B" + 12), ("B" + 12)); r.Value2 = this.lblStartTotalAmount.Text;
            r = ws.get_Range(("B" + 13), ("B" + 13)); r.Value2 = this.lblEndTotalAmount.Text;
            r = ws.get_Range(("B" + 14), ("B" + 14)); r.Value2 = this.lblIncreAmount.Text;

            r = ws.get_Range(("D" + 4), ("D" + 4)); r.Value2 = this.lblNewPawnCount.Text;
            r = ws.get_Range(("D" + 5), ("D" + 5)); r.Value2 = this.lblCloseOfNewCount.Text;
            r = ws.get_Range(("D" + 6), ("D" + 6)); r.Value2 = this.lblRenewPawnCount.Text;
            r = ws.get_Range(("D" + 7), ("D" + 7)); r.Value2 = this.lblSalesCount.Text;
            r = ws.get_Range(("D" + 8), ("D" + 8)); r.Value2 = this.lblRedeemPawnCount.Text;
            r = ws.get_Range(("D" + 9), ("D" + 9)); r.Value2 = this.lblClosePawnCount.Text;
            r = ws.get_Range(("D" + 10), ("D" + 10)); r.Value2 = this.lblGoldOfCloseCount.Text;
            r = ws.get_Range(("D" + 12), ("D" + 12)); r.Value2 = this.lblStartTotalCount.Text;
            r = ws.get_Range(("D" + 13), ("D" + 13)); r.Value2 = this.lblEndTotalCount.Text;
            r = ws.get_Range(("D" + 14), ("D" + 14)); r.Value2 = this.lblIncreCount.Text;
            r = ws.get_Range(("G" + 14), ("G" + 14)); r.Value2 = this.lblIncreOfStartPercent.Text;
            r = ws.get_Range(("J" + 14), ("J" + 14)); r.Value2 = this.lblIncreOfEndPercent.Text;

            r = ws.get_Range(("B" + 15), ("B" + 15)); r.Value2 = this.lblTotalFee.Text;
            r = ws.get_Range(("B" + 16), ("B" + 16)); r.Value2 = this.lblNewPawnServiceFee.Text;
            r = ws.get_Range(("B" + 17), ("B" + 17)); r.Value2 = this.lblRenewPawnServiceFee.Text;
            r = ws.get_Range(("B" + 18), ("B" + 18)); r.Value2 = this.lblInterestFee.Text;
            r = ws.get_Range(("B" + 19), ("B" + 19)); r.Value2 = this.lblOverDueFee.Text;
            r = ws.get_Range(("B" + 20), ("B" + 20)); r.Value2 = this.lblReturnFee.Text;
            r = ws.get_Range(("B" + 21), ("B" + 21)); r.Value2 = this.lblOtherFee.Text;

            r = ws.get_Range(("G" + 16), ("G" + 16)); r.Value2 = this.lblNewServiceFeeOfTotal.Text;
            r = ws.get_Range(("G" + 17), ("G" + 17)); r.Value2 = this.lblRenewServiceFeeOfTotal.Text;
            r = ws.get_Range(("G" + 18), ("G" + 18)); r.Value2 = this.lblInterestFeeOfTotal.Text;
            r = ws.get_Range(("G" + 19), ("G" + 19)); r.Value2 = this.lblOverdueFeeOfTotal.Text;
            r = ws.get_Range(("G" + 20), ("G" + 20)); r.Value2 = this.lblReturnfeeOfTotal.Text;
            r = ws.get_Range(("G" + 21), ("G" + 21)); r.Value2 = this.lblOtherFeeOfTotal.Text;

            r = ws.get_Range(("B" + 22), ("B" + 22)); r.Value2 = this.lblCloseClearAmount.Text;
            r = ws.get_Range(("H" + 22), ("H" + 22)); r.Value2 = this.lblClearAmount.Text;
            r = ws.get_Range(("L" + 22), ("L" + 22)); r.Value2 = this.lblReckoningPL.Text;
            r = ws.get_Range(("B" + 23), ("B" + 23)); r.Value2 = this.lblUnclearAmount.Text;
            r = ws.get_Range(("H" + 23), ("H" + 23)); r.Value2 = this.lblTotalAmount.Text;

            //WdSaveFormatΪExcel�ĵ��ı����ʽ
            object format = MSExcel.XlFileFormat.xlWorkbookNormal;

            excelDoc.PrintOut(Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing);


            //��excelDoc�ĵ���������ݱ���Ϊdd�ĵ�
            //excelDoc.Save();
            if (File.Exists(Application.StartupPath + @"\dump.dd"))
            {
                try
                {
                    File.Delete(Application.StartupPath + @"\dump.dd");
                }
                catch (FieldAccessException e)
                {
                    MessageBox.Show("��¼�ļ����ڱ�ʹ�ã����˳�Excel\n" + e.ToString());
                }
            }
            excelDoc.SaveAs(Application.StartupPath + @"\dump.dd", format, Nothing, Nothing, Nothing, Nothing, MSExcel.XlSaveAsAccessMode.xlExclusive, Nothing, Nothing, Nothing, Nothing, Nothing);
            
            //�ر�excelDoc�ĵ����� 
            excelDoc.Close(Nothing, Nothing, Nothing);

            //�ر�excelApp������� 
            excelApp.Quit();
            //MessageBox.Show("���ɳɹ�");
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                LoadTemplate();
                MessageBox.Show(this, "��ӡ�ɹ���", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show(this, "��ӡʧ�ܣ������ӡ���Ƿ�������ȷ��", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }          
        }
    }
}