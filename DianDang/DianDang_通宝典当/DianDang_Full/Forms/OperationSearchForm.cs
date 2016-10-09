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
    public partial class OperationSearchForm : DockContent
    {
        public OperationSearchForm()
        {
            InitializeComponent();
            InitTicketSearchRange();
            InitGridTableColumn();

        }

        private void InitTicketSearchRange()
        {
            DataSet comboRangeDataset;
            Query query = new Query(DDTicketStatus.Schema);
            query.AddWhere("IsOperation", 1);
            comboRangeDataset = query.ExecuteDataSet();
            this.cbxOperationType.DisplayMember = "Description";
            this.cbxOperationType.ValueMember = "StatusID";
            this.cbxOperationType.DataSource = comboRangeDataset.Tables[0];

            OperationType.DisplayMember = "Description";
            OperationType.ValueMember = "StatusID";
            OperationType.DataSource = comboRangeDataset.Tables[0].Copy();
        }

        private int DateTextBoxNum = 0;

        private void tbxEndDate_Click(object sender, EventArgs e)
        {
            DateTextBoxNum = 2;
            this.monthCalendar1.Visible = true;
        }

        private void tbxStartDate_Click(object sender, EventArgs e)
        {
            DateTextBoxNum = 1;
            this.monthCalendar1.Visible = true;
        }

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
                switch (DateTextBoxNum)
                {
                    case 1:
                        this.tbxStartDate.Text = _date;
                        break;
                    case 2:
                        this.tbxEndDate.Text = _date;
                        break;
                    default:
                        break;
                }
                //如果选中日期就自动隐藏MonthCalendar控件
                monthCalendar1.Hide();
            }
        }

        private DataTable m_GridTable = new DataTable();

        private void InitGridTableColumn()
        {
            m_GridTable.Columns.Add("TicketNumber", typeof(System.String));
            m_GridTable.Columns.Add("Amount", typeof(System.String));
            m_GridTable.Columns.Add("OperationType", typeof(System.Int32));
            m_GridTable.Columns.Add("OperationDate", typeof(System.String));
            m_GridTable.Columns.Add("OperaterName", typeof(System.String));
        }

        private void InitGridSource()
        {
            m_GridTable.Rows.Clear();
            int intStatusID = Convert.ToInt32(this.cbxOperationType.SelectedValue);
            string strStatus = this.cbxOperationType.Text;
            Query query = new Query(DDOperation.Schema);
            query.AddBetweenAnd("OperationDate", Convert.ToDateTime(this.tbxStartDate.Text), Convert.ToDateTime(this.tbxEndDate.Text));

            if (strStatus != "全部")
            {
                query.AddWhere("OperationType", intStatusID);
            }

            DataTable dt = query.ExecuteDataSet().Tables[0];
            if (dt.Rows.Count > 0)
            {
                double serviceFee = 0, interestFee = 0, overdueFee = 0, returnFee = 0;
                double amount=0, moneyRL = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow drow = m_GridTable.NewRow();
                    DDPawnTicket newTicket=new DDPawnTicket("TicketID",dt.Rows[i]["TicketID"]);
                    drow["TicketNumber"] = newTicket.TicketNumber ;
                    drow["Amount"] = dt.Rows[i]["Amount"];
                    drow["OperationType"] = dt.Rows[i]["OperationType"];
                    drow["OperationDate"] = dt.Rows[i]["OperationDate"];
                    drow["OperaterName"] = dt.Rows[i]["OperaterName"];
                    m_GridTable.Rows.Add(drow);

                    amount = Convert.ToDouble(dt.Rows[i]["Amount"]);
                    serviceFee = Convert.ToDouble(dt.Rows[i]["ServiceFee"]);
                    interestFee = Convert.ToDouble(dt.Rows[i]["InterestFee"]);
                    overdueFee = Convert.ToDouble(dt.Rows[i]["OverdueFee"]);
                    returnFee = Convert.ToDouble(dt.Rows[i]["ReturnFee"]);

                    switch (Convert.ToInt32(dt.Rows[i]["OperationType"]))
                    {
                        case 1:
                            moneyRL = moneyRL - amount + serviceFee;
                            break;
                        case 2:
                            moneyRL = moneyRL + amount + overdueFee + interestFee - returnFee;
                            break;
                        case 3:
                            moneyRL = moneyRL + serviceFee;
                            break;
                        default:
                            break;
                    }
                }
                this.lblMoneyRL.Text = moneyRL.ToString();
            }

        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (this.tbxStartDate.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, "请选择起始日期！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.tbxEndDate.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, "请选择终止日期！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            InitGridSource();
            this.dataGridView1.DataSource = m_GridTable;
        }
    }
}