using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;

namespace Limitation.Helpers
{
    internal sealed class ClipboardMonitor : NativeWindow
    {
        public event EventHandler ClipboardChanged;

        public ClipboardMonitor(Window window)
        {
            var helper = new WindowInteropHelper(window);
            if (helper.Handle == IntPtr.Zero)
                helper.EnsureHandle();

            this.m_handle = helper.Handle;

            this.AssignHandle(this.m_handle);
            NativeMethods.AddClipboardFormatListener(this.m_handle);
        }

        public override void ReleaseHandle()
        {
            NativeMethods.RemoveClipboardFormatListener(this.Handle);
            base.ReleaseHandle();
        }

        private readonly IntPtr m_handle;

        //private const int WM_CLIPBOARDUPDATE = 0x031D;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x031D) //WM_CLIPBOARDUPDATE
                if (this.ClipboardChanged != null)
                    this.ClipboardChanged.Invoke(this, new EventArgs());

            base.WndProc(ref m);
        }

        private static class NativeMethods
        {
            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool AddClipboardFormatListener(IntPtr hwnd);

            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool RemoveClipboardFormatListener(IntPtr hwnd);
        }
    }
}
