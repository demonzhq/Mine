using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace WIN32API
{
    public class Win32Api
    {

        public delegate bool CallBack(IntPtr hwnd, int lParam);

        [StructLayout(LayoutKind.Sequential)]
        public class POINT
        {
            public int x;
            public int y;
        }
        [StructLayout(LayoutKind.Sequential)]
        public class MouseHookStruct
        {
            public POINT pt;
            public int hwnd;
            public int wHitTestCode;
            public int dwExtraInfo;
        }

        public delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);
        //安装钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);
        //卸载钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(int idHook);
        //调用下一个钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(int idHook, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", EntryPoint = "WindowFromPoint")]//指定坐标处窗体句柄
        public static extern int WindowFromPoint(int xPoint, int yPoint);

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, string lParam);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        public static extern int AnyPopup();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        public static extern int EnumThreadWindows(IntPtr dwThreadId, CallBack lpfn, int lParam);

        [DllImport("user32.dll")]
        public static extern int EnumChildWindows(IntPtr hWndParent, CallBack lpfn, int lParam);

        [DllImport("user32.dll", CharSet = CharSet.Ansi)]
        public static extern IntPtr PostMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        [DllImport("user32.dll", CharSet = CharSet.Ansi)]
        public static extern IntPtr SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr SendMessageA(IntPtr hwnd, int wMsg, int wParam, int lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern IntPtr GetParent(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);



        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int Width, int Height, int flags);
        public enum SetWindowsPosFlags
        {
            SWP_ASYNCWINDOWPOS = 0x4000,
            SWP_DEFERERASE = 0x2000,
            SWP_DRAWFRAME = 0x0020,
            SWP_HIDEWINDOW = 0x0080,
            SWP_NOACTIVATE = 0x0010,
            SWP_NOCOPYBITS = 0x0100,
            SWP_NOMOVE = 0x0002,
            SWP_NOOWNERZORDER = 0x0200,
            SWP_NOREDRAW = 0x0008,
            SWP_NOREPOSITION = 0x0200,
            SWP_NOSENDCHANGING = 0x0400,
            SWP_NOSIZE = 0x0001,
            SWP_NOZORDER = 0x0004,
            SWP_SHOWWINDOW = 0x0040



        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);


        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int X, int Y);

        //设置鼠标按键和动作  
        [DllImport("user32.dll")]
        public static extern void mouse_event(MouseEventFlag flags, int dx, int dy, uint data, UIntPtr extraInfo); //UIntPtr指针多句柄类型  
        public enum MouseEventFlag : uint //设置鼠标动作的键值  
        {
            Move = 0x0001,               //发生移动  
            LeftDown = 0x0002,           //鼠标按下左键  
            LeftUp = 0x0004,             //鼠标松开左键  
            RightDown = 0x0008,          //鼠标按下右键  
            RightUp = 0x0010,            //鼠标松开右键  
            MiddleDown = 0x0020,         //鼠标按下中键  
            MiddleUp = 0x0040,           //鼠标松开中键  
            XDown = 0x0080,
            XUp = 0x0100,
            Wheel = 0x0800,              //鼠标轮被移动  
            VirtualDesk = 0x4000,        //虚拟桌面  
            Absolute = 0x8000
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;                             //最左坐标
            public int Top;                             //最上坐标
            public int Right;                           //最右坐标
            public int Bottom;                        //最下坐标
        }

        [DllImport("kernel32.dll")]
        public static extern uint GetLastError();
    }
}
