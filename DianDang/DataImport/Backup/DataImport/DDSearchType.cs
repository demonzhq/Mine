using System;
using System.Collections.Generic;
using System.Text;

namespace DataImport
{
    partial class Main
    {
        private void DDSearchType()
        {
            int SqlExecResult = 0;
            string SqlExecString = "";
            SqlExecString = "insert into DDSearchType (TypeName) VALUES ('CustomerSearch')\n"
                            + "insert into DDSearchType (TypeName) VALUES ('TicketSearch')\n"
                            + "insert into DDSearchType (TypeName) VALUES ('UserSearch')\n";
            SqlExecResult = SqlConnection.Exec(SqlExecString);
        }
    }
}
