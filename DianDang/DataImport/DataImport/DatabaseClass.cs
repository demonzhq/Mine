using System.Data.OleDb;
using System.Data.SqlClient;

namespace DataImport
{
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

    public partial class DBFQueryResult
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
    
    public partial class DBFConnectionResult
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
    
    public partial class MyDBFConnection
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