﻿using Artister.API.Models.Subgenre;

namespace Artister.API.Models.Artist
{
    public class UpdateArtistDto
    {
        public string? Name { get; set; }
        public int? YearOfOrigin { get; set; }
        public string? WikiUrl { get; set; }
        public string? PageUrl { get; set; }
        public bool? IsAccepted { get; set; }
    }
}
