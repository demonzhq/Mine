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
            //���û���MonthCalendar�ϵ��������ת�����û������꣬�����������õ������
            string s = System.Convert.ToString(monthCalendar1.HitTest(this.PointToClient(MonthCalendar.MousePosition)).HitArea);

            string _year, _month, _day, _date;
            //����û���������������ı�����и�ֵ���˳�
            if (s.Equals("Nowhere"))
            {
                //���¼�¼ѡ�е����ڵĸ���ֵ
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
                //���ѡ�����ھ��Զ�����MonthCalendar�ؼ�
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