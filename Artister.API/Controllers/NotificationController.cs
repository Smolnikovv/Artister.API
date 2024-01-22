using Artister.API.Models.Notification;
using Artister.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Artister.API.Controllers
{
    [Route("api/notifictation")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var result = await _notificationService.GetById(id);

            if (result == null) return BadRequest();

            return Ok(result);
        }
        [HttpGet("user/{id}")]
        public async Task<ActionResult> GetByUserId([FromRoute]int id) 
        {
            var result = await _notificationService.GetById(id);

            if (result == null) return BadRequest();

            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateNotificationDto dto)
        {
            if(!ModelState.IsValid) return BadRequest();

            var id = await _notificationService.Create(dto);

            return Created($"Created id {id}", null);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromBody] UpdateNotificationDto dto, [FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest();

            _notificationService.Update(dto, id);

            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            _notificationService.Delete(id);

            return NoContent();
        }
    }
}
