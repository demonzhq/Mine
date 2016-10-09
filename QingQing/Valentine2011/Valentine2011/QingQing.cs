using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Valentine2011
{
    public partial class QingQing : Form
    {
        public QingQing()
        {
            InitializeComponent();
        }

        private void Form2_MouseHover(object sender, EventArgs e)
        {
            int NewX = -1;
            int NewY = -1;
            while (NewX <= 0 || NewX > 950 || NewY <= 0 || NewY > 500)
            {
                Random seed = new Random();
                NewX = this.Location.X + seed.Next(-500, 500);
                NewY = this.Location.Y + seed.Next(-500, 500);
            }
            this.Location = new Point(NewX, NewY);
        }
    }
}
