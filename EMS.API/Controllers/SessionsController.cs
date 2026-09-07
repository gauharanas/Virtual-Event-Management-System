using EMS.DAL.Models;
using EMS.Services.DTOs;
using EMS.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers
{
    [ApiController]
    [Route("api/v1/sessions")]
    public class SessionsController : ControllerBase
    {
        private readonly ISessionService _service;

        public SessionsController(ISessionService service)
        {
            _service = service;
        }

        //[Authorize]
        [HttpGet("event/{eventId}")]
        public async Task<IActionResult> GetByEvent(Guid eventId)
        {
            var data = await _service.GetSessionsByEvent(eventId);
            return Ok(data);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(SessionInfo session)
        {
            var result = await _service.AddSession(session);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("assign-speaker")]
        public async Task<IActionResult>AssignSpeaker( AssignSpeakerDto dto)
        {
            var result =
                await _service.AssignSpeaker(
                    dto.SessionId,
                    dto.SpeakerId
                );

            return Ok(result);
        }

        //[Authorize]
        [HttpGet]
        public async Task<IActionResult>GetAll()
        {
            var data =
                await _service.GetAllSessions();

            return Ok(new
            {
                success = true,
                data
            });
        }


        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult>Delete(Guid id)
        {
            var result =
                await _service.DeleteSession(id);

            return Ok(result);
        }



      

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult>
        Update(SessionInfo session)
        {
            return Ok(
                await _service.UpdateSession(session)
            );
        }

   
    }
}
