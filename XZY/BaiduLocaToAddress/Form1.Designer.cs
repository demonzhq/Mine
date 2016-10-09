namespace BaiduLocaToAddress
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.RichTextBox();
            this.textBox2 = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxKey = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnAddresstoLocal = new System.Windows.Forms.Button();
            this.btnExcelLocaltoAddress = new System.Windows.Forms.Button();
            this.nudAddressCol = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.nudLocalCol = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.nudDataStartRow = new System.Windows.Forms.NumericUpDown();
            this.btnBrowseExcel = new System.Windows.Forms.Button();
            this.tbxExcelFile = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ofdExcelFile = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAddressCol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLocalCol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDataStartRow)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "经纬度";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(282, 394);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "28.696117,115.958458\n28.696117,115.958458\n28.696117,115.958458\n\n";
            this.textBox1.WordWrap = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(297, 29);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(312, 394);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "";
            this.textBox2.WordWrap = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(295, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "地址";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(618, 55);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "左->右";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(618, 84);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "右->左";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 432);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "key:";
            // 
            // tbxKey
            // 
            this.tbxKey.Location = new System.Drawing.Point(50, 429);
            this.tbxKey.Name = "tbxKey";
            this.tbxKey.Size = new System.Drawing.Size(429, 21);
            this.tbxKey.TabIndex = 7;
            this.tbxKey.Text = "29ce729a15887191a6213c117c0cecf0";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(705, 497);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tbxKey);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.textBox2);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(697, 471);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Direct";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnAddresstoLocal);
            this.tabPage2.Controls.Add(this.btnExcelLocaltoAddress);
            this.tabPage2.Controls.Add(this.nudAddressCol);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.nudLocalCol);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.nudDataStartRow);
            this.tabPage2.Controls.Add(this.btnBrowseExcel);
            this.tabPage2.Controls.Add(this.tbxExcelFile);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(697, 471);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Excel";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnAddresstoLocal
            // 
            this.btnAddresstoLocal.Location = new System.Drawing.Point(152, 62);
            this.btnAddresstoLocal.Name = "btnAddresstoLocal";
            this.btnAddresstoLocal.Size = new System.Drawing.Size(138, 23);
            this.btnAddresstoLocal.TabIndex = 9;
            this.btnAddresstoLocal.Text = "Address to Location";
            this.btnAddresstoLocal.UseVisualStyleBackColor = true;
            this.btnAddresstoLocal.Click += new System.EventHandler(this.btnAddresstoLocal_Click);
            // 
            // btnExcelLocaltoAddress
            // 
            this.btnExcelLocaltoAddress.Location = new System.Drawing.Point(8, 62);
            this.btnExcelLocaltoAddress.Name = "btnExcelLocaltoAddress";
            this.btnExcelLocaltoAddress.Size = new System.Drawing.Size(138, 23);
            this.btnExcelLocaltoAddress.TabIndex = 8;
            this.btnExcelLocaltoAddress.Text = "Location to Address";
            this.btnExcelLocaltoAddress.UseVisualStyleBackColor = true;
            this.btnExcelLocaltoAddress.Click += new System.EventHandler(this.btnExcelLocaltoAddress_Click);
            // 
            // nudAddressCol
            // 
            this.nudAddressCol.Location = new System.Drawing.Point(404, 35);
            this.nudAddressCol.Name = "nudAddressCol";
            this.nudAddressCol.Size = new System.Drawing.Size(31, 21);
            this.nudAddressCol.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(303, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "Address Column:";
            // 
            // nudLocalCol
            // 
            this.nudLocalCol.Location = new System.Drawing.Point(259, 35);
            this.nudLocalCol.Name = "nudLocalCol";
            this.nudLocalCol.Size = new System.Drawing.Size(38, 21);
            this.nudLocalCol.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(152, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "Location Column:";
            // 
            // nudDataStartRow
            // 
            this.nudDataStartRow.Location = new System.Drawing.Point(107, 35);
            this.nudDataStartRow.Name = "nudDataStartRow";
            this.nudDataStartRow.Size = new System.Drawing.Size(39, 21);
            this.nudDataStartRow.TabIndex = 3;
            // 
            // btnBrowseExcel
            // 
            this.btnBrowseExcel.Location = new System.Drawing.Point(614, 6);
            this.btnBrowseExcel.Name = "btnBrowseExcel";
            this.btnBrowseExcel.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseExcel.TabIndex = 2;
            this.btnBrowseExcel.Text = "Browse...";
            this.btnBrowseExcel.UseVisualStyleBackColor = true;
            this.btnBrowseExcel.Click += new System.EventHandler(this.btnBrowseExcel_Click);
            // 
            // tbxExcelFile
            // 
            this.tbxExcelFile.Location = new System.Drawing.Point(83, 8);
            this.tbxExcelFile.Name = "tbxExcelFile";
            this.tbxExcelFile.Size = new System.Drawing.Size(525, 21);
            this.tbxExcelFile.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "Data Start Row:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "Excel File:";
            // 
            // ofdExcelFile
            // 
            this.ofdExcelFile.FileName = "Excel File";
            this.ofdExcelFile.Filter = "Excel File|*.xls;*.xlsx";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 497);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Local To Address";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAddressCol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLocalCol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDataStartRow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox tbxKey;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBrowseExcel;
        private System.Windows.Forms.TextBox tbxExcelFile;
        private System.Windows.Forms.OpenFileDialog ofdExcelFile;
        private System.Windows.Forms.NumericUpDown nudAddressCol;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudLocalCol;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudDataStartRow;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAddresstoLocal;
        private System.Windows.Forms.Button btnExcelLocaltoAddress;
    }
}

