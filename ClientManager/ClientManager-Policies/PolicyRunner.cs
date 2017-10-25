using System;
using System.Timers;
using ClientManager_Entities;
using log4net;

namespace ClientManager_Policies
{
    public class PolicyRunner
    {
        private System.Timers.Timer _checkinTimer;
        private System.Timers.Timer _startupRetryTime;
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void Startup()
        {
            Logger.Info("Checking For Startup Policies");
            var result = new PolicySelector(EnumPolicyInterval.Trigger.Startup).GetPoliciesToExecute();
            if (result.CheckinTime != 0)
            {
                Logger.Info(String.Format("Check In Time Set To {0}",result.CheckinTime));
                _checkinTimer = new System.Timers.Timer(result.CheckinTime*1000);
                _checkinTimer.Elapsed += RecurringCheckin;
                _checkinTimer.Enabled = true;           
                new PolicyExecutor(result.Policies).Execute();
            }
            else
            {
                Logger.Error("Checkin Failed.  Trying Again In 5 Minutes");
                //start a timer to try and check in very 5 minutes if checkin failed
                _startupRetryTime = new System.Timers.Timer(300 * 1000);
                _startupRetryTime.Elapsed += StartupRetry;
                _startupRetryTime.Enabled = true;    
            }
          
        }

        public void Login()
        {
            var result = new PolicySelector(EnumPolicyInterval.Trigger.Login).GetPoliciesToExecute();
            new PolicyExecutor(result.Policies).Execute();
        }

        private void RecurringCheckin(object source, ElapsedEventArgs e)
        {
            Logger.Info("Checking For Policies");
            var result = new PolicySelector(EnumPolicyInterval.Trigger.Checkin).GetPoliciesToExecute();
            new PolicyExecutor(result.Policies).Execute();
        }

        private void StartupRetry(object source, ElapsedEventArgs e)
        {
            var result = new PolicySelector(EnumPolicyInterval.Trigger.Startup).GetPoliciesToExecute();
            if (result.CheckinTime != 0)
            {
                _checkinTimer = new System.Timers.Timer(result.CheckinTime * 1000);
                _checkinTimer.Elapsed += RecurringCheckin;
                _checkinTimer.Enabled = true;
                _startupRetryTime.Stop();
                _startupRetryTime.Enabled = false;
                new PolicyExecutor(result.Policies).Execute();
            }
            else
            {
                Logger.Error("Checkin Failed.  Trying Again In 5 Minutes");
            }
        }


    


      


     

      
    }
}
