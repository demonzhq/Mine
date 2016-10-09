using System.IO;


namespace DataImport
{
    public partial class Main
    {
    
        private void DDCertTypes()
        {
            int SqlExecResult = 0;
            string SqlExecString = "";

            DBFConnection.SetFile(this.DBFPath + "S_TYPE.DBF");
            DBFConnection.Connect();
            DBFResult = DBFConnection.Query("select S_TYPE from S_TYPE.DBF");
            DBFData = DBFResult.GetResult();
            while (DBFData.Read())
            {
                SqlExecString = "insert into DDCertTypes (TypeName) VALUES ('" + CutSpace(DBFData[0].ToString()) + "') ";
                SqlExecResult = SqlConnection.Exec(SqlExecString);
            }

            DBFConnection.DisConnect();

        }

        private void DDCertTypes_Init()
        {
            int SqlExecResult = 0;
            string SqlExecString = "";

            SqlExecString = "insert into DDCertTypes (TypeName) VALUES ('身份证') \n"
                            + "insert into DDCertTypes (TypeName) VALUES ('社保卡') \n"
                            + "insert into DDCertTypes (TypeName) VALUES ('驾驶证') \n"
                            + "insert into DDCertTypes (TypeName) VALUES ('护照') \n"
                            + "insert into DDCertTypes (TypeName) VALUES ('军官证') \n"
                            + "insert into DDCertTypes (TypeName) VALUES ('回乡证') \n"
                            + "insert into DDCertTypes (TypeName) VALUES ('户口本') \n"
                            + "insert into DDCertTypes (TypeName) VALUES ('营业执照') \n"
                            + "insert into DDCertTypes (TypeName) VALUES ('学生证') ";
            SqlExecResult = SqlConnection.Exec(SqlExecString);

        }

        private string GetCertTypeNameByTypeID(int theCertType)
        {
            string TypeName = "";
            SqlResultTemp = SqlTemp.Query("select TypeName from DDCertTypes where TypeID='" + theCertType.ToString() + "'");
            SqlDataTemp = SqlResultTemp.GetResult();
            while (SqlDataTemp.Read())
            {
                TypeName = SqlDataTemp[0].ToString();
            }
            SqlDataTemp.Close();
            return TypeName;
        }
    }
}