using EMS.DAL.DataAccess.Interfaces;
using EMS.DAL.Models;
using EMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Services.Services
{
    public class SpeakerService : ISpeakerService
    {
        private readonly ISpeakerRepository _repo;

        public SpeakerService(ISpeakerRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<SpeakersDetails>> GetAll()
        {
            return await _repo.GetAllSpeakersAsync();
        }

        public async Task<string> Add(SpeakersDetails speaker)
        {
            await _repo.AddSpeakerAsync(speaker);
            return "Speaker added";
        }

        public async Task<string> Delete(Guid id)
        {
            await _repo.DeleteSpeakerAsync(id);
            return "Speaker deleted";
        }
    }
}
