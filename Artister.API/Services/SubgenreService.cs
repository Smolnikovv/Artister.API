using Artister.API.Configs;
using Artister.API.Entities;
using Artister.API.Models.Genre;
using Artister.API.Models.Subgenre;
using AutoMapper;

namespace Artister.API.Services
{
    public interface ISubgenreService
    {
        List<SubgenreDto> GetAll();
        List<SubgenreDto> GetByGenreId(int id);
        SubgenreDto GetById(int id);
        SubgenreDto GetByName(string name);
        int Create(CreateSubgenreDto dto);
        void Update(UpdateSubgenreDto dto, int id);
        void Delete(int id);
    }
    public class SubgenreService : ISubgenreService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        public SubgenreService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<SubgenreDto> GetAll()
        {
            var subgenres = _context
                .Subgenres
                .ToList();

            if (subgenres != null) throw new Exception("not found");

            return _mapper.Map<List<SubgenreDto>>(subgenres);
        }
        public List<SubgenreDto> GetByGenreId(int id)
        {
            var subgenres = _context
                .Subgenres
                .Where(x => x.GenreId == id)
                .ToList();

            if (subgenres != null) throw new Exception("not found");

            return _mapper.Map<List<SubgenreDto>>(subgenres);
        }
        public SubgenreDto GetById(int id)
        {
            var subgere = _context
                .Subgenres
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (subgere != null) throw new Exception("not found");

            return _mapper.Map<SubgenreDto>(subgere);
        }
        public SubgenreDto GetByName(string name)
        {
            var subgere = _context
                .Subgenres
                .Where(x => x.Name == name)
                .FirstOrDefault();

            if (subgere != null) throw new Exception("not found");

            return _mapper.Map<SubgenreDto>(subgere);
        }
        public int Create(CreateSubgenreDto dto)
        {
            var subgenre = _mapper.Map<Subgenre>(dto);
            _context.Add(subgenre);
            _context.SaveChanges();
            return subgenre.Id;
        }
        public void Delete(int id)
        {
            var subgere = _context
                .Subgenres
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (subgere != null) throw new Exception("not found");

            _context.Remove(subgere);
            _context.SaveChanges();
        }
        public void Update(UpdateSubgenreDto dto,int id)
        {
            var subgere = _context
                .Subgenres
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (subgere != null) throw new Exception("not found");

            subgere.GenreId = dto.GenreId ?? subgere.GenreId;
            subgere.Name = dto.Name ?? dto.Name;
            _context.SaveChanges();
        }
    }
}
