using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientManager_Policies;
using Microsoft.Owin.Hosting;

namespace ClientManagerTray
{
    static class Program
    {
        public static NotifyIcon trayIcon = new NotifyIcon();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool createdNew = true;
            System.Threading.Thread.Sleep(1000);
            using (new Mutex(true, "ClientManagerTray", out createdNew))
            {

                if (createdNew)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                             
                    

                    trayIcon.Icon = new Icon("./logo.ico");
                    trayIcon.Visible = true;

                    string baseAddress = "http://localhost:12001/";
                    WebApp.Start<Startup>(url: baseAddress);
                    new PolicyRunner().Login();
                    Application.Run();
                }
                else
                    MessageBox.Show(@"ClientManager Tray Is Already Running");
            }

        
        }

        public static void ShowTrayMessage(string message)
        {
            // Display for 5 seconds.
            trayIcon.BalloonTipTitle = @"CloneDeploy";
            trayIcon.BalloonTipText = message;
            trayIcon.ShowBalloonTip(60);
          
        }
    }
}
