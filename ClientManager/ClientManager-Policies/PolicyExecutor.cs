using System;
using System.Collections.Generic;
using System.Linq;
using ClientManager_Entities;
using ClientManager_Policies.Modules;
using log4net;

namespace ClientManager_Policies
{
    public class PolicyExecutor
    {
        private readonly List<Policy> _policiesToExecute;
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public PolicyExecutor(List<Policy> policiesToExecute )
        {
            _policiesToExecute = policiesToExecute;
        }


        public void Execute()
        {
            var moduleOrder = GetPolicyModuleOrder();
            foreach (var order in moduleOrder)
            {
                foreach (var policy in _policiesToExecute)
                {
                    Logger.Info(String.Format("Running Policy {0}",policy.Guid));
                    foreach (var module in policy.InventoryModules)
                    {
                        if (module.Order == order)
                        {
                            new ModuleInventory().Run(module);
                        }
                    }
                    foreach (var module in policy.UserLoginsModules)
                    {
                        if (module.Order == order)
                        {
                            new ModuleUserLogins().Run(module);
                        }
                    }
                    foreach (var module in policy.SoftwareModules)
                    {
                        if (module.Order == order)
                        {
                            new ModuleSoftwareManager().Run(module);
                        }
                    }
                    foreach (var module in policy.ScriptModules)
                    {
                        if (module.Order == order)
                        {
                            new ModuleScriptManager().Run(module);
                        }
                    }
                    foreach (var module in policy.PrinterModules)
                    {
                        if (module.Order == order)
                        {
                            new ModulePrintManager().Run(module);
                        }
                    }
                    foreach (var module in policy.FileCopyModules)
                    {
                        if (module.Order == order)
                        {
                            new ModuleFileCopy().Run(module);
                        }
                    }
                    foreach (var module in policy.CommandModules)
                    {
                        if (module.Order == order)
                        {
                            new ModuleCommandManager().Run(module);
                        }
                    }
                    Logger.Info(String.Format("Finished Policy {0}", policy.Guid));
                }
            }

        }

        private List<int> GetPolicyModuleOrder()
        {
            var list = new List<int>();
            foreach (var policy in _policiesToExecute)
            {
                list.AddRange(policy.InventoryModules.Select(module => module.Order));
                list.AddRange(policy.UserLoginsModules.Select(module => module.Order));
                list.AddRange(policy.PrinterModules.Select(module => module.Order));
                list.AddRange(policy.SoftwareModules.Select(module => module.Order));
                list.AddRange(policy.ScriptModules.Select(module => module.Order));
                list.AddRange(policy.FileCopyModules.Select(module => module.Order));
                list.AddRange(policy.CommandModules.Select(module => module.Order));
            }
            list.Sort();
            return list;
        }
    }
}
