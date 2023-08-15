using System.ComponentModel.DataAnnotations;

namespace Artister.API.Models.Subgenre
{
    public class CreateSubgenreDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int GenreId { get; set; }
    }
}
