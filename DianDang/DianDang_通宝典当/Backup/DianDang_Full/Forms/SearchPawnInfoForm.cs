using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using SubSonic;
using System.Collections;

namespace DianDang
{
    public partial class SearchPawnInfoForm : DockContent
    {
        private DataTable m_GridTable = new DataTable();
        private int RowSelected = 0;
        private ClsDataGridViewPage dgvPage;

        public SearchPawnInfoForm()
        {
            InitializeComponent();
            InitializeSearchRange();
            InitalizeSearchOption();
            InitalizeGridTableColumn();
            InitalizeDataGridView();
            this.cbxClassSelector.Hide();
            this.btnPrint.Enabled = false;
            this.btnShowPhoto.Enabled = false;
            this.gbxCarInfo.Hide();
            this.gbxHouseInfo.Hide();
        }

        private void InitializeSearchRange()
        {
            Query query = new Query(DDSearchOption.Schema);
            query.AddWhere("SearchTypeID", 4);
            cbxSearchRange.DisplayMember = "OptionName";
            cbxSearchRange.ValueMember = "FieldName";
            cbxSearchRange.DataSource = query.ExecuteDataSet().Tables[0];
        }

        private void InitalizeSearchOption()
        {
            Query query = new Query(DDSearchOption.Schema);
            query.AddWhere("SearchTypeID", 5);
            cbxSearchOption.DisplayMember = "OptionName";
            cbxSearchOption.ValueMember = "FieldName";
            cbxSearchOption.DataSource = query.ExecuteDataSet().Tables[0];
        }

        private void InitalizeGridTableColumn()
        {
            m_GridTable.Columns.Add("PawnageID", typeof(Int32));
            m_GridTable.Columns.Add("OperationFlag", typeof(bool));
            m_GridTable.Columns.Add("TicketNumber", typeof(string));
            m_GridTable.Columns.Add("FirstClass", typeof(Int32));
            m_GridTable.Columns.Add("SecondClass", typeof(Int32));
            m_GridTable.Columns.Add("Description", typeof(string));
            m_GridTable.Columns.Add("Weight", typeof(string));
            m_GridTable.Columns.Add("TotalCount", typeof(string));
            m_GridTable.Columns.Add("Price", typeof(string));
            m_GridTable.Columns.Add("FeeRate", typeof(string));
            m_GridTable.Columns.Add("InterestRate", typeof(string));
            m_GridTable.Columns.Add("Remark", typeof(string));
            m_GridTable.Columns.Add("PhotoPath", typeof(string));
        }

