using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using UtilityLibrary.WinControls;
using SubSonic;

namespace DianDang
{
    public partial class ToolBoxForm : DockContent
    {
        private  OutlookBar outlookBar1 = null;

        public ToolBoxForm()
        {
            InitializeComponent();
            InitializeOutlookbar();
        }

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
            businessBand.Background = Color.OldLace;
            outlookBar1.Bands.Add(businessBand);
            
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
            searchBand.Background = Color.OldLace;
            outlookBar1.Bands.Add(searchBand);
            #endregion

            outlookBar1.Dock = DockStyle.Fill;
            outlookBar1.SetCurrentBand(0);
            outlookBar1.ItemClicked += new OutlookBarItemClickedHandler(OnOutlookBarItemClicked);

            this.panelToolBox.Controls.AddRange(new Control[] { outlookBar1 });
        }

        private DialogResult CheckPermission(string strModuleName)
        {
            DDUser user = new DDUser("AccountName", MainForm.AccountName);
            DDModule module = new DDModule("ModuleName", strModuleName);
            Query query = new Query(DDPermission.Schema);
            query.AddWhere("RoleID", user.RoleID);
            query.AddWhere("ModuleID", module.ModuleID);
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

        private IDockContent FindTab(string text)
        {
            foreach (Form form in MainForm.pCurrentWin.MdiChildren)
                if (form.Text == text)
                    return form as IDockContent;

            return null;
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
                        frmCreatePawn.Show((DockPanel)MainForm.pCurrentWin.Controls["dockPanel1"]);
                        break;
                    case "续当":
                        RenewPawnForm frmRenewPawn = new RenewPawnForm();
                        frmRenewPawn.Show((DockPanel)MainForm.pCurrentWin.Controls["dockPanel1"]);
                        break;
                    case "赎当":
                        RedeemPawnForm frmRedeemPawn = new RedeemPawnForm();
                        frmRedeemPawn.Show((DockPanel)MainForm.pCurrentWin.Controls["dockPanel1"]);
                        break;
                    case "绝当处理":
                        ClosePawnForm frmClosePawn = new ClosePawnForm();
                        frmClosePawn.Show((DockPanel)MainForm.pCurrentWin.Controls["dockPanel1"]);
                        break;
                    case "清算处理":
                        ClearPawnForm frmClearPawn = new ClearPawnForm();
                        frmClearPawn.Show((DockPanel)MainForm.pCurrentWin.Controls["dockPanel1"]);
                        break;
                    case "资金统计查询":
                        QueryByFinanceForm frmQueryByFinance = new QueryByFinanceForm();
                        frmQueryByFinance.Show((DockPanel)MainForm.pCurrentWin.Controls["dockPanel1"]);
                        break;
                    case "当日业务监控":
                        OperationsOfCurrentDayForm frmOperationOfCurrentDay = new OperationsOfCurrentDayForm();
                        frmOperationOfCurrentDay.Show((DockPanel)MainForm.pCurrentWin.Controls["dockPanel1"]);
                        break;
                    case "当品标准分类统计":
                        QueryByClassForm frmQueryByStandardClass = new QueryByClassForm(0);
                        frmQueryByStandardClass.Show((DockPanel)MainForm.pCurrentWin.Controls["dockPanel1"]);
                        break;
                    case "当品统计分类统计":
                        QueryByClassForm frmQueryByStatisticalClass = new QueryByClassForm(1);
                        frmQueryByStatisticalClass.Show((DockPanel)MainForm.pCurrentWin.Controls["dockPanel1"]);
                        break;
                    case "营收标准分类统计":
                        QueryByTakingForm frmQueryByStandardTaking = new QueryByTakingForm(0);
                        frmQueryByStandardTaking.Show((DockPanel)MainForm.pCurrentWin.Controls["dockPanel1"]);
                        break;
                    case "营收统计分类统计":
                        QueryByTakingForm frmQueryByStatisticalTaking = new QueryByTakingForm(1);
                        frmQueryByStatisticalTaking.Show((DockPanel)MainForm.pCurrentWin.Controls["dockPanel1"]);
                        break;
                    default:
                        break;
                }
            }
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

    }
}