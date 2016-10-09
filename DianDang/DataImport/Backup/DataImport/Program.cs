using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DataImport
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
            
        }
    }

    /*
        OleDbConnection conn = new OleDbConnection();
        string strTable = "\"" + "全路径DBF文件" + "\"";
        conn.ConnectionString = @"provider=vfpoledb.1;;data source=" + strTable;
        conn.Open();
        OleDbCommand cmd = new OleDbCommand();
        cmd.Connection = conn;
        cmd.CommandText = "set delete on ";
        cmd.CommandType = CommandType.Text;
        cmd.ExecuteNonQuery();
        string SQLSE1 = "select * from " + strTable
        OleDbDataAdapter da = new OleDbDataAdapter(SQLSE1, conn);
        DataSet ds1=new DataSet()
        da.Fill(ds1);
     protected void Page_Load(object sender, EventArgs e)
    {
        System.Data.Odbc.OdbcConnection conn = new System.Data.Odbc.OdbcConnection();
        string table = @"D:aaacode.dbf";
        string connStr=@"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + table + ";Exclusive=No;NULL=NO;Collate=Machine;BACKGROUNDFETCH=NO;DELETED=NO";

        conn.ConnectionString = connStr;
        conn.Open();
       

        OdbcCommand cmd = new OdbcCommand();
        cmd.Connection = conn;
        string sql = "update " + table + " set other='2',rate=1.014 ";
        cmd.CommandText = sql;
        cmd.CommandType = CommandType.Text;
        cmd.ExecuteNonQuery();

         sql = @"select * from " + table;
        OdbcDataAdapter da = new OdbcDataAdapter(sql,conn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        this.GridView1.DataSource = dt.DefaultView;
        this.GridView1.DataBind();

    }


     */
}
