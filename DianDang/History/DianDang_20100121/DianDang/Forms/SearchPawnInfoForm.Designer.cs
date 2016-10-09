namespace DianDang
{
    partial class SearchPawnInfoForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTotalPage = new System.Windows.Forms.Label();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnPre = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.tbxCurrPage = new System.Windows.Forms.TextBox();
            this.cbxClassSelector = new System.Windows.Forms.ComboBox();
            this.btnShowPhoto = new System.Windows.Forms.Button();
            this.cbxSearchOption = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbxKeyWord = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxSearchRange = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.gbxCarInfo = new System.Windows.Forms.GroupBox();
            this.tbxCarCheckDate = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbxCarRoadDate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxCarInsuranceDate = new System.Windows.Forms.TextBox();
            this.tbxCarEngineNumber = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxCarCaseNumber = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxCarType = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxCarLicenseNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gbxHouseInfo = new System.Windows.Forms.GroupBox();
            this.tbxHouseNotarizaDate = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbxHouseInsuranceDate = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbxHouseRegisterDate = new System.Windows.Forms.TextBox();
            this.tbxHouseAddress = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tbxHouseArea = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tbxHouseCompactNumber = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.PawnageID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhotoPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CarID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HouseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OperationFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.FirstClass = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.SecondClass = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FeeRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InterestRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gbxCarInfo.SuspendLayout();
            this.gbxHouseInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.lblTotalPage);
            this.groupBox1.Controls.Add(this.btnLast);
            this.groupBox1.Controls.Add(this.btnPre);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.btnFirst);
            this.groupBox1.Controls.Add(this.btnNext);
            this.groupBox1.Controls.Add(this.tbxCurrPage);
            this.groupBox1.Controls.Add(this.cbxClassSelector);
            this.groupBox1.Controls.Add(this.btnShowPhoto);
            this.groupBox1.Controls.Add(this.cbxSearchOption);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.tbxKeyWord);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbxSearchRange);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(802, 415);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "当品查询";
            // 
            // lblTotalPage
            // 
            this.lblTotalPage.AutoSize = true;
            this.lblTotalPage.Location = new System.Drawing.Point(643, 389);
            this.lblTotalPage.Name = "lblTotalPage";
            this.lblTotalPage.Size = new System.Drawing.Size(11, 12);
            this.lblTotalPage.TabIndex = 44;
            this.lblTotalPage.Text = "0";
            // 
            // btnLast
            // 
            this.btnLast.Enabled = false;
            this.btnLast.Location = new System.Drawing.Point(727, 383);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(65, 23);
            this.btnLast.TabIndex = 41;
            this.btnLast.Text = "最后一页";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnPre
            // 
            this.btnPre.Enabled = false;
            this.btnPre.Location = new System.Drawing.Point(528, 383);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(64, 23);
            this.btnPre.TabIndex = 40;
            this.btnPre.Text = "上一页";
            this.btnPre.UseVisualStyleBackColor = true;
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(626, 390);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(11, 12);
            this.label14.TabIndex = 45;
            this.label14.Text = "/";
            // 
            // btnFirst
            // 
            this.btnFirst.Enabled = false;
            this.btnFirst.Location = new System.Drawing.Point(454, 383);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(66, 23);
            this.btnFirst.TabIndex = 39;
            this.btnFirst.Text = "第一页";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.Location = new System.Drawing.Point(662, 383);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(59, 23);
            this.btnNext.TabIndex = 42;
            this.btnNext.Text = "下一页";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tbxCurrPage
            // 
            this.tbxCurrPage.Enabled = false;
            this.tbxCurrPage.Location = new System.Drawing.Point(598, 385);
            this.tbxCurrPage.Name = "tbxCurrPage";
            this.tbxCurrPage.Size = new System.Drawing.Size(26, 21);
            this.tbxCurrPage.TabIndex = 43;
            this.tbxCurrPage.Text = "0";
            this.tbxCurrPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbxClassSelector
            // 
            this.cbxClassSelector.FormattingEnabled = true;
            this.cbxClassSelector.Location = new System.Drawing.Point(555, 20);
            this.cbxClassSelector.Name = "cbxClassSelector";
            this.cbxClassSelector.Size = new System.Drawing.Size(127, 20);
            this.cbxClassSelector.TabIndex = 38;
            // 
            // btnShowPhoto
            // 
            this.btnShowPhoto.Enabled = false;
            this.btnShowPhoto.Location = new System.Drawing.Point(14, 383);
            this.btnShowPhoto.Name = "btnShowPhoto";
            this.btnShowPhoto.Size = new System.Drawing.Size(86, 23);
            this.btnShowPhoto.TabIndex = 37;
            this.btnShowPhoto.Text = "察看照片";
            this.btnShowPhoto.UseVisualStyleBackColor = true;
            this.btnShowPhoto.Click += new System.EventHandler(this.btnShowPhoto_Click);
            // 
            // cbxSearchOption
            // 
            this.cbxSearchOption.FormattingEnabled = true;
            this.cbxSearchOption.Location = new System.Drawing.Point(331, 20);
            this.cbxSearchOption.Name = "cbxSearchOption";
            this.cbxSearchOption.Size = new System.Drawing.Size(127, 20);
            this.cbxSearchOption.TabIndex = 36;
            this.cbxSearchOption.SelectedIndexChanged += new System.EventHandler(this.cbxSearchOption_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Location = new System.Drawing.Point(260, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 35;
            this.label9.Text = "查询条件：";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(717, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 32;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbxKeyWord
            // 
            this.tbxKeyWord.Location = new System.Drawing.Point(555, 20);
            this.tbxKeyWord.Name = "tbxKeyWord";
            this.tbxKeyWord.Size = new System.Drawing.Size(127, 21);
            this.tbxKeyWord.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(496, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 30;
            this.label1.Text = "关键字：";
            // 
            // btnPrint
            // 
            this.btnPrint.Enabled = false;
            this.btnPrint.Location = new System.Drawing.Point(120, 383);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(86, 23);
            this.btnPrint.TabIndex = 29;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(32, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "当品状态：";
            // 
            // cbxSearchRange
            // 
            this.cbxSearchRange.FormattingEnabled = true;
            this.cbxSearchRange.Location = new System.Drawing.Point(103, 20);
            this.cbxSearchRange.Name = "cbxSearchRange";
            this.cbxSearchRange.Size = new System.Drawing.Size(127, 20);
            this.cbxSearchRange.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PawnageID,
            this.PhotoPath,
            this.CarID,
            this.HouseID,
            this.OperationFlag,
            this.FirstClass,
            this.SecondClass,
            this.Description,
            this.Weight,
            this.Price,
            this.FeeRate,
            this.InterestRate,
            this.Remark});
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(11, 49);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(781, 328);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // gbxCarInfo
            // 
            this.gbxCarInfo.Controls.Add(this.tbxCarCheckDate);
            this.gbxCarInfo.Controls.Add(this.label10);
            this.gbxCarInfo.Controls.Add(this.tbxCarRoadDate);
            this.gbxCarInfo.Controls.Add(this.label5);
            this.gbxCarInfo.Controls.Add(this.tbxCarInsuranceDate);
            this.gbxCarInfo.Controls.Add(this.tbxCarEngineNumber);
            this.gbxCarInfo.Controls.Add(this.label8);
            this.gbxCarInfo.Controls.Add(this.tbxCarCaseNumber);
            this.gbxCarInfo.Controls.Add(this.label7);
            this.gbxCarInfo.Controls.Add(this.label6);
            this.gbxCarInfo.Controls.Add(this.tbxCarType);
            this.gbxCarInfo.Controls.Add(this.label3);
            this.gbxCarInfo.Controls.Add(this.tbxCarLicenseNumber);
            this.gbxCarInfo.Controls.Add(this.label2);
            this.gbxCarInfo.Location = new System.Drawing.Point(12, 433);
            this.gbxCarInfo.Name = "gbxCarInfo";
            this.gbxCarInfo.Size = new System.Drawing.Size(802, 193);
            this.gbxCarInfo.TabIndex = 2;
            this.gbxCarInfo.TabStop = false;
            this.gbxCarInfo.Text = "车辆信息";
            // 
            // tbxCarCheckDate
            // 
            this.tbxCarCheckDate.Location = new System.Drawing.Point(657, 122);
            this.tbxCarCheckDate.Name = "tbxCarCheckDate";
            this.tbxCarCheckDate.Size = new System.Drawing.Size(100, 21);
            this.tbxCarCheckDate.TabIndex = 45;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(562, 125);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 12);
            this.label10.TabIndex = 44;
            this.label10.Text = "验车到期日：";
            // 
            // tbxCarRoadDate
            // 
            this.tbxCarRoadDate.Location = new System.Drawing.Point(361, 122);
            this.tbxCarRoadDate.Name = "tbxCarRoadDate";
            this.tbxCarRoadDate.Size = new System.Drawing.Size(100, 21);
            this.tbxCarRoadDate.TabIndex = 43;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(272, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 42;
            this.label5.Text = "养路费到期日：";
            // 
            // tbxCarInsuranceDate
            // 
            this.tbxCarInsuranceDate.AcceptsReturn = true;
            this.tbxCarInsuranceDate.Location = new System.Drawing.Point(106, 122);
            this.tbxCarInsuranceDate.Name = "tbxCarInsuranceDate";
            this.tbxCarInsuranceDate.Size = new System.Drawing.Size(100, 21);
            this.tbxCarInsuranceDate.TabIndex = 41;
            // 
            // tbxCarEngineNumber
            // 
            this.tbxCarEngineNumber.Location = new System.Drawing.Point(106, 74);
            this.tbxCarEngineNumber.Name = "tbxCarEngineNumber";
            this.tbxCarEngineNumber.Size = new System.Drawing.Size(100, 21);
            this.tbxCarEngineNumber.TabIndex = 40;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 38;
            this.label8.Text = "保险到期日：";
            // 
            // tbxCarCaseNumber
            // 
            this.tbxCarCaseNumber.Location = new System.Drawing.Point(361, 74);
            this.tbxCarCaseNumber.Name = "tbxCarCaseNumber";
            this.tbxCarCaseNumber.Size = new System.Drawing.Size(175, 21);
            this.tbxCarCaseNumber.TabIndex = 37;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(272, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 12);
            this.label7.TabIndex = 36;
            this.label7.Text = "车架号(VIN)：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "发动机号：";
            // 
            // tbxCarType
            // 
            this.tbxCarType.Location = new System.Drawing.Point(361, 25);
            this.tbxCarType.Name = "tbxCarType";
            this.tbxCarType.Size = new System.Drawing.Size(100, 21);
            this.tbxCarType.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(272, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "车辆型号：";
            // 
            // tbxCarLicenseNumber
            // 
            this.tbxCarLicenseNumber.Location = new System.Drawing.Point(106, 25);
            this.tbxCarLicenseNumber.Name = "tbxCarLicenseNumber";
            this.tbxCarLicenseNumber.Size = new System.Drawing.Size(100, 21);
            this.tbxCarLicenseNumber.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "车辆牌照：";
            // 
            // gbxHouseInfo
            // 
            this.gbxHouseInfo.Controls.Add(this.tbxHouseNotarizaDate);
            this.gbxHouseInfo.Controls.Add(this.label11);
            this.gbxHouseInfo.Controls.Add(this.tbxHouseInsuranceDate);
            this.gbxHouseInfo.Controls.Add(this.label12);
            this.gbxHouseInfo.Controls.Add(this.tbxHouseRegisterDate);
            this.gbxHouseInfo.Controls.Add(this.tbxHouseAddress);
            this.gbxHouseInfo.Controls.Add(this.label13);
            this.gbxHouseInfo.Controls.Add(this.label15);
            this.gbxHouseInfo.Controls.Add(this.tbxHouseArea);
            this.gbxHouseInfo.Controls.Add(this.label16);
            this.gbxHouseInfo.Controls.Add(this.tbxHouseCompactNumber);
            this.gbxHouseInfo.Controls.Add(this.label17);
            this.gbxHouseInfo.Location = new System.Drawing.Point(12, 433);
            this.gbxHouseInfo.Name = "gbxHouseInfo";
            this.gbxHouseInfo.Size = new System.Drawing.Size(802, 193);
            this.gbxHouseInfo.TabIndex = 46;
            this.gbxHouseInfo.TabStop = false;
            this.gbxHouseInfo.Text = "房产信息";
            // 
            // tbxHouseNotarizaDate
            // 
            this.tbxHouseNotarizaDate.Location = new System.Drawing.Point(657, 122);
            this.tbxHouseNotarizaDate.Name = "tbxHouseNotarizaDate";
            this.tbxHouseNotarizaDate.Size = new System.Drawing.Size(100, 21);
            this.tbxHouseNotarizaDate.TabIndex = 45;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(562, 125);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 12);
            this.label11.TabIndex = 44;
            this.label11.Text = "公证到期日：";
            // 
            // tbxHouseInsuranceDate
            // 
            this.tbxHouseInsuranceDate.Location = new System.Drawing.Point(361, 122);
            this.tbxHouseInsuranceDate.Name = "tbxHouseInsuranceDate";
            this.tbxHouseInsuranceDate.Size = new System.Drawing.Size(100, 21);
            this.tbxHouseInsuranceDate.TabIndex = 43;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(272, 125);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 12);
            this.label12.TabIndex = 42;
            this.label12.Text = "保险到期日：";
            // 
            // tbxHouseRegisterDate
            // 
            this.tbxHouseRegisterDate.Location = new System.Drawing.Point(106, 122);
            this.tbxHouseRegisterDate.Name = "tbxHouseRegisterDate";
            this.tbxHouseRegisterDate.Size = new System.Drawing.Size(100, 21);
            this.tbxHouseRegisterDate.TabIndex = 41;
            // 
            // tbxHouseAddress
            // 
            this.tbxHouseAddress.Location = new System.Drawing.Point(106, 74);
            this.tbxHouseAddress.Name = "tbxHouseAddress";
            this.tbxHouseAddress.Size = new System.Drawing.Size(548, 21);
            this.tbxHouseAddress.TabIndex = 40;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(23, 125);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 12);
            this.label13.TabIndex = 38;
            this.label13.Text = "登记到期日：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(23, 77);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 6;
            this.label15.Text = "地址：";
            // 
            // tbxHouseArea
            // 
            this.tbxHouseArea.Location = new System.Drawing.Point(554, 25);
            this.tbxHouseArea.Name = "tbxHouseArea";
            this.tbxHouseArea.Size = new System.Drawing.Size(100, 21);
            this.tbxHouseArea.TabIndex = 3;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(471, 28);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 12);
            this.label16.TabIndex = 2;
            this.label16.Text = "建筑面积：";
            // 
            // tbxHouseCompactNumber
            // 
            this.tbxHouseCompactNumber.Location = new System.Drawing.Point(106, 25);
            this.tbxHouseCompactNumber.Name = "tbxHouseCompactNumber";
            this.tbxHouseCompactNumber.Size = new System.Drawing.Size(160, 21);
            this.tbxHouseCompactNumber.TabIndex = 1;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(23, 28);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(65, 12);
            this.label17.TabIndex = 0;
            this.label17.Text = "房产证号：";
            // 
            // PawnageID
            // 
            this.PawnageID.DataPropertyName = "PawnageID";
            this.PawnageID.HeaderText = "PawnageID";
            this.PawnageID.Name = "PawnageID";
            this.PawnageID.ReadOnly = true;
            this.PawnageID.Visible = false;
            this.PawnageID.Width = 84;
            // 
            // PhotoPath
            // 
            this.PhotoPath.DataPropertyName = "PhotoPath";
            this.PhotoPath.HeaderText = "PhotoPath";
            this.PhotoPath.Name = "PhotoPath";
            this.PhotoPath.ReadOnly = true;
            this.PhotoPath.Visible = false;
            this.PhotoPath.Width = 84;
            // 
            // CarID
            // 
            this.CarID.DataPropertyName = "CarID";
            this.CarID.HeaderText = "CarID";
            this.CarID.Name = "CarID";
            this.CarID.ReadOnly = true;
            this.CarID.Visible = false;
            this.CarID.Width = 60;
            // 
            // HouseID
            // 
            this.HouseID.DataPropertyName = "HouseID";
            this.HouseID.HeaderText = "HouseID";
            this.HouseID.Name = "HouseID";
            this.HouseID.ReadOnly = true;
            this.HouseID.Visible = false;
            this.HouseID.Width = 72;
            // 
            // OperationFlag
            // 
            this.OperationFlag.DataPropertyName = "OperationFlag";
            this.OperationFlag.HeaderText = "操作";
            this.OperationFlag.Name = "OperationFlag";
            this.OperationFlag.ReadOnly = true;
            this.OperationFlag.Visible = false;
            this.OperationFlag.Width = 35;
            // 
            // FirstClass
            // 
            this.FirstClass.DataPropertyName = "FirstClass";
            this.FirstClass.HeaderText = "一级分类";
            this.FirstClass.Name = "FirstClass";
            this.FirstClass.ReadOnly = true;
            this.FirstClass.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.FirstClass.Width = 78;
            // 
            // SecondClass
            // 
            this.SecondClass.DataPropertyName = "SecondClass";
            this.SecondClass.HeaderText = "二级分类";
            this.SecondClass.Name = "SecondClass";
            this.SecondClass.ReadOnly = true;
            this.SecondClass.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.SecondClass.Width = 78;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "当品描述";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 78;
            // 
            // Weight
            // 
            this.Weight.DataPropertyName = "Weight";
            this.Weight.HeaderText = "当品重量";
            this.Weight.Name = "Weight";
            this.Weight.ReadOnly = true;
            this.Weight.Width = 78;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "当品当值";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 78;
            // 
            // FeeRate
            // 
            this.FeeRate.DataPropertyName = "FeeRate";
            this.FeeRate.HeaderText = "服务费率";
            this.FeeRate.Name = "FeeRate";
            this.FeeRate.ReadOnly = true;
            this.FeeRate.Width = 78;
            // 
            // InterestRate
            // 
            this.InterestRate.DataPropertyName = "InterestRate";
            this.InterestRate.HeaderText = "典当利息";
            this.InterestRate.Name = "InterestRate";
            this.InterestRate.ReadOnly = true;
            this.InterestRate.Width = 78;
            // 
            // Remark
            // 
            this.Remark.DataPropertyName = "Remark";
            this.Remark.HeaderText = "备注";
            this.Remark.Name = "Remark";
            this.Remark.ReadOnly = true;
            this.Remark.Width = 54;
            // 
            // SearchPawnInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 638);
            this.Controls.Add(this.gbxCarInfo);
            this.Controls.Add(this.gbxHouseInfo);
            this.Controls.Add(this.groupBox1);
            this.Name = "SearchPawnInfoForm";
            this.Text = "当品查询";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gbxCarInfo.ResumeLayout(false);
            this.gbxCarInfo.PerformLayout();
            this.gbxHouseInfo.ResumeLayout(false);
            this.gbxHouseInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxSearchRange;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxKeyWord;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox gbxCarInfo;
        private System.Windows.Forms.TextBox tbxCarType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxCarLicenseNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxCarCaseNumber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbxSearchOption;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbxCarEngineNumber;
        private System.Windows.Forms.TextBox tbxCarRoadDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxCarInsuranceDate;
        private System.Windows.Forms.TextBox tbxCarCheckDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox gbxHouseInfo;
        private System.Windows.Forms.TextBox tbxHouseNotarizaDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbxHouseInsuranceDate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbxHouseRegisterDate;
        private System.Windows.Forms.TextBox tbxHouseAddress;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbxHouseArea;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbxHouseCompactNumber;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnShowPhoto;
        private System.Windows.Forms.ComboBox cbxClassSelector;
        private System.Windows.Forms.Label lblTotalPage;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TextBox tbxCurrPage;
        private System.Windows.Forms.DataGridViewTextBoxColumn PawnageID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhotoPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn CarID;
        private System.Windows.Forms.DataGridViewTextBoxColumn HouseID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn OperationFlag;
        private System.Windows.Forms.DataGridViewComboBoxColumn FirstClass;
        private System.Windows.Forms.DataGridViewComboBoxColumn SecondClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn FeeRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn InterestRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
    }
}