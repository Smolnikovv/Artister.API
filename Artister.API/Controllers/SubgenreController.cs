using Artister.API.Models.Subgenre;
using Artister.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Artister.API.Controllers
{
    [Route("api/subgenre")]
    public class SubgenreController : Controller
    {
        private readonly ISubgenreService _subgenreService;
        public SubgenreController(SubgenreService subgenreService)
        {
            _subgenreService = subgenreService;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            var result = _subgenreService.GetAll();

            if (result == null) return NotFound();

            return Ok(result);
        }
        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute] int id)
        {
            var result = _subgenreService.GetById(id);

            if (result == null) return NotFound();

            return Ok(result);
        }
        [HttpGet("genre/{id}")]
        public ActionResult GetBySubgenre([FromRoute] int id)
        {
            var result = _subgenreService.GetByGenreId(id);

            if (result == null) return NotFound();

            return Ok(result);
        }
        [HttpGet("name/{name}")]
        public ActionResult GetByName([FromRoute] string name)
        {
            var result = _subgenreService.GetByName(name);

            if (result == null) return NotFound();

            return Ok(result);
        }
        [HttpPost]
        public ActionResult Create([FromBody] CreateSubgenreDto dto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var id = _subgenreService.Create(dto);

            return Created($"id: {id}", null);
        }
        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateSubgenreDto dto, [FromRoute]int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            _subgenreService.Update(dto, id);

            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute]int id)
        {
            _subgenreService.Delete(id);

            return NoContent();
        }
    }
}
