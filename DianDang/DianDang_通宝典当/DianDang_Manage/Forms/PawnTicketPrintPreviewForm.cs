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
        public PawnTicketPrintPreviewForm(CreatePawnForm frmCreatePawn,int iTicketID,string strOperationNumber)
        {
            InitializeComponent();
            m_OperationNumber = strOperationNumber;
            LoadTemplate(frmCreatePawn, iTicketID);
            this.Dispose();
        }

        public PawnTicketPrintPreviewForm(PartRedeemPawnOperationForm frmCreatePawn, int iTicketID, string strOperationNumber)
        {
            InitializeComponent();
            m_OperationNumber = strOperationNumber;
            LoadTemplate(frmCreatePawn, iTicketID);
            this.Dispose();
        }

        public PawnTicketPrintPreviewForm(ViewPawnTicketForm frmViewPawnTicket, int iTicketID)
        {
            InitializeComponent();
            LoadTemplate(frmViewPawnTicket, iTicketID);
            this.Dispose();
        }

        public PawnTicketPrintPreviewForm(int iTicketID, string strOperationNumber)
        {
            m_OperationNumber = strOperationNumber;
            m_TicketID = iTicketID;
            InitializeComponent();
            LoadTemplate();
            this.Dispose();
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
        private string m_OperationNumber;

        private void LoadTemplate(PartRedeemPawnOperationForm frmCreatePawn, int iTicketID)
        {
            string thePrice;
            MSExcel.Application excelApp; //Excel应用程序变量
            MSExcel.Workbook excelDoc; //Excel文档变量
            excelApp = new MSExcel.ApplicationClass();  //初始化
            //由于使用的是COM库，因此有许多变量需要用Nothing代替
            Object Nothing = Missing.Value;
            excelDoc = excelApp.Workbooks._Open(Application.StartupPath + @"\Pram\PawnTemplate.dd", Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

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
            r = ws.get_Range(("C" + 2), ("C" + 2)); r.Value2 = "当票编号：" + newTicket.TicketNumber;

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

            if (frmCreatePawn.dataGridView2.Rows.Count > 0)
            {
                string strClassName;
                string strDescr;
                string strCount;
                //string strPercent;
                string strAmount;
                double doubleAmount = 0;
                string strRemark = "";

                for (int i = 0; i < frmCreatePawn.dataGridView2.Rows.Count; i++)
                {
                    strClassName = frmCreatePawn.dataGridView2.Rows[i].Cells["ChildClass"].Value.ToString();
                    strDescr = frmCreatePawn.dataGridView2.Rows[i].Cells["Description"].Value.ToString();
                    strCount = frmCreatePawn.dataGridView2.Rows[i].Cells["CountNumber"].Value.ToString();
                    //strPercent = frmCreatePawn.dataGridView1.Rows[i].Cells["DiscountPercent"].Value.ToString();
                    strAmount = frmCreatePawn.dataGridView2.Rows[i].Cells["PawnageAmount"].Value.ToString();
                    doubleAmount = Convert.ToDouble(frmCreatePawn.dataGridView2.Rows[i].Cells["PawnageAmount"].Value);




                    switch (i)
                    {
                        case 0:
                            r = ws.get_Range(("B" + 10), ("B" + 10)); r.Value2 = "1";
                            r = ws.get_Range(("D" + 10), ("D" + 10)); r.Value2 = strClassName;
                            r = ws.get_Range(("K" + 10), ("K" + 10)); r.Value2 = strDescr;
                            r = ws.get_Range(("N" + 10), ("N" + 10)); r.Value2 = strCount;
                            r = ws.get_Range(("P" + 10), ("P" + 10)); r.Value2 = strAmount;
                            //r = ws.get_Range(("U" + 10), ("U" + 10)); r.Value2 = strPercent;
                            thePrice = doubleAmount.ToString("0.00");
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
                            thePrice = doubleAmount.ToString("0.00");
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
                            thePrice = doubleAmount.ToString("0.00");
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

                    if (i < 3)
                    {
                        strRemark += (i + 1).ToString() + ":";
                        if (frmCreatePawn.dataGridView2.Rows[i].Cells["Remark"].Value.ToString().Trim().Length > 0)
                        {

                            strRemark += frmCreatePawn.dataGridView2.Rows[i].Cells["Remark"].Value.ToString();
                            strRemark += " ";
                        }
                        else
                        {
                            strRemark += "无备注";
                            strRemark += " ";
                        }
                    }
                    if (i >= 3)
                    {
                        strRemark = strRemark + (i + 1).ToString() + ":";
                        strRemark = strRemark + strClassName + " ";
                        strRemark = strRemark + strCount + "(件)" + " ";
                        strRemark = strRemark + strDescr + " ";
                        strRemark = strRemark + strAmount + " ";
                        strRemark = strRemark + frmCreatePawn.dataGridView2.Rows[i].Cells["Remark"].Value.ToString() + " ";
                    }

                    #region 打印房屋和车辆信息
                    if (frmCreatePawn.dataGridView2.Rows[i].Cells["ParentClass"].Value.ToString() == "房产")
                    {
                        strRemark = strRemark + "合同号:" + newTicket.TicketNumber.ToString() + "";
                        if (frmCreatePawn.dataGridView2.Rows[i].Cells["HouseCompactNumber"].Value.ToString() != "")
                        {
                            strRemark = strRemark + "房产证号:" + frmCreatePawn.dataGridView2.Rows[i].Cells["HouseCompactNumber"].Value.ToString() + "";
                        }
                        if (frmCreatePawn.dataGridView2.Rows[i].Cells["HouseAddress"].Value.ToString() != "")
                        {
                            strRemark = strRemark + "房产地址:" + frmCreatePawn.dataGridView2.Rows[i].Cells["HouseAddress"].Value.ToString() + "";
                        }
                        if (frmCreatePawn.dataGridView2.Rows[i].Cells["HouseArea"].Value.ToString() != "")
                        {
                            strRemark = strRemark + "建筑面积:" + frmCreatePawn.dataGridView2.Rows[i].Cells["HouseArea"].Value.ToString() + "";
                        }

                    }
                    if (frmCreatePawn.dataGridView2.Rows[i].Cells["ParentClass"].Value.ToString() == "机动车")
                    {
                        if (frmCreatePawn.dataGridView2.Rows[i].Cells["CarLicenceNumber"].Value.ToString() != "")
                        {
                            strRemark = strRemark + "牌照号码:" + frmCreatePawn.dataGridView2.Rows[i].Cells["CarLicenceNumber"].Value.ToString();
                        }
                        if (frmCreatePawn.dataGridView2.Rows[i].Cells["CarType"].Value.ToString() != "")
                        {
                            strRemark = strRemark + "车辆型号:" + frmCreatePawn.dataGridView2.Rows[i].Cells["CarType"].Value.ToString();
                        }
                        if (frmCreatePawn.dataGridView2.Rows[i].Cells["CarEngineNumber"].Value.ToString() != "")
                        {
                            strRemark = strRemark + "发动机编号:" + frmCreatePawn.dataGridView2.Rows[i].Cells["CarEngineNumber"].Value.ToString();
                        }
                        if (frmCreatePawn.dataGridView2.Rows[i].Cells["CarcaseNumber"].Value.ToString() != "")
                        {
                            strRemark = strRemark + "车架号:" + frmCreatePawn.dataGridView2.Rows[i].Cells["CarcaseNumber"].Value.ToString();
                        }
                    }
                    #endregion
                }
                strRemark += "当户承诺所有当品属合法取得.";
                r = ws.get_Range(("C" + 17), ("C" + 17)); r.Value2 = strRemark;
            }



            //this.lblTotalAmount.Text = FormatString(frmCreatePawn.tbxTotalAmount.Text.Trim());
            thePrice = Convert.ToDouble(frmCreatePawn.tbxTotalAmount.Text.Trim()).ToString("0.00");
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
            r = ws.get_Range(("R" + 14), ("R" + 14)); r.Value2 = Convert.ToDouble(frmCreatePawn.tbxNewServiceFee.Text).ToString("0.00");
            r = ws.get_Range(("F" + 14), ("F" + 14)); r.Value2 = newChinese.toChineseChar(Convert.ToDecimal(frmCreatePawn.tbxNewServiceFee.Text));
            r = ws.get_Range(("R" + 15), ("R" + 15)); r.Value2 = Convert.ToDouble(frmCreatePawn.tbxNewPaidFee.Text).ToString("0.00");
            r = ws.get_Range(("F" + 15), ("F" + 15)); r.Value2 = newChinese.toChineseChar(Convert.ToDecimal(frmCreatePawn.tbxNewPaidFee.Text));

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

            //WdSaveFormat为Excel文档的保存格式
            object format = MSExcel.XlFileFormat.xlWorkbookNormal;

            excelDoc.PrintOut(Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing);


            //将excelDoc文档对象的内容保存为dd文档
            //excelDoc.Save();
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

        private void LoadTemplate(CreatePawnForm frmCreatePawn, int iTicketID)
        {
            string thePrice;
            MSExcel.Application excelApp; //Excel应用程序变量
            MSExcel.Workbook excelDoc; //Excel文档变量
            excelApp = new MSExcel.ApplicationClass();  //初始化
            //由于使用的是COM库，因此有许多变量需要用Nothing代替
            Object Nothing = Missing.Value;
            excelDoc = excelApp.Workbooks._Open(Application.StartupPath + @"\Pram\PawnTemplate.dd", Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value); 　　　　　　　　

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
            r = ws.get_Range(("C" + 2), ("C" + 2)); r.Value2 = "当票编号："+newTicket.TicketNumber;

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
                    strDescr = frmCreatePawn.dataGridView1.Rows[i].Cells["Description"].Value.ToString();
                    strCount = frmCreatePawn.dataGridView1.Rows[i].Cells["CountNumber"].Value.ToString();
                    //strPercent = frmCreatePawn.dataGridView1.Rows[i].Cells["DiscountPercent"].Value.ToString();
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
                            //r = ws.get_Range(("U" + 10), ("U" + 10)); r.Value2 = strPercent;
                            thePrice = doubleAmount.ToString("0.00");
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
                            thePrice = doubleAmount.ToString("0.00");
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
                            thePrice = doubleAmount.ToString("0.00");
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

                    if (i < 3)
                    {
                        strRemark += (i + 1).ToString() + ":";
                        if (frmCreatePawn.dataGridView1.Rows[i].Cells["Remark"].Value.ToString().Trim().Length > 0)
                        {

                            strRemark += frmCreatePawn.dataGridView1.Rows[i].Cells["Remark"].Value.ToString();
                            strRemark += " ";
                        }
                        else
                        {
                            strRemark += "无备注";
                            strRemark += " ";
                        }
                    }
                    if (i >= 3)
                    {
                        strRemark = strRemark + (i + 1).ToString() + ":";
                        strRemark = strRemark + strClassName + " ";
                        strRemark = strRemark + strCount + "(件)" + " ";
                        strRemark = strRemark + strDescr + " ";
                        strRemark = strRemark + strAmount + " ";
                        strRemark = strRemark + frmCreatePawn.dataGridView1.Rows[i].Cells["Remark"].Value.ToString() + " ";
                    }

                    #region 打印房屋和车辆信息
                    if (frmCreatePawn.dataGridView1.Rows[i].Cells["ParentClass"].Value.ToString() == "房产")
                    {
                        strRemark = strRemark + "合同号:" + newTicket.TicketNumber.ToString() + "";
                        if (frmCreatePawn.dataGridView1.Rows[i].Cells["HouseCompactNumber"].Value.ToString() != "")
                        {
                            strRemark = strRemark + "房产证号:" + frmCreatePawn.dataGridView1.Rows[i].Cells["HouseCompactNumber"].Value.ToString() + "";
                        }
                        if (frmCreatePawn.dataGridView1.Rows[i].Cells["HouseAddress"].Value.ToString() != "")
                        {
                            strRemark = strRemark + "房产地址:" + frmCreatePawn.dataGridView1.Rows[i].Cells["HouseAddress"].Value.ToString() + "";
                        }
                        if (frmCreatePawn.dataGridView1.Rows[i].Cells["HouseArea"].Value.ToString() != "")
                        {
                            strRemark = strRemark + "建筑面积:" + frmCreatePawn.dataGridView1.Rows[i].Cells["HouseArea"].Value.ToString() + "";
                        }

                    }
                    if (frmCreatePawn.dataGridView1.Rows[i].Cells["ParentClass"].Value.ToString() == "机动车")
                    {
                        if (frmCreatePawn.dataGridView1.Rows[i].Cells["CarLicenceNumber"].Value.ToString() != "")
                        {
                            strRemark = strRemark + "牌照号码:" + frmCreatePawn.dataGridView1.Rows[i].Cells["CarLicenceNumber"].Value.ToString();
                        }
                        if (frmCreatePawn.dataGridView1.Rows[i].Cells["CarType"].Value.ToString() != "")
                        {
                            strRemark = strRemark + "车辆型号:" + frmCreatePawn.dataGridView1.Rows[i].Cells["CarType"].Value.ToString();
                        }
                        if (frmCreatePawn.dataGridView1.Rows[i].Cells["CarEngineNumber"].Value.ToString() != "")
                        {
                            strRemark = strRemark + "发动机编号:" + frmCreatePawn.dataGridView1.Rows[i].Cells["CarEngineNumber"].Value.ToString();
                        }
                        if (frmCreatePawn.dataGridView1.Rows[i].Cells["CarcaseNumber"].Value.ToString() != "")
                        {
                            strRemark = strRemark + "车架号:" + frmCreatePawn.dataGridView1.Rows[i].Cells["CarcaseNumber"].Value.ToString();
                        }
                    }
                    #endregion
                }
                strRemark += "当户承诺所有当品属合法取得.";
                r = ws.get_Range(("C" + 17), ("C" + 17)); r.Value2 = strRemark;
            }         

            
             
            //this.lblTotalAmount.Text = FormatString(frmCreatePawn.tbxTotalAmount.Text.Trim());
            thePrice = Convert.ToDouble(frmCreatePawn.tbxTotalAmount.Text.Trim()).ToString("0.00");
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
            r = ws.get_Range(("R" + 14), ("R" + 14)); r.Value2 = Convert.ToDouble(frmCreatePawn.tbxServiceFee.Text).ToString("0.00");
            r = ws.get_Range(("F" + 14), ("F" + 14)); r.Value2 = newChinese.toChineseChar(Convert.ToDecimal(frmCreatePawn.tbxServiceFee.Text));
            r = ws.get_Range(("R" + 15), ("R" + 15)); r.Value2 = Convert.ToDouble(frmCreatePawn.tbxPaidFee.Text).ToString("0.00");
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

            //WdSaveFormat为Excel文档的保存格式
            object format = MSExcel.XlFileFormat.xlWorkbookNormal;

            excelDoc.PrintOut(Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing);


            //将excelDoc文档对象的内容保存为dd文档
            //excelDoc.Save();
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

        private void LoadTemplate(ViewPawnTicketForm frmCreatePawn, int iTicketID)
        {
            string thePrice;
            MSExcel.Application excelApp; //Excel应用程序变量
            MSExcel.Workbook excelDoc; //Excel文档变量
            excelApp = new MSExcel.ApplicationClass();  //初始化
            //由于使用的是COM库，因此有许多变量需要用Nothing代替
            Object Nothing = Missing.Value;
            excelDoc = excelApp.Workbooks._Open(Application.StartupPath + @"\Pram\PawnTemplate.dd", Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

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
            r = ws.get_Range(("C" + 2), ("C" + 2)); r.Value2 = "当票编号：" + newTicket.TicketNumber;

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
                    strDescr = frmCreatePawn.dataGridView1.Rows[i].Cells["Description"].Value.ToString();
                    //strDescr = frmCreatePawn.dataGridView1.Rows[i].Cells["Weight"].Value.ToString() + GetUnitTypeByClass(strClassName);
                    strCount = frmCreatePawn.dataGridView1.Rows[i].Cells["CountNumber"].Value.ToString();
                    //strPercent = frmCreatePawn.dataGridView1.Rows[i].Cells["DiscountPercent"].Value.ToString();
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
                            //r = ws.get_Range(("U" + 10), ("U" + 10)); r.Value2 = strPercent;
                            thePrice = doubleAmount.ToString("0.00");
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
                            thePrice = doubleAmount.ToString("0.00");
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
                            thePrice = doubleAmount.ToString("0.00");
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

                    if (i < 3)
                    {
                        strRemark += (i + 1).ToString() + ":";
                        if (frmCreatePawn.dataGridView1.Rows[i].Cells["Remark"].Value.ToString().Trim().Length > 0)
                        {

                            strRemark += frmCreatePawn.dataGridView1.Rows[i].Cells["Remark"].Value.ToString();
                            strRemark += " ";
                        }
                        else
                        {
                            strRemark += "无备注";
                            strRemark += " ";
                        }
                    }
                    if (i >= 3)
                    {
                        strRemark = strRemark + (i + 1).ToString() + ":";
                        strRemark = strRemark + strClassName + " ";
                        strRemark = strRemark + strCount + "(件)" + " ";
                        strRemark = strRemark + strDescr + " ";
                        strRemark = strRemark + strAmount + " ";
                        strRemark = strRemark + frmCreatePawn.dataGridView1.Rows[i].Cells["Remark"].Value.ToString() + " ";

                    }

                    #region 打印房屋和车辆信息
                    if (frmCreatePawn.dataGridView1.Rows[i].Cells["ParentClass"].Value.ToString() == "房产")
                    {
                        Query Query3 = new Query(DDHouseInfo.Schema);
                        Query3.AddWhere("PawnageID", frmCreatePawn.dataGridView1.Rows[i].Cells["PawnageID"].Value.ToString());
                        DataTable Dt3 = Query3.ExecuteDataSet().Tables[0];

                        strRemark = strRemark + "合同号:" + newTicket.TicketNumber.ToString() + " ";
                        if (Dt3.Rows[0]["CompactNumber"].ToString() != "")
                        {
                            strRemark = strRemark + "房产证号:" + Dt3.Rows[0]["CompactNumber"].ToString() + " ";
                        }
                        if (Dt3.Rows[0]["Address"].ToString() != "")
                        {
                            strRemark = strRemark + "房产地址:" + Dt3.Rows[0]["Address"].ToString() + " ";
                        }
                        if (Dt3.Rows[0]["Area"].ToString() != "")
                        {
                            strRemark = strRemark + "建筑面积:" + Dt3.Rows[0]["Area"].ToString() + " ";
                        }
                    }
                    if (frmCreatePawn.dataGridView1.Rows[i].Cells["ParentClass"].Value.ToString() == "机动车")
                    {
                        Query Query4 = new Query(DDCarInfo.Schema);
                        Query4.AddWhere("PawnageID", frmCreatePawn.dataGridView1.Rows[i].Cells["PawnageID"].Value.ToString());
                        DataTable Dt4 = Query4.ExecuteDataSet().Tables[0];

                        if (Dt4.Rows[0]["LicenseNumber"].ToString() != "")
                        {
                            strRemark = strRemark + "牌照号码:" + Dt4.Rows[i]["LicenseNumber"].ToString() +" ";
                        }
                        if (Dt4.Rows[0]["CarType"].ToString() != "")
                        {
                            strRemark = strRemark + "车辆型号:" + Dt4.Rows[0]["CarType"].ToString() + " ";
                        }
                        if (Dt4.Rows[0]["EngineNumber"].ToString() != "")
                        {
                            strRemark = strRemark + "发动机编号:" + Dt4.Rows[0]["EngineNumber"].ToString() + " ";
                        }
                        if (Dt4.Rows[0]["CarcaseNumber"].ToString() != "")
                        {
                            strRemark = strRemark + "车架号:" + Dt4.Rows[0]["CarcaseNumber"].ToString() + " ";
                        }
                    }
                    #endregion

                }
                strRemark += "当户承诺所有当品属合法取得.";
                r = ws.get_Range(("C" + 17), ("C" + 17)); r.Value2 = strRemark;
            }



            //this.lblTotalAmount.Text = FormatString(frmCreatePawn.tbxTotalAmount.Text.Trim());
            thePrice = Convert.ToDouble(frmCreatePawn.tbxTotalAmount.Text.Trim()).ToString("0.00");
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
            r = ws.get_Range(("R" + 14), ("R" + 14)); r.Value2 = Convert.ToDouble(frmCreatePawn.tbxServiceFee.Text).ToString("0.00");
            r = ws.get_Range(("F" + 14), ("F" + 14)); r.Value2 = newChinese.toChineseChar(Convert.ToDecimal(frmCreatePawn.tbxServiceFee.Text));
            r = ws.get_Range(("R" + 15), ("R" + 15)); r.Value2 = Convert.ToDouble(frmCreatePawn.tbxPaidFee.Text).ToString("0.00");
            r = ws.get_Range(("F" + 15), ("F" + 15)); r.Value2 = newChinese.toChineseChar(Convert.ToDecimal(frmCreatePawn.tbxPaidFee.Text));

            DateTime startDate = Convert.ToDateTime(frmCreatePawn.tbxStartDate.Text);
            //DateTime endDate = Convert.ToDateTime(frmCreatePawn.tbxEndDate.Text);
            Query Query5 = new Query(DDOperation.Schema);
            Query5.AddWhere("TicketID", iTicketID);
            Query5.AddWhere("OperationType", 1);
            DataTable Dt5 = Query5.ExecuteDataSet().Tables[0];
            DateTime endDate = Convert.ToDateTime(Dt5.Rows[0]["EndDate"].ToString());

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
            Query Query6 = new Query(DDPawnageInfo.Schema);
            Query6.AddWhere("PawnageID", frmCreatePawn.dataGridView1.Rows[0].Cells["PawnageID"].Value.ToString());
            DataTable Dt6 = Query6.ExecuteDataSet().Tables[0];

            r = ws.get_Range(("Y" + 14), ("Y" + 14)); r.Value2 = Dt6.Rows[0]["FeeRate"].ToString();
            r = ws.get_Range(("AD" + 14), ("AD" + 14)); r.Value2 = Dt6.Rows[0]["InterestRate"].ToString();
            DDUser newUser = new DDUser("AccountName", MainForm.AccountName);
            //r = ws.get_Range(("G" + 18), ("G" + 18)); r.Value2 = newUser.UserName;

            Query Query2 = new Query(DDOperation.Schema);
            Query2.AddWhere("TicketID", iTicketID);
            Query2.AddWhere("OperationType", 1);
            DataTable Dt2 = Query2.ExecuteDataSet().Tables[0];
            r = ws.get_Range(("G" + 18), ("G" + 18)); r.Value2 = Dt2.Rows[0]["OperaterName"];

            //WdSaveFormat为Excel文档的保存格式
            object format = MSExcel.XlFileFormat.xlWorkbookNormal;

            excelDoc.PrintOut(Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing);


            //将excelDoc文档对象的内容保存为dd文档
            //excelDoc.Save();
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

        private void LoadTemplate()
        {
            double TotalAmount=0;
            double TotalServiceFee = 0;
            double TotalPaidFee = 0;

            string thePrice;
            MSExcel.Application excelApp; //Excel应用程序变量
            MSExcel.Workbook excelDoc; //Excel文档变量
            excelApp = new MSExcel.ApplicationClass();  //初始化
            //由于使用的是COM库，因此有许多变量需要用Nothing代替
            Object Nothing = Missing.Value;
            excelDoc = excelApp.Workbooks._Open(Application.StartupPath + @"\Pram\PawnTemplate.dd", Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

            //使用第一个工作表作为插入数据的工作表
            MSExcel.Worksheet ws = (MSExcel.Worksheet)excelDoc.Sheets[1];

            //声明一个MSExcel.Range 类型的变量r
            MSExcel.Range r;

            DDCompanyInfo company = new DDCompanyInfo("CompanyID", 1);

            r = ws.get_Range(("H" + 4), ("H" + 4)); r.Value2 = company.CompanyName;
            r = ws.get_Range(("V" + 4), ("V" + 4)); r.Value2 = company.PhoneNumber;
            r = ws.get_Range(("H" + 5), ("H" + 5)); r.Value2 = company.Address;
            r = ws.get_Range(("V" + 5), ("V" + 5)); r.Value2 = company.LicenseCode;

            DDPawnTicket newTicket = new DDPawnTicket("TicketID", m_TicketID);
            r = ws.get_Range(("C" + 2), ("C" + 2)); r.Value2 = "当票编号：" + newTicket.TicketNumber;

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

            Query queryOperation = new Query(DDOperation.Schema);
            queryOperation.AddWhere("TicketID", m_TicketID);
            queryOperation.AddWhere("OperationNumber", m_OperationNumber);
            queryOperation.AddWhere("OperationType", Comparison.NotEquals, 6);
            DataTable dtOperation = queryOperation.ExecuteDataSet().Tables[0];
            


            if (dtOperation.Rows.Count > 0)
            {
                string strClassName;
                string strDescr;
                string strCount;
                //string strPercent;
                string strAmount;
                double doubleAmount = 0;
                string strRemark = "";

                for (int i = 0; i < dtOperation.Rows.Count; i++)
                {
                    DDPawnageInfo newInfo = new DDPawnageInfo("PawnageID", dtOperation.Rows[i]["PawnageID"]);
                    DDPawnageClass newClass = new DDPawnageClass("ClassID", newInfo.ClassID);
                    strClassName = newClass.ClassName.ToString();
                    strDescr = newInfo.Description.ToString();
                    strCount = newInfo.CountNumber.ToString();
                    //strPercent = frmCreatePawn.dataGridView1.Rows[i].Cells["DiscountPercent"].Value.ToString();
                    strAmount = dtOperation.Rows[i]["Amount"].ToString();
                    doubleAmount = Convert.ToDouble(strAmount);

                    TotalAmount = TotalAmount + Convert.ToDouble(dtOperation.Rows[i]["Amount"].ToString());
                    TotalServiceFee = TotalServiceFee + Convert.ToDouble(dtOperation.Rows[i]["ServiceFee"].ToString());

                    switch (i)
                    {
                        case 0:
                            r = ws.get_Range(("B" + 10), ("B" + 10)); r.Value2 = "1";
                            r = ws.get_Range(("D" + 10), ("D" + 10)); r.Value2 = strClassName;
                            r = ws.get_Range(("K" + 10), ("K" + 10)); r.Value2 = strDescr;
                            r = ws.get_Range(("N" + 10), ("N" + 10)); r.Value2 = strCount;
                            r = ws.get_Range(("P" + 10), ("P" + 10)); r.Value2 = strAmount;
                            //r = ws.get_Range(("U" + 10), ("U" + 10)); r.Value2 = strPercent;
                            thePrice = doubleAmount.ToString("0.00");
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
                            thePrice = doubleAmount.ToString("0.00");
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
                            thePrice = doubleAmount.ToString("0.00");
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

                    if (i < 3)
                    {
                        strRemark += (i + 1).ToString() + ":";
                        if (newInfo.Remark.Trim().Length > 0)
                        {

                            strRemark += newInfo.Remark.ToString();
                            strRemark += " ";
                        }
                        else
                        {
                            strRemark += "无备注";
                            strRemark += " ";
                        }
                    }
                    if (i >= 3)
                    {
                        strRemark = strRemark + (i + 1).ToString() + ":";
                        strRemark = strRemark + strClassName + " ";
                        strRemark = strRemark + strCount + "(件)" + " ";
                        strRemark = strRemark + strDescr + " ";
                        strRemark = strRemark + strAmount + " ";
                        strRemark = strRemark + newInfo.Remark.ToString() + " ";

                    }

                    #region 打印房屋和车辆信息
                    if (newInfo.ParentID == 11)
                    {
                        Query Query3 = new Query(DDHouseInfo.Schema);
                        Query3.AddWhere("PawnageID", newInfo.PawnageID);
                        DataTable Dt3 = Query3.ExecuteDataSet().Tables[0];

                        strRemark = strRemark + "合同号:" + newTicket.TicketNumber.ToString() + " ";
                        if (Dt3.Rows[0]["CompactNumber"].ToString() != "")
                        {
                            strRemark = strRemark + "房产证号:" + Dt3.Rows[0]["CompactNumber"].ToString() + " ";
                        }
                        if (Dt3.Rows[0]["Address"].ToString() != "")
                        {
                            strRemark = strRemark + "房产地址:" + Dt3.Rows[0]["Address"].ToString() + " ";
                        }
                        if (Dt3.Rows[0]["Area"].ToString() != "")
                        {
                            strRemark = strRemark + "建筑面积:" + Dt3.Rows[0]["Area"].ToString() + " ";
                        }
                    }
                    if (newInfo.ParentID == 10)
                    {
                        Query Query4 = new Query(DDCarInfo.Schema);
                        Query4.AddWhere("PawnageID", newInfo.PawnageID);
                        DataTable Dt4 = Query4.ExecuteDataSet().Tables[0];

                        if (Dt4.Rows[0]["LicenseNumber"].ToString() != "")
                        {
                            strRemark = strRemark + "牌照号码:" + Dt4.Rows[i]["LicenseNumber"].ToString() + " ";
                        }
                        if (Dt4.Rows[0]["CarType"].ToString() != "")
                        {
                            strRemark = strRemark + "车辆型号:" + Dt4.Rows[0]["CarType"].ToString() + " ";
                        }
                        if (Dt4.Rows[0]["EngineNumber"].ToString() != "")
                        {
                            strRemark = strRemark + "发动机编号:" + Dt4.Rows[0]["EngineNumber"].ToString() + " ";
                        }
                        if (Dt4.Rows[0]["CarcaseNumber"].ToString() != "")
                        {
                            strRemark = strRemark + "车架号:" + Dt4.Rows[0]["CarcaseNumber"].ToString() + " ";
                        }
                    }
                    #endregion

                }
                strRemark += "当户承诺所有当品属合法取得.";
                r = ws.get_Range(("C" + 17), ("C" + 17)); r.Value2 = strRemark;
            }


            TotalAmount = DianDangFunction.myRound(TotalAmount, MainForm.AmountAccuracy);
            TotalServiceFee = DianDangFunction.myRound(TotalServiceFee, MainForm.AmountAccuracy);
            TotalPaidFee = TotalAmount - TotalServiceFee;

            //this.lblTotalAmount.Text = FormatString(frmCreatePawn.tbxTotalAmount.Text.Trim());
            thePrice = TotalAmount.ToString("0.00");
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

            r = ws.get_Range(("F" + 13), ("F" + 13)); r.Value2 = newChinese.toChineseChar(Convert.ToDecimal(TotalAmount));
            r = ws.get_Range(("R" + 14), ("R" + 14)); r.Value2 = TotalServiceFee.ToString("0.00");
            r = ws.get_Range(("F" + 14), ("F" + 14)); r.Value2 = newChinese.toChineseChar(Convert.ToDecimal(TotalServiceFee));
            r = ws.get_Range(("R" + 15), ("R" + 15)); r.Value2 = TotalPaidFee.ToString("0.00");
            r = ws.get_Range(("F" + 15), ("F" + 15)); r.Value2 = newChinese.toChineseChar(Convert.ToDecimal(TotalPaidFee));

            DateTime startDate = Convert.ToDateTime(dtOperation.Rows[0]["StartDate"].ToString());
            //DateTime endDate = Convert.ToDateTime(frmCreatePawn.tbxEndDate.Text);
            Query Query5 = new Query(DDOperation.Schema);
            Query5.AddWhere("TicketID", m_TicketID);
            Query5.AddWhere("OperationType", 1);
            DataTable Dt5 = Query5.ExecuteDataSet().Tables[0];
            DateTime endDate = Convert.ToDateTime(Dt5.Rows[0]["EndDate"].ToString());

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
            
            r = ws.get_Range(("Y" + 14), ("Y" + 14)); r.Value2 = dtOperation.Rows[0]["ServiceFeeRate"].ToString();
            r = ws.get_Range(("AD" + 14), ("AD" + 14)); r.Value2 = dtOperation.Rows[0]["InterestFeeRate"].ToString();
            DDUser newUser = new DDUser("AccountName", MainForm.AccountName);
            //r = ws.get_Range(("G" + 18), ("G" + 18)); r.Value2 = newUser.UserName;

            r = ws.get_Range(("G" + 18), ("G" + 18)); r.Value2 = dtOperation.Rows[0]["OperaterName"];

            //WdSaveFormat为Excel文档的保存格式
            object format = MSExcel.XlFileFormat.xlWorkbookNormal;

            excelDoc.PrintOut(Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing);


            //将excelDoc文档对象的内容保存为dd文档
            //excelDoc.Save();
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



        /*
        private void PrintReceipt()
        {
            ReceiptPrintViewForm frmReceiptPrintView = new ReceiptPrintViewForm(m_TicketID, m_OperationNumber);
        }
        */
        ToChineseValue newChinese = new ToChineseValue();

    }
}