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
using SubSonic;

namespace DianDang
{
    public partial class RedeemPawnPrintPreviewForm : Form
    {

        public RedeemPawnPrintPreviewForm(int iTicketID, string strOperationNumber)
        {
            InitializeComponent();
            m_OperationNumber = strOperationNumber;
            m_TicketID = iTicketID;
            LoadTemplate(m_TicketID, m_OperationNumber);
        }

        private int m_TicketID;
        private string m_OperationNumber;
        //private void PrintReceipt()
        //{
        //    ReceiptPrintViewForm frmReceiptPrintView = new ReceiptPrintViewForm(m_TicketID,m_OperationNumber);
        //}

        ToChineseValue newChinese = new ToChineseValue();


        private void LoadTemplate_Ori(int iTicketID, string strOperationNumber)
        {
            double TotalAmount = 0;
            double TotalServiceFee = 0;
            double TotalLastInterestFee = 0;

            DDPawnTicket newTicket = new DDPawnTicket("TicketID", m_TicketID);

            Query queryOperation = new Query(DDOperation.Schema);
            queryOperation.AddWhere("TicketID", m_TicketID);
            queryOperation.AddWhere("OperationNumber", strOperationNumber);
            queryOperation.AddWhere("OperationType", Comparison.NotEquals, 6);
            DataTable dtOperation = queryOperation.ExecuteDataSet().Tables[0];

            for (int i = 0; i < dtOperation.Rows.Count; i++)
            {
                TotalAmount += Convert.ToDouble(dtOperation.Rows[i]["Amount"].ToString());
                TotalServiceFee += Convert.ToDouble(dtOperation.Rows[i]["ServiceFee"].ToString());
                TotalLastInterestFee += Convert.ToDouble(dtOperation.Rows[i]["InterestFee"].ToString());
            }
            TotalAmount = DianDangFunction.myRound(TotalAmount, MainForm.AmountAccuracy);
            TotalServiceFee = DianDangFunction.myRound(TotalServiceFee, MainForm.AmountAccuracy);
            TotalLastInterestFee = DianDangFunction.myRound(TotalLastInterestFee, MainForm.AmountAccuracy);


            MSExcel.Application excelApp; //Excel应用程序变量
            MSExcel.Workbook excelDoc; //Excel文档变量
            excelApp = new MSExcel.ApplicationClass();  //初始化
            //由于使用的是COM库，因此有许多变量需要用Nothing代替
            Object Nothing = Missing.Value;
            excelDoc = excelApp.Workbooks._Open(Application.StartupPath + @"\Pram\RedeemTemplate.dd", Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

            //使用第一个工作表作为插入数据的工作表
            MSExcel.Worksheet ws = (MSExcel.Worksheet)excelDoc.Sheets[1];

            //声明一个MSExcel.Range 类型的变量r
            MSExcel.Range r;

            DDCompanyInfo company = new DDCompanyInfo("CompanyID", 1);
            //this.lblCompanyName.Text = company.CompanyName;
            //this.lblOldTicketNumber.Text = frmRedeemPawnOperation.lblOldTicketNum.Text;
            r = ws.get_Range(("F" + 4), ("F" + 4)); r.Value2 = company.CompanyName;
            r = ws.get_Range(("M" + 4), ("M" + 4)); r.Value2 = newTicket.TicketNumber.ToString();
;
            DDCustomerInfo newCustomer = new DDCustomerInfo("CustomerID", newTicket.CustomerID);
            //this.lblCustomerName.Text = newCustomer.CustomerName;
            //this.lblContactPerson.Text = newCustomer.ContactPerson;
            r = ws.get_Range(("F" + 5), ("F" + 5)); r.Value2 = newCustomer.CustomerName;
            r = ws.get_Range(("M" + 5), ("M" + 5)); r.Value2 = newCustomer.ContactPerson;

            //this.lblAmount.Text = frmRedeemPawnOperation.tbxTotalAmount.Text;
            //this.lblAmountChinese.Text = newChinese.toChineseChar(Convert.ToDecimal(frmRedeemPawnOperation.tbxTotalAmount.Text));
            //this.lblServiceFee.Text = frmRedeemPawnOperation.tbxServiceFee.Text;
            //this.lblServiceFeeChinese.Text = newChinese.toChineseChar(Convert.ToDecimal(frmRedeemPawnOperation.tbxServiceFee.Text));
            //this.lblPaidInterestFee.Text = frmRedeemPawnOperation.lblPaidInterest.Text;
            //this.lblPaidInterestFeeChinese.Text = newChinese.toChineseChar(Convert.ToDecimal(frmRedeemPawnOperation.lblPaidInterest.Text));
            r = ws.get_Range(("M" + 6), ("M" + 6)); r.Value2 = TotalAmount.ToString("0.00");
            r = ws.get_Range(("H" + 6), ("H" + 6)); r.Value2 = newChinese.toChineseChar(Convert.ToDecimal(TotalAmount));
            r = ws.get_Range(("M" + 7), ("M" + 7)); r.Value2 = TotalServiceFee.ToString("0.00");
            r = ws.get_Range(("H" + 7), ("H" + 7)); r.Value2 = newChinese.toChineseChar(Convert.ToDecimal(TotalServiceFee));
            r = ws.get_Range(("M" + 8), ("M" + 8)); r.Value2 = TotalLastInterestFee.ToString("0.00");
            r = ws.get_Range(("H" + 8), ("H" + 8)); r.Value2 = newChinese.toChineseChar(Convert.ToDecimal(TotalLastInterestFee));

            double totalPaidFee = TotalServiceFee + TotalLastInterestFee;
            //this.lblPaidFee.Text = totalPaidFee.ToString();
            //this.lblPaidFeeChinese.Text = newChinese.toChineseChar(Convert.ToDecimal(totalPaidFee));
            r = ws.get_Range(("H" + 9), ("H" + 9)); r.Value2 = newChinese.toChineseChar(Convert.ToDecimal(totalPaidFee));
            r = ws.get_Range(("M" + 9), ("M" + 9)); r.Value2 = totalPaidFee.ToString("0.00");

            DateTime startDate = Convert.ToDateTime(dtOperation.Rows[0]["StartDate"].ToString());
            DateTime endDate = Convert.ToDateTime(dtOperation.Rows[0]["EndDate"].ToString());
            DateTime operationDate = Convert.ToDateTime(dtOperation.Rows[0]["OperationDate"].ToString());
            //this.lblStartYear.Text = startDate.Year.ToString();
            //this.lblStartMonth.Text = startDate.Month.ToString();
            //this.lblStartDay.Text = startDate.Day.ToString();
            //this.lblEndYear.Text = endDate.Year.ToString();
            //this.lblEndMonth.Text = endDate.Month.ToString();
            //this.lblEndDay.Text = endDate.Day.ToString();
            //this.lblOperationYear.Text = operationDate.Year.ToString();
            //this.lblOperationMonth.Text = operationDate.Month.ToString();
            //this.lblOperationDay.Text = operationDate.Day.ToString();
            r = ws.get_Range(("F" + 10), ("F" + 10)); r.Value2 = startDate.Year.ToString();
            r = ws.get_Range(("I" + 10), ("I" + 10)); r.Value2 = startDate.Month.ToString();
            r = ws.get_Range(("J" + 10), ("J" + 10)); r.Value2 = startDate.Day.ToString();
            r = ws.get_Range(("K" + 10), ("K" + 10)); r.Value2 = endDate.Year.ToString();
            r = ws.get_Range(("L" + 10), ("L" + 10)); r.Value2 = endDate.Month.ToString();
            r = ws.get_Range(("M" + 10), ("M" + 10)); r.Value2 = endDate.Day.ToString();
            r = ws.get_Range(("M" + 13), ("M" + 13)); r.Value2 = operationDate.Year.ToString();
            r = ws.get_Range(("O" + 13), ("O" + 13)); r.Value2 = operationDate.Month.ToString();
            r = ws.get_Range(("Q" + 13), ("Q" + 13)); r.Value2 = operationDate.Day.ToString();


            double serviceFeeRate = Convert.ToDouble(dtOperation.Rows[0]["ServiceFeeRate"].ToString());
            double interestRate = Convert.ToDouble(dtOperation.Rows[0]["InterestFeeRate"].ToString());
            //this.lblMonthFeeRate.Text = serviceFeeRate.ToString();
            //this.lblInterestFeeRate.Text = interestRate.ToString();
            //this.lblOperater.Text = MainForm.AccountName;
            r = ws.get_Range(("D" + 11), ("D" + 11)); r.Value2 = serviceFeeRate.ToString();
            r = ws.get_Range(("D" + 12), ("D" + 12)); r.Value2 = interestRate.ToString();

            DDUser newUser = new DDUser("AccountName", MainForm.AccountName);
            r = ws.get_Range(("I" + 13), ("I" + 13)); r.Value2 = newUser.UserName;

            //WdSaveFormat为Excel文档的保存格式
            object format = MSExcel.XlFileFormat.xlWorkbookNormal;

            //将excelDoc文档对象的内容保存为dd文档
            //excelDoc.Save();
            //excelDoc.SaveAs(path, format, Nothing, Nothing, Nothing, Nothing, MSExcel.ddaveAsAccessMode.xlExclusive, Nothing, Nothing, Nothing, Nothing, Nothing);

            excelDoc.PrintOut(Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing);

            if (File.Exists(Application.StartupPath + @"\Pram\dump.dd"))
            {
                try
                {
                    File.Delete(Application.StartupPath + @"\Pram\dump.dd");
                }
                catch (FieldAccessException e)
                {
                    MessageBox.Show("记录文件正在被使用，请退出Excel\n" + e.ToString());
                }
            }
            excelDoc.SaveAs(Application.StartupPath + @"\Pram\dump.dd", format, Nothing, Nothing, Nothing, Nothing, MSExcel.XlSaveAsAccessMode.xlExclusive, Nothing, Nothing, Nothing, Nothing, Nothing);


            //关闭excelDoc文档对象 
            excelDoc.Close(Nothing, Nothing, Nothing);

            //关闭excelApp组件对象 
            excelApp.Quit();
            //MessageBox.Show("生成成功");
            //PrintReceipt();
        }

        private void LoadTemplate(int iTicketID, string strOperationNumber)
        {
            double TotalAmount = 0;
            double TotalServiceFee = 0;
            double TotalLastInterestFee = 0;
            double TotalReturnFee = 0;
            double TotalOverdueFee = 0;
            double FirstTotalServiceFee = 0;
            double FirstTotalAmount = 0;
            List<string> strList = new List<string>();

            DDPawnTicket newTicket = new DDPawnTicket("TicketID", m_TicketID);
            DDCustomerInfo newCustomer = new DDCustomerInfo("CustomerID", newTicket.CustomerID);

            Query queryOperation = new Query(DDOperation.Schema);
            queryOperation.AddWhere("TicketID", m_TicketID);
            queryOperation.AddWhere("OperationNumber", strOperationNumber);
            queryOperation.AddWhere("OperationType", Comparison.NotEquals, 6);
            DataTable dtOperation = queryOperation.ExecuteDataSet().Tables[0];

            for (int i = 0; i < dtOperation.Rows.Count; i++)
            {
                TotalAmount += Convert.ToDouble(dtOperation.Rows[i]["Amount"].ToString());
                TotalServiceFee += Convert.ToDouble(dtOperation.Rows[i]["ServiceFee"].ToString());
                TotalLastInterestFee += Convert.ToDouble(dtOperation.Rows[i]["InterestFee"].ToString());
                TotalReturnFee += Convert.ToDouble(dtOperation.Rows[i]["ReturnFee"].ToString());
                TotalOverdueFee += Convert.ToDouble(dtOperation.Rows[i]["OverdueFee"].ToString());
            }
            TotalAmount = DianDangFunction.myRound(TotalAmount, MainForm.AmountAccuracy);
            TotalServiceFee = DianDangFunction.myRound(TotalServiceFee, MainForm.AmountAccuracy);
            TotalLastInterestFee = DianDangFunction.myRound(TotalLastInterestFee, MainForm.AmountAccuracy);
            TotalReturnFee = DianDangFunction.myRound(TotalReturnFee, MainForm.AmountAccuracy);
            TotalOverdueFee = DianDangFunction.myRound(TotalOverdueFee, MainForm.AmountAccuracy);

            queryOperation = new Query(DDOperation.Schema);
            queryOperation.AddWhere("TicketID", m_TicketID);
            queryOperation.AddWhere("PreOperationID", 0);
            queryOperation.AddWhere("OperationType", Comparison.NotEquals, 6);
            dtOperation = queryOperation.ExecuteDataSet().Tables[0];
            for (int i = 0; i < dtOperation.Rows.Count; i++)
            {
                FirstTotalAmount += Convert.ToDouble(dtOperation.Rows[i]["Amount"].ToString());
                FirstTotalServiceFee += Convert.ToDouble(dtOperation.Rows[i]["ServiceFee"].ToString());
            }
            FirstTotalAmount = DianDangFunction.myRound(FirstTotalAmount, MainForm.AmountAccuracy);
            FirstTotalServiceFee = DianDangFunction.myRound(FirstTotalServiceFee, MainForm.AmountAccuracy);



            MSExcel.Application excelApp; //Excel应用程序变量
            MSExcel.Workbook excelDoc; //Excel文档变量
            excelApp = new MSExcel.ApplicationClass();  //初始化
            //由于使用的是COM库，因此有许多变量需要用Nothing代替
            Object Nothing = Missing.Value;
            excelDoc = excelApp.Workbooks._Open(Application.StartupPath + @"\Pram\RedeemTemplate_TongBao.dd", Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

            //使用第一个工作表作为插入数据的工作表
            MSExcel.Worksheet ws = (MSExcel.Worksheet)excelDoc.Sheets[1];

            //声明一个MSExcel.Range 类型的变量r
            MSExcel.Range r;

            DDCompanyInfo company = new DDCompanyInfo("CompanyID", 1);
            //r = ws.get_Range(("F" + 4), ("F" + 4)); r.Value2 = company.CompanyName;
            r = ws.get_Range(("K" + 5), ("K" + 5)); r.Value2 = newTicket.TicketNumber.ToString();
            
            r = ws.get_Range(("D" + 5), ("D" + 5)); r.Value2 = newCustomer.CustomerName;
            
            
            //TotalAmount:
            string strTotalMount = TotalAmount.ToString("0.00");
            r = ws.get_Range(("D" + 7), ("D" + 7)); r.Value2 = newChinese.toChineseChar(strTotalMount);
            r = ws.get_Range(("M" + 7), ("M" + 7)); r.Value2 = strTotalMount;
            

            //Fee           
            string strFirstGive = (FirstTotalAmount - FirstTotalServiceFee).ToString("0.00");
            r = ws.get_Range(("E" + 13), ("E" + 13)); r.Value2 = newChinese.toChineseChar(strFirstGive);
            r = ws.get_Range(("L" + 13), ("L" + 13)); r.Value2 = strFirstGive;

            string strFirstServiceFee = FirstTotalServiceFee.ToString("0.00");
            r = ws.get_Range(("E" + 15), ("E" + 15)); r.Value2 = newChinese.toChineseChar(strFirstServiceFee);
            r = ws.get_Range(("L" + 15), ("L" + 15)); r.Value2 = strFirstServiceFee;

            string strOverdue = (Math.Abs(TotalLastInterestFee + TotalOverdueFee - TotalReturnFee + TotalServiceFee)).ToString("0.00");
            r = ws.get_Range(("E" + 17), ("E" + 17)); r.Value2 = newChinese.toChineseChar(strOverdue);
            r = ws.get_Range(("L" + 17), ("L" + 17)); r.Value2 = strOverdue;

            string strAll = (TotalAmount + TotalLastInterestFee + TotalOverdueFee + TotalServiceFee - TotalReturnFee).ToString("0.00");
            strList = newChinese.toStrList(strAll, 5, 2);
            r = ws.get_Range(("D" + 19), ("D" + 19)); r.Value2 = strList[0];
            r = ws.get_Range(("E" + 19), ("E" + 19)); r.Value2 = strList[1];
            r = ws.get_Range(("G" + 19), ("G" + 19)); r.Value2 = strList[2];
            r = ws.get_Range(("H" + 19), ("H" + 19)); r.Value2 = strList[3];
            r = ws.get_Range(("I" + 19), ("I" + 19)); r.Value2 = strList[4];
            r = ws.get_Range(("J" + 19), ("J" + 19)); r.Value2 = strList[5];
            r = ws.get_Range(("L" + 19), ("L" + 19)); r.Value2 = strList[6];
            r = ws.get_Range(("N" + 19), ("N" + 19)); r.Value2 = strAll;

            //日期
            DDOperation ThisOperation = new DDOperation("OperationNumber", strOperationNumber);
            DDOperation LastOperation = new DDOperation("OperationID", ThisOperation.PreOperationID);

            DateTime operationDate = Convert.ToDateTime(ThisOperation.OperationDate);
            DateTime lastStartDate = Convert.ToDateTime(LastOperation.StartDate);
            DateTime lastEndDate = Convert.ToDateTime(LastOperation.EndDate);

            r = ws.get_Range(("C" + 9), ("C" + 9)); r.Value2 = lastStartDate.Year.ToString();
            r = ws.get_Range(("E" + 9), ("E" + 9)); r.Value2 = lastStartDate.Month.ToString();
            r = ws.get_Range(("G" + 9), ("G" + 9)); r.Value2 = lastStartDate.Day.ToString();
            r = ws.get_Range(("I" + 9), ("I" + 9)); r.Value2 = lastEndDate.Year.ToString();
            r = ws.get_Range(("J" + 9), ("J" + 9)); r.Value2 = lastEndDate.Month.ToString();
            r = ws.get_Range(("L" + 9), ("L" + 9)); r.Value2 = lastEndDate.Day.ToString();


            r = ws.get_Range(("B" + 11), ("B" + 11)); r.Value2 = operationDate.Year.ToString();
            r = ws.get_Range(("D" + 11), ("D" + 11)); r.Value2 = operationDate.Month.ToString();
            r = ws.get_Range(("G" + 11), ("G" + 11)); r.Value2 = operationDate.Day.ToString();
            r = ws.get_Range(("L" + 3), ("L" + 3)); r.Value2 = operationDate.Year.ToString();
            r = ws.get_Range(("N" + 3), ("N" + 3)); r.Value2 = operationDate.Month.ToString();
            r = ws.get_Range(("O" + 3), ("O" + 3)); r.Value2 = operationDate.Day.ToString();

            //double serviceFeeRate = Convert.ToDouble(dtOperation.Rows[0]["ServiceFeeRate"].ToString());
            //double interestRate = Convert.ToDouble(dtOperation.Rows[0]["InterestFeeRate"].ToString());
            //r = ws.get_Range(("D" + 11), ("D" + 11)); r.Value2 = serviceFeeRate.ToString();
            //r = ws.get_Range(("D" + 12), ("D" + 12)); r.Value2 = interestRate.ToString();

            DDUser newUser = new DDUser("AccountName", MainForm.AccountName);
            r = ws.get_Range(("K" + 21), ("K" + 21)); r.Value2 = newUser.UserName;

            //WdSaveFormat为Excel文档的保存格式
            object format = MSExcel.XlFileFormat.xlWorkbookNormal;

            //将excelDoc文档对象的内容保存为dd文档
            //excelDoc.Save();
            //excelDoc.SaveAs(path, format, Nothing, Nothing, Nothing, Nothing, MSExcel.ddaveAsAccessMode.xlExclusive, Nothing, Nothing, Nothing, Nothing, Nothing);

            excelDoc.PrintOut(Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing);

            if (File.Exists(Application.StartupPath + @"\Pram\dump.dd"))
            {
                try
                {
                    File.Delete(Application.StartupPath + @"\Pram\dump.dd");
                }
                catch (FieldAccessException e)
                {
                    MessageBox.Show("记录文件正在被使用，请退出Excel\n" + e.ToString());
                }
            }
            excelDoc.SaveAs(Application.StartupPath + @"\Pram\dump.dd", format, Nothing, Nothing, Nothing, Nothing, MSExcel.XlSaveAsAccessMode.xlExclusive, Nothing, Nothing, Nothing, Nothing, Nothing);


            //关闭excelDoc文档对象 
            excelDoc.Close(Nothing, Nothing, Nothing);

            //关闭excelApp组件对象 
            excelApp.Quit();
            //MessageBox.Show("生成成功");
            //PrintReceipt();
        }


    }
}