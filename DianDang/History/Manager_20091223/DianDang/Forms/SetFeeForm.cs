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
    public partial class SetFeeForm : DockContent
    {
        public SetFeeForm()
        {
            InitializeComponent();
            LoadFeeRate();
        }

        DDFeeRate feeRate = new DDFeeRate("RateID", 1);
        DDFeeRate interestRate = new DDFeeRate("RateID", 2);

        public void LoadFeeRate()
        {            
            this.tbxFeeRate.Text = feeRate.Rate;
            this.tbxInterestRate.Text = interestRate.Rate;
        }

        public void SetFeeRate()
        {
            feeRate.Rate = this.tbxFeeRate.Text;
            interestRate.Rate = this.tbxInterestRate.Text;

            try
            {
                feeRate.Save();
                interestRate.Save();
                MessageBox.Show("���ʸ��³ɹ���","���ʸ���");
            }
            catch
            {
                MessageBox.Show("���ʸ���ʧ�ܣ������������ݵ���Ч�ԣ�","���ʸ���");
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SetFeeRate();
        }
    }
}