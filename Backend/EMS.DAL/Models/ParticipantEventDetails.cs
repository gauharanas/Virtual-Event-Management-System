using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EMS.DAL.Models
{
    public class ParticipantEventDetails
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [EmailAddress]
        public required string ParticipantEmailId { get; set; }

        [Required]
        public Guid EventId { get; set; }

        public bool IsAttended { get; set; }

        
        [ForeignKey("ParticipantEmailId")]
        public UserInfo? User { get; set; }

        [ForeignKey("EventId")]
        public EventDetails? Event { get; set; }
    }
}
