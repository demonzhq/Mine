using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _160X_Ray
{
    public partial class TimeSettingForm : Form
    {

        public int Seconds = 0;
        public TimeSettingForm(int Timer)
        {
            InitializeComponent();
            try
            {
                setting_Minute.Value = Timer / 60;
                Setting_Second.Value = Timer % 60;
            }
            catch
            {

            }

        }

        private void btn_setting_OK_Click(object sender, EventArgs e)
        {
            try
            {
                Seconds = (int)(setting_Minute).Value * 60 + (int)(Setting_Second.Value);
                if (Seconds > 0 && Seconds < 6000)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("请输入正确的时间", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                }
                
            }
            catch
            {
                MessageBox.Show("请输入正确的时间", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;                
            }
            
        }

        private void btn_setting_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
