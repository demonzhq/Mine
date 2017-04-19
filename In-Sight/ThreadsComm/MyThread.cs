using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadsComm
{
    public delegate void ReadParamEventHandler(string sParam);
    class MyThread
    {
        public Thread thread1;
        private static ReadParamEventHandler OnReadParamEvent;
        public MyThread()
        {
            thread1 = new Thread(new ThreadStart(MyRead));
            thread1.IsBackground = true;
            thread1.Start();
        }
        public event ReadParamEventHandler ReadParam      
        {
            add { OnReadParamEvent += new ReadParamEventHandler(value); }
            remove { OnReadParamEvent -= new ReadParamEventHandler(value); }
        }
        
        protected void MyRead()
        {
            int i = 0;
            while (true)
            {
                Thread.Sleep(1000);
                i = i + 1;
                OnReadParamEvent(i.ToString());//触发事件  
            }
        }
    }
}
