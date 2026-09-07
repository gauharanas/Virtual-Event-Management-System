using EMS.DAL.DataAccess.Interfaces;
using EMS.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DAL.DataAccess.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly EMSDbContext _context;

        public SessionRepository(EMSDbContext context)
        {
            _context = context;
        }

        //  Get All Sessions
        public async Task<IEnumerable<SessionInfo>> GetAllSessionsAsync()
        {
            return await _context.Sessions
                .Include(s => s.Event)
                .Include(s => s.Speaker)
                .ToListAsync();
        }

        //  Get Session By Id
        public async Task<SessionInfo?> GetSessionByIdAsync(Guid sessionId)
        {
            return await _context.Sessions
                .Include(s => s.Event)
                .Include(s => s.Speaker)
                .FirstOrDefaultAsync(s => s.SessionId == sessionId);
        }

        //  Get Sessions By EventId 
        public async Task<IEnumerable<SessionInfo>> GetSessionsByEventIdAsync(Guid eventId)
        {
            return await _context.Sessions
                .Where(s => s.EventId == eventId)
                .Include(s => s.Speaker)
                .ToListAsync();
        }

        //  Add Session
        public async Task AddSessionAsync(SessionInfo session)
        {
            await _context.Sessions.AddAsync(session);
            await _context.SaveChangesAsync();
        }

        //  Update Session
        public async Task UpdateSessionAsync(SessionInfo session)
        {
            _context.Sessions.Update(session);
            await _context.SaveChangesAsync();
        }

        //  Delete Session
        public async Task DeleteSessionAsync(Guid sessionId)
        {
            var session = await _context.Sessions.FindAsync(sessionId);
            if (session != null)
            {
                _context.Sessions.Remove(session);
                await _context.SaveChangesAsync();
            }
        }


    }
}
