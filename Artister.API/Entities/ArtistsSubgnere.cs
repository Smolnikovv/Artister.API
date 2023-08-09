namespace Artister.API.Entities
{
    public class ArtistsSubgnere
    {
        public int SubgenreId { get; set; }
        public int ArtistId { get; set; }
        public Subgenre Subgenre { get; set; }
        public Artist Artist { get; set; }
    }
}
