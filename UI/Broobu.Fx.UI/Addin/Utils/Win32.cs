using System;
using System.Runtime.InteropServices;

namespace Broobu.Fx.UI.Addin.Utils
{
    public static class Win32
    {
        public const int
            GWL_STYLE = -16,
            VK_SHIFT = 0x10,
            VK_CONTROL = 0x11,
            VK_MENU = 0x12;

        public const uint
            WS_CHILD = 0x40000000,
            WS_CLIPCHILDREN = 0x02000000,
            SWP_FRAMECHANGED = 0x0020,
            SWP_NOSIZE = 0x0001,
            SWP_NOMOVE = 0x0002,
            SWP_NOZORDER = 0x0004,
            SWP_NOACTIVATE = 0x10,
            SWP_ASYNCWINDOWPOS = 16384,
            WM_KEYFIRST = 0x0100,
            WM_KEYDOWN = 0x0100,
            WM_KEYUP = 0x0101,
            WM_CHAR = 0x0102,
            WM_DEADCHAR = 0x0103,
            WM_SYSKEYDOWN = 0x0104,
            WM_SYSKEYUP = 0x0105,
            WM_SYSCHAR = 0x0106,
            WM_SYSDEADCHAR = 0x0107,
            WM_KEYLAST = 0x0108,
            WM_IME_STARTCOMPOSITION = 0x010D,
            WM_IME_ENDCOMPOSITION = 0x010E,
            WM_IME_COMPOSITION = 0x010F,
            WM_IME_KEYLAST = 0x010F;

        [DllImport("user32.dll")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool DestroyWindow(IntPtr hwnd);

        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);

        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy,
            uint uFlags);

        public static void ConvertToChildWindow(IntPtr hwnd)
        {
            SetWindowLong(hwnd, GWL_STYLE, WS_CHILD | WS_CLIPCHILDREN);
            SetWindowPos(hwnd, IntPtr.Zero, 0, 0, 0, 0, SWP_FRAMECHANGED | SWP_NOMOVE | SWP_NOSIZE | SWP_NOZORDER);
        }
    };
}