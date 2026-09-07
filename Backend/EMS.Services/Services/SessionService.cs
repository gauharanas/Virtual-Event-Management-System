using EMS.DAL.DataAccess.Interfaces;
using EMS.DAL.Models;
using EMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Services.Services
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository _repo;

        public SessionService(ISessionRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<SessionInfo>> GetSessionsByEvent(Guid eventId)
        {
            return await _repo.GetSessionsByEventIdAsync(eventId);
        }

        public async Task<string> AddSession(SessionInfo session)
        {
            await _repo.AddSessionAsync(session);
            return "Session created successfully";
        }

        public async Task<string> AssignSpeaker(Guid sessionId, Guid? speakerId)
        {
            var session = await _repo.GetSessionByIdAsync(sessionId);

            if (session == null)
                return "Session not found";

            session.SpeakerId = speakerId; // null = remove speaker

            await _repo.UpdateSessionAsync(session);

            return "Speaker updated";
        }

        public async Task<IEnumerable<SessionInfo>>GetAllSessions()
        {
            return await _repo.GetAllSessionsAsync();
        }

        public async Task<string> DeleteSession(Guid sessionId)
        {
            await _repo.DeleteSessionAsync(sessionId);

            return "Session Deleted Successfully";
        }

        public async Task<string>UpdateSession(SessionInfo session)
        {
            await _repo.UpdateSessionAsync(session);

            return "Session Updated";
        }

    }
}
