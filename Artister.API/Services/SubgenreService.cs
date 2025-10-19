using Artister.API.Configs;
using Artister.API.Entities;
using Artister.API.Models.Subgenre;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Artister.API.Services
{
    public interface ISubgenreService
    {
        Task<List<SubgenreDto>> GetAll();
        Task<List<SubgenreDto>> GetByGenreId(int id);
        Task<SubgenreDto> GetById(int id);
        Task<SubgenreDto> GetByName(string name);
        Task<int> Create(CreateSubgenreDto dto);
        void Update(UpdateSubgenreDto dto, int id);
        void Delete(int id);
    }
    public class SubgenreService : ISubgenreService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        int i = 10;
        public SubgenreService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<SubgenreDto>> GetAll()
        {
            var subgenres = await _context
                .Subgenres
                .ToListAsync();

            if (subgenres == null) throw new Exception("not found");

            return _mapper.Map<List<SubgenreDto>>(subgenres);
        }
        public async Task<List<SubgenreDto>> GetByGenreId(int id)
        {
            var subgenres = await _context
                .Subgenres
                .Where(x => x.GenreId == id)
                .ToListAsync();

            if (subgenres == null) throw new Exception("not found");

            return _mapper.Map<List<SubgenreDto>>(subgenres);
        }
        public async Task<SubgenreDto> GetById(int id)
        {
            var subgere = await _context
                .Subgenres
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (subgere != null) throw new Exception("not found");

            return _mapper.Map<SubgenreDto>(subgere);
        }
        public async Task<SubgenreDto> GetByName(string name)
        {
            var subgere = await _context
                .Subgenres
                .Where(x => x.Name == name)
                .FirstOrDefaultAsync();

            if (subgere == null) throw new Exception("not found");

            return _mapper.Map<SubgenreDto>(subgere);
        }
        public async Task<int> Create(CreateSubgenreDto dto)
        {
            var subgenre = _mapper.Map<Subgenre>(dto);
            await _context.AddAsync(subgenre);
            await _context.SaveChangesAsync();
            return subgenre.Id;
        }
        public async void Delete(int id)
        {
            var subgere = await _context
                .Subgenres
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (subgere == null) throw new Exception("not found");

            _context.Remove(subgere);
            await _context.SaveChangesAsync();
        }
        public async void Update(UpdateSubgenreDto dto, int id)
        {
            var subgere = await _context
                .Subgenres
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (subgere == null) throw new Exception("not found");

            subgere.GenreId = dto.GenreId ?? subgere.GenreId;
            subgere.Name = dto.Name ?? subgere.Name;
            await _context.SaveChangesAsync();
        }
    }
}
