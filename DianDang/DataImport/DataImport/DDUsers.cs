using System;
using System.Collections.Generic;
using System.Text;

namespace DataImport
{
    public class UserInfo
    {
        public string OperatorNum = "";
        public string AccountName;
        public string UserPassword;
        public string UserName;
        public int RoleID = 0;
        public string Email = "";
        public string PhoneNumber = "";
        public string CertNumber = "";
    }

    partial class Main
    {
        private void ReadDBFUserInfo()
        {
            DBFConnection.SetFile(this.DBFPath + "OPERATOR.DBF");
            DBFConnection.Connect();
            DBFResult = DBFConnection.Query("select OPERATOR, NAME from OPERATOR.DBF");
            DBFData = DBFResult.GetResult();
            while (DBFData.Read())
            {
                UserInfo theUser = new UserInfo();
                theUser.AccountName = CutSpace(DBFData[0].ToString());
                theUser.UserName = CutSpace(DBFData[1].ToString());
                UserList.Add(theUser);
            }
            DBFData.Close();
            DBFConnection.DisConnect();
        }

        private void DDUsers()
        {
            int SqlExecResult = 0;
            string SqlExecString = "";


            
            SqlExecString = "insert into DDUsers (AccountName, UserPassword, UserName, RoleID, Email, PhoneNumber, CertNumber) VALUES ('admin', 'admin', '管理员', '1', '', '', '')";
            SqlExecResult = SqlConnection.Exec(SqlExecString);
            /*
            for (int i = 0; i < UserList.Count; i++)
            {
                SqlExecString = "insert into DDUsers (AccountName, UserName, RoleID) VALUES("
                                + "'" + UserList[i].AccountName + "', "
                                + "'" + UserList[i].UserName + "', "
                                + "'" + 1 + "')";
                SqlExecResult = SqlConnection.Exec(SqlExecString);
            }
            */
        }

        private int GetSqlOperatorIDByDBFOperator(string theOperator)
        {
            int OperatorID = 0;
            SqlResultTemp = SqlTemp.Query("select UserID from DDUsers where AccountName='" + theOperator + "'");
            SqlDataTemp = SqlResultTemp.GetResult();
            while (SqlDataTemp.Read())
            {
                OperatorID = Convert.ToInt32(SqlDataTemp[0].ToString());
            }
            SqlDataTemp.Close();
            return OperatorID;
        }

        private string GetOperatorNameByDBFOperator(string theOperator)
        {
            string OperatorName = "";
            DBFTemp.SetFile(this.DBFPath + "OPERATOR.DBF");
            DBFTemp.Connect();
            DBFResultTemp = DBFTemp.Query("select NAME from OPERATOR.DBF where OPERATOR='" + theOperator + "'");
            DBFDataTemp = DBFResultTemp.GetResult();
            while (DBFDataTemp.Read())
            {
                OperatorName = CutSpace(DBFDataTemp[0].ToString());
            }
            DBFDataTemp.Close();
            DBFTemp.DisConnect();
            return OperatorName;
        }
    }
}
