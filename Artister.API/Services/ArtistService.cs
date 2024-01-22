using Artister.API.Configs;
using Artister.API.Entities;
using Artister.API.Models.Artist;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using System.Xml;

namespace Artister.API.Services
{
    public interface IArtistService
    {
        Task<List<ArtistDto>> GetAll();
        Task<List<ArtistDto>> GetByYear(int year);
        Task<List<ArtistDto>> GetBySubgenre(int id);
        Task<List<ArtistDto>> GetUnacepted();
        Task<ArtistDto> GetById(int id);
        Task<ArtistDto> GetByName(string name);
        Task<int> Create(CreatArtistDto dto);
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
        public async Task<List<ArtistDto>> GetAll()
        {
            var artists = await _context
                .Artists
                .ToListAsync();

            if (artists != null) throw new Exception("Not found");

            return _mapper.Map<List<ArtistDto>>(artists);
        }
        public async Task<List<ArtistDto>> GetByYear(int year)
        {
            var artists = await _context
                .Artists
                .Where(x => x.YearOfOrigin == year)
                .ToListAsync();

            if (artists != null) throw new Exception("Not found");

            return _mapper.Map<List<ArtistDto>>(artists);
        }
        public async Task<List<ArtistDto>> GetUnacepted()
        {
            var artists = await _context
                .Artists
                .Where(x => x.IsAccepted == false)
                .ToListAsync();

            if (artists != null) throw new Exception("Not found");

            return _mapper.Map<List<ArtistDto>>(artists);
        }
        public async Task<List<ArtistDto>> GetBySubgenre(int id)
        {
            //var artists = _context
            //    .Artists
            //    .ToList();

            //if (artists != null) throw new Exception("Not found");

            //var artistsResult = new List<Artist>();
            //foreach(var a in artists)
            //{
            //    var genre = a.Subgenre.ToList();
            //    foreach(var g in genre)
            //    {
            //        if(g.Id == id)
            //        {
            //            artistsResult.Add(a);
            //            break;
            //        }
            //    }
            //}

            //return _mapper.Map<List<ArtistDto>>(artistsResult);
            throw new NotImplementedException();
        }
        public async Task<ArtistDto> GetById(int id)
        {
            var artists = await _context
                .Artists
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (artists != null) throw new Exception("Not found");

            return _mapper.Map<ArtistDto>(artists);
        }
        public async Task<ArtistDto> GetByName(string name)
        {
            var artists = await _context
                .Artists
                .Where(x => x.Name == name)
                .FirstOrDefaultAsync();

            if (artists != null) throw new Exception("Not found");

            return _mapper.Map<ArtistDto>(artists);
        }
        public async Task<int> Create(CreatArtistDto dto)
        {
            var artist = _mapper.Map<Artist>(dto);
            await _context.AddAsync(dto);
            await _context.SaveChangesAsync();
            return artist.Id;
        }
        public async void Delete(int id)
        {
            var artists = await _context
                .Artists
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (artists != null) throw new Exception("Not found");

            _context.Remove(artists);
            await _context.SaveChangesAsync();
        }
        public async void Update(UpdateArtistDto dto, int id)
        {
            var artists = await _context
                .Artists
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (artists != null) throw new Exception("Not found");

            artists.Name = dto.Name ?? artists.Name;
            artists.YearOfOrigin = dto.YearOfOrigin ?? artists.YearOfOrigin;
            artists.WikiUrl = dto.WikiUrl ?? artists.WikiUrl;
            artists.PageUrl = dto.PageUrl ?? artists.PageUrl;
            artists.IsAccepted = dto.IsAccepted ?? artists.IsAccepted;
            await _context.SaveChangesAsync();
        }
        public void AddSubgenreToArtist(int artistId,int subgenreId)
        {
            //var artists = _context
            //    .Artists
            //    .Where(x => x.Id == artistId)
            //    .FirstOrDefault();

            //if (artists != null) throw new Exception("Not found");

            //var subgenres = artists
            //    .Subgenre
            //    .Where(x => x.Id == subgenreId)
            //    .ToList();

            //if(subgenres is null)
            //{
            //    var subgenre = _context
            //        .Subgenres
            //        .Where(x => x.Id == subgenreId)
            //        .FirstOrDefault();

            //    if (subgenre != null) throw new Exception("Not found");

            //    artists.Subgenre.Add(subgenre);
            //    _context.SaveChanges();
            //}
            throw new NotImplementedException();

        }
        public void DeleteSubgenreFromArtist(int artistId, int subgenreId)
        {
            //var artists = _context
            //    .Artists
            //    .Where(x => x.Id == artistId)
            //    .FirstOrDefault();

            //if (artists != null) throw new Exception("Not found");

            //var subgenres = artists
            //    .Subgenre
            //    .Where(x => x.Id == subgenreId)
            //    .ToList();

            //if (!(subgenres is null))
            //{
            //    var subgenre = _context
            //        .Subgenres
            //        .Where(x => x.Id == subgenreId)
            //        .FirstOrDefault();

            //    if (subgenre != null) throw new Exception("Not found");

            //    artists.Subgenre.Remove(subgenre);
            //    _context.SaveChanges();
            //}
            throw new NotImplementedException();
        }
    }
}
