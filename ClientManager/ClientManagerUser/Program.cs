using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientManager_Policies;
using Microsoft.Owin.Hosting;

namespace ClientManagerUser
{
    class Program
    {
        public static NotifyIcon tray = new NotifyIcon();
        static void Main(string[] args)
        {
            tray.Icon = new Icon("./logo.ico");
            tray.Visible = true;

            string baseAddress = "http://localhost:12001/";
            WebApp.Start<Startup>(url: baseAddress);
            new PolicyRunner().Login();           
            Console.Read();
        }

        public static void ShowTrayMessage(string message)
        {
            // Display for 5 seconds.
            tray.BalloonTipText = message;
            tray.ShowBalloonTip(0);
            tray.Dispose();
        }
    }
}
