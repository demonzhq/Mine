namespace DianDang
{
    partial class SetCompanyInfoForm
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
            this.gbxMain = new System.Windows.Forms.GroupBox();
            this.tbxTicketNumber = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.cbxCountDayMode = new System.Windows.Forms.ComboBox();
            this.cbxAmountAccuracy = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.tbxLicenseCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxShopHours = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxCompanyAdd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxSubCompanyName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxStartTicketNumber = new System.Windows.Forms.TextBox();
            this.tbxPostalCode = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbxSetupDate = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbxCompanyPhone = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxSubCompanyNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxCompanyName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbxMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxMain
            // 
            this.gbxMain.BackColor = System.Drawing.Color.Transparent;
            this.gbxMain.Controls.Add(this.tbxTicketNumber);
            this.gbxMain.Controls.Add(this.label13);
            this.gbxMain.Controls.Add(this.btnUpdate);
            this.gbxMain.Controls.Add(this.cbxCountDayMode);
            this.gbxMain.Controls.Add(this.cbxAmountAccuracy);
            this.gbxMain.Controls.Add(this.label12);
            this.gbxMain.Controls.Add(this.label11);
            this.gbxMain.Controls.Add(this.monthCalendar1);
            this.gbxMain.Controls.Add(this.tbxLicenseCode);
            this.gbxMain.Controls.Add(this.label2);
            this.gbxMain.Controls.Add(this.tbxShopHours);
            this.gbxMain.Controls.Add(this.label8);
            this.gbxMain.Controls.Add(this.tbxCompanyAdd);
            this.gbxMain.Controls.Add(this.label5);
            this.gbxMain.Controls.Add(this.tbxSubCompanyName);
            this.gbxMain.Controls.Add(this.label6);
            this.gbxMain.Controls.Add(this.tbxStartTicketNumber);
            this.gbxMain.Controls.Add(this.tbxPostalCode);
            this.gbxMain.Controls.Add(this.label10);
            this.gbxMain.Controls.Add(this.tbxSetupDate);
            this.gbxMain.Controls.Add(this.label7);
            this.gbxMain.Controls.Add(this.label9);
            this.gbxMain.Controls.Add(this.tbxCompanyPhone);
            this.gbxMain.Controls.Add(this.label4);
            this.gbxMain.Controls.Add(this.tbxSubCompanyNumber);
            this.gbxMain.Controls.Add(this.label3);
            this.gbxMain.Controls.Add(this.tbxCompanyName);
            this.gbxMain.Controls.Add(this.label1);
            this.gbxMain.Location = new System.Drawing.Point(12, 12);
            this.gbxMain.Name = "gbxMain";
            this.gbxMain.Size = new System.Drawing.Size(802, 303);
            this.gbxMain.TabIndex = 0;
            this.gbxMain.TabStop = false;
            this.gbxMain.Text = "典当行信息";
            // 
            // tbxTicketNumber
            // 
            this.tbxTicketNumber.Location = new System.Drawing.Point(109, 267);
            this.tbxTicketNumber.Name = "tbxTicketNumber";
            this.tbxTicketNumber.Size = new System.Drawing.Size(149, 21);
            this.tbxTicketNumber.TabIndex = 6;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(21, 270);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 12);
            this.label13.TabIndex = 5;
            this.label13.Text = "默认当票号：";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(721, 265);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "确认更新";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // cbxCountDayMode
            // 
            this.cbxCountDayMode.FormattingEnabled = true;
            this.cbxCountDayMode.Items.AddRange(new object[] {
            "期内五天算法，期外五天算法",
            "期内五天算法，期外单天算法",
            "期内单天算法，期外五天算法",
            "期内单天算法，期外单天算法"});
            this.cbxCountDayMode.Location = new System.Drawing.Point(109, 230);
            this.cbxCountDayMode.Name = "cbxCountDayMode";
            this.cbxCountDayMode.Size = new System.Drawing.Size(149, 20);
            this.cbxCountDayMode.TabIndex = 4;
            // 
            // cbxAmountAccuracy
            // 
            this.cbxAmountAccuracy.FormattingEnabled = true;
            this.cbxAmountAccuracy.Items.AddRange(new object[] {
            "元",
            "角",
            "分"});
            this.cbxAmountAccuracy.Location = new System.Drawing.Point(109, 195);
            this.cbxAmountAccuracy.Name = "cbxAmountAccuracy";
            this.cbxAmountAccuracy.Size = new System.Drawing.Size(86, 20);
            this.cbxAmountAccuracy.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(21, 233);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 3;
            this.label12.Text = "计费规则：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 195);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 3;
            this.label11.Text = "计费单位：";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(270, 27);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 2;
            this.monthCalendar1.Visible = false;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // tbxLicenseCode
            // 
            this.tbxLicenseCode.Location = new System.Drawing.Point(531, 24);
            this.tbxLicenseCode.Name = "tbxLicenseCode";
            this.tbxLicenseCode.Size = new System.Drawing.Size(210, 21);
            this.tbxLicenseCode.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(460, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "许可证号：";
            // 
            // tbxShopHours
            // 
            this.tbxShopHours.Location = new System.Drawing.Point(531, 107);
            this.tbxShopHours.Name = "tbxShopHours";
            this.tbxShopHours.Size = new System.Drawing.Size(210, 21);
            this.tbxShopHours.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(460, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "营业时间：";
            // 
            // tbxCompanyAdd
            // 
            this.tbxCompanyAdd.Location = new System.Drawing.Point(531, 65);
            this.tbxCompanyAdd.Name = "tbxCompanyAdd";
            this.tbxCompanyAdd.Size = new System.Drawing.Size(210, 21);
            this.tbxCompanyAdd.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(460, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "分店地址：";
            // 
            // tbxSubCompanyName
            // 
            this.tbxSubCompanyName.Location = new System.Drawing.Point(322, 62);
            this.tbxSubCompanyName.Name = "tbxSubCompanyName";
            this.tbxSubCompanyName.Size = new System.Drawing.Size(86, 21);
            this.tbxSubCompanyName.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(242, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "分店名称：";
            // 
            // tbxStartTicketNumber
            // 
            this.tbxStartTicketNumber.Location = new System.Drawing.Point(475, 155);
            this.tbxStartTicketNumber.Name = "tbxStartTicketNumber";
            this.tbxStartTicketNumber.ReadOnly = true;
            this.tbxStartTicketNumber.Size = new System.Drawing.Size(144, 21);
            this.tbxStartTicketNumber.TabIndex = 1;
            // 
            // tbxPostalCode
            // 
            this.tbxPostalCode.Location = new System.Drawing.Point(322, 110);
            this.tbxPostalCode.Name = "tbxPostalCode";
            this.tbxPostalCode.Size = new System.Drawing.Size(86, 21);
            this.tbxPostalCode.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(380, 158);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "当票起始号码：";
            // 
            // tbxSetupDate
            // 
            this.tbxSetupDate.Location = new System.Drawing.Point(109, 155);
            this.tbxSetupDate.Name = "tbxSetupDate";
            this.tbxSetupDate.Size = new System.Drawing.Size(149, 21);
            this.tbxSetupDate.TabIndex = 1;
            this.tbxSetupDate.Click += new System.EventHandler(this.tbxSetupDate_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(240, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "邮政编码：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 158);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "公司成立时间：";
            // 
            // tbxCompanyPhone
            // 
            this.tbxCompanyPhone.Location = new System.Drawing.Point(109, 107);
            this.tbxCompanyPhone.Name = "tbxCompanyPhone";
            this.tbxCompanyPhone.Size = new System.Drawing.Size(86, 21);
            this.tbxCompanyPhone.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "电话号码：";
            // 
            // tbxSubCompanyNumber
            // 
            this.tbxSubCompanyNumber.Location = new System.Drawing.Point(109, 62);
            this.tbxSubCompanyNumber.Name = "tbxSubCompanyNumber";
            this.tbxSubCompanyNumber.Size = new System.Drawing.Size(86, 21);
            this.tbxSubCompanyNumber.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "分店编号：";
            // 
            // tbxCompanyName
            // 
            this.tbxCompanyName.Location = new System.Drawing.Point(109, 24);
            this.tbxCompanyName.Name = "tbxCompanyName";
            this.tbxCompanyName.Size = new System.Drawing.Size(299, 21);
            this.tbxCompanyName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "典当行名称：";
            // 
            // SetCompanyInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 383);
            this.Controls.Add(this.gbxMain);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "SetCompanyInfoForm";
            this.TabText = "典当行信息设定";
            this.Text = "典当行信息设定";
            this.gbxMain.ResumeLayout(false);
            this.gbxMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxMain;
        private System.Windows.Forms.TextBox tbxCompanyName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxLicenseCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxCompanyAdd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxSubCompanyName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxPostalCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxCompanyPhone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxSubCompanyNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxShopHours;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox tbxStartTicketNumber;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbxSetupDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.ComboBox cbxAmountAccuracy;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbxCountDayMode;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbxTicketNumber;
    }
}