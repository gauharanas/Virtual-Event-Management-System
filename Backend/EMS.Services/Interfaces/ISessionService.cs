using EMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Services.Interfaces
{
    public interface ISessionService
    {
        Task<IEnumerable<SessionInfo>> GetSessionsByEvent(Guid eventId);
        Task<string> AddSession(SessionInfo session);
        Task<string> AssignSpeaker(Guid sessionId, Guid? speakerId);
        Task<IEnumerable<SessionInfo>>GetAllSessions();

        Task<string> DeleteSession(Guid sessionId);

        Task<string> UpdateSession(SessionInfo session);
        

    }
}
