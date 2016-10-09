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
    public partial class SearchHouseInfoForm : DockContent
    {
        public SearchHouseInfoForm()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            string strKey = this.tbxKeyWord.Text.Trim();
            Query queryHouse = new Query(DDHouseInfo.Schema);
            DataTable dtHouse = queryHouse.ExecuteDataSet().Tables[0];
            if (dtHouse.Rows.Count > 0)
            {
                for (int i = 0; i < dtHouse.Rows.Count; i++)
                {
                    string TicketNumber = "";
                    Query queryOperation = new Query(DDOperation.Schema);
                    queryOperation.AddWhere("PawnageID", dtHouse.Rows[i]["PawnageID"].ToString());
                    DataTable dtOperation = queryOperation.ExecuteDataSet().Tables[0];
                    if (dtOperation.Rows.Count > 0)
                    {
                        Query queryTicket = new Query(DDPawnTicket.Schema);
                        queryTicket.AddWhere("TicketID", dtOperation.Rows[0]["TicketID"].ToString());
                        DataTable dtTicket = queryTicket.ExecuteDataSet().Tables[0];
                        if (dtTicket.Rows.Count > 0)
                        {
                            TicketNumber = dtTicket.Rows[0]["TicketNumber"].ToString();
                            if (TicketNumber.Contains(strKey))
                            {
                                this.dataGridView1.Rows.Add(1);
                                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["TicketNumber"].Value = dtTicket.Rows[0]["TicketNumber"];
                                Query queryCustomer = new Query(DDCustomerInfo.Schema);
                                queryCustomer.AddWhere("CustomerID", dtTicket.Rows[0]["CustomerID"].ToString());
                                DataTable dtCustomer = queryCustomer.ExecuteDataSet().Tables[0];
                                if (dtCustomer.Rows.Count > 0)
                                {
                                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["CustomerName"].Value = dtCustomer.Rows[0]["CustomerName"];
                                }
                                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["HouseID"].Value = dtHouse.Rows[i]["HouseID"];
                                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Address"].Value = dtHouse.Rows[i]["Address"];
                                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["CompactNumber"].Value = dtHouse.Rows[i]["CompactNumber"];
                                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Area"].Value = dtHouse.Rows[i]["Area"];
                                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["RegisterDate"].Value = dtHouse.Rows[i]["RegisterDate"];
                                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["InsuranceDate"].Value = dtHouse.Rows[i]["InsuranceDate"];
                                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["NotarizationDate"].Value = dtHouse.Rows[i]["NotarizationDate"];

                            }
                        }
                    }
                }
            }
            /*
            Query queryTicket = new Query(DDPawnTicket.Schema);
            
            queryTicket.AddWhere("TicketNumber",Comparison.Like,strKey);
            DataTable dtTicket = queryTicket.ExecuteDataSet().Tables[0];
            if (dtTicket.Rows.Count > 0)
            {
                for (int i = 0; i < dtTicket.Rows.Count; i++)
                {
                    Query query = new Query(DDOperation.Schema);
                    query.AddWhere("OperationType", 1);
                    query.AddWhere("TicketID",Convert.ToInt32(dtTicket.Rows[i]["TicketID"]));
                    DataTable dt = query.ExecuteDataSet().Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            Query queryHouse = new Query(DDHouseInfo.Schema);
                            queryHouse.AddWhere("PawnageID",Convert.ToInt32(dt.Rows[j]["PawnageID"]));
                            DataTable dtHouse = queryHouse.ExecuteDataSet().Tables[0];
                            if (dtHouse.Rows.Count > 0)
                            {
                                for (int k = 0; k < dtHouse.Rows.Count; k++)
                                {
                                    this.dataGridView1.Rows.Add(1);
                                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["TicketNumber"].Value = dtTicket.Rows[i]["TicketNumber"];
                                    Query queryCustomer = new Query(DDCustomerInfo.Schema);
                                    queryCustomer.AddWhere("CustomerID", dtTicket.Rows[i]["CustomerID"].ToString());
                                    DataTable dtCustomer = queryCustomer.ExecuteDataSet().Tables[0];
                                    if (dtCustomer.Rows.Count > 0)
                                    {
                                        dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["CustomerName"].Value = dtCustomer.Rows[0]["CustomerName"];
                                    }
                                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["HouseID"].Value = dtHouse.Rows[k]["HouseID"];
                                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Address"].Value = dtHouse.Rows[k]["Address"];
                                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["CompactNumber"].Value = dtHouse.Rows[k]["CompactNumber"];
                                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Area"].Value = dtHouse.Rows[k]["Area"];
                                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["RegisterDate"].Value = dtHouse.Rows[k]["RegisterDate"];
                                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["InsuranceDate"].Value = dtHouse.Rows[k]["InsuranceDate"];
                                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["NotarizationDate"].Value = dtHouse.Rows[k]["NotarizationDate"];
                                }
                            }
                        }
                    }
                }
            }
             
            else
            {
                MessageBox.Show("该当票不存在！","提示信息");
            }
            */
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.dataGridView1.Rows.Count > 0)
            {
                DataGridViewRow dgr = dataGridView1.CurrentRow;
                
                this.tbxHouseAddress.Text = dgr.Cells["Address"].Value.ToString();
                this.tbxHouseCompactNumber.Text = dgr.Cells["CompactNumber"].Value.ToString();
                this.tbxHouseArea.Text = dgr.Cells["Area"].Value.ToString();
                this.tbxHouseRegisterDate.Text = dgr.Cells["RegisterDate"].Value.ToString();
                this.tbxHouseInsuranceDate.Text = dgr.Cells["InsuranceDate"].Value.ToString();
                this.tbxHouseNotarizationDate.Text = dgr.Cells["NotarizationDate"].Value.ToString();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow dgr = dataGridView1.CurrentRow;
                dgr.Cells["Address"].Value = this.tbxHouseAddress.Text;
                dgr.Cells["CompactNumber"].Value = this.tbxHouseCompactNumber.Text;
                dgr.Cells["Area"].Value = this.tbxHouseArea.Text;
                dgr.Cells["RegisterDate"].Value = this.tbxHouseRegisterDate.Text;
                dgr.Cells["InsuranceDate"].Value = this.tbxHouseInsuranceDate.Text;
                dgr.Cells["NotarizationDate"].Value = this.tbxHouseNotarizationDate.Text;

                DDHouseInfo newHouse = new DDHouseInfo("HouseID", Convert.ToInt32(dgr.Cells["HouseID"].Value));
                newHouse.Address = this.tbxHouseAddress.Text;
                newHouse.CompactNumber = this.tbxHouseCompactNumber.Text;
                newHouse.Area = this.tbxHouseArea.Text;
                newHouse.RegisterDate = this.tbxHouseRegisterDate.Text;
                newHouse.InsuranceDate = this.tbxHouseInsuranceDate.Text;
                newHouse.NotarizationDate = this.tbxHouseNotarizationDate.Text;
                newHouse.Save();
                MessageBox.Show("信息更新成功！", "提示信息");
            }
            catch
            {
                MessageBox.Show("信息更新错误，请检查数据库是否连接正确！","提示信息");
            }

        }

        void tbxKeyWord_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                btnSearch_Click(sender, e);
        }
    
    }


}