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
    public partial class PawnTicketPrintPreviewForm : Form
    {
        public PawnTicketPrintPreviewForm(CreatePawnForm frmCreatePawn,int iTicketID)
        {
            InitializeComponent();
            LoadTemplate(frmCreatePawn, iTicketID);
        }

        private string FormatString(string str)
        {
            string returnStr = "";
            for (int i = 0; i <= str.Length - 1; i++)
            {
                if (str[i] != '.')
                {
                    returnStr += str[i];
                    returnStr += "  ";
                }
            }
            return returnStr;
        }

        private int m_TicketID = 0;

        private void LoadTemplate(CreatePawnForm frmCreatePawn, int iTicketID)
        {
            string thePrice;
            object path;
            path = Application.StartupPath + @"PawnTemplate.xls";
            MSExcel.Application excelApp; //Excel应用程序变量
            MSExcel.Workbook excelDoc; //Excel文档变量
            excelApp = new MSExcel.ApplicationClass();  //初始化
            //由于使用的是COM库，因此有许多变量需要用Nothing代替
            Object Nothing = Missing.Value;
            excelDoc = excelApp.Workbooks._Open(Application.StartupPath + @"\PawnTemplate.xls" ,Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value); 　　　　　　　　

            //使用第一个工作表作为插入数据的工作表
            MSExcel.Worksheet ws = (MSExcel.Worksheet)excelDoc.Sheets[1];

            //声明一个MSExcel.Range 类型的变量r
            MSExcel.Range r;



            DDCompanyInfo company = new DDCompanyInfo("CompanyID", 1);

            r = ws.get_Range(("H" + 4), ("H" + 4)); r.Value2 = company.CompanyName;
            r = ws.get_Range(("V" + 4), ("V" + 4)); r.Value2 = company.PhoneNumber;
            r = ws.get_Range(("H" + 5), ("H" + 5)); r.Value2 = company.Address;
            r = ws.get_Range(("V" + 5), ("V" + 5)); r.Value2 = company.LicenseCode;

            m_TicketID = iTicketID;
            DDPawnTicket newTicket = new DDPawnTicket("TicketID", iTicketID);
            DDCustomerInfo newCustomer = new DDCustomerInfo("CustomerID", newTicket.CustomerID);
            r = ws.get_Range(("H" + 6), ("H" + 6)); r.Value2 = newCustomer.CustomerName;
            r = ws.get_Range(("V" + 6), ("V" + 6)); r.Value2 = newCustomer.PhoneNumber;
            r = ws.get_Range(("H" + 7), ("H" + 7)); r.Value2 = newCustomer.Address;
            r = ws.get_Range(("V" + 7), ("V" + 7)); r.Value2 = newCustomer.ContactPerson;
            DDCertType newType = new DDCertType("TypeID", newCustomer.CertTypeID);
            r = ws.get_Range(("H" + 8), ("H" + 8)); r.Value2 = newType.TypeName;
            r = ws.get_Range(("V" + 8), ("V" + 8)); r.Value2 = newCustomer.CertNumber;

            if (frmCreatePawn.dataGridView1.Rows.Count > 0)
            {
                string strClassName;
                string strDescr;
                string strCount;
                string strPercent;
                string strAmount;
                double doubleAmount = 0;

                for (int i = 0; i < frmCreatePawn.dataGridView1.Rows.Count; i++)
                {
                    strClassName = frmCreatePawn.dataGridView1.Rows[i].Cells["ChildClass"].Value.ToString();
                    strDescr = frmCreatePawn.dataGridView1.Rows[i].Cells["Description"].Value.ToString();
                    strCount = frmCreatePawn.dataGridView1.Rows[i].Cells["CountNumber"].Value.ToString();
                    strPercent = frmCreatePawn.dataGridView1.Rows[i].Cells["DiscountPercent"].Value.ToString();
                    strAmount = frmCreatePawn.dataGridView1.Rows[i].Cells["Amount"].Value.ToString();
                    doubleAmount = Convert.ToDouble(frmCreatePawn.dataGridView1.Rows[i].Cells["Amount"].Value);
                    switch (i)
                    {
                        case 0:
                            r = ws.get_Range(("B" + 10), ("B" + 10)); r.Value2 = "1";
                            r = ws.get_Range(("D" + 10), ("D" + 10)); r.Value2 = strClassName;
                            r = ws.get_Range(("K" + 10), ("K" + 10)); r.Value2 = strDescr;
                            r = ws.get_Range(("N" + 10), ("N" + 10)); r.Value2 = strCount;
                            r = ws.get_Range(("P" + 10), ("P" + 10)); r.Value2 = strAmount;
                            r = ws.get_Range(("U" + 10), ("U" + 10)); r.Value2 = strPercent;
                            thePrice = doubleAmount.ToString(".00");
                            thePrice = thePrice.Substring(0, thePrice.Length - 3) + thePrice.Substring(thePrice.Length - 2);
  
                            if (thePrice.Length < 10)
                            {
                                for (int j = (10 - thePrice.Length); j > 0; j--)
                                {
                                    thePrice = " " + thePrice;
                                }
                            }
                            r = ws.get_Range(("V" + 10), ("V" + 10)); r.Value2 = thePrice.Substring(0, 1);
                            r = ws.get_Range(("W" + 10), ("W" + 10)); r.Value2 = thePrice.Substring(1, 1);
                            r = ws.get_Range(("X" + 10), ("X" + 10)); r.Value2 = thePrice.Substring(2, 1);
                            r = ws.get_Range(("Y" + 10), ("Y" + 10)); r.Value2 = thePrice.Substring(3, 1);
                            r = ws.get_Range(("Z" + 10), ("Z" + 10)); r.Value2 = thePrice.Substring(4, 1);
                            r = ws.get_Range(("AA" + 10), ("AA" + 10)); r.Value2 = thePrice.Substring(5, 1);
                            r = ws.get_Range(("AB" + 10), ("AB" + 10)); r.Value2 = thePrice.Substring(6, 1);
                            r = ws.get_Range(("AC" + 10), ("AC" + 10)); r.Value2 = thePrice.Substring(7, 1);
                            r = ws.get_Range(("AD" + 10), ("AD" + 10)); r.Value2 = thePrice.Substring(8, 1);
                            r = ws.get_Range(("AE" + 10), ("AE" + 10)); r.Value2 = thePrice.Substring(9, 1);

                            break;
                        case 1:
                            r = ws.get_Range(("B" + 11), ("B" + 11)); r.Value2 = "1";
                            r = ws.get_Range(("D" + 11), ("D" + 11)); r.Value2 = strClassName;
                            r = ws.get_Range(("K" + 11), ("K" + 11)); r.Value2 = strDescr;
                            r = ws.get_Range(("N" + 11), ("N" + 11)); r.Value2 = strCount;
                            r = ws.get_Range(("P" + 11), ("P" + 11)); r.Value2 = strAmount;
                            r = ws.get_Range(("U" + 11), ("U" + 11)); r.Value2 = strPercent;
                            thePrice = doubleAmount.ToString(".00");
                            thePrice = thePrice.Substring(0, thePrice.Length - 3) + thePrice.Substring(thePrice.Length - 2);
                            if (thePrice.Length < 10)
                            {
                                for (int j = (10 - thePrice.Length); j > 0; j--)
                                {
                                    thePrice = " " + thePrice;
                                }
                            }
                            r = ws.get_Range(("V" + 11), ("V" + 11)); r.Value2 = thePrice.Substring(0, 1);
                            r = ws.get_Range(("W" + 11), ("W" + 11)); r.Value2 = thePrice.Substring(1, 1);
                            r = ws.get_Range(("X" + 11), ("X" + 11)); r.Value2 = thePrice.Substring(2, 1);
                            r = ws.get_Range(("Y" + 11), ("Y" + 11)); r.Value2 = thePrice.Substring(3, 1);
                            r = ws.get_Range(("Z" + 11), ("Z" + 11)); r.Value2 = thePrice.Substring(4, 1);
                            r = ws.get_Range(("AA" + 11), ("AA" + 11)); r.Value2 = thePrice.Substring(5, 1);
                            r = ws.get_Range(("AB" + 11), ("AB" + 11)); r.Value2 = thePrice.Substring(6, 1);
                            r = ws.get_Range(("AC" + 11), ("AC" + 11)); r.Value2 = thePrice.Substring(7, 1);
                            r = ws.get_Range(("AD" + 11), ("AD" + 11)); r.Value2 = thePrice.Substring(8, 1);
                            r = ws.get_Range(("AE" + 11), ("AE" + 11)); r.Value2 = thePrice.Substring(9, 1);
                            break;
                        case 2:
                            r = ws.get_Range(("B" + 12), ("B" + 12)); r.Value2 = "1";
                            r = ws.get_Range(("D" + 12), ("D" + 12)); r.Value2 = strClassName;
                            r = ws.get_Range(("K" + 12), ("K" + 12)); r.Value2 = strDescr;
                            r = ws.get_Range(("N" + 12), ("N" + 12)); r.Value2 = strCount;
                            r = ws.get_Range(("P" + 12), ("P" + 12)); r.Value2 = strAmount;
                            r = ws.get_Range(("U" + 12), ("U" + 12)); r.Value2 = strPercent;
                            thePrice = doubleAmount.ToString(".00");
                            thePrice = thePrice.Substring(0, thePrice.Length - 3) + thePrice.Substring(thePrice.Length - 2);
                            if (thePrice.Length < 10)
                            {
                                for (int j = (10 - thePrice.Length); j > 0; j--)
                                {
                                    thePrice = " " + thePrice;
                                }
                            }
                            r = ws.get_Range(("V" + 12), ("V" + 12)); r.Value2 = thePrice.Substring(0, 1);
                            r = ws.get_Range(("W" + 12), ("W" + 12)); r.Value2 = thePrice.Substring(1, 1);
                            r = ws.get_Range(("X" + 12), ("X" + 12)); r.Value2 = thePrice.Substring(2, 1);
                            r = ws.get_Range(("Y" + 12), ("Y" + 12)); r.Value2 = thePrice.Substring(3, 1);
                            r = ws.get_Range(("Z" + 12), ("Z" + 12)); r.Value2 = thePrice.Substring(4, 1);
                            r = ws.get_Range(("AA" + 12), ("AA" + 12)); r.Value2 = thePrice.Substring(5, 1);
                            r = ws.get_Range(("AB" + 12), ("AB" + 12)); r.Value2 = thePrice.Substring(6, 1);
                            r = ws.get_Range(("AC" + 12), ("AC" + 12)); r.Value2 = thePrice.Substring(7, 1);
                            r = ws.get_Range(("AD" + 12), ("AD" + 12)); r.Value2 = thePrice.Substring(8, 1);
                            r = ws.get_Range(("AE" + 12), ("AE" + 12)); r.Value2 = thePrice.Substring(9, 1);
                            break;
                        default:
                            break;
                    }
                }
            }         

            
             
            //this.lblTotalAmount.Text = FormatString(frmCreatePawn.tbxTotalAmount.Text.Trim());
            thePrice = Convert.ToDouble(frmCreatePawn.tbxTotalAmount.Text.Trim()).ToString(".00");
            thePrice = thePrice.Substring(0, thePrice.Length - 3) + thePrice.Substring(thePrice.Length - 2);
            if (thePrice.Length < 10)
            {
                for (int j = (10 - thePrice.Length); j > 0; j--)
                {
                    thePrice = " " + thePrice;
                }
            }
            r = ws.get_Range(("V" + 13), ("V" + 13)); r.Value2 = thePrice.Substring(0, 1);
            r = ws.get_Range(("W" + 13), ("W" + 13)); r.Value2 = thePrice.Substring(1, 1);
            r = ws.get_Range(("X" + 13), ("X" + 13)); r.Value2 = thePrice.Substring(2, 1);
            r = ws.get_Range(("Y" + 13), ("Y" + 13)); r.Value2 = thePrice.Substring(3, 1);
            r = ws.get_Range(("Z" + 13), ("Z" + 13)); r.Value2 = thePrice.Substring(4, 1);
            r = ws.get_Range(("AA" + 13), ("AA" + 13)); r.Value2 = thePrice.Substring(5, 1);
            r = ws.get_Range(("AB" + 13), ("AB" + 13)); r.Value2 = thePrice.Substring(6, 1);
            r = ws.get_Range(("AC" + 13), ("AC" + 13)); r.Value2 = thePrice.Substring(7, 1);
            r = ws.get_Range(("AD" + 13), ("AD" + 13)); r.Value2 = thePrice.Substring(8, 1);
            r = ws.get_Range(("AE" + 13), ("AE" + 13)); r.Value2 = thePrice.Substring(9, 1);

            r = ws.get_Range(("F" + 13), ("F" + 13)); r.Value2 = newChinese.toChineseChar(Convert.ToDecimal(frmCreatePawn.tbxTotalAmount.Text));
            r = ws.get_Range(("R" + 14), ("R" + 14)); r.Value2 = frmCreatePawn.tbxServiceFee.Text;
            r = ws.get_Range(("F" + 14), ("F" + 14)); r.Value2 = newChinese.toChineseChar(Convert.ToDecimal(frmCreatePawn.tbxServiceFee.Text));
            r = ws.get_Range(("R" + 15), ("R" + 15)); r.Value2 = frmCreatePawn.tbxPaidFee.Text;
            r = ws.get_Range(("F" + 15), ("F" + 15)); r.Value2 = newChinese.toChineseChar(Convert.ToDecimal(frmCreatePawn.tbxPaidFee.Text));

            DateTime startDate = Convert.ToDateTime(frmCreatePawn.tbxStartDate.Text);
            DateTime endDate = Convert.ToDateTime(frmCreatePawn.tbxEndDate.Text);
            DateTime currentDate = DateTime.Now;
            r = ws.get_Range(("E" + 16), ("E" + 16)); r.Value2 = startDate.Year.ToString();
            r = ws.get_Range(("I" + 16), ("I" + 16)); r.Value2 = startDate.Month.ToString();
            r = ws.get_Range(("K" + 16), ("K" + 16)); r.Value2 = startDate.Day.ToString();

            r = ws.get_Range(("S" + 16), ("S" + 16)); r.Value2 = endDate.Day.ToString();
            r = ws.get_Range(("O" + 16), ("O" + 16)); r.Value2 = endDate.Month.ToString();
            r = ws.get_Range(("L" + 16), ("L" + 16)); r.Value2 = endDate.Year.ToString();

            r = ws.get_Range(("T" + 18), ("T" + 18)); r.Value2 = currentDate.Day.ToString();
            r = ws.get_Range(("Q" + 18), ("Q" + 18)); r.Value2 = currentDate.Month.ToString();
            r = ws.get_Range(("M" + 18), ("M" + 18)); r.Value2 = currentDate.Year.ToString();

            r = ws.get_Range(("X" + 14), ("X" + 14)); r.Value2 = frmCreatePawn.tbxFeeRate.Text;
            r = ws.get_Range(("AC" + 14), ("AC" + 14)); r.Value2 = frmCreatePawn.tbxInterestRate.Text;

            r = ws.get_Range(("G" + 18), ("G" + 18)); r.Value2 = MainForm.AccountName;

            //WdSaveFormat为Excel文档的保存格式
            object format = MSExcel.XlFileFormat.xlWorkbookNormal;

            //将excelDoc文档对象的内容保存为XLSX文档
            excelDoc.Save();
            //excelDoc.SaveAs(path, format, Nothing, Nothing, Nothing, Nothing, MSExcel.XlSaveAsAccessMode.xlExclusive, Nothing, Nothing, Nothing, Nothing, Nothing);

            excelDoc.PrintOut(Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing);

            //关闭excelDoc文档对象 
            excelDoc.Close(Nothing, Nothing, Nothing);

            //关闭excelApp组件对象 
            excelApp.Quit();
            //MessageBox.Show("生成成功");
            PrintReceipt();
        }

        private void PrintReceipt()
        {
            ReceiptPrintViewForm frmReceiptPrintView = new ReceiptPrintViewForm(m_TicketID);
        }

        ToChineseValue newChinese = new ToChineseValue();

    }
}