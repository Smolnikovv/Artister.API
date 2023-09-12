using Artister.API.Models.User;
using Artister.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Artister.API.Controllers
{
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            var result = _userService.GetUsers();

            if (result == null) return NotFound();

            return Ok(result);
        }
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var result = _userService.GetUserById(id);

            if (result == null) return NotFound();

            return Ok(result);
        }
        [HttpGet("name/{name}")]
        public ActionResult GetByName(string name)
        {
            var result = _userService.GetUserByName(name);

            if (result == null) return NotFound();

            return Ok(result);
        }
        [HttpPost]
        public ActionResult Create([FromBody]CreateUserDto dto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var id = _userService.Create(dto);

            return Created($"Created id {id}", null);
        }
        [HttpPut("{id}")]
        public ActionResult Update([FromBody]UpdateUserDto dto, [FromRoute]int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _userService.Update(dto, id);

            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute]int id)
        {
            _userService.Delete(id);

            return NoContent();
        }
    }
}
