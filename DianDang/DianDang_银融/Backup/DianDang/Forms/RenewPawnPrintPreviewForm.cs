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

namespace DianDang
{
    public partial class RenewPawnPrintPreviewForm : Form
    {
        public RenewPawnPrintPreviewForm(RenewPawnOperationForm frmRenewPawnOperation,int iTicketID,string strOperationNumber)
        {
            InitializeComponent();
            m_OperationNumber = strOperationNumber;
            LoadTemplate(frmRenewPawnOperation, iTicketID);
            this.Dispose();
        }

        private int m_TicketID;
        private string m_OperationNumber;
        //private void PrintReceipt()
        //{
        //    ReceiptPrintViewForm frmReceiptPrintView = new ReceiptPrintViewForm(m_TicketID,m_OperationNumber);
        //}

        ToChineseValue newChinese = new ToChineseValue();

        private void LoadTemplate(RenewPawnOperationForm frmRenewPawnOperation, int iTicketID)
        {
            MSExcel.Application excelApp; //Excel应用程序变量
            MSExcel.Workbook excelDoc; //Excel文档变量
            excelApp = new MSExcel.ApplicationClass();  //初始化
            //由于使用的是COM库，因此有许多变量需要用Nothing代替
            Object Nothing = Missing.Value;
            excelDoc = excelApp.Workbooks._Open(Application.StartupPath + @"\Pram\RenewTemplate.dd", Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

            //使用第一个工作表作为插入数据的工作表
            MSExcel.Worksheet ws = (MSExcel.Worksheet)excelDoc.Sheets[1];

            //声明一个MSExcel.Range 类型的变量r
            MSExcel.Range r;

            DDCompanyInfo company = new DDCompanyInfo("CompanyID", 1);
            //this.lblCompanyName.Text = company.CompanyName;
            //this.lblOldTicketNumber.Text = frmRenewPawnOperation.lblOldTicketNum.Text;
            r = ws.get_Range(("F" + 4), ("F" + 4)); r.Value2 = company.CompanyName;
            r = ws.get_Range(("M" + 4), ("M" + 4)); r.Value2 = frmRenewPawnOperation.lblOldTicketNum.Text;

            m_TicketID = iTicketID;
            DDPawnTicket newTicket = new DDPawnTicket("TicketID", iTicketID);
            DDCustomerInfo newCustomer = new DDCustomerInfo("CustomerID", newTicket.CustomerID);
            //this.lblCustomerName.Text = newCustomer.CustomerName;
            //this.lblContactPerson.Text = newCustomer.ContactPerson;
            r = ws.get_Range(("F" + 5), ("F" + 5)); r.Value2 = newCustomer.CustomerName;
            r = ws.get_Range(("M" + 5), ("M" + 5)); r.Value2 = newCustomer.ContactPerson;

            //this.lblAmount.Text = frmRenewPawnOperation.tbxTotalAmount.Text;
            //this.lblAmountChinese.Text = newChinese.toChineseChar(Convert.ToDecimal(frmRenewPawnOperation.tbxTotalAmount.Text));
            //this.lblServiceFee.Text = frmRenewPawnOperation.tbxServiceFee.Text;
            //this.lblServiceFeeChinese.Text = newChinese.toChineseChar(Convert.ToDecimal(frmRenewPawnOperation.tbxServiceFee.Text));
            //this.lblPaidInterestFee.Text = frmRenewPawnOperation.lblPaidInterest.Text;
            //this.lblPaidInterestFeeChinese.Text = newChinese.toChineseChar(Convert.ToDecimal(frmRenewPawnOperation.lblPaidInterest.Text));
            r = ws.get_Range(("M" + 6), ("M" + 6)); r.Value2 = Convert.ToDouble(frmRenewPawnOperation.tbxTotalAmount.Text).ToString("0.00");
            r = ws.get_Range(("H" + 6), ("H" + 6)); r.Value2 = newChinese.toChineseChar(Convert.ToDecimal(frmRenewPawnOperation.tbxTotalAmount.Text));
            r = ws.get_Range(("M" + 7), ("M" + 7)); r.Value2 = Convert.ToDouble(frmRenewPawnOperation.tbxServiceFee.Text).ToString("0.00");
            r = ws.get_Range(("H" + 7), ("H" + 7)); r.Value2 = newChinese.toChineseChar(Convert.ToDecimal(frmRenewPawnOperation.tbxServiceFee.Text));
            r = ws.get_Range(("M" + 8), ("M" + 8)); r.Value2 = Convert.ToDouble(frmRenewPawnOperation.tbxLastInterestFee.Text).ToString("0.00");
            r = ws.get_Range(("H" + 8), ("H" + 8)); r.Value2 = newChinese.toChineseChar(Convert.ToDecimal(frmRenewPawnOperation.tbxLastInterestFee.Text));

            double totalPaidFee = Convert.ToDouble(frmRenewPawnOperation.tbxServiceFee.Text) + Convert.ToDouble(frmRenewPawnOperation.tbxLastInterestFee.Text);
            //this.lblPaidFee.Text = totalPaidFee.ToString();
            //this.lblPaidFeeChinese.Text = newChinese.toChineseChar(Convert.ToDecimal(totalPaidFee));
            r = ws.get_Range(("H" + 9), ("H" + 9)); r.Value2 = newChinese.toChineseChar(Convert.ToDecimal(totalPaidFee));
            r = ws.get_Range(("M" + 9), ("M" + 9)); r.Value2 = totalPaidFee.ToString("0.00");

            DateTime startDate = Convert.ToDateTime(frmRenewPawnOperation.tbxStartDate.Text);
            DateTime endDate = Convert.ToDateTime(frmRenewPawnOperation.tbxEndDate.Text);
            DateTime operationDate = Convert.ToDateTime(frmRenewPawnOperation.tbxOperationDate.Text);
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


            double serviceFeeRate = Convert.ToDouble(frmRenewPawnOperation.dataGridView1.Rows[0].Cells["FeeRate"].Value);
            double interestRate = Convert.ToDouble(frmRenewPawnOperation.dataGridView1.Rows[0].Cells["InterestRate"].Value);
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
    }
}