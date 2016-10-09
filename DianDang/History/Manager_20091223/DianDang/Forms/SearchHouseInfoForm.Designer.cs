namespace DianDang
{
    partial class SearchHouseInfoForm
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
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompactNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Area = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegisterDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InsuranceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NotarizationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HouseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelHouseInfo = new System.Windows.Forms.TableLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.tbxHouseAddress = new System.Windows.Forms.TextBox();
            this.tbxHouseCompactNumber = new System.Windows.Forms.TextBox();
            this.tbxHouseArea = new System.Windows.Forms.TextBox();
            this.tbxHouseRegisterDate = new System.Windows.Forms.TextBox();
            this.tbxHouseInsuranceDate = new System.Windows.Forms.TextBox();
            this.tbxHouseNotarizationDate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxKeyWord = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panelHouseInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Address,
            this.CompactNumber,
            this.Area,
            this.RegisterDate,
            this.InsuranceDate,
            this.NotarizationDate,
            this.HouseID});
            dataGridView1.Location = new System.Drawing.Point(6, 20);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 23;
            dataGridView1.Size = new System.Drawing.Size(790, 216);
            dataGridView1.TabIndex = 0;
            dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // Address
            // 
            this.Address.HeaderText = "房产地址";
            this.Address.Name = "Address";
            this.Address.Width = 190;
            // 
            // CompactNumber
            // 
            this.CompactNumber.HeaderText = "合同号";
            this.CompactNumber.Name = "CompactNumber";
            // 
            // Area
            // 
            this.Area.HeaderText = "建筑面积";
            this.Area.Name = "Area";
            // 
            // RegisterDate
            // 
            this.RegisterDate.HeaderText = "登记到期日";
            this.RegisterDate.Name = "RegisterDate";
            this.RegisterDate.Width = 120;
            // 
            // InsuranceDate
            // 
            this.InsuranceDate.HeaderText = "保险到期日";
            this.InsuranceDate.Name = "InsuranceDate";
            this.InsuranceDate.Width = 120;
            // 
            // NotarizationDate
            // 
            this.NotarizationDate.HeaderText = "公正到期日";
            this.NotarizationDate.Name = "NotarizationDate";
            this.NotarizationDate.Width = 120;
            // 
            // HouseID
            // 
            this.HouseID.HeaderText = "HouseID";
            this.HouseID.Name = "HouseID";
            this.HouseID.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(802, 242);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "房产信息";
            // 
            // panelHouseInfo
            // 
            this.panelHouseInfo.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.panelHouseInfo.ColumnCount = 6;
            this.panelHouseInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.panelHouseInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.panelHouseInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.panelHouseInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.panelHouseInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.panelHouseInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 148F));
            this.panelHouseInfo.Controls.Add(this.label10, 0, 0);
            this.panelHouseInfo.Controls.Add(this.label16, 1, 0);
            this.panelHouseInfo.Controls.Add(this.label32, 2, 0);
            this.panelHouseInfo.Controls.Add(this.label33, 3, 0);
            this.panelHouseInfo.Controls.Add(this.label34, 4, 0);
            this.panelHouseInfo.Controls.Add(this.label35, 5, 0);
            this.panelHouseInfo.Controls.Add(this.tbxHouseAddress, 0, 1);
            this.panelHouseInfo.Controls.Add(this.tbxHouseCompactNumber, 1, 1);
            this.panelHouseInfo.Controls.Add(this.tbxHouseArea, 2, 1);
            this.panelHouseInfo.Controls.Add(this.tbxHouseRegisterDate, 3, 1);
            this.panelHouseInfo.Controls.Add(this.tbxHouseInsuranceDate, 4, 1);
            this.panelHouseInfo.Controls.Add(this.tbxHouseNotarizationDate, 5, 1);
            this.panelHouseInfo.Location = new System.Drawing.Point(17, 288);
            this.panelHouseInfo.Name = "panelHouseInfo";
            this.panelHouseInfo.RowCount = 2;
            this.panelHouseInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelHouseInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelHouseInfo.Size = new System.Drawing.Size(791, 71);
            this.panelHouseInfo.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 1);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(194, 34);
            this.label10.TabIndex = 0;
            this.label10.Text = "房产地址";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(205, 1);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(94, 34);
            this.label16.TabIndex = 0;
            this.label16.Text = "合同号";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label32
            // 
            this.label32.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(306, 1);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(94, 34);
            this.label32.TabIndex = 0;
            this.label32.Text = "建筑面积";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label33
            // 
            this.label33.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(407, 1);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(114, 34);
            this.label33.TabIndex = 0;
            this.label33.Text = "登记到期日";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label34
            // 
            this.label34.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(528, 1);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(114, 34);
            this.label34.TabIndex = 0;
            this.label34.Text = "保险到期日";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label35
            // 
            this.label35.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(649, 1);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(142, 34);
            this.label35.TabIndex = 0;
            this.label35.Text = "公正到期日";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbxHouseAddress
            // 
            this.tbxHouseAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxHouseAddress.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxHouseAddress.Location = new System.Drawing.Point(4, 39);
            this.tbxHouseAddress.Name = "tbxHouseAddress";
            this.tbxHouseAddress.Size = new System.Drawing.Size(194, 26);
            this.tbxHouseAddress.TabIndex = 1;
            this.tbxHouseAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbxHouseCompactNumber
            // 
            this.tbxHouseCompactNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxHouseCompactNumber.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxHouseCompactNumber.Location = new System.Drawing.Point(205, 39);
            this.tbxHouseCompactNumber.Name = "tbxHouseCompactNumber";
            this.tbxHouseCompactNumber.Size = new System.Drawing.Size(94, 26);
            this.tbxHouseCompactNumber.TabIndex = 1;
            this.tbxHouseCompactNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbxHouseArea
            // 
            this.tbxHouseArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxHouseArea.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxHouseArea.Location = new System.Drawing.Point(306, 39);
            this.tbxHouseArea.Name = "tbxHouseArea";
            this.tbxHouseArea.Size = new System.Drawing.Size(94, 26);
            this.tbxHouseArea.TabIndex = 1;
            this.tbxHouseArea.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbxHouseRegisterDate
            // 
            this.tbxHouseRegisterDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxHouseRegisterDate.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxHouseRegisterDate.Location = new System.Drawing.Point(407, 39);
            this.tbxHouseRegisterDate.Name = "tbxHouseRegisterDate";
            this.tbxHouseRegisterDate.Size = new System.Drawing.Size(114, 26);
            this.tbxHouseRegisterDate.TabIndex = 1;
            this.tbxHouseRegisterDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbxHouseInsuranceDate
            // 
            this.tbxHouseInsuranceDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxHouseInsuranceDate.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxHouseInsuranceDate.Location = new System.Drawing.Point(528, 39);
            this.tbxHouseInsuranceDate.Name = "tbxHouseInsuranceDate";
            this.tbxHouseInsuranceDate.Size = new System.Drawing.Size(114, 26);
            this.tbxHouseInsuranceDate.TabIndex = 1;
            this.tbxHouseInsuranceDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbxHouseNotarizationDate
            // 
            this.tbxHouseNotarizationDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxHouseNotarizationDate.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxHouseNotarizationDate.Location = new System.Drawing.Point(649, 39);
            this.tbxHouseNotarizationDate.Name = "tbxHouseNotarizationDate";
            this.tbxHouseNotarizationDate.Size = new System.Drawing.Size(142, 26);
            this.tbxHouseNotarizationDate.TabIndex = 1;
            this.tbxHouseNotarizationDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 30;
            this.label1.Text = "当票号：";
            // 
            // tbxKeyWord
            // 
            this.tbxKeyWord.Location = new System.Drawing.Point(69, 12);
            this.tbxKeyWord.Name = "tbxKeyWord";
            this.tbxKeyWord.Size = new System.Drawing.Size(124, 21);
            this.tbxKeyWord.TabIndex = 31;
            this.tbxKeyWord.Text = "0";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(199, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 32;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(733, 375);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 33;
            this.btnEdit.Text = "修改";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // SearchHouseInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 410);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tbxKeyWord);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelHouseInfo);
            this.Controls.Add(this.groupBox1);
            this.Name = "SearchHouseInfoForm";
            this.TabText = "房产查询";
            this.Text = "房产查询";
            ((System.ComponentModel.ISupportInitialize)(dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panelHouseInfo.ResumeLayout(false);
            this.panelHouseInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel panelHouseInfo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox tbxHouseAddress;
        private System.Windows.Forms.TextBox tbxHouseCompactNumber;
        private System.Windows.Forms.TextBox tbxHouseArea;
        private System.Windows.Forms.TextBox tbxHouseRegisterDate;
        private System.Windows.Forms.TextBox tbxHouseInsuranceDate;
        private System.Windows.Forms.TextBox tbxHouseNotarizationDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxKeyWord;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompactNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Area;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegisterDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn InsuranceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn NotarizationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn HouseID;
    }
}