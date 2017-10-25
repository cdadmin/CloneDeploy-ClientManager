using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientManager_Entities
{
    [Table("policy_history")]
    public class EntityPolicyHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("policy_history_id", Order = 1)]
        public int Id { get; set; }

        [Column("policy_guid", Order = 2)]
        public string PolicyGUID { get; set; }

        [Column("policy_hash", Order = 3)]
        public string PolicyHash { get; set; }

        [Column("last_run_time", Order = 4)]
        public long LastRunTime { get; set; }

        [Column("username", Order = 5)]
        public string Username { get; set; }
    }
}
