using System.ComponentModel.DataAnnotations;

namespace Artister.API.Models.Genre
{
    public class CreateGenreDto
    {
        [Required]
        public string Name { get; set; }
    }
}
