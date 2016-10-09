using System.IO;

namespace DataImport
{
    public partial class Main
    {
        private void CreatDatabaseStructure()
        {
            FileStream StructFile = new FileStream(this.ImportStructFile, FileMode.Open);
            StreamReader FileReader = new StreamReader(StructFile);
            int ExecResult = 0;
            string ExecString = "";

            ExecString = "create database " + this.Database;
            ExecResult = SqlConnection.Exec(ExecString);
            SqlConnection.ChangeDatabase(this.Database);
            ExecString = FileReader.ReadToEnd();
            StructFile.Close();
            ExecResult = SqlConnection.Exec(ExecString);
        }
    }
}