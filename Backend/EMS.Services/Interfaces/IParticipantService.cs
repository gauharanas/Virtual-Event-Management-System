using EMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Services.Interfaces
{
    public interface IParticipantService
    {
        Task<string> RegisterEvent(string email, Guid eventId);
        Task<IEnumerable<ParticipantEventDetails>> GetMyEvents(string email);
        Task<string> MarkAttendance(Guid id);
    }
}
