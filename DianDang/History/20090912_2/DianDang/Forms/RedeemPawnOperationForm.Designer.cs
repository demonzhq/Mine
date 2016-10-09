namespace DianDang
{
    partial class RedeemPawnOperationForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbxOperationDate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxServiceFee = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxInterestFee = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxReturnFee = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxOverdueFee = new System.Windows.Forms.TextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxPaidFee = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ClassName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InterestFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReturnFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OverdueFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "赎当日期：";
            // 
            // tbxOperationDate
            // 
            this.tbxOperationDate.Location = new System.Drawing.Point(87, 19);
            this.tbxOperationDate.Name = "tbxOperationDate";
            this.tbxOperationDate.Size = new System.Drawing.Size(150, 21);
            this.tbxOperationDate.TabIndex = 1;
            this.tbxOperationDate.TextChanged += new System.EventHandler(this.tbxOperationDate_TextChanged);
            this.tbxOperationDate.Click += new System.EventHandler(this.tbxOperationDate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "典当金额：";
            // 
            // tbxAmount
            // 
            this.tbxAmount.Location = new System.Drawing.Point(130, 28);
            this.tbxAmount.Name = "tbxAmount";
            this.tbxAmount.ReadOnly = true;
            this.tbxAmount.Size = new System.Drawing.Size(80, 21);
            this.tbxAmount.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(290, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "综合服务费：";
            // 
            // tbxServiceFee
            // 
            this.tbxServiceFee.Location = new System.Drawing.Point(373, 28);
            this.tbxServiceFee.Name = "tbxServiceFee";
            this.tbxServiceFee.ReadOnly = true;
            this.tbxServiceFee.Size = new System.Drawing.Size(80, 21);
            this.tbxServiceFee.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(565, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "典当利息：";
            // 
            // tbxInterestFee
            // 
            this.tbxInterestFee.Location = new System.Drawing.Point(636, 31);
            this.tbxInterestFee.Name = "tbxInterestFee";
            this.tbxInterestFee.ReadOnly = true;
            this.tbxInterestFee.Size = new System.Drawing.Size(80, 21);
            this.tbxInterestFee.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "返回服务费：";
            // 
            // tbxReturnFee
            // 
            this.tbxReturnFee.Location = new System.Drawing.Point(130, 73);
            this.tbxReturnFee.Name = "tbxReturnFee";
            this.tbxReturnFee.ReadOnly = true;
            this.tbxReturnFee.Size = new System.Drawing.Size(80, 21);
            this.tbxReturnFee.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(290, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "逾期服务费：";
            // 
            // tbxOverdueFee
            // 
            this.tbxOverdueFee.Location = new System.Drawing.Point(373, 73);
            this.tbxOverdueFee.Name = "tbxOverdueFee";
            this.tbxOverdueFee.ReadOnly = true;
            this.tbxOverdueFee.Size = new System.Drawing.Size(80, 21);
            this.tbxOverdueFee.TabIndex = 1;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(739, 413);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "打印预览";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(565, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "客户应付：";
            // 
            // tbxPaidFee
            // 
            this.tbxPaidFee.Location = new System.Drawing.Point(636, 73);
            this.tbxPaidFee.Name = "tbxPaidFee";
            this.tbxPaidFee.ReadOnly = true;
            this.tbxPaidFee.Size = new System.Drawing.Size(80, 21);
            this.tbxPaidFee.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbxInterestFee);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbxPaidFee);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbxOverdueFee);
            this.groupBox1.Controls.Add(this.tbxAmount);
            this.groupBox1.Controls.Add(this.tbxServiceFee);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbxReturnFee);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(12, 295);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(801, 112);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "赎当费用合计";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.monthCalendar1);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(12, 46);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(802, 243);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "当票详细信息";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClassName,
            this.Amount,
            this.ServiceFee,
            this.InterestFee,
            this.ReturnFee,
            this.OverdueFee});
            this.dataGridView1.Location = new System.Drawing.Point(6, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(790, 217);
            this.dataGridView1.TabIndex = 0;
            // 
            // ClassName
            // 
            this.ClassName.DataPropertyName = "ClassName";
            this.ClassName.HeaderText = "当品名称";
            this.ClassName.Name = "ClassName";
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            this.Amount.HeaderText = "典当金额";
            this.Amount.Name = "Amount";
            // 
            // ServiceFee
            // 
            this.ServiceFee.DataPropertyName = "ServiceFee";
            this.ServiceFee.HeaderText = "综合服务费";
            this.ServiceFee.Name = "ServiceFee";
            // 
            // InterestFee
            // 
            this.InterestFee.DataPropertyName = "InterestFee";
            this.InterestFee.HeaderText = "典当利息";
            this.InterestFee.Name = "InterestFee";
            // 
            // ReturnFee
            // 
            this.ReturnFee.DataPropertyName = "ReturnFee";
            this.ReturnFee.HeaderText = "返回服务费";
            this.ReturnFee.Name = "ReturnFee";
            // 
            // OverdueFee
            // 
            this.OverdueFee.DataPropertyName = "OverdueFee";
            this.OverdueFee.HeaderText = "逾期服务费";
            this.OverdueFee.Name = "OverdueFee";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(264, 53);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 1;
            this.monthCalendar1.Visible = false;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // RedeemPawnOperationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 448);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.tbxOperationDate);
            this.Controls.Add(this.label1);
            this.Name = "RedeemPawnOperationForm";
            this.TabText = "赎当操作";
            this.Text = "赎当操作";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxOperationDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxServiceFee;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxInterestFee;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxReturnFee;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxOverdueFee;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxPaidFee;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn InterestFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReturnFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn OverdueFee;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
    }
}