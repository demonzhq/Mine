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
    public partial class SearchHouseForm : DockContent
    {
        public SearchHouseForm()
        {
            InitializeComponent();

            InitGridTable();
        }

        private void InitGridTable()
        {
            //string CustomerName = "";
            //string TicketNumber = "";
            string TicketStatus ="";
            DateTime startTime = Convert.ToDateTime("1900-1-1");
            DateTime endTime = DateTime.Now.AddDays(30);
            string strEndTime = endTime.Year.ToString() + "-" + endTime.Month.ToString() + "-" + endTime.Day.ToString();
            endTime = Convert.ToDateTime(strEndTime);
            Query query = new Query(DDHouseInfo.Schema);
            query.AddBetweenAnd("NotarizationDate",startTime,endTime);
            DataTable dt = query.ExecuteDataSet().Tables[0];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Query queryPawnage = new Query(DDPawnageInfo.Schema);
                    queryPawnage.AddWhere("PawnageID", dt.Rows[i]["PawnageID"].ToString());
                    DataTable dtPawnage = queryPawnage.ExecuteDataSet().Tables[0];
                    if (dtPawnage.Rows.Count > 0)
                    {
                        TicketStatus = dtPawnage.Rows[0]["StatusID"].ToString();
                        if (TicketStatus == "1" || TicketStatus == "3" || TicketStatus == "4")
                        {
                            this.dataGridView1.Rows.Add(1);
                            //GetName
                            Query queryOperation = new Query(DDOperation.Schema);
                            queryOperation.AddWhere("PawnageID", dt.Rows[i]["PawnageID"]);
                            DataTable dtOperation = queryOperation.ExecuteDataSet().Tables[0];
                            if (dtOperation.Rows.Count > 0)
                            {
                                Query queryTicket = new Query(DDPawnTicket.Schema);
                                queryTicket.AddWhere("TicketID", dtOperation.Rows[0]["TicketID"].ToString());
                                DataTable dtTicket = queryTicket.ExecuteDataSet().Tables[0];
                                if (dtTicket.Rows.Count > 0)
                                {
                                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["TicketNumber"].Value = dtTicket.Rows[0]["TicketNumber"];
                                    Query queryCustomer = new Query(DDCustomerInfo.Schema);
                                    queryCustomer.AddWhere("CustomerID", dtTicket.Rows[0]["CustomerID"].ToString());
                                    DataTable dtCustomer = queryCustomer.ExecuteDataSet().Tables[0];
                                    if (dtCustomer.Rows.Count > 0)
                                    {
                                        dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["CustomerName"].Value = dtCustomer.Rows[0]["CustomerName"];
                                    }
                                }
                            }
                            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Address"].Value = dt.Rows[i]["Address"];
                            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["CompactNumber"].Value = dt.Rows[i]["CompactNumber"];
                            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Area"].Value = dt.Rows[i]["Area"];
                            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["RegisterDate"].Value = dt.Rows[i]["RegisterDate"];
                            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["InsuranceDate"].Value = dt.Rows[i]["InsuranceDate"];
                            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["NotarizationDate"].Value = dt.Rows[i]["NotarizationDate"];

                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("暂无任何公正到期房产!","提示信息");
            }
        }
    }
}