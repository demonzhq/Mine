using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SubSonic;
using WeifenLuo.WinFormsUI.Docking;

namespace DianDang
{
    public partial class SetPrintForm : DockContent
    {
        public SetPrintForm()
        {
            InitializeComponent();
            Init();
        }

        private DDPrintParam param1 = new DDPrintParam("PrintOption", 1);
        //private DDPrintParam param2 = new DDPrintParam("PrintOption", 2);
        private DDPrintParam param3 = new DDPrintParam("PrintOption", 3);
        //private DDPrintParam param4 = new DDPrintParam("PrintOption", 4);
        private DDPrintParam param5 = new DDPrintParam("PrintOption", 5);
        private DDPrintParam param6 = new DDPrintParam("PrintOption", 6);

        private void Init()
        {
            this.cbxPrintCreateTicket.Checked = Convert.ToBoolean(param1.OptionValue);
            //this.cbxPrintCreateReceipt.Checked = Convert.ToBoolean(param2.OptionValue);
            this.cbxPrintRenewTicket.Checked = Convert.ToBoolean(param3.OptionValue);
            //this.cbxPrintRenewReceipt.Checked = Convert.ToBoolean(param4.OptionValue);
            this.cbxPrintRedeemReceipt.Checked = Convert.ToBoolean(param5.OptionValue);
            this.cbxPrintPartRedeemReceipt.Checked = Convert.ToBoolean(param6.OptionValue);
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            try
            {
                param1.OptionValue = Convert.ToInt32(this.cbxPrintCreateTicket.Checked);
                //param2.OptionValue = Convert.ToInt32(this.cbxPrintCreateReceipt.Checked);
                param3.OptionValue = Convert.ToInt32(this.cbxPrintRenewTicket.Checked);
                //param4.OptionValue = Convert.ToInt32(this.cbxPrintRenewReceipt.Checked);
                param5.OptionValue = Convert.ToInt32(this.cbxPrintRedeemReceipt.Checked);
                param6.OptionValue = Convert.ToInt32(this.cbxPrintPartRedeemReceipt.Checked);

                param1.Save();
               // param2.Save();
                param3.Save();
                //param4.Save();
                param5.Save();
                param6.Save();
                MessageBox.Show("设置成功！","提示信息");
            }
            catch
            {
                MessageBox.Show("设置失败，请检查数据库是否连接正确？", "提示信息");
            }
        }
    }
}