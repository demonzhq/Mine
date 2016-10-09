namespace DataImport
{
    partial class Main
    {
        private void DDModules()
        {
            int SqlExecResult = 0;
            string SqlExecString = "";

            SqlExecString = "insert into DDModules (ModuleName, ParentID) VALUES('帐户管理', '0')\n"
                            + "insert into DDModules (ModuleName, ParentID) VALUES('业务处理', '0')\n"
                            + "insert into DDModules (ModuleName, ParentID) VALUES('统计查询', '0')\n"
                            + "insert into DDModules (ModuleName, ParentID) VALUES('客户信息管理', '0')\n"
                            + "insert into DDModules (ModuleName, ParentID) VALUES('风险提示', '0')\n"
                            + "insert into DDModules (ModuleName, ParentID) VALUES('系统设定', '0')\n"
                            + "insert into DDModules (ModuleName, ParentID) VALUES('数据管理', '0')\n"
                            + "insert into DDModules (ModuleName, ParentID) VALUES('修改个人信息', '1')\n"
                            + "insert into DDModules (ModuleName, ParentID) VALUES('帐户管理', '1')\n"
                            + "insert into DDModules (ModuleName, ParentID) VALUES('权限管理', '1')\n"
                            + "insert into DDModules (ModuleName, ParentID) VALUES('建当', '2')\n"
                            + "insert into DDModules (ModuleName, ParentID) VALUES('赎当', '2')\n"
                            + "insert into DDModules (ModuleName, ParentID) VALUES('续当', '2')\n"
                            + "insert into DDModules (ModuleName, ParentID) VALUES('部分赎回', '2')\n"
                            + "insert into DDModules (ModuleName, ParentID) VALUES('绝当处理', '2')\n"
                            + "insert into DDModules (ModuleName, ParentID) VALUES('冻结处理', '2')\n"
                            + "insert into DDModules (ModuleName, ParentID) VALUES('删除处理', '2')\n"
                            + "insert into DDModules (ModuleName, ParentID) VALUES('清算处理', '2')\n"
                            + "insert into DDModules (ModuleName, ParentID) VALUES('资金统计查询', '3')\n"
                            + "insert into DDModules (ModuleName, ParentID) VALUES('当日业务监控', '3')\n"
                            + "insert into DDModules (ModuleName, ParentID) VALUES('当票查询', '3')\n"
                            + "insert into DDModules (ModuleName, ParentID) VALUES('房产查询', '3')\n"
                            + "insert into DDModules (ModuleName, ParentID) VALUES('车辆查询', '3')\n"
                            + "insert into DDModules (ModuleName, ParentID) VALUES('添加客户信息', '4')\n"
                            + "insert into DDModules (ModuleName, ParentID) VALUES('客户查询', '4')\n"
                            + "insert into DDModules (ModuleName, ParentID) VALUES('客户历史查询', '4')\n"
                            + "insert into DDModules (ModuleName, ParentID) VALUES('股票查询', '5')\n"
                            + "insert into DDModules (ModuleName, ParentID) VALUES('黄金查询', '5')\n"
                            + "insert into DDModules (ModuleName, ParentID) VALUES('铂金查询', '5')\n"
                            + "insert into DDModules (ModuleName, ParentID) VALUES('到期房产查询', '5')\n"
                            + "insert into DDModules (ModuleName, ParentID) VALUES('典当行信息设定', '6')\n"
                            + "insert into DDModules (ModuleName, ParentID) VALUES('当品类别设定', '6')\n"
                            + "insert into DDModules (ModuleName, ParentID) VALUES('数据备份和恢复', '7')\n"
                            + "insert into DDModules (ModuleName, ParentID) VALUES('分店管理', '7')\n"
                            + "insert into DDModules (ModuleName, ParentID) VALUES('当品标准分类统计', '3')\n"
                            + "insert into DDModules (ModuleName, ParentID) VALUES('当品统计分类统计', '3')\n"
                            + "insert into DDModules (ModuleName, ParentID) VALUES('营收标准分类统计', '3')\n"
                            + "insert into DDModules (ModuleName, ParentID) VALUES('营收统计分类统计', '3')\n"
                            + "insert into DDModules (ModuleName, ParentID) VALUES('打印设定', '6')\n"
                            + "insert into DDModules (ModuleName, ParentID) VALUES('操作查询', '3')\n"
                            + "insert into DDModules (ModuleName, ParentID) VALUES('当品查询', '3')\n"
                            + "insert into DDModules (ModuleName, ParentID) VALUES('续转处理', '2')\n"
                            + "insert into DDModules (ModuleName, ParentID) VALUES('修改客户信息', '4')\n";
            SqlExecResult = SqlConnection.Exec(SqlExecString);
        }
    }
    
}