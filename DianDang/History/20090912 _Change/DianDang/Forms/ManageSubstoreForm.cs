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
    public partial class ManageSubstoreForm : DockContent
    {
        public ManageSubstoreForm()
        {
            InitializeComponent();
            InitStoreInfo();
        }

        
        private void InitStoreInfo()
        {
            DataTable m_ClassTakingTable = new DataTable();
            //set columns names
            m_ClassTakingTable.Columns.Add("StoreID", typeof(System.String));
            m_ClassTakingTable.Columns.Add("StoreName", typeof(System.String));
            m_ClassTakingTable.Columns.Add("StoreAddress", typeof(System.String));
            m_ClassTakingTable.Columns.Add("PosterCode", typeof(System.String));
            m_ClassTakingTable.Columns.Add("PhoneNumber", typeof(System.String));

            DataRow drow = m_ClassTakingTable.NewRow();
            drow["StoreID"] = "001";
            drow["StoreName"] = "һ�ŷֵ�";
            drow["StoreAddress"] = "����·1000��";
            drow["PosterCode"] = "200100";
            drow["PhoneNumber"] = "021324421421";
            m_ClassTakingTable.Rows.Add(drow);

            this.dataGridView1.DataSource = m_ClassTakingTable;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            //if (e.ColumnIndex > 0)
            //{
                if (dgv.Columns[e.ColumnIndex].Name == "BtnConnect")
                {
                    System.Diagnostics.Process.Start("StoreManage.exe");
                }
            //}
        }
    }
}