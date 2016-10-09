using System;
using System.Collections.Generic;
using System.Text;

namespace DataImport
{
    partial class Main
    {
        private void DDRoles()
        {
            int SqlExecResult = 0;
            string SqlExecString = "";

            SqlExecString = "insert into DDRoles (RoleName) VALUES ('管理员')\n"
                            + "insert into DDRoles (RoleName) VALUES ('部门经理')\n"
                            + "insert into DDRoles (RoleName) VALUES ('业务员')\n";
            SqlExecResult = SqlConnection.Exec(SqlExecString);
        }
    }
}
