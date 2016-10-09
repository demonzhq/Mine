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
                MessageBox.Show("费率更新成功！","费率更新");
            }
            catch
            {
                MessageBox.Show("费率更新失败，请检查输入数据的有效性！","费率更新");
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SetFeeRate();
        }
    }
}