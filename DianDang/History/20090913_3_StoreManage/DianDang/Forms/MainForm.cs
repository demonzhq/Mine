using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace DianDang
{
    public partial class MainForm : Form
    {
        public static MainForm pCurrentWin = null;
        public static string AccountName = "";

        private ToolBoxForm mainToolBox = new ToolBoxForm();
       
        public MainForm()
        {
            InitializeComponent();
            mainToolBox.Show(this.dockPanel1,DockState.DockLeft);
            //CreatePawnForm frmCreatePawn = new CreatePawnForm();
            //frmCreatePawn.Show(this.dockPanel1);
            QueryByFinanceForm frmQueryByByFinanceForm = new QueryByFinanceForm();
            frmQueryByByFinanceForm.Show(this.dockPanel1);
            pCurrentWin = this;
        }

        private IDockContent FindTab(string text)
        {
            if (dockPanel1.DocumentStyle == DocumentStyle.SystemMdi)
            {
                foreach (Form form in MdiChildren)
                    if (form.Text == text)
                        return form as IDockContent;

                return null;
            }
            else
            {
                foreach (IDockContent content in dockPanel1.Documents)
                    if (content.DockHandler.TabText == text)
                        return content;

                return null;
            }
        }

        private void CreateTab(string text)
        {
            IDockContent content = FindTab(text);
            if (content != null)
            {
                content.DockHandler.Show();
            }
            else
            {
                switch (text)
                {
                    case "建当":
                        CreatePawnForm frmCreatePawn = new CreatePawnForm();
                        frmCreatePawn.Show(this.dockPanel1);
                        break;
                    case "添加客户信息":
                        AddCustomerForm frmAddCustomer = new AddCustomerForm();
                        frmAddCustomer.Show(this.dockPanel1);
                        break;
                    case "客户查询":
                        SearchCustomerForm frmSearchCustomre = new SearchCustomerForm();
                        frmSearchCustomre.Show(this.dockPanel1);
                        break;
                    case "续当":
                        RenewPawnForm frmRenewPawn = new RenewPawnForm();
                        frmRenewPawn.Show(this.dockPanel1);
                        break;
                    case "赎当":
                        RedeemPawnForm frmRedeemPawn = new RedeemPawnForm();
                        frmRedeemPawn.Show(this.dockPanel1);
                        break;
                    case "当品类别设定":
                        SetPawnageClassForm frmSetPawnageClass = new SetPawnageClassForm();
                        frmSetPawnageClass.Show(this.dockPanel1);
                        break;
                    case "典当行信息设定":
                        SetCompanyInfoForm frmSetComInfo = new SetCompanyInfoForm();
                        frmSetComInfo.Show(this.dockPanel1);
                        break;
                    case "当票查询":
                        SearchPawnTicketForm frmSearchPawnTicket = new SearchPawnTicketForm();
                        frmSearchPawnTicket.Show(this.dockPanel1);
                        break;
                    case "分店管理":
                        ManageSubstoreForm frmManageSubstore = new ManageSubstoreForm();
                        frmManageSubstore.Show(this.dockPanel1);
                        break;
                    case "删除处理":
                        DeletePawnForm frmDeletePawn = new DeletePawnForm();
                        frmDeletePawn.Show(this.dockPanel1);
                        break;
                    case "绝当处理":
                        ClosePawnForm frmClosePawn = new ClosePawnForm();
                        frmClosePawn.Show(this.dockPanel1);
                        break;
                    case "冻结处理":
                        FreezePawnForm frmFreezePawn = new FreezePawnForm();
                        frmFreezePawn.Show(this.dockPanel1);
                        break;
                    case "清算处理":
                        ClearPawnForm frmClearPawn = new ClearPawnForm();
                        frmClearPawn.Show(this.dockPanel1);
                        break;
                    case "权限管理":
                        ManageRoleForm frmManageRole = new ManageRoleForm();
                        frmManageRole.Show(this.dockPanel1);
                        break;
                    case "帐户管理":
                        ManageAccountForm frmManageAccount = new ManageAccountForm();
                        frmManageAccount.Show(this.dockPanel1);
                        break;
                    case "修改个人信息":
                        EditPersonalAccountForm frmEditPersonalAccount = new EditPersonalAccountForm();
                        frmEditPersonalAccount.Show(this.dockPanel1);
                        break;
                    case "资金统计查询":
                        QueryByFinanceForm frmQueryByFinance = new QueryByFinanceForm();
                        frmQueryByFinance.Show(this.dockPanel1);
                        break;
                    case "公告内容管理":
                        ManageNewsForm frmManageNews = new ManageNewsForm();
                        frmManageNews.Show(this.dockPanel1);
                        break;
                    case "当日业务监控":
                        OperationsOfCurrentDayForm frmOperationOfCurrentDay = new OperationsOfCurrentDayForm();
                        frmOperationOfCurrentDay.Show(this.dockPanel1);
                        break;
                    case "当品标准分类统计":
                        QueryByClassForm frmQueryByStandardClass = new QueryByClassForm(0);
                        frmQueryByStandardClass.Show(this.dockPanel1);
                        break;
                    case "当品统计分类统计":
                        QueryByClassForm frmQueryByStatisticalClass = new QueryByClassForm(1);
                        frmQueryByStatisticalClass.Show(this.dockPanel1);
                        break;
                    case "营收标准分类统计":
                        QueryByTakingForm frmQueryByStandardTaking = new QueryByTakingForm(0);
                        frmQueryByStandardTaking.Show(this.dockPanel1);
                        break;
                    case "营收统计分类统计":
                        QueryByTakingForm frmQueryByStatisticalTaking = new QueryByTakingForm(1);
                        frmQueryByStatisticalTaking.Show(this.dockPanel1);
                        break;
                    default:
                        MessageBox.Show(this, "该功能尚未实现！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
            }
        }

        private void Menu_Pawn_Create_Click(object sender, EventArgs e)
        {
            CreateTab("建当");
        }

        private void Menu_Customer_Add_Click(object sender, EventArgs e)
        {
            CreateTab("添加客户信息");
        }

        private void Menu_Customer_Query_Click(object sender, EventArgs e)
        {
            CreateTab("客户查询");
        }

        private void Menu_Pawn_Renew_Click(object sender, EventArgs e)
        {
            CreateTab("续当");
        }

        private void Menu_Pawn_Redeem_Click(object sender, EventArgs e)
        {
            CreateTab("赎当");
        }

        private void Menu_CompanyInfo_Set_Click(object sender, EventArgs e)
        {
            CreateTab("典当行信息设定");
        }

        private void Menu_PawnageClass_Set_Click(object sender, EventArgs e)
        {
            CreateTab("当品类别设定");
        }

        private void Menu_PawnTicket_Search_Click(object sender, EventArgs e)
        {
            CreateTab("当票查询");
        }

        private void Menu_Database_Set_Click(object sender, EventArgs e)
        {
            ConnectForm frmConn = new ConnectForm();
            frmConn.ShowDialog();
        }

        private void Menu_AboutUs_Click(object sender, EventArgs e)
        {
            AboutusForm frmAbout = new AboutusForm();
            frmAbout.Show();
        }

        private void Menu_Substore_Manage_Click(object sender, EventArgs e)
        {
            CreateTab("分店管理");
        }

        private void Menu_Query_By_Class_Click(object sender, EventArgs e)
        {
            CreateTab("当品分类统计");
        }

        private void Menu_Pawn_Delete_Click(object sender, EventArgs e)
        {
            CreateTab("删除处理");
        }

        private void Menu_Pawn_Close_Click(object sender, EventArgs e)
        {
            CreateTab("绝当处理");
        }

        private void Menu_Pawn_Freeze_Click(object sender, EventArgs e)
        {
            CreateTab("冻结处理");
        }

        private void Menu_Pawn_Clear_Click(object sender, EventArgs e)
        {
            CreateTab("清算处理");
        }

        private void Menu_Exit_System_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Menu_Manage_Roles_Click(object sender, EventArgs e)
        {
            CreateTab("权限管理");
        }

        private void Menu_Manage_Accounts_Click(object sender, EventArgs e)
        {
            CreateTab("帐户管理");
        }

        private void Menu_Edit_Personal_Account_Click(object sender, EventArgs e)
        {
            CreateTab("修改个人信息");
        }

        private void Menu_Query_By_Finance_Click(object sender, EventArgs e)
        {
            CreateTab("资金统计查询");
        }

        private void Menu_Update_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "该软件已为最新版本，无需更新！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Menu_News_Manage_Click(object sender, EventArgs e)
        {
            CreateTab("公告内容管理");
        }

        private void Menu_Query_By_Class_Standard_Click(object sender, EventArgs e)
        {
            CreateTab("当品标准分类统计");
        }

        private void Menu_Query_By_Class_Statistical_Click(object sender, EventArgs e)
        {
            CreateTab("当品统计分类统计");
        }

        private void Query_By_Taking_Standard_Click(object sender, EventArgs e)
        {
            CreateTab("营收标准分类统计");
        }

        private void Menu_Query_By_Statistical_Click(object sender, EventArgs e)
        {
            CreateTab("营收统计分类统计");
        }

        private void Menu_CurrentDay_Operations_Click(object sender, EventArgs e)
        {
            CreateTab("当日业务监控");
        }
    }
}