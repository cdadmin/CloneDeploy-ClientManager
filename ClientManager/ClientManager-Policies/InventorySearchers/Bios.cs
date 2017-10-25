using ClientManager_Entities;

namespace ClientManager_Policies.InventorySearchers
{
    public class Bios : IInventorySearcher
    {
        public void Search(EntityInventoryCollection collection)
        {
            using (var wmi = new WMI<EntityBiosInventory>(new EntityBiosInventory()))
            {
                collection.Bios = wmi.Execute();

            }
        }
    }
}
