using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DianDang
{
    public partial class RenewPawnPrintPreviewForm : Form
    {
        public RenewPawnPrintPreviewForm(RenewPawnOperationForm frmRenewPawnOperation,int iTicketID)
        {
            InitializeComponent();
            LoadInfo(frmRenewPawnOperation,iTicketID);
        }

        private int m_TicketID;
        private void PrintReceipt()
        {
            ReceiptPrintViewForm frmReceiptPrintView = new ReceiptPrintViewForm(m_TicketID);
            frmReceiptPrintView.Show();
        }

        ToChineseValue newChinese = new ToChineseValue();

        private void LoadInfo(RenewPawnOperationForm frmRenewPawnOperation,int iTicketID)
        {
            DDCompanyInfo company = new DDCompanyInfo("CompanyID", 1);
            this.lblCompanyName.Text = company.CompanyName;
            this.lblOldTicketNumber.Text = frmRenewPawnOperation.lblOldTicketNum.Text;

            m_TicketID = iTicketID;
            DDPawnTicket newTicket = new DDPawnTicket("TicketID",iTicketID);
            DDCustomerInfo newCustomer = new DDCustomerInfo("CustomerID",newTicket.CustomerID);
            this.lblCustomerName.Text = newCustomer.CustomerName;
            this.lblContactPerson.Text = newCustomer.ContactPerson;

            this.lblAmount.Text = frmRenewPawnOperation.tbxTotalAmount.Text;
            this.lblAmountChinese.Text = newChinese.toChineseChar(Convert.ToDecimal(frmRenewPawnOperation.tbxTotalAmount.Text));
            this.lblServiceFee.Text = frmRenewPawnOperation.tbxServiceFee.Text;
            this.lblServiceFeeChinese.Text = newChinese.toChineseChar(Convert.ToDecimal(frmRenewPawnOperation.tbxServiceFee.Text));
            this.lblPaidInterestFee.Text = frmRenewPawnOperation.lblPaidInterest.Text;
            this.lblPaidInterestFeeChinese.Text = newChinese.toChineseChar(Convert.ToDecimal(frmRenewPawnOperation.lblPaidInterest.Text));

            double totalPaidFee = Convert.ToDouble(this.lblServiceFee.Text) + Convert.ToDouble(this.lblPaidInterestFee.Text);
            this.lblPaidFee.Text = totalPaidFee.ToString();
            this.lblPaidFeeChinese.Text = newChinese.toChineseChar(Convert.ToDecimal(totalPaidFee));

            DateTime startDate = Convert.ToDateTime(frmRenewPawnOperation.tbxStartDate.Text);
            DateTime endDate = Convert.ToDateTime(frmRenewPawnOperation.tbxEndDate.Text);
            DateTime operationDate = Convert.ToDateTime(frmRenewPawnOperation.tbxOperationDate.Text);
            this.lblStartYear.Text = startDate.Year.ToString();
            this.lblStartMonth.Text = startDate.Month.ToString();
            this.lblStartDay.Text = startDate.Day.ToString();
            this.lblEndYear.Text = endDate.Year.ToString();
            this.lblEndMonth.Text = endDate.Month.ToString();
            this.lblEndDay.Text = endDate.Day.ToString();
            this.lblOperationYear.Text = operationDate.Year.ToString();
            this.lblOperationMonth.Text = operationDate.Month.ToString();
            this.lblOperationDay.Text = operationDate.Day.ToString();

            double serviceFeeRate =Convert.ToDouble( frmRenewPawnOperation.dataGridView1.Rows[0].Cells["FeeRate"].Value);
            double interestRate = Convert.ToDouble(frmRenewPawnOperation.dataGridView1.Rows[0].Cells["InterestRate"].Value);
            this.lblMonthFeeRate.Text = serviceFeeRate.ToString();
            this.lblInterestFeeRate.Text = interestRate.ToString();
            this.lblOperater.Text = MainForm.AccountName;

        }

        //¥Ú”°

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
            PrintReceipt();
            this.Close();
        }
    }
}