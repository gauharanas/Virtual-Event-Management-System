using EMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DAL.DataAccess.Interfaces
{
    public interface ISpeakerRepository
    {
        Task<IEnumerable<SpeakersDetails>> GetAllSpeakersAsync();
        Task<SpeakersDetails?> GetSpeakerByIdAsync(Guid speakerId);
        Task AddSpeakerAsync(SpeakersDetails speaker);
        Task DeleteSpeakerAsync(Guid speakerId);
    }
}
