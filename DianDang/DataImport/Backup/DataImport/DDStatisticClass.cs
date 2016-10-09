using System;
using System.Collections.Generic;
using System.Text;

namespace DataImport
{
    partial class Main
    {
        private void DDStatisticClass()
        {
            int SqlExecResutl = 0;
            string SqlExecString = "";

            DBFConnection.SetFile(this.DBFPath + "D1_CLASS.DBF");
            DBFConnection.Connect();
            DBFResult = DBFConnection.Query("select D1_Name from D1_CLASS.DBF");
            DBFData = DBFResult.GetResult();
            while (DBFData.Read())
            {
                SqlExecString = "Insert into DDStatisticClass (ClassName) VALUES ('" + CutSpace(DBFData[0].ToString()) + "')";
                SqlExecResutl = SqlConnection.Exec(SqlExecString);
            }
            DBFData.Close();
            DBFConnection.DisConnect();

            SqlExecString = "Insert into DDStatisticClass (ClassName) VALUES ('其它')";
            SqlExecResutl = SqlConnection.Exec(SqlExecString);
        }

        private void DDStatisticClass_Init()
        {
            int SqlExecResult = 0;
            string SqlExecString = "";

            SqlExecString = "Insert into DDStatisticClass (ClassName) VALUES ('民品')\n"
                            + "Insert into DDStatisticClass (ClassName) VALUES ('汽车')\n"
                            + "Insert into DDStatisticClass (ClassName) VALUES ('房产')\n"
                            + "Insert into DDStatisticClass (ClassName) VALUES ('证券')\n"
                            + "Insert into DDStatisticClass (ClassName) VALUES ('其它')";
            SqlExecResult = SqlConnection.Exec(SqlExecString);
        }
    }
}
