using Artister.API.Configs;
using Artister.API.Entities;
using Artister.API.Models.Genre;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Artister.API.Services
{
    public interface IGenreService
    {
        Task<List<GenreDto>> GetAll();
        Task<GenreDto> GetById(int id);
        Task<GenreDto> GetByName(string name);
        Task<int> Create(CreateGenreDto dto);
        void Update(UpdateGenreDto dto, int id);
        void Delete(int id);

    }
    public class GenreService : IGenreService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public GenreService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<GenreDto>> GetAll()
        {
            var genres = await _context
                .Genres
                .ToListAsync();

            if (genres == null) throw new Exception("not found");

            return _mapper.Map<List<GenreDto>>(genres);
        }
        public async Task<GenreDto> GetById(int id)
        {
            var genre = await _context
                .Genres
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (genre == null) throw new Exception("not found");

            return _mapper.Map<GenreDto>(genre);
        }
        public async Task<GenreDto> GetByName(string name)
        {
            var genre = await _context
                .Genres
                .Where(x => x.Name == name)
                .FirstOrDefaultAsync();

            if (genre == null) throw new Exception("not found");

            return _mapper.Map<GenreDto>(genre);
        }
        public async Task<int> Create(CreateGenreDto dto)
        {
            var genre = _mapper.Map<Genre>(dto);
            await _context.AddAsync(genre);
            await _context.SaveChangesAsync();
            return genre.Id;
        }
        public async void Delete(int id)
        {
            var genre = await _context
                .Genres
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (genre == null) throw new Exception("not found");

            _context.Remove(genre);
            await _context.SaveChangesAsync();
        }
        public async void Update(UpdateGenreDto dto, int id)
        {
            var genre = await _context
                .Genres
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (genre == null) throw new Exception("not found");

            genre.Name = dto.Name ?? genre.Name;

            await _context.SaveChangesAsync();
        }

    }
}
