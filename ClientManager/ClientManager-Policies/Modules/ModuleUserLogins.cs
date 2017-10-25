using System;
using System.Globalization;
using System.Timers;
using ClientManager_Dtos;
using ClientManager_Entities;
using ClientManager_Services;
using log4net;

namespace ClientManager_Policies.Modules
{
    class ModuleUserLogins
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static System.Timers.Timer _timer;
        private static readonly object ObjectLock = new object();
        public void Run(DtoUserLoginsModule module)
        {
            _timer = new System.Timers.Timer(2000);
            _timer.Elapsed += OnTimedEvent;
            _timer.Interval = 10000;
            _timer.Enabled = true;
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            lock (ObjectLock)
            {
                var users = new ServiceUserLogins().GetUsersLoggedIn();
                foreach (var user in users)
                {
                    Console.WriteLine(user);
                    var en = new EntityUserLogin();
                    en.Type = "login";
                    en.UserName = user;
                    en.DateTime = DateTime.Now.ToString(CultureInfo.InvariantCulture);
                }
            }
            
        }   
    }
}
