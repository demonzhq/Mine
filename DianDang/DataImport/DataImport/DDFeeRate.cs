using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace DataImport
{
    public partial class Main
    {
        string DDFeeRate_Rate1 = "4.7";
        string DDFeeRate_Rate2 = "0";

        private void DDFeeRate()
        {
            int SqlExecResult = 0;
            string SqlExecString = "";

            SqlExecString = "insert into DDFeeRate (Rate, RateType) VALUES ("
                            + "'" + DDFeeRate_Rate1 + "', "
                            + "1)";
            SqlExecResult = SqlConnection.Exec(SqlExecString);

            SqlExecString = "insert into DDFeeRate (Rate, RateType) VALUES ('"
                            + "" + DDFeeRate_Rate2 + "', "
                            + "2)";
            SqlExecResult = SqlConnection.Exec(SqlExecString);
        }
    }

}