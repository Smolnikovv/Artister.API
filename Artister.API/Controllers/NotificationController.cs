using Artister.API.Models.Notification;
using Artister.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Artister.API.Controllers
{
    [Route("api/notifictation")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        public NotificationController(NotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute] int id)
        {
            var result = _notificationService.GetById(id);

            if (result == null) return BadRequest();

            return Ok(result);
        }
        [HttpGet("user/{id}")]
        public ActionResult GetByUserId([FromRoute]int id) 
        {
            var result = _notificationService.GetById(id);

            if (result == null) return BadRequest();

            return Ok(result);
        }
        [HttpPost]
        public ActionResult Create([FromBody] CreateNotificationDto dto)
        {
            if(!ModelState.IsValid) return BadRequest();

            var id = _notificationService.Create(dto);

            return Created($"Created id: {id}", null);
        }
        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateNotificationDto dto, [FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest();

            _notificationService.Update(dto, id);

            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _notificationService.Delete(id);

            return NoContent();
        }
    }
}
