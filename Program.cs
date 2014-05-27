//////////////////////////////////////////////////////////
// Auto Screen Capture 2.0.5
// autoscreen.Program.cs
//
// Written by Gavin Kendall (gavinkendall@gmail.com)
// Thursday, 15 May 2008 - Wednesday, 27 November 2013

using System;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;

namespace autoscreen
{
    static class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var appGuid = "8E34A5BB-7381-45F5-BCEE-EF64174C2B75";
            using (var mutex = new Mutex(false, appGuid))
            {
                if (!mutex.WaitOne(0, false))
                    return;

                if (Environment.OSVersion.Version.Major >= 6)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new FormMain(args));
                }
            }
        }
    }
}
