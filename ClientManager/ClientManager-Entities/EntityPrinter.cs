namespace ClientManager_Entities
{
    public class EntityPrinter
    {
        public const string Query = "select * from Win32_Printer";
        public string Name { get; set; }
        public string DriverName { get; set; }
        public bool Local { get; set; }
        public bool Network { get; set; }
    }
}
