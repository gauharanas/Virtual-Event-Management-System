namespace EMS.Services.DTOs
{
    public class AssignSpeakerDto
    {
        public Guid SessionId { get; set; }

        public Guid SpeakerId { get; set; }
    }
}