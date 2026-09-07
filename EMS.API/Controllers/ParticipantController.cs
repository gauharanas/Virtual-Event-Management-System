using EMS.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EMS.API.Controllers
{
    [ApiController]
    [Route("api/v1/participant")]
    [Authorize(Roles = "Participant")]
    public class ParticipantController : ControllerBase
    {
        private readonly IParticipantService _service;

        public ParticipantController(IParticipantService service)
        {
            _service = service;
        }

        private string GetEmail()
        {
            return User.FindFirst(ClaimTypes.Name)?.Value;
        }

        [HttpPost("register-event")]
        public async Task<IActionResult> Register(Guid eventId)
        {
            var email = GetEmail();
            var result = await _service.RegisterEvent(email, eventId);
            return Ok(result);
        }

        [HttpGet("my-events")]
        public async Task<IActionResult> MyEvents()
        {
            var email = GetEmail();
            return Ok(await _service.GetMyEvents(email));
        }

        [HttpPost("mark-attendance")]
        public async Task<IActionResult> MarkAttendance(Guid id)
        {
            return Ok(await _service.MarkAttendance(id));
        }
    }
}
