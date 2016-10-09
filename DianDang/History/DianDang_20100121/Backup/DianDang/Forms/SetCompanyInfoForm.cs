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
            this.tbxSetupDate.Text=company.SetupDate;
            this.tbxStartTicketNumber.Text=company.StartTicketNumber;
            this.cbxAmountAccuracy.SelectedIndex = Convert.ToInt32(company.AmountAccuracy);
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
            company.SetupDate=this.tbxSetupDate.Text;
            company.StartTicketNumber=this.tbxStartTicketNumber.Text;
            company.AmountAccuracy = this.cbxAmountAccuracy.SelectedIndex.ToString();
            company.Save();
            MessageBox.Show("典当行信息更新成功！");
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            //将用户在MonthCalendar上点击的坐标转换程用户区坐标，并根据坐标获得点击类型
            string s = System.Convert.ToString(monthCalendar1.HitTest(this.PointToClient(MonthCalendar.MousePosition)).HitArea);

            string _year, _month, _day, _date;
            //如果用户点中了日期则对文本框进行赋值并退出
            if (s.Equals("Nowhere"))
            {
                //以下记录选中的日期的各个值
                _year = System.Convert.ToString(e.Start.Year);
                _month = System.Convert.ToString(e.Start.Month);
                _day = System.Convert.ToString(e.Start.Day);
                _date = _year + "-" + _month + "-" + _day;
                this.tbxSetupDate.Text=_date;
            }
                //如果选中日期就自动隐藏MonthCalendar控件
                monthCalendar1.Hide();
        }

        private void tbxSetupDate_Click(object sender, EventArgs e)
        {
            this.monthCalendar1.Visible = true;
        }
    }
}