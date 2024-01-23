using Artister.API.Models.Subgenre;
using Artister.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Artister.API.Controllers
{
    [Route("api/subgenre")]
    public class SubgenreController : Controller
    {
        private readonly ISubgenreService _subgenreService;
        public SubgenreController(ISubgenreService subgenreService)
        {
            _subgenreService = subgenreService;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await _subgenreService.GetAll();

            if (result == null) return NotFound();

            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var result = await _subgenreService.GetById(id);

            if (result == null) return NotFound();

            return Ok(result);
        }
        [HttpGet("GetBySubgenre/{id}")]
        public async Task<ActionResult> GetBySubgenre([FromRoute] int id)
        {
            var result = await _subgenreService.GetByGenreId(id);

            if (result == null) return NotFound();

            return Ok(result);
        }
        [HttpGet("GetByName/{name}")]
        public async Task<ActionResult> GetByName([FromRoute] string name)
        {
            var result = await _subgenreService.GetByName(name);

            if (result == null) return NotFound();

            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateSubgenreDto dto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var id = await _subgenreService.Create(dto);

            return Created($"Created id {id}", null);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromBody] UpdateSubgenreDto dto, [FromRoute]int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            _subgenreService.Update(dto, id);

            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute]int id)
        {
            _subgenreService.Delete(id);

            return NoContent();
        }
    }
}
