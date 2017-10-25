using System.Collections.Generic;

namespace ClientManager_Entities
{
    public class EntityInventoryCollection
    {
        public EntityBiosInventory Bios { get; set; }
        public EntityComputerSystemInventory ComputerSystem { get; set; }
        public List<EntitySoftwareInventory> Software { get; set; }
        public EntityOsInventory Os { get; set; }
        public EntityProcessorInventory Processor { get; set; }
        public List<EntityHardDrive> HardDrives { get; set; }
        public List<EntityPrinter> Printers { get; set; } 
    }
}
