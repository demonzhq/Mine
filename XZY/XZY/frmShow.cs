using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XZY
{
    public partial class frmShow : Form
    {
        Algorithm BrakeLightControl = new Algorithm();
        Timer tmrUpdate = new Timer();
        public frmShow()
        {
            InitializeComponent();
            //this.P01.DataBindings.Add("Checked", this.LC, "P0");

            this.tmrUpdate.Interval = 50; //Get CAN message every 5ms
            tmrUpdate.Tick += tmrUpdate_Tick;
            BrakeLightControl.Draw += tmp_Draw;
            tmrUpdate.Start();
        }

        void tmrUpdate_Tick(object sender, EventArgs e)
        {
            lblPrecentage.Text = (tbBrake.Value * 100 / tbBrake.Maximum).ToString() + "%";
            BrakeLightControl.Update(this.tbBrake.Value);
        }

        void tmp_Draw(ResultP P)
        {
            P01.Checked = Convert.ToBoolean(P.P0);
            P02.Checked = Convert.ToBoolean(P.P0);
            P03.Checked = Convert.ToBoolean(P.P0);
            P04.Checked = Convert.ToBoolean(P.P0);
            P05.Checked = Convert.ToBoolean(P.P0);
            P06.Checked = Convert.ToBoolean(P.P0);
            P11.Checked = Convert.ToBoolean(P.P1);
            P12.Checked = Convert.ToBoolean(P.P1);
            P13.Checked = Convert.ToBoolean(P.P1);
            P14.Checked = Convert.ToBoolean(P.P1);
            P15.Checked = Convert.ToBoolean(P.P1);
            P16.Checked = Convert.ToBoolean(P.P1);
            P21.Checked = Convert.ToBoolean(P.P2);
            P22.Checked = Convert.ToBoolean(P.P2);
            P23.Checked = Convert.ToBoolean(P.P2);
            P24.Checked = Convert.ToBoolean(P.P2);
            P25.Checked = Convert.ToBoolean(P.P2);
            P26.Checked = Convert.ToBoolean(P.P2);
        }



    }


}
