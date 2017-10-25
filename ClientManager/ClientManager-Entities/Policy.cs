using System.Collections.Generic;
using ClientManager_Dtos;

namespace ClientManager_Entities
{
    public class Policy
    {
        public Policy()
        {
            InventoryModules = new List<DtoInventoryModule>();
            UserLoginsModules = new List<DtoUserLoginsModule>();
            PrinterModules = new List<DtoPrinterModule>();
            SoftwareModules = new List<DtoSoftwareModule>();
            ScriptModules = new List<DtoScriptModule>();
            FileCopyModules = new List<DtoFileCopyModule>();
            CommandModules = new List<DtoCommandModule>();
        }
        public string Guid { get; set; }
        public int Frequeny { get; set; }
        public int Trigger { get; set; }
        public int SubFrequency { get; set; }
        public string Scope { get; set; }
        public string Hash { get; set; }
        public string CompletedAction { get; set; }
        public int Weight { get; set; }
        public List<DtoInventoryModule> InventoryModules { get; set; }
        public List<DtoUserLoginsModule> UserLoginsModules { get; set; }
        public List<DtoPrinterModule> PrinterModules { get; set; }
        public List<DtoSoftwareModule> SoftwareModules { get; set; }
        public List<DtoScriptModule> ScriptModules { get; set; }
        public List<DtoFileCopyModule> FileCopyModules { get; set; }
        public List<DtoCommandModule> CommandModules { get; set; } 
    }
}
