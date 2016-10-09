using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SubSonic;
using MSExcel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;

namespace DianDang
{
    public partial class ReceiptPrintViewForm : Form
    {
        public ReceiptPrintViewForm(int iTicketID)
        {
            InitializeComponent();
            LoadTemplate(iTicketID);
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

        ToChineseValue newChinese = new ToChineseValue();

        private void LoadTemplate(int iTicketID)
        {
            string thePrice;
            object path;
            path = Application.StartupPath + @"ReceiptTemplate.dd";
            MSExcel.Application excelApp; //Excel应用程序变量
            MSExcel.Workbook excelDoc; //Excel文档变量
            excelApp = new MSExcel.ApplicationClass();  //初始化
            //由于使用的是COM库，因此有许多变量需要用Nothing代替
            Object Nothing = Missing.Value;
            excelDoc = excelApp.Workbooks._Open(Application.StartupPath + @"\ReceiptTemplate.dd", Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

            //使用第一个工作表作为插入数据的工作表
            MSExcel.Worksheet ws = (MSExcel.Worksheet)excelDoc.Sheets[1];

            //声明一个MSExcel.Range 类型的变量r
            MSExcel.Range r;

            DDPawnTicket newTicket = new DDPawnTicket("TicketID", iTicketID);
            switch (newTicket.StatusID)
            {
                case 1:
                    r = ws.get_Range(("B" + 3), ("B" + 3)); r.Value2 = "新当";
                    break;
                case 2:
                    r = ws.get_Range(("B" + 3), ("B" + 3)); r.Value2 = "赎当";
                    break;
                case 3:
                    r = ws.get_Range(("B" + 3), ("B" + 3)); r.Value2 = "续当";
                    break;
                default:
                    break;
            }
            r = ws.get_Range(("C" + 4), ("C" + 4)); r.Value2 = newTicket.TicketNumber;
            //this.lblTicketNumber.Text = newTicket.TicketNumber;

            DateTime currentDate = DateTime.Now;
            string strYear = currentDate.Year.ToString();
            string strMonth = currentDate.Month.ToString();
            string strDay = currentDate.Day.ToString();
            //this.lblYear.Text = strYear;
            //this.lblMonth.Text = strMonth;
            //this.lblDay.Text = strDay;
            r = ws.get_Range(("V" + 4), ("V" + 4)); r.Value2 = strYear;
            r = ws.get_Range(("X" + 4), ("X" + 4)); r.Value2 = strMonth;
            r = ws.get_Range(("Z" + 4), ("Z" + 4)); r.Value2 = strDay;

            double totalAmount = 0;
            string strItem = "";
            Query query = new Query(DDOperation.Schema);
            query.AddWhere("TicketID", iTicketID);
            query.AddWhere("OperationType", 1);
            DataTable dt = query.ExecuteDataSet().Tables[0];

            //Query query2 = new Query(DDOperation.Schema);

            
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DDPawnageInfo newInfo = new DDPawnageInfo("PawnageID", Convert.ToInt32(dt.Rows[i]["PawnageID"]));
                    DDPawnageClass newClass = new DDPawnageClass("ClassID", newInfo.ClassID);
                    switch (i)
                    {
                        case 0:
                            //this.lblPawnageInfo1.Text = newClass.ClassName + dt.Rows[i]["Amount"].ToString();
                            strItem = newClass.ClassName;
                            //r = ws.get_Range(("J" + 6), ("J" + 6)); r.Value2 = newClass.ClassName + dt.Rows[i]["Amount"].ToString();
                            break;
                        case 1:
                            //this.lblPawnageInfo2.Text = newClass.ClassName + dt.Rows[i]["Amount"].ToString();
                            //r = ws.get_Range(("C" + 7), ("C" + 7)); r.Value2 = newClass.ClassName + dt.Rows[i]["Amount"].ToString();
                            strItem = strItem + "等";
                            break;
                        case 2:
                            //this.lblPawnageInfo3.Text = newClass.ClassName + dt.Rows[i]["Amount"].ToString();
                            //r = ws.get_Range(("C" + 8), ("C" + 8)); r.Value2 = newClass.ClassName + dt.Rows[i]["Amount"].ToString();
                            break;
                        default:
                            break;

                    }
                    totalAmount += Convert.ToDouble(dt.Rows[i]["Amount"]);
                }

                r = ws.get_Range(("C" + 6), ("C" + 6)); r.Value2 = strItem + " " + totalAmount;
            }

            Query queryAll = new Query(DDOperation.Schema);
            queryAll.AddWhere("TicketID", iTicketID);
            queryAll.AddWhere("NextOperationID", 0);
            queryAll.AddWhere("OperationType", Comparison.In, new int[] { 1,2, 3 });
            DataTable dtAll = queryAll.ExecuteDataSet().Tables[0];

            double overdueFee = 0;
            double returnFee = 0;
            double serviceFee = 0;
            string serviceFeeRate = "";
            if (dtAll.Rows.Count > 0)
            {
                int iPawnageID = Convert.ToInt32(dtAll.Rows[0]["PawnageID"]);
                DDPawnageInfo newPawnageInfo = new DDPawnageInfo("PawnageID", iPawnageID);
                serviceFeeRate = newPawnageInfo.FeeRate;
                for (int i = 0; i < dtAll.Rows.Count; i++)
                {
                    overdueFee += Convert.ToDouble(dtAll.Rows[i]["OverdueFee"]);
                    returnFee += Convert.ToDouble(dtAll.Rows[i]["ReturnFee"]);
                    serviceFee += Convert.ToDouble(dtAll.Rows[i]["ServiceFee"]);
                }
            }

            if (serviceFee >= 0)
            {
                if (newTicket.StatusID == 1)
                {
                    r = ws.get_Range(("H" + 10), ("H" + 10)); r.Value2 = "新当服务费: " + serviceFee.ToString(".00");
                }
                else
                {
                    r = ws.get_Range(("H" + 10), ("H" + 10)); r.Value2 = "续当服务费: " + serviceFee.ToString(".00");
                }
                //r = ws.get_Range(("H" + 12), ("H" + 12)); r.Value2 ="收："+ newChinese.toChineseChar(Convert.ToDecimal(serviceFee));
                r = ws.get_Range(("H" + 12), ("H" + 12)); r.Value2 = "" + newChinese.toChineseChar(Convert.ToDecimal(serviceFee));
                if (serviceFee != 0)
                {
                    thePrice = serviceFee.ToString(".00");
                    thePrice = thePrice.Substring(0, thePrice.Length - 3) + thePrice.Substring(thePrice.Length - 2);
                }
                else thePrice = "000";

                if (thePrice.Length < 8)
                {
                    for (int j = (8 - thePrice.Length); j > 0; j--)
                    {
                        thePrice = " " + thePrice;
                    }
                }
                r = ws.get_Range(("M" + 10), ("M" + 10)); r.Value2 = thePrice.Substring(0, 1);
                r = ws.get_Range(("N" + 10), ("N" + 10)); r.Value2 = thePrice.Substring(1, 1);
                r = ws.get_Range(("O" + 10), ("O" + 10)); r.Value2 = thePrice.Substring(2, 1);
                r = ws.get_Range(("P" + 10), ("P" + 10)); r.Value2 = thePrice.Substring(3, 1);
                r = ws.get_Range(("Q" + 10), ("Q" + 10)); r.Value2 = thePrice.Substring(4, 1);
                r = ws.get_Range(("R" + 10), ("R" + 10)); r.Value2 = thePrice.Substring(5, 1);
                r = ws.get_Range(("S" + 10), ("S" + 10)); r.Value2 = thePrice.Substring(6, 1);
                r = ws.get_Range(("T" + 10), ("T" + 10)); r.Value2 = thePrice.Substring(7, 1);

                r = ws.get_Range(("M" + 12), ("M" + 12)); r.Value2 = thePrice.Substring(0, 1);
                r = ws.get_Range(("N" + 12), ("N" + 12)); r.Value2 = thePrice.Substring(1, 1);
                r = ws.get_Range(("O" + 12), ("O" + 12)); r.Value2 = thePrice.Substring(2, 1);
                r = ws.get_Range(("P" + 12), ("P" + 12)); r.Value2 = thePrice.Substring(3, 1);
                r = ws.get_Range(("Q" + 12), ("Q" + 12)); r.Value2 = thePrice.Substring(4, 1);
                r = ws.get_Range(("R" + 12), ("R" + 12)); r.Value2 = thePrice.Substring(5, 1);
                r = ws.get_Range(("S" + 12), ("S" + 12)); r.Value2 = thePrice.Substring(6, 1);
                r = ws.get_Range(("T" + 12), ("T" + 12)); r.Value2 = thePrice.Substring(7, 1);

            }

            if (overdueFee > 0)
            {
                //this.lblFee.Text = "逾期服务费" + overdueFee.ToString();
                //this.lblTotalFee.Text = "收：" + newChinese.toChineseChar(Convert.ToDecimal(overdueFee));
                //this.lblTotalFeeNumber.Text = FormatString(overdueFee.ToString(".00"));
                //this.lblFeeNumber.Text = FormatString(overdueFee.ToString(".00"));

                r = ws.get_Range(("H" + 10), ("H" + 10)); r.Value2 = "逾期服务费: " + overdueFee.ToString(".00");
                //r = ws.get_Range(("H" + 12), ("H" + 12)); r.Value2 = "收：" + newChinese.toChineseChar(Convert.ToDecimal(overdueFee));
                r = ws.get_Range(("H" + 12), ("H" + 12)); r.Value2 =  newChinese.toChineseChar(Convert.ToDecimal(overdueFee));
                thePrice = overdueFee.ToString(".00");
                thePrice = thePrice.Substring(0, thePrice.Length - 3) + thePrice.Substring(thePrice.Length - 2);

                if (thePrice.Length < 8)
                {
                    for (int j = (8 - thePrice.Length); j > 0; j--)
                    {
                        thePrice = " " + thePrice;
                    }
                }
                r = ws.get_Range(("M" + 10), ("M" + 10)); r.Value2 = thePrice.Substring(0, 1);
                r = ws.get_Range(("N" + 10), ("N" + 10)); r.Value2 = thePrice.Substring(1, 1);
                r = ws.get_Range(("O" + 10), ("O" + 10)); r.Value2 = thePrice.Substring(2, 1);
                r = ws.get_Range(("P" + 10), ("P" + 10)); r.Value2 = thePrice.Substring(3, 1);
                r = ws.get_Range(("Q" + 10), ("Q" + 10)); r.Value2 = thePrice.Substring(4, 1);
                r = ws.get_Range(("R" + 10), ("R" + 10)); r.Value2 = thePrice.Substring(5, 1);
                r = ws.get_Range(("S" + 10), ("S" + 10)); r.Value2 = thePrice.Substring(6, 1);
                r = ws.get_Range(("T" + 10), ("T" + 10)); r.Value2 = thePrice.Substring(7, 1);

                r = ws.get_Range(("M" + 12), ("M" + 12)); r.Value2 = thePrice.Substring(0, 1);
                r = ws.get_Range(("N" + 12), ("N" + 12)); r.Value2 = thePrice.Substring(1, 1);
                r = ws.get_Range(("O" + 12), ("O" + 12)); r.Value2 = thePrice.Substring(2, 1);
                r = ws.get_Range(("P" + 12), ("P" + 12)); r.Value2 = thePrice.Substring(3, 1);
                r = ws.get_Range(("Q" + 12), ("Q" + 12)); r.Value2 = thePrice.Substring(4, 1);
                r = ws.get_Range(("R" + 12), ("R" + 12)); r.Value2 = thePrice.Substring(5, 1);
                r = ws.get_Range(("S" + 12), ("S" + 12)); r.Value2 = thePrice.Substring(6, 1);
                r = ws.get_Range(("T" + 12), ("T" + 12)); r.Value2 = thePrice.Substring(7, 1);
            }
            if (returnFee > 0)
            {
                //this.lblFee.Text = "返回服务费" + returnFee.ToString();
                //this.lblTotalFee.Text = "退：" + newChinese.toChineseChar(Convert.ToDecimal(returnFee));
                //this.lblTotalFeeNumber.Text = FormatString(returnFee.ToString(".00"));
                //this.lblFeeNumber.Text = FormatString(returnFee.ToString(".00"));
                r = ws.get_Range(("H" + 10), ("H" + 10)); r.Value2 = "返回服务费: " + returnFee.ToString(".00");
                r = ws.get_Range(("H" + 12), ("H" + 12)); r.Value2 = "退: " + newChinese.toChineseChar(Convert.ToDecimal(returnFee));
                thePrice = returnFee.ToString(".00");
                thePrice = thePrice.Substring(0, thePrice.Length - 3) + thePrice.Substring(thePrice.Length - 2);
                thePrice = "-" + thePrice;
                if (thePrice.Length < 8)
                {
                    for (int j = (8 - thePrice.Length); j > 0; j--)
                    {
                        thePrice = " " + thePrice;
                    }
                }
                r = ws.get_Range(("M" + 10), ("M" + 10)); r.Value2 = thePrice.Substring(0, 1);
                r = ws.get_Range(("N" + 10), ("N" + 10)); r.Value2 = thePrice.Substring(1, 1);
                r = ws.get_Range(("O" + 10), ("O" + 10)); r.Value2 = thePrice.Substring(2, 1);
                r = ws.get_Range(("P" + 10), ("P" + 10)); r.Value2 = thePrice.Substring(3, 1);
                r = ws.get_Range(("Q" + 10), ("Q" + 10)); r.Value2 = thePrice.Substring(4, 1);
                r = ws.get_Range(("R" + 10), ("R" + 10)); r.Value2 = thePrice.Substring(5, 1);
                r = ws.get_Range(("S" + 10), ("S" + 10)); r.Value2 = thePrice.Substring(6, 1);
                r = ws.get_Range(("T" + 10), ("T" + 10)); r.Value2 = thePrice.Substring(7, 1);

                r = ws.get_Range(("M" + 12), ("M" + 12)); r.Value2 = thePrice.Substring(0, 1);
                r = ws.get_Range(("N" + 12), ("N" + 12)); r.Value2 = thePrice.Substring(1, 1);
                r = ws.get_Range(("O" + 12), ("O" + 12)); r.Value2 = thePrice.Substring(2, 1);
                r = ws.get_Range(("P" + 12), ("P" + 12)); r.Value2 = thePrice.Substring(3, 1);
                r = ws.get_Range(("Q" + 12), ("Q" + 12)); r.Value2 = thePrice.Substring(4, 1);
                r = ws.get_Range(("R" + 12), ("R" + 12)); r.Value2 = thePrice.Substring(5, 1);
                r = ws.get_Range(("S" + 12), ("S" + 12)); r.Value2 = thePrice.Substring(6, 1);
                r = ws.get_Range(("T" + 12), ("T" + 12)); r.Value2 = thePrice.Substring(7, 1);
            }

            if (newTicket.StatusID != 1 && newTicket.StatusID != 3)
            {
                totalAmount = totalAmount + overdueFee - returnFee;
                r = ws.get_Range(("C" + 11), ("C" + 11)); r.Value2 = "总计交收金额: " + totalAmount.ToString(".00");
            }

            DDUser newUser = new DDUser("AccountName", MainForm.AccountName);
            //r = ws.get_Range(("F" + 14), ("F" + 14)); r.Value2 = newUser.UserName;
            r = ws.get_Range(("F" + 14), ("F" + 14)); r.Value2 = dtAll.Rows[dtAll.Rows.Count - 1]["OperaterName"].ToString();
            //this.lblTotalAmount.Text = totalAmount.ToString();
            //this.lblOperater.Text = MainForm.AccountName;

            //WdSaveFormat为Excel文档的保存格式
            object format = MSExcel.XlFileFormat.xlWorkbookNormal;

            //打印文档
            excelDoc.PrintOut(Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing);


            //将excelDoc文档对象的内容保存为dd文档
            //excelDoc.Save();
            if (File.Exists(Application.StartupPath + @"\dump.dd"))
            {
                try
                {
                    File.Delete(Application.StartupPath + @"\dump.dd");
                }
                catch (FieldAccessException e)
                {
                    MessageBox.Show("记录文件正在被使用，请退出Excel\n" + e.ToString());
                }
            }
            excelDoc.SaveAs(Application.StartupPath + @"\dump.dd", format, Nothing, Nothing, Nothing, Nothing, MSExcel.XlSaveAsAccessMode.xlExclusive, Nothing, Nothing, Nothing, Nothing, Nothing);

            //关闭excelDoc文档对象 
            excelDoc.Close(Nothing, Nothing, Nothing);

            //关闭excelApp组件对象 
            excelApp.Quit();
            //MessageBox.Show("生成成功");
        }
    }
}