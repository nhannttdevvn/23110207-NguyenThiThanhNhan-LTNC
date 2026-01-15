using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneStoreManagement.Entity.Entities
{
    [Table("AppRoles", Schema = "dbo")]
    public class AppRole
    {
        [Key]
        public int AppRoleId { get; set; }

        [Required]
        [MaxLength(100)]
        public string RoleName { get; set; } = "";

        public ICollection<AppUser> Users { get; set; } = new List<AppUser>();
    }
}
