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
        public async Task<ActionResult> GetAll()
        {
            var result = await _userService.GetUsers();

            if (result == null) return NotFound();

            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await _userService.GetUserById(id);

            if (result == null) return NotFound();

            return Ok(result);
        }
        [HttpGet("GetByName/{name}")]
        public async Task<ActionResult> GetByName(string name)
        {
            var result = await _userService.GetUserByName(name);

            if (result == null) return NotFound();

            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody]CreateUserDto dto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var id = await _userService.Create(dto);

            return Created($"Created id {id}", null);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromBody]UpdateUserDto dto, [FromRoute]int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _userService.Update(dto, id);

            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute]int id)
        {
            _userService.Delete(id);

            return NoContent();
        }
    }
}
