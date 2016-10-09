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
        private string CutSpace(string theString)
        {
            string FinalReturn = "";
            string Sub="";
            for (int i = 0; i < theString.Length; i++)
            {
                Sub = theString.Substring(i,1);
                if (Sub != " ")
                    FinalReturn = FinalReturn + Sub;
            }
            return FinalReturn;

        }

        private void CreatConnectString()
        {
            //Server
            this.ConnectString += "Data Source=";
            this.ConnectString += this.Server;
            this.ConnectString += ";";
            //Init Database
            //this.ConnectString += "Initial Catalog=";
            //this.ConnectString += this.Database;
            //this.ConnectString += ";";
            //Password Needed
            this.ConnectString += "Persist Security Info=True;Asynchronous Processing=true;";
            //User ID
            this.ConnectString += "User ID=";
            this.ConnectString += this.User;
            this.ConnectString += ";";
            //Password
            this.ConnectString += "Password=";
            this.ConnectString += this.Pass;
            this.ConnectString += ";";
        }

        private string ChangeDateFormat(string OldDate)
        {
            string NewDate = "";
            string Sub = "";
            for (int i = 0; i < OldDate.Length; i++)
            {
                Sub = OldDate.Substring(i, 1);
                if (Sub != "/")
                {
                    NewDate = NewDate + Sub;
                }
                else NewDate = NewDate + "-";
            }
            return NewDate;
        }

        private string FormatParmValue(int theValue)
        {
            int Length = 9;
            string Value = "";
            string Number = theValue.ToString();
            for (int i = 0; i < (Length - Number.Length); i++)
            {
                Value = Value + "0";
            }
            Value = Value + Number;
            return Value;
        }

        private double FormatDigital(double theValue, int theLength)
        {
            return Math.Round(theValue, theLength, MidpointRounding.AwayFromZero);
        }
    }

}