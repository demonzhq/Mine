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
        public ReceiptPrintViewForm(int iTicketID,string strOperationNumber)
        {
            InitializeComponent();
            LoadTemplate(iTicketID,strOperationNumber);
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

        ToChineseValue newChinese = new ToChineseValue();

        private void LoadTemplate(int iTicketID,string strOperationNumber)
        {
            string thePrice;
            MSExcel.Application excelApp; //ExcelӦ�ó������
            MSExcel.Workbook excelDoc; //Excel�ĵ�����
            excelApp = new MSExcel.ApplicationClass();  //��ʼ��
            //����ʹ�õ���COM�⣬�������������Ҫ��Nothing����
            Object Nothing = Missing.Value;
            excelDoc = excelApp.Workbooks._Open(Application.StartupPath + @"\Pram\ReceiptTemplate.dd", Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

            //ʹ�õ�һ����������Ϊ�������ݵĹ�����
            MSExcel.Worksheet ws = (MSExcel.Worksheet)excelDoc.Sheets[1];

            //����һ��MSExcel.Range ���͵ı���r
            MSExcel.Range r;

            DDPawnTicket newTicket = new DDPawnTicket("TicketID", iTicketID);
            switch (newTicket.StatusID)
            {
                case 1:
                    r = ws.get_Range(("B" + 3), ("B" + 3)); r.Value2 = "�µ�";
                    break;
                case 2:
                    r = ws.get_Range(("B" + 3), ("B" + 3)); r.Value2 = "�굱";
                    break;
                case 3:
                    r = ws.get_Range(("B" + 3), ("B" + 3)); r.Value2 = "����";
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
                            strItem = strItem + "��";
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

            Query queryCurrentOperation = new Query(DDOperation.Schema);
            queryCurrentOperation.AddWhere("OperationNumber",strOperationNumber);
            DataTable dtCurrentOperation = queryCurrentOperation.ExecuteDataSet().Tables[0];
            int currentOperationType = Convert.ToInt32(dtCurrentOperation.Rows[0]["OperationType"]);

            double overdueFee = 0;
            double returnFee = 0;
            double serviceFee = 0;
            double interestFee = 0;
            string serviceFeeRate = "";
            string interestFeeRate ="";
            int preOperationID = 0;

            if (dtCurrentOperation.Rows.Count > 0)
            {
                serviceFeeRate = dtCurrentOperation.Rows[0]["ServiceFeeRate"].ToString();
                preOperationID = Convert.ToInt32(dtCurrentOperation.Rows[0]["PreOperationID"]);
                if (preOperationID != 0)
                {
                    DDOperation preOperation = new DDOperation("OperationID", preOperationID);
                    //interestFee += Convert.ToDouble(preOperation.InterestFee);
                    interestFeeRate = preOperation.InterestFeeRate;
                }
                for (int i = 0; i < dtCurrentOperation.Rows.Count; i++)
                {
                    overdueFee += Convert.ToDouble(dtCurrentOperation.Rows[i]["OverdueFee"]);
                    returnFee += Convert.ToDouble(dtCurrentOperation.Rows[i]["ReturnFee"]);
                    serviceFee += Convert.ToDouble(dtCurrentOperation.Rows[i]["ServiceFee"]);
                    interestFee += Convert.ToDouble(dtCurrentOperation.Rows[i]["interestFee"]);
                }
            }

            if (currentOperationType != 1)
            {
                r = ws.get_Range(("H" + 8), ("H" + 8)); r.Value2 = "������Ϣ: " + interestFeeRate.ToString()+"%";
                //r = ws.get_Range(("I" + 8), ("I" + 8)); r.Value2 = "%";
                if (interestFee != 0)
                {
                    thePrice = interestFee.ToString("0.00");
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
                r = ws.get_Range(("M" + 8), ("M" + 8)); r.Value2 = thePrice.Substring(0, 1);
                r = ws.get_Range(("N" + 8), ("N" + 8)); r.Value2 = thePrice.Substring(1, 1);
                r = ws.get_Range(("O" + 8), ("O" + 8)); r.Value2 = thePrice.Substring(2, 1);
                r = ws.get_Range(("P" + 8), ("P" + 8)); r.Value2 = thePrice.Substring(3, 1);
                r = ws.get_Range(("Q" + 8), ("Q" + 8)); r.Value2 = thePrice.Substring(4, 1);
                r = ws.get_Range(("R" + 8), ("R" + 8)); r.Value2 = thePrice.Substring(5, 1);
                r = ws.get_Range(("S" + 8), ("S" + 8)); r.Value2 = thePrice.Substring(6, 1);
                r = ws.get_Range(("T" + 8), ("T" + 8)); r.Value2 = thePrice.Substring(7, 1);
            }



            double paidFee = 0;
            if (currentOperationType!=2)
            {
                if (currentOperationType == 1)
                {
                    r = ws.get_Range(("H" + 10), ("H" + 10)); r.Value2 = "�µ������: " + serviceFee.ToString("0.00");
                    paidFee = serviceFee;
                }
                else
                {
                    r = ws.get_Range(("H" + 10), ("H" + 10)); r.Value2 = "���������: " + serviceFee.ToString("0.00");
                    paidFee = serviceFee + interestFee;
                }
                //r = ws.get_Range(("H" + 12), ("H" + 12)); r.Value2 ="�գ�"+ newChinese.toChineseChar(Convert.ToDecimal(serviceFee));
                r = ws.get_Range(("H" + 12), ("H" + 12)); r.Value2 = "" + newChinese.toChineseChar(Convert.ToDecimal(paidFee));
                if (serviceFee != 0)
                {
                    thePrice = serviceFee.ToString("0.00");
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


                if (paidFee != 0)
                {
                    thePrice = paidFee.ToString("0.00");
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
                //this.lblFee.Text = "���ڷ����" + overdueFee.ToString();
                //this.lblTotalFee.Text = "�գ�" + newChinese.toChineseChar(Convert.ToDecimal(overdueFee));
                //this.lblTotalFeeNumber.Text = FormatString(overdueFee.ToString("0.00"));
                //this.lblFeeNumber.Text = FormatString(overdueFee.ToString("0.00"));

                r = ws.get_Range(("H" + 10), ("H" + 10)); r.Value2 = "���ڷ����: " + overdueFee.ToString("0.00");
                //r = ws.get_Range(("H" + 12), ("H" + 12)); r.Value2 = "�գ�" + newChinese.toChineseChar(Convert.ToDecimal(overdueFee));
                paidFee = overdueFee + interestFee;
                r = ws.get_Range(("H" + 12), ("H" + 12)); r.Value2 =  newChinese.toChineseChar(Convert.ToDecimal(paidFee));
                thePrice = overdueFee.ToString("0.00");
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

                thePrice = paidFee.ToString("0.00");
                thePrice = thePrice.Substring(0, thePrice.Length - 3) + thePrice.Substring(thePrice.Length - 2);

                if (thePrice.Length < 8)
                {
                    for (int j = (8 - thePrice.Length); j > 0; j--)
                    {
                        thePrice = " " + thePrice;
                    }
                }
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
                //this.lblFee.Text = "���ط����" + returnFee.ToString();
                //this.lblTotalFee.Text = "�ˣ�" + newChinese.toChineseChar(Convert.ToDecimal(returnFee));
                //this.lblTotalFeeNumber.Text = FormatString(returnFee.ToString("0.00"));
                //this.lblFeeNumber.Text = FormatString(returnFee.ToString("0.00"));
                r = ws.get_Range(("H" + 10), ("H" + 10)); r.Value2 = "���ط����: " + returnFee.ToString("0.00");
                paidFee = interestFee - returnFee;
                r = ws.get_Range(("H" + 12), ("H" + 12)); r.Value2 = "��: " + newChinese.toChineseChar(Convert.ToDecimal(paidFee));
                thePrice = returnFee.ToString("0.00");
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

                thePrice = paidFee.ToString("0.00");
                thePrice = thePrice.Substring(0, thePrice.Length - 3) + thePrice.Substring(thePrice.Length - 2);
                if (thePrice.Length < 8)
                {
                    for (int j = (8 - thePrice.Length); j > 0; j--)
                    {
                        thePrice = " " + thePrice;
                    }
                }
                r = ws.get_Range(("M" + 12), ("M" + 12)); r.Value2 = thePrice.Substring(0, 1);
                r = ws.get_Range(("N" + 12), ("N" + 12)); r.Value2 = thePrice.Substring(1, 1);
                r = ws.get_Range(("O" + 12), ("O" + 12)); r.Value2 = thePrice.Substring(2, 1);
                r = ws.get_Range(("P" + 12), ("P" + 12)); r.Value2 = thePrice.Substring(3, 1);
                r = ws.get_Range(("Q" + 12), ("Q" + 12)); r.Value2 = thePrice.Substring(4, 1);
                r = ws.get_Range(("R" + 12), ("R" + 12)); r.Value2 = thePrice.Substring(5, 1);
                r = ws.get_Range(("S" + 12), ("S" + 12)); r.Value2 = thePrice.Substring(6, 1);
                r = ws.get_Range(("T" + 12), ("T" + 12)); r.Value2 = thePrice.Substring(7, 1);
            }

            Query queryAll = new Query(DDOperation.Schema);
            queryAll.AddWhere("TicketID", iTicketID);
            queryAll.AddWhere("NextOperationID", 0);
            queryAll.AddWhere("OperationType", Comparison.In, new int[] { 1, 2, 3 });
            DataTable dtAll = queryAll.ExecuteDataSet().Tables[0];

            double totalOverdueFee = 0;
            double totalReturnFee = 0;
            double totalServiceFee = 0;
            double totalInterestFee = 0;

            if (dtAll.Rows.Count > 0)
            {
                for (int i = 0; i < dtAll.Rows.Count; i++)
                {
                    totalOverdueFee += Convert.ToDouble(dtAll.Rows[i]["OverdueFee"]);
                    totalReturnFee += Convert.ToDouble(dtAll.Rows[i]["ReturnFee"]);
                    totalServiceFee += Convert.ToDouble(dtAll.Rows[i]["ServiceFee"]);
                    totalInterestFee += Convert.ToDouble(dtAll.Rows[i]["InterestFee"]);
                }
            }

            if (currentOperationType==2)
            {
                totalAmount = totalAmount + totalOverdueFee + totalInterestFee - totalReturnFee;
                r = ws.get_Range(("C" + 11), ("C" + 11)); r.Value2 = "�ܼƽ��ս��: " + totalAmount.ToString("0.00");
            }

            DDUser newUser = new DDUser("AccountName", MainForm.AccountName);
            //r = ws.get_Range(("F" + 14), ("F" + 14)); r.Value2 = newUser.UserName;
            r = ws.get_Range(("F" + 14), ("F" + 14)); r.Value2 = dtAll.Rows[dtAll.Rows.Count - 1]["OperaterName"].ToString();
            //this.lblTotalAmount.Text = totalAmount.ToString();
            //this.lblOperater.Text = MainForm.AccountName;

            //WdSaveFormatΪExcel�ĵ��ı����ʽ
            object format = MSExcel.XlFileFormat.xlWorkbookNormal;

            //��ӡ�ĵ�
            excelDoc.PrintOut(Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing);


            //��excelDoc�ĵ���������ݱ���Ϊdd�ĵ�
            //excelDoc.Save();
            if (File.Exists(Application.StartupPath + @"\Pram\dump.dd"))
            {
                try
                {
                    File.Delete(Application.StartupPath + @"\Pram\dump.dd");
                }
                catch (FieldAccessException e)
                {
                    MessageBox.Show("��¼�ļ����ڱ�ʹ�ã����˳�Excel\n" + e.ToString());
                }
            }
            excelDoc.SaveAs(Application.StartupPath + @"\Pram\dump.dd", format, Nothing, Nothing, Nothing, Nothing, MSExcel.XlSaveAsAccessMode.xlExclusive, Nothing, Nothing, Nothing, Nothing, Nothing);

            //�ر�excelDoc�ĵ����� 
            excelDoc.Close(Nothing, Nothing, Nothing);

            //�ر�excelApp������� 
            excelApp.Quit();
            //MessageBox.Show("���ɳɹ�");
        }
    }
}