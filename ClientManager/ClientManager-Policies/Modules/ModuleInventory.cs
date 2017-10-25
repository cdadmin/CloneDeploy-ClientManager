using System;
using System.Linq;
using System.Reflection;
using ClientManager_Dtos;
using ClientManager_Entities;
using ClientManager_Policies.InventorySearchers;
using log4net;

namespace ClientManager_Policies.Modules
{
    class ModuleInventory
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public void Run(DtoInventoryModule module)
        {
            Logger.Info("Running Inventory Module");
            var collection = new EntityInventoryCollection();
            var instances = from t in Assembly.GetExecutingAssembly().GetTypes()
                            where t.GetInterfaces().Contains(typeof(IInventorySearcher))
                                     && t.GetConstructor(Type.EmptyTypes) != null
                            select Activator.CreateInstance(t) as IInventorySearcher;

           
            foreach (var instance in instances)
            {
                instance.Search(collection);
                //Thread thread = new Thread(() => instance.Search(collection));
                //thread.Start();
            }

           
            
          
            
        }
    }
}
