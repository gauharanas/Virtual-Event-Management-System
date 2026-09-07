using EMS.DAL.Models;

namespace EMS.DAL.DataAccess.Interfaces
{
    public interface IParticipantEventRepository
    {
        Task RegisterEventAsync(ParticipantEventDetails pe);
        Task<IEnumerable<ParticipantEventDetails>> GetRegisteredEventsAsync(string email);
        Task<bool> IsAlreadyRegistered(string email, Guid eventId);

        Task MarkAttendanceAsync(Guid id);
    }
}