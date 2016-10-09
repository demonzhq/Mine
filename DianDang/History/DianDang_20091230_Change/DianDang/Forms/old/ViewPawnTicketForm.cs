using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using SubSonic;

namespace DianDang
{
    public partial class ViewPawnTicketForm : DockContent
    {
        public ViewPawnTicketForm(int intTicketID)
        {
            InitializeComponent();           
            InitComboboxCertType();
            InitComboboxClass();
            InitFeeRate();
            LoadAllData(intTicketID);
        }

        private void LoadCustomerInfo(int intCustomerID)
        {
            DDCustomerInfo newCustomer = new DDCustomerInfo("CustomerID", intCustomerID);
            this.tbxCustomerName.Text = newCustomer.CustomerName;
            this.tbxCustomerPhone.Text=newCustomer.PhoneNumber;
            this.tbxCustomerAdd.Text = newCustomer.Address;
            this.tbxContactPerson.Text = newCustomer.ContactPerson;
            this.cbxCertType.SelectedValue = newCustomer.CertTypeID;
            this.tbxCertNum.Text = newCustomer.CertNumber;
        }

        private void LoadPawnageInfo(int intTicketID)
        {
            DDPawnTicket newTicket=new DDPawnTicket("TicketID",intTicketID);
            this.tbxTicketNumber.Text = newTicket.TicketNumber;
            this.tbxStartDate.Text = newTicket.StartDate;
            this.tbxEndDate.Text = newTicket.EndDate;
            this.tbxOperateDate.Text = newTicket.OperateDate;

            Query query = new Query(DDPawnageInfo.Schema);
            query.AddWhere("TicketID", intTicketID);
            DataSet ds = query.ExecuteDataSet();
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    switch (i)
                    {
                        case 0:
                            this.cbxParentClass1.SelectedValue=Convert.ToInt32(dt.Rows[i]["ParentID"]);
                            this.cbxChildClass1.SelectedValue = Convert.ToInt32(dt.Rows[i]["ClassID"]);
                            this.tbxCount1.Text = dt.Rows[i]["CountNumber"].ToString();
                            this.tbxPrice1.Text=dt.Rows[i]["Price"].ToString();
                            this.tbxPercent1.Text=dt.Rows[i]["DiscountPercent"].ToString();
                            this.tbxPawnageAmount1.Text=dt.Rows[i]["Amount"].ToString();
                            this.tbxDescr1.Text=dt.Rows[i]["Description"].ToString();
                            break;
                        case 1:
                            this.cbxParentClass2.SelectedValue = Convert.ToInt32(dt.Rows[i]["ParentID"]);
                            this.cbxChildClass2.SelectedValue = Convert.ToInt32(dt.Rows[i]["ClassID"]);
                            this.tbxCount2.Text = dt.Rows[i]["CountNumber"].ToString();
                            this.tbxPrice2.Text = dt.Rows[i]["Price"].ToString();
                            this.tbxPercent2.Text = dt.Rows[i]["DiscountPercent"].ToString();
                            this.tbxPawnageAmount2.Text = dt.Rows[i]["Amount"].ToString();
                            this.tbxDescr2.Text = dt.Rows[i]["Description"].ToString();
                            break;
                        case 2:
                            this.cbxParentClass3.SelectedValue = Convert.ToInt32(dt.Rows[i]["ParentID"]);
                            this.cbxChildClass3.SelectedValue = Convert.ToInt32(dt.Rows[i]["ClassID"]);
                            this.tbxCount3.Text = dt.Rows[i]["CountNumber"].ToString();
                            this.tbxPrice3.Text = dt.Rows[i]["Price"].ToString();
                            this.tbxPercent3.Text = dt.Rows[i]["DiscountPercent"].ToString();
                            this.tbxPawnageAmount3.Text = dt.Rows[i]["Amount"].ToString();
                            this.tbxDescr3.Text = dt.Rows[i]["Description"].ToString();
                            break;
                    }
 
                }
            }
 
        }

        private void LoadCompanyInfo(int intCompanyID)
        {
            DDCompanyInfo company = new DDCompanyInfo("CompanyID", intCompanyID);
            this.tbxCompanyName.Text = company.CompanyName;
            this.tbxCompanyPhone.Text = company.PhoneNumber;
            this.tbxCompanyAdd.Text = company.Address;
            this.tbxLicenseCode.Text = company.LicenseCode;
        }

        private void LoadAllData(int intTicketID)
        {
            DDPawnTicket newTicket = new DDPawnTicket("TicketID", intTicketID);
            LoadCompanyInfo(Convert.ToInt32(newTicket.CompanyID));
            LoadCustomerInfo(Convert.ToInt32(newTicket.CustomerID));
            LoadPawnageInfo(intTicketID);            
        }

        private void InitComboboxCertType()
        {
            Query query = new Query(DDCertType.Schema);
            DataSet comboCertTypeDataset = query.ExecuteDataSet();
            this.cbxCertType.DataSource = comboCertTypeDataset.Tables[0];
            this.cbxCertType.DisplayMember = "TypeName";
            this.cbxCertType.ValueMember = "TypeID";
        }

        private void InitComboboxClass()
        {
            Query query = new Query(DDPawnageClass.Schema);
            query.AddWhere("ParentID", 0);
            DataTable dt = query.ExecuteDataSet().Tables[0];

            this.cbxParentClass1.DisplayMember = "ClassName";
            this.cbxParentClass1.ValueMember = "ClassID";
            this.cbxParentClass1.DataSource = dt;

            this.cbxParentClass2.DisplayMember = "ClassName";
            this.cbxParentClass2.ValueMember = "ClassID";
            this.cbxParentClass2.DataSource = dt.Copy();

            this.cbxParentClass3.DisplayMember = "ClassName";
            this.cbxParentClass3.ValueMember = "ClassID";
            this.cbxParentClass3.DataSource = dt.Copy();

            Query query2 = new Query(DDPawnageClass.Schema);
            query2.AddWhere("ParentID", Convert.ToInt32(cbxParentClass1.SelectedValue));
            DataTable dt2 = query2.ExecuteDataSet().Tables[0];

            this.cbxChildClass1.DataSource = dt2;
            this.cbxChildClass1.DisplayMember = "ClassName";
            this.cbxChildClass1.ValueMember = "ClassID";

            this.cbxChildClass2.DataSource = dt2.Copy();
            this.cbxChildClass2.DisplayMember = "ClassName";
            this.cbxChildClass2.ValueMember = "ClassID";

            this.cbxChildClass3.DataSource = dt2.Copy();
            this.cbxChildClass3.DisplayMember = "ClassName";
            this.cbxChildClass3.ValueMember = "ClassID";
        }

        private void InitFeeRate()
        {
            DDFeeRate newFeeRate = new DDFeeRate("RateType", 1);
            this.tbxFeeRate.Text = newFeeRate.Rate.ToString();
            DDFeeRate newInterestRate = new DDFeeRate("RateType", 2);
            this.tbxInterestRate.Text = newInterestRate.Rate.ToString();
        }
    }
}