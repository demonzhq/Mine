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
    public partial class AddCustomerForm : DockContent
    {
        public AddCustomerForm()
        {
            InitializeComponent();
            InitComboCertType();
        }

        private void InitComboCertType()
        {
            DataSet comboDataset; 
            Query query = new Query("DDCertTypes");
            comboDataset = query.ExecuteDataSet();
            
            this.cbxCertType.DisplayMember = "TypeName";
            this.cbxCertType.ValueMember = "TypeID";
            this.cbxCertType.DataSource = comboDataset.Tables[0];
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                DDCustomerInfo newCustomer = new DDCustomerInfo();
                newCustomer.CustomerName = this.tbxName.Text;
                newCustomer.PhoneNumber = this.tbxPhone.Text;
                newCustomer.Address = this.tbxAddress.Text;
                newCustomer.ContactPerson = this.tbxContactPerson.Text;
                newCustomer.CertTypeID= Convert.ToInt32(this.cbxCertType.SelectedValue);
                newCustomer.CertNumber = this.tbxCertNum.Text;
                newCustomer.Save();
                MessageBox.Show("添加成功！");
            }
            catch
            {
                MessageBox.Show("添加失败，请检查数据库是否连接正确。");
            }
        }
    }
}