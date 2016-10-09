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
    public partial class CustomerHistoryForm : DockContent
    {
        public CustomerHistoryForm()
        {
            InitializeComponent();
            InitTicketStatus();
        }

        private void InitTicketStatus()
        {
            Query query = new Query(DDTicketStatus.Schema);
            DataTable dt = query.ExecuteDataSet().Tables[0];
            this.StatusID.DataSource = dt;
            this.StatusID.DisplayMember = "Description";
            this.StatusID.ValueMember = "StatusID";
        }

        private void QueryByNumber()
        {
            string strCardNumber = this.tbxCardNumber.Text.Trim();
            DDCustomerInfo customer = new DDCustomerInfo("CertNumber", strCardNumber);
            Query query = new Query(DDPawnTicket.Schema);
            query.AddWhere("CustomerID", customer.CustomerID);
            DataTable dt = query.ExecuteDataSet().Tables[0];
            this.dataGridView1.Rows.Clear();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    this.dataGridView1.Rows.Add(1);
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["CustomerName"].Value = customer.CustomerName;
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["TicketID"].Value = dt.Rows[i]["TicketID"];
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["TicketNumber"].Value = dt.Rows[i]["TicketNumber"];
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["StartDate"].Value = dt.Rows[i]["StartDate"];
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["EndDate"].Value = dt.Rows[i]["EndDate"];
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["StatusID"].Value = dt.Rows[i]["StatusID"];
                }
            }
        }

        private DialogResult CheckCartNumber()
        {
            if (this.tbxCardNumber.Text.Trim().Length > 0)
            {
                return DialogResult.OK;
            }
            else
            {
                return DialogResult.No;
            }
        }

        private void btnQueryByInput_Click(object sender, EventArgs e)
        {
            if (CheckCartNumber() != DialogResult.OK)
            {
                MessageBox.Show("证件号不能为空！", "提示信息");
            }
            else
            {
                QueryByNumber();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {
                DataGridView dgv = (DataGridView)sender;
                if (dgv.Columns[e.ColumnIndex].Name == "BtnOperation")
                {
                    int intTicketID = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells["TicketID"].Value);
                    ViewPawnTicketForm frmViewPawnTicket = new ViewPawnTicketForm(intTicketID);
                    frmViewPawnTicket.Show((DockPanel)MainForm.pCurrentWin.Controls["dockPanel1"]);
                }
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow CurrentRow = this.dataGridView1.Rows[e.RowIndex];
            CurrentRow.HeaderCell.Value = Convert.ToString(e.RowIndex + 1);
        }

        private void btnQueryByCard_Click(object sender, EventArgs e)
        {
            Int32 result;
            Int32 port = 1001;    //USB接口
            UInt32 flag = 0;

            result = CardRecognise.OpenCardReader(port, flag);

            if (result != 0)
            {
                MessageBox.Show(this, "设备初始化失败，请检查设备是否已连接？", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                CardRecognise.PERSONINFOW newInfo = new CardRecognise.PERSONINFOW();
                result = CardRecognise.GetPersonMsgW(ref newInfo, "");
                if (result != 0)
                {
                    MessageBox.Show(this, "读卡错误，请重新操作！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    this.tbxCardNumber.Text = newInfo.cardId;
                    if (CheckCartNumber() != DialogResult.OK)
                    {
                        MessageBox.Show("证件号不能为空！", "提示信息");
                    }
                    else
                    {
                        QueryByNumber();
                    }
                }
            }
            CardRecognise.CloseCardReader();
        }
    }
}