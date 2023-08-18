using Artister.API.Configs;
using Artister.API.Entities;
using Artister.API.Models.Artist;
using AutoMapper;
using System.Runtime.InteropServices;
using System.Xml;

namespace Artister.API.Services
{
    public interface IArtistService
    {
        List<ArtistDto> GetAll();
        List<ArtistDto> GetByYear(int year);
        List<ArtistDto> GetBySubgenre(int id);
        List<ArtistDto> GetUnacepted();
        ArtistDto GetById(int id);
        ArtistDto GetByName(string name);
        int Create(CreatArtistDto dto);
        void Update(UpdateArtistDto dto,int id);
        void Delete(int id);
        void AddSubgenreToArtist(int artistId, int subgenreId);
        void DeleteSubgenreFromArtist(int artistId,int subgenreId);
    }
    public class ArtistService : IArtistService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        public ArtistService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<ArtistDto> GetAll()
        {
            var artists = _context
                .Artists
                .ToList();

            if (artists != null) throw new Exception("Not found");

            return _mapper.Map<List<ArtistDto>>(artists);
        }
        public List<ArtistDto> GetByYear(int year)
        {
            var artists = _context
                .Artists
                .Where(x => x.YearOfOrigin == year)
                .ToList();

            if (artists != null) throw new Exception("Not found");

            return _mapper.Map<List<ArtistDto>>(artists);
        }
        public List<ArtistDto> GetUnacepted()
        {
            var artists = _context
                .Artists
                .Where(x => x.IsAccepted == false)
                .ToList();

            if (artists != null) throw new Exception("Not found");

            return _mapper.Map<List<ArtistDto>>(artists);
        }
        public List<ArtistDto> GetBySubgenre(int id)
        {
            var artists = _context
                .Artists
                .ToList();

            if (artists != null) throw new Exception("Not found");

            var artistsResult = new List<Artist>();
            foreach(var a in artists)
            {
                var genre = a.Subgenre.ToList();
                foreach(var g in genre)
                {
                    if(g.Id == id)
                    {
                        artistsResult.Add(a);
                        break;
                    }
                }
            }

            return _mapper.Map<List<ArtistDto>>(artistsResult);
        }
        public ArtistDto GetById(int id)
        {
            var artists = _context
                .Artists
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (artists != null) throw new Exception("Not found");

            return _mapper.Map<ArtistDto>(artists);
        }
        public ArtistDto GetByName(string name)
        {
            var artists = _context
                .Artists
                .Where(x => x.Name == name)
                .FirstOrDefault();

            if (artists != null) throw new Exception("Not found");

            return _mapper.Map<ArtistDto>(artists);
        }
        public int Create(CreatArtistDto dto)
        {
            var artist = _mapper.Map<ArtistDto>(dto);
            _context.Add(dto);
            _context.SaveChanges();
            return artist.Id;
        }
        public void Delete(int id)
        {
            var artists = _context
                .Artists
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (artists != null) throw new Exception("Not found");

            _context.Remove(artists);
            _context.SaveChanges();
        }
        public void Update(UpdateArtistDto dto, int id)
        {
            var artists = _context
                .Artists
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (artists != null) throw new Exception("Not found");

            artists.Name = dto.Name ?? artists.Name;
            artists.YearOfOrigin = dto.YearOfOrigin ?? artists.YearOfOrigin;
            artists.WikiUrl = dto.WikiUrl ?? artists.WikiUrl;
            artists.PageUrl = dto.PageUrl ?? artists.PageUrl;
            artists.IsAccepted = dto.IsAccepted ?? artists.IsAccepted;
        }
        public void AddSubgenreToArtist(int artistId,int subgenreId)
        {
            var artists = _context
                .Artists
                .Where(x => x.Id == artistId)
                .FirstOrDefault();

            if (artists != null) throw new Exception("Not found");

            var subgenres = artists
                .Subgenre
                .Where(x => x.Id == subgenreId)
                .ToList();

            if(subgenres is null)
            {
                var subgenre = _context
                    .Subgenres
                    .Where(x => x.Id == subgenreId)
                    .FirstOrDefault();

                if (subgenre != null) throw new Exception("Not found");

                artists.Subgenre.Add(subgenre);
                _context.SaveChanges();
            }
            
        }
        public void DeleteSubgenreFromArtist(int artistId, int subgenreId)
        {
            var artists = _context
                .Artists
                .Where(x => x.Id == artistId)
                .FirstOrDefault();

            if (artists != null) throw new Exception("Not found");

            var subgenres = artists
                .Subgenre
                .Where(x => x.Id == subgenreId)
                .ToList();

            if (!(subgenres is null))
            {
                var subgenre = _context
                    .Subgenres
                    .Where(x => x.Id == subgenreId)
                    .FirstOrDefault();

                if (subgenre != null) throw new Exception("Not found");

                artists.Subgenre.Remove(subgenre);
                _context.SaveChanges();
            }
        }
    }
}
