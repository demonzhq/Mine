using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace FindData
{
    public partial class Form1 : Form
    {
        MyDBFConnection Connection = new MyDBFConnection();
        DBFConnectionResult ConnectionResult;
        DBFQueryResult Result;
        OleDbDataReader Data;
        DirectoryInfo Dir;
        FileInfo []Files;


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            textBox1.Text = folderBrowserDialog1.SelectedPath;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            textBox3.Update();
            Dir = new DirectoryInfo(textBox1.Text);
            Files = Dir.GetFiles();
            for (int i = 0; i < Files.Length; i++)
            {
                if (isDBF(Files[i]))
                {
                    Connection.SetFile(Files[i].FullName);
                    ConnectionResult = Connection.Connect();
                    if (ConnectionResult.isSuccess())
                    {
                        Result = Connection.Query("select * from " + Files[i].Name);
                        Data = Result.GetResult();
                        while (Data.Read())
                        {
                            for (int j = 0; j < Data.VisibleFieldCount; j++)
                            {
                                if ( CutSpace(Data[j].ToString().ToUpper()).Contains(textBox2.Text.ToUpper()))
                                {
                                    if (textBox3.Text.Contains(Files[i].Name) == false)
                                    {
                                        textBox3.Text += Files[i].Name;
                                        textBox3.Text += " :: ";
                                        textBox3.Text += Data.GetName(j);
                                        textBox3.Text += "\r\n";
                                    }

                                }
                            }
                        }
                    }

                    Connection.DisConnect();
                }
            }
            textBox3.Text += "Done!";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            textBox3.Update();
            Dir = new DirectoryInfo(textBox1.Text);
            Files = Dir.GetFiles();
            for (int i = 0; i < Files.Length; i++)
            {
                if (isDBF(Files[i]))
                {
                    Connection.SetFile(Files[i].FullName);
                    ConnectionResult = Connection.Connect();
                    if (ConnectionResult.isSuccess())
                    {
                        Result = Connection.Query("select * from " + Files[i].Name);
                        Data = Result.GetResult();
                        if (Data.Read())
                        {
                            for (int j = 0; j < Data.VisibleFieldCount; j++)
                            {
                                if (CutSpace(Data.GetName(j)).ToUpper().Contains(textBox4.Text.ToUpper()))
                                {
                                    textBox3.Text += Files[i].Name;
                                    textBox3.Text += " :: ";
                                    textBox3.Text += Data.GetName(j);
                                    textBox3.Text += "\r\n";
                                }
                            }
                        }
                    }

                    Connection.DisConnect();
                }
            }
            textBox3.Text += "Done!";
        }

        private bool isDBF(FileInfo theFile)
        {
            string Name = theFile.Name;
            Name = Name.Substring((Name.Length - 3), 3);
            if (Name == "DBF") return true;
            else return false;
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


    }



    public class DBFQueryResult
    {
        private bool ifSuccess;
        private OleDbException FailReason;
        private OleDbDataReader Result;

        public DBFQueryResult()
        {
            ifSuccess = true;
        }

        public DBFQueryResult(OleDbException theFailReason)
        {
            ifSuccess = false;
            FailReason = theFailReason;
        }

        public DBFQueryResult(OleDbDataReader theResult)
        {
            this.ifSuccess = true;
            this.Result = theResult;
        }

        public bool isSuccess()
        {
            return ifSuccess;
        }

        public OleDbException GetReason()
        {
            return FailReason;
        }

        public OleDbDataReader GetResult()
        {
            return this.Result;
        }

    }

    public class DBFConnectionResult
    {
        private bool ifSuccess;
        private OleDbException FailReason;

        public DBFConnectionResult(OleDbException theFailReason)
        {
            ifSuccess = false;
            this.FailReason = theFailReason;
        }

        public DBFConnectionResult()
        {
            ifSuccess = true;
        }

        public bool isSuccess()
        {
            return ifSuccess;
        }

        public OleDbException GetReason()
        {
            return FailReason;
        }

    }

    public class MyDBFConnection
    {
        private OleDbConnection Connection;


        public MyDBFConnection()
        {
            Connection = new OleDbConnection();
        }

        public MyDBFConnection(string ConnectionString)
        {
            Connection = new OleDbConnection(ConnectionString);
        }

        public void SetConnectionString(string theConnectionString)
        {
            Connection.ConnectionString = theConnectionString;
        }

        public void SetFile(string FileName)
        {
            Connection.ConnectionString = @"provider=vfpoledb.1;;data source=" + FileName;
        }

        public DBFConnectionResult Connect()
        {
            try
            {
                Connection.Open();
                return (new DBFConnectionResult());

            }
            catch (OleDbException e)
            {
                return (new DBFConnectionResult(e));
            }
        }

        public DBFConnectionResult DisConnect()
        {
            try
            {
                this.Connection.Close();
                return (new DBFConnectionResult());
            }
            catch (OleDbException e)
            {
                return (new DBFConnectionResult(e));
            }
        }

        public DBFQueryResult Query(string QueryString)
        {
            OleDbCommand QueryCommand = new OleDbCommand();
            DBFQueryResult FinalResult;
            OleDbDataReader Result;
            QueryCommand.CommandText = QueryString;
            QueryCommand.Connection = this.Connection;
            try
            {
                Result = QueryCommand.ExecuteReader();
                QueryCommand.Dispose();
                FinalResult = new DBFQueryResult(Result);
                return FinalResult;
            }
            catch (OleDbException e)
            {
                FinalResult = new DBFQueryResult(e);
                return FinalResult;
            }
        }

        public int Exec(string QueryString)
        {
            int Result;
            OleDbCommand ExecCommand = new OleDbCommand();
            ExecCommand.CommandText = QueryString;
            ExecCommand.Connection = this.Connection;
            Result = ExecCommand.ExecuteNonQuery();
            return Result;
        }
    }

}
