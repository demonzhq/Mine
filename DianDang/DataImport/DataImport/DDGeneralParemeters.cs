using System;
using System.Collections.Generic;
using System.Text;

namespace DataImport
{
    partial class Main
    {
        private void DDGeneralParemeters_Init()
        {
            int SqlExecResult = 0;
            string SqlExecString = "";


            SqlExecString = "insert into DDGeneralParemeters (ParamName, ParamValue) VALUES ('CurrentTicketNumber', '000000001')\n"
                           + "insert into DDGeneralParemeters (ParamName, ParamValue) VALUES ('OperationNumber', '000000001')\n";
            SqlExecResult = SqlConnection.Exec(SqlExecString);


        }

        private string GetNewTicketNumber()
        {
            int Value = 0;
            string TicketNumber = "";
            SqlResultTemp = SqlTemp.Query("select max (ParamValue) from DDGeneralParemeters where ParamName='CurrentTicketNumber'");
            SqlDataTemp = SqlResultTemp.GetResult();
            while (SqlDataTemp.Read())
            {
                Value = Convert.ToInt32(CutSpace(SqlDataTemp[0].ToString()));
            }
            Value++;
            TicketNumber = FormatParmValue(Value);
            SqlDataTemp.Close();
            return TicketNumber;
        }

        private string GetNewOperationNumber()
        {
            int Value = 0;
            string TicketNumber = "";
            SqlResultTemp = SqlTemp.Query("select max (ParamValue) from DDGeneralParemeters where ParamName='OperationNumber'");
            SqlDataTemp = SqlResultTemp.GetResult();
            while (SqlDataTemp.Read())
            {
                Value = Convert.ToInt32(CutSpace(SqlDataTemp[0].ToString()));
            }
            Value++;
            TicketNumber = FormatParmValue(Value);
            SqlDataTemp.Close();
            return TicketNumber;
        }

        private void UpdateParamTicketNumber()
        {
            int SqlExecResult = 0;
            string SqlExecString = "";
            string NewValue = GetNewTicketNumber();
            SqlExecString = "update DDGeneralParemeters set ParamValue='"
                            + NewValue
                            + "' where ParamName='CurrentTicketNumber'";
            SqlExecResult = SqlTemp.Exec(SqlExecString);
            
        }

        private void UpdateOperationNumber()
        {
            int SqlExecResult = 0;
            string SqlExecString = "";
            string NewValue = GetNewOperationNumber();
            SqlExecString = "update DDGeneralParemeters set ParamValue='"
                            + NewValue
                            + "' where ParamName='OperationNumber'";
            SqlExecResult = SqlTemp.Exec(SqlExecString);

        }

        private void RefreshOperationNumber()
        {
            int SqlExecResult = 0;
            string SqlExecString = "";

            int MaxPawnTicketNumber = 0;
            SqlResult = SqlConnection.Query("select max(TicketNumber) from DDPawnTicket");
            SqlData = SqlResult.GetResult();
            while (SqlData.Read())
            {
                MaxPawnTicketNumber = Convert.ToInt32(SqlData[0].ToString());
            }
            SqlData.Close();
            MaxPawnTicketNumber++;
            SqlExecString = "update DDGeneralParemeters set ParamValue='" + MaxPawnTicketNumber.ToString() + "' where ParamName='CurrentTicketNumber'";
            SqlExecResult = SqlConnection.Exec(SqlExecString);
        }
    }
}
