namespace DianDang
{
    partial class ClearOperationForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnClear = new System.Windows.Forms.Button();
            this.TicketNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OperationID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClassName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CloseDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReckonAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PawnageID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(802, 176);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "当品清算";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TicketNumber,
            this.OperationID,
            this.ClassName,
            this.CloseDate,
            this.Amount,
            this.ReckonAmount,
            this.PawnageID});
            this.dataGridView1.Location = new System.Drawing.Point(7, 21);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 50;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(789, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(733, 194);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "清算";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // TicketNumber
            // 
            this.TicketNumber.HeaderText = "当票号";
            this.TicketNumber.Name = "TicketNumber";
            this.TicketNumber.ReadOnly = true;
            // 
            // OperationID
            // 
            this.OperationID.HeaderText = "OperationID";
            this.OperationID.Name = "OperationID";
            this.OperationID.Visible = false;
            // 
            // ClassName
            // 
            this.ClassName.HeaderText = "当品分类";
            this.ClassName.Name = "ClassName";
            this.ClassName.ReadOnly = true;
            // 
            // CloseDate
            // 
            this.CloseDate.HeaderText = "绝当日期";
            this.CloseDate.Name = "CloseDate";
            this.CloseDate.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "典当价格";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // ReckonAmount
            // 
            this.ReckonAmount.HeaderText = "清算价格";
            this.ReckonAmount.Name = "ReckonAmount";
            // 
            // PawnageID
            // 
            this.PawnageID.HeaderText = "PawnageID";
            this.PawnageID.Name = "PawnageID";
            this.PawnageID.Visible = false;
            // 
            // ClearOperationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 283);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.groupBox1);
            this.Name = "ClearOperationForm";
            this.TabText = "清算操作";
            this.Text = "清算操作";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridViewTextBoxColumn TicketNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn OperationID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CloseDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReckonAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn PawnageID;

    }
}