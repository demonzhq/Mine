using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QingTV
{
    public partial class QingTV : Form
    {
        public QingTV()
        {
            InitializeComponent();
            this.isCompactMode = false;
            this.isFullScreen = false;
        }

        void QTV_LostFocus(object sender, System.EventArgs e)
        {
            if (this.isCompactMode)
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.ClientSize = new Size(this.ClientSize.Width, this.ClientSize.Height - this.QMenu.Height);
                this.QMenu.Hide();
                this.Location = new Point(this.Location.X, this.Location.Y + this.QMenu.Height + System.Windows.Forms.SystemInformation.CaptionHeight);
                
            }
        }


        void QTV_GotFocus(object sender, System.EventArgs e)
        {
            if (this.isCompactMode)
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                this.QMenu.Show();
                this.ClientSize = new Size(this.ClientSize.Width, this.ClientSize.Height + this.QMenu.Height);
                this.Location = new Point(this.Location.X, this.Location.Y - this.QMenu.Height - System.Windows.Forms.SystemInformation.CaptionHeight);
            }
        }


        private void 精简ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.isCompactMode = true;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.ShowInTaskbar = false;
            this.QTV.uiMode = "none";
            this.TopMost = true;
        }

        private void 普通ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.QTV.uiMode = "full";
            this.QMenu.Show();
            this.FormBorderStyle = FormBorderStyle.Sizable;
            if (isFullScreen)
            {
                this.Location = OriginalLocation;
                this.ClientSize = OriginalSize;
            }
            if (isCompactMode)
            {
                this.ClientSize = new Size(this.ClientSize.Width, this.ClientSize.Height + this.QMenu.Height);
            }
            this.ShowInTaskbar = true;
            this.TopMost = false;
            this.isFullScreen = false;
            this.isCompactMode = false;
        } 

        void QTV_KeyPressEvent(object sender, AxWMPLib._WMPOCXEvents_KeyPressEvent e)
        {

            if (e.nKeyAscii == 27)
            {
                this.QTV.uiMode = "full";
                this.QMenu.Show();
                this.FormBorderStyle = FormBorderStyle.Sizable;
                if (isFullScreen)
                {
                    this.Location = OriginalLocation;
                    this.ClientSize = OriginalSize;
                }
                if (isCompactMode)
                {
                    this.ClientSize = new Size(this.ClientSize.Width, this.ClientSize.Height + this.QMenu.Height);
                }
                this.ShowInTaskbar = true;
                this.TopMost = false;
                this.isFullScreen = false;
                this.isCompactMode = false;
            }
            else if (e.nKeyAscii == 1 && this.isFullScreen == false)
            {
                this.OriginalLocation = this.Location;
                this.OriginalSize = this.ClientSize;
                this.isFullScreen = true;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.QMenu.Hide();
                this.QTV.uiMode = "none";
                this.Location = new System.Drawing.Point(0, 0);
                this.Size = new Size(System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width, System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height);
            }
            else if (e.nKeyAscii == 1 && this.isFullScreen == true)
            {
                this.isFullScreen = false;
                this.QTV.uiMode = "full";
                this.QMenu.Show();
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.Size = QTV.Size;
                this.Location = OriginalLocation;
                this.ClientSize = OriginalSize; 
                this.ShowInTaskbar = true;
                this.TopMost = false;
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 全屏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.isFullScreen = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.QMenu.Hide();
            this.QTV.uiMode = "none";
            this.Location = new System.Drawing.Point(0, 0);
            this.Size = new Size(System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width, System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height);
        }

        private void 上市体育ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.QTV.URL = "mms://live.smgbb.cn/stv5";
        }

        private void 上视纪实ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.QTV.URL = "mms://live.smgbb.cn/js";
        }

        private void iCSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.QTV.URL = "mms://live.smgbb.cn/music";
        }

        private void 第一财经ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.QTV.URL = "mms://live.smgbb.cn/CBN";
        }

        private void 股票频道ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.QTV.URL = "mms://live.smgbb.cn/stock";
        }

        private void 购物频道ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.QTV.URL = "mms://live.smgbb.cn/ocjshopping";
        }

        private void 凤凰卫视ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.QTV.URL = "mms://61.236.93.37/litv01";
        }

        private void 凤凰资讯ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.QTV.URL = "mms://61.236.93.37/litv03";
        }

        private void channelVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.QTV.URL = "mms://61.236.93.37/litv02";
        }

        private void 阳光卫视ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.QTV.URL = "mms://61.236.93.37/litv04";
        }

        private void tVBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.QTV.URL = "mms://61.236.93.37/litv05";
        }

        private void 星空卫视ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.QTV.URL = "mms://61.236.93.37/litv06";
        }

        private void 乐风ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.QTV.URL = "mms://61.236.93.37/litv07";
        }

        private void cETVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.QTV.URL = "mms://61.236.93.37/litv08";
        }

        private void f体育ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.QTV.URL = "mms://61.236.93.37/litv10";
        }

        private void cCTV9ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.QTV.URL = "mms://61.236.93.37/litv11";
        }

        private void 新知台ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.QTV.URL = "mms://61.236.93.37/litv12";
        }

        private void 华娱ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.QTV.URL = "mms://61.236.93.37/litv13";
        }

        private void 财经HowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.QTV.URL = "mms://61.236.93.37/litv14";
        }

        private void 东方卫视ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.QTV.URL = "mms://live.smgbb.cn/dfws";
        }

        private void 新闻综合ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.QTV.URL = "mms://live.smgbb.cn/xwzh";
        }

        private void 生活时尚ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.QTV.URL = "mms://live.smgbb.cn/shss";
        }

        private void 炫动卡通ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.QTV.URL = "mms://live.smgbb.cn/xdkt";
        }

        private void 电视剧ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.QTV.URL = "mms://live.smgbb.cn/dsj";
        }

        private void 少儿频道ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.QTV.URL = "mms://live.smgbb.cn/dfchild";
        }

        private void 艺术人文ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.QTV.URL = "mms://live.smgbb.cn/wy";
        }

        private void 新闻娱乐ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.QTV.URL = "mms://live.smgbb.cn/xwyl";
        }

        private void 东方戏剧ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.QTV.URL = "mms://live.smgbb.cn/xj";
        }

        private void 东方电影ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.QTV.URL = "mms://live.smgbb.cn/dfdy";
        }
     
    }
}