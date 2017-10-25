namespace ClientManager_Entities
{
    public class EntitySoftwareInventory
    {
        public const string Query = "Select * From Win32_Product";
        public string Name { get; set; }
        public string Version { get; set; }
        public string IdentifyingNumber { get; set; }
        
    }
}
