using EMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Services.Interfaces
{
    public interface ISpeakerService
    {
        Task<IEnumerable<SpeakersDetails>> GetAll();
        Task<string> Add(SpeakersDetails speaker);
        Task<string> Delete(Guid id);
    }
}
