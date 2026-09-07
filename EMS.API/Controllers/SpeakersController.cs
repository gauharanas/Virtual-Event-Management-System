using EMS.DAL.Models;
using EMS.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers
{
    [ApiController]
    [Route("api/v1/speakers")]
    public class SpeakersController : ControllerBase
    {
        private readonly ISpeakerService _service;

        public SpeakersController(ISpeakerService service)
        {
            _service = service;
        }

      
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(SpeakersDetails speaker)
        {
            return Ok(await _service.Add(speaker));
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _service.Delete(id));
        }
    }
}
