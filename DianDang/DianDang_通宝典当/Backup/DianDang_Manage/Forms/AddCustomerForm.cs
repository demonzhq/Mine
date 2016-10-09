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

        private DialogResult CheckAllMessage()
        {
            if (this.tbxName.Text == ""||this.tbxPhone.Text==""||this.tbxAddress.Text==""||this.tbxCertNum.Text==""||this.tbxContactPerson.Text=="")
            {
                MessageBox.Show("请填写完整的客户信息！", "添加客户");
                return DialogResult.No;
            }
            else
            {
                return DialogResult.OK;
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            DialogResult res=CheckAllMessage();
            if (res == DialogResult.OK)
            {
                try
                {
                    DDCustomerInfo newCustomer = new DDCustomerInfo();
                    newCustomer.CustomerName = this.tbxName.Text;
                    newCustomer.PhoneNumber = this.tbxPhone.Text;
                    newCustomer.Address = this.tbxAddress.Text;
                    newCustomer.ContactPerson = this.tbxContactPerson.Text;
                    newCustomer.CertTypeID = Convert.ToInt32(this.cbxCertType.SelectedValue);
                    newCustomer.CertNumber = this.tbxCertNum.Text;
                    newCustomer.CreatDate = DianDangFunction.ChangeDateFormat(DateTime.Now.ToShortDateString());
                    newCustomer.Save();
                    MessageBox.Show("添加成功！","添加客户");
                }
                catch
                {
                    MessageBox.Show("添加失败，请检查数据库是否连接正确！","添加客户");
                }
            }
        }

        private void btnGetCustomerInfo_Click(object sender, EventArgs e)
        {
            Int32 result;
            Int32 port = 1001;    //USB接口
            UInt32 flag = 0;

            result = CardRecognise.OpenCardReader(port, flag);

            if (result != 0)    //
            {
                MessageBox.Show("设备初始化失败，请检查设备是否已连接？");
            }
            else
            {
                CardRecognise.PERSONINFOW newInfo = new CardRecognise.PERSONINFOW();
                result = CardRecognise.GetPersonMsgW(ref newInfo, "");
                if (result != 0)
                {
                    MessageBox.Show("读卡失败！");
                }
                else
                {
                    tbxName.Text = newInfo.name;
                    tbxContactPerson.Text = newInfo.name;
                    tbxAddress.Text = newInfo.address;
                    tbxCertNum.Text = newInfo.cardId;
                }
            }
            CardRecognise.CloseCardReader();
        }
    }
}