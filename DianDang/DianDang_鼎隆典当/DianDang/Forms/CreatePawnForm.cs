using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using SubSonic;
using System.Transactions;

namespace DianDang
{
    public partial class CreatePawnForm : DockContent
    {
        private bool isRemarkDetailAllowed = true;

        private string OldValue = "";

        private bool isLoading = false;

        private bool isOperationSucess = false;

        public static string g_PhotoPath = "";

        public CreatePawnForm()
        {
            InitializeComponent();
            Init();
            this.cbxTermType.SelectedIndex = 0;
        }
              
        private void Init()
        {
            LoadTicketNumber();
            LoadOperationNumber();
            InitCbxCertType();
            InitParentClass();

            DateTime dt = DateTime.Now;
            this.tbxStartDate.Text = dt.Year.ToString() + "-" + dt.Month.ToString() + "-" + dt.Day.ToString();
            this.tbxPawnTerm.Text = "1";
            dt = dt.AddMonths(1);
            this.tbxEndDate.Text = dt.Year.ToString() + "-" + dt.Month.ToString() + "-" + dt.Day.ToString();
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
        private void LoadTicketNumber()
        {
            DDGeneralParemeter newParam = new DDGeneralParemeter("ParamName", "CurrentTicketNumber");
            this.tbxTicketNumber.Text = newParam.ParamValue.Trim();
        }
        private void UpdateTicketNumber()
        {
            string iTicketNumber = this.tbxTicketNumber.Text;
            DDGeneralParemeter newParam = new DDGeneralParemeter("ParamName", "CurrentTicketNumber");

            if (this.tbxTicketNumber.Text.Length > 9)
            {
                newParam.ParamValue = CaculateString(newParam.ParamValue.Trim());
            }
            else
            {
                for (int i = 0; i < 9 - tbxTicketNumber.Text.Length; i++)
                {
                    iTicketNumber = "0" + iTicketNumber;
                }
                newParam.ParamValue =CaculateString(iTicketNumber);
            }
            newParam.Save();
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

        private void InitCbxCertType()
        {
            Query query = new Query(DDCertType.Schema);
            DataSet comboCertTypeDataset = query.ExecuteDataSet();
            this.cbxCertType.DataSource = comboCertTypeDataset.Tables[0];
            this.cbxCertType.DisplayMember = "TypeName";
            this.cbxCertType.ValueMember = "TypeID";
        }
        private void InitParentClass()
        {
            Query query = new Query(DDPawnageClass.Schema);
            query.AddWhere("ParentID", 0);
            DataTable dt = query.ExecuteDataSet().Tables[0];

            if (dt.Rows.Count > 0)
            {
                this.cbxParentClass.DisplayMember = "ClassName";
                this.cbxParentClass.ValueMember = "ClassID";
                this.cbxParentClass.DataSource = dt;
            }
        }

        private void InitChildClass(int intParentID)
        {
            Query query = new Query(DDPawnageClass.Schema);
            query.AddWhere("ParentID", intParentID);
            query.OrderBy = OrderBy.Asc("ClassName");
            DataTable dt = query.ExecuteDataSet().Tables[0];
            
            if (dt.Rows.Count > 0)
            {
                this.cbxChildClass.DisplayMember = "ClassName";
                this.cbxChildClass.ValueMember = "ClassID";
                this.cbxChildClass.DataSource = dt;
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow CurrentRow = this.dataGridView1.Rows[e.RowIndex];
            CurrentRow.HeaderCell.Value = Convert.ToString(e.RowIndex + 1);
        }

        private ToChineseValue newChinese = new ToChineseValue();

        private void CaculateAmount()
        {            
            double amount = 0, totalAmount = 0, serviceFee = 0, totalServiceFee = 0, interestFee = 0, totalInterestFee = 0, paidFee = 0;
            for (int i = dataGridView1.Rows.Count - 1; i > -1; i--)
            {
                amount = Convert.ToDouble(dataGridView1.Rows[i].Cells["Amount"].Value);
                serviceFee = Convert.ToDouble(dataGridView1.Rows[i].Cells["ServiceFee"].Value.ToString());
                interestFee = Convert.ToDouble(dataGridView1.Rows[i].Cells["InterestFee"].Value.ToString());
                serviceFee = DianDangFunction.myRound(serviceFee, MainForm.AmountAccuracy);
                interestFee = DianDangFunction.myRound(interestFee, MainForm.AmountAccuracy);

                totalAmount += amount;
                totalServiceFee += serviceFee;
                totalInterestFee += interestFee;
            }

            paidFee = totalAmount - totalServiceFee;

            this.tbxTotalAmount.Text = totalAmount.ToString();
            this.tbxServiceFee.Text = totalServiceFee.ToString();
            this.tbxInterestFee.Text = totalInterestFee.ToString();
            this.tbxPaidFee.Text = paidFee.ToString();

            this.lblTotalAmount.Text = newChinese.toChineseChar(Convert.ToDecimal(totalAmount));
            this.lblServiceFee.Text = newChinese.toChineseChar(Convert.ToDecimal(totalServiceFee));
            this.lblInterestFee.Text = newChinese.toChineseChar(Convert.ToDecimal(totalInterestFee));
            this.lblPaidFee.Text = newChinese.toChineseChar(Convert.ToDecimal(paidFee));
        }

        private void CaculateGridAmount()
        {
            isLoading = true;
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    double serviceFee = 0;
                    double serviceFeeRate = Convert.ToDouble(dataGridView1.Rows[i].Cells["FeeRate"].Value.ToString());
                    double interestFeeRate = Convert.ToDouble(dataGridView1.Rows[i].Cells["InterestRate"].Value.ToString());
                    double interestFee = 0;
                    double amount = Convert.ToDouble(dataGridView1.Rows[i].Cells["Amount"].Value.ToString());

                    PawnSpan ServiceSpan = DianDangFunction.GetPawnSpan(DateTime.Parse(tbxStartDate.Text), DateTime.Parse(tbxEndDate.Text), FeeType.ServiceFee, PeridType.Within);
                    PawnSpan InterestSpan = DianDangFunction.GetPawnSpan(DateTime.Parse(tbxStartDate.Text), DateTime.Parse(tbxEndDate.Text), FeeType.InterestFee, PeridType.Within);

                    serviceFeeRate = Convert.ToDouble(this.tbxFeeRate.Text.ToString());
                    serviceFee = (ServiceSpan.Months + ServiceSpan.CountDays / 30) * amount * serviceFeeRate / 100;
                    serviceFee = DianDangFunction.myRound(serviceFee, MainForm.AmountAccuracy);
                    interestFeeRate = Convert.ToDouble(this.tbxInterestRate.Text.ToString());
                    interestFee = (InterestSpan.Months + InterestSpan.CountDays / 30) * amount * interestFeeRate / 100;
                    interestFee = DianDangFunction.myRound(interestFee, MainForm.AmountAccuracy);
                    dataGridView1.Rows[i].Cells["ServiceFee"].Value = serviceFee;
                    dataGridView1.Rows[i].Cells["InterestFee"].Value = interestFee;
                }

            }
            catch
            {
                MessageBox.Show("请输入正确的数值", "提示信息");
            }

            isLoading = false;

        }

        private DialogResult CheckAllData()
        {            
            if (this.tbxPrice.Text == "0"||this.tbxPrice.Text.Trim().Length==0)
            {
                MessageBox.Show(this, "价格输入错误，请重新输入！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return DialogResult.No;
            }
            if (this.tbxCountNumber.Text == "0"||this.tbxCountNumber.Text.Trim().Length==0)
            {
                MessageBox.Show(this, "件数输入错误，请重新输入！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return DialogResult.No;
            }

            double feeRate = 0;
            try
            {
                feeRate = Convert.ToDouble(this.tbxFeeRate.Text);
                if (feeRate < m_MinFeeRate || feeRate > m_MaxFeeRate)
                {
                    MessageBox.Show("费率超过规定范围，请重新输入！", "提示信息");
                    return DialogResult.No;
                }
            }
            catch
            {
                MessageBox.Show("费率输入错误，请重新输入！", "提示信息");
                return DialogResult.No;
            }
            double interestRate = 0;
            try
            {
                interestRate = Convert.ToDouble(this.tbxInterestRate.Text);
            }
            catch
            {
                MessageBox.Show("利率输入错误，请重新输入！", "提示信息");
                return DialogResult.No;
            }
            return DialogResult.OK;
        }
        private DialogResult CheckTicketNumber()
        {
            if (this.dataGridView1.Rows.Count < 1)
            {
                MessageBox.Show("当品不能为空！","提示信息");
                return DialogResult.No;
            }
            string strTicketNumber = this.tbxTicketNumber.Text.Trim();
            if (strTicketNumber.Length == 0)
            {
                MessageBox.Show(this, "当票号不能为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.tbxTicketNumber.Focus();
                return DialogResult.No;
            }
            Query query = new Query(DDPawnTicket.Schema);
            query.AddWhere("TicketNumber",strTicketNumber);
            query.AddWhere("StatusID", Comparison.NotEquals, 6);
            DataTable dt = query.ExecuteDataSet().Tables[0];
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show(this, "该当票号已经存在，请重新输入！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.tbxTicketNumber.Focus();
                return DialogResult.No;
            }

            double iTotalAmount=0;
            try
            {
                iTotalAmount = Convert.ToDouble(tbxTotalAmount.Text);
            }
            catch
            {
                MessageBox.Show("总金额错误！", "提示信息");
                return DialogResult.No;
            }

            
            //权限检查
            try
            {
                DDUser newUser = new DDUser("AccountName", MainForm.AccountName);
                DDRole newRole = new DDRole("RoleID", newUser.RoleID);
                if (newRole.AmountLimit < iTotalAmount && newRole.AmountLimit != 0)
                {
                    MessageBox.Show("您没有权限执行该笔操作！", "提示信息");
                    return DialogResult.No;
                }
            }
            catch
            {
                MessageBox.Show("数据库连接错误！", "提示信息");
                return DialogResult.No;
            }

            return DialogResult.OK;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isLoading = true;
            double serviceFee = 0;
            double serviceFeeRate = 0;
            double interestFeeRate = 0;
            double interestFee = 0;
            PawnSpan ServiceSpan = DianDangFunction.GetPawnSpan(DateTime.Parse(tbxStartDate.Text), DateTime.Parse(tbxEndDate.Text), FeeType.ServiceFee, PeridType.Within);
            PawnSpan InterestSpan = DianDangFunction.GetPawnSpan(DateTime.Parse(tbxStartDate.Text), DateTime.Parse(tbxEndDate.Text), FeeType.InterestFee, PeridType.Within);
            DialogResult diaRes = CheckAllData();
            if (diaRes != DialogResult.OK)
            {
                return;
            }

            double price, percent, amount, weight;

            try
            {
                price = Convert.ToDouble(this.tbxPrice.Text);
                percent = Convert.ToDouble(this.tbxDiscountPercent.Text);
                weight = Convert.ToDouble(this.tbxWeight.Text);
                amount = price;
                amount = DianDangFunction.myRound(amount, MainForm.AmountAccuracy);
            }
            catch
            {
                MessageBox.Show("数据格式不正确！", "输入数据");
                return;
            }

            this.dataGridView1.Rows.Add(1);
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["ParentClassID"].Value = this.cbxParentClass.SelectedValue;
            if (Convert.ToInt32(this.cbxParentClass.SelectedValue) == 11)
            {
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["HouseAddress"].Value = this.tbxHouseAddress.Text;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["HouseCompactNumber"].Value = this.tbxHouseCompactNumber.Text;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["HouseArea"].Value = this.tbxHouseArea.Text;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["HouseRegisterDate"].Value = this.tbxHouseRegisterDate.Text;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["HouseInsuranceDate"].Value = this.tbxHouseInsuranceDate.Text;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["HouseNotarizationDate"].Value = this.tbxHouseNotarizationDate.Text;
            }
            if (Convert.ToInt32(this.cbxParentClass.SelectedValue) == 10)
            {
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["CarLicenceNumber"].Value = this.tbxCarLicenceNumber.Text;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["CarType"].Value = this.tbxCarType.Text;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["CarEngineNumber"].Value = this.tbxCarEngineNumber.Text;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["CarcaseNumber"].Value = this.tbxCarcaseNumber.Text;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["CarInsuranceDate"].Value = this.tbxCarInsuranceDate.Text;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["CarRoadtollDate"].Value = this.tbxCarRoadtollDate.Text;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["CarCheckDate"].Value = this.tbxCarCheckDate.Text;
            }
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["ParentClass"].Value = this.cbxParentClass.Text;
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["ChildClassID"].Value = this.cbxChildClass.SelectedValue;
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["ChildClass"].Value = this.cbxChildClass.Text;
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["FeeRate"].Value = this.tbxFeeRate.Text;
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["InterestRate"].Value = this.tbxInterestRate.Text;
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Description"].Value = this.tbxDescription.Text;
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["CountNumber"].Value = this.tbxCountNumber.Text;
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Weight"].Value = weight;
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["DiscountPercent"].Value = this.tbxDiscountPercent.Text;
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Amount"].Value = amount;
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Remark"].Value = this.tbxRemark.Text;
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["PhotoPath"].Value = g_PhotoPath;

            serviceFeeRate = Convert.ToDouble(this.tbxFeeRate.Text.ToString());
            serviceFee = (ServiceSpan.Months + ServiceSpan.CountDays / 30) * amount * serviceFeeRate / 100;
            serviceFee = DianDangFunction.myRound(serviceFee, MainForm.AmountAccuracy);
            interestFeeRate = Convert.ToDouble(this.tbxInterestRate.Text.ToString());
            interestFee = (InterestSpan.Months + InterestSpan.CountDays / 30) * amount * interestFeeRate / 100;
            interestFee = DianDangFunction.myRound(interestFee, MainForm.AmountAccuracy);
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["ServiceFee"].Value = serviceFee;
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["InterestFee"].Value = interestFee;
            g_PhotoPath = "";
            CaculateAmount();

            isLoading = false;
        }

        private double m_MaxFeeRate = 0;
        private double m_MinFeeRate = 0;

        private void GetRateByClass(int intClassID)
        {
            DDPawnageClass newClass = new DDPawnageClass("ClassID", intClassID);
            this.tbxFeeRate.Text = newClass.MonthFeeRate;
            m_MaxFeeRate = Convert.ToDouble(newClass.MaxFeeRate);
            m_MinFeeRate = Convert.ToDouble(newClass.MinFeeRate);
            this.tbxInterestRate.Text = newClass.InterestRate;
        }

        private void cbxParentClass_SelectedValueChanged(object sender, EventArgs e)
        {
            int intParentID = Convert.ToInt32(this.cbxParentClass.SelectedValue);
            InitChildClass(intParentID);
            GetRateByClass(intParentID);
            if (intParentID == 11)
            {
                this.panelHouseInfo.Visible = true;
                this.panelCarInfo.Visible = false;
            }
            else if (intParentID == 10)
            {
                this.panelHouseInfo.Visible = false;
                this.panelCarInfo.Visible = true;
            }
            else
            {
                this.panelCarInfo.Visible = false;
                this.panelHouseInfo.Visible = false;
            }
        }

        private int dateTextNumber;
        private void tbxStartDate_Click(object sender, EventArgs e)
        {
            this.monthCalendar1.Visible = true;
            dateTextNumber = 1;
        }


        private void tbxCarInsuranceDate_Click(object sender, EventArgs e)
        {
            this.monthCalendar1.Visible = true;
            dateTextNumber = 2;
        }

        private void tbxCarRoadtollDate_Click(object sender, EventArgs e)
        {
            this.monthCalendar1.Visible = true;
            dateTextNumber = 3;
        }

        private void tbxCarCheckDate_Click(object sender, EventArgs e)
        {
            this.monthCalendar1.Visible = true;
            dateTextNumber = 4;
        }

        private void tbxHouseRegisterDate_Click(object sender, EventArgs e)
        {
            this.monthCalendar1.Visible = true;
            dateTextNumber = 5;
        }

        private void tbxHouseInsuranceDate_Click(object sender, EventArgs e)
        {
            this.monthCalendar1.Visible = true;
            dateTextNumber = 6;
        }

        private void tbxHouseNotarizationDate_Click(object sender, EventArgs e)
        {
            this.monthCalendar1.Visible = true;
            dateTextNumber = 7;
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

                switch(dateTextNumber)
                {
                    case 1:
                        this.tbxStartDate.Text = _date;

                        DateTime dt = Convert.ToDateTime(this.tbxStartDate.Text); ;
                        int spanMonths;
                        try
                        {
                            spanMonths = Convert.ToInt32(this.tbxPawnTerm.Text);
                        }
                        catch
                        {
                            MessageBox.Show("典当期限输入不正确！", "提示信息");
                            return;
                        }
                        dt = dt.AddMonths(spanMonths);
                        this.tbxEndDate.Text = dt.Year.ToString() + "-" + dt.Month.ToString() + "-" + dt.Day.ToString();
                        break;
                    case 2:
                        this.tbxCarInsuranceDate.Text = _date;
                        break;
                    case 3:
                        this.tbxCarRoadtollDate.Text = _date;
                        break;
                    case 4:
                        this.tbxCarCheckDate.Text = _date;
                        break;
                    case 5:
                        this.tbxHouseRegisterDate.Text = _date;
                        break;
                    case 6:
                        this.tbxHouseInsuranceDate.Text = _date;
                        break;
                    case 7:
                        this.tbxHouseNotarizationDate.Text = _date;
                        break;
                    default:
                        break;
                 }
                //如果选中日期就自动隐藏MonthCalendar控件
                monthCalendar1.Hide();

                #region 计算
                if (this.cbxTermType.SelectedIndex != -1)
                {
                    int spanTime = 0;
                    try
                    {
                        spanTime = Convert.ToInt32(this.tbxPawnTerm.Text);
                    }
                    catch
                    {
                        MessageBox.Show("典当期限输入不正确！", "提示信息");
                        return;
                    }

                    DateTime startDate = Convert.ToDateTime(this.tbxStartDate.Text);
                    DateTime endDate;
                    if (this.cbxTermType.SelectedIndex == 0)
                    {
                        endDate = startDate.AddMonths(spanTime);
                        //二月份特殊处理
                        if (DateTime.IsLeapYear(startDate.Year) == true && startDate.Month == 2 && startDate.Day == 29 ||
                            DateTime.IsLeapYear(startDate.Year) == false && startDate.Month == 2 && startDate.Day == 28)
                        {
                            endDate = new DateTime(endDate.Year, endDate.Month, DateTime.DaysInMonth(endDate.Year, endDate.Month));
                        }
                    }
                    else
                    {
                        endDate = startDate.AddDays(spanTime);
                        this.lblPawnTerm.Text = spanTime.ToString();
                    }
                    this.tbxEndDate.Text = endDate.Year.ToString() + "-" + endDate.Month.ToString() + "-" + endDate.Day.ToString();
                    CaculateGridAmount();
                    CaculateAmount();
                }
                #endregion

            }

        }

        private void btnGetCustomerInfo_Click(object sender, EventArgs e)
        {
            Int32 result;
            Int32 port = 1001;    //USB接口
            UInt32 flag = 0;

            result = CardRecognise.OpenCardReader(port, flag);

            if (result != 0)    
            {
                MessageBox.Show(this, "设备初始化失败，请检查设备是否已连接？", "提示信息",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                CardRecognise.PERSONINFOW newInfo = new CardRecognise.PERSONINFOW();
                result = CardRecognise.GetPersonMsgW(ref newInfo, "");
                if (result != 0)
                {
                    MessageBox.Show(this, "读卡错误，请重新操作！","提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    tbxCustomerName.Text = newInfo.name;
                    tbxContactPerson.Text = newInfo.name;
                    tbxCustomerAdd.Text = newInfo.address;
                    tbxCertNum.Text = newInfo.cardId;
                }
            }
            CardRecognise.CloseCardReader();

            Query query = new Query(DDCustomerInfo.Schema);
            query.AddWhere("CertNUmber", this.tbxCertNum.Text.Trim());
            DataTable dt = query.ExecuteDataSet().Tables[0];
            if (dt.Rows.Count != 0)
            {
                this.tbxCustomerPhone.Text = dt.Rows[0]["PhoneNumber"].ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            isLoading = true;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (this.dataGridView1.Rows[i].Cells["Operation"].Value != null && this.dataGridView1.Rows[i].Cells["Operation"].Value.ToString() == "1")
                {
                    dataGridView1.Rows[i].Selected = true;
                }
                else
                {
                    dataGridView1.Rows[i].Selected = false;
                }
            }
            if (dataGridView1.SelectedRows.Count > 0)
            {
                for (int i = dataGridView1.SelectedRows.Count - 1; i > -1; i--)
                {
                    int rowIndex = dataGridView1.SelectedRows[i].Index;
                    DataGridViewRow dgr = dataGridView1.Rows[rowIndex];
                    dataGridView1.Rows.Remove(dgr);
                }
                CaculateAmount();
            }
            else
            {
                MessageBox.Show(this, "请选择需要删除的数据！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            isLoading = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            isLoading = true;
            double serviceFee = 0;
            double serviceFeeRate = 0;
            double interestFeeRate = 0;
            double interestFee = 0;
            PawnSpan ServiceSpan = DianDangFunction.GetPawnSpan(DateTime.Parse(tbxStartDate.Text), DateTime.Parse(tbxEndDate.Text), FeeType.ServiceFee, PeridType.Within);
            PawnSpan InterestSpan = DianDangFunction.GetPawnSpan(DateTime.Parse(tbxStartDate.Text), DateTime.Parse(tbxEndDate.Text), FeeType.InterestFee, PeridType.Within);

            DialogResult diaRes = CheckAllData();
            if (diaRes != DialogResult.OK)
            {
                return;
            }
            double price, percent, amount, weight;

            try
            {
                price = Convert.ToDouble(this.tbxPrice.Text);
                percent = Convert.ToDouble(this.tbxDiscountPercent.Text);
                weight = Convert.ToDouble(this.tbxWeight.Text);
            }
            catch
            {
                MessageBox.Show("数据格式不正确！", "输入数据");
                return;
            }

            amount = price * percent / 100;
            amount = DianDangFunction.myRound(amount, MainForm.AmountAccuracy);

            DataGridViewRow dgr = new DataGridViewRow();

            for (int i = dataGridView1.Rows.Count -1; i >= 0; i--)
            {
                if (this.dataGridView1.Rows[i].Cells["Operation"].Value != null && this.dataGridView1.Rows[i].Cells["Operation"].Value.ToString() == "1")
                {
                    dgr = dataGridView1.Rows[i];
                }
            }

            try
            {
                dgr.Cells["ParentClassID"].Value = this.cbxParentClass.SelectedValue;
                dgr.Cells["ParentClass"].Value = this.cbxParentClass.Text;
                dgr.Cells["ChildClassID"].Value = this.cbxChildClass.SelectedValue;
                dgr.Cells["ChildClass"].Value = this.cbxChildClass.Text;
                dgr.Cells["FeeRate"].Value = this.tbxFeeRate.Text;
                dgr.Cells["InterestRate"].Value = this.tbxInterestRate.Text;
                dgr.Cells["Description"].Value = this.tbxDescription.Text;
                dgr.Cells["CountNumber"].Value = this.tbxCountNumber.Text;
                dgr.Cells["Weight"].Value = weight;
                dgr.Cells["DiscountPercent"].Value = this.tbxDiscountPercent.Text;
                dgr.Cells["Amount"].Value = amount;
                dgr.Cells["Remark"].Value = this.tbxRemark.Text;
                dgr.Cells["PhotoPath"].Value = g_PhotoPath;
                if (Convert.ToInt32(this.cbxParentClass.SelectedValue) == 11)
                {
                    dgr.Cells["HouseAddress"].Value = this.tbxHouseAddress.Text;
                    dgr.Cells["HouseCompactNumber"].Value = this.tbxHouseCompactNumber.Text;
                    dgr.Cells["HouseArea"].Value = this.tbxHouseArea.Text;
                    dgr.Cells["HouseRegisterDate"].Value = this.tbxHouseRegisterDate.Text;
                    dgr.Cells["HouseInsuranceDate"].Value = this.tbxHouseInsuranceDate.Text;
                    dgr.Cells["HouseNotarizationDate"].Value = this.tbxHouseNotarizationDate.Text;
                }
                if (Convert.ToInt32(this.cbxParentClass.SelectedValue) == 10)
                {
                    dgr.Cells["CarLicenceNumber"].Value = this.tbxCarLicenceNumber.Text;
                    dgr.Cells["CarType"].Value = this.tbxCarType.Text;
                    dgr.Cells["CarEngineNumber"].Value = this.tbxCarEngineNumber.Text;
                    dgr.Cells["CarcaseNumber"].Value = this.tbxCarcaseNumber.Text;
                    dgr.Cells["CarInsuranceDate"].Value = this.tbxCarInsuranceDate.Text;
                    dgr.Cells["CarRoadtollDate"].Value = this.tbxCarRoadtollDate.Text;
                    dgr.Cells["CarCheckDate"].Value = this.tbxCarCheckDate.Text;
                }

                serviceFeeRate = Convert.ToDouble(dgr.Cells["FeeRate"].Value.ToString());
                serviceFee = (ServiceSpan.Months + ServiceSpan.CountDays / 30) * amount * serviceFeeRate / 100;
                serviceFee = DianDangFunction.myRound(serviceFee, MainForm.AmountAccuracy);
                interestFeeRate = Convert.ToDouble(dgr.Cells["InterestRate"].Value.ToString());
                interestFee = (InterestSpan.Months + InterestSpan.CountDays / 30) * amount * interestFeeRate / 100;
                interestFee = DianDangFunction.myRound(interestFee, MainForm.AmountAccuracy);
                dgr.Cells["ServiceFee"].Value = serviceFee;
                dgr.Cells["InterestFee"].Value = interestFee;

                CaculateAmount();

                //MessageBox.Show(this, "数据修改成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show(this, "数据修改失败！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            isLoading = false;
        }

        void dataGridView1_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1 )
            {
                try
                {
                    OldValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }
                catch
                {
                }

            }

            this.panelCarInfo.Visible = false;
            this.panelHouseInfo.Visible = false;

            if (this.dataGridView1.Rows.Count > 0)
            {
                DataGridViewRow dgr = dataGridView1.CurrentRow;
                this.cbxParentClass.Text = dgr.Cells["ParentClass"].Value.ToString();

                if (Convert.ToInt32(dgr.Cells["ParentClassID"].Value) == 11)
                {
                    this.panelHouseInfo.Visible = true;
                    this.tbxHouseAddress.Text = dgr.Cells["HouseAddress"].Value.ToString();
                    this.tbxHouseCompactNumber.Text = dgr.Cells["HouseCompactNumber"].Value.ToString();
                    this.tbxHouseArea.Text = dgr.Cells["HouseArea"].Value.ToString();
                    this.tbxHouseRegisterDate.Text = dgr.Cells["HouseRegisterDate"].Value.ToString();
                    this.tbxHouseInsuranceDate.Text = dgr.Cells["HouseInsuranceDate"].Value.ToString();
                    this.tbxHouseNotarizationDate.Text = dgr.Cells["HouseNotarizationDate"].Value.ToString();
                }
                if (Convert.ToInt32(dgr.Cells["ParentClassID"].Value) == 10)
                {
                    this.panelCarInfo.Visible = true;
                    this.tbxCarLicenceNumber.Text = dgr.Cells["CarLicenceNumber"].Value.ToString();
                    this.tbxCarType.Text = dgr.Cells["CarType"].Value.ToString();
                    this.tbxCarEngineNumber.Text = dgr.Cells["CarEngineNumber"].Value.ToString();
                    this.tbxCarcaseNumber.Text = dgr.Cells["CarcaseNumber"].Value.ToString();
                    this.tbxCarInsuranceDate.Text = dgr.Cells["CarInsuranceDate"].Value.ToString();
                    this.tbxCarRoadtollDate.Text = dgr.Cells["CarRoadtollDate"].Value.ToString();
                    this.tbxCarCheckDate.Text = dgr.Cells["CarCheckDate"].Value.ToString();
                }
                this.cbxChildClass.Text = dgr.Cells["ChildClass"].Value.ToString();
                this.tbxFeeRate.Text = dgr.Cells["Feerate"].Value.ToString();
                this.tbxInterestRate.Text = dgr.Cells["InterestRate"].Value.ToString();
                this.tbxDescription.Text = dgr.Cells["Description"].Value.ToString();
                this.tbxWeight.Text = dgr.Cells["Weight"].Value.ToString();
                this.tbxPrice.Text = dgr.Cells["Amount"].Value.ToString();
                this.tbxDiscountPercent.Text = dgr.Cells["DiscountPercent"].Value.ToString();
                this.tbxRemark.Text = dgr.Cells["Remark"].Value.ToString();
                this.tbxCountNumber.Text = dgr.Cells["CountNumber"].Value.ToString();
                g_PhotoPath = dgr.Cells["PhotoPath"].Value.ToString();
                if (g_PhotoPath != "")
                {
                    this.btnViewPhoto.Visible = true;
                }
                else
                {
                    this.btnViewPhoto.Visible = false;
                }
            }
        }

        private int UpdateCustomerInfo()
        {
            try
            {
                Query query = new Query(DDCustomerInfo.Schema);
                query.AddWhere("CertNumber", this.tbxCertNum.Text);
                DataTable dt = query.ExecuteDataSet().Tables[0];
                if (dt.Rows.Count == 0)
                {
                    DDCustomerInfo newCustomer = new DDCustomerInfo();
                    newCustomer.CustomerName = this.tbxCustomerName.Text;
                    newCustomer.PhoneNumber = this.tbxCustomerPhone.Text;
                    newCustomer.Address = this.tbxCustomerAdd.Text;
                    newCustomer.ContactPerson = this.tbxContactPerson.Text;
                    newCustomer.CertTypeID = Convert.ToInt32(this.cbxCertType.SelectedValue);
                    newCustomer.CertNumber = this.tbxCertNum.Text;
                    newCustomer.CreatDate = this.tbxStartDate.Text;
                    newCustomer.Save();
                    return newCustomer.CustomerID;
                }
                else
                {
                    return Convert.ToInt32(dt.Rows[0]["CustomerID"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private int UpdatePawages(int i)
        {

            DataGridViewRow dgr = dataGridView1.Rows[i];

            try
            {
                DDPawnageInfo newInfo = new DDPawnageInfo();
                newInfo.ClassID = Convert.ToInt32(dgr.Cells["ChildClassID"].Value);
                newInfo.ParentID = Convert.ToInt32(dgr.Cells["ParentClassID"].Value);
                newInfo.CountNumber = dgr.Cells["CountNumber"].Value.ToString();
                newInfo.StatusID = 1; //新当
                newInfo.Price = dgr.Cells["Amount"].Value.ToString();
                newInfo.Weight = dgr.Cells["Weight"].Value.ToString();
                newInfo.FeeRate = dgr.Cells["FeeRate"].Value.ToString();
                newInfo.InterestRate = dgr.Cells["InterestRate"].Value.ToString();
                newInfo.DiscountPercent = dgr.Cells["DiscountPercent"].Value.ToString();
                newInfo.Description = dgr.Cells["Description"].Value.ToString();  
                newInfo.StartDate = this.tbxStartDate.Text;
                newInfo.EndDate = this.tbxEndDate.Text;
                newInfo.Remark = dgr.Cells["Remark"].Value.ToString();
                newInfo.PhotoPath = dgr.Cells["PhotoPath"].Value.ToString();      
                newInfo.Save();
                if (Convert.ToInt32(newInfo.ParentID) == 11)
                {
                    DDHouseInfo newHouseInfo = new DDHouseInfo();
                    newHouseInfo.Address = dgr.Cells["HouseAddress"].Value.ToString();
                    newHouseInfo.CompactNumber = dgr.Cells["HouseCompactNumber"].Value.ToString();
                    newHouseInfo.Area = dgr.Cells["HouseArea"].Value.ToString();
                    newHouseInfo.RegisterDate = dgr.Cells["HouseRegisterDate"].Value.ToString();
                    newHouseInfo.InsuranceDate = dgr.Cells["HouseInsuranceDate"].Value.ToString();
                    newHouseInfo.NotarizationDate = dgr.Cells["HouseNotarizationDate"].Value.ToString();
                    newHouseInfo.PawnageID = newInfo.PawnageID;
                    newHouseInfo.Save();
                }
                if (Convert.ToInt32(newInfo.ParentID) == 10)
                {
                    DDCarInfo newCarInfo = new DDCarInfo();
                    newCarInfo.LicenseNumber = dgr.Cells["CarLicenceNumber"].Value.ToString();
                    newCarInfo.CarType = dgr.Cells["CarType"].Value.ToString();
                    newCarInfo.EngineNumber = dgr.Cells["CarEngineNumber"].Value.ToString();
                    newCarInfo.CarcaseNumber = dgr.Cells["CarcaseNumber"].Value.ToString();
                    newCarInfo.InsuranceDate = dgr.Cells["CarInsuranceDate"].Value.ToString();
                    newCarInfo.RoadtollDate = dgr.Cells["CarRoadtollDate"].Value.ToString();
                    newCarInfo.CheckDate = dgr.Cells["CarCheckDate"].Value.ToString();
                    newCarInfo.PawnageID = newInfo.PawnageID;
                    newCarInfo.Save();
                 }
                return newInfo.PawnageID;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(this, "当品信息更新失败，请检查数据库是否连接正确！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //return 0;
                throw ex;
            } 
        }

        private int m_TicketID;

        private int UpdatePawnTicket()
        {
            try
            {
                int intCustomerID = UpdateCustomerInfo();
                DDPawnTicket newTicket = new DDPawnTicket();
                newTicket.CustomerID = intCustomerID;
                newTicket.TicketNumber = this.tbxTicketNumber.Text;
                newTicket.StartDate = this.tbxStartDate.Text;
                newTicket.EndDate = this.tbxEndDate.Text;
                newTicket.StatusID = 1;
                newTicket.Save();
                UpdateTicketNumber();
                m_TicketID = newTicket.TicketID;
                return newTicket.TicketID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void UpdateOperation()
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    int iTicketID = UpdatePawnTicket();
                    int iPawnageID = 0;
                    double serviceFee = 0;
                    for (int i = dataGridView1.Rows.Count - 1; i > -1; i--)
                    {
                        DataGridViewRow dgr = dataGridView1.Rows[i];

                        iPawnageID = UpdatePawages(i);
                        DDOperation newOperation = new DDOperation();
                        newOperation.TicketID = iTicketID;
                        newOperation.PawnageID = iPawnageID;
                        newOperation.OperationType = 1;   //1 ：新当
                        newOperation.OperationNumber = m_OperationNumber;
                        //计算服务费
                        serviceFee = Convert.ToDouble(dgr.Cells["ServiceFee"].Value);
                        serviceFee = DianDangFunction.myRound(serviceFee, MainForm.AmountAccuracy);
                        newOperation.ServiceFee = serviceFee.ToString();
                        newOperation.InterestFee = "0";
                        newOperation.ReturnFee = "0";
                        newOperation.OverdueFee = "0";
                        newOperation.Amount = dgr.Cells["Amount"].Value.ToString();
                        newOperation.ReckonAmount = "0";
                        newOperation.OperationDate = this.tbxStartDate.Text;
                        newOperation.StartDate = this.tbxStartDate.Text;
                        newOperation.EndDate = this.tbxEndDate.Text;
                        newOperation.ServiceFeeRate = dgr.Cells["FeeRate"].Value.ToString();
                        newOperation.InterestFeeRate = dgr.Cells["InterestRate"].Value.ToString();
                        //存入操作人
                        DDUser newOperater = new DDUser("AccountName", MainForm.AccountName);
                        newOperation.OperaterName = newOperater.UserName;
                        newOperation.PreOperationID = 0;
                        newOperation.NextOperationID = 0;
                        newOperation.Deleted = 0;
                        newOperation.Save();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //

        }

        private void PrintPawnTicket()
        {
            PawnTicketPrintPreviewForm frmPawnTicketPrint = new PawnTicketPrintPreviewForm(this,m_TicketID,m_OperationNumber);
            //frmPawnTicketPrint.Show();
        }

        private void PrintReceipt()
        {
            ReceiptPrintViewForm frmReceiptPrintView = new ReceiptPrintViewForm(m_TicketID, m_OperationNumber);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DialogResult dataCheckDlg = CheckTicketNumber();
            if (dataCheckDlg != DialogResult.OK)
            {
                return;
            }

            using (TransactionScope Scope = new TransactionScope())
            {
                try
                {
                    LoadOperationNumber();
                    UpdateOperation();
                    DDPrintParam newParam = new DDPrintParam("PrintOption", 1);
                    if (newParam.OptionValue == 1)
                    {
                        PrintPawnTicket();
                    }

                    newParam = new DDPrintParam("PrintOption", 2);
                    if (newParam.OptionValue == 1)
                    {
                        PrintReceipt();
                    }

                    UpdateOperationNumber();
                    LoadOperationNumber();
                    Scope.Complete();
                    //MessageBox.Show(this, "建当成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.isOperationSucess = true;

                }
                catch
                {
                    Scope.Dispose();
                    //MessageBox.Show(this, "建当操作失败，请检查数据库是否连接正确！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.isOperationSucess = false;
                }
            }

            if (this.isOperationSucess == true)
            {
                this.isOperationSucess = false;
                MessageBox.Show(this, "建当成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(this, "建当操作失败，请检查数据库是否连接正确！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tbxPawnTerm_TextChanged(object sender, EventArgs e)
        {
            if (this.cbxTermType.SelectedIndex != -1)
            {
                int spanTime = 0;
                try
                {
                    spanTime = Convert.ToInt32(this.tbxPawnTerm.Text);
                }
                catch
                {
                    MessageBox.Show("典当期限输入不正确！", "提示信息");
                    return;
                }

                DateTime startDate = Convert.ToDateTime(this.tbxStartDate.Text);
                DateTime endDate;
                if (this.cbxTermType.SelectedIndex == 0)
                {
                    endDate = startDate.AddMonths(spanTime);
                    //二月份特殊处理
                    if (DateTime.IsLeapYear(startDate.Year) == true && startDate.Month == 2 && startDate.Day == 29 ||
                        DateTime.IsLeapYear(startDate.Year) == false && startDate.Month == 2 && startDate.Day == 28)
                    {
                        endDate = new DateTime(endDate.Year, endDate.Month, DateTime.DaysInMonth(endDate.Year, endDate.Month));
                    }
                }
                else
                {
                    endDate = startDate.AddDays(spanTime);
                    this.lblPawnTerm.Text = spanTime.ToString();
                }
                this.tbxEndDate.Text = endDate.Year.ToString() + "-" + endDate.Month.ToString() + "-" + endDate.Day.ToString();
                CaculateGridAmount();
                CaculateAmount();
            }
        }

        private void cbxTermType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int spanTime = 0;
            int count = 0;
            try
            {
                spanTime = Convert.ToInt32(this.tbxPawnTerm.Text);
                DateTime startDate = Convert.ToDateTime(this.tbxStartDate.Text);
                DateTime endDate;
                if (this.cbxTermType.SelectedIndex == 0)
                {
                    endDate = startDate.AddMonths(spanTime);
                    //二月份特殊处理
                    if (DateTime.IsLeapYear(startDate.Year) == true && startDate.Month == 2 && startDate.Day == 29 ||
                        DateTime.IsLeapYear(startDate.Year) == false && startDate.Month == 2 && startDate.Day == 28)
                    {
                        endDate = new DateTime(endDate.Year, endDate.Month, DateTime.DaysInMonth(endDate.Year, endDate.Month));
                    }
                }
                else
                {
                    if (spanTime > 0)
                    {
                        count = spanTime / 30;
                        spanTime = spanTime - 30 * count;
                        if (0 < spanTime && spanTime < 6)
                        {
                            spanTime = 5;
                        }
                        else if (5 < spanTime && spanTime < 16)
                        {
                            spanTime = 15;
                        }
                        else if (15 < spanTime && spanTime < 30)
                        {
                            spanTime = 30;
                        }
                        spanTime = 30 * count + spanTime;
                    }
                    endDate = startDate.AddDays(spanTime);
                    this.tbxPawnTerm.Text = spanTime.ToString();
                }
                this.tbxEndDate.Text = endDate.Year.ToString() + "-" + endDate.Month.ToString() + "-" + endDate.Day.ToString();


                CaculateGridAmount();
                CaculateAmount();
            }
            catch
            {
                MessageBox.Show("典当期限输入不正确！", "提示信息");
                return;
            }


        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            CapturePicForm frmCapturePic = new CapturePicForm();
            frmCapturePic.Show();
            this.btnViewPhoto.Visible = true;
        }

        private void btnViewPhoto_Click(object sender, EventArgs e)
        {
            if (g_PhotoPath != "")
            {
                ViewPhotoForm frmViewPhoto = new ViewPhotoForm(g_PhotoPath);
                frmViewPhoto.Show();
            }
            else
            {
                MessageBox.Show("图片尚未拍摄！", "提示信息");
            }
        }

        private void tbxCustomerName_TextChanged(object sender, EventArgs e)
        {
            Query query = new Query(DDCustomerInfo.Schema);
            query.AddWhere("CustomerName", this.tbxCustomerName.Text);
            DataTable dt = query.ExecuteDataSet().Tables[0];
            if (dt.Rows.Count > 0)
            {
                tbxCustomerAdd.Text = dt.Rows[0]["Address"].ToString();
                tbxCertNum.Text = dt.Rows[0]["CertNumber"].ToString();
                cbxCertType.SelectedValue = dt.Rows[0]["CertTypeID"].ToString();
                tbxCustomerPhone.Text = dt.Rows[0]["PhoneNumber"].ToString();
                tbxContactPerson.Text = dt.Rows[0]["ContactPerson"].ToString();                
            }
        }

        private void tbxCertNum_TextChanged(object sender, EventArgs e)
        {
            if (tbxCertNum.Text.Length > 10)
            {
                Query query = new Query(DDCustomerInfo.Schema);
                query.AddWhere("CertNumber", this.tbxCertNum.Text);
                DataTable dt = query.ExecuteDataSet().Tables[0];
                if (dt.Rows.Count > 0)
                {
                    tbxCustomerAdd.Text = dt.Rows[0]["Address"].ToString();
                    tbxCustomerName.Text = dt.Rows[0]["CustomerName"].ToString();
                    cbxCertType.SelectedValue = dt.Rows[0]["CertTypeID"].ToString();
                    tbxCustomerPhone.Text = dt.Rows[0]["PhoneNumber"].ToString();
                    tbxContactPerson.Text = dt.Rows[0]["ContactPerson"].ToString();
                }

            }
        }

        void dataGridView1_CellValueChanged(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1 && !isLoading)
            {
                if (e.ColumnIndex == dataGridView1.Columns["ServiceFee"].Index)
                {
                    double serviceFee = 0;
                    try
                    {
                        serviceFee = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        CaculateAmount();
                    }
                    catch
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = OldValue;
                        MessageBox.Show("请输入正确的服务费", "提示信息");
                    }
                }

            }
        }

        private void tbxStartDate_TextChanged(object sender, EventArgs e)
        {
            this.monthCalendar1.Hide();
            try
            {
                DateTime startDate = Convert.ToDateTime(this.tbxStartDate.Text);
                DateTime endDate = new DateTime();
                int spanTime = Convert.ToInt32(this.tbxPawnTerm.Text);
                if (this.cbxTermType.SelectedIndex == 0)
                {
                    endDate = startDate.AddMonths(spanTime);
                    //二月份特殊处理
                    if (DateTime.IsLeapYear(startDate.Year) == true && startDate.Month == 2 && startDate.Day == 29 ||
                        DateTime.IsLeapYear(startDate.Year) == false && startDate.Month == 2 && startDate.Day == 28)
                    {
                        endDate = new DateTime(endDate.Year, endDate.Month, DateTime.DaysInMonth(endDate.Year, endDate.Month));
                    }
                }
                else
                {
                    endDate = startDate.AddDays(spanTime);
                    this.lblPawnTerm.Text = spanTime.ToString();
                }
                this.tbxEndDate.Text = endDate.Year.ToString() + "-" + endDate.Month.ToString() + "-" + endDate.Day.ToString();
                CaculateGridAmount();
                CaculateAmount();
            }
            catch
            {
            }
        }


        private void btnRemarkDetail_Click(object sender, EventArgs e)
        {
            if (tbxRemarkDetail.Visible == false && this.isRemarkDetailAllowed)
            {
                tbxRemarkDetail.Show();
                tbxRemarkDetail.Text = this.tbxRemark.Text;
                this.tbxRemark.Enabled = false;
                tmrRemarkDetail.Start();
            }
            else
            {
                tbxRemarkDetail.Hide();
                tbxRemark.Text = tbxRemarkDetail.Text;
                this.tbxRemark.Enabled = true;
            }
        }


        void tbxRemarkDetail_LostFocus(object sender, System.EventArgs e)
        {
            if (this.tbxRemarkDetail.Visible == true)
            {
                tbxRemarkDetail.Hide();
                tbxRemark.Text = tbxRemarkDetail.Text;
                this.tbxRemark.Enabled = true;
                this.isRemarkDetailAllowed = false;
            }
        }

        private void tmrRemarkDetail_Tick(object sender, EventArgs e)
        {
            this.isRemarkDetailAllowed = true;
        }

   }
}