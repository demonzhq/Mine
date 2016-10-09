using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Collections;

namespace FindData
{
    public partial class Form1 : Form
    {
        MySqlConnection Connection = new MySqlConnection();
        SqlQueryResult Result;
        SqlDataReader Data;
        string ConnectString = "";


        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ArrayList Tables = new ArrayList();
            textBox3.Text = "";
            CreatConnectString();
            Connection.SetConnectionString(ConnectString);
            Connection.Connect();
            Connection.ChangeDatabase(textBox7.Text);
            Result = Connection.Query("select name from sysobjects where xtype='u'");
            Data = Result.GetResult();
            while (Data.Read())
            {                
                Tables.Add(Data[0].ToString());
            }
            Data.Close();

            for (int i = 0; i < Tables.Count; i++)
            {
                Result = Connection.Query("select * from " + Tables[i]);
                Data = Result.GetResult();
                while (Data.Read())
                {
                    for (int j = 0; j < Data.VisibleFieldCount; j++)
                    {
                        if (CutSpace(Data[j].ToString()).ToUpper() == textBox2.Text.ToUpper())
                        {
                            if (textBox3.Text.Contains(Tables[i].ToString()) == false)
                            {
                                textBox3.Text += Tables[i];
                                textBox3.Text += " :: ";
                                textBox3.Text += Data.GetName(j);
                                textBox3.Text += "\r\n";
                            }
                        }
                    }
                }
                Data.Close();
            }
            

            
            Connection.DisConnect();
            
            
            
            textBox3.Text += "Done!";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ArrayList Tables = new ArrayList();
            textBox3.Text = "";
            CreatConnectString();
            Connection.SetConnectionString(ConnectString);
            Connection.Connect();
            Connection.ChangeDatabase(textBox7.Text);
            Result = Connection.Query("select name from sysobjects where xtype='u'");
            Data = Result.GetResult();
            while (Data.Read())
            {
                Tables.Add(Data[0].ToString());
            }
            Data.Close();
            for (int i = 0; i < Tables.Count; i++)
            {
                Result = Connection.Query("select * from " + Tables[i]);
                Data = Result.GetResult();
                for (int j = 0; j < Data.VisibleFieldCount; j++)
                {
                    if (Data.GetName(j).ToUpper() == textBox4.Text.ToUpper())
                    {
                        if (textBox3.Text.Contains(Tables[i].ToString()) == false)
                        {
                            textBox3.Text += Tables[i];
                            textBox3.Text += " :: ";
                            textBox3.Text += Data.GetName(j);
                            textBox3.Text += "\r\n";
                        }
                    }
                }
                Data.Close();
            }
            textBox3.Text += "Done!";
            Connection.DisConnect();

        }



        private string CutSpace(string theString)
        {
            int i = theString.Length;
            while ((i != 0) && (theString.Substring(i - 1, 1) == @" "))
            {
                i--;
            }
            return theString.Substring(0, i);
        }

        private void CreatConnectString()
        {
            
            //Server
            this.ConnectString += "Data Source=";
            this.ConnectString += this.textBox1.Text;
            this.ConnectString += ";";
            //Init Database
            //this.ConnectString += "Initial Catalog=";
            //this.ConnectString += this.Database;
            //this.ConnectString += ";";
            //Password Needed
            this.ConnectString += "Persist Security Info=True;Asynchronous Processing=true;";
            //User ID
            this.ConnectString += "User ID=";
            this.ConnectString += this.textBox5.Text;
            this.ConnectString += ";";
            //Password
            this.ConnectString += "Password=";
            this.ConnectString += this.textBox6.Text;
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
