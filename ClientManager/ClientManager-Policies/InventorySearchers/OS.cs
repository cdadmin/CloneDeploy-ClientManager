using ClientManager_Entities;

namespace ClientManager_Policies.InventorySearchers
{
    public class Os : IInventorySearcher
    {
       

        public void Search(EntityInventoryCollection collection)
        {
            using (var wmi = new WMI<EntityOsInventory>(new EntityOsInventory()))
            {
                collection.Os = wmi.Execute();

            }
        }
    }
}
