namespace DianDang
{
    partial class SearchOperationForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbxEndDate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.btnCaculate = new System.Windows.Forms.Button();
            this.tbxStartDate = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRedeem = new System.Windows.Forms.Button();
            this.btnRenew = new System.Windows.Forms.Button();
            this.btnViewOperations = new System.Windows.Forms.Button();
            this.btnViewTicketInfo = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxSearchRange = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.TicketID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TickNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OperationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OperaterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTotalPage = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxCurrPage = new System.Windows.Forms.TextBox();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnPre = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.gbCaculate = new System.Windows.Forms.GroupBox();
            this.lblUnclearAmount = new System.Windows.Forms.Label();
            this.lblRedeemAmount = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label98 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.label93 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label85 = new System.Windows.Forms.Label();
            this.lblClearAmount = new System.Windows.Forms.Label();
            this.label83 = new System.Windows.Forms.Label();
            this.lblFrezeeAmount = new System.Windows.Forms.Label();
            this.lblCloseClearAmount = new System.Windows.Forms.Label();
            this.lblReckoningRL = new System.Windows.Forms.Label();
            this.lblOverdueFee = new System.Windows.Forms.Label();
            this.lblCloseAmount = new System.Windows.Forms.Label();
            this.lblInterestFee = new System.Windows.Forms.Label();
            this.lblRenewServiceFee = new System.Windows.Forms.Label();
            this.lblCreateServiceFee = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gbCaculate.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.tbxEndDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.monthCalendar1);
            this.groupBox1.Controls.Add(this.btnCaculate);
            this.groupBox1.Controls.Add(this.tbxStartDate);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.label2);
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
            this.groupBox1.Size = new System.Drawing.Size(802, 415);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "当票信息";
            // 
            // tbxEndDate
            // 
            this.tbxEndDate.Location = new System.Drawing.Point(484, 14);
            this.tbxEndDate.Name = "tbxEndDate";
            this.tbxEndDate.Size = new System.Drawing.Size(127, 21);
            this.tbxEndDate.TabIndex = 30;
            this.tbxEndDate.Click += new System.EventHandler(tbxEndDate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(425, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 29;
            this.label1.Text = "结束时间：";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(273, 144);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 28;
            this.monthCalendar1.TitleBackColor = System.Drawing.Color.SandyBrown;
            this.monthCalendar1.Visible = false;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            this.monthCalendar1.LostFocus += new System.EventHandler(this.monthCalendar1_LostFocus);
            // 
            // btnCaculate
            // 
            this.btnCaculate.Enabled = false;
            this.btnCaculate.Location = new System.Drawing.Point(441, 385);
            this.btnCaculate.Name = "btnCaculate";
            this.btnCaculate.Size = new System.Drawing.Size(45, 23);
            this.btnCaculate.TabIndex = 27;
            this.btnCaculate.Text = "统计";
            this.btnCaculate.UseVisualStyleBackColor = true;
            this.btnCaculate.Click += new System.EventHandler(this.btnCaculate_Click);
            // 
            // tbxStartDate
            // 
            this.tbxStartDate.Location = new System.Drawing.Point(281, 14);
            this.tbxStartDate.Name = "tbxStartDate";
            this.tbxStartDate.Size = new System.Drawing.Size(127, 21);
            this.tbxStartDate.TabIndex = 7;
            this.tbxStartDate.Click += new System.EventHandler(tbxStartDate_Click);
            // 
            // btnClear
            // 
            this.btnClear.Enabled = false;
            this.btnClear.Location = new System.Drawing.Point(387, 385);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(47, 23);
            this.btnClear.TabIndex = 26;
            this.btnClear.Text = "清算";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(222, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "开始时间：";
            // 
            // btnClose
            // 
            this.btnClose.Enabled = false;
            this.btnClose.Location = new System.Drawing.Point(334, 384);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(47, 23);
            this.btnClose.TabIndex = 26;
            this.btnClose.Text = "绝当";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRedeem
            // 
            this.btnRedeem.Enabled = false;
            this.btnRedeem.Location = new System.Drawing.Point(281, 384);
            this.btnRedeem.Name = "btnRedeem";
            this.btnRedeem.Size = new System.Drawing.Size(47, 23);
            this.btnRedeem.TabIndex = 26;
            this.btnRedeem.Text = "赎当";
            this.btnRedeem.UseVisualStyleBackColor = true;
            this.btnRedeem.Click += new System.EventHandler(this.btnRedeem_Click);
            // 
            // btnRenew
            // 
            this.btnRenew.Enabled = false;
            this.btnRenew.Location = new System.Drawing.Point(228, 384);
            this.btnRenew.Name = "btnRenew";
            this.btnRenew.Size = new System.Drawing.Size(47, 23);
            this.btnRenew.TabIndex = 26;
            this.btnRenew.Text = "续当";
            this.btnRenew.UseVisualStyleBackColor = true;
            this.btnRenew.Click += new System.EventHandler(this.btnRenew_Click);
            // 
            // btnViewOperations
            // 
            this.btnViewOperations.Enabled = false;
            this.btnViewOperations.Location = new System.Drawing.Point(118, 384);
            this.btnViewOperations.Name = "btnViewOperations";
            this.btnViewOperations.Size = new System.Drawing.Size(104, 23);
            this.btnViewOperations.TabIndex = 26;
            this.btnViewOperations.Text = "查看流水操作";
            this.btnViewOperations.UseVisualStyleBackColor = true;
            this.btnViewOperations.Click += new System.EventHandler(this.btnViewOperations_Click);
            // 
            // btnViewTicketInfo
            // 
            this.btnViewTicketInfo.Enabled = false;
            this.btnViewTicketInfo.Location = new System.Drawing.Point(8, 384);
            this.btnViewTicketInfo.Name = "btnViewTicketInfo";
            this.btnViewTicketInfo.Size = new System.Drawing.Size(104, 23);
            this.btnViewTicketInfo.TabIndex = 26;
            this.btnViewTicketInfo.Text = "查看当票信息";
            this.btnViewTicketInfo.UseVisualStyleBackColor = true;
            this.btnViewTicketInfo.Click += new System.EventHandler(this.btnViewTicketInfo_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(32, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "操作类别：";
            // 
            // cbxSearchRange
            // 
            this.cbxSearchRange.FormattingEnabled = true;
            this.cbxSearchRange.Location = new System.Drawing.Point(102, 14);
            this.cbxSearchRange.Name = "cbxSearchRange";
            this.cbxSearchRange.Size = new System.Drawing.Size(101, 20);
            this.cbxSearchRange.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TicketID,
            this.TickNumber,
            this.OperationDate,
            this.StatusID,
            this.CustomerName,
            this.OperaterName});
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(11, 49);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(781, 328);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
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
            // OperationDate
            // 
            this.OperationDate.DataPropertyName = "OperationDate";
            this.OperationDate.HeaderText = "操作时间";
            this.OperationDate.Name = "OperationDate";
            this.OperationDate.ReadOnly = true;
            this.OperationDate.Width = 120;
            // 
            // StatusID
            // 
            this.StatusID.DataPropertyName = "StatusID";
            this.StatusID.HeaderText = "操作";
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
            // lblTotalPage
            // 
            this.lblTotalPage.AutoSize = true;
            this.lblTotalPage.Location = new System.Drawing.Point(659, 440);
            this.lblTotalPage.Name = "lblTotalPage";
            this.lblTotalPage.Size = new System.Drawing.Size(11, 12);
            this.lblTotalPage.TabIndex = 24;
            this.lblTotalPage.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(642, 441);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 25;
            this.label3.Text = "/";
            // 
            // tbxCurrPage
            // 
            this.tbxCurrPage.Enabled = false;
            this.tbxCurrPage.Location = new System.Drawing.Point(614, 436);
            this.tbxCurrPage.Name = "tbxCurrPage";
            this.tbxCurrPage.Size = new System.Drawing.Size(26, 21);
            this.tbxCurrPage.TabIndex = 23;
            this.tbxCurrPage.Text = "0";
            this.tbxCurrPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnLast
            // 
            this.btnLast.Enabled = false;
            this.btnLast.Location = new System.Drawing.Point(743, 434);
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
            this.btnNext.Location = new System.Drawing.Point(678, 434);
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
            this.btnFirst.Location = new System.Drawing.Point(470, 434);
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
            this.btnPre.Location = new System.Drawing.Point(544, 434);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(64, 23);
            this.btnPre.TabIndex = 20;
            this.btnPre.Text = "上一页";
            this.btnPre.UseVisualStyleBackColor = true;
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
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
            // gbCaculate
            // 
            this.gbCaculate.BackColor = System.Drawing.SystemColors.Control;
            this.gbCaculate.Controls.Add(this.lblUnclearAmount);
            this.gbCaculate.Controls.Add(this.lblRedeemAmount);
            this.gbCaculate.Controls.Add(this.label7);
            this.gbCaculate.Controls.Add(this.label13);
            this.gbCaculate.Controls.Add(this.label28);
            this.gbCaculate.Controls.Add(this.label98);
            this.gbCaculate.Controls.Add(this.label);
            this.gbCaculate.Controls.Add(this.label93);
            this.gbCaculate.Controls.Add(this.label14);
            this.gbCaculate.Controls.Add(this.label11);
            this.gbCaculate.Controls.Add(this.label26);
            this.gbCaculate.Controls.Add(this.label85);
            this.gbCaculate.Controls.Add(this.lblClearAmount);
            this.gbCaculate.Controls.Add(this.label83);
            this.gbCaculate.Controls.Add(this.lblFrezeeAmount);
            this.gbCaculate.Controls.Add(this.lblCloseClearAmount);
            this.gbCaculate.Controls.Add(this.lblReckoningRL);
            this.gbCaculate.Controls.Add(this.lblOverdueFee);
            this.gbCaculate.Controls.Add(this.lblCloseAmount);
            this.gbCaculate.Controls.Add(this.lblInterestFee);
            this.gbCaculate.Controls.Add(this.lblRenewServiceFee);
            this.gbCaculate.Controls.Add(this.lblCreateServiceFee);
            this.gbCaculate.Controls.Add(this.label8);
            this.gbCaculate.Controls.Add(this.lblTotalCount);
            this.gbCaculate.Controls.Add(this.lblTotalAmount);
            this.gbCaculate.Controls.Add(this.label6);
            this.gbCaculate.Controls.Add(this.label5);
            this.gbCaculate.Location = new System.Drawing.Point(13, 478);
            this.gbCaculate.Name = "gbCaculate";
            this.gbCaculate.Size = new System.Drawing.Size(802, 148);
            this.gbCaculate.TabIndex = 26;
            this.gbCaculate.TabStop = false;
            this.gbCaculate.Text = "统计";
            this.gbCaculate.Visible = false;
            // 
            // lblUnclearAmount
            // 
            this.lblUnclearAmount.AutoSize = true;
            this.lblUnclearAmount.Location = new System.Drawing.Point(99, 88);
            this.lblUnclearAmount.Name = "lblUnclearAmount";
            this.lblUnclearAmount.Size = new System.Drawing.Size(11, 12);
            this.lblUnclearAmount.TabIndex = 11;
            this.lblUnclearAmount.Text = "0";
            // 
            // lblRedeemAmount
            // 
            this.lblRedeemAmount.AutoSize = true;
            this.lblRedeemAmount.Location = new System.Drawing.Point(99, 65);
            this.lblRedeemAmount.Name = "lblRedeemAmount";
            this.lblRedeemAmount.Size = new System.Drawing.Size(11, 12);
            this.lblRedeemAmount.TabIndex = 11;
            this.lblRedeemAmount.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "未清算：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(17, 65);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 12;
            this.label13.Text = "已赎回：";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BackColor = System.Drawing.SystemColors.Control;
            this.label28.Location = new System.Drawing.Point(568, 65);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(89, 12);
            this.label28.TabIndex = 6;
            this.label28.Text = "绝当清算金额：";
            // 
            // label98
            // 
            this.label98.AutoSize = true;
            this.label98.BackColor = System.Drawing.SystemColors.Control;
            this.label98.Location = new System.Drawing.Point(580, 109);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(77, 12);
            this.label98.TabIndex = 6;
            this.label98.Text = "逾期服务费：";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.BackColor = System.Drawing.SystemColors.Control;
            this.label.Location = new System.Drawing.Point(373, 65);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(89, 12);
            this.label.TabIndex = 7;
            this.label.Text = "绝当处理金额：";
            // 
            // label93
            // 
            this.label93.AutoSize = true;
            this.label93.BackColor = System.Drawing.SystemColors.Control;
            this.label93.Location = new System.Drawing.Point(397, 109);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(65, 12);
            this.label93.TabIndex = 7;
            this.label93.Text = "典当利息：";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.SystemColors.Control;
            this.label14.Location = new System.Drawing.Point(409, 88);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 4;
            this.label14.Text = "已冻结：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.Control;
            this.label11.Location = new System.Drawing.Point(209, 88);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 4;
            this.label11.Text = "清算盈亏：";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.SystemColors.Control;
            this.label26.Location = new System.Drawing.Point(209, 65);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(65, 12);
            this.label26.TabIndex = 4;
            this.label26.Text = "绝当金额：";
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.BackColor = System.Drawing.SystemColors.Control;
            this.label85.Location = new System.Drawing.Point(197, 109);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(77, 12);
            this.label85.TabIndex = 4;
            this.label85.Text = "续当服务费：";
            // 
            // lblClearAmount
            // 
            this.lblClearAmount.AutoSize = true;
            this.lblClearAmount.Location = new System.Drawing.Point(674, 65);
            this.lblClearAmount.Name = "lblClearAmount";
            this.lblClearAmount.Size = new System.Drawing.Size(11, 12);
            this.lblClearAmount.TabIndex = 3;
            this.lblClearAmount.Text = "0";
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.BackColor = System.Drawing.SystemColors.Control;
            this.label83.Location = new System.Drawing.Point(19, 109);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(77, 12);
            this.label83.TabIndex = 5;
            this.label83.Text = "建当服务费：";
            // 
            // lblFrezeeAmount
            // 
            this.lblFrezeeAmount.AutoSize = true;
            this.lblFrezeeAmount.Location = new System.Drawing.Point(494, 88);
            this.lblFrezeeAmount.Name = "lblFrezeeAmount";
            this.lblFrezeeAmount.Size = new System.Drawing.Size(11, 12);
            this.lblFrezeeAmount.TabIndex = 3;
            this.lblFrezeeAmount.Text = "0";
            // 
            // lblCloseClearAmount
            // 
            this.lblCloseClearAmount.AutoSize = true;
            this.lblCloseClearAmount.Location = new System.Drawing.Point(494, 65);
            this.lblCloseClearAmount.Name = "lblCloseClearAmount";
            this.lblCloseClearAmount.Size = new System.Drawing.Size(11, 12);
            this.lblCloseClearAmount.TabIndex = 3;
            this.lblCloseClearAmount.Text = "0";
            // 
            // lblReckoningRL
            // 
            this.lblReckoningRL.AutoSize = true;
            this.lblReckoningRL.Location = new System.Drawing.Point(299, 88);
            this.lblReckoningRL.Name = "lblReckoningRL";
            this.lblReckoningRL.Size = new System.Drawing.Size(11, 12);
            this.lblReckoningRL.TabIndex = 3;
            this.lblReckoningRL.Text = "0";
            // 
            // lblOverdueFee
            // 
            this.lblOverdueFee.AutoSize = true;
            this.lblOverdueFee.Location = new System.Drawing.Point(674, 109);
            this.lblOverdueFee.Name = "lblOverdueFee";
            this.lblOverdueFee.Size = new System.Drawing.Size(11, 12);
            this.lblOverdueFee.TabIndex = 3;
            this.lblOverdueFee.Text = "0";
            // 
            // lblCloseAmount
            // 
            this.lblCloseAmount.AutoSize = true;
            this.lblCloseAmount.Location = new System.Drawing.Point(299, 65);
            this.lblCloseAmount.Name = "lblCloseAmount";
            this.lblCloseAmount.Size = new System.Drawing.Size(11, 12);
            this.lblCloseAmount.TabIndex = 3;
            this.lblCloseAmount.Text = "0";
            // 
            // lblInterestFee
            // 
            this.lblInterestFee.AutoSize = true;
            this.lblInterestFee.Location = new System.Drawing.Point(494, 109);
            this.lblInterestFee.Name = "lblInterestFee";
            this.lblInterestFee.Size = new System.Drawing.Size(11, 12);
            this.lblInterestFee.TabIndex = 3;
            this.lblInterestFee.Text = "0";
            // 
            // lblRenewServiceFee
            // 
            this.lblRenewServiceFee.AutoSize = true;
            this.lblRenewServiceFee.Location = new System.Drawing.Point(299, 109);
            this.lblRenewServiceFee.Name = "lblRenewServiceFee";
            this.lblRenewServiceFee.Size = new System.Drawing.Size(11, 12);
            this.lblRenewServiceFee.TabIndex = 3;
            this.lblRenewServiceFee.Text = "0";
            // 
            // lblCreateServiceFee
            // 
            this.lblCreateServiceFee.AutoSize = true;
            this.lblCreateServiceFee.Location = new System.Drawing.Point(99, 109);
            this.lblCreateServiceFee.Name = "lblCreateServiceFee";
            this.lblCreateServiceFee.Size = new System.Drawing.Size(11, 12);
            this.lblCreateServiceFee.TabIndex = 3;
            this.lblCreateServiceFee.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 2;
            this.label8.Text = "其 中 ： ";
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Location = new System.Drawing.Point(98, 20);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(11, 12);
            this.lblTotalCount.TabIndex = 1;
            this.lblTotalCount.Text = "0";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new System.Drawing.Point(299, 20);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(11, 12);
            this.lblTotalAmount.TabIndex = 0;
            this.lblTotalAmount.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(219, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "典当额：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "总笔数：";
            // 
            // SearchOperationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 638);
            this.Controls.Add(this.gbCaculate);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTotalPage);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnPre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.tbxCurrPage);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "SearchOperationForm";
            this.TabText = "操作查询";
            this.Text = "操作查询";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gbCaculate.ResumeLayout(false);
            this.gbCaculate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }





        void monthCalendar1_LostFocus(object sender, System.EventArgs e)
        {
            this.monthCalendar1.Hide();
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbxStartDate;
        private System.Windows.Forms.Label label2;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn OperationDate;
        private System.Windows.Forms.DataGridViewComboBoxColumn StatusID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn OperaterName;
        private System.Windows.Forms.GroupBox gbCaculate;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnCaculate;
        private System.Windows.Forms.Label label98;
        private System.Windows.Forms.Label label93;
        private System.Windows.Forms.Label label85;
        private System.Windows.Forms.Label label83;
        private System.Windows.Forms.Label lblRedeemAmount;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label lblClearAmount;
        private System.Windows.Forms.Label lblCloseClearAmount;
        private System.Windows.Forms.Label lblOverdueFee;
        private System.Windows.Forms.Label lblCloseAmount;
        private System.Windows.Forms.Label lblInterestFee;
        private System.Windows.Forms.Label lblRenewServiceFee;
        private System.Windows.Forms.Label lblCreateServiceFee;
        private System.Windows.Forms.Label lblUnclearAmount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblReckoningRL;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblFrezeeAmount;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.TextBox tbxEndDate;
        private System.Windows.Forms.Label label1;
    }
}