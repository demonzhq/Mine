namespace DianDang
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.MenuAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Edit_Personal_Account = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Manage_Accounts = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Manage_Roles = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Exit_System = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuBusiness = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Pawn_Create = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Pawn_Redeem = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Pawn_Renew = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Pawn_Close = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Pawn_Freeze = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Pawn_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Pawn_Clear = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Query = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Query_By_Finance = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Query_By_Class = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Query_By_Class_Standard = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Query_By_Class_Statistical = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Query_By_Taking = new System.Windows.Forms.ToolStripMenuItem();
            this.Query_By_Taking_Standard = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Query_By_Statistical = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_CurrentDay_Operations = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_PawnTicket_Query = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuCustomerInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Customer_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Customer_Query = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_News = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_News_View = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_News_Manage = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSystemSet = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_CompanyInfo_Set = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_PawnageClass_Set = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDataManage = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Data_Backup = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Database_Set = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Substore_Manage = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_AboutUs = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Update = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Website = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.dockPanel1 = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuAccount,
            this.MenuBusiness,
            this.MenuQuery,
            this.MenuCustomerInfo,
            this.Menu_News,
            this.MenuSystemSet,
            this.MenuDataManage,
            this.MenuHelp});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(1012, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "menuStrip1";
            // 
            // MenuAccount
            // 
            this.MenuAccount.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Edit_Personal_Account,
            this.Menu_Manage_Accounts,
            this.Menu_Manage_Roles,
            this.Menu_Exit_System});
            this.MenuAccount.Name = "MenuAccount";
            this.MenuAccount.Size = new System.Drawing.Size(65, 20);
            this.MenuAccount.Text = "帐户管理";
            // 
            // Menu_Edit_Personal_Account
            // 
            this.Menu_Edit_Personal_Account.Name = "Menu_Edit_Personal_Account";
            this.Menu_Edit_Personal_Account.Size = new System.Drawing.Size(142, 22);
            this.Menu_Edit_Personal_Account.Text = "修改个人信息";
            this.Menu_Edit_Personal_Account.Click += new System.EventHandler(this.Menu_Edit_Personal_Account_Click);
            // 
            // Menu_Manage_Accounts
            // 
            this.Menu_Manage_Accounts.Name = "Menu_Manage_Accounts";
            this.Menu_Manage_Accounts.Size = new System.Drawing.Size(142, 22);
            this.Menu_Manage_Accounts.Text = "帐户管理";
            this.Menu_Manage_Accounts.Click += new System.EventHandler(this.Menu_Manage_Accounts_Click);
            // 
            // Menu_Manage_Roles
            // 
            this.Menu_Manage_Roles.Name = "Menu_Manage_Roles";
            this.Menu_Manage_Roles.Size = new System.Drawing.Size(142, 22);
            this.Menu_Manage_Roles.Text = "权限管理";
            this.Menu_Manage_Roles.Click += new System.EventHandler(this.Menu_Manage_Roles_Click);
            // 
            // Menu_Exit_System
            // 
            this.Menu_Exit_System.Name = "Menu_Exit_System";
            this.Menu_Exit_System.Size = new System.Drawing.Size(142, 22);
            this.Menu_Exit_System.Text = "退出系统";
            this.Menu_Exit_System.Click += new System.EventHandler(this.Menu_Exit_System_Click);
            // 
            // MenuBusiness
            // 
            this.MenuBusiness.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Pawn_Create,
            this.Menu_Pawn_Redeem,
            this.Menu_Pawn_Renew,
            this.Menu_Pawn_Close,
            this.Menu_Pawn_Freeze,
            this.Menu_Pawn_Delete,
            this.Menu_Pawn_Clear});
            this.MenuBusiness.Name = "MenuBusiness";
            this.MenuBusiness.Size = new System.Drawing.Size(65, 20);
            this.MenuBusiness.Text = "业务处理";
            // 
            // Menu_Pawn_Create
            // 
            this.Menu_Pawn_Create.Name = "Menu_Pawn_Create";
            this.Menu_Pawn_Create.Size = new System.Drawing.Size(152, 22);
            this.Menu_Pawn_Create.Text = "建当处理";
            this.Menu_Pawn_Create.Click += new System.EventHandler(this.Menu_Pawn_Create_Click);
            // 
            // Menu_Pawn_Redeem
            // 
            this.Menu_Pawn_Redeem.Name = "Menu_Pawn_Redeem";
            this.Menu_Pawn_Redeem.Size = new System.Drawing.Size(152, 22);
            this.Menu_Pawn_Redeem.Text = "赎当处理";
            this.Menu_Pawn_Redeem.Click += new System.EventHandler(this.Menu_Pawn_Redeem_Click);
            // 
            // Menu_Pawn_Renew
            // 
            this.Menu_Pawn_Renew.Name = "Menu_Pawn_Renew";
            this.Menu_Pawn_Renew.Size = new System.Drawing.Size(152, 22);
            this.Menu_Pawn_Renew.Text = "续当处理";
            this.Menu_Pawn_Renew.Click += new System.EventHandler(this.Menu_Pawn_Renew_Click);
            // 
            // Menu_Pawn_Close
            // 
            this.Menu_Pawn_Close.Name = "Menu_Pawn_Close";
            this.Menu_Pawn_Close.Size = new System.Drawing.Size(152, 22);
            this.Menu_Pawn_Close.Text = "绝当处理";
            this.Menu_Pawn_Close.Click += new System.EventHandler(this.Menu_Pawn_Close_Click);
            // 
            // Menu_Pawn_Freeze
            // 
            this.Menu_Pawn_Freeze.Name = "Menu_Pawn_Freeze";
            this.Menu_Pawn_Freeze.Size = new System.Drawing.Size(152, 22);
            this.Menu_Pawn_Freeze.Text = "冻结处理";
            this.Menu_Pawn_Freeze.Click += new System.EventHandler(this.Menu_Pawn_Freeze_Click);
            // 
            // Menu_Pawn_Delete
            // 
            this.Menu_Pawn_Delete.Name = "Menu_Pawn_Delete";
            this.Menu_Pawn_Delete.Size = new System.Drawing.Size(152, 22);
            this.Menu_Pawn_Delete.Text = "删除处理";
            this.Menu_Pawn_Delete.Click += new System.EventHandler(this.Menu_Pawn_Delete_Click);
            // 
            // Menu_Pawn_Clear
            // 
            this.Menu_Pawn_Clear.Name = "Menu_Pawn_Clear";
            this.Menu_Pawn_Clear.Size = new System.Drawing.Size(152, 22);
            this.Menu_Pawn_Clear.Text = "清算处理";
            this.Menu_Pawn_Clear.Click += new System.EventHandler(this.Menu_Pawn_Clear_Click);
            // 
            // MenuQuery
            // 
            this.MenuQuery.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Query,
            this.Menu_CurrentDay_Operations,
            this.Menu_PawnTicket_Query});
            this.MenuQuery.Name = "MenuQuery";
            this.MenuQuery.Size = new System.Drawing.Size(65, 20);
            this.MenuQuery.Text = "统计查询";
            // 
            // Menu_Query
            // 
            this.Menu_Query.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Query_By_Finance,
            this.Menu_Query_By_Class,
            this.Menu_Query_By_Taking});
            this.Menu_Query.Name = "Menu_Query";
            this.Menu_Query.Size = new System.Drawing.Size(152, 22);
            this.Menu_Query.Text = "典当分布统计";
            // 
            // Menu_Query_By_Finance
            // 
            this.Menu_Query_By_Finance.Name = "Menu_Query_By_Finance";
            this.Menu_Query_By_Finance.Size = new System.Drawing.Size(154, 22);
            this.Menu_Query_By_Finance.Text = "按典当资金统计";
            this.Menu_Query_By_Finance.Click += new System.EventHandler(this.Menu_Query_By_Finance_Click);
            // 
            // Menu_Query_By_Class
            // 
            this.Menu_Query_By_Class.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Query_By_Class_Standard,
            this.Menu_Query_By_Class_Statistical});
            this.Menu_Query_By_Class.Name = "Menu_Query_By_Class";
            this.Menu_Query_By_Class.Size = new System.Drawing.Size(154, 22);
            this.Menu_Query_By_Class.Text = "按典当分类统计";
            // 
            // Menu_Query_By_Class_Standard
            // 
            this.Menu_Query_By_Class_Standard.Name = "Menu_Query_By_Class_Standard";
            this.Menu_Query_By_Class_Standard.Size = new System.Drawing.Size(118, 22);
            this.Menu_Query_By_Class_Standard.Text = "标准分类";
            this.Menu_Query_By_Class_Standard.Click += new System.EventHandler(this.Menu_Query_By_Class_Standard_Click);
            // 
            // Menu_Query_By_Class_Statistical
            // 
            this.Menu_Query_By_Class_Statistical.Name = "Menu_Query_By_Class_Statistical";
            this.Menu_Query_By_Class_Statistical.Size = new System.Drawing.Size(118, 22);
            this.Menu_Query_By_Class_Statistical.Text = "统计分类";
            this.Menu_Query_By_Class_Statistical.Click += new System.EventHandler(this.Menu_Query_By_Class_Statistical_Click);
            // 
            // Menu_Query_By_Taking
            // 
            this.Menu_Query_By_Taking.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Query_By_Taking_Standard,
            this.Menu_Query_By_Statistical});
            this.Menu_Query_By_Taking.Name = "Menu_Query_By_Taking";
            this.Menu_Query_By_Taking.Size = new System.Drawing.Size(154, 22);
            this.Menu_Query_By_Taking.Text = "按营收分类统计";
            // 
            // Query_By_Taking_Standard
            // 
            this.Query_By_Taking_Standard.Name = "Query_By_Taking_Standard";
            this.Query_By_Taking_Standard.Size = new System.Drawing.Size(118, 22);
            this.Query_By_Taking_Standard.Text = "标准分类";
            this.Query_By_Taking_Standard.Click += new System.EventHandler(this.Query_By_Taking_Standard_Click);
            // 
            // Menu_Query_By_Statistical
            // 
            this.Menu_Query_By_Statistical.Name = "Menu_Query_By_Statistical";
            this.Menu_Query_By_Statistical.Size = new System.Drawing.Size(118, 22);
            this.Menu_Query_By_Statistical.Text = "统计分类";
            this.Menu_Query_By_Statistical.Click += new System.EventHandler(this.Menu_Query_By_Statistical_Click);
            // 
            // Menu_CurrentDay_Operations
            // 
            this.Menu_CurrentDay_Operations.Name = "Menu_CurrentDay_Operations";
            this.Menu_CurrentDay_Operations.Size = new System.Drawing.Size(152, 22);
            this.Menu_CurrentDay_Operations.Text = "当日业务监控";
            this.Menu_CurrentDay_Operations.Click += new System.EventHandler(this.Menu_CurrentDay_Operations_Click);
            // 
            // Menu_PawnTicket_Query
            // 
            this.Menu_PawnTicket_Query.Name = "Menu_PawnTicket_Query";
            this.Menu_PawnTicket_Query.Size = new System.Drawing.Size(152, 22);
            this.Menu_PawnTicket_Query.Text = "当票检索";
            this.Menu_PawnTicket_Query.Click += new System.EventHandler(this.Menu_PawnTicket_Search_Click);
            // 
            // MenuCustomerInfo
            // 
            this.MenuCustomerInfo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Customer_Add,
            this.Menu_Customer_Query});
            this.MenuCustomerInfo.Name = "MenuCustomerInfo";
            this.MenuCustomerInfo.Size = new System.Drawing.Size(89, 20);
            this.MenuCustomerInfo.Text = "客户信息管理";
            // 
            // Menu_Customer_Add
            // 
            this.Menu_Customer_Add.Name = "Menu_Customer_Add";
            this.Menu_Customer_Add.Size = new System.Drawing.Size(142, 22);
            this.Menu_Customer_Add.Text = "添加新客户";
            this.Menu_Customer_Add.Click += new System.EventHandler(this.Menu_Customer_Add_Click);
            // 
            // Menu_Customer_Query
            // 
            this.Menu_Customer_Query.Name = "Menu_Customer_Query";
            this.Menu_Customer_Query.Size = new System.Drawing.Size(142, 22);
            this.Menu_Customer_Query.Text = "客户信息查询";
            this.Menu_Customer_Query.Click += new System.EventHandler(this.Menu_Customer_Query_Click);
            // 
            // Menu_News
            // 
            this.Menu_News.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_News_View,
            this.Menu_News_Manage});
            this.Menu_News.Name = "Menu_News";
            this.Menu_News.Size = new System.Drawing.Size(65, 20);
            this.Menu_News.Text = "公告管理";
            this.Menu_News.Visible = false;
            // 
            // Menu_News_View
            // 
            this.Menu_News_View.Name = "Menu_News_View";
            this.Menu_News_View.Size = new System.Drawing.Size(142, 22);
            this.Menu_News_View.Text = "查看所有公告";
            // 
            // Menu_News_Manage
            // 
            this.Menu_News_Manage.Name = "Menu_News_Manage";
            this.Menu_News_Manage.Size = new System.Drawing.Size(142, 22);
            this.Menu_News_Manage.Text = "内容管理";
            this.Menu_News_Manage.Click += new System.EventHandler(this.Menu_News_Manage_Click);
            // 
            // MenuSystemSet
            // 
            this.MenuSystemSet.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_CompanyInfo_Set,
            this.Menu_PawnageClass_Set});
            this.MenuSystemSet.Name = "MenuSystemSet";
            this.MenuSystemSet.Size = new System.Drawing.Size(65, 20);
            this.MenuSystemSet.Text = "系统设定";
            // 
            // Menu_CompanyInfo_Set
            // 
            this.Menu_CompanyInfo_Set.Name = "Menu_CompanyInfo_Set";
            this.Menu_CompanyInfo_Set.Size = new System.Drawing.Size(154, 22);
            this.Menu_CompanyInfo_Set.Text = "典当行信息设定";
            this.Menu_CompanyInfo_Set.Click += new System.EventHandler(this.Menu_CompanyInfo_Set_Click);
            // 
            // Menu_PawnageClass_Set
            // 
            this.Menu_PawnageClass_Set.Name = "Menu_PawnageClass_Set";
            this.Menu_PawnageClass_Set.Size = new System.Drawing.Size(154, 22);
            this.Menu_PawnageClass_Set.Text = "当品类别设定";
            this.Menu_PawnageClass_Set.Click += new System.EventHandler(this.Menu_PawnageClass_Set_Click);
            // 
            // MenuDataManage
            // 
            this.MenuDataManage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Data_Backup,
            this.Menu_Database_Set,
            this.Menu_Substore_Manage});
            this.MenuDataManage.Name = "MenuDataManage";
            this.MenuDataManage.Size = new System.Drawing.Size(65, 20);
            this.MenuDataManage.Text = "数据管理";
            // 
            // Menu_Data_Backup
            // 
            this.Menu_Data_Backup.Name = "Menu_Data_Backup";
            this.Menu_Data_Backup.Size = new System.Drawing.Size(130, 22);
            this.Menu_Data_Backup.Text = "数据备份";
            // 
            // Menu_Database_Set
            // 
            this.Menu_Database_Set.Name = "Menu_Database_Set";
            this.Menu_Database_Set.Size = new System.Drawing.Size(130, 22);
            this.Menu_Database_Set.Text = "数据库配置";
            this.Menu_Database_Set.Click += new System.EventHandler(this.Menu_Database_Set_Click);
            // 
            // Menu_Substore_Manage
            // 
            this.Menu_Substore_Manage.Name = "Menu_Substore_Manage";
            this.Menu_Substore_Manage.Size = new System.Drawing.Size(130, 22);
            this.Menu_Substore_Manage.Text = "分店管理";
            this.Menu_Substore_Manage.Click += new System.EventHandler(this.Menu_Substore_Manage_Click);
            // 
            // MenuHelp
            // 
            this.MenuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Help,
            this.Menu_AboutUs,
            this.Menu_Update,
            this.Menu_Website});
            this.MenuHelp.Name = "MenuHelp";
            this.MenuHelp.Size = new System.Drawing.Size(41, 20);
            this.MenuHelp.Text = "帮助";
            // 
            // Menu_Help
            // 
            this.Menu_Help.Name = "Menu_Help";
            this.Menu_Help.Size = new System.Drawing.Size(118, 22);
            this.Menu_Help.Text = "索引";
            // 
            // Menu_AboutUs
            // 
            this.Menu_AboutUs.Name = "Menu_AboutUs";
            this.Menu_AboutUs.Size = new System.Drawing.Size(118, 22);
            this.Menu_AboutUs.Text = "关于我们";
            this.Menu_AboutUs.Click += new System.EventHandler(this.Menu_AboutUs_Click);
            // 
            // Menu_Update
            // 
            this.Menu_Update.Name = "Menu_Update";
            this.Menu_Update.Size = new System.Drawing.Size(118, 22);
            this.Menu_Update.Text = "软件更新";
            this.Menu_Update.Click += new System.EventHandler(this.Menu_Update_Click);
            // 
            // Menu_Website
            // 
            this.Menu_Website.Name = "Menu_Website";
            this.Menu_Website.Size = new System.Drawing.Size(118, 22);
            this.Menu_Website.Text = "访问官网";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 691);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1012, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "数据库已连接";
            // 
            // dockPanel1
            // 
            this.dockPanel1.ActiveAutoHideContent = null;
            this.dockPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel1.DockLeftPortion = 175;
            this.dockPanel1.Location = new System.Drawing.Point(0, 24);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.RightToLeftLayout = true;
            this.dockPanel1.Size = new System.Drawing.Size(1012, 667);
            this.dockPanel1.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 713);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.MainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MainMenu;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "典当软件V1.0";
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem MenuBusiness;
        private System.Windows.Forms.ToolStripMenuItem MenuSystemSet;
        private System.Windows.Forms.ToolStripMenuItem MenuQuery;
        private System.Windows.Forms.ToolStripMenuItem MenuCustomerInfo;
        private System.Windows.Forms.ToolStripMenuItem MenuAccount;
        private System.Windows.Forms.ToolStripMenuItem Menu_Pawn_Create;
        private System.Windows.Forms.ToolStripMenuItem Menu_Pawn_Redeem;
        private System.Windows.Forms.ToolStripMenuItem Menu_Pawn_Close;
        private System.Windows.Forms.ToolStripMenuItem Menu_Pawn_Freeze;
        private System.Windows.Forms.ToolStripMenuItem Menu_Pawn_Renew;
        private System.Windows.Forms.ToolStripMenuItem Menu_Pawn_Delete;
        private System.Windows.Forms.ToolStripMenuItem Menu_Pawn_Clear;
        private System.Windows.Forms.ToolStripMenuItem Menu_Query;
        private System.Windows.Forms.ToolStripMenuItem Menu_Customer_Add;
        private System.Windows.Forms.ToolStripMenuItem Menu_Customer_Query;
        private System.Windows.Forms.ToolStripMenuItem Menu_Edit_Personal_Account;
        private System.Windows.Forms.ToolStripMenuItem Menu_Manage_Accounts;
        private System.Windows.Forms.ToolStripMenuItem Menu_PawnageClass_Set;
        private System.Windows.Forms.ToolStripMenuItem MenuDataManage;
        private System.Windows.Forms.ToolStripMenuItem Menu_Data_Backup;
        private System.Windows.Forms.ToolStripMenuItem MenuHelp;
        private System.Windows.Forms.ToolStripMenuItem Menu_Manage_Roles;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel1;
        private System.Windows.Forms.ToolStripMenuItem Menu_CompanyInfo_Set;
        private System.Windows.Forms.ToolStripMenuItem Menu_Database_Set;
        private System.Windows.Forms.ToolStripMenuItem Menu_Help;
        private System.Windows.Forms.ToolStripMenuItem Menu_AboutUs;
        private System.Windows.Forms.ToolStripMenuItem Menu_Update;
        private System.Windows.Forms.ToolStripMenuItem Menu_Website;
        private System.Windows.Forms.ToolStripMenuItem Menu_Query_By_Finance;
        private System.Windows.Forms.ToolStripMenuItem Menu_Query_By_Class;
        private System.Windows.Forms.ToolStripMenuItem Menu_Exit_System;
        private System.Windows.Forms.ToolStripMenuItem Menu_News;
        private System.Windows.Forms.ToolStripMenuItem Menu_News_View;
        private System.Windows.Forms.ToolStripMenuItem Menu_News_Manage;
        private System.Windows.Forms.ToolStripMenuItem Menu_Query_By_Class_Standard;
        private System.Windows.Forms.ToolStripMenuItem Menu_Query_By_Class_Statistical;
        private System.Windows.Forms.ToolStripMenuItem Menu_Query_By_Taking;
        private System.Windows.Forms.ToolStripMenuItem Query_By_Taking_Standard;
        private System.Windows.Forms.ToolStripMenuItem Menu_Query_By_Statistical;
        private System.Windows.Forms.ToolStripMenuItem Menu_CurrentDay_Operations;
        private System.Windows.Forms.ToolStripMenuItem Menu_PawnTicket_Query;
        private System.Windows.Forms.ToolStripMenuItem Menu_Substore_Manage;
    }
}

