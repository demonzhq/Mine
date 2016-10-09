namespace DianDang
{
    partial class SearchPawnTicketForm
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
            this.btnViewTicketInfo = new System.Windows.Forms.Button();
            this.lblTotalPage = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxSearchRange = new System.Windows.Forms.ComboBox();
            this.tbxCurrPage = new System.Windows.Forms.TextBox();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnPre = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbxKeyWord = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxSearchOption = new System.Windows.Forms.ComboBox();
            this.btnViewOperations = new System.Windows.Forms.Button();
            this.btnRenew = new System.Windows.Forms.Button();
            this.btnRedeem = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.TicketID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TickNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OperaterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnRedeem);
            this.groupBox1.Controls.Add(this.btnRenew);
            this.groupBox1.Controls.Add(this.btnViewOperations);
            this.groupBox1.Controls.Add(this.btnViewTicketInfo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbxSearchRange);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(802, 465);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "当票信息";
            // 
            // btnViewTicketInfo
            // 
            this.btnViewTicketInfo.Enabled = false;
            this.btnViewTicketInfo.Location = new System.Drawing.Point(8, 432);
            this.btnViewTicketInfo.Name = "btnViewTicketInfo";
            this.btnViewTicketInfo.Size = new System.Drawing.Size(104, 23);
            this.btnViewTicketInfo.TabIndex = 26;
            this.btnViewTicketInfo.Text = "查看当票信息";
            this.btnViewTicketInfo.UseVisualStyleBackColor = true;
            this.btnViewTicketInfo.Click += new System.EventHandler(this.btnViewTicketInfo_Click);
            // 
            // lblTotalPage
            // 
            this.lblTotalPage.AutoSize = true;
            this.lblTotalPage.Location = new System.Drawing.Point(658, 489);
            this.lblTotalPage.Name = "lblTotalPage";
            this.lblTotalPage.Size = new System.Drawing.Size(11, 12);
            this.lblTotalPage.TabIndex = 24;
            this.lblTotalPage.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "在库状态：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(641, 490);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 25;
            this.label3.Text = "/";
            // 
            // cbxSearchRange
            // 
            this.cbxSearchRange.FormattingEnabled = true;
            this.cbxSearchRange.Location = new System.Drawing.Point(102, 14);
            this.cbxSearchRange.Name = "cbxSearchRange";
            this.cbxSearchRange.Size = new System.Drawing.Size(127, 20);
            this.cbxSearchRange.TabIndex = 4;
            // 
            // tbxCurrPage
            // 
            this.tbxCurrPage.Enabled = false;
            this.tbxCurrPage.Location = new System.Drawing.Point(613, 485);
            this.tbxCurrPage.Name = "tbxCurrPage";
            this.tbxCurrPage.Size = new System.Drawing.Size(26, 21);
            this.tbxCurrPage.TabIndex = 23;
            this.tbxCurrPage.Text = "0";
            this.tbxCurrPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnLast
            // 
            this.btnLast.Enabled = false;
            this.btnLast.Location = new System.Drawing.Point(742, 483);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(65, 23);
            this.btnLast.TabIndex = 21;
            this.btnLast.Text = "最后一页";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.Location = new System.Drawing.Point(677, 483);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(59, 23);
            this.btnNext.TabIndex = 22;
            this.btnNext.Text = "下一页";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Enabled = false;
            this.btnFirst.Location = new System.Drawing.Point(469, 483);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(66, 23);
            this.btnFirst.TabIndex = 19;
            this.btnFirst.Text = "第一页";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnPre
            // 
            this.btnPre.Enabled = false;
            this.btnPre.Location = new System.Drawing.Point(543, 483);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(64, 23);
            this.btnPre.TabIndex = 20;
            this.btnPre.Text = "上一页";
            this.btnPre.UseVisualStyleBackColor = true;
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TicketID,
            this.TickNumber,
            this.StartDate,
            this.EndDate,
            this.StatusID,
            this.CustomerName,
            this.OperaterName});
            this.dataGridView1.Location = new System.Drawing.Point(11, 49);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(781, 377);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(727, 25);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbxKeyWord
            // 
            this.tbxKeyWord.Location = new System.Drawing.Point(571, 25);
            this.tbxKeyWord.Name = "tbxKeyWord";
            this.tbxKeyWord.Size = new System.Drawing.Size(127, 21);
            this.tbxKeyWord.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(501, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "关键字：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(263, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "查询条件：";
            // 
            // cbxSearchOption
            // 
            this.cbxSearchOption.FormattingEnabled = true;
            this.cbxSearchOption.Location = new System.Drawing.Point(333, 27);
            this.cbxSearchOption.Name = "cbxSearchOption";
            this.cbxSearchOption.Size = new System.Drawing.Size(127, 20);
            this.cbxSearchOption.TabIndex = 4;
            // 
            // btnViewOperations
            // 
            this.btnViewOperations.Enabled = false;
            this.btnViewOperations.Location = new System.Drawing.Point(118, 432);
            this.btnViewOperations.Name = "btnViewOperations";
            this.btnViewOperations.Size = new System.Drawing.Size(104, 23);
            this.btnViewOperations.TabIndex = 26;
            this.btnViewOperations.Text = "查看流水操作";
            this.btnViewOperations.UseVisualStyleBackColor = true;
            this.btnViewOperations.Click += new System.EventHandler(this.btnViewOperations_Click);
            // 
            // btnRenew
            // 
            this.btnRenew.Enabled = false;
            this.btnRenew.Location = new System.Drawing.Point(228, 432);
            this.btnRenew.Name = "btnRenew";
            this.btnRenew.Size = new System.Drawing.Size(47, 23);
            this.btnRenew.TabIndex = 26;
            this.btnRenew.Text = "续当";
            this.btnRenew.UseVisualStyleBackColor = true;
            this.btnRenew.Click += new System.EventHandler(this.btnRenew_Click);
            // 
            // btnRedeem
            // 
            this.btnRedeem.Enabled = false;
            this.btnRedeem.Location = new System.Drawing.Point(281, 432);
            this.btnRedeem.Name = "btnRedeem";
            this.btnRedeem.Size = new System.Drawing.Size(47, 23);
            this.btnRedeem.TabIndex = 26;
            this.btnRedeem.Text = "赎当";
            this.btnRedeem.UseVisualStyleBackColor = true;
            this.btnRedeem.Click += new System.EventHandler(this.btnRedeem_Click);
            // 
            // btnClose
            // 
            this.btnClose.Enabled = false;
            this.btnClose.Location = new System.Drawing.Point(334, 432);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(47, 23);
            this.btnClose.TabIndex = 26;
            this.btnClose.Text = "绝当";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.Enabled = false;
            this.btnClear.Location = new System.Drawing.Point(387, 433);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(47, 23);
            this.btnClear.TabIndex = 26;
            this.btnClear.Text = "清算";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // TicketID
            // 
            this.TicketID.DataPropertyName = "TicketID";
            this.TicketID.HeaderText = "TicketID";
            this.TicketID.Name = "TicketID";
            this.TicketID.ReadOnly = true;
            this.TicketID.Visible = false;
            // 
            // TickNumber
            // 
            this.TickNumber.DataPropertyName = "TicketNumber";
            this.TickNumber.HeaderText = "当票号";
            this.TickNumber.Name = "TickNumber";
            this.TickNumber.ReadOnly = true;
            this.TickNumber.Width = 120;
            // 
            // StartDate
            // 
            this.StartDate.DataPropertyName = "StartDate";
            this.StartDate.HeaderText = "起始时间";
            this.StartDate.Name = "StartDate";
            this.StartDate.ReadOnly = true;
            this.StartDate.Width = 120;
            // 
            // EndDate
            // 
            this.EndDate.DataPropertyName = "EndDate";
            this.EndDate.HeaderText = "结束时间";
            this.EndDate.Name = "EndDate";
            this.EndDate.ReadOnly = true;
            this.EndDate.Width = 120;
            // 
            // StatusID
            // 
            this.StatusID.DataPropertyName = "StatusID";
            this.StatusID.HeaderText = "当票状态";
            this.StatusID.Name = "StatusID";
            this.StatusID.ReadOnly = true;
            this.StatusID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.StatusID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.StatusID.Width = 120;
            // 
            // CustomerName
            // 
            this.CustomerName.DataPropertyName = "CustomerName";
            this.CustomerName.HeaderText = "客户名称";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            this.CustomerName.Width = 120;
            // 
            // OperaterName
            // 
            this.OperaterName.DataPropertyName = "OperaterName";
            this.OperaterName.HeaderText = "操作人";
            this.OperaterName.Name = "OperaterName";
            this.OperaterName.ReadOnly = true;
            this.OperaterName.Width = 120;
            // 
            // SearchPawnTicketForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 545);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tbxKeyWord);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxSearchOption);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTotalPage);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnPre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.tbxCurrPage);
            this.Name = "SearchPawnTicketForm";
            this.TabText = "当票查询";
            this.Text = "当票查询";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbxKeyWord;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxSearchOption;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnViewTicketInfo;
        private System.Windows.Forms.Label lblTotalPage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxCurrPage;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxSearchRange;
        private System.Windows.Forms.Button btnViewOperations;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRedeem;
        private System.Windows.Forms.Button btnRenew;
        private System.Windows.Forms.DataGridViewTextBoxColumn TicketID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TickNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndDate;
        private System.Windows.Forms.DataGridViewComboBoxColumn StatusID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn OperaterName;
    }
}