        private void InitalizeDataGridView()
        {
            Query queryPawnClass = new Query(DDPawnageClass.Schema);
            DataTable dtPawnClass = queryPawnClass.ExecuteDataSet().Tables[0];
            FirstClass.DisplayMember = "ClassName";
            FirstClass.ValueMember = "ClassID";
            SecondClass.DisplayMember = "ClassName";
            SecondClass.ValueMember = "ClassID";
            FirstClass.DataSource = dtPawnClass;
            SecondClass.DataSource = dtPawnClass;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            m_GridTable.Rows.Clear();
            Query queryPawnage = new Query(DDPawnageInfo.Schema);
            bool RedyToQuery = true;
            double Amount = 0;
            string KeyWord = "%" + tbxKeyWord.Text + "%";
            

            #region 加上SearchRange查询限制
            switch (cbxSearchRange.Text)
            {
                case "在库全部":
                    queryPawnage.AddWhere("StatusID", Comparison.In, new int[] { 1, 3, 4, 5 });
                    break;
                case "在库正常":
                    queryPawnage.AddWhere("StatusID", Comparison.In, new int[] { 1, 3 });
                    queryPawnage.AddBetweenAnd("EndDate", DateTime.Now, new DateTime(9999, 12, 23));
                    break;
                case "在库过期":
                    queryPawnage.AddWhere("StatusID", Comparison.In, new int[] { 1, 3 });
                    queryPawnage.AddBetweenAnd("EndDate", new DateTime(1900, 1, 1), DateTime.Now);
                    break;
                case "冻结当品":
                    queryPawnage.AddWhere("StatusID", 5);
                    break;
                case "已绝当":
                    queryPawnage.AddWhere("StatusID", 4);
                    break;
                case "已赎回":
                    queryPawnage.AddWhere("StatusID", 2);
                    break;
                case "已清算":
                    queryPawnage.AddWhere("StatusID", 7);
                    break;
                default:
                    break;
            }
            #endregion


            #region 加上SearchOption查询限制

            Hashtable PawnageIDList = new Hashtable();
            if (cbxSearchOption.Text == "当票号")
            {
                Query queryTicket = new Query(DDPawnTicket.Schema);
                queryTicket.AddWhere("TicketNumber", Comparison.Like, KeyWord);
                DataTable dtTicket = queryTicket.ExecuteDataSet().Tables[0];
                int[] TicketIDList = new int[dtTicket.Rows.Count];
                for (int i = 0; i < dtTicket.Rows.Count; i++)
                {
                    TicketIDList[i] = Convert.ToInt32(dtTicket.Rows[i]["TicketID"].ToString());
                }

                Query queryOperation = new Query(DDOperation.Schema);
                queryOperation.AddWhere("TicketID", Comparison.In, TicketIDList);
                queryOperation.AddWhere("NextOperationID", 0);
                queryOperation.AddWhere("OperationType", Comparison.NotEquals, 6);
                DataTable dtOperation = queryOperation.ExecuteDataSet().Tables[0];
                for (int i = 0; i < dtOperation.Rows.Count; i++)
                {
                    PawnageIDList.Add(dtOperation.Rows[i]["PawnageID"], 0);
                }

                
 
            }
            else if (cbxSearchOption.Text == "客户姓名")
            {
                Query queryCustomer = new Query(DDCustomerInfo.Schema);
                queryCustomer.AddWhere("CustomerName", Comparison.Like, KeyWord);
                DataTable dtCustomer = queryCustomer.ExecuteDataSet().Tables[0];
                int[] CustomerIDList = new int[dtCustomer.Rows.Count];
                for (int i = 0; i < dtCustomer.Rows.Count; i++)
                {
                    CustomerIDList[i] = Convert.ToInt32(dtCustomer.Rows[i]["CustomerID"].ToString());
                }

                Query queryTicket = new Query(DDPawnTicket.Schema);
                queryTicket.AddWhere("CustomerID", Comparison.In, CustomerIDList);
                DataTable dtTicket = queryTicket.ExecuteDataSet().Tables[0];
                int[] TicketIDList = new int[dtTicket.Rows.Count];
                for (int i = 0; i < dtTicket.Rows.Count; i++)
                {
                    TicketIDList[i] = Convert.ToInt32(dtTicket.Rows[i]["TicketID"].ToString());
                }

                Query queryOperation = new Query(DDOperation.Schema);
                queryOperation.AddWhere("TicketID", Comparison.In, TicketIDList);
                queryOperation.AddWhere("NextOperationID", 0);
                queryOperation.AddWhere("OperationType", Comparison.NotEquals, 6);
                DataTable dtOperation = queryOperation.ExecuteDataSet().Tables[0];
                
                for (int i = 0; i < dtOperation.Rows.Count; i++)
                {
                    PawnageIDList.Add(dtOperation.Rows[i]["PawnageID"], 0);
                }

                

            }
            else if (cbxSearchOption.Text == "当值大于")
            {
                try
                {
                    Amount = Convert.ToDouble(tbxKeyWord.Text);
                    queryPawnage.AddWhere("Price", Comparison.GreaterOrEquals, Amount);
                }
                catch
                {
                    RedyToQuery = false;
                    MessageBox.Show("请填入正确的金额", "提示信息");
                }
            }
            else if (cbxSearchOption.Text == "当值小于")
            {
                try
                {
                    Amount = Convert.ToDouble(tbxKeyWord.Text);
                    queryPawnage.AddWhere("Price", Comparison.LessThan, Amount);
                }
                catch
                {
                    RedyToQuery = false;
                    MessageBox.Show("请填入正确的金额", "提示信息");
                }
            }
            else if (cbxSearchOption.Text == "一级分类")
            {
                queryPawnage.AddWhere("ParentID", cbxClassSelector.SelectedValue);
            }
            else if (cbxSearchOption.Text == "二级分类")
            {
                queryPawnage.AddWhere("ClassID", cbxClassSelector.SelectedValue);
            }
            else
            {
                queryPawnage.AddWhere(cbxSearchOption.SelectedValue.ToString(), Comparison.Like, KeyWord);
            }
            #endregion

           



            #region 执行查询
            if (RedyToQuery)
            {
                DataTable dtPawnage = queryPawnage.ExecuteDataSet().Tables[0];
                for (int i = 0; i < dtPawnage.Rows.Count; i++)
                {
                    if ((PawnageIDList[dtPawnage.Rows[i]["PawnageID"]] != null && (this.cbxSearchOption.Text == "当票号" || this.cbxSearchOption.Text == "客户姓名")) || (this.cbxSearchOption.Text != "当票号" && this.cbxSearchOption.Text != "客户姓名"))
                    {
                        DataRow dRow = m_GridTable.NewRow();
                        dRow["PawnageID"] = dtPawnage.Rows[i]["PawnageID"];
                        dRow["OperationFlag"] = false;
                        dRow["FirstClass"] = dtPawnage.Rows[i]["ParentID"];
                        dRow["SecondClass"] = dtPawnage.Rows[i]["ClassID"];
                        dRow["Description"] = dtPawnage.Rows[i]["Description"];
                        dRow["Weight"] = dtPawnage.Rows[i]["Weight"];
                        dRow["Price"] = dtPawnage.Rows[i]["Price"];
                        dRow["TotalCount"] = dtPawnage.Rows[i]["CountNumber"];
                        dRow["FeeRate"] = dtPawnage.Rows[i]["FeeRate"];
                        dRow["InterestRate"] = dtPawnage.Rows[i]["InterestRate"];
                        dRow["Remark"] = dtPawnage.Rows[i]["Remark"];
                        dRow["PhotoPath"] = dtPawnage.Rows[i]["PhotoPath"];
                        //获取当票号
                        Query queryOperation = new Query(DDOperation.Schema);
                        queryOperation.AddWhere("PawnageID", dtPawnage.Rows[i]["PawnageID"]);
                        queryOperation.AddWhere("NextOperationID", 0);
                        queryOperation.AddWhere("OperationType", Comparison.NotEquals, 6);
                        DataTable dtOperation = queryOperation.ExecuteDataSet().Tables[0];
                        if (dtOperation.Rows.Count > 0)
                        {
                            string TicketID = dtOperation.Rows[dtOperation.Rows.Count - 1]["TicketID"].ToString();
                            DDPawnTicket newTicket = new DDPawnTicket("TicketID", TicketID);
                            dRow["TicketNumber"] = newTicket.TicketNumber;
                        }
                        m_GridTable.Rows.Add(dRow);
                    }

                }
                dataGridView1.DataSource = m_GridTable;

                if (dtPawnage.Rows.Count > 0)
                {
                    btnPrint.Enabled = true;
                }
            }
            #endregion

            SetForGridViewPage();

            
        }

