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
    public partial class SetCompanyInfoForm : DockContent
    {
        public SetCompanyInfoForm()
        {
            InitializeComponent();
            LoadCompanyInfo();
        }

        private void LoadCompanyInfo()
        {
            DDCompanyInfo company = new DDCompanyInfo("CompanyID", 1);
            this.tbxCompanyName.Text = company.CompanyName;
            this.tbxLicenseCode.Text = company.LicenseCode;
            this.tbxSubCompanyNumber.Text = company.SubCompanyNumber;
            this.tbxSubCompanyName.Text = company.SubCompanyName;
            this.tbxCompanyAdd.Text = company.Address;
            this.tbxCompanyPhone.Text = company.PhoneNumber;
            this.tbxPostalCode.Text = company.Postalcode;
            this.tbxShopHours.Text = company.ShopHours;
            this.tbxRemark.Text = company.Remark;        
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DDCompanyInfo company = new DDCompanyInfo("CompanyID", 1);
            company.CompanyName = this.tbxCompanyName.Text;
            company.LicenseCode = this.tbxLicenseCode.Text;
            company.SubCompanyNumber = this.tbxSubCompanyNumber.Text;
            company.SubCompanyName = this.tbxSubCompanyName.Text;
            company.Address = this.tbxCompanyAdd.Text;
            company.PhoneNumber = this.tbxCompanyPhone.Text;
            company.Postalcode = this.tbxPostalCode.Text;
            company.ShopHours = this.tbxShopHours.Text;
            company.Remark= this.tbxRemark.Text;
            company.Save();
            MessageBox.Show("典当行信息更新成功！");
        }
    }
}