using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneStoreManagement.Entity.Entities
{
    public class AppUser
    {
        [Key]
        public int AppUserId { get; set; }

        [Required]
        [MaxLength(10)]
        public string EmployeeCode { get; set; } = null!; // NV001

        [Required]
        [MaxLength(150)]
        public string FullName { get; set; } = null!;

        [MaxLength(20)]
        public string? Phone { get; set; }

        [MaxLength(150)]
        public string? HomeTown { get; set; }

        [MaxLength(150)]
        public string? Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; } = null!;

        [Required]
        [MaxLength(256)]
        public string PasswordHash { get; set; } = null!;

        [Required]
        public int AppRoleId { get; set; }

        public bool IsActive { get; set; } = true;
        public AppRole AppRole { get; set; } = null!;
    }
}
