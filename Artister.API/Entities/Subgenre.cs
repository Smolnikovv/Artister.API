﻿namespace Artister.API.Entities
{
    public class Subgenre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
