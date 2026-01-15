using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStoreManagement.Domain.Entities
{
    public class AppAdminAccount
    {
        [Key]
        public int AdminId { get; set; }

        [Required, MaxLength(50)]
        public string Username { get; set; } = null!;

        [Required, MaxLength(256)]
        public string PasswordHash { get; set; } = null!;

        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }

}
