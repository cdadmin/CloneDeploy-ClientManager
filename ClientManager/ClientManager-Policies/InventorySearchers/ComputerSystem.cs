using ClientManager_Entities;

namespace ClientManager_Policies.InventorySearchers
{
    public class ComputerSystem : IInventorySearcher
    {
        public void Search(EntityInventoryCollection collection)
        {
            using (var wmi = new WMI<EntityComputerSystemInventory>(new EntityComputerSystemInventory()))
            {
                collection.ComputerSystem = wmi.Execute();
               
            }
        }
    }
}
