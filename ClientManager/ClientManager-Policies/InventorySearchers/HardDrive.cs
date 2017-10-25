using ClientManager_Entities;

namespace ClientManager_Policies.InventorySearchers
{
    public class HardDrive : IInventorySearcher
    {
      
        public void Search(EntityInventoryCollection collection)
        {
            using (var wmi = new WMI<EntityHardDrive>(new EntityHardDrive()))
            {
                collection.HardDrives = wmi.GetObjectList();
              
            }
           

        }
    }
}
