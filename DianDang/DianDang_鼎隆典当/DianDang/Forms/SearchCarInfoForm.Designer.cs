namespace DianDang
{
    partial class SearchCarInfoForm
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
            this.TicketNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LicenseNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CarType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EngineNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CarcaseNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InsuranceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoadtollDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CarID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelCarInfo = new System.Windows.Forms.TableLayoutPanel();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.tbxCarLicenceNumber = new System.Windows.Forms.TextBox();
            this.tbxCarType = new System.Windows.Forms.TextBox();
            this.tbxCarEngineNumber = new System.Windows.Forms.TextBox();
            this.tbxCarcaseNumber = new System.Windows.Forms.TextBox();
            this.tbxCarInsuranceDate = new System.Windows.Forms.TextBox();
            this.tbxCarRoadtollDate = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.tbxCarCheckDate = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbxKeyWord = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(dataGridView1)).BeginInit();
            this.panelCarInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(802, 242);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "车辆信息";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TicketNumber,
            this.CustomerName,
            this.LicenseNumber,
            this.CarType,
            this.EngineNumber,
            this.CarcaseNumber,
            this.InsuranceDate,
            this.RoadtollDate,
            this.CheckDate,
            this.CarID});
            dataGridView1.Location = new System.Drawing.Point(6, 20);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 23;
            dataGridView1.Size = new System.Drawing.Size(790, 216);
            dataGridView1.TabIndex = 0;
            dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // TicketNumber
            // 
            this.TicketNumber.HeaderText = "当票号";
            this.TicketNumber.Name = "TicketNumber";
            this.TicketNumber.Width = 100;
            // 
            // CustomerName
            // 
            this.CustomerName.HeaderText = "客户姓名";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.Width = 80;
            // 
            // LicenseNumber
            // 
            this.LicenseNumber.HeaderText = "牌照号码";
            this.LicenseNumber.Name = "LicenseNumber";
            // 
            // CarType
            // 
            this.CarType.HeaderText = "车辆型号";
            this.CarType.Name = "CarType";
            // 
            // EngineNumber
            // 
            this.EngineNumber.HeaderText = "发动机号码";
            this.EngineNumber.Name = "EngineNumber";
            // 
            // CarcaseNumber
            // 
            this.CarcaseNumber.HeaderText = "车架号";
            this.CarcaseNumber.Name = "CarcaseNumber";
            this.CarcaseNumber.Width = 120;
            // 
            // InsuranceDate
            // 
            this.InsuranceDate.HeaderText = "保险到期日";
            this.InsuranceDate.Name = "InsuranceDate";
            this.InsuranceDate.Width = 110;
            // 
            // RoadtollDate
            // 
            this.RoadtollDate.HeaderText = "养路费到期日";
            this.RoadtollDate.Name = "RoadtollDate";
            this.RoadtollDate.Width = 110;
            // 
            // CheckDate
            // 
            this.CheckDate.HeaderText = "验车到期日";
            this.CheckDate.Name = "CheckDate";
            this.CheckDate.Width = 110;
            // 
            // CarID
            // 
            this.CarID.HeaderText = "CarID";
            this.CarID.Name = "CarID";
            this.CarID.Visible = false;
            // 
            // panelCarInfo
            // 
            this.panelCarInfo.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.panelCarInfo.ColumnCount = 9;
            this.panelCarInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.panelCarInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.panelCarInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.panelCarInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.panelCarInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.panelCarInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.panelCarInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 122F));
            this.panelCarInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelCarInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.panelCarInfo.Controls.Add(this.label36, 0, 0);
            this.panelCarInfo.Controls.Add(this.label37, 1, 0);
            this.panelCarInfo.Controls.Add(this.label41, 2, 0);
            this.panelCarInfo.Controls.Add(this.label42, 3, 0);
            this.panelCarInfo.Controls.Add(this.label43, 4, 0);
            this.panelCarInfo.Controls.Add(this.label44, 5, 0);
            this.panelCarInfo.Controls.Add(this.tbxCarLicenceNumber, 0, 1);
            this.panelCarInfo.Controls.Add(this.tbxCarType, 1, 1);
            this.panelCarInfo.Controls.Add(this.tbxCarEngineNumber, 2, 1);
            this.panelCarInfo.Controls.Add(this.tbxCarcaseNumber, 3, 1);
            this.panelCarInfo.Controls.Add(this.tbxCarInsuranceDate, 4, 1);
            this.panelCarInfo.Controls.Add(this.tbxCarRoadtollDate, 5, 1);
            this.panelCarInfo.Controls.Add(this.label45, 6, 0);
            this.panelCarInfo.Controls.Add(this.tbxCarCheckDate, 6, 1);
            this.panelCarInfo.Location = new System.Drawing.Point(15, 289);
            this.panelCarInfo.Name = "panelCarInfo";
            this.panelCarInfo.RowCount = 2;
            this.panelCarInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelCarInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelCarInfo.Size = new System.Drawing.Size(789, 71);
            this.panelCarInfo.TabIndex = 38;
            // 
            // label36
            // 
            this.label36.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(4, 1);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(94, 34);
            this.label36.TabIndex = 0;
            this.label36.Text = "牌照号码";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label37
            // 
            this.label37.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(105, 1);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(94, 34);
            this.label37.TabIndex = 0;
            this.label37.Text = "车辆型号";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label41
            // 
            this.label41.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(206, 1);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(94, 34);
            this.label41.TabIndex = 0;
            this.label41.Text = "发动机号码";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label42
            // 
            this.label42.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(307, 1);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(114, 34);
            this.label42.TabIndex = 0;
            this.label42.Text = "车架号";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label43
            // 
            this.label43.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(428, 1);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(114, 34);
            this.label43.TabIndex = 0;
            this.label43.Text = "保险到期日";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label44
            // 
            this.label44.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(549, 1);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(114, 34);
            this.label44.TabIndex = 0;
            this.label44.Text = "养路费到期日";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbxCarLicenceNumber
            // 
            this.tbxCarLicenceNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxCarLicenceNumber.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxCarLicenceNumber.Location = new System.Drawing.Point(4, 39);
            this.tbxCarLicenceNumber.Name = "tbxCarLicenceNumber";
            this.tbxCarLicenceNumber.Size = new System.Drawing.Size(94, 26);
            this.tbxCarLicenceNumber.TabIndex = 1;
            this.tbxCarLicenceNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbxCarType
            // 
            this.tbxCarType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxCarType.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxCarType.Location = new System.Drawing.Point(105, 39);
            this.tbxCarType.Name = "tbxCarType";
            this.tbxCarType.Size = new System.Drawing.Size(94, 26);
            this.tbxCarType.TabIndex = 1;
            this.tbxCarType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbxCarEngineNumber
            // 
            this.tbxCarEngineNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxCarEngineNumber.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxCarEngineNumber.Location = new System.Drawing.Point(206, 39);
            this.tbxCarEngineNumber.Name = "tbxCarEngineNumber";
            this.tbxCarEngineNumber.Size = new System.Drawing.Size(94, 26);
            this.tbxCarEngineNumber.TabIndex = 1;
            this.tbxCarEngineNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbxCarcaseNumber
            // 
            this.tbxCarcaseNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxCarcaseNumber.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxCarcaseNumber.Location = new System.Drawing.Point(307, 39);
            this.tbxCarcaseNumber.Name = "tbxCarcaseNumber";
            this.tbxCarcaseNumber.Size = new System.Drawing.Size(114, 26);
            this.tbxCarcaseNumber.TabIndex = 1;
            this.tbxCarcaseNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbxCarInsuranceDate
            // 
            this.tbxCarInsuranceDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxCarInsuranceDate.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxCarInsuranceDate.Location = new System.Drawing.Point(428, 39);
            this.tbxCarInsuranceDate.Name = "tbxCarInsuranceDate";
            this.tbxCarInsuranceDate.Size = new System.Drawing.Size(114, 26);
            this.tbxCarInsuranceDate.TabIndex = 1;
            this.tbxCarInsuranceDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbxCarRoadtollDate
            // 
            this.tbxCarRoadtollDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxCarRoadtollDate.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxCarRoadtollDate.Location = new System.Drawing.Point(549, 39);
            this.tbxCarRoadtollDate.Name = "tbxCarRoadtollDate";
            this.tbxCarRoadtollDate.Size = new System.Drawing.Size(114, 26);
            this.tbxCarRoadtollDate.TabIndex = 1;
            this.tbxCarRoadtollDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label45
            // 
            this.label45.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(670, 1);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(116, 34);
            this.label45.TabIndex = 0;
            this.label45.Text = "验车到期日";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbxCarCheckDate
            // 
            this.tbxCarCheckDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxCarCheckDate.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxCarCheckDate.Location = new System.Drawing.Point(670, 39);
            this.tbxCarCheckDate.Name = "tbxCarCheckDate";
            this.tbxCarCheckDate.Size = new System.Drawing.Size(116, 26);
            this.tbxCarCheckDate.TabIndex = 1;
            this.tbxCarCheckDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(197, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 41;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbxKeyWord
            // 
            this.tbxKeyWord.Location = new System.Drawing.Point(67, 14);
            this.tbxKeyWord.Name = "tbxKeyWord";
            this.tbxKeyWord.Size = new System.Drawing.Size(124, 21);
            this.tbxKeyWord.TabIndex = 40;
            this.tbxKeyWord.Text = "0";
            this.tbxKeyWord.KeyPress += new System.Windows.Forms.KeyPressEventHandler(tbxKeyWord_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 39;
            this.label1.Text = "当票号：";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(726, 375);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 42;
            this.btnEdit.Text = "修改";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // SearchCarInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 410);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tbxKeyWord);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelCarInfo);
            this.Controls.Add(this.groupBox1);
            this.Name = "SearchCarInfoForm";
            this.TabText = "车辆查询";
            this.Text = "车辆查询";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(dataGridView1)).EndInit();
            this.panelCarInfo.ResumeLayout(false);
            this.panelCarInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel panelCarInfo;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.TextBox tbxCarLicenceNumber;
        private System.Windows.Forms.TextBox tbxCarType;
        private System.Windows.Forms.TextBox tbxCarEngineNumber;
        private System.Windows.Forms.TextBox tbxCarcaseNumber;
        private System.Windows.Forms.TextBox tbxCarInsuranceDate;
        private System.Windows.Forms.TextBox tbxCarRoadtollDate;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.TextBox tbxCarCheckDate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbxKeyWord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TicketNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LicenseNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn CarType;
        private System.Windows.Forms.DataGridViewTextBoxColumn EngineNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn CarcaseNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn InsuranceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoadtollDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CheckDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CarID;
    }
}