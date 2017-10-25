namespace ClientManager_Entities
{
    public class EntityOsInventory
    {
        public const string Query = "Select * From Win32_OperatingSystem";
        public string Name { get; set; }
        public string Version { get; set; }
        //public string ServicePack { get; set; }
        //public string Ram { get; set; }
    }
}
