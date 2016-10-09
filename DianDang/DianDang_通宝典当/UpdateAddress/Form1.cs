using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace UpdateAddress
{
    public partial class Form1 : Form
    {
        private string Server = @"127.0.0.1\SQLEXPRESS";
        private string User = "sa";
        private string Pass = "0000pppP";
        private string Database = "DD";
        private string ConnectString = "";
        string ImportStructFile = @"C:\a.txt";
        private MySqlConnection SqlConnection;
        SqlQueryResult SqlResult;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreatConnectString();
            SqlConnection = new MySqlConnection(this.ConnectString);
            SqlConnection.Connect();
            string command = @"use [DD]
                                alter table DDCustomerInfo
                                alter column Address char(200)";
            int a = SqlConnection.Exec(command);
            if (a == -1)
            {
                MessageBox.Show("修改成功");
                Application.Exit();
            }
            else MessageBox.Show("失败");
        }

        private void CreatConnectString()
        {
            //Server
            this.ConnectString += "Data Source=";
            this.ConnectString += this.Server;
            this.ConnectString += ";";
            //Init Database
            //this.ConnectString += "Initial Catalog=";
            //this.ConnectString += this.Database;
            //this.ConnectString += ";";
            //Password Needed
            this.ConnectString += "Persist Security Info=True;Asynchronous Processing=true;";
            //User ID
            this.ConnectString += "User ID=";
            this.ConnectString += this.User;
            this.ConnectString += ";";
            //Password
            this.ConnectString += "Password=";
            this.ConnectString += this.Pass;
            this.ConnectString += ";";
        }


    }

    public partial class MySqlConnection
    {
        private SqlConnection Connection;


        public MySqlConnection()
        {
            Connection = new SqlConnection();
        }

        public MySqlConnection(string ConnectionString)
        {
            Connection = new SqlConnection(ConnectionString);
        }

        public void SetConnectionString(string theConnectionString)
        {
            Connection.ConnectionString = theConnectionString;
        }

        public SqlConnectionResult Connect()
        {
            try
            {
                Connection.Open();
                return (new SqlConnectionResult());

            }
            catch (SqlException e)
            {
                return (new SqlConnectionResult(e));
            }
        }

        public SqlConnectionResult DisConnect()
        {
            try
            {
                this.Connection.Close();
                return (new SqlConnectionResult());
            }
            catch (SqlException e)
            {
                return (new SqlConnectionResult(e));
            }
        }

        public SqlQueryResult Query(string QueryString)
        {
            SqlCommand QueryCommand = new SqlCommand();
            SqlQueryResult FinalResult;
            SqlDataReader Result;
            QueryCommand.CommandText = QueryString;
            QueryCommand.Connection = this.Connection;
            try
            {
                Result = QueryCommand.ExecuteReader();
                QueryCommand.Dispose();
                FinalResult = new SqlQueryResult(Result);
                return FinalResult;
            }
            catch (SqlException e)
            {
                FinalResult = new SqlQueryResult(e);
                return FinalResult;
            }
        }

        public int ChangeDatabase(string Database)
        {
            int Result;
            SqlCommand ExecCommand = new SqlCommand();
            ExecCommand.CommandText = "use [" + Database + "]";
            ExecCommand.Connection = this.Connection;
            Result = ExecCommand.ExecuteNonQuery();
            return Result;
        }

        public int Exec(string QueryString)
        {
            int Result;
            SqlCommand ExecCommand = new SqlCommand();
            ExecCommand.CommandText = QueryString;
            ExecCommand.Connection = this.Connection;
            Result = ExecCommand.ExecuteNonQuery();
            return Result;
        }
    }

    public partial class SqlConnectionResult
    {
        private bool ifSuccess;
        private SqlException FailReason;

        public SqlConnectionResult(SqlException theFailReason)
        {
            ifSuccess = false;
            this.FailReason = theFailReason;
        }

        public SqlConnectionResult()
        {
            ifSuccess = true;
        }

        public bool isSuccess()
        {
            return ifSuccess;
        }

        public SqlException GetReason()
        {
            return FailReason;
        }

    }

    public partial class SqlQueryResult
    {
        private bool ifSuccess;
        private SqlException FailReason;
        private SqlDataReader Result;

        public SqlQueryResult()
        {
            ifSuccess = true;
        }

        public SqlQueryResult(SqlException theFailReason)
        {
            ifSuccess = false;
            FailReason = theFailReason;
        }

        public SqlQueryResult(SqlDataReader theResult)
        {
            this.ifSuccess = true;
            this.Result = theResult;
        }

        public bool isSuccess()
        {
            return ifSuccess;
        }

        public SqlException GetReason()
        {
            return FailReason;
        }

        public SqlDataReader GetResult()
        {
            return this.Result;
        }

    }
}
