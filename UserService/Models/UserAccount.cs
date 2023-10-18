using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserService.Models
{
    [Table("User")]
    public class UserAccount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("UserId")]
        public int UserId { get; set; }
        [Column("FullName")]
        public string FullName { get; set; }
        [Column("UserName")]
        public string UserName { get; set; }
        [Column("Password")]
        public string Password { get; set; }
    }
}
