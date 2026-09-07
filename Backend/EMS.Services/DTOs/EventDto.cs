namespace EMS.Services.DTOs
{
    public class EventDto
    {
        public Guid EventId { get; set; }
        public string EventName { get; set; }
        public string EventCategory { get; set; }
        public DateTime EventDate { get; set; }
        public string Status { get; set; }

        public string ? Description { get; set; }
    }
}