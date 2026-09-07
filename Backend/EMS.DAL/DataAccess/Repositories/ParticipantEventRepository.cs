using EMS.DAL.Models;
using EMS.DAL.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EMS.DAL.DataAccess.Repositories
{
    public class ParticipantEventRepository : IParticipantEventRepository
    {
        private readonly EMSDbContext _context;

        public ParticipantEventRepository(EMSDbContext context)
        {
            _context = context;
        }

        public async Task RegisterEventAsync(ParticipantEventDetails pe)
        {
            await _context.ParticipantEvents.AddAsync(pe);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ParticipantEventDetails>> GetRegisteredEventsAsync(string email)
        {
            return await _context.ParticipantEvents
                .Include(p => p.Event)
                .Where(p => p.ParticipantEmailId == email)
                .ToListAsync();
        }

        public async Task<bool> IsAlreadyRegistered(string email, Guid eventId)
        {
            return await _context.ParticipantEvents
                .AnyAsync(p => p.ParticipantEmailId == email && p.EventId == eventId);
        }

        public async Task MarkAttendanceAsync(Guid id)
        {
            var record = await _context.ParticipantEvents.FindAsync(id);

            if (record != null)
            {
                record.IsAttended = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}