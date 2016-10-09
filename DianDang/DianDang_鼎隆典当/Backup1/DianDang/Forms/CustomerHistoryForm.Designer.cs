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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.gbxSummery = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblRedeenAmount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblInHouseAmount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblCloseAmount = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblInHouseAmountPercent = new System.Windows.Forms.Label();
            this.lblRedeenAmountPercent = new System.Windows.Forms.Label();
            this.lblCloseAmountPercent = new System.Windows.Forms.Label();
            this.lblCloseCountPercent = new System.Windows.Forms.Label();
            this.lblRedeenCountPercent = new System.Windows.Forms.Label();
            this.lblInHouseCountPercent = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblCloseCount = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblRedeenCount = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblInHouseCount = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTotalServiceFee = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblTotalInterestFee = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblLastDate = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gbxSummery.SuspendLayout();
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
            this.btnQueryByInput.Location = new System.Drawing.Point(448, 15);
            this.btnQueryByInput.Name = "btnQueryByInput";
            this.btnQueryByInput.Size = new System.Drawing.Size(91, 23);
            this.btnQueryByInput.TabIndex = 0;
            this.btnQueryByInput.Text = "手动查询";
            this.btnQueryByInput.UseVisualStyleBackColor = true;
            this.btnQueryByInput.Click += new System.EventHandler(this.btnQueryByInput_Click);
            // 
            // tbxCardNumber
            // 
            this.tbxCardNumber.Location = new System.Drawing.Point(199, 17);
            this.tbxCardNumber.Name = "tbxCardNumber";
            this.tbxCardNumber.Size = new System.Drawing.Size(215, 21);
            this.tbxCardNumber.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(128, 20);
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
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
            // gbxSummery
            // 
            this.gbxSummery.Controls.Add(this.lblLastDate);
            this.gbxSummery.Controls.Add(this.label17);
            this.gbxSummery.Controls.Add(this.lblStartDate);
            this.gbxSummery.Controls.Add(this.label13);
            this.gbxSummery.Controls.Add(this.lblTotalInterestFee);
            this.gbxSummery.Controls.Add(this.label10);
            this.gbxSummery.Controls.Add(this.lblTotalServiceFee);
            this.gbxSummery.Controls.Add(this.label8);
            this.gbxSummery.Controls.Add(this.lblCloseCountPercent);
            this.gbxSummery.Controls.Add(this.lblRedeenCountPercent);
            this.gbxSummery.Controls.Add(this.lblInHouseCountPercent);
            this.gbxSummery.Controls.Add(this.label12);
            this.gbxSummery.Controls.Add(this.lblCloseCount);
            this.gbxSummery.Controls.Add(this.label14);
            this.gbxSummery.Controls.Add(this.label15);
            this.gbxSummery.Controls.Add(this.label16);
            this.gbxSummery.Controls.Add(this.lblRedeenCount);
            this.gbxSummery.Controls.Add(this.label18);
            this.gbxSummery.Controls.Add(this.lblInHouseCount);
            this.gbxSummery.Controls.Add(this.label20);
            this.gbxSummery.Controls.Add(this.lblTotalCount);
            this.gbxSummery.Controls.Add(this.label22);
            this.gbxSummery.Controls.Add(this.lblCloseAmountPercent);
            this.gbxSummery.Controls.Add(this.lblRedeenAmountPercent);
            this.gbxSummery.Controls.Add(this.lblInHouseAmountPercent);
            this.gbxSummery.Controls.Add(this.label9);
            this.gbxSummery.Controls.Add(this.lblCloseAmount);
            this.gbxSummery.Controls.Add(this.label7);
            this.gbxSummery.Controls.Add(this.label6);
            this.gbxSummery.Controls.Add(this.label5);
            this.gbxSummery.Controls.Add(this.lblRedeenAmount);
            this.gbxSummery.Controls.Add(this.label4);
            this.gbxSummery.Controls.Add(this.lblInHouseAmount);
            this.gbxSummery.Controls.Add(this.label3);
            this.gbxSummery.Controls.Add(this.lblTotalAmount);
            this.gbxSummery.Controls.Add(this.label2);
            this.gbxSummery.Location = new System.Drawing.Point(13, 371);
            this.gbxSummery.Name = "gbxSummery";
            this.gbxSummery.Size = new System.Drawing.Size(801, 260);
            this.gbxSummery.TabIndex = 4;
            this.gbxSummery.TabStop = false;
            this.gbxSummery.Text = "统计信息";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(235, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "占：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(235, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "占：";
            // 
            // lblRedeenAmount
            // 
            this.lblRedeenAmount.AutoSize = true;
            this.lblRedeenAmount.Location = new System.Drawing.Point(115, 75);
            this.lblRedeenAmount.Name = "lblRedeenAmount";
            this.lblRedeenAmount.Size = new System.Drawing.Size(65, 12);
            this.lblRedeenAmount.TabIndex = 5;
            this.lblRedeenAmount.Text = "赎回金额：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "赎回金额：";
            // 
            // lblInHouseAmount
            // 
            this.lblInHouseAmount.AutoSize = true;
            this.lblInHouseAmount.Location = new System.Drawing.Point(115, 51);
            this.lblInHouseAmount.Name = "lblInHouseAmount";
            this.lblInHouseAmount.Size = new System.Drawing.Size(65, 12);
            this.lblInHouseAmount.TabIndex = 3;
            this.lblInHouseAmount.Text = "在库金额：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "在库金额：";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new System.Drawing.Point(115, 28);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(65, 12);
            this.lblTotalAmount.TabIndex = 1;
            this.lblTotalAmount.Text = "典当金额：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "总计金额：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(40, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 8;
            this.label7.Text = "绝当金额：";
            // 
            // lblCloseAmount
            // 
            this.lblCloseAmount.AutoSize = true;
            this.lblCloseAmount.Location = new System.Drawing.Point(115, 99);
            this.lblCloseAmount.Name = "lblCloseAmount";
            this.lblCloseAmount.Size = new System.Drawing.Size(65, 12);
            this.lblCloseAmount.TabIndex = 9;
            this.lblCloseAmount.Text = "绝当金额：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(235, 99);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 10;
            this.label9.Text = "占：";
            // 
            // lblInHouseAmountPercent
            // 
            this.lblInHouseAmountPercent.AutoSize = true;
            this.lblInHouseAmountPercent.Location = new System.Drawing.Point(270, 51);
            this.lblInHouseAmountPercent.Name = "lblInHouseAmountPercent";
            this.lblInHouseAmountPercent.Size = new System.Drawing.Size(65, 12);
            this.lblInHouseAmountPercent.TabIndex = 11;
            this.lblInHouseAmountPercent.Text = "在库金额：";
            // 
            // lblRedeenAmountPercent
            // 
            this.lblRedeenAmountPercent.AutoSize = true;
            this.lblRedeenAmountPercent.Location = new System.Drawing.Point(270, 75);
            this.lblRedeenAmountPercent.Name = "lblRedeenAmountPercent";
            this.lblRedeenAmountPercent.Size = new System.Drawing.Size(65, 12);
            this.lblRedeenAmountPercent.TabIndex = 12;
            this.lblRedeenAmountPercent.Text = "赎回金额：";
            // 
            // lblCloseAmountPercent
            // 
            this.lblCloseAmountPercent.AutoSize = true;
            this.lblCloseAmountPercent.Location = new System.Drawing.Point(270, 99);
            this.lblCloseAmountPercent.Name = "lblCloseAmountPercent";
            this.lblCloseAmountPercent.Size = new System.Drawing.Size(65, 12);
            this.lblCloseAmountPercent.TabIndex = 13;
            this.lblCloseAmountPercent.Text = "绝当金额：";
            // 
            // lblCloseCountPercent
            // 
            this.lblCloseCountPercent.AutoSize = true;
            this.lblCloseCountPercent.Location = new System.Drawing.Point(628, 99);
            this.lblCloseCountPercent.Name = "lblCloseCountPercent";
            this.lblCloseCountPercent.Size = new System.Drawing.Size(65, 12);
            this.lblCloseCountPercent.TabIndex = 27;
            this.lblCloseCountPercent.Text = "绝当金额：";
            // 
            // lblRedeenCountPercent
            // 
            this.lblRedeenCountPercent.AutoSize = true;
            this.lblRedeenCountPercent.Location = new System.Drawing.Point(628, 75);
            this.lblRedeenCountPercent.Name = "lblRedeenCountPercent";
            this.lblRedeenCountPercent.Size = new System.Drawing.Size(65, 12);
            this.lblRedeenCountPercent.TabIndex = 26;
            this.lblRedeenCountPercent.Text = "赎回金额：";
            // 
            // lblInHouseCountPercent
            // 
            this.lblInHouseCountPercent.AutoSize = true;
            this.lblInHouseCountPercent.Location = new System.Drawing.Point(628, 51);
            this.lblInHouseCountPercent.Name = "lblInHouseCountPercent";
            this.lblInHouseCountPercent.Size = new System.Drawing.Size(65, 12);
            this.lblInHouseCountPercent.TabIndex = 25;
            this.lblInHouseCountPercent.Text = "在库金额：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(593, 99);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 24;
            this.label12.Text = "占：";
            // 
            // lblCloseCount
            // 
            this.lblCloseCount.AutoSize = true;
            this.lblCloseCount.Location = new System.Drawing.Point(473, 99);
            this.lblCloseCount.Name = "lblCloseCount";
            this.lblCloseCount.Size = new System.Drawing.Size(65, 12);
            this.lblCloseCount.TabIndex = 23;
            this.lblCloseCount.Text = "绝当金额：";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(398, 99);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 22;
            this.label14.Text = "绝当笔数：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(593, 75);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 12);
            this.label15.TabIndex = 21;
            this.label15.Text = "占：";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(593, 51);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 12);
            this.label16.TabIndex = 20;
            this.label16.Text = "占：";
            // 
            // lblRedeenCount
            // 
            this.lblRedeenCount.AutoSize = true;
            this.lblRedeenCount.Location = new System.Drawing.Point(473, 75);
            this.lblRedeenCount.Name = "lblRedeenCount";
            this.lblRedeenCount.Size = new System.Drawing.Size(65, 12);
            this.lblRedeenCount.TabIndex = 19;
            this.lblRedeenCount.Text = "赎回金额：";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(398, 75);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(65, 12);
            this.label18.TabIndex = 18;
            this.label18.Text = "赎回笔数：";
            // 
            // lblInHouseCount
            // 
            this.lblInHouseCount.AutoSize = true;
            this.lblInHouseCount.Location = new System.Drawing.Point(473, 51);
            this.lblInHouseCount.Name = "lblInHouseCount";
            this.lblInHouseCount.Size = new System.Drawing.Size(65, 12);
            this.lblInHouseCount.TabIndex = 17;
            this.lblInHouseCount.Text = "在库金额：";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(398, 51);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(65, 12);
            this.label20.TabIndex = 16;
            this.label20.Text = "在库笔数：";
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Location = new System.Drawing.Point(473, 28);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(65, 12);
            this.lblTotalCount.TabIndex = 15;
            this.lblTotalCount.Text = "典当金额：";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(398, 28);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(65, 12);
            this.label22.TabIndex = 14;
            this.label22.Text = "总计笔数：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(40, 142);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 28;
            this.label8.Text = "已收服务费：";
            // 
            // lblTotalServiceFee
            // 
            this.lblTotalServiceFee.AutoSize = true;
            this.lblTotalServiceFee.Location = new System.Drawing.Point(123, 142);
            this.lblTotalServiceFee.Name = "lblTotalServiceFee";
            this.lblTotalServiceFee.Size = new System.Drawing.Size(77, 12);
            this.lblTotalServiceFee.TabIndex = 29;
            this.lblTotalServiceFee.Text = "已收服务费：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(270, 142);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 30;
            this.label10.Text = "已收利息：";
            // 
            // lblTotalInterestFee
            // 
            this.lblTotalInterestFee.AutoSize = true;
            this.lblTotalInterestFee.Location = new System.Drawing.Point(341, 142);
            this.lblTotalInterestFee.Name = "lblTotalInterestFee";
            this.lblTotalInterestFee.Size = new System.Drawing.Size(65, 12);
            this.lblTotalInterestFee.TabIndex = 31;
            this.lblTotalInterestFee.Text = "已收利息：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(40, 188);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 32;
            this.label13.Text = "起档日期：";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(123, 188);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(65, 12);
            this.lblStartDate.TabIndex = 33;
            this.lblStartDate.Text = "起档日期：";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(270, 188);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(65, 12);
            this.label17.TabIndex = 34;
            this.label17.Text = "最近日期：";
            // 
            // lblLastDate
            // 
            this.lblLastDate.AutoSize = true;
            this.lblLastDate.Location = new System.Drawing.Point(341, 188);
            this.lblLastDate.Name = "lblLastDate";
            this.lblLastDate.Size = new System.Drawing.Size(65, 12);
            this.lblLastDate.TabIndex = 35;
            this.lblLastDate.Text = "最近日期：";
            // 
            // CustomerHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 679);
            this.Controls.Add(this.gbxSummery);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxCardNumber);
            this.Controls.Add(this.btnQueryByInput);
            this.Controls.Add(this.btnQueryByCard);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "CustomerHistoryForm";
            this.TabText = "客户历史信息";
            this.Text = "客户历史信息";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gbxSummery.ResumeLayout(false);
            this.gbxSummery.PerformLayout();
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
        private System.Windows.Forms.GroupBox gbxSummery;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblInHouseAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblRedeenAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCloseAmountPercent;
        private System.Windows.Forms.Label lblRedeenAmountPercent;
        private System.Windows.Forms.Label lblInHouseAmountPercent;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblCloseAmount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblCloseCountPercent;
        private System.Windows.Forms.Label lblRedeenCountPercent;
        private System.Windows.Forms.Label lblInHouseCountPercent;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblCloseCount;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblRedeenCount;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblInHouseCount;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblTotalInterestFee;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblTotalServiceFee;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblLastDate;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblStartDate;
    }
}