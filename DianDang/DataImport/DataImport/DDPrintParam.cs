using System;
using System.Collections.Generic;
using System.Text;

namespace DataImport
{
    partial class Main
    {
        private void DDPrintParam()
        {
            int SqlExecResult = 0;
            string SqlExecString = "";

            SqlExecString = "insert into DDPrintParam (OptionName, OptionValue) VALUES ('CreatTicket', '1')\n"
                            + "insert into DDPrintParam (OptionName, OptionValue) VALUES ('CreatRceipt', '1')\n"
                            + "insert into DDPrintParam (OptionName, OptionValue) VALUES ('RenewTicket', '1')\n"
                            + "insert into DDPrintParam (OptionName, OptionValue) VALUES ('RenewRceipt', '1')\n"
                            + "insert into DDPrintParam (OptionName, OptionValue) VALUES ('RedeemRceipt', '1')\n";
            SqlExecResult = SqlConnection.Exec(SqlExecString);
        }
    }
}
