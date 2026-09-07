using EMS.DAL.DataAccess.Interfaces;
using EMS.DAL.Models;
using EMS.Services.DTOs;
using EMS.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace EMS.Services.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _repo;

        //private readonly IMemoryCache _cache;

        public EventService(IEventRepository repo)
        {
            _repo = repo;
            //_cache = cache;
        }

        public async Task<IEnumerable<EventDto>> GetAllEventsAsync(int page, int pageSize)
                {
                    var events =
                        await _repo.GetAllEventsAsync(page, pageSize);

                    return events.Select(e =>
                        new EventDto
                        {
                            EventId = e.EventId,
                            EventName = e.EventName,
                            EventCategory = e.EventCategory,
                            EventDate = e.EventDate,
                            Status = e.Status,
                            Description = e.Description
                        });
                }
        public async Task<string> CreateEvent(EventDto dto)
        {
            var entity = new EventDetails
            {
                EventId = Guid.NewGuid(),
                EventName = dto.EventName,
                EventCategory = dto.EventCategory,
                EventDate = dto.EventDate,
                Status = dto.Status,
                Description = dto.Description,

            };

            await _repo.AddEventAsync(entity);

            return "Event created successfully";
        }

        public async Task<string> DeleteEvent(Guid id)
        {
            var eventData = await _repo.GetEventByIdAsync(id);

            if (eventData == null)
                return "Event not found";

            await _repo.DeleteEventAsync(id);

            return "Event deleted successfully";
        }

        public async Task<string> UpdateEvent(EventDto dto)
        {
            var existing = await _repo.GetEventByIdAsync(dto.EventId);

            if (existing == null)
                return "Event not found";

            //  Update fields
            existing.EventName = dto.EventName;
            existing.EventCategory = dto.EventCategory;
            existing.EventDate = dto.EventDate;
            existing.Status = dto.Status;
            existing.Description = dto.Description;

            await _repo.UpdateEventAsync(existing);

            return "Event updated successfully";
        }

        public async Task<EventDto?> GetEventByIdAsync(Guid id)
        {
            var eventEntity =
                await _repo.GetEventByIdAsync(id);

            if (eventEntity == null)
            {
                return null;
            }

            return new EventDto
            {
                EventId = eventEntity.EventId,
                EventName = eventEntity.EventName,
                EventCategory = eventEntity.EventCategory,
                EventDate = eventEntity.EventDate,
                Status = eventEntity.Status,
                Description = eventEntity.Description
            };
        }
    }
}