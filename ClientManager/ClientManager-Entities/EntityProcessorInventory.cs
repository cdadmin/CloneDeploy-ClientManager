using System;

namespace ClientManager_Entities
{
    public class EntityProcessorInventory
    {
        public const string Query = "Select * From Win32_Processor";
        public string Name { get; set; }
        public UInt32 MaxClockSpeed { get; set; }
        public UInt32 NumberOfCores { get; set; }
    }
}
