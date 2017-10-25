using System;
using System.Collections.Generic;
using ClientManager_Dtos;
using ClientManager_Entities;
using ClientManager_Services;
using log4net;

namespace ClientManager_Policies
{
    public class PolicySelector
    {
        private readonly List<Policy> _policiesToRun;
       private readonly EnumPolicyInterval.Trigger _triggerType;
        private readonly PolicyHistoryServices _policyHistoryServices;
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly int _currentDayOfWeek;
        private readonly int _currentDayOfMonth;
        private readonly string _currentUser;

        public PolicySelector(EnumPolicyInterval.Trigger triggerType)
        {
            _triggerType = triggerType;
            _policiesToRun = new List<Policy>();
            _policyHistoryServices = new PolicyHistoryServices();
            _currentDayOfWeek = (int)DateTime.Now.DayOfWeek == 0 ? 7 : (int)DateTime.Now.DayOfWeek;
            _currentDayOfMonth = DateTime.Now.Day;
            _currentUser = Environment.UserName;
        }

        public CheckinSetting GetPoliciesToExecute()
        {
            var checkin = GetPolicies(_triggerType);
            foreach (var policy in checkin.Policies)
            {
                switch (policy.Scope)
                {
                    case "Computer":
                        var policyHistory = _policyHistoryServices.GetLastPolicyRun(policy.Hash);
                        switch (policy.Frequeny)
                        {
                            case (int) EnumPolicyInterval.Frequency.Ongoing:
                                _policiesToRun.Add(policy);
                                break;
                            case (int) EnumPolicyInterval.Frequency.OncePerComputer:
                                OncePerComputer(policy,policyHistory);
                                break;

                            case (int) EnumPolicyInterval.Frequency.OncePerDay:
                                OncePerDay(policy,policyHistory);
                                break;

                            case (int) EnumPolicyInterval.Frequency.OncePerWeek:
                                OncePerWeek(policy,policyHistory);
                                break;

                            case (int) EnumPolicyInterval.Frequency.OncePerMonth:
                                OncePerMonth(policy,policyHistory);
                                break;
                        }
                        break;
                    case "User":
                        var policyHistoryUser = _policyHistoryServices.GetLastPolicyRunForUser(policy.Hash,_currentUser);
                        switch (policy.Frequeny)
                        {
                            case (int)EnumPolicyInterval.Frequency.Ongoing:
                                _policiesToRun.Add(policy);
                                break;
                            case (int)EnumPolicyInterval.Frequency.OncePerUserPerComputer:
                                OncePerComputerPerUser(policy, policyHistoryUser);
                                break;
                        }
                        break;
                    default:
                        throw new Exception("Policy scope not defined");
                }
            }
            var checkinResult = new CheckinSetting();
            checkinResult.CheckinTime = checkin.CheckinTime;
            checkinResult.Policies = _policiesToRun;
            return checkinResult;
        }



        private void OncePerComputer(Policy policy, EntityPolicyHistory history)
        {

            if (history == null)
                _policiesToRun.Add(policy);
        }

        private void OncePerDay(Policy policy, EntityPolicyHistory history)
        {

            if (history == null)
            {
                _policiesToRun.Add(policy);
            }
            else
            {
                AddPolicyTimeConditional(86400, history.LastRunTime, policy);
            }
        }

        private void OncePerWeek(Policy policy, EntityPolicyHistory history)
        {

            if (history == null)
            {
                if (policy.SubFrequency == _currentDayOfWeek)
                    _policiesToRun.Add(policy);
            }
            else
            {
                AddPolicyTimeConditional(604800, history.LastRunTime, policy);
            }
        }

        private void OncePerMonth(Policy policy, EntityPolicyHistory history)
        {

            if (history == null)
            {
                if (policy.SubFrequency == _currentDayOfMonth)
                    _policiesToRun.Add(policy);
            }
            else
            {
                AddPolicyTimeConditional(2592000, history.LastRunTime, policy);
            }

        }
    

        private void OncePerComputerPerUser(Policy policy, EntityPolicyHistory history)
        {
            if (history == null)
                _policiesToRun.Add(policy);
        }


        private void AddPolicyTimeConditional(int timeInSeconds, long lastRunTime, Policy policy)
        {
            try
            {
                var currentTime = ToUnixTime(DateTime.UtcNow);
                if (currentTime - lastRunTime > timeInSeconds)
                {
                    _policiesToRun.Add(policy);
                }
            }
            catch (Exception)
            {
                Logger.Error("Could Not Run Policy " + policy.Guid + " Could Not Parse Last Known Run Time");
            }
        }


        public static DateTime FromUnixTime(long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime);
        }

        public static long ToUnixTime(DateTime date)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return Convert.ToInt64((date.ToUniversalTime() - epoch).TotalSeconds);
        }


        private CheckinSetting GetPolicies(EnumPolicyInterval.Trigger triggerType)
        {
            //todo change to api call
            //for now seeded for development

 
            var checkinSetting = new CheckinSetting();
            checkinSetting.CheckinTime = 60;
            checkinSetting.Policies = Seed();
            return checkinSetting;
        }

        private List<Policy> Seed()
        {
            var policyList = new List<Policy>();
            var policy = new Policy();
            policy.Guid = "Guid-1";
            policy.Hash = "Hash-1";
            policy.Frequeny = (int) EnumPolicyInterval.Frequency.Ongoing;
            policy.Trigger = (int) EnumPolicyInterval.Trigger.Startup;
            policy.Scope = "Computer";
            policy.Weight = 100;
            policy.CompletedAction = "Nothing";
            var inventorymodule = new DtoInventoryModule();
            inventorymodule.DisplayName = "Test";
            inventorymodule.Order = 1;
            policy.InventoryModules.Add(inventorymodule);
            policyList.Add(policy);
            return policyList;

        }



     
    }
}
