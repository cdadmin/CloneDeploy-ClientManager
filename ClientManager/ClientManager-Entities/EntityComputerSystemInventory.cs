using System;

namespace ClientManager_Entities
{
    public class EntityComputerSystemInventory
    {     
        public const string Query = "select * from Win32_ComputerSystem";
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Name { get; set; }
        public string Domain { get; set; }
        public string Workgroup { get; set; }
        public UInt64 TotalPhysicalMemory { get; set; }
    }
}
