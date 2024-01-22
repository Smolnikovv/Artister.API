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
        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await _genreService.GetAll();

            if (result is null) return BadRequest();

            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute]int id)
        {
            var result = await _genreService.GetById(id);

            if (result is null) return BadRequest();

            return Ok(result);
        }
        [HttpGet("name/{name}")]
        public async Task<ActionResult> GetByName([FromRoute]string name)
        {
            var result = await _genreService.GetByName(name);

            if (result is null) return BadRequest();

            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody]CreateGenreDto dto)
        {
            if(!ModelState.IsValid) return BadRequest();

            var id = await _genreService.Create(dto);

            return Created($"Created id {id}", null);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute]int id)
        {
            _genreService.Delete(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromBody]UpdateGenreDto dto, [FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest();
            _genreService.Update(dto,id);
            return Ok("Updated");
        }
    }
}
