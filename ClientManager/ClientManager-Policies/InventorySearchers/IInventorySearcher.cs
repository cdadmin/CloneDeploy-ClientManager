using ClientManager_Entities;

namespace ClientManager_Policies.InventorySearchers
{
    public interface IInventorySearcher
    {
        void Search(EntityInventoryCollection collection);
    }
}