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
        private ToolBoxForm mainToolBox = new ToolBoxForm();
       
        public MainForm()
        {
            InitializeComponent();
            mainToolBox.Show(this.dockPanel1,DockState.DockLeft);
            CreatePawnForm frmCreatePawn = new CreatePawnForm();
            frmCreatePawn.Show(this.dockPanel1);
        }

        private void Menu_Pawn_Create_Click(object sender, EventArgs e)
        {
            CreatePawnForm frmCreatePawn = new CreatePawnForm();
            frmCreatePawn.Show(this.dockPanel1);
        }

        private void Menu_Customer_Add_Click(object sender, EventArgs e)
        {
            AddCustomerForm frmAddCustomer = new AddCustomerForm();
            frmAddCustomer.Show(this.dockPanel1);
        }

        private void Menu_Customer_Query_Click(object sender, EventArgs e)
        {
            SearchCustomerForm frmSearchCustomre = new SearchCustomerForm();
            frmSearchCustomre.Show(this.dockPanel1);
        }

        private void Menu_Pawn_Renew_Click(object sender, EventArgs e)
        {
            RenewPawnForm frmRenewPawn = new RenewPawnForm();
            frmRenewPawn.Show(this.dockPanel1);
        }

        private void Menu_Pawn_Redeem_Click(object sender, EventArgs e)
        {
            RedeemPawnForm frmRedeemPawn = new RedeemPawnForm();
            frmRedeemPawn.Show(this.dockPanel1);
        }

        private void Menu_CompanyInfo_Set_Click(object sender, EventArgs e)
        {
            SetCompanyInfoForm frmSetComInfo = new SetCompanyInfoForm();
            frmSetComInfo.Show(this.dockPanel1);
        }

        private void Menu_PawnageClass_Set_Click(object sender, EventArgs e)
        {
            SetPawnageClassForm frmSetPawnageClass = new SetPawnageClassForm();
            frmSetPawnageClass.Show(this.dockPanel1);
        }

        private void Menu_PawnTicket_Search_Click(object sender, EventArgs e)
        {
            SearchPawnTicketForm frmSearchPawnTicket = new SearchPawnTicketForm();
            frmSearchPawnTicket.Show(this.dockPanel1);
        }

        private void Menu_Database_Set_Click(object sender, EventArgs e)
        {
            ConnectForm frmConn = new ConnectForm();
            frmConn.ShowDialog();
        }
    }
}