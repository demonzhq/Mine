namespace DianDang
{
    partial class ReceiptPrintViewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTicketNumber = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblMonth = new System.Windows.Forms.Label();
            this.lblDay = new System.Windows.Forms.Label();
            this.lblPawnageInfo1 = new System.Windows.Forms.Label();
            this.lblPawnageInfo2 = new System.Windows.Forms.Label();
            this.lblPawnageInfo3 = new System.Windows.Forms.Label();
            this.lblFee = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblTotalFee = new System.Windows.Forms.Label();
            this.lblOperater = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblFeeNumber = new System.Windows.Forms.TextBox();
            this.lblTotalFeeNumber = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblTicketNumber
            // 
            this.lblTicketNumber.AutoSize = true;
            this.lblTicketNumber.Location = new System.Drawing.Point(118, 104);
            this.lblTicketNumber.Name = "lblTicketNumber";
            this.lblTicketNumber.Size = new System.Drawing.Size(95, 12);
            this.lblTicketNumber.TabIndex = 0;
            this.lblTicketNumber.Text = "lblTicketNumber";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(634, 104);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(11, 12);
            this.lblYear.TabIndex = 1;
            this.lblYear.Text = "Y";
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(691, 104);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(11, 12);
            this.lblMonth.TabIndex = 1;
            this.lblMonth.Text = "M";
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.Location = new System.Drawing.Point(737, 104);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(11, 12);
            this.lblDay.TabIndex = 1;
            this.lblDay.Text = "D";
            // 
            // lblPawnageInfo1
            // 
            this.lblPawnageInfo1.AutoSize = true;
            this.lblPawnageInfo1.Location = new System.Drawing.Point(98, 173);
            this.lblPawnageInfo1.Name = "lblPawnageInfo1";
            this.lblPawnageInfo1.Size = new System.Drawing.Size(89, 12);
            this.lblPawnageInfo1.TabIndex = 0;
            this.lblPawnageInfo1.Text = "lalPawnageInfo";
            // 
            // lblPawnageInfo2
            // 
            this.lblPawnageInfo2.AutoSize = true;
            this.lblPawnageInfo2.Location = new System.Drawing.Point(98, 190);
            this.lblPawnageInfo2.Name = "lblPawnageInfo2";
            this.lblPawnageInfo2.Size = new System.Drawing.Size(89, 12);
            this.lblPawnageInfo2.TabIndex = 0;
            this.lblPawnageInfo2.Text = "lalPawnageInfo";
            // 
            // lblPawnageInfo3
            // 
            this.lblPawnageInfo3.AutoSize = true;
            this.lblPawnageInfo3.Location = new System.Drawing.Point(98, 208);
            this.lblPawnageInfo3.Name = "lblPawnageInfo3";
            this.lblPawnageInfo3.Size = new System.Drawing.Size(89, 12);
            this.lblPawnageInfo3.TabIndex = 0;
            this.lblPawnageInfo3.Text = "lalPawnageInfo";
            // 
            // lblFee
            // 
            this.lblFee.AutoSize = true;
            this.lblFee.Location = new System.Drawing.Point(303, 222);
            this.lblFee.Name = "lblFee";
            this.lblFee.Size = new System.Drawing.Size(41, 12);
            this.lblFee.TabIndex = 0;
            this.lblFee.Text = "lblFee";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 241);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "总计交收金额：";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new System.Drawing.Point(193, 241);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(71, 12);
            this.lblTotalAmount.TabIndex = 0;
            this.lblTotalAmount.Text = "TotalAmount";
            // 
            // lblTotalFee
            // 
            this.lblTotalFee.AutoSize = true;
            this.lblTotalFee.Location = new System.Drawing.Point(303, 276);
            this.lblTotalFee.Name = "lblTotalFee";
            this.lblTotalFee.Size = new System.Drawing.Size(71, 12);
            this.lblTotalFee.TabIndex = 0;
            this.lblTotalFee.Text = "lblTotalFee";
            // 
            // lblOperater
            // 
            this.lblOperater.AutoSize = true;
            this.lblOperater.Location = new System.Drawing.Point(146, 356);
            this.lblOperater.Name = "lblOperater";
            this.lblOperater.Size = new System.Drawing.Size(77, 12);
            this.lblOperater.TabIndex = 0;
            this.lblOperater.Text = "operatername";
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(693, 396);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lblFeeNumber
            // 
            this.lblFeeNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblFeeNumber.Location = new System.Drawing.Point(456, 218);
            this.lblFeeNumber.Name = "lblFeeNumber";
            this.lblFeeNumber.Size = new System.Drawing.Size(134, 14);
            this.lblFeeNumber.TabIndex = 3;
            // 
            // lblTotalFeeNumber
            // 
            this.lblTotalFeeNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblTotalFeeNumber.Location = new System.Drawing.Point(456, 253);
            this.lblTotalFeeNumber.Name = "lblTotalFeeNumber";
            this.lblTotalFeeNumber.Size = new System.Drawing.Size(134, 14);
            this.lblTotalFeeNumber.TabIndex = 3;
            // 
            // ReceiptPrintViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(837, 421);
            this.Controls.Add(this.lblTotalFeeNumber);
            this.Controls.Add(this.lblFeeNumber);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lblDay);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblOperater);
            this.Controls.Add(this.lblTotalFee);
            this.Controls.Add(this.lblFee);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPawnageInfo3);
            this.Controls.Add(this.lblPawnageInfo2);
            this.Controls.Add(this.lblPawnageInfo1);
            this.Controls.Add(this.lblTicketNumber);
            this.Name = "ReceiptPrintViewForm";
            this.Text = "收据打印预览";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTicketNumber;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.Label lblPawnageInfo1;
        private System.Windows.Forms.Label lblPawnageInfo2;
        private System.Windows.Forms.Label lblPawnageInfo3;
        private System.Windows.Forms.Label lblFee;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblTotalFee;
        private System.Windows.Forms.Label lblOperater;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TextBox lblFeeNumber;
        private System.Windows.Forms.TextBox lblTotalFeeNumber;
    }
}