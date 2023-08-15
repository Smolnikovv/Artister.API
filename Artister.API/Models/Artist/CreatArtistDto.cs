using Artister.API.Models.Subgenre;
using System.ComponentModel.DataAnnotations;

namespace Artister.API.Models.Artist
{
    public class CreatArtistDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int YearOfOrigin { get; set; }
        public string? WikiUrl { get; set; }
        public string? PageUrl { get; set; }
        [Required]
        public bool IsAccepted { get; set; }
        [Required]
        public int UserAddedId { get; set; }
        public List<SubgenreDto> Subgenre { get; set; }
    }
}
