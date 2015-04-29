using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SupermarketKata
{
    /// <summary>
    /// The Main entry point to the application
    /// </summary>
    static class Program
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern int ShowWindow(IntPtr hWnd, uint Msg);

        private const int SW_RESTORE = 9;
        private const uint SW_RESTORE_HEX = 0x09;

        /// <summary>
        /// The initial method that is executed when starting the application
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Instead of opening multiple instances of the app, it focuses the currently open one
            bool createdNew = true;
            using (Mutex mutex = new Mutex(true, "SupermarketKata", out createdNew))
            {
                // if application isn't currently running, create a new instance of the main form
                if (createdNew)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new MainForm());
                }
                else
                {
                    Process current = Process.GetCurrentProcess();
                    Process[] thisProgram = Process.GetProcessesByName(current.ProcessName);

                    for (int i = 0; i < thisProgram.Length; i++)
                    {
                        if (thisProgram[i].Id != current.Id)
                        {
                            SetForegroundWindow(thisProgram[i].MainWindowHandle);

                            try
                            {
                                ShowWindowAsync(thisProgram[i].MainWindowHandle, SW_RESTORE);
                                ShowWindow(thisProgram[i].MainWindowHandle, SW_RESTORE_HEX);

                                ShowWindowAsync(thisProgram[i].Handle, SW_RESTORE);
                                ShowWindow(thisProgram[i].Handle, SW_RESTORE_HEX);

                                SetForegroundWindow(thisProgram[i].MainWindowHandle);
                            }
                            catch { }

                            break;
                        }
                    }
                }
            }
        }
    }
}
