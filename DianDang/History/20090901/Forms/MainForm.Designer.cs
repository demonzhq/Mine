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
            this.MainMEnu = new System.Windows.Forms.MenuStrip();
            this.MenuAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Account_EditPwd = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Account_EditInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.权限管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuBusiness = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Pawn_Create = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Pawn_Redeem = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Pawn_Renew = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Pawn_Close = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Pawn_Freeze = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Pawn_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Pawn_Clear = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Pawn_Replace = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_PawnTicket_Search = new System.Windows.Forms.ToolStripMenuItem();
            this.典当业务统计ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.资金出入帐查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.资金来源统计ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuCustomerInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Customer_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Customer_Query = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSystemSet = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_CompanyInfo_Set = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Fee_Set = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_PawnageClass_Set = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Unit_Set = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDataManage = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Data_Backup = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Database_Set = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.关于本软件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.软件更新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.dockPanel1 = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.MainMEnu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMEnu
            // 
            this.MainMEnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuAccount,
            this.MenuBusiness,
            this.MenuQuery,
            this.MenuCustomerInfo,
            this.MenuSystemSet,
            this.MenuDataManage,
            this.MenuHelp});
            this.MainMEnu.Location = new System.Drawing.Point(0, 0);
            this.MainMEnu.Name = "MainMEnu";
            this.MainMEnu.Size = new System.Drawing.Size(1008, 25);
            this.MainMEnu.TabIndex = 0;
            this.MainMEnu.Text = "menuStrip1";
            // 
            // MenuAccount
            // 
            this.MenuAccount.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Account_EditPwd,
            this.Menu_Account_EditInfo,
            this.权限管理ToolStripMenuItem});
            this.MenuAccount.Name = "MenuAccount";
            this.MenuAccount.Size = new System.Drawing.Size(68, 21);
            this.MenuAccount.Text = "帐户管理";
            // 
            // Menu_Account_EditPwd
            // 
            this.Menu_Account_EditPwd.Name = "Menu_Account_EditPwd";
            this.Menu_Account_EditPwd.Size = new System.Drawing.Size(148, 22);
            this.Menu_Account_EditPwd.Text = "修改密码";
            // 
            // Menu_Account_EditInfo
            // 
            this.Menu_Account_EditInfo.Name = "Menu_Account_EditInfo";
            this.Menu_Account_EditInfo.Size = new System.Drawing.Size(148, 22);
            this.Menu_Account_EditInfo.Text = "修改帐户信息";
            // 
            // 权限管理ToolStripMenuItem
            // 
            this.权限管理ToolStripMenuItem.Name = "权限管理ToolStripMenuItem";
            this.权限管理ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.权限管理ToolStripMenuItem.Text = "权限管理";
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
            this.Menu_Pawn_Clear,
            this.Menu_Pawn_Replace});
            this.MenuBusiness.Name = "MenuBusiness";
            this.MenuBusiness.Size = new System.Drawing.Size(68, 21);
            this.MenuBusiness.Text = "业务处理";
            // 
            // Menu_Pawn_Create
            // 
            this.Menu_Pawn_Create.Name = "Menu_Pawn_Create";
            this.Menu_Pawn_Create.Size = new System.Drawing.Size(124, 22);
            this.Menu_Pawn_Create.Text = "建当处理";
            this.Menu_Pawn_Create.Click += new System.EventHandler(this.Menu_Pawn_Create_Click);
            // 
            // Menu_Pawn_Redeem
            // 
            this.Menu_Pawn_Redeem.Name = "Menu_Pawn_Redeem";
            this.Menu_Pawn_Redeem.Size = new System.Drawing.Size(124, 22);
            this.Menu_Pawn_Redeem.Text = "赎当处理";
            this.Menu_Pawn_Redeem.Click += new System.EventHandler(this.Menu_Pawn_Redeem_Click);
            // 
            // Menu_Pawn_Renew
            // 
            this.Menu_Pawn_Renew.Name = "Menu_Pawn_Renew";
            this.Menu_Pawn_Renew.Size = new System.Drawing.Size(124, 22);
            this.Menu_Pawn_Renew.Text = "续当处理";
            this.Menu_Pawn_Renew.Click += new System.EventHandler(this.Menu_Pawn_Renew_Click);
            // 
            // Menu_Pawn_Close
            // 
            this.Menu_Pawn_Close.Name = "Menu_Pawn_Close";
            this.Menu_Pawn_Close.Size = new System.Drawing.Size(124, 22);
            this.Menu_Pawn_Close.Text = "绝当处理";
            // 
            // Menu_Pawn_Freeze
            // 
            this.Menu_Pawn_Freeze.Name = "Menu_Pawn_Freeze";
            this.Menu_Pawn_Freeze.Size = new System.Drawing.Size(124, 22);
            this.Menu_Pawn_Freeze.Text = "冻结处理";
            // 
            // Menu_Pawn_Delete
            // 
            this.Menu_Pawn_Delete.Name = "Menu_Pawn_Delete";
            this.Menu_Pawn_Delete.Size = new System.Drawing.Size(124, 22);
            this.Menu_Pawn_Delete.Text = "删除处理";
            // 
            // Menu_Pawn_Clear
            // 
            this.Menu_Pawn_Clear.Name = "Menu_Pawn_Clear";
            this.Menu_Pawn_Clear.Size = new System.Drawing.Size(124, 22);
            this.Menu_Pawn_Clear.Text = "清算处理";
            // 
            // Menu_Pawn_Replace
            // 
            this.Menu_Pawn_Replace.Name = "Menu_Pawn_Replace";
            this.Menu_Pawn_Replace.Size = new System.Drawing.Size(124, 22);
            this.Menu_Pawn_Replace.Text = "当品替换";
            // 
            // MenuQuery
            // 
            this.MenuQuery.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_PawnTicket_Search,
            this.典当业务统计ToolStripMenuItem,
            this.资金出入帐查询ToolStripMenuItem,
            this.资金来源统计ToolStripMenuItem});
            this.MenuQuery.Name = "MenuQuery";
            this.MenuQuery.Size = new System.Drawing.Size(68, 21);
            this.MenuQuery.Text = "统计查询";
            // 
            // Menu_PawnTicket_Search
            // 
            this.Menu_PawnTicket_Search.Name = "Menu_PawnTicket_Search";
            this.Menu_PawnTicket_Search.Size = new System.Drawing.Size(160, 22);
            this.Menu_PawnTicket_Search.Text = "当票检索查询";
            this.Menu_PawnTicket_Search.Click += new System.EventHandler(this.Menu_PawnTicket_Search_Click);
            // 
            // 典当业务统计ToolStripMenuItem
            // 
            this.典当业务统计ToolStripMenuItem.Name = "典当业务统计ToolStripMenuItem";
            this.典当业务统计ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.典当业务统计ToolStripMenuItem.Text = "典当业务统计";
            // 
            // 资金出入帐查询ToolStripMenuItem
            // 
            this.资金出入帐查询ToolStripMenuItem.Name = "资金出入帐查询ToolStripMenuItem";
            this.资金出入帐查询ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.资金出入帐查询ToolStripMenuItem.Text = "资金出入帐查询";
            // 
            // 资金来源统计ToolStripMenuItem
            // 
            this.资金来源统计ToolStripMenuItem.Name = "资金来源统计ToolStripMenuItem";
            this.资金来源统计ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.资金来源统计ToolStripMenuItem.Text = "资金来源统计";
            // 
            // MenuCustomerInfo
            // 
            this.MenuCustomerInfo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Customer_Add,
            this.Menu_Customer_Query});
            this.MenuCustomerInfo.Name = "MenuCustomerInfo";
            this.MenuCustomerInfo.Size = new System.Drawing.Size(92, 21);
            this.MenuCustomerInfo.Text = "客户信息管理";
            // 
            // Menu_Customer_Add
            // 
            this.Menu_Customer_Add.Name = "Menu_Customer_Add";
            this.Menu_Customer_Add.Size = new System.Drawing.Size(148, 22);
            this.Menu_Customer_Add.Text = "添加新客户";
            this.Menu_Customer_Add.Click += new System.EventHandler(this.Menu_Customer_Add_Click);
            // 
            // Menu_Customer_Query
            // 
            this.Menu_Customer_Query.Name = "Menu_Customer_Query";
            this.Menu_Customer_Query.Size = new System.Drawing.Size(148, 22);
            this.Menu_Customer_Query.Text = "客户信息查询";
            this.Menu_Customer_Query.Click += new System.EventHandler(this.Menu_Customer_Query_Click);
            // 
            // MenuSystemSet
            // 
            this.MenuSystemSet.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_CompanyInfo_Set,
            this.toolStripMenuItem2,
            this.Menu_Fee_Set,
            this.Menu_PawnageClass_Set,
            this.Menu_Unit_Set});
            this.MenuSystemSet.Name = "MenuSystemSet";
            this.MenuSystemSet.Size = new System.Drawing.Size(68, 21);
            this.MenuSystemSet.Text = "系统设定";
            // 
            // Menu_CompanyInfo_Set
            // 
            this.Menu_CompanyInfo_Set.Name = "Menu_CompanyInfo_Set";
            this.Menu_CompanyInfo_Set.Size = new System.Drawing.Size(160, 22);
            this.Menu_CompanyInfo_Set.Text = "典当行信息设定";
            this.Menu_CompanyInfo_Set.Click += new System.EventHandler(this.Menu_CompanyInfo_Set_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItem2.Text = "分店信息设定";
            // 
            // Menu_Fee_Set
            // 
            this.Menu_Fee_Set.Name = "Menu_Fee_Set";
            this.Menu_Fee_Set.Size = new System.Drawing.Size(160, 22);
            this.Menu_Fee_Set.Text = "典当费率设定";
            // 
            // Menu_PawnageClass_Set
            // 
            this.Menu_PawnageClass_Set.Name = "Menu_PawnageClass_Set";
            this.Menu_PawnageClass_Set.Size = new System.Drawing.Size(160, 22);
            this.Menu_PawnageClass_Set.Text = "当品类别设定";
            this.Menu_PawnageClass_Set.Click += new System.EventHandler(this.Menu_PawnageClass_Set_Click);
            // 
            // Menu_Unit_Set
            // 
            this.Menu_Unit_Set.Name = "Menu_Unit_Set";
            this.Menu_Unit_Set.Size = new System.Drawing.Size(160, 22);
            this.Menu_Unit_Set.Text = "计量单位设定";
            // 
            // MenuDataManage
            // 
            this.MenuDataManage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Data_Backup,
            this.Menu_Database_Set});
            this.MenuDataManage.Name = "MenuDataManage";
            this.MenuDataManage.Size = new System.Drawing.Size(68, 21);
            this.MenuDataManage.Text = "数据管理";
            // 
            // Menu_Data_Backup
            // 
            this.Menu_Data_Backup.Name = "Menu_Data_Backup";
            this.Menu_Data_Backup.Size = new System.Drawing.Size(136, 22);
            this.Menu_Data_Backup.Text = "数据备份";
            // 
            // Menu_Database_Set
            // 
            this.Menu_Database_Set.Name = "Menu_Database_Set";
            this.Menu_Database_Set.Size = new System.Drawing.Size(136, 22);
            this.Menu_Database_Set.Text = "数据库配置";
            this.Menu_Database_Set.Click += new System.EventHandler(this.Menu_Database_Set_Click);
            // 
            // MenuHelp
            // 
            this.MenuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.关于本软件ToolStripMenuItem,
            this.软件更新ToolStripMenuItem});
            this.MenuHelp.Name = "MenuHelp";
            this.MenuHelp.Size = new System.Drawing.Size(44, 21);
            this.MenuHelp.Text = "帮助";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem1.Text = "索引";
            // 
            // 关于本软件ToolStripMenuItem
            // 
            this.关于本软件ToolStripMenuItem.Name = "关于本软件ToolStripMenuItem";
            this.关于本软件ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.关于本软件ToolStripMenuItem.Text = "关于本软件";
            // 
            // 软件更新ToolStripMenuItem
            // 
            this.软件更新ToolStripMenuItem.Name = "软件更新ToolStripMenuItem";
            this.软件更新ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.软件更新ToolStripMenuItem.Text = "软件更新";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 686);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1008, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "数据库已连接";
            // 
            // dockPanel1
            // 
            this.dockPanel1.ActiveAutoHideContent = null;
            this.dockPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel1.DockLeftPortion = 175;
            this.dockPanel1.Location = new System.Drawing.Point(0, 25);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.RightToLeftLayout = true;
            this.dockPanel1.Size = new System.Drawing.Size(1008, 661);
            this.dockPanel1.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 708);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.MainMEnu);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MainMEnu;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "典当软件V1.0";
            this.MainMEnu.ResumeLayout(false);
            this.MainMEnu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMEnu;
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
        private System.Windows.Forms.ToolStripMenuItem Menu_Pawn_Replace;
        private System.Windows.Forms.ToolStripMenuItem Menu_PawnTicket_Search;
        private System.Windows.Forms.ToolStripMenuItem 典当业务统计ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Menu_Customer_Add;
        private System.Windows.Forms.ToolStripMenuItem Menu_Customer_Query;
        private System.Windows.Forms.ToolStripMenuItem Menu_Account_EditPwd;
        private System.Windows.Forms.ToolStripMenuItem Menu_Account_EditInfo;
        private System.Windows.Forms.ToolStripMenuItem Menu_Fee_Set;
        private System.Windows.Forms.ToolStripMenuItem Menu_PawnageClass_Set;
        private System.Windows.Forms.ToolStripMenuItem Menu_Unit_Set;
        private System.Windows.Forms.ToolStripMenuItem MenuDataManage;
        private System.Windows.Forms.ToolStripMenuItem Menu_Data_Backup;
        private System.Windows.Forms.ToolStripMenuItem 资金出入帐查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 资金来源统计ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuHelp;
        private System.Windows.Forms.ToolStripMenuItem 权限管理ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel1;
        private System.Windows.Forms.ToolStripMenuItem Menu_CompanyInfo_Set;
        private System.Windows.Forms.ToolStripMenuItem Menu_Database_Set;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 关于本软件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 软件更新ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    }
}

