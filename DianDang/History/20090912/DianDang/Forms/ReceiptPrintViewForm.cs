using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SubSonic;

namespace DianDang
{
    public partial class ReceiptPrintViewForm : Form
    {
        public ReceiptPrintViewForm(int iTicketID)
        {
            InitializeComponent();
            LoadTicketInfo(iTicketID);
        }

        private string FormatString(string str)
        {
            string returnStr = "";
            for (int i = str.Length - 1; i > -1; i--)
            {
                if (str[i] != '.')
                {
                    returnStr += str[i];
                    returnStr += "   ";
                }
            }
            return returnStr;
        }

        ToChineseValue newChinese = new ToChineseValue();
        private void LoadTicketInfo(int iTicketID)
        {
            DDPawnTicket newTicket = new DDPawnTicket("TicketID",iTicketID);
            this.lblTicketNumber.Text = newTicket.TicketNumber;

            DateTime currentDate = DateTime.Now;
            string strYear = currentDate.Year.ToString();
            string strMonth = currentDate.Month.ToString();
            string strDay = currentDate.Day.ToString();
            this.lblYear.Text = strYear;
            this.lblMonth.Text = strMonth;
            this.lblDay.Text = strDay;

            double totalAmount=0;
            Query query = new Query(DDOperation.Schema);
            query.AddWhere("TicketID",iTicketID);
            query.AddWhere("OperationType",1);
            DataTable dt = query.ExecuteDataSet().Tables[0];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DDPawnageInfo newInfo=new DDPawnageInfo("PawnageID",Convert.ToInt32(dt.Rows[i]["PawnageID"]));
                    DDPawnageClass newClass=new DDPawnageClass("ClassID",newInfo.ClassID);
                    switch (i)
                    {
                        case 0:
                            this.lblPawnageInfo1.Text = newClass.ClassName + dt.Rows[i]["Amount"].ToString();
                            break;
                        case 1:
                            this.lblPawnageInfo2.Text = newClass.ClassName + dt.Rows[i]["Amount"].ToString();
                            break;
                        case 2:
                            this.lblPawnageInfo3.Text = newClass.ClassName + dt.Rows[i]["Amount"].ToString();
                            break;
                        default:
                            break;

                    }
                    totalAmount+=Convert.ToDouble(dt.Rows[i]["Amount"]);
                }
            }

            Query queryAll = new Query(DDOperation.Schema);
            queryAll.AddWhere("TicketID",iTicketID);
            queryAll.AddWhere("NextOperationID",0);
            queryAll.AddWhere("OperationType", Comparison.In, new int[] { 2,3 });
            DataTable dtAll = queryAll.ExecuteDataSet().Tables[0];

            double overdueFee = 0;
            double returnFee = 0;
            double serviceFee = 0;
            if (dtAll.Rows.Count > 0)
            {
                for(int i=0;i<dtAll.Rows.Count;i++)
                {
                    overdueFee += Convert.ToDouble(dtAll.Rows[i]["OverdueFee"]);
                    returnFee += Convert.ToDouble(dtAll.Rows[i]["ReturnFee"]);
                    serviceFee += Convert.ToDouble(dtAll.Rows[i]["ServiceFee"]);
                }
            }

            if (serviceFee > 0)
            {
                this.lblFee.Text = "续当服务费" + serviceFee.ToString();
                this.lblTotalFee.Text = "收：" + newChinese.toChineseChar(Convert.ToDecimal(serviceFee));
                this.lblTotalFeeNumber.Text =FormatString( serviceFee.ToString(".00"));
                this.lblFeeNumber.Text =FormatString(serviceFee.ToString(".00"));
            }

            if (overdueFee > 0)
            {
                this.lblFee.Text = "逾期服务费" + overdueFee.ToString();
                this.lblTotalFee.Text = "收："+newChinese.toChineseChar(Convert.ToDecimal(overdueFee));
                this.lblTotalFeeNumber.Text = FormatString(overdueFee.ToString(".00"));
                this.lblFeeNumber.Text = FormatString(overdueFee.ToString(".00"));
            }
            if (returnFee > 0)
            {
                this.lblFee.Text = "返回服务费" + returnFee.ToString();
                this.lblTotalFee.Text = "退：" + newChinese.toChineseChar(Convert.ToDecimal(returnFee));
                this.lblTotalFeeNumber.Text = FormatString(returnFee.ToString(".00"));
                this.lblFeeNumber.Text = FormatString(returnFee.ToString(".00"));
            }
            totalAmount =totalAmount+ overdueFee-returnFee;
            this.lblTotalAmount.Text = totalAmount.ToString();
            this.lblOperater.Text = MainForm.AccountName;
        }

        //打印

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern long BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);
        private Bitmap memoryImage;
        private void CaptureScreen()
        {
            Graphics mygraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, mygraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            IntPtr dc1 = mygraphics.GetHdc();
            IntPtr dc2 = memoryGraphics.GetHdc();
            BitBlt(dc2, 0, 0, this.ClientRectangle.Width, 350, dc1, 0, 0, 13369376);
            mygraphics.ReleaseHdc(dc1);
            memoryGraphics.ReleaseHdc(dc2);
        }
        private void printDocument1_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

        private void PrintOut()
        {
            CaptureScreen();
            printDocument1.Print();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintOut();
            this.Close();
        }
    }
}