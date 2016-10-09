namespace DataImport
{
    partial class Main
    {
        private void DDMesureUnit()
        {
            int SqlExecResult = 0;
            string SqlExecString = "";

            DBFConnection.SetFile(this.DBFPath + "UNITTYPE.DBF");
            DBFConnection.Connect();
            DBFResult = DBFConnection.Query("select UNITNAME from UNITTYPE.DBF");
            DBFData = DBFResult.GetResult();
            while (DBFData.Read())
            {
                SqlExecString = "insert into DDMesureUnit (UnitName) VALUES ('" + CutSpace(DBFData[0].ToString()) + "')";
                SqlExecResult = SqlConnection.Exec(SqlExecString);
            }
            DBFData.Close();
            DBFConnection.DisConnect();
            SqlExecResult = SqlConnection.Exec("Insert into DDMesureUnit (UnitName) VALUES ('其它')");
        }

        private void DDMesureUnit_Init()
        {
            int SqlExecResult = 0;
            string SqlExecString = "";
            SqlExecString = "Insert into DDMesureUnit (UnitName) VALUES ('克')\n"
                            + "Insert into DDMesureUnit (UnitName) VALUES ('件')\n"
                            + "Insert into DDMesureUnit (UnitName) VALUES ('批')\n"
                            + "Insert into DDMesureUnit (UnitName) VALUES ('台')\n"
                            + "Insert into DDMesureUnit (UnitName) VALUES ('辆')\n"
                            + "Insert into DDMesureUnit (UnitName) VALUES ('套')\n"
                            + "Insert into DDMesureUnit (UnitName) VALUES ('部')\n"
                            + "Insert into DDMesureUnit (UnitName) VALUES ('克拉')\n"
                            + "Insert into DDMesureUnit (UnitName) VALUES ('只')\n"
                            + "Insert into DDMesureUnit (UnitName) VALUES ('其它')";
            SqlExecResult = SqlConnection.Exec(SqlExecString);
        }

        private string GetUnitNameByClassID(int theClassID)
        {
            string UnitName = "";
            string UnitID = "";
            SqlResultTemp = SqlTemp.Query("select UnitID from DDPawnageClass where ClassID='" + theClassID + "'");
            SqlDataTemp = SqlResultTemp.GetResult();
            while (SqlDataTemp.Read())
            {
                UnitID = CutSpace(SqlDataTemp[0].ToString());
            }
            SqlDataTemp.Close();

            SqlResultTemp = SqlTemp.Query("select UnitName from DDMesureUnit where UnitID='" + UnitID + "'");
            SqlDataTemp = SqlResultTemp.GetResult();
            while (SqlDataTemp.Read())
            {
                UnitName = CutSpace(SqlDataTemp[0].ToString());
            }
            SqlDataTemp.Close();


            return UnitName;
        }

    }
    
}