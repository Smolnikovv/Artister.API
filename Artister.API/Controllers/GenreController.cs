using Artister.API.Models.Genre;
using Artister.API.Services;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;

namespace Artister.API.Controllers
{
    [Route("api/genre")]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;
        public GenreController(GenreService genreService)
        {
            _genreService = genreService;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            var result = _genreService.GetAll();

            if (result is null) return BadRequest();

            return Ok(result);
        }
        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute]int id)
        {
            var result = _genreService.GetById(id);

            if (result is null) return BadRequest();

            return Ok(result);
        }
        [HttpGet("name/{name}")]
        public ActionResult GetByName([FromRoute]string name)
        {
            var result = _genreService.GetByName(name);

            if (result is null) return BadRequest();

            return Ok(result);
        }
        [HttpPost]
        public ActionResult Create([FromBody]CreateGenreDto dto)
        {
            if(!ModelState.IsValid) return BadRequest();

            var result = _genreService.Create(dto);

            return Created($"Created id {result}", null);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute]int id)
        {
            _genreService.Delete(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public ActionResult Update([FromBody]UpdateGenreDto dto, [FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest();
            _genreService.Update(dto,id);
            return Ok("Updated");
        }
    }
}
