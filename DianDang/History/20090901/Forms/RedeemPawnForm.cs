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
    public partial class RedeemPawnForm : DockContent
    {
        public RedeemPawnForm()
        {
            InitializeComponent();
            InitTicketSearchOption();
            InitTicketSearchRange();
        }

        private void InitTicketSearchOption()
        {
            DataSet comboOptionDataset;
            Query query = new Query(DDSearchOption.Schema);
            query.AddWhere("SearchTypeID", 2);
            comboOptionDataset = query.ExecuteDataSet();
            cbxSearchOption.DisplayMember = "OptionName";
            cbxSearchOption.ValueMember = "FieldName";
            cbxSearchOption.DataSource = comboOptionDataset.Tables[0];
        }
        private void InitTicketSearchRange()
        {
            DataSet comboRangeDataset;
            Query query = new Query(DDTicketStatus.Schema);
            comboRangeDataset = query.ExecuteDataSet();
            cbxSearchRange.DisplayMember = "Description";
            cbxSearchRange.ValueMember = "StatusID";
            cbxSearchRange.DataSource = comboRangeDataset.Tables[0];
        }

        DataSet gridDataset;
        private void InitGridSource()
        {
            Query query = new Query(DDPawnTicket.Schema);
            int intStatusID =Convert.ToInt32(this.cbxSearchRange.SelectedValue);
            string strOption = this.cbxSearchOption.SelectedValue.ToString();
            string strKey = "%" + this.tbxKeyWord.Text + "%";
            query.AddWhere(strOption, Comparison.Like, strKey);
            query.AddWhere("StatusID", intStatusID);
            gridDataset = query.ExecuteDataSet();
        }

        private ClsDataGridViewPage dgvPage;

        private void SetForGridViewPage()
        {
            //DataGridView��ҳ
            dgvPage = new ClsDataGridViewPage();
            dgvPage.GetDataGridView = this.dataGridView1;    //��Ҫ��ҳ���� dataGridView1
            dgvPage.RowsPerPage = 15; //ÿҳ��ʾ��������¼              
            dgvPage.SetDataView = gridDataset.Tables[0].DefaultView;
            dgvPage.Paging();    //���÷�ҳ���Paging ������ʼ��ҳ

            if (dgvPage.TotalPage > 0)
            {
                this.btnRedeem.Enabled = true;
                this.btnView.Enabled = true;

                this.btnFirst.Enabled = true;
                this.btnLast.Enabled = true;
                this.btnPre.Enabled = true;
                this.btnNext.Enabled = true;
                this.tbxCurrPage.Enabled = true;
                this.tbxCurrPage.Text = (dgvPage.curPage + 1).ToString();
                this.lblTotalPage.Text = dgvPage.TotalPage.ToString();
            }
            else
            {
                this.btnRedeem.Enabled = false;
                this.btnView.Enabled = false;

                this.btnFirst.Enabled = false;
                this.btnLast.Enabled = false;
                this.btnPre.Enabled = false;
                this.btnNext.Enabled = false;
                this.tbxCurrPage.Text = "0";
                this.tbxCurrPage.Enabled = false;
                this.lblTotalPage.Text = "0";
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow CurrentRow = this.dataGridView1.Rows[e.RowIndex];
            CurrentRow.HeaderCell.Value = Convert.ToString(e.RowIndex + 1);
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            dgvPage.GoFirstPage();
            this.tbxCurrPage.Text = (dgvPage.curPage + 1).ToString();
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            dgvPage.GoPrevPage();
            this.tbxCurrPage.Text = (dgvPage.curPage + 1).ToString();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            dgvPage.GoNextPage();
            this.tbxCurrPage.Text = (dgvPage.curPage + 1).ToString();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            dgvPage.GoLastPage();
            this.tbxCurrPage.Text = (dgvPage.curPage + 1).ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            InitGridSource();

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = gridDataset.Tables[0];
            SetForGridViewPage();    //���÷�ҳ���ú���
        }

        private void btnView_Click(object sender, EventArgs e)
        {

        }

        private void btnRedeem_Click(object sender, EventArgs e)
        {

        }

    }
}