using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class WindowTools
    {
        public static bool SetForegroundWindow(IntPtr hWnd)
        {
            return Win32API.SetForegroundWindow(hWnd);
        }

        public static bool SetWindowPosition(IntPtr hWnd, System.Drawing.Point pt)
        {
            return Win32API.SetWindowPos(hWnd, IntPtr.Zero, pt.X, pt.Y, 0, 0, Win32API.SetWindowPosFlags.NOSIZE | Win32API.SetWindowPosFlags.NOZORDER);
        }

        public static IntPtr FindWindowByClassName(string className)
        {
            return Win32API.FindWindow(className, null);
        }

        public static IntPtr FindWindowByWindowName(string windowName)
        {
            return Win32API.FindWindow(null, windowName);
        }

        private class Win32API
        {
            #region SetWindowPos
            static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
            static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
            static readonly IntPtr HWND_TOP = new IntPtr(0);
            static readonly IntPtr HWND_BOTTOM = new IntPtr(1);

            /// <summary>
            /// Window handles (HWND) used for hWndInsertAfter
            /// </summary>
            public static class hWndInsertAfterFlags
            {
                public static IntPtr
                NoTopMost = new IntPtr(-2),
                TopMost = new IntPtr(-1),
                Top = new IntPtr(0),
                Bottom = new IntPtr(1);
            }

            /// <summary>
            /// SetWindowPos Flags
            /// </summary>
            public static class SetWindowPosFlags
            {
                public static readonly int
                NOSIZE = 0x0001,
                NOMOVE = 0x0002,
                NOZORDER = 0x0004,
                NOREDRAW = 0x0008,
                NOACTIVATE = 0x0010,
                DRAWFRAME = 0x0020,
                FRAMECHANGED = 0x0020,
                SHOWWINDOW = 0x0040,
                HIDEWINDOW = 0x0080,
                NOCOPYBITS = 0x0100,
                NOOWNERZORDER = 0x0200,
                NOREPOSITION = 0x0200,
                NOSENDCHANGING = 0x0400,
                DEFERERASE = 0x2000,
                ASYNCWINDOWPOS = 0x4000;
            }

            [DllImport("user32.dll", SetLastError = true)]
            public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, int uFlags);
            #endregion

            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool SetForegroundWindow(IntPtr hWnd);

            [DllImport("user32.dll", SetLastError = true)]
            public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        }
    }
}
