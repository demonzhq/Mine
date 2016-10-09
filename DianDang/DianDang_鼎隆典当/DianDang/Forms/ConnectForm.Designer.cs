namespace DianDang
{
    partial class ConnectForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbxSqlPwd = new System.Windows.Forms.TextBox();
            this.tbxSqlUserName = new System.Windows.Forms.TextBox();
            this.tbxDBName = new System.Windows.Forms.TextBox();
            this.tbxServerName = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器地址：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "数据库名称：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "数据库用户：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "数据库密码：";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(37, 161);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "测试连接";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(154, 161);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.tbxServerName);
            this.groupBox1.Controls.Add(this.tbxSqlPwd);
            this.groupBox1.Controls.Add(this.tbxSqlUserName);
            this.groupBox1.Controls.Add(this.tbxDBName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(269, 143);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据库连接";
            // 
            // tbxSqlPwd
            // 
            this.tbxSqlPwd.Location = new System.Drawing.Point(117, 110);
            this.tbxSqlPwd.Name = "tbxSqlPwd";
            this.tbxSqlPwd.PasswordChar = '*';
            this.tbxSqlPwd.Size = new System.Drawing.Size(121, 21);
            this.tbxSqlPwd.TabIndex = 4;
            // 
            // tbxSqlUserName
            // 
            this.tbxSqlUserName.Location = new System.Drawing.Point(117, 83);
            this.tbxSqlUserName.Name = "tbxSqlUserName";
            this.tbxSqlUserName.PasswordChar = '*';
            this.tbxSqlUserName.Size = new System.Drawing.Size(121, 21);
            this.tbxSqlUserName.TabIndex = 3;
            // 
            // tbxDBName
            // 
            this.tbxDBName.Location = new System.Drawing.Point(117, 56);
            this.tbxDBName.Name = "tbxDBName";
            this.tbxDBName.Size = new System.Drawing.Size(121, 21);
            this.tbxDBName.TabIndex = 2;
            // 
            // tbxServerName
            // 
            this.tbxServerName.Location = new System.Drawing.Point(117, 29);
            this.tbxServerName.Name = "tbxServerName";
            this.tbxServerName.Size = new System.Drawing.Size(121, 21);
            this.tbxServerName.TabIndex = 5;
            // 
            // ConnectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(293, 206);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConnect);
            this.Name = "ConnectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "连接服务器...";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbxSqlPwd;
        private System.Windows.Forms.TextBox tbxSqlUserName;
        private System.Windows.Forms.TextBox tbxDBName;
        private System.Windows.Forms.TextBox tbxServerName;
    }
}