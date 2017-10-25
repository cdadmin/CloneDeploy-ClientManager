namespace ClientManager_Entities
{
    public class EnumPolicyInterval
    {
        public enum Frequency
        {
            Ongoing,
            OncePerComputer,
            OncePerUserPerComputer,
            OncePerDay,
            OncePerWeek,
            OncePerMonth
        }

        public enum Trigger
        {
            Startup,
            Login,
            Checkin,
        }
    }
}
