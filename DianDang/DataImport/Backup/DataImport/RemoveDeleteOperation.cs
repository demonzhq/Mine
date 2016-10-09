using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Collections;

namespace DataImport
{
    partial class Main
    {
        private void RemoveDeleteOperation()
        {
            SqlResult = SqlConnection.Query("select OperationID from DDOperation where OperationType=6");
            SqlData = SqlResult.GetResult();
            while (SqlData.Read())
            {
                RemoveOperationLine(SqlData[0].ToString());
            }
            SqlData.Close();
        }

        private void RemoveOperationLine(string iOperationID)
        {
            string SqlExecString = "";
            int SqlExecResult = 0;
            string DeleteOperationID = "";
            string NextOperationID = "";
            string PreOperationID = "";
            SqlResultTemp = SqlTemp.Query("select PreOperationID, NextOperationID from DDOperation where OperationID='" + iOperationID + "'");
            SqlDataTemp = SqlResultTemp.GetResult();
            while (SqlDataTemp.Read())
            {
                DeleteOperationID = SqlDataTemp[0].ToString();
                NextOperationID = SqlDataTemp[1].ToString();
            }
            SqlDataTemp.Close();

            SqlResultTemp = SqlTemp.Query("select PreOperationID, NextOperationID from DDOperation where OperationID='" + DeleteOperationID + "'");
            SqlDataTemp = SqlResultTemp.GetResult();
            while (SqlDataTemp.Read())
            {
                PreOperationID = SqlDataTemp[0].ToString();
            }
            SqlDataTemp.Close();

            SqlExecString = "update DDOperation set NextOperationID='" + NextOperationID + "' where OperationID='" + PreOperationID + "'";
            SqlExecResult = SqlTemp.Exec(SqlExecString);

            SqlExecString = "update DDOperation set OperationType=6 where OperationID='" + DeleteOperationID + "'";
            SqlExecResult = SqlTemp.Exec(SqlExecString);

            SqlExecString = "update DDOperation set NextOperationID='" + NextOperationID + "' where OperationID='" + DeleteOperationID + "'";
            SqlExecResult = SqlTemp.Exec(SqlExecString);

            SqlExecString = "delete from DDOperation where OperationID='" + iOperationID + "'";
            SqlExecResult = SqlTemp.Exec(SqlExecString);

            SqlExecString = "update DDOperation set PreOperationID='" + PreOperationID + "' where OperationID='" + NextOperationID + "'";
            SqlExecResult = SqlTemp.Exec(SqlExecString);
        }
    }
}
