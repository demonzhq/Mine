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
                    case "����":
                        RenewPawnForm frmRenewPawn = new RenewPawnForm();
                        frmRenewPawn.Show(this.dockPanel1);
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
    }
}