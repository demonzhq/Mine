namespace DianDang
{
    partial class CustomerHistoryForm
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
            this.btnQueryByCard = new System.Windows.Forms.Button();
            this.btnQueryByInput = new System.Windows.Forms.Button();
            this.tbxCardNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TicketID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TicketNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.BtnOperation = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnQueryByCard
            // 
            this.btnQueryByCard.Location = new System.Drawing.Point(19, 15);
            this.btnQueryByCard.Name = "btnQueryByCard";
            this.btnQueryByCard.Size = new System.Drawing.Size(91, 23);
            this.btnQueryByCard.TabIndex = 0;
            this.btnQueryByCard.Text = "读卡查询";
            this.btnQueryByCard.UseVisualStyleBackColor = true;
            this.btnQueryByCard.Click += new System.EventHandler(this.btnQueryByCard_Click);
            // 
            // btnQueryByInput
            // 
            this.btnQueryByInput.Location = new System.Drawing.Point(428, 15);
            this.btnQueryByInput.Name = "btnQueryByInput";
            this.btnQueryByInput.Size = new System.Drawing.Size(91, 23);
            this.btnQueryByInput.TabIndex = 0;
            this.btnQueryByInput.Text = "手动查询";
            this.btnQueryByInput.UseVisualStyleBackColor = true;
            this.btnQueryByInput.Click += new System.EventHandler(this.btnQueryByInput_Click);
            // 
            // tbxCardNumber
            // 
            this.tbxCardNumber.Location = new System.Drawing.Point(207, 15);
            this.tbxCardNumber.Name = "tbxCardNumber";
            this.tbxCardNumber.Size = new System.Drawing.Size(215, 21);
            this.tbxCardNumber.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(141, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "身份证号：";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(13, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(801, 319);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "客户历史信息";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomerName,
            this.TicketID,
            this.TicketNumber,
            this.StartDate,
            this.EndDate,
            this.StatusID,
            this.BtnOperation});
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(6, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 50;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(789, 293);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // CustomerName
            // 
            this.CustomerName.HeaderText = "客户姓名";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            // 
            // TicketID
            // 
            this.TicketID.HeaderText = "TicketID";
            this.TicketID.Name = "TicketID";
            this.TicketID.ReadOnly = true;
            this.TicketID.Visible = false;
            // 
            // TicketNumber
            // 
            this.TicketNumber.HeaderText = "当票号";
            this.TicketNumber.Name = "TicketNumber";
            this.TicketNumber.ReadOnly = true;
            // 
            // StartDate
            // 
            this.StartDate.HeaderText = "建当日期";
            this.StartDate.Name = "StartDate";
            this.StartDate.ReadOnly = true;
            // 
            // EndDate
            // 
            this.EndDate.HeaderText = "结束日期";
            this.EndDate.Name = "EndDate";
            this.EndDate.ReadOnly = true;
            // 
            // StatusID
            // 
            this.StatusID.HeaderText = "当前状态";
            this.StatusID.Name = "StatusID";
            this.StatusID.ReadOnly = true;
            this.StatusID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.StatusID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // BtnOperation
            // 
            this.BtnOperation.HeaderText = "查看当票";
            this.BtnOperation.Name = "BtnOperation";
            this.BtnOperation.ReadOnly = true;
            this.BtnOperation.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BtnOperation.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.BtnOperation.Text = "查看当票";
            this.BtnOperation.UseColumnTextForButtonValue = true;
            // 
            // CustomerHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 376);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxCardNumber);
            this.Controls.Add(this.btnQueryByInput);
            this.Controls.Add(this.btnQueryByCard);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "CustomerHistoryForm";
            this.TabText = "客户历史信息";
            this.Text = "客户历史信息";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnQueryByCard;
        private System.Windows.Forms.Button btnQueryByInput;
        private System.Windows.Forms.TextBox tbxCardNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TicketID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TicketNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndDate;
        private System.Windows.Forms.DataGridViewComboBoxColumn StatusID;
        private System.Windows.Forms.DataGridViewButtonColumn BtnOperation;
    }
}