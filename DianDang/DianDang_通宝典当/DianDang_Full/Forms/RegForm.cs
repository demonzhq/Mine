using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DianDang
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
            //this.tbxRegCode.Text = rg.getMd5(rg.GetCpuID());
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            String sysFolder = System.Environment.SystemDirectory;
            //ע�ᣬ
            //1.�޸�ddreg.ini
            if (tbxRegCode.Text.Trim() != rg.getMd5(rg.GetCpuID()))
            {
                MessageBox.Show("ע�������");
                return;
            }
            else
            {
                File.WriteAllText(sysFolder+"\\ddreg.ini", rg.getMd5(rg.GetCpuID()));

                //���Խ�������������档����������������
                this.DialogResult= DialogResult.OK;
                return;
            }
        }
    }
}