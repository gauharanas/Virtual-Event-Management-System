using EMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DAL.DataAccess.Interfaces
{
    public interface IEventRepository
    {
        Task<IEnumerable<EventDetails>>GetAllEventsAsync(int page,int pageSize);
        Task<EventDetails?> GetEventByIdAsync(Guid eventId);
        Task AddEventAsync(EventDetails ev);
        Task UpdateEventAsync(EventDetails eventData);
        Task DeleteEventAsync(Guid eventId);
    }
}
