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
        public ActionResult GetAll()
        {
            var artists = _artistService.GetAll();
            
            if(artists is null) return NotFound();

            return Ok(artists);
        }
        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute]int id)
        {
            var artist = _artistService.GetById(id);

            if(artist is null) return NotFound();

            return Ok(artist);
        }
        [HttpGet("name/{name}")]
        public ActionResult GetByName([FromRoute]string name)
        {
            var artist = _artistService.GetByName(name);

            if(artist is null) return NotFound();

            return Ok(artist);
        }
        [HttpGet("year/{year}")]
        public ActionResult GetByYear([FromRoute]int year)
        {
            var artist = _artistService.GetByYear(year);

            if(artist is null) return NotFound();

            return Ok(artist);
        }
        [HttpGet("subgenre/{subgenre}")]
        public ActionResult GetBySubgenre([FromRoute]int subgenre)
        {
            var artist = _artistService.GetBySubgenre(subgenre);

            if(artist is null) return NotFound();

            return Ok(artist);
        }
        [HttpGet("unaccepted")]
        public ActionResult GetUnaccepted()
        {
            var artist = _artistService.GetUnacepted();

            if(artist is null) return NotFound();

            return Ok(artist);
        }
        [HttpPost]
        public ActionResult Create([FromBody]CreatArtistDto dto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var id = _artistService.Create(dto);

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
