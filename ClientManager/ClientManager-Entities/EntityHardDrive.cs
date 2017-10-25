using System;

namespace ClientManager_Entities
{
    public class EntityHardDrive
    {
        public const string Query = "select * from Win32_DiskDrive where size > 0 AND MediaLoaded = TRUE";
        public string Model { get; set; }
        public string FirmwareRevision { get; set; }
        public string SerialNumber { get; set; }
        public UInt64 Size { get; set; }
        public string Status { get; set; }
    }
}
