namespace DianDang
{
    partial class EditPersonalAccountForm
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
            this.btnEditPwd = new System.Windows.Forms.Button();
            this.tbxRepeatedPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxNewPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxOldPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbxPhoneNumber = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxCertNumber = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxRoleName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbxEmail = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxUserName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.btnEditPwd);
            this.groupBox1.Controls.Add(this.tbxRepeatedPassword);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbxNewPassword);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbxOldPassword);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(801, 176);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "安全信息";
            // 
            // btnEditPwd
            // 
            this.btnEditPwd.Location = new System.Drawing.Point(717, 144);
            this.btnEditPwd.Name = "btnEditPwd";
            this.btnEditPwd.Size = new System.Drawing.Size(75, 23);
            this.btnEditPwd.TabIndex = 2;
            this.btnEditPwd.Text = "修改密码";
            this.btnEditPwd.UseVisualStyleBackColor = true;
            this.btnEditPwd.Click += new System.EventHandler(this.btnEditPwd_Click);
            // 
            // tbxRepeatedPassword
            // 
            this.tbxRepeatedPassword.Location = new System.Drawing.Point(145, 100);
            this.tbxRepeatedPassword.Name = "tbxRepeatedPassword";
            this.tbxRepeatedPassword.Size = new System.Drawing.Size(155, 21);
            this.tbxRepeatedPassword.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "重复新密码：";
            // 
            // tbxNewPassword
            // 
            this.tbxNewPassword.Location = new System.Drawing.Point(145, 63);
            this.tbxNewPassword.Name = "tbxNewPassword";
            this.tbxNewPassword.Size = new System.Drawing.Size(155, 21);
            this.tbxNewPassword.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "新密码：";
            // 
            // tbxOldPassword
            // 
            this.tbxOldPassword.Location = new System.Drawing.Point(145, 27);
            this.tbxOldPassword.Name = "tbxOldPassword";
            this.tbxOldPassword.Size = new System.Drawing.Size(155, 21);
            this.tbxOldPassword.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(336, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(191, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "(请输入6位以上的字母及数字组合)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "原密码：";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.tbxPhoneNumber);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.tbxCertNumber);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.tbxRoleName);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.tbxEmail);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.tbxUserName);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(13, 195);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(801, 152);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "个人信息";
            // 
            // tbxPhoneNumber
            // 
            this.tbxPhoneNumber.Location = new System.Drawing.Point(540, 34);
            this.tbxPhoneNumber.Name = "tbxPhoneNumber";
            this.tbxPhoneNumber.Size = new System.Drawing.Size(155, 21);
            this.tbxPhoneNumber.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(429, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "电话：";
            // 
            // tbxCertNumber
            // 
            this.tbxCertNumber.Location = new System.Drawing.Point(540, 72);
            this.tbxCertNumber.Name = "tbxCertNumber";
            this.tbxCertNumber.Size = new System.Drawing.Size(155, 21);
            this.tbxCertNumber.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(429, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "身份证号：";
            // 
            // tbxRoleName
            // 
            this.tbxRoleName.Enabled = false;
            this.tbxRoleName.Location = new System.Drawing.Point(145, 113);
            this.tbxRoleName.Name = "tbxRoleName";
            this.tbxRoleName.Size = new System.Drawing.Size(155, 21);
            this.tbxRoleName.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(34, 116);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "权限组：";
            // 
            // tbxEmail
            // 
            this.tbxEmail.Location = new System.Drawing.Point(145, 72);
            this.tbxEmail.Name = "tbxEmail";
            this.tbxEmail.Size = new System.Drawing.Size(155, 21);
            this.tbxEmail.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "邮箱地址：";
            // 
            // tbxUserName
            // 
            this.tbxUserName.Location = new System.Drawing.Point(145, 31);
            this.tbxUserName.Name = "tbxUserName";
            this.tbxUserName.Size = new System.Drawing.Size(155, 21);
            this.tbxUserName.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "姓名：";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(730, 359);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "修改信息";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // EditPersonalAccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 387);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "EditPersonalAccountForm";
            this.TabText = "修改个人信息";
            this.Text = "修改个人信息";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbxRepeatedPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxNewPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxOldPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxPhoneNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxCertNumber;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbxRoleName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbxEmail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxUserName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnEditPwd;
    }
}