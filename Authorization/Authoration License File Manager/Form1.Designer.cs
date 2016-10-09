namespace Authoration_License_File_Manager
{
    partial class Main
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tbx_File = new System.Windows.Forms.TextBox();
            this.lbl_File = new System.Windows.Forms.Label();
            this.btn_browse = new System.Windows.Forms.Button();
            this.gbx_Info = new System.Windows.Forms.GroupBox();
            this.tbxMessage = new System.Windows.Forms.TextBox();
            this.dtp_ExpireDate = new System.Windows.Forms.DateTimePicker();
            this.dtp_CurrentDate = new System.Windows.Forms.DateTimePicker();
            this.cbx_Valid = new System.Windows.Forms.ComboBox();
            this.lbl_Valid = new System.Windows.Forms.Label();
            this.num_AuthoDay = new System.Windows.Forms.NumericUpDown();
            this.lbl_AuthoDay = new System.Windows.Forms.Label();
            this.tbx_AuthoServer = new System.Windows.Forms.TextBox();
            this.lbl_AuthoServer = new System.Windows.Forms.Label();
            this.lbl_ExpireDate = new System.Windows.Forms.Label();
            this.btn_RenewID = new System.Windows.Forms.Button();
            this.lbl_CurrentDate = new System.Windows.Forms.Label();
            this.tbx_ID = new System.Windows.Forms.TextBox();
            this.lbl_ID = new System.Windows.Forms.Label();
            this.tbx_ProjectName = new System.Windows.Forms.TextBox();
            this.lbl_ProjectName = new System.Windows.Forms.Label();
            this.btn_Update = new System.Windows.Forms.Button();
            this.lbl_key = new System.Windows.Forms.Label();
            this.tbx_key = new System.Windows.Forms.TextBox();
            this.tbx_IV = new System.Windows.Forms.TextBox();
            this.lvl_IV = new System.Windows.Forms.Label();
            this.btn_ReadInfo = new System.Windows.Forms.Button();
            this.ofd_Main = new System.Windows.Forms.OpenFileDialog();
            this.sfd_Main = new System.Windows.Forms.SaveFileDialog();
            this.gbx_Info.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_AuthoDay)).BeginInit();
            this.SuspendLayout();
            // 
            // tbx_File
            // 
            this.tbx_File.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_File.Location = new System.Drawing.Point(54, 10);
            this.tbx_File.Name = "tbx_File";
            this.tbx_File.Size = new System.Drawing.Size(321, 21);
            this.tbx_File.TabIndex = 0;
            // 
            // lbl_File
            // 
            this.lbl_File.AutoSize = true;
            this.lbl_File.Location = new System.Drawing.Point(13, 13);
            this.lbl_File.Name = "lbl_File";
            this.lbl_File.Size = new System.Drawing.Size(35, 12);
            this.lbl_File.TabIndex = 1;
            this.lbl_File.Text = "File:";
            // 
            // btn_browse
            // 
            this.btn_browse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_browse.Location = new System.Drawing.Point(381, 8);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(75, 23);
            this.btn_browse.TabIndex = 2;
            this.btn_browse.Text = "Browse...";
            this.btn_browse.UseVisualStyleBackColor = true;
            this.btn_browse.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // gbx_Info
            // 
            this.gbx_Info.Controls.Add(this.tbxMessage);
            this.gbx_Info.Controls.Add(this.dtp_ExpireDate);
            this.gbx_Info.Controls.Add(this.dtp_CurrentDate);
            this.gbx_Info.Controls.Add(this.cbx_Valid);
            this.gbx_Info.Controls.Add(this.lbl_Valid);
            this.gbx_Info.Controls.Add(this.num_AuthoDay);
            this.gbx_Info.Controls.Add(this.lbl_AuthoDay);
            this.gbx_Info.Controls.Add(this.tbx_AuthoServer);
            this.gbx_Info.Controls.Add(this.lbl_AuthoServer);
            this.gbx_Info.Controls.Add(this.lbl_ExpireDate);
            this.gbx_Info.Controls.Add(this.btn_RenewID);
            this.gbx_Info.Controls.Add(this.lbl_CurrentDate);
            this.gbx_Info.Controls.Add(this.tbx_ID);
            this.gbx_Info.Controls.Add(this.lbl_ID);
            this.gbx_Info.Controls.Add(this.tbx_ProjectName);
            this.gbx_Info.Controls.Add(this.lbl_ProjectName);
            this.gbx_Info.Location = new System.Drawing.Point(12, 64);
            this.gbx_Info.Name = "gbx_Info";
            this.gbx_Info.Size = new System.Drawing.Size(363, 389);
            this.gbx_Info.TabIndex = 3;
            this.gbx_Info.TabStop = false;
            this.gbx_Info.Text = "Infomation";
            // 
            // tbxMessage
            // 
            this.tbxMessage.Location = new System.Drawing.Point(1, 209);
            this.tbxMessage.Multiline = true;
            this.tbxMessage.Name = "tbxMessage";
            this.tbxMessage.Size = new System.Drawing.Size(351, 169);
            this.tbxMessage.TabIndex = 27;
            // 
            // dtp_ExpireDate
            // 
            this.dtp_ExpireDate.Location = new System.Drawing.Point(104, 101);
            this.dtp_ExpireDate.Name = "dtp_ExpireDate";
            this.dtp_ExpireDate.Size = new System.Drawing.Size(145, 21);
            this.dtp_ExpireDate.TabIndex = 26;
            // 
            // dtp_CurrentDate
            // 
            this.dtp_CurrentDate.Location = new System.Drawing.Point(104, 74);
            this.dtp_CurrentDate.Name = "dtp_CurrentDate";
            this.dtp_CurrentDate.Size = new System.Drawing.Size(145, 21);
            this.dtp_CurrentDate.TabIndex = 25;
            // 
            // cbx_Valid
            // 
            this.cbx_Valid.FormattingEnabled = true;
            this.cbx_Valid.Items.AddRange(new object[] {
            "InValid",
            "Valid"});
            this.cbx_Valid.Location = new System.Drawing.Point(104, 183);
            this.cbx_Valid.Name = "cbx_Valid";
            this.cbx_Valid.Size = new System.Drawing.Size(121, 20);
            this.cbx_Valid.TabIndex = 24;
            // 
            // lbl_Valid
            // 
            this.lbl_Valid.AutoSize = true;
            this.lbl_Valid.Location = new System.Drawing.Point(6, 186);
            this.lbl_Valid.Name = "lbl_Valid";
            this.lbl_Valid.Size = new System.Drawing.Size(59, 12);
            this.lbl_Valid.TabIndex = 23;
            this.lbl_Valid.Text = "Is Valid:";
            // 
            // num_AuthoDay
            // 
            this.num_AuthoDay.Location = new System.Drawing.Point(104, 156);
            this.num_AuthoDay.Name = "num_AuthoDay";
            this.num_AuthoDay.Size = new System.Drawing.Size(47, 21);
            this.num_AuthoDay.TabIndex = 22;
            // 
            // lbl_AuthoDay
            // 
            this.lbl_AuthoDay.AutoSize = true;
            this.lbl_AuthoDay.Location = new System.Drawing.Point(6, 158);
            this.lbl_AuthoDay.Name = "lbl_AuthoDay";
            this.lbl_AuthoDay.Size = new System.Drawing.Size(71, 12);
            this.lbl_AuthoDay.TabIndex = 21;
            this.lbl_AuthoDay.Text = "Autho Days:";
            // 
            // tbx_AuthoServer
            // 
            this.tbx_AuthoServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_AuthoServer.Location = new System.Drawing.Point(104, 129);
            this.tbx_AuthoServer.Name = "tbx_AuthoServer";
            this.tbx_AuthoServer.Size = new System.Drawing.Size(253, 21);
            this.tbx_AuthoServer.TabIndex = 20;
            // 
            // lbl_AuthoServer
            // 
            this.lbl_AuthoServer.AutoSize = true;
            this.lbl_AuthoServer.Location = new System.Drawing.Point(6, 132);
            this.lbl_AuthoServer.Name = "lbl_AuthoServer";
            this.lbl_AuthoServer.Size = new System.Drawing.Size(83, 12);
            this.lbl_AuthoServer.TabIndex = 19;
            this.lbl_AuthoServer.Text = "Autho Server:";
            // 
            // lbl_ExpireDate
            // 
            this.lbl_ExpireDate.AutoSize = true;
            this.lbl_ExpireDate.Location = new System.Drawing.Point(6, 104);
            this.lbl_ExpireDate.Name = "lbl_ExpireDate";
            this.lbl_ExpireDate.Size = new System.Drawing.Size(77, 12);
            this.lbl_ExpireDate.TabIndex = 16;
            this.lbl_ExpireDate.Text = "Expire Date:";
            // 
            // btn_RenewID
            // 
            this.btn_RenewID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_RenewID.Location = new System.Drawing.Point(282, 45);
            this.btn_RenewID.Name = "btn_RenewID";
            this.btn_RenewID.Size = new System.Drawing.Size(75, 23);
            this.btn_RenewID.TabIndex = 14;
            this.btn_RenewID.Text = "Renew";
            this.btn_RenewID.UseVisualStyleBackColor = true;
            this.btn_RenewID.Click += new System.EventHandler(this.btn_RenewID_Click);
            // 
            // lbl_CurrentDate
            // 
            this.lbl_CurrentDate.AutoSize = true;
            this.lbl_CurrentDate.Location = new System.Drawing.Point(6, 77);
            this.lbl_CurrentDate.Name = "lbl_CurrentDate";
            this.lbl_CurrentDate.Size = new System.Drawing.Size(83, 12);
            this.lbl_CurrentDate.TabIndex = 12;
            this.lbl_CurrentDate.Text = "Current Date:";
            // 
            // tbx_ID
            // 
            this.tbx_ID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_ID.Location = new System.Drawing.Point(104, 47);
            this.tbx_ID.Name = "tbx_ID";
            this.tbx_ID.Size = new System.Drawing.Size(172, 21);
            this.tbx_ID.TabIndex = 11;
            // 
            // lbl_ID
            // 
            this.lbl_ID.AutoSize = true;
            this.lbl_ID.Location = new System.Drawing.Point(6, 50);
            this.lbl_ID.Name = "lbl_ID";
            this.lbl_ID.Size = new System.Drawing.Size(77, 12);
            this.lbl_ID.TabIndex = 10;
            this.lbl_ID.Text = "Computer ID:";
            // 
            // tbx_ProjectName
            // 
            this.tbx_ProjectName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_ProjectName.Location = new System.Drawing.Point(104, 20);
            this.tbx_ProjectName.Name = "tbx_ProjectName";
            this.tbx_ProjectName.Size = new System.Drawing.Size(253, 21);
            this.tbx_ProjectName.TabIndex = 9;
            // 
            // lbl_ProjectName
            // 
            this.lbl_ProjectName.AutoSize = true;
            this.lbl_ProjectName.Location = new System.Drawing.Point(6, 23);
            this.lbl_ProjectName.Name = "lbl_ProjectName";
            this.lbl_ProjectName.Size = new System.Drawing.Size(83, 12);
            this.lbl_ProjectName.TabIndex = 8;
            this.lbl_ProjectName.Text = "Project Name:";
            // 
            // btn_Update
            // 
            this.btn_Update.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Update.Location = new System.Drawing.Point(381, 419);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(75, 23);
            this.btn_Update.TabIndex = 4;
            this.btn_Update.Text = "Update";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // lbl_key
            // 
            this.lbl_key.AutoSize = true;
            this.lbl_key.Location = new System.Drawing.Point(13, 40);
            this.lbl_key.Name = "lbl_key";
            this.lbl_key.Size = new System.Drawing.Size(29, 12);
            this.lbl_key.TabIndex = 5;
            this.lbl_key.Text = "Key:";
            // 
            // tbx_key
            // 
            this.tbx_key.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_key.Location = new System.Drawing.Point(54, 37);
            this.tbx_key.Name = "tbx_key";
            this.tbx_key.Size = new System.Drawing.Size(124, 21);
            this.tbx_key.TabIndex = 6;
            // 
            // tbx_IV
            // 
            this.tbx_IV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_IV.Location = new System.Drawing.Point(213, 37);
            this.tbx_IV.Name = "tbx_IV";
            this.tbx_IV.Size = new System.Drawing.Size(162, 21);
            this.tbx_IV.TabIndex = 8;
            this.tbx_IV.Text = "ZHQLICIV";
            // 
            // lvl_IV
            // 
            this.lvl_IV.AutoSize = true;
            this.lvl_IV.Location = new System.Drawing.Point(184, 40);
            this.lvl_IV.Name = "lvl_IV";
            this.lvl_IV.Size = new System.Drawing.Size(23, 12);
            this.lvl_IV.TabIndex = 7;
            this.lvl_IV.Text = "IV:";
            // 
            // btn_ReadInfo
            // 
            this.btn_ReadInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ReadInfo.Location = new System.Drawing.Point(381, 35);
            this.btn_ReadInfo.Name = "btn_ReadInfo";
            this.btn_ReadInfo.Size = new System.Drawing.Size(75, 23);
            this.btn_ReadInfo.TabIndex = 9;
            this.btn_ReadInfo.Text = "Read";
            this.btn_ReadInfo.UseVisualStyleBackColor = true;
            this.btn_ReadInfo.Click += new System.EventHandler(this.btn_ReadInfo_Click);
            // 
            // ofd_Main
            // 
            this.ofd_Main.FileName = "openFileDialog1";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 453);
            this.Controls.Add(this.btn_ReadInfo);
            this.Controls.Add(this.tbx_IV);
            this.Controls.Add(this.lvl_IV);
            this.Controls.Add(this.tbx_key);
            this.Controls.Add(this.lbl_key);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.gbx_Info);
            this.Controls.Add(this.btn_browse);
            this.Controls.Add(this.lbl_File);
            this.Controls.Add(this.tbx_File);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Main";
            this.Text = "License Manager";
            this.gbx_Info.ResumeLayout(false);
            this.gbx_Info.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_AuthoDay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbx_File;
        private System.Windows.Forms.Label lbl_File;
        private System.Windows.Forms.Button btn_browse;
        private System.Windows.Forms.GroupBox gbx_Info;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Label lbl_key;
        private System.Windows.Forms.TextBox tbx_key;
        private System.Windows.Forms.TextBox tbx_IV;
        private System.Windows.Forms.Label lvl_IV;
        private System.Windows.Forms.Button btn_ReadInfo;
        private System.Windows.Forms.Label lbl_ProjectName;
        private System.Windows.Forms.TextBox tbx_ProjectName;
        private System.Windows.Forms.TextBox tbx_ID;
        private System.Windows.Forms.Label lbl_ID;
        private System.Windows.Forms.Button btn_RenewID;
        private System.Windows.Forms.Label lbl_CurrentDate;
        private System.Windows.Forms.Label lbl_ExpireDate;
        private System.Windows.Forms.TextBox tbx_AuthoServer;
        private System.Windows.Forms.Label lbl_AuthoServer;
        private System.Windows.Forms.ComboBox cbx_Valid;
        private System.Windows.Forms.Label lbl_Valid;
        private System.Windows.Forms.NumericUpDown num_AuthoDay;
        private System.Windows.Forms.Label lbl_AuthoDay;
        private System.Windows.Forms.OpenFileDialog ofd_Main;
        private System.Windows.Forms.DateTimePicker dtp_ExpireDate;
        private System.Windows.Forms.DateTimePicker dtp_CurrentDate;
        private System.Windows.Forms.SaveFileDialog sfd_Main;
        private System.Windows.Forms.TextBox tbxMessage;
    }
}

