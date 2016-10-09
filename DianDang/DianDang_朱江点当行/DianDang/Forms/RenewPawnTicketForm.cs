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
    public partial class RenewPawnTicketForm : DockContent
    {
        public RenewPawnTicketForm()
        {
            InitializeComponent();
        }

        int textBoxNumber;
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            //将用户在MonthCalendar上点击的坐标转换程用户区坐标，并根据坐标获得点击类型
            string s = System.Convert.ToString(monthCalendar1.HitTest(this.PointToClient(MonthCalendar.MousePosition)).HitArea);

            string _year, _month, _day, _date;
            //如果用户点中了日期则对文本框进行赋值并退出
            if (s.Equals("Nowhere"))
            {
                //以下记录选中的日期的各个值
                _year = System.Convert.ToString(e.Start.Year);
                _month = System.Convert.ToString(e.Start.Month);
                _day = System.Convert.ToString(e.Start.Day);
                _date = _year + "-" + _month + "-" + _day;
                switch (textBoxNumber)
                {
                    case 1: 
                        this.tbxStartDate.Text = _date;
                        break;
                    case 2: 
                        this.tbxEndDate.Text = _date;
                        break;
                    case 3:
                        this.tbxCurrentDate.Text = _date;
                        break;
                    default:
                        break;
                }
                //如果选中日期就自动隐藏MonthCalendar控件
                monthCalendar1.Hide();
            }
        }

        private void tbxStartDate_Click(object sender, EventArgs e)
        {
            textBoxNumber = 1;
            this.monthCalendar1.Visible = true;
        }

        private void tbxEndDate_Click(object sender, EventArgs e)
        {
            textBoxNumber = 2;
            this.monthCalendar1.Visible = true;
        }

        private void tbxCurrentDate_Click(object sender, EventArgs e)
        {
            textBoxNumber = 3;
            this.monthCalendar1.Visible = true;
        }
    }
}