using EMS.Services.Common;
using EMS.Services.DTOs;
using EMS.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace EMS.API.Controllers
{
    [ApiController]
    [Route("api/v1/events")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _service;

        public EventsController(IEventService service)
        {
            _service = service;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pageSize = 5)
        {
            var data = await _service.GetAllEventsAsync(page, pageSize);

            var response = new ApiResponse<object>(
                true,
                "Events fetched successfully",
                data
            );

            return Ok(response);
        }



        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(EventDto dto)
        {
            var result = await _service.CreateEvent(dto);

            return Ok(new ApiResponse<string>(
                true,
                result,
                null
            ));
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _service.DeleteEvent(id);

            return Ok(new ApiResponse<string>(
                true,
                result,
                null
            ));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> Update(EventDto dto)
        {
            var result = await _service.UpdateEvent(dto);

            return Ok(new ApiResponse<string>(
                true,
                result,
                null
            ));
        }

        
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var eventData =
                await _service.GetEventByIdAsync(id);

            if (eventData == null)
            {
                return NotFound(
                    new ApiResponse<object>(
                        false,
                        "Event not found",
                        null
                    )
                );
            }

            var response =
                new ApiResponse<object>(
                    true,
                    "Event fetched successfully",
                    eventData
                );

            return Ok(response);
        }
    }
}