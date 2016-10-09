using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MSExcel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace DianDang
{
    public partial class RenewPawnPrintPreviewForm : Form
    {
        public RenewPawnPrintPreviewForm(RenewPawnOperationForm frmRenewPawnOperation,int iTicketID)
        {
            InitializeComponent();
            LoadTemplate(frmRenewPawnOperation, iTicketID);
        }

        private int m_TicketID;
        private void PrintReceipt()
        {
            ReceiptPrintViewForm frmReceiptPrintView = new ReceiptPrintViewForm(m_TicketID);
        }

        ToChineseValue newChinese = new ToChineseValue();

        private void LoadTemplate(RenewPawnOperationForm frmRenewPawnOperation, int iTicketID)
        {
            object path;
            path = Application.StartupPath + @"RenewTemplate.xls";
            MSExcel.Application excelApp; //ExcelӦ�ó������
            MSExcel.Workbook excelDoc; //Excel�ĵ�����
            excelApp = new MSExcel.ApplicationClass();  //��ʼ��
            //����ʹ�õ���COM�⣬�������������Ҫ��Nothing����
            Object Nothing = Missing.Value;
            excelDoc = excelApp.Workbooks._Open(Application.StartupPath + @"\RenewTemplate.xls", Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

            //ʹ�õ�һ����������Ϊ�������ݵĹ�����
            MSExcel.Worksheet ws = (MSExcel.Worksheet)excelDoc.Sheets[1];

            //����һ��MSExcel.Range ���͵ı���r
            MSExcel.Range r;

            DDCompanyInfo company = new DDCompanyInfo("CompanyID", 1);
            //this.lblCompanyName.Text = company.CompanyName;
            //this.lblOldTicketNumber.Text = frmRenewPawnOperation.lblOldTicketNum.Text;
            r = ws.get_Range(("H" + 4), ("H" + 4)); r.Value2 = company.CompanyName;
            r = ws.get_Range(("O" + 4), ("O" + 4)); r.Value2 = frmRenewPawnOperation.lblOldTicketNum.Text;

            m_TicketID = iTicketID;
            DDPawnTicket newTicket = new DDPawnTicket("TicketID", iTicketID);
            DDCustomerInfo newCustomer = new DDCustomerInfo("CustomerID", newTicket.CustomerID);
            //this.lblCustomerName.Text = newCustomer.CustomerName;
            //this.lblContactPerson.Text = newCustomer.ContactPerson;
            r = ws.get_Range(("H" + 5), ("H" + 5)); r.Value2 = newCustomer.CustomerName;
            r = ws.get_Range(("O" + 5), ("O" + 5)); r.Value2 = newCustomer.ContactPerson;

            //this.lblAmount.Text = frmRenewPawnOperation.tbxTotalAmount.Text;
            //this.lblAmountChinese.Text = newChinese.toChineseChar(Convert.ToDecimal(frmRenewPawnOperation.tbxTotalAmount.Text));
            //this.lblServiceFee.Text = frmRenewPawnOperation.tbxServiceFee.Text;
            //this.lblServiceFeeChinese.Text = newChinese.toChineseChar(Convert.ToDecimal(frmRenewPawnOperation.tbxServiceFee.Text));
            //this.lblPaidInterestFee.Text = frmRenewPawnOperation.lblPaidInterest.Text;
            //this.lblPaidInterestFeeChinese.Text = newChinese.toChineseChar(Convert.ToDecimal(frmRenewPawnOperation.lblPaidInterest.Text));
            r = ws.get_Range(("H" + 6), ("H" + 6)); r.Value2 = frmRenewPawnOperation.tbxTotalAmount.Text;
            r = ws.get_Range(("O" + 6), ("O" + 6)); r.Value2 = newChinese.toChineseChar(Convert.ToDecimal(frmRenewPawnOperation.tbxTotalAmount.Text));
            r = ws.get_Range(("H" + 7), ("H" + 7)); r.Value2 = frmRenewPawnOperation.tbxServiceFee.Text;
            r = ws.get_Range(("O" + 7), ("O" + 7)); r.Value2 = newChinese.toChineseChar(Convert.ToDecimal(frmRenewPawnOperation.tbxServiceFee.Text));
            r = ws.get_Range(("H" + 8), ("H" + 8)); r.Value2 = frmRenewPawnOperation.lblPaidInterest.Text;
            r = ws.get_Range(("O" + 8), ("O" + 8)); r.Value2 = newChinese.toChineseChar(Convert.ToDecimal(frmRenewPawnOperation.lblPaidInterest.Text));

            double totalPaidFee = Convert.ToDouble(frmRenewPawnOperation.tbxServiceFee.Text) + Convert.ToDouble(frmRenewPawnOperation.lblPaidInterest.Text);
            //this.lblPaidFee.Text = totalPaidFee.ToString();
            //this.lblPaidFeeChinese.Text = newChinese.toChineseChar(Convert.ToDecimal(totalPaidFee));
            r = ws.get_Range(("O" + 9), ("O" + 9)); r.Value2 = newChinese.toChineseChar(Convert.ToDecimal(totalPaidFee));
            r = ws.get_Range(("H" + 9), ("H" + 9)); r.Value2 = totalPaidFee.ToString();

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
            r = ws.get_Range(("H" + 10), ("H" + 10)); r.Value2 = startDate.Year.ToString();
            r = ws.get_Range(("J" + 10), ("J" + 10)); r.Value2 = startDate.Month.ToString();
            r = ws.get_Range(("K" + 10), ("K" + 10)); r.Value2 = startDate.Day.ToString();
            r = ws.get_Range(("L" + 10), ("L" + 10)); r.Value2 = endDate.Year.ToString();
            r = ws.get_Range(("N" + 10), ("N" + 10)); r.Value2 = endDate.Month.ToString();
            r = ws.get_Range(("R" + 10), ("R" + 10)); r.Value2 = endDate.Day.ToString();
            r = ws.get_Range(("N" + 13), ("N" + 13)); r.Value2 = operationDate.Year.ToString();
            r = ws.get_Range(("Q" + 13), ("Q" + 13)); r.Value2 = operationDate.Month.ToString();
            r = ws.get_Range(("T" + 13), ("T" + 13)); r.Value2 = operationDate.Day.ToString();


            double serviceFeeRate = Convert.ToDouble(frmRenewPawnOperation.dataGridView1.Rows[0].Cells["FeeRate"].Value);
            double interestRate = Convert.ToDouble(frmRenewPawnOperation.dataGridView1.Rows[0].Cells["InterestRate"].Value);
            //this.lblMonthFeeRate.Text = serviceFeeRate.ToString();
            //this.lblInterestFeeRate.Text = interestRate.ToString();
            //this.lblOperater.Text = MainForm.AccountName;
            r = ws.get_Range(("D" + 11), ("D" + 11)); r.Value2 = serviceFeeRate.ToString();
            r = ws.get_Range(("D" + 12), ("D" + 12)); r.Value2 = interestRate.ToString();
            r = ws.get_Range(("I" + 13), ("I" + 13)); r.Value2 = MainForm.AccountName;
            
            //WdSaveFormatΪExcel�ĵ��ı����ʽ
            object format = MSExcel.XlFileFormat.xlWorkbookNormal;

            //��excelDoc�ĵ���������ݱ���ΪXLSX�ĵ�
            excelDoc.Save();
            //excelDoc.SaveAs(path, format, Nothing, Nothing, Nothing, Nothing, MSExcel.XlSaveAsAccessMode.xlExclusive, Nothing, Nothing, Nothing, Nothing, Nothing);

            excelDoc.PrintOut(Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing);

            //�ر�excelDoc�ĵ����� 
            excelDoc.Close(Nothing, Nothing, Nothing);

            //�ر�excelApp������� 
            excelApp.Quit();
            //MessageBox.Show("���ɳɹ�");
            PrintReceipt();
        }
    }
}