using EMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DAL.DataAccess.Interfaces
{
    public interface ISessionRepository
    {
        Task<IEnumerable<SessionInfo>> GetAllSessionsAsync();
        Task<SessionInfo?> GetSessionByIdAsync(Guid sessionId);
        Task<IEnumerable<SessionInfo>> GetSessionsByEventIdAsync(Guid eventId);
        Task AddSessionAsync(SessionInfo session);
        Task UpdateSessionAsync(SessionInfo session);
        Task DeleteSessionAsync(Guid sessionId);

        
    }
}
