namespace DianDang
{
    partial class DataBackupRestoreForm
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
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnBackupFileBrowser = new System.Windows.Forms.Button();
            this.tbxBackupFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnRestoreFileBrowser = new System.Windows.Forms.Button();
            this.tbxRestoreFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.selectBackupFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBackup);
            this.groupBox1.Controls.Add(this.btnBackupFileBrowser);
            this.groupBox1.Controls.Add(this.tbxBackupFile);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(344, 94);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据备份";
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(126, 53);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(75, 23);
            this.btnBackup.TabIndex = 3;
            this.btnBackup.Text = "开始备份";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnBackupFileBrowser
            // 
            this.btnBackupFileBrowser.Location = new System.Drawing.Point(252, 24);
            this.btnBackupFileBrowser.Name = "btnBackupFileBrowser";
            this.btnBackupFileBrowser.Size = new System.Drawing.Size(75, 23);
            this.btnBackupFileBrowser.TabIndex = 2;
            this.btnBackupFileBrowser.Text = "浏览...";
            this.btnBackupFileBrowser.UseVisualStyleBackColor = true;
            this.btnBackupFileBrowser.Click += new System.EventHandler(this.btnBackupFileBrowser_Click);
            // 
            // tbxBackupFile
            // 
            this.tbxBackupFile.Location = new System.Drawing.Point(87, 26);
            this.tbxBackupFile.Name = "tbxBackupFile";
            this.tbxBackupFile.Size = new System.Drawing.Size(159, 21);
            this.tbxBackupFile.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "请选择文件";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRestore);
            this.groupBox2.Controls.Add(this.btnRestoreFileBrowser);
            this.groupBox2.Controls.Add(this.tbxRestoreFile);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 112);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(344, 93);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "数据恢复";
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(126, 55);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(75, 23);
            this.btnRestore.TabIndex = 3;
            this.btnRestore.Text = "开始恢复";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnRestoreFileBrowser
            // 
            this.btnRestoreFileBrowser.Location = new System.Drawing.Point(252, 26);
            this.btnRestoreFileBrowser.Name = "btnRestoreFileBrowser";
            this.btnRestoreFileBrowser.Size = new System.Drawing.Size(75, 23);
            this.btnRestoreFileBrowser.TabIndex = 5;
            this.btnRestoreFileBrowser.Text = "浏览...";
            this.btnRestoreFileBrowser.UseVisualStyleBackColor = true;
            this.btnRestoreFileBrowser.Click += new System.EventHandler(this.btnRestoreFileBrowser_Click);
            // 
            // tbxRestoreFile
            // 
            this.tbxRestoreFile.Location = new System.Drawing.Point(87, 28);
            this.tbxRestoreFile.Name = "tbxRestoreFile";
            this.tbxRestoreFile.Size = new System.Drawing.Size(159, 21);
            this.tbxRestoreFile.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "请选择文件";
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 220);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(368, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // selectBackupFileDialog
            // 
            this.selectBackupFileDialog.Filter = "备份文件 *.bak|*.bak|所有文件|*.*";
            this.selectBackupFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.selectBackupFileDialog_FileOk);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "备份文件 *.bak|*.bak|所有文件|*.*";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(openFileDialog1_FileOk);
            // 
            // DataBackupRestoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 243);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "DataBackupRestoreForm";
            this.Text = "数据备份和恢复";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }



        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbxBackupFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnBackupFileBrowser;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnRestoreFileBrowser;
        private System.Windows.Forms.TextBox tbxRestoreFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.SaveFileDialog selectBackupFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}