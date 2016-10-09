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
    public partial class PawnTicketPrintPreviewForm : Form
    {
        public PawnTicketPrintPreviewForm(CreatePawnForm frmCreatePawn,int iTicketID)
        {
            InitializeComponent();
            LoadTemplate(frmCreatePawn, iTicketID);
        }

        public PawnTicketPrintPreviewForm(ViewPawnTicketForm frmViewPawnTicket, int iTicketID)
        {
            InitializeComponent();
            LoadTemplate(frmViewPawnTicket, iTicketID);
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

        private string GetUnitTypeByClass(string ClassName)
        {
            string UnitType = "";
            Query Query1 = new Query(DDPawnageClass.Schema);
            Query1.AddWhere("ClassName", ClassName);
            DataTable Table1 = Query1.ExecuteDataSet().Tables[0];
            if (Table1.Rows.Count > 0)
            {
                Query Query2 = new Query(DDMesureUnit.Schema);
                Query2.AddWhere("UnitID", Table1.Rows[0]["UnitID"].ToString());
                DataTable Table2 = Query2.ExecuteDataSet().Tables[0];
                if (Table2.Rows.Count > 0)
                {
                    UnitType = Table2.Rows[0]["UnitName"].ToString();
                }
            }
            return UnitType;
        }

        private int m_TicketID = 0;

        private void LoadTemplate(CreatePawnForm frmCreatePawn, int iTicketID)
        {
            string thePrice;
            object path;
            path = Application.StartupPath + @"PawnTemplate.dd";
            MSExcel.Application excelApp; //ExcelӦ�ó������
            MSExcel.Workbook excelDoc; //Excel�ĵ�����
            excelApp = new MSExcel.ApplicationClass();  //��ʼ��
            //����ʹ�õ���COM�⣬��������������Ҫ��Nothing����
            Object Nothing = Missing.Value;
            excelDoc = excelApp.Workbooks._Open(Application.StartupPath + @"\PawnTemplate.dd" ,Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value); ����������������

            //ʹ�õ�һ����������Ϊ�������ݵĹ�����
            MSExcel.Worksheet ws = (MSExcel.Worksheet)excelDoc.Sheets[1];

            //����һ��MSExcel.Range ���͵ı���r
            MSExcel.Range r;

            DDCompanyInfo company = new DDCompanyInfo("CompanyID", 1);

            r = ws.get_Range(("H" + 4), ("H" + 4)); r.Value2 = company.CompanyName;
            r = ws.get_Range(("V" + 4), ("V" + 4)); r.Value2 = company.PhoneNumber;
            r = ws.get_Range(("H" + 5), ("H" + 5)); r.Value2 = company.Address;
            r = ws.get_Range(("V" + 5), ("V" + 5)); r.Value2 = company.LicenseCode;

            m_TicketID = iTicketID;
            DDPawnTicket newTicket = new DDPawnTicket("TicketID", iTicketID);
            r = ws.get_Range(("C" + 2), ("C" + 2)); r.Value2 = "��Ʊ��ţ�"+newTicket.TicketNumber;

            Query Query1 = new Query(DDCompanyInfo.Schema);
            DataTable dt1 = Query1.ExecuteDataSet().Tables[0];
            r = ws.get_Range(("C" + 3), ("C" + 3)); r.Value2 = dt1.Rows[0]["ShopHours"].ToString();
            dt1.Dispose();

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
                //string strPercent;
                string strAmount;
                double doubleAmount = 0;
                string strRemark = "";

                for (int i = 0; i < frmCreatePawn.dataGridView1.Rows.Count; i++)
                {
                    strClassName = frmCreatePawn.dataGridView1.Rows[i].Cells["ChildClass"].Value.ToString();
                    strDescr = frmCreatePawn.dataGridView1.Rows[i].Cells["Weight"].Value.ToString() + GetUnitTypeByClass(strClassName);
                    strCount = frmCreatePawn.dataGridView1.Rows[i].Cells["CountNumber"].Value.ToString();
                    //strPercent = frmCreatePawn.dataGridView1.Rows[i].Cells["DiscountPercent"].Value.ToString();
                    strAmount = frmCreatePawn.dataGridView1.Rows[i].Cells["Amount"].Value.ToString();
                    doubleAmount = Convert.ToDouble(frmCreatePawn.dataGridView1.Rows[i].Cells["Amount"].Value);

                    if (i < 3)
                    {
                        if (frmCreatePawn.dataGridView1.Rows[i].Cells["Remark"].Value.ToString().Trim().Length > 0)
                        {
                            strRemark += (i + 1).ToString() + ":";
                            strRemark += frmCreatePawn.dataGridView1.Rows[i].Cells["Remark"].Value.ToString();
                            strRemark += " ";
                        }
                    }

                    
                    switch (i)
                    {
                        case 0:
                            r = ws.get_Range(("B" + 10), ("B" + 10)); r.Value2 = "1";
                            r = ws.get_Range(("D" + 10), ("D" + 10)); r.Value2 = strClassName;
                            r = ws.get_Range(("K" + 10), ("K" + 10)); r.Value2 = strDescr;
                            r = ws.get_Range(("N" + 10), ("N" + 10)); r.Value2 = strCount;
                            r = ws.get_Range(("P" + 10), ("P" + 10)); r.Value2 = strAmount;
                            //r = ws.get_Range(("U" + 10), ("U" + 10)); r.Value2 = strPercent;
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
                            r = ws.get_Range(("B" + 11), ("B" + 11)); r.Value2 = "2";
                            r = ws.get_Range(("D" + 11), ("D" + 11)); r.Value2 = strClassName;
                            r = ws.get_Range(("K" + 11), ("K" + 11)); r.Value2 = strDescr;
                            r = ws.get_Range(("N" + 11), ("N" + 11)); r.Value2 = strCount;
                            r = ws.get_Range(("P" + 11), ("P" + 11)); r.Value2 = strAmount;
                            //r = ws.get_Range(("U" + 11), ("U" + 11)); r.Value2 = strPercent;
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
                            r = ws.get_Range(("B" + 12), ("B" + 12)); r.Value2 = "3";
                            r = ws.get_Range(("D" + 12), ("D" + 12)); r.Value2 = strClassName;
                            r = ws.get_Range(("K" + 12), ("K" + 12)); r.Value2 = strDescr;
                            r = ws.get_Range(("N" + 12), ("N" + 12)); r.Value2 = strCount;
                            r = ws.get_Range(("P" + 12), ("P" + 12)); r.Value2 = strAmount;
                            //r = ws.get_Range(("U" + 12), ("U" + 12)); r.Value2 = strPercent;
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

                    if (i >= 3)
                    {
                        strRemark = strRemark + (i + 1).ToString() + ":";
                        strRemark = strRemark + strClassName + " ";
                        strRemark = strRemark + strCount + "(��)" + " ";
                        strRemark = strRemark + strDescr + " ";
                        strRemark = strRemark + strAmount + " ";
                        strRemark = strRemark + frmCreatePawn.dataGridView1.Rows[i].Cells["Remark"].Value.ToString() + " ";

                    }
                }
                strRemark += "������ŵ���е�Ʒ���Ϸ�ȡ��.";
                r = ws.get_Range(("E" + 17), ("E" + 17)); r.Value2 = strRemark;
            }         

            
             
            //this.lblTotalAmount.Text = FormatString(frmCreatePawn.tbxTotalAmount.Text.Trim());
            thePrice = Convert.ToDouble(frmCreatePawn.tbxTotalAmount.Text.Trim()).ToString(".0");
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

            r = ws.get_Range(("Y" + 14), ("Y" + 14)); r.Value2 = frmCreatePawn.tbxFeeRate.Text;
            r = ws.get_Range(("AD" + 14), ("AD" + 14)); r.Value2 = frmCreatePawn.tbxInterestRate.Text;

            DDUser newUser = new DDUser("AccountName", MainForm.AccountName);
            r = ws.get_Range(("G" + 18), ("G" + 18)); r.Value2 = newUser.UserName;

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
            PrintReceipt();
        }

        private void LoadTemplate(ViewPawnTicketForm frmCreatePawn, int iTicketID)
        {
            string thePrice;
            object path;
            path = Application.StartupPath + @"PawnTemplate.dd";
            MSExcel.Application excelApp; //ExcelӦ�ó������
            MSExcel.Workbook excelDoc; //Excel�ĵ�����
            excelApp = new MSExcel.ApplicationClass();  //��ʼ��
            //����ʹ�õ���COM�⣬��������������Ҫ��Nothing����
            Object Nothing = Missing.Value;
            excelDoc = excelApp.Workbooks._Open(Application.StartupPath + @"\PawnTemplate.dd", Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

            //ʹ�õ�һ����������Ϊ�������ݵĹ�����
            MSExcel.Worksheet ws = (MSExcel.Worksheet)excelDoc.Sheets[1];

            //����һ��MSExcel.Range ���͵ı���r
            MSExcel.Range r;

            DDCompanyInfo company = new DDCompanyInfo("CompanyID", 1);

            r = ws.get_Range(("H" + 4), ("H" + 4)); r.Value2 = company.CompanyName;
            r = ws.get_Range(("V" + 4), ("V" + 4)); r.Value2 = company.PhoneNumber;
            r = ws.get_Range(("H" + 5), ("H" + 5)); r.Value2 = company.Address;
            r = ws.get_Range(("V" + 5), ("V" + 5)); r.Value2 = company.LicenseCode;

            m_TicketID = iTicketID;
            DDPawnTicket newTicket = new DDPawnTicket("TicketID", iTicketID);
            r = ws.get_Range(("C" + 2), ("C" + 2)); r.Value2 = "��Ʊ��ţ�" + newTicket.TicketNumber;

            Query Query1 = new Query(DDCompanyInfo.Schema);
            DataTable dt1 = Query1.ExecuteDataSet().Tables[0];
            r = ws.get_Range(("C" + 3), ("C" + 3)); r.Value2 = dt1.Rows[0]["ShopHours"].ToString();
            dt1.Dispose();


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
                //string strPercent;
                string strAmount;
                double doubleAmount = 0;
                string strRemark = "";

                for (int i = 0; i < frmCreatePawn.dataGridView1.Rows.Count; i++)
                {
                    strClassName = frmCreatePawn.dataGridView1.Rows[i].Cells["ChildClass"].Value.ToString();
                    strDescr = frmCreatePawn.dataGridView1.Rows[i].Cells["Weight"].Value.ToString()+"��";
                    strCount = frmCreatePawn.dataGridView1.Rows[i].Cells["CountNumber"].Value.ToString();
                    //strPercent = frmCreatePawn.dataGridView1.Rows[i].Cells["DiscountPercent"].Value.ToString();
                    strAmount = frmCreatePawn.dataGridView1.Rows[i].Cells["Amount"].Value.ToString();
                    doubleAmount = Convert.ToDouble(frmCreatePawn.dataGridView1.Rows[i].Cells["Amount"].Value);

                    if (i < 3)
                    {
                        if (frmCreatePawn.dataGridView1.Rows[i].Cells["Remark"].Value.ToString().Trim().Length > 0)
                        {
                            strRemark += (i + 1).ToString() + ":";
                            strRemark += frmCreatePawn.dataGridView1.Rows[i].Cells["Remark"].Value.ToString();
                            strRemark += " ";
                        }
                    }


                    switch (i)
                    {
                        case 0:
                            r = ws.get_Range(("B" + 10), ("B" + 10)); r.Value2 = "1";
                            r = ws.get_Range(("D" + 10), ("D" + 10)); r.Value2 = strClassName;
                            r = ws.get_Range(("K" + 10), ("K" + 10)); r.Value2 = strDescr;
                            r = ws.get_Range(("N" + 10), ("N" + 10)); r.Value2 = strCount;
                            r = ws.get_Range(("P" + 10), ("P" + 10)); r.Value2 = strAmount;
                            //r = ws.get_Range(("U" + 10), ("U" + 10)); r.Value2 = strPercent;
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
                            r = ws.get_Range(("B" + 11), ("B" + 11)); r.Value2 = "2";
                            r = ws.get_Range(("D" + 11), ("D" + 11)); r.Value2 = strClassName;
                            r = ws.get_Range(("K" + 11), ("K" + 11)); r.Value2 = strDescr;
                            r = ws.get_Range(("N" + 11), ("N" + 11)); r.Value2 = strCount;
                            r = ws.get_Range(("P" + 11), ("P" + 11)); r.Value2 = strAmount;
                            //r = ws.get_Range(("U" + 11), ("U" + 11)); r.Value2 = strPercent;
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
                            r = ws.get_Range(("B" + 12), ("B" + 12)); r.Value2 = "3";
                            r = ws.get_Range(("D" + 12), ("D" + 12)); r.Value2 = strClassName;
                            r = ws.get_Range(("K" + 12), ("K" + 12)); r.Value2 = strDescr;
                            r = ws.get_Range(("N" + 12), ("N" + 12)); r.Value2 = strCount;
                            r = ws.get_Range(("P" + 12), ("P" + 12)); r.Value2 = strAmount;
                            //r = ws.get_Range(("U" + 12), ("U" + 12)); r.Value2 = strPercent;
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
                    if (i >= 3)
                    {
                        strRemark = strRemark + (i + 1).ToString() + ":";
                        strRemark = strRemark + strClassName + " ";
                        strRemark = strRemark + strCount + "(��)" + " ";
                        strRemark = strRemark + strDescr + " ";
                        strRemark = strRemark + strAmount + " ";
                        strRemark = strRemark + frmCreatePawn.dataGridView1.Rows[i].Cells["Remark"].Value.ToString() + " ";

                    }
                }
                strRemark += "������ŵ���е�Ʒ���Ϸ�ȡ��.";
                r = ws.get_Range(("E" + 17), ("E" + 17)); r.Value2 = strRemark;
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

            //r = ws.get_Range(("X" + 14), ("X" + 14)); r.Value2 = frmCreatePawn.tbxFeeRate.Text;
            //r = ws.get_Range(("AC" + 14), ("AC" + 14)); r.Value2 = frmCreatePawn.tbxInterestRate.Text;

            DDUser newUser = new DDUser("AccountName", MainForm.AccountName);
            //r = ws.get_Range(("G" + 18), ("G" + 18)); r.Value2 = newUser.UserName;

            Query Query2 = new Query(DDOperation.Schema);
            Query2.AddWhere("TicketID", iTicketID);
            Query2.AddWhere("OperationType", 1);
            DataTable Dt2 = Query2.ExecuteDataSet().Tables[0];
            r = ws.get_Range(("G" + 18), ("G" + 18)); r.Value2 = Dt2.Rows[0]["OperaterName"];

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
            PrintReceipt();
        }


        private void PrintReceipt()
        {
            ReceiptPrintViewForm frmReceiptPrintView = new ReceiptPrintViewForm(m_TicketID);
        }

        ToChineseValue newChinese = new ToChineseValue();

    }
}