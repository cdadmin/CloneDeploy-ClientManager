using System.Collections.Generic;

namespace ClientManager_Entities
{
    public class CheckinSetting
    {
        public CheckinSetting()
        {
            Policies = new List<Policy>(); 
        }
        public int CheckinTime { get; set; }
        public List<Policy> Policies { get; set; }
    }
}
