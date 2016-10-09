using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace DianDang
{
    class CardRecognise
    {
        [StructLayout(LayoutKind.Sequential,CharSet=CharSet.Unicode,Pack=4)]
        public struct PERSONINFOW
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string name;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
            public string sex;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
            public string nation;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
            public string birthday;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 36)]
            public string address;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
            public string cardId;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string police;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
            public string validStart;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
            public string validEnd;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
            public string sexCode;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
            public string nationCode;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 36)]
            public string appendMsg;
        }
        [DllImport("cardapi2.dll",EntryPoint="OpenCardReader",
            CallingConvention=CallingConvention.StdCall,CharSet=CharSet.Unicode)]
        public static extern Int32 OpenCardReader(Int32 lPort, UInt32 ulFlag);
        [DllImport("cardapi2.dll", EntryPoint = "GetPersonMsgW",
            CallingConvention=CallingConvention.StdCall,CharSet=CharSet.Unicode)]
        public static extern Int32 GetPersonMsgW(ref PERSONINFOW pInfo, string pszImageFile);
        [DllImport("cardapi2.dll", EntryPoint = "CloseCardReader",
            CallingConvention=CallingConvention.StdCall,CharSet=CharSet.Unicode)]
        public static extern Int32 CloseCardReader();

    }
}
