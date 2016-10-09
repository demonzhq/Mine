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
            businessBand.Background = Color.White;
            //outlookBar1.Bands.Add(businessBand);

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
                        frmCreatePawn.Show(this.dockPanel1);
                        break;
                    case "��ӿͻ���Ϣ":
                        AddCustomerForm frmAddCustomer = new AddCustomerForm();
                        frmAddCustomer.Show(this.dockPanel1);
                        break;
                    case "�ͻ���ѯ":
                        SearchCustomerForm frmSearchCustomre = new SearchCustomerForm();
                        frmSearchCustomre.Show(this.dockPanel1);
                        break;
                    case "�ͻ���ʷ��ѯ":
                        CustomerHistoryForm frmCustomerHistory = new CustomerHistoryForm();
                        frmCustomerHistory.Show(this.dockPanel1);
                        break;
                    case "����":
                        RenewPawnForm frmRenewPawn = new RenewPawnForm();
                        frmRenewPawn.Show(this.dockPanel1);
                        break;
                    case "�������":
                        PartRedeemPawnForm frmPartRedeemPawn = new PartRedeemPawnForm();
                        frmPartRedeemPawn.Show(this.dockPanel1);
                        break;
                    case "�굱":
                        RedeemPawnForm frmRedeemPawn = new RedeemPawnForm();
                        frmRedeemPawn.Show(this.dockPanel1);
                        break;
                    case "��Ʒ����趨":
                        SetPawnageClassForm frmSetPawnageClass = new SetPawnageClassForm();
                        frmSetPawnageClass.Show(this.dockPanel1);
                        break;
                    case "�䵱����Ϣ�趨":
                        SetCompanyInfoForm frmSetComInfo = new SetCompanyInfoForm();
                        frmSetComInfo.Show(this.dockPanel1);
                        break;
                    case "��Ʊ��ѯ":
                        SearchPawnTicketForm frmSearchPawnTicket = new SearchPawnTicketForm();
                        frmSearchPawnTicket.Show(this.dockPanel1);
                        break;
                    case "�ֵ����":
                        ManageSubstoreForm frmManageSubstore = new ManageSubstoreForm();
                        frmManageSubstore.Show(this.dockPanel1);
                        break;
                    case "ɾ������":
                        DeletePawnForm frmDeletePawn = new DeletePawnForm();
                        frmDeletePawn.Show(this.dockPanel1);
                        break;
                    case "��������":
                        ClosePawnForm frmClosePawn = new ClosePawnForm();
                        frmClosePawn.Show(this.dockPanel1);
                        break;
                    case "���ᴦ��":
                        FreezePawnForm frmFreezePawn = new FreezePawnForm();
                        frmFreezePawn.Show(this.dockPanel1);
                        break;
                    case "���㴦��":
                        ClearPawnForm frmClearPawn = new ClearPawnForm();
                        frmClearPawn.Show(this.dockPanel1);
                        break;
                    case "Ȩ�޹���":
                        ManageRoleForm frmManageRole = new ManageRoleForm();
                        frmManageRole.Show(this.dockPanel1);
                        break;
                    case "�ʻ�����":
                        ManageAccountForm frmManageAccount = new ManageAccountForm();
                        frmManageAccount.Show(this.dockPanel1);
                        break;
                    case "�޸ĸ�����Ϣ":
                        EditPersonalAccountForm frmEditPersonalAccount = new EditPersonalAccountForm();
                        frmEditPersonalAccount.Show(this.dockPanel1);
                        break;
                    case "�ʽ�ͳ�Ʋ�ѯ":
                        QueryByFinanceForm frmQueryByFinance = new QueryByFinanceForm();
                        frmQueryByFinance.Show(this.dockPanel1);
                        break;
                    case "�������ݹ���":
                        ManageNewsForm frmManageNews = new ManageNewsForm();
                        frmManageNews.Show(this.dockPanel1);
                        break;
                    case "����ҵ����":
                        OperationsOfCurrentDayForm frmOperationOfCurrentDay = new OperationsOfCurrentDayForm();
                        frmOperationOfCurrentDay.Show(this.dockPanel1);
                        break;
                    case "��Ʒ��׼����ͳ��":
                        QueryByClassForm frmQueryByStandardClass = new QueryByClassForm(0);
                        frmQueryByStandardClass.Show(this.dockPanel1);
                        break;
                    case "��Ʒͳ�Ʒ���ͳ��":
                        QueryByClassForm frmQueryByStatisticalClass = new QueryByClassForm(1);
                        frmQueryByStatisticalClass.Show(this.dockPanel1);
                        break;
                    case "Ӫ�ձ�׼����ͳ��":
                        QueryByTakingForm frmQueryByStandardTaking = new QueryByTakingForm(0);
                        frmQueryByStandardTaking.Show(this.dockPanel1);
                        break;
                    case "Ӫ��ͳ�Ʒ���ͳ��":
                        QueryByTakingForm frmQueryByStatisticalTaking = new QueryByTakingForm(1);
                        frmQueryByStatisticalTaking.Show(this.dockPanel1);
                        break;
                    case "��Ʊ��ѯ":
                        SearchStockForm frmSearchStock = new SearchStockForm();
                        frmSearchStock.Show(this.dockPanel1);
                        break;
                    case "���ڷ�����ѯ":
                        SearchHouseForm frmSearchHouse = new SearchHouseForm();
                        frmSearchHouse.Show(this.dockPanel1);
                        break;
                    case "������ѯ":
                        SearchHouseInfoForm frmSearchHouseInfo = new SearchHouseInfoForm();
                        frmSearchHouseInfo.Show(this.dockPanel1);
                        break;
                    case "������ѯ":
                        SearchCarInfoForm frmSearchCarInfo = new SearchCarInfoForm();
                        frmSearchCarInfo.Show(this.dockPanel1);
                        break;
                    case "�ƽ��ѯ":
                        SearchGoldForm frmSearchGold = new SearchGoldForm();
                        frmSearchGold.Show(this.dockPanel1);
                        break;
                    case "�����ѯ":
                        SearchPtForm frmSearchPt = new SearchPtForm();
                        frmSearchPt.Show(this.dockPanel1);
                        break;
                    case "��ӡ�趨":
                        SetPrintForm frmSetPrint = new SetPrintForm();
                        frmSetPrint.Show(this.dockPanel1);
                        break;
                    default:
                        MessageBox.Show(this, "�ù�����δʵ�֣�", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
            }
        }

        private void Menu_Pawn_Create_Click(object sender, EventArgs e)
        {
            CreateTab("����");
        }

        private void Menu_Customer_Add_Click(object sender, EventArgs e)
        {
            CreateTab("��ӿͻ���Ϣ");
        }

        private void Menu_Customer_Query_Click(object sender, EventArgs e)
        {
            CreateTab("�ͻ���ѯ");
        }

        private void Menu_Pawn_Renew_Click(object sender, EventArgs e)
        {
            CreateTab("����");
        }

        private void Menu_Pawn_Redeem_Click(object sender, EventArgs e)
        {
            CreateTab("�굱");
        }

        private void Menu_CompanyInfo_Set_Click(object sender, EventArgs e)
        {
            CreateTab("�䵱����Ϣ�趨");
        }

        private void Menu_PawnageClass_Set_Click(object sender, EventArgs e)
        {
            CreateTab("��Ʒ����趨");
        }

        private void Menu_PawnTicket_Search_Click(object sender, EventArgs e)
        {
            CreateTab("��Ʊ��ѯ");
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
            CreateTab("�ֵ����");
        }

        private void Menu_Query_By_Class_Click(object sender, EventArgs e)
        {
            CreateTab("��Ʒ����ͳ��");
        }

        private void Menu_Pawn_Delete_Click(object sender, EventArgs e)
        {
            CreateTab("ɾ������");
        }

        private void Menu_Pawn_Close_Click(object sender, EventArgs e)
        {
            CreateTab("��������");
        }

        private void Menu_Pawn_Freeze_Click(object sender, EventArgs e)
        {
            CreateTab("���ᴦ��");
        }

        private void Menu_Pawn_Clear_Click(object sender, EventArgs e)
        {
            CreateTab("���㴦��");
        }

        private void Menu_Exit_System_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Menu_Manage_Roles_Click(object sender, EventArgs e)
        {
            CreateTab("Ȩ�޹���");
        }

        private void Menu_Manage_Accounts_Click(object sender, EventArgs e)
        {
            CreateTab("�ʻ�����");
        }

        private void Menu_Edit_Personal_Account_Click(object sender, EventArgs e)
        {
            CreateTab("�޸ĸ�����Ϣ");
        }

        private void Menu_Query_By_Finance_Click(object sender, EventArgs e)
        {
            CreateTab("�ʽ�ͳ�Ʋ�ѯ");
        }

        private void Menu_Update_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "�������Ϊ���°汾��������£�", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Menu_News_Manage_Click(object sender, EventArgs e)
        {
            CreateTab("�������ݹ���");
        }

        private void Menu_Query_By_Class_Standard_Click(object sender, EventArgs e)
        {
            CreateTab("��Ʒ��׼����ͳ��");
        }

        private void Menu_Query_By_Class_Statistical_Click(object sender, EventArgs e)
        {
            CreateTab("��Ʒͳ�Ʒ���ͳ��");
        }

        private void Query_By_Taking_Standard_Click(object sender, EventArgs e)
        {
            CreateTab("Ӫ�ձ�׼����ͳ��");
        }

        private void Menu_Query_By_Statistical_Click(object sender, EventArgs e)
        {
            CreateTab("Ӫ��ͳ�Ʒ���ͳ��");
        }

        private void Menu_CurrentDay_Operations_Click(object sender, EventArgs e)
        {
            CreateTab("����ҵ����");
        }

        private void Menu_Pawn_RedeemPart_Click(object sender, EventArgs e)
        {
            CreateTab("�������");
        }

        private void Menu_Stock_Search_Click(object sender, EventArgs e)
        {
            CreateTab("��Ʊ��ѯ");
        }

        private void Menu_House_Search_Click(object sender, EventArgs e)
        {
            CreateTab("���ڷ�����ѯ");
        }

        private void Menu_House_Query_Click(object sender, EventArgs e)
        {
            CreateTab("������ѯ");
        }

        private void Menu_Car_Query_Click(object sender, EventArgs e)
        {
            CreateTab("������ѯ");
        }

        private void Menu_Gold_Search_Click(object sender, EventArgs e)
        {
            CreateTab("�ƽ��ѯ");
        }

        private void Menu_Platina_Search_Click(object sender, EventArgs e)
        {
            CreateTab("�����ѯ");
        }

        private void Menu_CustomerHistory_Query_Click(object sender, EventArgs e)
        {
            CreateTab("�ͻ���ʷ��ѯ");
        }

        private void Menu_Print_Set_Click(object sender, EventArgs e)
        {
            CreateTab("��ӡ�趨");
        }
    }
}