using EMS.DAL.Models;
using EMS.DAL.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EMS.DAL.DataAccess.Repositories
{
    public class SpeakerRepository : ISpeakerRepository
    {
        private readonly EMSDbContext _context;

        public SpeakerRepository(EMSDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SpeakersDetails>> GetAllSpeakersAsync()
        {
            return await _context.Speakers.ToListAsync();
        }

        public async Task<SpeakersDetails?> GetSpeakerByIdAsync(Guid speakerId)
        {
            return await _context.Speakers.FindAsync(speakerId);
        }

        public async Task AddSpeakerAsync(SpeakersDetails speaker)
        {
            await _context.Speakers.AddAsync(speaker);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSpeakerAsync(Guid speakerId)
        {
            var speaker = await _context.Speakers.FindAsync(speakerId);
            if (speaker != null)
            {
                _context.Speakers.Remove(speaker);
                await _context.SaveChangesAsync();
            }
        }
    }
}