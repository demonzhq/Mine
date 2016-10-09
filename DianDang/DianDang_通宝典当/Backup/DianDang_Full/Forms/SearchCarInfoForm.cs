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
    public partial class SearchCarInfoForm : DockContent
    {
        public SearchCarInfoForm()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            string strKey = this.tbxKeyWord.Text.Trim();

            Query queryCar = new Query(DDCarInfo.Schema);
            DataTable dtCar = queryCar.ExecuteDataSet().Tables[0];
            if (dtCar.Rows.Count > 0)
            {
                for (int i = 0; i < dtCar.Rows.Count; i++)
                {
                    string TicketNumber = "";
                    Query queryOperation = new Query(DDOperation.Schema);
                    queryOperation.AddWhere("PawnageID", dtCar.Rows[i]["PawnageID"].ToString());
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
                                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["CarID"].Value = dtCar.Rows[i]["CarID"];
                                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["LicenseNumber"].Value = dtCar.Rows[i]["LicenseNumber"];
                                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["CarType"].Value = dtCar.Rows[i]["CarType"];
                                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["EngineNumber"].Value = dtCar.Rows[i]["EngineNumber"];
                                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["CarcaseNumber"].Value = dtCar.Rows[i]["CarcaseNumber"];
                                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["InsuranceDate"].Value = dtCar.Rows[i]["InsuranceDate"];
                                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["RoadtollDate"].Value = dtCar.Rows[i]["RoadtollDate"];
                                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["CheckDate"].Value = dtCar.Rows[i]["CheckDate"];
                            }
                        }
                    }
                }
            }

            /*
            Query queryTicket = new Query(DDPawnTicket.Schema);
            
            queryTicket.AddWhere("TicketNumber", Comparison.Like, strKey);
            DataTable dtTicket = queryTicket.ExecuteDataSet().Tables[0];
            if (dtTicket.Rows.Count > 0)
            {
                for (int i = 0; i < dtTicket.Rows.Count; i++)
                {
                    Query query = new Query(DDOperation.Schema);
                    query.AddWhere("OperationType", 1);
                    query.AddWhere("TicketID", Convert.ToInt32(dtTicket.Rows[i]["TicketID"]));
                    DataTable dt = query.ExecuteDataSet().Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            Query queryCar = new Query(DDCarInfo.Schema);
                            queryCar.AddWhere("PawnageID", Convert.ToInt32(dt.Rows[j]["PawnageID"]));
                            DataTable dtCar = queryCar.ExecuteDataSet().Tables[0];
                            if (dtCar.Rows.Count > 0)
                            {
                                for (int k = 0; k < dtCar.Rows.Count; k++)
                                {
                                    this.dataGridView1.Rows.Add(1);
                                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["CarID"].Value = dtCar.Rows[k]["CarID"];
                                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["LicenseNumber"].Value = dtCar.Rows[k]["LicenseNumber"];
                                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["CarType"].Value = dtCar.Rows[k]["CarType"];
                                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["EngineNumber"].Value = dtCar.Rows[k]["EngineNumber"];
                                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["CarcaseNumber"].Value = dtCar.Rows[k]["CarcaseNumber"];
                                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["InsuranceDate"].Value = dtCar.Rows[k]["InsuranceDate"];
                                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["RoadtollDate"].Value = dtCar.Rows[k]["RoadtollDate"];
                                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["CheckDate"].Value = dtCar.Rows[k]["CheckDate"];
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("该当票不存在！", "提示信息");
            }
            */

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.dataGridView1.Rows.Count > 0)
            {
                DataGridViewRow dgr = dataGridView1.CurrentRow;

                this.tbxCarLicenceNumber.Text = dgr.Cells["LicenseNumber"].Value.ToString();
                this.tbxCarType.Text = dgr.Cells["CarType"].Value.ToString();
                this.tbxCarEngineNumber.Text = dgr.Cells["EngineNumber"].Value.ToString();
                this.tbxCarcaseNumber.Text = dgr.Cells["CarcaseNumber"].Value.ToString();
                this.tbxCarInsuranceDate.Text = dgr.Cells["InsuranceDate"].Value.ToString();
                this.tbxCarRoadtollDate.Text = dgr.Cells["RoadtollDate"].Value.ToString();
                this.tbxCarCheckDate.Text = dgr.Cells["CheckDate"].Value.ToString();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow dgr = dataGridView1.CurrentRow;
                dgr.Cells["LicenseNumber"].Value = this.tbxCarLicenceNumber.Text;
                dgr.Cells["CarType"].Value = this.tbxCarType.Text;
                dgr.Cells["EngineNumber"].Value = this.tbxCarEngineNumber.Text;
                dgr.Cells["CarcaseNumber"].Value = this.tbxCarcaseNumber.Text;
                dgr.Cells["InsuranceDate"].Value = this.tbxCarInsuranceDate.Text;
                dgr.Cells["RoadtollDate"].Value = this.tbxCarRoadtollDate.Text;
                dgr.Cells["CheckDate"].Value = this.tbxCarCheckDate.Text;

                DDCarInfo newCar = new DDCarInfo("CarID", Convert.ToInt32(dgr.Cells["CarID"].Value));
                newCar.LicenseNumber = this.tbxCarLicenceNumber.Text;
                newCar.CarType = this.tbxCarType.Text;
                newCar.EngineNumber = this.tbxCarEngineNumber.Text;
                newCar.CarcaseNumber = this.tbxCarcaseNumber.Text;
                newCar.InsuranceDate = this.tbxCarInsuranceDate.Text;
                newCar.RoadtollDate = this.tbxCarRoadtollDate.Text;
                newCar.CheckDate = this.tbxCarCheckDate.Text;
                newCar.Save();
                MessageBox.Show("信息更新成功！", "提示信息");
            }
            catch
            {
                MessageBox.Show("信息更新错误，请检查数据库是否连接正确！", "提示信息");
            }
        }
    }
}