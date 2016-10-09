namespace DianDang
{
    partial class SearchCustomerForm
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lblTotalPage = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxCurrPage = new System.Windows.Forms.TextBox();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnPre = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContactPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CertTypeID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.CertNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbxKeyWord = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxSearchOption = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.lblTotalPage);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbxCurrPage);
            this.groupBox1.Controls.Add(this.btnLast);
            this.groupBox1.Controls.Add(this.btnNext);
            this.groupBox1.Controls.Add(this.btnFirst);
            this.groupBox1.Controls.Add(this.btnPre);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.tbxKeyWord);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbxSearchOption);
            this.groupBox1.Location = new System.Drawing.Point(4, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(819, 465);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询";
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(108, 431);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 18;
            this.btnDelete.Text = "删除所选";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(11, 431);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 17;
            this.btnUpdate.Text = "更新所选";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lblTotalPage
            // 
            this.lblTotalPage.AutoSize = true;
            this.lblTotalPage.Location = new System.Drawing.Point(661, 437);
            this.lblTotalPage.Name = "lblTotalPage";
            this.lblTotalPage.Size = new System.Drawing.Size(11, 12);
            this.lblTotalPage.TabIndex = 16;
            this.lblTotalPage.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(644, 438);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "/";
            // 
            // tbxCurrPage
            // 
            this.tbxCurrPage.Enabled = false;
            this.tbxCurrPage.Location = new System.Drawing.Point(616, 433);
            this.tbxCurrPage.Name = "tbxCurrPage";
            this.tbxCurrPage.Size = new System.Drawing.Size(26, 21);
            this.tbxCurrPage.TabIndex = 15;
            this.tbxCurrPage.Text = "0";
            this.tbxCurrPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnLast
            // 
            this.btnLast.Enabled = false;
            this.btnLast.Location = new System.Drawing.Point(745, 431);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(65, 23);
            this.btnLast.TabIndex = 14;
            this.btnLast.Text = "最后一页";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.Location = new System.Drawing.Point(680, 431);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(59, 23);
            this.btnNext.TabIndex = 14;
            this.btnNext.Text = "下一页";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Enabled = false;
            this.btnFirst.Location = new System.Drawing.Point(472, 431);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(66, 23);
            this.btnFirst.TabIndex = 13;
            this.btnFirst.Text = "第一页";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnPre
            // 
            this.btnPre.Enabled = false;
            this.btnPre.Location = new System.Drawing.Point(546, 431);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(64, 23);
            this.btnPre.TabIndex = 13;
            this.btnPre.Text = "上一页";
            this.btnPre.UseVisualStyleBackColor = true;
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomerID,
            this.CustomerName,
            this.PhoneNumber,
            this.Address,
            this.ContactPerson,
            this.CertTypeID,
            this.CertNumber,
            this.DataSelect});
            this.dataGridView1.Location = new System.Drawing.Point(11, 57);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 50;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(799, 368);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // CustomerID
            // 
            this.CustomerID.DataPropertyName = "CustomerID";
            this.CustomerID.Frozen = true;
            this.CustomerID.HeaderText = "客户ID";
            this.CustomerID.Name = "CustomerID";
            this.CustomerID.Visible = false;
            // 
            // CustomerName
            // 
            this.CustomerName.DataPropertyName = "CustomerName";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CustomerName.DefaultCellStyle = dataGridViewCellStyle1;
            this.CustomerName.Frozen = true;
            this.CustomerName.HeaderText = "客户名称";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.Width = 80;
            // 
            // PhoneNumber
            // 
            this.PhoneNumber.DataPropertyName = "PhoneNumber";
            this.PhoneNumber.Frozen = true;
            this.PhoneNumber.HeaderText = "电话号码";
            this.PhoneNumber.Name = "PhoneNumber";
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            this.Address.Frozen = true;
            this.Address.HeaderText = "客户地址";
            this.Address.Name = "Address";
            this.Address.Width = 200;
            // 
            // ContactPerson
            // 
            this.ContactPerson.DataPropertyName = "ContactPerson";
            this.ContactPerson.Frozen = true;
            this.ContactPerson.HeaderText = "联系人";
            this.ContactPerson.Name = "ContactPerson";
            this.ContactPerson.Width = 80;
            // 
            // CertTypeID
            // 
            this.CertTypeID.DataPropertyName = "CertTypeID";
            this.CertTypeID.Frozen = true;
            this.CertTypeID.HeaderText = "证件类型";
            this.CertTypeID.Name = "CertTypeID";
            this.CertTypeID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CertTypeID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // CertNumber
            // 
            this.CertNumber.DataPropertyName = "CertNumber";
            this.CertNumber.Frozen = true;
            this.CertNumber.HeaderText = "证件号码";
            this.CertNumber.Name = "CertNumber";
            this.CertNumber.Width = 120;
            // 
            // DataSelect
            // 
            this.DataSelect.FalseValue = "0";
            this.DataSelect.Frozen = true;
            this.DataSelect.HeaderText = "操作";
            this.DataSelect.Name = "DataSelect";
            this.DataSelect.TrueValue = "1";
            this.DataSelect.Width = 70;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(472, 28);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbxKeyWord
            // 
            this.tbxKeyWord.Location = new System.Drawing.Point(317, 27);
            this.tbxKeyWord.Name = "tbxKeyWord";
            this.tbxKeyWord.Size = new System.Drawing.Size(127, 21);
            this.tbxKeyWord.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(247, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "关键字：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "查询条件：";
            // 
            // cbxSearchOption
            // 
            this.cbxSearchOption.FormattingEnabled = true;
            this.cbxSearchOption.Location = new System.Drawing.Point(79, 29);
            this.cbxSearchOption.Name = "cbxSearchOption";
            this.cbxSearchOption.Size = new System.Drawing.Size(127, 20);
            this.cbxSearchOption.TabIndex = 0;
            // 
            // SearchCustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 489);
            this.Controls.Add(this.groupBox1);
            this.Name = "SearchCustomerForm";
            this.TabText = "客户查询";
            this.Text = "客户查询";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxSearchOption;
        private System.Windows.Forms.TextBox tbxKeyWord;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.TextBox tbxCurrPage;
        private System.Windows.Forms.Label lblTotalPage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContactPerson;
        private System.Windows.Forms.DataGridViewComboBoxColumn CertTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CertNumber;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DataSelect;
    }
}