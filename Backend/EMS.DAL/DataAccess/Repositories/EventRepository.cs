using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EMS.DAL.Models;
using Microsoft.EntityFrameworkCore;
using EMS.DAL.DataAccess.Interfaces;

namespace EMS.DAL.DataAccess.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly EMSDbContext _context;

        public EventRepository(EMSDbContext context)
        {
            _context = context;
        }

        // Get All Events
        public async Task<IEnumerable<EventDetails>>GetAllEventsAsync(int page,int pageSize)
        {
            return await _context.Events

                .AsNoTracking()

                .OrderByDescending(
                    e => e.EventDate
                )

                .Skip((page - 1) * pageSize)

                .Take(pageSize)

                .ToListAsync();
        }

        // Get Event By Id
        public async Task<EventDetails?> GetEventByIdAsync(Guid eventId)
        {
            return await _context.Events
                .FirstOrDefaultAsync(e => e.EventId == eventId);
        }

        //  Add Event
        public async Task AddEventAsync(EventDetails ev)
        {
            await _context.Events.AddAsync(ev);
            await _context.SaveChangesAsync();
        }

        // Update Event
        public async Task UpdateEventAsync(EventDetails ev)
        {
            _context.Events.Update(ev);
            await _context.SaveChangesAsync();
        }

        //  Delete Event
        public async Task DeleteEventAsync(Guid eventId)
        {
            var ev = await _context.Events.FindAsync(eventId);
            if (ev != null)
            {
                _context.Events.Remove(ev);
                await _context.SaveChangesAsync();
            }
        }
    }
}