using System;
using System.ServiceProcess;
using ClientManager_Policies;
using log4net;
using log4net.Repository.Hierarchy;
using Microsoft.Owin.Hosting;

namespace ClientManager.ServiceHost
{
    partial class Host : ServiceBase
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private IDisposable _server = null;
        public Host()
        {
            InitializeComponent();
        }

        public void ManualStart()
        {
            OnStart(new string[0]);
        }

        public void ManualStop()
        {
            OnStop();
        }


        protected override void OnStart(string[] args)
        {
            Logger.Info("Starting ClientManager Service");
            string baseAddress = "http://*:9000/";
            _server = WebApp.Start<Startup>(url: baseAddress);
            new PolicyRunner().Startup();           
        }

        protected override void OnStop()
        {
            if (_server != null)
            {
                _server.Dispose();
            }
            base.OnStop();
        }
    }
}
