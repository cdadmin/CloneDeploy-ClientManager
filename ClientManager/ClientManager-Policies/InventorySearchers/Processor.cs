using ClientManager_Entities;

namespace ClientManager_Policies.InventorySearchers
{
    public class Processor : IInventorySearcher
    {
        public void Search(EntityInventoryCollection collection)
        {
            using (var wmi = new WMI<EntityProcessorInventory>(new EntityProcessorInventory()))
            {
                collection.Processor = wmi.Execute();

            }
        }
    }
}
