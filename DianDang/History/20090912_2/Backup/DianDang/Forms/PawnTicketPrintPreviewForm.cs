using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DianDang
{
    public partial class PawnTicketPrintPreviewForm : Form
    {
        public PawnTicketPrintPreviewForm(CreatePawnForm frmCreatePawn,int iTicketID)
        {
            InitializeComponent();
            LoadInfo(frmCreatePawn, iTicketID);
        }

        private string FormatString(string str)
        {
            string returnStr="";
            for (int i = str.Length-1; i >-1; i--)
            {
                if (str[i] != '.')
                {
                    returnStr += str[i];
                    returnStr += "   ";
                }
            }
            return returnStr;
        }

        private int m_TicketID = 0;

        private void LoadInfo(CreatePawnForm frmCreatePawn, int iTicketID)
        {
            DDCompanyInfo company = new DDCompanyInfo("CompanyID", 1);
            this.lblCompanyName.Text = company.CompanyName;
            this.lblCompanyPhone.Text = company.PhoneNumber;
            this.lblCompanyAddress.Text = company.Address;
            this.lblCompanyCode.Text = company.LicenseCode;

            m_TicketID = iTicketID;
            DDPawnTicket newTicket = new DDPawnTicket("TicketID", iTicketID);
            DDCustomerInfo newCustomer = new DDCustomerInfo("CustomerID", newTicket.CustomerID);
            this.lblCustomerName.Text = newCustomer.CustomerName;
            this.lblCustomerPhone.Text = newCustomer.PhoneNumber;
            this.lblCustomerAddress.Text = newCustomer.Address;
            this.lblCustomerContactPerson.Text = newCustomer.ContactPerson;
            DDCertType newType = new DDCertType("TypeID",newCustomer.CertTypeID);
            this.lblCertType.Text = newType.TypeName;
            this.lblCertNumber.Text = newCustomer.CertNumber;

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
                            this.lblSeq1.Text = "1";
                            this.lblPawnage1.Text = strClassName;
                            this.lblDescr1.Text = strDescr;
                            this.lblCount1.Text = strCount;
                            this.lblPrice1.Text = strAmount;
                            this.lblPercent1.Text = strPercent;
                            this.lblAmount1.Text = FormatString(doubleAmount.ToString(".00"));
                            break;
                        case 1:
                            this.lblSeq2.Text = "2";
                            this.lblPawnage2.Text = strClassName;
                            this.lblDescr2.Text = strDescr;
                            this.lblCount2.Text = strCount;
                            this.lblPrice2.Text = strAmount;
                            this.lblPercent2.Text = strPercent;
                            this.lblAmount2.Text = FormatString(doubleAmount.ToString(".00"));
                            break;
                        case 2:
                            this.lblSeq3.Text = "3";
                            this.lblPawnage3.Text = strClassName;
                            this.lblDescr3.Text = strDescr;
                            this.lblCount3.Text = strCount;
                            this.lblPrice3.Text = strAmount;
                            this.lblPercent3.Text = strPercent;
                            this.lblAmount3.Text = FormatString(doubleAmount.ToString(".00"));
                            break;
                        default:
                            break;
                    }
                }
            }
            this.lblTotalAmount.Text = FormatString(frmCreatePawn.tbxTotalAmount.Text.Trim());
            this.lblTotalAmountChinese.Text = newChinese.toChineseChar(Convert.ToDecimal(frmCreatePawn.tbxTotalAmount.Text));
            this.lblServiceFee.Text = frmCreatePawn.tbxServiceFee.Text;
            this.lblServiceFeeChinese.Text = newChinese.toChineseChar(Convert.ToDecimal(frmCreatePawn.tbxServiceFee.Text));
            this.lblPaidFee.Text = frmCreatePawn.tbxPaidFee.Text;
            this.lblPaidFeeChinese.Text = newChinese.toChineseChar(Convert.ToDecimal(frmCreatePawn.tbxPaidFee.Text));

            DateTime startDate=Convert.ToDateTime(frmCreatePawn.tbxStartDate.Text);
            DateTime endDate=Convert.ToDateTime(frmCreatePawn.tbxEndDate.Text);
            DateTime currentDate=DateTime.Now;
            this.lblStartYear.Text = startDate.Year.ToString();
            this.lblStartMonth.Text = startDate.Month.ToString();
            this.lblStartDay.Text = startDate.Day.ToString();

            this.lblEndDay.Text = endDate.Day.ToString();
            this.lblEndMonth.Text = endDate.Month.ToString();
            this.lblEndYear.Text = endDate.Year.ToString();

            this.lblOperationDay.Text = currentDate.Day.ToString();
            this.lblOperationMonth.Text = currentDate.Month.ToString();
            this.lblOperationYear.Text = currentDate.Year.ToString();

            this.lblServiceFeeRate.Text = frmCreatePawn.tbxFeeRate.Text;
            this.lblInterestFeeRate.Text = frmCreatePawn.tbxInterestRate.Text;

            this.lblOperater.Text = MainForm.AccountName;
        }


        private void PrintReceipt()
        {
            ReceiptPrintViewForm frmReceiptPrintView = new ReceiptPrintViewForm(m_TicketID);
            frmReceiptPrintView.Show();
        }

        ToChineseValue newChinese = new ToChineseValue();

        //´òÓ¡

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
            BitBlt(dc2, 0, 0, this.ClientRectangle.Width, 560, dc1, 0, 0, 13369376);
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
            PrintReceipt();
            this.Close();
        }

    }
}