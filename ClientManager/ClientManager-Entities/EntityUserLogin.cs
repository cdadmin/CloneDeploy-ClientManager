using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientManager_Entities
{
    [Table("user_logins")]
    public class EntityUserLogin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("user_login_id", Order = 1)]
        public int Id { get; set; }

        [Column("username", Order = 2)]
        public string UserName { get; set; }

        [Column("type", Order = 3)]
        public string Type { get; set; }

        [Column("date_time", Order = 4)]
        public string DateTime { get; set; }
    }
}
