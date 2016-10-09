using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using SubSonic;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using UtilityLibrary.WinControls;
using SkinSharp;

namespace DianDang
{
    public partial class MainForm : Form
    {
        public static MainForm pCurrentWin = null;
        public static string AccountName = "";

        private OutlookBar outlookBar1 = null;
        private void InitializeOutlookbar()
        {
            outlookBar1 = new OutlookBar();

            #region 业务管理
            OutlookBarBand businessBand = new OutlookBarBand("业务管理");
            businessBand.SmallImageList = this.imageList;
            businessBand.LargeImageList = this.imageList;
            businessBand.Items.Add(new OutlookBarItem("建当处理", 0));
            businessBand.Items.Add(new OutlookBarItem("赎当处理", 1));
            businessBand.Items.Add(new OutlookBarItem("续当处理", 2));
            businessBand.Items.Add(new OutlookBarItem("绝当处理", 3));
            businessBand.Items.Add(new OutlookBarItem("清算处理", 4));
            //businessBand.Background = SystemColors.AppWorkspace;
            businessBand.TextColor = Color.SandyBrown;
            businessBand.Background = Color.White;
            //outlookBar1.Bands.Add(businessBand);

            #endregion

            #region 统计查询
            OutlookBarBand searchBand = new OutlookBarBand("统计查询");
            searchBand.SmallImageList = this.imageList;
            searchBand.LargeImageList = this.imageList;
            searchBand.Items.Add(new OutlookBarItem("资金统计查询", 5));
            searchBand.Items.Add(new OutlookBarItem("当日业务监控", 6));
            searchBand.Items.Add(new OutlookBarItem("当品标准分类统计", 7));
            searchBand.Items.Add(new OutlookBarItem("当品统计分类统计", 8));
            searchBand.Items.Add(new OutlookBarItem("营收标准分类统计", 9));
            searchBand.Items.Add(new OutlookBarItem("营收统计分类统计", 10));
            //searchBand.Background = SystemColors.AppWorkspace;
            searchBand.TextColor = Color.SandyBrown;
            searchBand.Background = Color.White;
            outlookBar1.Bands.Add(searchBand);
            #endregion

            outlookBar1.Dock = DockStyle.Fill;
            outlookBar1.SetCurrentBand(0);
            outlookBar1.ItemClicked += new OutlookBarItemClickedHandler(OnOutlookBarItemClicked);

            this.panelToolBox.Controls.AddRange(new Control[] { outlookBar1 });
        }

        private void OnOutlookBarItemClicked(OutlookBarBand band, OutlookBarItem item)
        {
            switch (item.Text)
            {
                #region 业务管理

                case "建当处理":
                    CreateTab("建当");
                    break;
                case "赎当处理":
                    CreateTab("赎当");
                    break;
                case "续当处理":
                    CreateTab("续当");
                    break;
                case "绝当处理":
                    CreateTab("绝当处理");
                    break;
                case "清算处理":
                    CreateTab("清算处理");
                    break;
                #endregion

                #region 统计查询
                case "资金统计查询":
                    CreateTab("资金统计查询");
                    break;
                case "当日业务监控":
                    CreateTab("当日业务监控");
                    break;
                case "当品标准分类统计":
                    CreateTab("当品标准分类统计");
                    break;
                case "当品统计分类统计":
                    CreateTab("当品统计分类统计");
                    break;
                case "营收标准分类统计":
                    CreateTab("营收标准分类统计");
                    break;
                case "营收统计分类统计":
                    CreateTab("营收统计分类统计");
                    break;
                #endregion

                default:
                    break;
            }
        }

