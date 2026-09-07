using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EMS.DAL.Models
{
    public class SpeakersDetails
    {
        [Key]
        public Guid SpeakerId { get; set; }

        [Required]
        [StringLength(50,MinimumLength =1)]
        public required string SpeakerName { get; set; }
    }

}
