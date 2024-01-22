using Artister.API.Models.Artist;
using Artister.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Artister.API.Controllers
{
    [Route("api/artist")]
    public class ArtistController : Controller
    {
        private readonly IArtistService _artistService;
        public ArtistController(IArtistService artistService)
        {
            _artistService = artistService;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var artists = await _artistService.GetAll();
            
            if(artists is null) return NotFound();

            return Ok(artists);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute]int id)
        {
            var artist = await _artistService.GetById(id);

            if(artist is null) return NotFound();

            return Ok(artist);
        }
        [HttpGet("GetByName/{name}")]
        public async Task<ActionResult> GetByName([FromRoute]string name)
        {
            var artist = await _artistService.GetByName(name);

            if(artist is null) return NotFound();

            return Ok(artist);
        }
        [HttpGet("GetByYear/{year}")]
        public async Task<ActionResult> GetByYear([FromRoute]int year)
        {
            var artist = await _artistService.GetByYear(year);

            if(artist is null) return NotFound();

            return Ok(artist);
        }
        [HttpGet("GetBySubgenre/{subgenre}")]
        public async Task<ActionResult> GetBySubgenre([FromRoute]int subgenre)
        {
            var artist = await _artistService.GetBySubgenre(subgenre);

            if(artist is null) return NotFound();

            return Ok(artist);
        }
        [HttpGet("GetUnaccepted")]
        public async Task<ActionResult> GetUnaccepted()
        {
            var artist = await _artistService.GetUnacepted();

            if(artist is null) return NotFound();

            return Ok(artist);
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody]CreatArtistDto dto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var id = await _artistService.Create(dto);

            return Created($"Created id {id}", null);
        }
        [HttpPut("{id}")]
        public ActionResult Update([FromBody]UpdateArtistDto dto, [FromRoute]int id)
        {
            if (!ModelState.IsValid) return BadRequest();

            _artistService.Update(dto, id);

            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute]int id)
        {
            _artistService.Delete(id);

            return NoContent();
        }
        [HttpDelete("{artistId}/{subgenreId}")]
        public ActionResult DeleteSubgenreFromArtist([FromRoute]int artistId, [FromRoute]int subgenreId)
        {
            _artistService.DeleteSubgenreFromArtist(artistId, subgenreId);

            return Ok();
        }
        [HttpPut("{artistId}/{subgenreId}")]
        public ActionResult AddSubgenreToArtist([FromRoute] int artistId, [FromRoute] int subgenreId)
        {
            _artistService.AddSubgenreToArtist(artistId, subgenreId);

            return Ok();
        }
    }
}
