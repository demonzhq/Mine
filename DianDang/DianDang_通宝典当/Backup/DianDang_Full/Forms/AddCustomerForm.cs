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
                MessageBox.Show("����д�����Ŀͻ���Ϣ��", "��ӿͻ�");
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
                    MessageBox.Show("��ӳɹ���","��ӿͻ�");
                }
                catch
                {
                    MessageBox.Show("���ʧ�ܣ��������ݿ��Ƿ�������ȷ��","��ӿͻ�");
                }
            }
        }

        private void btnGetCustomerInfo_Click(object sender, EventArgs e)
        {
            Int32 result;
            Int32 port = 1001;    //USB�ӿ�
            UInt32 flag = 0;

            result = CardRecognise.OpenCardReader(port, flag);

            if (result != 0)    //
            {
                MessageBox.Show("�豸��ʼ��ʧ�ܣ������豸�Ƿ������ӣ�");
            }
            else
            {
                CardRecognise.PERSONINFOW newInfo = new CardRecognise.PERSONINFOW();
                result = CardRecognise.GetPersonMsgW(ref newInfo, "");
                if (result != 0)
                {
                    MessageBox.Show("����ʧ�ܣ�");
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