        public SkinH_Net skinh;
        public MainForm()
        {
            InitializeComponent();
            InitializeOutlookbar();

            OperationsOfCurrentDayForm frmOPerationOfCurrentDayForm = new OperationsOfCurrentDayForm();
            frmOPerationOfCurrentDayForm.Show(this.dockPanel1);
            pCurrentWin = this;

            skinh = new SkinH_Net();
            skinh.Attach();
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

        private DialogResult CheckPermission(string strModuleName)
        {
            DDUser user = new DDUser("AccountName",MainForm.AccountName);
            DDModule module = new DDModule("ModuleName",strModuleName);
            Query query = new Query(DDPermission.Schema);
            query.AddWhere("RoleID",user.RoleID);
            query.AddWhere("ModuleID",module.ModuleID);
            DataTable dt = query.ExecuteDataSet().Tables[0];
            if (dt.Rows.Count > 0)
            {
                return DialogResult.OK;
            }
            else
            {
                return DialogResult.No;
            }            
        }

        private void CreateTab(string text)
        {
            if (CheckPermission(text) != DialogResult.OK)
            {
                MessageBox.Show("对不起，该用户没有权限做此操作！", "提示信息");
                return;
            }

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
                    case "客户历史查询":
                        CustomerHistoryForm frmCustomerHistory = new CustomerHistoryForm();
                        frmCustomerHistory.Show(this.dockPanel1);
                        break;
                    case "续当":
                        RenewPawnForm frmRenewPawn = new RenewPawnForm();
                        frmRenewPawn.Show(this.dockPanel1);
                        break;
                    case "部分赎回":
                        PartRedeemPawnForm frmPartRedeemPawn = new PartRedeemPawnForm();
                        frmPartRedeemPawn.Show(this.dockPanel1);
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
                    case "股票查询":
                        SearchStockForm frmSearchStock = new SearchStockForm();
                        frmSearchStock.Show(this.dockPanel1);
                        break;
                    case "到期房产查询":
                        SearchHouseForm frmSearchHouse = new SearchHouseForm();
                        frmSearchHouse.Show(this.dockPanel1);
                        break;
                    case "房产查询":
                        SearchHouseInfoForm frmSearchHouseInfo = new SearchHouseInfoForm();
                        frmSearchHouseInfo.Show(this.dockPanel1);
                        break;
                    case "车辆查询":
                        SearchCarInfoForm frmSearchCarInfo = new SearchCarInfoForm();
                        frmSearchCarInfo.Show(this.dockPanel1);
                        break;
                    case "黄金查询":
                        SearchGoldForm frmSearchGold = new SearchGoldForm();
                        frmSearchGold.Show(this.dockPanel1);
                        break;
                    case "铂金查询":
                        SearchPtForm frmSearchPt = new SearchPtForm();
                        frmSearchPt.Show(this.dockPanel1);
                        break;
                    case "打印设定":
                        SetPrintForm frmSetPrint = new SetPrintForm();
                        frmSetPrint.Show(this.dockPanel1);
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

        private void Menu_Pawn_RedeemPart_Click(object sender, EventArgs e)
        {
            CreateTab("部分赎回");
        }

        private void Menu_Stock_Search_Click(object sender, EventArgs e)
        {
            CreateTab("股票查询");
        }

        private void Menu_House_Search_Click(object sender, EventArgs e)
        {
            CreateTab("到期房产查询");
        }

        private void Menu_House_Query_Click(object sender, EventArgs e)
        {
            CreateTab("房产查询");
        }

        private void Menu_Car_Query_Click(object sender, EventArgs e)
        {
            CreateTab("车辆查询");
        }

        private void Menu_Gold_Search_Click(object sender, EventArgs e)
        {
            CreateTab("黄金查询");
        }

        private void Menu_Platina_Search_Click(object sender, EventArgs e)
        {
            CreateTab("铂金查询");
        }

        private void Menu_CustomerHistory_Query_Click(object sender, EventArgs e)
        {
            CreateTab("客户历史查询");
        }

        private void Menu_Print_Set_Click(object sender, EventArgs e)
        {
            CreateTab("打印设定");
        }
    }
}