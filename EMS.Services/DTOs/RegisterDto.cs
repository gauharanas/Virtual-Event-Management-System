using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace EMS.Services.DTOs
{
    public class RegisterDto
    {
        [Required]
        [EmailAddress]
        public string EmailId { get; set; }
      
        [Required]
        public string UserName { get; set; }
        
        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }
    }
}