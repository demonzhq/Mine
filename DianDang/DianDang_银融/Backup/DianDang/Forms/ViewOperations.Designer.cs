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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.TicketNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PawnageClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OperationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OperationType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operater = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OperationNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(801, 310);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "�鿴��ˮ����";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TicketNumber,
            this.PawnageClass,
            this.OperationDate,
            this.OperationType,
            this.StartDate,
            this.EndDate,
            this.Operater,
            this.OperationNumber});
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(6, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.RowHeadersWidth = 60;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(789, 284);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // TicketNumber
            // 
            this.TicketNumber.DataPropertyName = "TicketNumber";
            this.TicketNumber.HeaderText = "��Ʊ��";
            this.TicketNumber.Name = "TicketNumber";
            this.TicketNumber.ReadOnly = true;
            this.TicketNumber.Width = 120;
            // 
            // PawnageClass
            // 
            this.PawnageClass.DataPropertyName = "PawnageClass";
            this.PawnageClass.HeaderText = "��Ʒ����";
            this.PawnageClass.Name = "PawnageClass";
            this.PawnageClass.ReadOnly = true;
            this.PawnageClass.Visible = false;
            this.PawnageClass.Width = 120;
            // 
            // OperationDate
            // 
            this.OperationDate.DataPropertyName = "OperationDate";
            this.OperationDate.HeaderText = "����ʱ��";
            this.OperationDate.Name = "OperationDate";
            this.OperationDate.ReadOnly = true;
            this.OperationDate.Width = 120;
            // 
            // OperationType
            // 
            this.OperationType.DataPropertyName = "OperationType";
            this.OperationType.HeaderText = "��������";
            this.OperationType.Name = "OperationType";
            this.OperationType.ReadOnly = true;
            this.OperationType.Width = 120;
            // 
            // StartDate
            // 
            this.StartDate.DataPropertyName = "StartDate";
            this.StartDate.HeaderText = "��ʼʱ��";
            this.StartDate.Name = "StartDate";
            this.StartDate.ReadOnly = true;
            // 
            // EndDate
            // 
            this.EndDate.DataPropertyName = "EndDate";
            this.EndDate.HeaderText = "����ʱ��";
            this.EndDate.Name = "EndDate";
            this.EndDate.ReadOnly = true;
            // 
            // Operater
            // 
            this.Operater.DataPropertyName = "Operater";
            this.Operater.HeaderText = "������";
            this.Operater.Name = "Operater";
            this.Operater.ReadOnly = true;
            this.Operater.Width = 120;
            // 
            // OperationNumber
            // 
            this.OperationNumber.DataPropertyName = "OperationNumber";
            this.OperationNumber.HeaderText = "OperationNumber";
            this.OperationNumber.Name = "OperationNumber";
            this.OperationNumber.ReadOnly = true;
            this.OperationNumber.Visible = false;
            // 
            // ViewOperations
            // 
            this.ClientSize = new System.Drawing.Size(826, 334);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "ViewOperations";
            this.TabText = "�鿴��ˮ����";
            this.Text = "�鿴��ˮ����";
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
        private System.Windows.Forms.DataGridViewTextBoxColumn StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operater;
        private System.Windows.Forms.DataGridViewTextBoxColumn OperationNumber;
    }
}