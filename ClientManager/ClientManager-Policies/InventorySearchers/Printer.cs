using ClientManager_Entities;

namespace ClientManager_Policies.InventorySearchers
{
    public class Printer : IInventorySearcher
    {
      
        public void Search(EntityInventoryCollection collection)
        {
            using (var wmi = new WMI<EntityPrinter>(new EntityPrinter()))
            {
                collection.Printers = wmi.GetObjectList();
              
            }
           

        }
    }
}
