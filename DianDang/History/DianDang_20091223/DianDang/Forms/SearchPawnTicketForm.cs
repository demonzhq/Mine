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
    public partial class SearchPawnTicketForm : DockContent
    {
        public SearchPawnTicketForm()
        {
            InitializeComponent();
            InitTicketSearchOption();
            InitTicketSearchRange();
            InitGridTableColumn();
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
            query.AddWhere("Visible", 1);
            comboRangeDataset = query.ExecuteDataSet();
            cbxSearchRange.DisplayMember = "Description";
            cbxSearchRange.ValueMember = "StatusID";
            cbxSearchRange.DataSource = comboRangeDataset.Tables[0];

            StatusID.DisplayMember = "Description";
            StatusID.ValueMember = "StatusID";
            StatusID.DataSource = comboRangeDataset.Tables[0].Copy();
        }

        private DataTable m_GridTable = new DataTable();

        private void InitGridTableColumn()
        {
            m_GridTable.Columns.Add("TicketID", typeof(System.Int32));
            m_GridTable.Columns.Add("TicketNumber", typeof(System.String));
            m_GridTable.Columns.Add("StartDate", typeof(System.String));
            m_GridTable.Columns.Add("EndDate", typeof(System.String));
            m_GridTable.Columns.Add("StatusID", typeof(System.Int32));
            m_GridTable.Columns.Add("CustomerName", typeof(System.String));
            m_GridTable.Columns.Add("OperaterName", typeof(System.String));
        }
        private void InitGridSource()
        {
            m_GridTable.Rows.Clear();
            Query query = new Query(DDPawnTicket.Schema);            
            int intStatusID =Convert.ToInt32(this.cbxSearchRange.SelectedValue);
            string strStatus = this.cbxSearchRange.Text;
            string strOption = this.cbxSearchOption.SelectedValue.ToString();
            string strKey = "%" + this.tbxKeyWord.Text + "%";
            query.AddWhere(strOption, Comparison.Like,strKey);

            if (strStatus == "过期")
            {
                query.AddWhere("StatusID", Comparison.In, new int[] { 1,3});
                query.AddBetweenAnd("EndDate",Convert.ToDateTime("1900-1-1"),DateTime.Now);
            }
            else if (strStatus == "在库")
            {
                query.AddWhere("StatusID", Comparison.In, new int[] { 1,3,4});
            }
            else if (strStatus != "全部")
            {
                query.AddWhere("StatusID", intStatusID);
            }
            else
            {
                query.AddWhere("StatusID",Comparison.NotEquals,6);  //6--已删除
            }
            DataTable dt = query.ExecuteDataSet().Tables[0];
            if (dt.Rows.Count > 0)
            { 
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow drow = m_GridTable.NewRow();
                    drow["TicketID"] = dt.Rows[i]["TicketID"];
                    drow["TicketNumber"] = dt.Rows[i]["TicketNumber"];
                    drow["StartDate"] = dt.Rows[i]["StartDate"];
                    drow["EndDate"] = dt.Rows[i]["EndDate"];
                    drow["StatusID"] = dt.Rows[i]["StatusID"];
                    DDCustomerInfo customerInfo = new DDCustomerInfo("CustomerID",Convert.ToInt32(dt.Rows[i]["CustomerID"]));
                    DDOperation operation = new DDOperation("TicketID",Convert.ToInt32(dt.Rows[i]["TicketID"]));
                    drow["CustomerName"] = customerInfo.CustomerName;
                    drow["OperaterName"] = operation.OperaterName;
                    m_GridTable.Rows.Add(drow);
                }
            }
        }

        private ClsDataGridViewPage dgvPage;

        private void SetForGridViewPage()
        {
            //DataGridView分页
            dgvPage = new ClsDataGridViewPage();
            dgvPage.GetDataGridView = this.dataGridView1;    //需要分页的是 dataGridView1
            dgvPage.RowsPerPage = 15; //每页显示多少条记录              
            dgvPage.SetDataView = m_GridTable.DefaultView;
            dgvPage.Paging();    //调用分页类的Paging 方法开始分页

            if (dgvPage.TotalPage > 0)
            {
                this.btnViewTicketInfo.Enabled = true;
                this.btnViewOperations.Enabled = true;

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
                this.btnViewTicketInfo.Enabled = false;
                this.btnViewOperations.Enabled = false;

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
            this.btnCaculate.Enabled = false;
            InitGridSource();

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = m_GridTable;
            SetForGridViewPage();    //调用分页设置函数
            if (dataGridView1.Rows.Count > 0)
            {
                this.btnCaculate.Enabled = true;
            }
        }

        private void btnViewOperations_Click(object sender, EventArgs e)
        {
            int intTicketID = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells["TicketID"].Value);
            ViewOperations frmViewOperations = new ViewOperations(intTicketID);
            frmViewOperations.Show((DockPanel)MainForm.pCurrentWin.Controls["dockPanel1"]);
        }

        private void btnViewTicketInfo_Click(object sender, EventArgs e)
        {
            int intTicketID = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells["TicketID"].Value);
            ViewPawnTicketForm frmViewPawnTicket = new ViewPawnTicketForm(intTicketID);
            frmViewPawnTicket.Show((DockPanel)MainForm.pCurrentWin.Controls["dockPanel1"]);
        }

        private void UpdateCloseOperation()
        {
            DataGridViewRow dgr = dataGridView1.CurrentRow;
            int intStatusID = Convert.ToInt32(dgr.Cells["StatusID"].Value);

            if (intStatusID == 1 || intStatusID == 3)
            {
                int iTicketID = Convert.ToInt32(dgr.Cells["TicketID"].Value);
                DDPawnTicket newTicket = new DDPawnTicket("TicketID", iTicketID);

                Query queryOperations = new Query(DDOperation.Schema);
                queryOperations.AddWhere("TicketID", iTicketID);
                queryOperations.AddWhere("NextOperationID", 0);
                DataTable dtOperations = queryOperations.ExecuteDataSet().Tables[0];
                if (dtOperations.Rows.Count > 0)
                {
                    newTicket.StatusID = 4;
                    newTicket.Save();
                    DateTime operateDate = DateTime.Now;
                    string strDate = operateDate.Year.ToString() + "-" + operateDate.Month.ToString() + "-" + operateDate.Day.ToString();
                    int preOperationID = 0;

                    for (int i = 0; i < dtOperations.Rows.Count; i++)
                    {
                        DDOperation newOperation = new DDOperation();
                        preOperationID = Convert.ToInt32(dtOperations.Rows[i]["OperationID"]);
                        newOperation.TicketID = iTicketID;
                        newOperation.PawnageID = Convert.ToInt32(dtOperations.Rows[i]["PawnageID"]);
                        newOperation.OperationType = 4;   //4 ：绝当
                        newOperation.OperationNumber = m_OperationNumber;
                        newOperation.ServiceFee = "0";
                        newOperation.InterestFee = "0";
                        newOperation.ReturnFee = "0";
                        newOperation.OverdueFee = "0";
                        newOperation.Amount = dtOperations.Rows[i]["Amount"].ToString();
                        newOperation.ReckonAmount = "0";
                        newOperation.OperationDate = strDate;
                        newOperation.OperaterName = MainForm.AccountName;
                        newOperation.PreOperationID = preOperationID;
                        newOperation.NextOperationID = 0;
                        newOperation.Save();

                        DDOperation oldOperation = new DDOperation("OperationID", preOperationID);
                        oldOperation.NextOperationID = newOperation.OperationID;
                        oldOperation.Save();
                    }

                    InitGridSource();
                    dataGridView1.DataSource = m_GridTable;
                    MessageBox.Show("绝当处理成功！", "绝当");
                }

            }
            else
            {
                MessageBox.Show("该当票不能进行绝当操作！", "绝当");
            }
        }

        private string CaculateString(string strCode)
        {
            string strChar = string.Empty;
            string strRight, strMiddle, strLeft;
            strRight = string.Empty;
            strMiddle = string.Empty;
            strLeft = string.Empty;

            int j = 0;

            strChar = string.IsNullOrEmpty(strCode) ? "001" : strCode;

            if (strCode.Substring(strChar.Length - 1).Equals("9"))
            {
                for (int i = 0; i < strCode.Length; i++)
                {
                    if (strCode.Substring((strCode.Length - i - 1), 1).Equals("9"))
                        j++;
                    else
                        break;

                }
                strRight = strRight.PadRight(j, '0');   //有多少个9补多少个零
                strMiddle = Convert.ToString(int.Parse(strCode.Substring(strCode.Length - j - 1, 1)) + 1);   //加1后的值
                strLeft = strCode.Substring(0, strCode.Length - j - 1); //
                strChar = strLeft + strMiddle + strRight;

            }
            else
            {
                strRight = Convert.ToString(int.Parse(strCode.Substring(strCode.Length - 1)) + 1);
                strLeft = strCode.Substring(0, strCode.Length - 1);
                strChar = strLeft + strRight;
            }
            return strChar;
        }

        private string m_OperationNumber;
        private void LoadOperationNumber()
        {
            DDGeneralParemeter newParam = new DDGeneralParemeter("ParamName", "OperationNumber");
            m_OperationNumber = newParam.ParamValue.Trim();
        }
        private void UpdateOperationNumber()
        {
            DDGeneralParemeter newParam = new DDGeneralParemeter("ParamName", "OperationNumber");
            newParam.ParamValue = CaculateString(newParam.ParamValue.Trim());
            newParam.Save();
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            DataGridViewRow dgr = dataGridView1.CurrentRow;
            int intTicketID = Convert.ToInt32(dgr.Cells["TicketID"].Value);
            RenewPawnOperationForm frmRenewPawnOperation = new RenewPawnOperationForm(intTicketID);
            frmRenewPawnOperation.Show((DockPanel)MainForm.pCurrentWin.Controls["dockPanel1"]);
        }

        private void btnRedeem_Click(object sender, EventArgs e)
        {
            DataGridViewRow dgr = dataGridView1.CurrentRow;
            int intTicketID = Convert.ToInt32(dgr.Cells["TicketID"].Value);
            RedeemPawnOperationForm frmRedeemPawnOperation = new RedeemPawnOperationForm(intTicketID);
            frmRedeemPawnOperation.Show((DockPanel)MainForm.pCurrentWin.Controls["dockPanel1"]);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DataGridViewRow dgr = dataGridView1.CurrentRow;
            int intTicketID = Convert.ToInt32(dgr.Cells["TicketID"].Value);
            DialogResult dialogResult = MessageBox.Show("确定进行绝当处理？", "绝当", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                LoadOperationNumber();
                UpdateCloseOperation();
                UpdateOperationNumber();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DataGridViewRow dgr = dataGridView1.CurrentRow;
            int intTicketID = Convert.ToInt32(dgr.Cells["TicketID"].Value);
            ClearOperationForm frmClearOperation = new ClearOperationForm(intTicketID);
            frmClearOperation.Show((DockPanel)MainForm.pCurrentWin.Controls["dockPanel1"]);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int intStatusID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["StatusID"].Value);
            switch (intStatusID)
            {
                case 1:
                    this.btnRenew.Enabled = true;
                    this.btnRedeem.Enabled = true;
                    this.btnClose.Enabled = true;
                    this.btnClear.Enabled = false;
                    break;
                case 2:
                    this.btnRenew.Enabled = false;
                    this.btnRedeem.Enabled = false;
                    this.btnClose.Enabled = false;
                    this.btnClear.Enabled = false;
                    break;
                case 3:
                    this.btnRenew.Enabled = true;
                    this.btnRedeem.Enabled = true;
                    this.btnClose.Enabled = true;
                    this.btnClear.Enabled = false;
                    break;
                case 4:
                    this.btnRenew.Enabled = false;
                    this.btnRedeem.Enabled = false;
                    this.btnClose.Enabled = false;
                    this.btnClear.Enabled = true;
                    break;
                default:
                    this.btnRenew.Enabled = false;
                    this.btnRedeem.Enabled = false;
                    this.btnClose.Enabled = false;
                    this.btnClear.Enabled = false;
                    break;
            }
        }

        private void btnCaculate_Click(object sender, EventArgs e)
        {
            double totalCount = 0;
            double totalAmount = 0;
            double redeemAmount = 0;
            double closeAmount = 0;
            double closeClearAmount = 0;
            double clearAmount = 0;
            double unclearAmount = 0;
            double reckoningRlAmount = 0;
            double frezeeAmount = 0;
            double createServiceFee = 0;
            double renewServiceFee = 0;
            double interestFee = 0;
            double overdueFee = 0;

            int intTicketID = 0;
            if (dataGridView1.SelectedRows.Count < 1)
            {
                totalCount = m_GridTable.Rows.Count;
            }
            else
            {
                totalCount = dataGridView1.SelectedRows.Count;
            }
            for (int i = 0; i < totalCount; i++)
            {
                if (dataGridView1.SelectedRows.Count < 1)
                {
                    intTicketID = Convert.ToInt32(m_GridTable.Rows[i]["TicketID"]);
                }
                else
                {
                    intTicketID = Convert.ToInt32(dataGridView1.SelectedRows[i].Cells["TicketID"].Value);
                }
                DDPawnTicket newTicket = new DDPawnTicket("TicketID", intTicketID);

                Query query = new Query(DDOperation.Schema);
                query.AddWhere("TicketID", intTicketID);
                DataTable dt= query.ExecuteDataSet().Tables[0];
                if (dt.Rows.Count > 0)
                {
                    int operationType=0;
                    double amount = 0;
                    double tmpServiceFee=0;
                    double tmpInterestFee=0;
                    double tmpOverdueFee=0;
                    double tmpReturnFee=0;

                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        operationType=Convert.ToInt32(dt.Rows[j]["OperationType"]);
                        amount = Convert.ToDouble(dt.Rows[j]["Amount"]);
                        tmpServiceFee=Convert.ToDouble(dt.Rows[j]["ServiceFee"]);
                        tmpInterestFee=Convert.ToDouble(dt.Rows[j]["InterestFee"]);

                        switch(operationType)
                        {
                            case 1:
                                totalAmount += amount;
                                createServiceFee += tmpServiceFee;
                                interestFee += tmpInterestFee;
                                break;
                            case 2:
                                redeemAmount += amount;
                                interestFee += tmpInterestFee;
                                tmpOverdueFee=Convert.ToDouble(dt.Rows[j]["OverdueFee"]);
                                tmpReturnFee=Convert.ToDouble(dt.Rows[j]["ReturnFee"]);
                                overdueFee += tmpOverdueFee;
                                break;
                            case 3:
                                interestFee += tmpInterestFee;
                                renewServiceFee += tmpServiceFee;
                                break;
                            case 4:
                                closeAmount += amount;
                                break;
                            case 5:
                                frezeeAmount += amount;
                                break;
                            case 7:
                                closeClearAmount += amount;
                                clearAmount+=Convert.ToDouble(dt.Rows[j]["ReckonAmount"]);
                                break;
                            default:
                                break;
                        }                        
                    }
                    reckoningRlAmount = clearAmount - closeClearAmount;
                    unclearAmount = closeAmount - closeClearAmount;
                }
            }

            this.lblTotalCount.Text = totalCount.ToString();
            this.lblTotalAmount.Text = totalAmount.ToString();
            this.lblRedeemAmount.Text = redeemAmount.ToString();
            this.lblCloseAmount.Text = closeAmount.ToString();
            this.lblCloseClearAmount.Text = closeClearAmount.ToString();
            this.lblClearAmount.Text = clearAmount.ToString();
            this.lblUnclearAmount.Text = unclearAmount.ToString();
            this.lblReckoningRL.Text = reckoningRlAmount.ToString();
            this.lblFrezeeAmount.Text = frezeeAmount.ToString();
            this.lblCreateServiceFee.Text = createServiceFee.ToString();
            this.lblRenewServiceFee.Text = renewServiceFee.ToString();
            this.lblInterestFee.Text = interestFee.ToString();
            this.lblOverdueFee.Text = overdueFee.ToString();

            this.gbCaculate.Visible = true;
        }

        private void tbxKeyWord_Click(object sender, EventArgs e)
        {
            if (this.cbxSearchOption.SelectedIndex == 1)
            {
                this.monthCalendar1.Visible = true;
            }
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
                this.tbxKeyWord.Text = _date;
                monthCalendar1.Hide();
            }
        }
    }
}