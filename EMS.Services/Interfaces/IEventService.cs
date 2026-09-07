using EMS.Services.DTOs;

namespace EMS.Services.Interfaces
{
    public interface IEventService
    {
        Task<IEnumerable<EventDto>> GetAllEventsAsync(int page, int pageSize);
        Task<string> CreateEvent(EventDto dto);
        Task<string> DeleteEvent(Guid id);

        Task<EventDto?> GetEventByIdAsync(Guid id);
        Task<string> UpdateEvent(EventDto dto);
    }
}