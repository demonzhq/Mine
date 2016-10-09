namespace DianDang
{
    partial class RenewPawnForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbxKeyWord = new System.Windows.Forms.TextBox();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnRedeem = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.lblTotalPage = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxSearchOption = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxSearchRange = new System.Windows.Forms.ComboBox();
            this.tbxCurrPage = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.TickNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OperateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OperatorID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPre = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(501, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "关键字：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(263, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "查询条件：";
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.Location = new System.Drawing.Point(659, 432);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(59, 23);
            this.btnNext.TabIndex = 22;
            this.btnNext.Text = "下一页";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // btnFirst
            // 
            this.btnFirst.Enabled = false;
            this.btnFirst.Location = new System.Drawing.Point(451, 432);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(66, 23);
            this.btnFirst.TabIndex = 19;
            this.btnFirst.Text = "第一页";
            this.btnFirst.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(727, 25);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // tbxKeyWord
            // 
            this.tbxKeyWord.Location = new System.Drawing.Point(571, 25);
            this.tbxKeyWord.Name = "tbxKeyWord";
            this.tbxKeyWord.Size = new System.Drawing.Size(127, 21);
            this.tbxKeyWord.TabIndex = 13;
            // 
            // btnLast
            // 
            this.btnLast.Enabled = false;
            this.btnLast.Location = new System.Drawing.Point(724, 432);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(65, 23);
            this.btnLast.TabIndex = 21;
            this.btnLast.Text = "最后一页";
            this.btnLast.UseVisualStyleBackColor = true;
            // 
            // btnRedeem
            // 
            this.btnRedeem.Enabled = false;
            this.btnRedeem.Location = new System.Drawing.Point(102, 432);
            this.btnRedeem.Name = "btnRedeem";
            this.btnRedeem.Size = new System.Drawing.Size(75, 23);
            this.btnRedeem.TabIndex = 27;
            this.btnRedeem.Text = "续当";
            this.btnRedeem.UseVisualStyleBackColor = true;
            // 
            // btnView
            // 
            this.btnView.Enabled = false;
            this.btnView.Location = new System.Drawing.Point(8, 432);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 23);
            this.btnView.TabIndex = 26;
            this.btnView.Text = "预览";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // lblTotalPage
            // 
            this.lblTotalPage.AutoSize = true;
            this.lblTotalPage.Location = new System.Drawing.Point(640, 438);
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
            this.label4.Text = "查询范围：";
            // 
            // cbxSearchOption
            // 
            this.cbxSearchOption.FormattingEnabled = true;
            this.cbxSearchOption.Location = new System.Drawing.Point(333, 27);
            this.cbxSearchOption.Name = "cbxSearchOption";
            this.cbxSearchOption.Size = new System.Drawing.Size(127, 20);
            this.cbxSearchOption.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(623, 439);
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
            this.tbxCurrPage.Location = new System.Drawing.Point(595, 434);
            this.tbxCurrPage.Name = "tbxCurrPage";
            this.tbxCurrPage.Size = new System.Drawing.Size(26, 21);
            this.tbxCurrPage.TabIndex = 23;
            this.tbxCurrPage.Text = "0";
            this.tbxCurrPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TickNumber,
            this.StartDate,
            this.EndDate,
            this.OperateDate,
            this.Remark,
            this.OperatorID});
            this.dataGridView1.Location = new System.Drawing.Point(11, 49);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(781, 377);
            this.dataGridView1.TabIndex = 0;
            // 
            // TickNumber
            // 
            this.TickNumber.DataPropertyName = "TicketNumber";
            this.TickNumber.HeaderText = "当票号";
            this.TickNumber.Name = "TickNumber";
            this.TickNumber.ReadOnly = true;
            // 
            // StartDate
            // 
            this.StartDate.DataPropertyName = "StartDate";
            this.StartDate.HeaderText = "起始时间";
            this.StartDate.Name = "StartDate";
            this.StartDate.ReadOnly = true;
            // 
            // EndDate
            // 
            this.EndDate.DataPropertyName = "EndDate";
            this.EndDate.HeaderText = "结束时间";
            this.EndDate.Name = "EndDate";
            this.EndDate.ReadOnly = true;
            // 
            // OperateDate
            // 
            this.OperateDate.DataPropertyName = "OperateDate";
            this.OperateDate.HeaderText = "制单时间";
            this.OperateDate.Name = "OperateDate";
            this.OperateDate.ReadOnly = true;
            // 
            // Remark
            // 
            this.Remark.HeaderText = "备注";
            this.Remark.Name = "Remark";
            this.Remark.ReadOnly = true;
            // 
            // OperatorID
            // 
            this.OperatorID.HeaderText = "操作人";
            this.OperatorID.Name = "OperatorID";
            this.OperatorID.ReadOnly = true;
            // 
            // btnPre
            // 
            this.btnPre.Enabled = false;
            this.btnPre.Location = new System.Drawing.Point(525, 432);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(64, 23);
            this.btnPre.TabIndex = 20;
            this.btnPre.Text = "上一页";
            this.btnPre.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRedeem);
            this.groupBox1.Controls.Add(this.btnView);
            this.groupBox1.Controls.Add(this.lblTotalPage);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbxSearchRange);
            this.groupBox1.Controls.Add(this.tbxCurrPage);
            this.groupBox1.Controls.Add(this.btnLast);
            this.groupBox1.Controls.Add(this.btnNext);
            this.groupBox1.Controls.Add(this.btnFirst);
            this.groupBox1.Controls.Add(this.btnPre);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(802, 465);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "当票信息";
            // 
            // RenewPawnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 489);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tbxKeyWord);
            this.Controls.Add(this.cbxSearchOption);
            this.Controls.Add(this.groupBox1);
            this.Name = "RenewPawnForm";
            this.Text = "续当";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbxKeyWord;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnRedeem;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label lblTotalPage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxSearchOption;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxSearchRange;
        private System.Windows.Forms.TextBox tbxCurrPage;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TickNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn OperateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn OperatorID;
    }
}