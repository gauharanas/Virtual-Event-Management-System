using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EMS.DAL.Models
{
    public class EventDetails
    {
        [Key]
        public Guid EventId { get; set; }

        [Required]
        [StringLength(50,MinimumLength =1)]
        public required string EventName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public required string EventCategory { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; }
        
        public string? Description { get; set; }

        [Required]
        public required string Status { get; set; }
    }
}
