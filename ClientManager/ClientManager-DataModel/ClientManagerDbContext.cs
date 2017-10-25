using System.Data.Entity;
using System.Data.SQLite;
using ClientManager_Entities;

namespace ClientManager_DataModel
{
    class ClientManagerDbContext : DbContext
    {
        public ClientManagerDbContext()
            : base(new SQLiteConnection() { ConnectionString = @"data source=ClientManager.db" }, true)
        {

        }

        public DbSet<EntityUserLogin> UserLogins { get; set; }
        public DbSet<EntityPolicyHistory> PolicyHistories { get; set; }
    }
}