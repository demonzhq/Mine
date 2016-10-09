using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DDReg
{
    public partial class RegForm : Form
    {
        public RegForm()
        {
            InitializeComponent();
            this.tbxMachineCode.Text = rg.GetCpuID();
        }

        private Reg rg = new Reg();

        private void btnGetRegCode_Click(object sender, EventArgs e)
        {
            this.tbxRegCode.Text = rg.getMd5(this.tbxMachineCode.Text);
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            String sysFolder = System.Environment.SystemDirectory;
            //注册，
            //1.修改ddreg.ini
            if (tbxRegCode.Text.Trim() != rg.getMd5(rg.GetCpuID()))
            {
                MessageBox.Show("注册码错误！");
                return;
            }
            else
            {
                File.WriteAllText(sysFolder+"\\ddreg.ini", rg.getMd5(rg.GetCpuID()));

                //可以进入软件的主界面。或重新启动本程序。
                this.DialogResult= DialogResult.OK;
                MessageBox.Show("注册成功");
                return;
            }
        }
    }
}