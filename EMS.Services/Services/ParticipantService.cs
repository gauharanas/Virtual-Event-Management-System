using EMS.DAL.DataAccess.Interfaces;
using EMS.DAL.Models;
using EMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Services.Services
{
    public class ParticipantService : IParticipantService
    {
        private readonly IParticipantEventRepository _repo;

        public ParticipantService(IParticipantEventRepository repo)
        {
            _repo = repo;
        }

        public async Task<string> RegisterEvent(string email, Guid eventId)
        {
            if (await _repo.IsAlreadyRegistered(email, eventId))
                return "Already registered";

            var data = new ParticipantEventDetails
            {
                Id = Guid.NewGuid(),
                EventId = eventId,
                ParticipantEmailId = email,
                IsAttended = false
            };

            await _repo.RegisterEventAsync(data);

            return "Registered successfully";
        }

        public async Task<IEnumerable<ParticipantEventDetails>> GetMyEvents(string email)
        {
            return await _repo.GetRegisteredEventsAsync(email);
        }

        public async Task<string> MarkAttendance(Guid id)
        {
            await _repo.MarkAttendanceAsync(id);
            return "Attendance marked";
        }
    }
}
