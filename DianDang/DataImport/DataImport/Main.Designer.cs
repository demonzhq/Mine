namespace DataImport
{
    partial class Main
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
            this.btnBrandNewDatabase = new System.Windows.Forms.Button();
            this.TestResultLabel = new System.Windows.Forms.Label();
            this.TestConnect = new System.Windows.Forms.Button();
            this.InputDatabase = new System.Windows.Forms.TextBox();
            this.InputPass = new System.Windows.Forms.TextBox();
            this.InputUser = new System.Windows.Forms.TextBox();
            this.InputAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MainProgressBar = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCreatNew = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.StartImport = new System.Windows.Forms.Button();
            this.DBFPathSelect = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.InputFileSelect = new System.Windows.Forms.Button();
            this.InputDBFPath = new System.Windows.Forms.TextBox();
            this.InputStructFile = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnBrandNewDatabase);
            this.groupBox1.Controls.Add(this.TestResultLabel);
            this.groupBox1.Controls.Add(this.TestConnect);
            this.groupBox1.Controls.Add(this.InputDatabase);
            this.groupBox1.Controls.Add(this.InputPass);
            this.groupBox1.Controls.Add(this.InputUser);
            this.groupBox1.Controls.Add(this.InputAddress);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(252, 159);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "服务器配置";
            // 
            // btnBrandNewDatabase
            // 
            this.btnBrandNewDatabase.Location = new System.Drawing.Point(87, 126);
            this.btnBrandNewDatabase.Name = "btnBrandNewDatabase";
            this.btnBrandNewDatabase.Size = new System.Drawing.Size(75, 23);
            this.btnBrandNewDatabase.TabIndex = 4;
            this.btnBrandNewDatabase.Text = "空白数据库";
            this.btnBrandNewDatabase.UseVisualStyleBackColor = true;
            this.btnBrandNewDatabase.Click += new System.EventHandler(this.btnBrandNewDatabase_Click);
            // 
            // TestResultLabel
            // 
            this.TestResultLabel.AutoSize = true;
            this.TestResultLabel.Location = new System.Drawing.Point(87, 131);
            this.TestResultLabel.Name = "TestResultLabel";
            this.TestResultLabel.Size = new System.Drawing.Size(0, 12);
            this.TestResultLabel.TabIndex = 3;
            // 
            // TestConnect
            // 
            this.TestConnect.Location = new System.Drawing.Point(6, 126);
            this.TestConnect.Name = "TestConnect";
            this.TestConnect.Size = new System.Drawing.Size(75, 23);
            this.TestConnect.TabIndex = 2;
            this.TestConnect.Text = "测试连接";
            this.TestConnect.UseVisualStyleBackColor = true;
            this.TestConnect.Click += new System.EventHandler(this.TestConnect_Click);
            // 
            // InputDatabase
            // 
            this.InputDatabase.Location = new System.Drawing.Point(59, 99);
            this.InputDatabase.Name = "InputDatabase";
            this.InputDatabase.Size = new System.Drawing.Size(176, 21);
            this.InputDatabase.TabIndex = 1;
            this.InputDatabase.Text = "DD";
            this.InputDatabase.WordWrap = false;
            // 
            // InputPass
            // 
            this.InputPass.Location = new System.Drawing.Point(59, 72);
            this.InputPass.Name = "InputPass";
            this.InputPass.Size = new System.Drawing.Size(176, 21);
            this.InputPass.TabIndex = 1;
            this.InputPass.Text = "0000pppP";
            this.InputPass.UseSystemPasswordChar = true;
            this.InputPass.WordWrap = false;
            // 
            // InputUser
            // 
            this.InputUser.Location = new System.Drawing.Point(59, 45);
            this.InputUser.Name = "InputUser";
            this.InputUser.Size = new System.Drawing.Size(176, 21);
            this.InputUser.TabIndex = 1;
            this.InputUser.Text = "sa";
            // 
            // InputAddress
            // 
            this.InputAddress.Location = new System.Drawing.Point(59, 18);
            this.InputAddress.Name = "InputAddress";
            this.InputAddress.Size = new System.Drawing.Size(176, 21);
            this.InputAddress.TabIndex = 1;
            this.InputAddress.Text = "127.0.0.1\\SqlExpress";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "数据库:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "密码:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "用户名:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "地址:";
            // 
            // MainProgressBar
            // 
            this.MainProgressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MainProgressBar.Location = new System.Drawing.Point(0, 351);
            this.MainProgressBar.Name = "MainProgressBar";
            this.MainProgressBar.Size = new System.Drawing.Size(277, 23);
            this.MainProgressBar.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "表格式文件：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCreatNew);
            this.groupBox2.Controls.Add(this.numericUpDown1);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.StartImport);
            this.groupBox2.Controls.Add(this.DBFPathSelect);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.InputFileSelect);
            this.groupBox2.Controls.Add(this.InputDBFPath);
            this.groupBox2.Controls.Add(this.InputStructFile);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(19, 179);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(246, 166);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "导入配置";
            // 
            // btnCreatNew
            // 
            this.btnCreatNew.Location = new System.Drawing.Point(167, 137);
            this.btnCreatNew.Name = "btnCreatNew";
            this.btnCreatNew.Size = new System.Drawing.Size(73, 23);
            this.btnCreatNew.TabIndex = 10;
            this.btnCreatNew.Text = "新建数据";
            this.btnCreatNew.UseVisualStyleBackColor = true;
            this.btnCreatNew.Visible = false;
            this.btnCreatNew.Click += new System.EventHandler(this.btnCreatNew_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(104, 99);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(34, 21);
            this.numericUpDown1.TabIndex = 9;
            this.numericUpDown1.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 8;
            this.label7.Text = "保留小数位数：";
            // 
            // StartImport
            // 
            this.StartImport.Location = new System.Drawing.Point(8, 137);
            this.StartImport.Name = "StartImport";
            this.StartImport.Size = new System.Drawing.Size(73, 23);
            this.StartImport.TabIndex = 7;
            this.StartImport.Text = "开始导入";
            this.StartImport.UseVisualStyleBackColor = true;
            this.StartImport.Click += new System.EventHandler(this.StartImport_Click);
            // 
            // DBFPathSelect
            // 
            this.DBFPathSelect.Location = new System.Drawing.Point(183, 69);
            this.DBFPathSelect.Name = "DBFPathSelect";
            this.DBFPathSelect.Size = new System.Drawing.Size(57, 23);
            this.DBFPathSelect.TabIndex = 6;
            this.DBFPathSelect.Text = "选择";
            this.DBFPathSelect.UseVisualStyleBackColor = true;
            this.DBFPathSelect.Click += new System.EventHandler(this.DBFPathSelect_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "原始数据库";
            // 
            // InputFileSelect
            // 
            this.InputFileSelect.Location = new System.Drawing.Point(183, 30);
            this.InputFileSelect.Name = "InputFileSelect";
            this.InputFileSelect.Size = new System.Drawing.Size(57, 23);
            this.InputFileSelect.TabIndex = 4;
            this.InputFileSelect.Text = "选择";
            this.InputFileSelect.UseVisualStyleBackColor = true;
            this.InputFileSelect.Click += new System.EventHandler(this.InputFileSelect_Click);
            // 
            // InputDBFPath
            // 
            this.InputDBFPath.Location = new System.Drawing.Point(6, 71);
            this.InputDBFPath.Name = "InputDBFPath";
            this.InputDBFPath.Size = new System.Drawing.Size(165, 21);
            this.InputDBFPath.TabIndex = 3;
            this.InputDBFPath.Text = "D:\\Work\\Other\\DianDang\\系统\\DDBackup\\";
            this.InputDBFPath.WordWrap = false;
            // 
            // InputStructFile
            // 
            this.InputStructFile.Location = new System.Drawing.Point(8, 32);
            this.InputStructFile.Name = "InputStructFile";
            this.InputStructFile.Size = new System.Drawing.Size(165, 21);
            this.InputStructFile.TabIndex = 3;
            this.InputStructFile.Text = "20100310.txt";
            this.InputStructFile.WordWrap = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(168, 126);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 374);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.MainProgressBar);
            this.Controls.Add(this.groupBox1);
            this.Name = "Main";
            this.Text = "数据库导入V20100313";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }



        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox InputPass;
        private System.Windows.Forms.TextBox InputUser;
        private System.Windows.Forms.TextBox InputAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label TestResultLabel;
        private System.Windows.Forms.Button TestConnect;
        private System.Windows.Forms.ProgressBar MainProgressBar;
        private System.Windows.Forms.TextBox InputDatabase;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox InputStructFile;
        private System.Windows.Forms.Button InputFileSelect;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox InputDBFPath;
        private System.Windows.Forms.Button DBFPathSelect;
        private System.Windows.Forms.Button StartImport;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCreatNew;
        private System.Windows.Forms.Button btnBrandNewDatabase;
        private System.Windows.Forms.Button btnDelete;

    }
}