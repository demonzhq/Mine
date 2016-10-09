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

            #region ҵ�����
            OutlookBarBand businessBand = new OutlookBarBand("ҵ�����");
            businessBand.SmallImageList = this.imageList;
            businessBand.LargeImageList = this.imageList;
            businessBand.Items.Add(new OutlookBarItem("��������", 0));
            businessBand.Items.Add(new OutlookBarItem("�굱����", 1));
            businessBand.Items.Add(new OutlookBarItem("��������", 2));
            businessBand.Items.Add(new OutlookBarItem("��������", 3));
            businessBand.Items.Add(new OutlookBarItem("���㴦��", 4));
            //businessBand.Background = SystemColors.AppWorkspace;
            businessBand.TextColor = Color.SandyBrown;
            businessBand.Background = Color.OldLace;
            outlookBar1.Bands.Add(businessBand);
            
            #endregion

            #region ͳ�Ʋ�ѯ
            OutlookBarBand searchBand = new OutlookBarBand("ͳ�Ʋ�ѯ");
            searchBand.SmallImageList = this.imageList;
            searchBand.LargeImageList = this.imageList;
            searchBand.Items.Add(new OutlookBarItem("�ʽ�ͳ�Ʋ�ѯ", 5));
            searchBand.Items.Add(new OutlookBarItem("����ҵ����", 6));
            searchBand.Items.Add(new OutlookBarItem("��Ʒ��׼����ͳ��", 7));
            searchBand.Items.Add(new OutlookBarItem("��Ʒͳ�Ʒ���ͳ��", 8));
            searchBand.Items.Add(new OutlookBarItem("Ӫ�ձ�׼����ͳ��", 9));
            searchBand.Items.Add(new OutlookBarItem("Ӫ��ͳ�Ʒ���ͳ��", 10));
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
                MessageBox.Show("�Բ��𣬸��û�û��Ȩ�����˲�����", "��ʾ��Ϣ");
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
                    case "����":
                        CreatePawnForm frmCreatePawn = new CreatePawnForm();
                        frmCreatePawn.Show((DockPanel)MainForm.pCurrentWin.Controls["dockPanel1"]);
                        break;
                    case "����":
                        RenewPawnForm frmRenewPawn = new RenewPawnForm();
                        frmRenewPawn.Show((DockPanel)MainForm.pCurrentWin.Controls["dockPanel1"]);
                        break;
                    case "�굱":
                        RedeemPawnForm frmRedeemPawn = new RedeemPawnForm();
                        frmRedeemPawn.Show((DockPanel)MainForm.pCurrentWin.Controls["dockPanel1"]);
                        break;
                    case "��������":
                        ClosePawnForm frmClosePawn = new ClosePawnForm();
                        frmClosePawn.Show((DockPanel)MainForm.pCurrentWin.Controls["dockPanel1"]);
                        break;
                    case "���㴦��":
                        ClearPawnForm frmClearPawn = new ClearPawnForm();
                        frmClearPawn.Show((DockPanel)MainForm.pCurrentWin.Controls["dockPanel1"]);
                        break;
                    case "�ʽ�ͳ�Ʋ�ѯ":
                        QueryByFinanceForm frmQueryByFinance = new QueryByFinanceForm();
                        frmQueryByFinance.Show((DockPanel)MainForm.pCurrentWin.Controls["dockPanel1"]);
                        break;
                    case "����ҵ����":
                        OperationsOfCurrentDayForm frmOperationOfCurrentDay = new OperationsOfCurrentDayForm();
                        frmOperationOfCurrentDay.Show((DockPanel)MainForm.pCurrentWin.Controls["dockPanel1"]);
                        break;
                    case "��Ʒ��׼����ͳ��":
                        QueryByClassForm frmQueryByStandardClass = new QueryByClassForm(0);
                        frmQueryByStandardClass.Show((DockPanel)MainForm.pCurrentWin.Controls["dockPanel1"]);
                        break;
                    case "��Ʒͳ�Ʒ���ͳ��":
                        QueryByClassForm frmQueryByStatisticalClass = new QueryByClassForm(1);
                        frmQueryByStatisticalClass.Show((DockPanel)MainForm.pCurrentWin.Controls["dockPanel1"]);
                        break;
                    case "Ӫ�ձ�׼����ͳ��":
                        QueryByTakingForm frmQueryByStandardTaking = new QueryByTakingForm(0);
                        frmQueryByStandardTaking.Show((DockPanel)MainForm.pCurrentWin.Controls["dockPanel1"]);
                        break;
                    case "Ӫ��ͳ�Ʒ���ͳ��":
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
                #region ҵ�����

                case "��������":
                    CreateTab("����");
                    break;
                case "�굱����":
                    CreateTab("�굱");
                    break;
                case "��������":
                    CreateTab("����");
                    break;
                case "��������":
                    CreateTab("��������");
                    break;
                case "���㴦��":
                    CreateTab("���㴦��");
                    break;
                #endregion

                #region ͳ�Ʋ�ѯ
                case "�ʽ�ͳ�Ʋ�ѯ":
                    CreateTab("�ʽ�ͳ�Ʋ�ѯ");
                    break;
                case "����ҵ����":
                    CreateTab("����ҵ����");
                    break;
                case "��Ʒ��׼����ͳ��":
                    CreateTab("��Ʒ��׼����ͳ��");
                    break;
                case "��Ʒͳ�Ʒ���ͳ��":
                    CreateTab("��Ʒͳ�Ʒ���ͳ��");
                    break;
                case "Ӫ�ձ�׼����ͳ��":
                    CreateTab("Ӫ�ձ�׼����ͳ��");
                    break;
                case "Ӫ��ͳ�Ʒ���ͳ��":
                    CreateTab("Ӫ��ͳ�Ʒ���ͳ��");
                    break;
                #endregion

                default:
                    break;
            }
        }

    }
}