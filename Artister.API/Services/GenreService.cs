using Artister.API.Configs;
using Artister.API.Entities;
using Artister.API.Models.Genre;
using AutoMapper;

namespace Artister.API.Services
{
    public interface IGenreService
    {
        List<GenreDto> GetAll();
        GenreDto GetById(int id);
        GenreDto GetByName(string name);
        int Create(CreateGenreDto dto);
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
        public List<GenreDto> GetAll()
        {
            var genres = _context
                .Genres
                .ToList();

            if (genres == null) throw new Exception("not found");

            return _mapper.Map<List<GenreDto>>(genres);
        }
        public GenreDto GetById(int id)
        {
            var genre = _context
                .Genres
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (genre == null) throw new Exception("not found");

            return _mapper.Map<GenreDto>(genre);
        }
        public GenreDto GetByName(string name)
        {
            var genre = _context
                .Genres
                .Where(x => x.Name == name)
                .FirstOrDefault();

            if (genre == null) throw new Exception("not found");

            return _mapper.Map<GenreDto>(genre);
        }
        public int Create(CreateGenreDto dto)
        {
            var genre = _mapper.Map<Genre>(dto);
            _context.Add(genre);
            _context.SaveChanges();
            return genre.Id;
        }
        public void Delete(int id)
        {
            var genre = _context
                .Genres
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (genre == null) throw new Exception("not found");

            _context.Remove(genre);
            _context.SaveChanges();
        }
        public void Update(UpdateGenreDto dto, int id)
        {
            var genre = _context
                .Genres
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (genre == null) throw new Exception("not found");

            genre.Name = dto.Name ?? genre.Name;

            _context.SaveChanges();
        }

    }
}
