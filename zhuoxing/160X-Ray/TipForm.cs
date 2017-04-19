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
    public partial class TipForm : Form
    {
        public TipForm()
        {
            InitializeComponent();
            
        }

        public void SetDisplay(string Display)
        {
            this.label1.Text = Display;
        }

        public void SetPos(int mX, int mY)
        {
            this.Location = new Point(mX, mY);
        }

        public Point GetPos()
        {
            return this.Location;
        }
    }
}
