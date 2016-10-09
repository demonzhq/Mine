using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace StockAnalyzer
{
    public partial class MainForm : Form
    {
        public static int ShortTerm = 5;
        public static int LongTerm = 50;


        public StockGroup Test;

        DirectoryInfo Dir = new DirectoryInfo(Application.StartupPath + @"\Stock");

        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Hashtable b = new Hashtable();
            double Result = 0;
            

            /*
            List<WareHouse> a = new List<WareHouse>();
            
            FileInfo[] Files = Dir.GetFiles();

            int count = Files.Length;

            this.pgbReadingProgress.Maximum = count;
            
            for (int i = 0; i < count; i++)
            {
                WareHouse ww = new WareHouse(100000000, new StockGroup("上证A股", Files[i].Name , Dir), 0.003);
                ww.Run(DateTime.Parse("2007.6.1"), DateTime.Now);

                Result = ww.GetProperty() / 100000000;

                a.Add(ww);
                b.Add(Files[i].Name, Result);
                pgbReadingProgress.Value = i;
                this.Refresh();
            }
            */
            
            
            WareHouse ww = new WareHouse(100000000, new StockGroup("上证A股", new string[] {"SH600376.TXT", "SH000001.TXT"}, Dir), 0.003);
            
            /*
            for (int j = 2; j < 10; j++)
            {
                MainForm.ShortTerm = j;
                for (int i = j + 1; i < 100; i++)
                {
                    MainForm.LongTerm = i;
                    ww.Run(DateTime.Parse("2009.5.1"), DateTime.Now);
                    Result = ww.GetProperty() / 100000000;
                    b.Add(i.ToString()+","+j.ToString(), Result);
                    ww.Clear();
                }
            }
            */

            
            MainForm.ShortTerm = 5; MainForm.LongTerm = 40;
            ww.Run(DateTime.Parse("2000.6.1"), DateTime.Now);
            Result = ww.GetProperty() / 100000000;
            b.Add(0, Result);
            
        
        }

        public void SetProgress(int Progress)
        {
            this.pgbReadingProgress.Value = Progress;
            this.lblProgress.Text = Progress.ToString();
        }
    }
}
