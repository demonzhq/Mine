using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Reflection;
using MSExcel = Microsoft.Office.Interop.Excel;
using System.IO;


namespace DataImport
{
    public partial class Main : Form
    {
        //服务器变量
        private string Server = @"ZHQ-LAPTOP\SQLEXPRESS";
        private string User = "sa";
        private string Pass = "0000pppP";
        private string Database = "DD";
        private string ConnectString = "";
        string ImportStructFile = @"C:\a.txt";
        private MySqlConnection SqlConnection;    //主SQL线程
        private MySqlConnection SqlTemp;           //从SQL线程
        SqlQueryResult SqlResult;
        SqlDataReader SqlData;
        SqlQueryResult SqlResultTemp;
        SqlDataReader SqlDataTemp; 

        //DBF变量
        string DBFPath = @"D:\Work\Other\DianDang\系统\ddbackup\";
        private MyDBFConnection DBFConnection = new MyDBFConnection();
        private MyDBFConnection DBFTemp = new MyDBFConnection();
        DBFQueryResult DBFResult;
        DBFQueryResult DBFResultTemp;
        OleDbDataReader DBFData;
        OleDbDataReader DBFDataTemp;
        
        //用户参数
        public List<UserInfo> UserList = new List<UserInfo>();


        public Main()
        {     
            InitializeComponent();
        }

        private void Do_Once()
        {

            RefreshInfo();
            SqlConnection = new MySqlConnection(this.ConnectString);
            SqlTemp = new MySqlConnection(this.ConnectString);
            SqlConnection.Connect();
            SqlTemp.Connect();





            //CreatDatabaseStructure();

            SqlConnection.ChangeDatabase(this.Database);
            SqlTemp.ChangeDatabase(this.Database);

            //ReadDBFUserInfo();
            //DDUsers();
            //PawnOperatTicket();
            



            SqlConnection.DisConnect();
            SqlTemp.DisConnect();

            MessageBox.Show("Done!!");
        }

        private void Do_All()
        {
            RefreshInfo();
            CreatConnectString();
            SqlConnection = new MySqlConnection(this.ConnectString);
            SqlTemp = new MySqlConnection(this.ConnectString);
            SqlConnection.Connect();
            SqlTemp.Connect();





            CreatDatabaseStructure();

            SqlConnection.ChangeDatabase(this.Database);
            SqlTemp.ChangeDatabase(this.Database);




            //TryZone

            //int abc = GetSqlOperationTypebyDBFOP_TYPE("2");
            //End of TryZone


            //DoList Below
                        
            DDCertTypes();   //DDCertTypes_Init();
            DDCompanyInfo();
            DDCustomerInfo();
            DDFeeRate();
            DDPrintParam();
             

            DDSearchType();
            DDSearchOption();
                        
            DDMesureUnit();//DDMesureUnit_Init();  //

            //权限表
            DDModules();
            DDRoles();
            //ReadDBFUserInfo();
            DDUsers();
            DDPermissions();
            //未处理DDNews();

            DDGeneralParemeters_Init();
             
            DDStatisticClass();DDPawnageClass();
            //DDStatisticClass_Init();//处理中DDPawnageClass_Init();
            DDTicketStatus();
            PawnOperatTicket();

            RefreshOperationNumber();

            DDCarInfo();
            DDHouseInfo();

            //最后更新OperationID

            UpdateOperationNumber();

            RemoveDeleteOperation();

            SaveUserInfo();

            SqlConnection.DisConnect();
            SqlTemp.DisConnect();

            MessageBox.Show("Done!!");

            

        }

        private void TestConnect_Click(object sender, EventArgs e)
        {
            RefreshInfo();
            SqlConnectionResult SqlConnResult = new SqlConnectionResult();
            SqlConnection = new MySqlConnection(this.ConnectString);
            SqlConnResult = SqlConnection.Connect();
            if (SqlConnResult.isSuccess() == false)
            {
                SqlException theException = SqlConnResult.GetReason();
                MessageBox.Show(theException.Message);
            }
            else
            {
                try
                {
                    SqlConnection.ChangeDatabase(this.Database);
                    MessageBox.Show("警告：该数据库已经存在！");
                }
                catch (SqlException a)
                {
                    a.ToString();
                    MessageBox.Show("通过测试");
                }
                SqlConnection.DisConnect();
            }
            
        }

        private void InputFileSelect_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            this.InputStructFile.Text = openFileDialog1.FileName;
        }

        private void DBFPathSelect_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            this.InputDBFPath.Text = folderBrowserDialog1.SelectedPath;
            if (this.InputDBFPath.Text.Substring(InputDBFPath.Text.Length - 1, 1) != "\\")
            {
                this.InputDBFPath.Text = InputDBFPath.Text + "\\";
            }
        }

        private void RefreshInfo()
        {
            this.Server = this.InputAddress.Text;
            this.User = this.InputUser.Text;
            this.Pass = this.InputPass.Text;
            this.Database = this.InputDatabase.Text;
            CreatConnectString();
            this.DBFPath = this.InputDBFPath.Text;
            this.ImportStructFile = this.InputStructFile.Text;
        }

        private void StartImport_Click(object sender, EventArgs e)
        {
            Do_All();
        }

        private void btnCreatNew_Click(object sender, EventArgs e)
        {
            RefreshInfo();
            CreatConnectString();
            SqlConnection = new MySqlConnection(this.ConnectString);
            SqlTemp = new MySqlConnection(this.ConnectString);
            SqlConnection.Connect();
            SqlTemp.Connect();





            CreatDatabaseStructure();

            SqlConnection.ChangeDatabase(this.Database);
            SqlTemp.ChangeDatabase(this.Database);




            //TryZone

            //int abc = GetSqlOperationTypebyDBFOP_TYPE("2");
            //End of TryZone


            //DoList Below

            DDCertTypes();   //DDCertTypes_Init();
            DDCompanyInfo();
            DDCustomerInfo();
            DDFeeRate();
            DDPrintParam();


            DDSearchType();
            DDSearchOption();

            DDMesureUnit();//DDMesureUnit_Init();  //

            //权限表
            DDModules();
            DDRoles();
            //ReadDBFUserInfo();
            DDUsers();
            DDPermissions();
            //未处理DDNews();

            DDGeneralParemeters_Init();

            DDStatisticClass(); DDPawnageClass();
            //DDStatisticClass_Init();//处理中DDPawnageClass_Init();
            DDTicketStatus();
            PawnOperatTicket();

            RefreshOperationNumber();

            DDCarInfo();
            DDHouseInfo();

            //最后更新OperationID

            UpdateOperationNumber();

            RemoveDeleteOperation();

            SaveUserInfo();

            SqlConnection.DisConnect();
            SqlTemp.DisConnect();

            MessageBox.Show("Done!!");
        }


    }




    public partial class SqlQueryResult
    {
    }

    public partial class SqlConnectionResult
    {
    }

    public partial class MySqlConnection
    {
    }

    public partial class DBFQueryResult
    {
    }

    public partial class DBFConnectionResult
    {
    }

    public partial class MyDBFConnection
    {
    }


}
