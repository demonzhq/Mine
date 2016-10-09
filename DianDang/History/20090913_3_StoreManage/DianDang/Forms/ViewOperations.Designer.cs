namespace DianDang
{
    partial class ViewOperations
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
            this.TicketNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PawnageClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OperationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OperationType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operater = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(801, 310);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查看流水操作";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TicketNumber,
            this.PawnageClass,
            this.OperationDate,
            this.OperationType,
            this.Operater});
            this.dataGridView1.Location = new System.Drawing.Point(6, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 60;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(789, 284);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // TicketNumber
            // 
            this.TicketNumber.DataPropertyName = "TicketNumber";
            this.TicketNumber.HeaderText = "当票号";
            this.TicketNumber.Name = "TicketNumber";
            this.TicketNumber.ReadOnly = true;
            this.TicketNumber.Width = 120;
            // 
            // PawnageClass
            // 
            this.PawnageClass.DataPropertyName = "PawnageClass";
            this.PawnageClass.HeaderText = "当品名称";
            this.PawnageClass.Name = "PawnageClass";
            this.PawnageClass.ReadOnly = true;
            this.PawnageClass.Width = 120;
            // 
            // OperationDate
            // 
            this.OperationDate.DataPropertyName = "OperationDate";
            this.OperationDate.HeaderText = "操作时间";
            this.OperationDate.Name = "OperationDate";
            this.OperationDate.ReadOnly = true;
            this.OperationDate.Width = 120;
            // 
            // OperationType
            // 
            this.OperationType.DataPropertyName = "OperationType";
            this.OperationType.HeaderText = "操作类型";
            this.OperationType.Name = "OperationType";
            this.OperationType.ReadOnly = true;
            this.OperationType.Width = 120;
            // 
            // Operater
            // 
            this.Operater.DataPropertyName = "Operater";
            this.Operater.HeaderText = "操作人";
            this.Operater.Name = "Operater";
            this.Operater.ReadOnly = true;
            this.Operater.Width = 120;
            // 
            // ViewOperations
            // 
            this.ClientSize = new System.Drawing.Size(826, 334);
            this.Controls.Add(this.groupBox1);
            this.Name = "ViewOperations";
            this.TabText = "查看流水操作";
            this.Text = "查看流水操作";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TicketNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn PawnageClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn OperationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn OperationType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operater;
    }
}