        private void cbxSearchOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbxSearchOption.Text == "二级分类")
            {
                this.tbxKeyWord.Hide();
                this.cbxClassSelector.Show();
                Query querySecondClass = new Query(DDPawnageClass.Schema);
                querySecondClass.AddWhere("ParentID", Comparison.NotEquals, 0);
                querySecondClass.AddWhere("ClassID", Comparison.NotEquals, 1);
                cbxClassSelector.DisplayMember = "ClassName";
                cbxClassSelector.ValueMember = "ClassID";
                cbxClassSelector.DataSource = querySecondClass.ExecuteDataSet().Tables[0];
            }
            else if (this.cbxSearchOption.Text == "一级分类")
            {
                this.tbxKeyWord.Hide();
                this.cbxClassSelector.Show();
                Query querySecondClass = new Query(DDPawnageClass.Schema);
                querySecondClass.AddWhere("ParentID", 0);
                cbxClassSelector.DisplayMember = "ClassName";
                cbxClassSelector.ValueMember = "ClassID";
                cbxClassSelector.DataSource = querySecondClass.ExecuteDataSet().Tables[0];
            }
            else
            {
                this.cbxClassSelector.Hide();
                this.tbxKeyWord.Show();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RowSelected = e.RowIndex;
            if (e.RowIndex != -1)
            {
                if (dataGridView1.Rows[RowSelected].Cells["PhotoPath"].Value.ToString() != "")
                {
                    btnShowPhoto.Enabled = true;
                }
                else
                {
                    btnShowPhoto.Enabled = false;
                }

                if (dataGridView1.Rows[RowSelected].Cells["FirstClass"].Value.ToString() == "10")
                {
                    gbxHouseInfo.Hide();

                    this.tbxCarCaseNumber.Text = "";
                    this.tbxCarCheckDate.Text = "";
                    this.tbxCarEngineNumber.Text = "";
                    this.tbxCarLicenseNumber.Text = "";
                    this.tbxCarRoadDate.Text = "";
                    this.tbxCarType.Text = "";
                    this.tbxCarInsuranceDate.Text = "";

                    DDCarInfo newCar = new DDCarInfo("PawnageID", dataGridView1.Rows[RowSelected].Cells["PawnageID"].Value.ToString());
                    this.tbxCarCaseNumber.Text = newCar.CarcaseNumber;
                    this.tbxCarCheckDate.Text = newCar.CheckDate;
                    this.tbxCarEngineNumber.Text = newCar.EngineNumber;
                    this.tbxCarInsuranceDate.Text = newCar.InsuranceDate;
                    this.tbxCarLicenseNumber.Text = newCar.LicenseNumber;
                    this.tbxCarRoadDate.Text = newCar.RoadtollDate;
                    this.tbxCarType.Text = newCar.CarType;

                    this.gbxCarInfo.Show();
                }
                else if (dataGridView1.Rows[RowSelected].Cells["FirstClass"].Value.ToString() == "11")
                {
                    gbxCarInfo.Hide();

                    this.tbxHouseAddress.Text = "";
                    this.tbxHouseArea.Text = "";
                    this.tbxHouseCompactNumber.Text = "";
                    this.tbxHouseInsuranceDate.Text = "";
                    this.tbxHouseNotarizaDate.Text = "";
                    this.tbxHouseRegisterDate.Text = "";

                    DDHouseInfo newHouse = new DDHouseInfo("PawnageID", dataGridView1.Rows[RowSelected].Cells["PawnageID"].Value.ToString());
                    this.tbxHouseAddress.Text = newHouse.Address;
                    this.tbxHouseArea.Text = newHouse.Area;
                    this.tbxHouseCompactNumber.Text = newHouse.CompactNumber;
                    this.tbxHouseInsuranceDate.Text = newHouse.InsuranceDate;
                    this.tbxHouseNotarizaDate.Text = newHouse.NotarizationDate;
                    this.tbxHouseRegisterDate.Text = newHouse.RegisterDate;

                    this.gbxHouseInfo.Show();
                }
                else
                {
                    this.gbxCarInfo.Hide();
                    this.gbxHouseInfo.Hide();
                }
            }


        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataGridView DataSource = new DataGridView();
            List<int> Columns = new List<int>();
            string Title = "";

            DataSource = dataGridView1;
            DataSource.DataSource = dgvPage.GetData().ToTable();

            Title += "查询状态：" + this.cbxSearchRange.Text;
            Title += "    ";
            Title += "查询日期：" + DateTime.Now.ToShortDateString();
            Title += "    ";
            Title += "共计" + DataSource.Rows.Count.ToString() + "件当品";
            Title += "    ";
            DDUser newUser = new DDUser("AccountName", MainForm.AccountName);
            Title += "查询人：" + newUser.UserName;

            Columns.Add(dataGridView1.Columns["TicketNumber"].Index);
            Columns.Add(dataGridView1.Columns["FirstClass"].Index);
            Columns.Add(dataGridView1.Columns["SecondClass"].Index);
            Columns.Add(dataGridView1.Columns["Description"].Index);
            Columns.Add(dataGridView1.Columns["Weight"].Index);
            Columns.Add(dataGridView1.Columns["TotalCount"].Index);
            Columns.Add(dataGridView1.Columns["Price"].Index);
            Columns.Add(dataGridView1.Columns["FeeRate"].Index);
            Columns.Add(dataGridView1.Columns["InterestRate"].Index);
            Columns.Add(dataGridView1.Columns["Remark"].Index);



            PrintDataGrid frmPrintDataGrid = new PrintDataGrid(Title, DataSource, Columns);

            SetForGridViewPage();
        }


        #region 分页函数
        private void SetForGridViewPage()
        {
            //DataGridView分页
            dgvPage = new ClsDataGridViewPage();
            dgvPage.GetDataGridView = this.dataGridView1;    //需要分页的是 dataGridView1
            dgvPage.RowsPerPage = 13; //每页显示多少条记录              
            dgvPage.SetDataView = m_GridTable.DefaultView;
            dgvPage.Paging();    //调用分页类的Paging 方法开始分页

            if (dgvPage.TotalPage > 0)
            {

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
        #endregion

        private void btnShowPhoto_Click(object sender, EventArgs e)
        {
            ViewPhotoForm frmViewPhotoForm = new ViewPhotoForm(dataGridView1.Rows[RowSelected].Cells["PhotoPath"].ToString());
            frmViewPhotoForm.Show();
        }

        void tbxKeyWord_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                btnSearch_Click(sender, e);
        }
    }
}
