using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EMS.DAL.Models
{
    public class UserInfo
    {
        [Key]
        [EmailAddress]
        public required string EmailId { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength =1)]
        public required string UserName { get; set; }

        [Required]
        public required string Role { get; set; } // Admin / Participant

        [Required]
        [StringLength(20, MinimumLength = 6)]
        public required string Password { get; set; }
    }
}
