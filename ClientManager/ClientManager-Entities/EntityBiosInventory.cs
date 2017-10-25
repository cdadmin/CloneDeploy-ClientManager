namespace ClientManager_Entities
{
    public class EntityBiosInventory
    {
        public const string Query = "Select * From Win32_BIOS";
        public string SerialNumber { get; set; }
        public string Version { get; set; }
        public string SMBIOSBIOSVersion { get; set; }
    }
}
