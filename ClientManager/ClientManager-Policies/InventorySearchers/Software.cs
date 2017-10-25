using ClientManager_Entities;

namespace ClientManager_Policies.InventorySearchers
{
    public class Software : IInventorySearcher
    {
      
        public void Search(EntityInventoryCollection collection)
        {
            using (var wmi = new WMI<EntitySoftwareInventory>(new EntitySoftwareInventory()))
            {
                collection.Software = wmi.GetObjectList();
              
            }
           

        }
    }
}
