using Artister.API.Configs;
using Artister.API.Entities;
using Artister.API.Models.User;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Artister.API.Services
{
    public interface IUserService
    {
        Task<List<UserDto>> GetUsers();
        Task<UserDto> GetUserById(int id);
        Task<UserDto> GetUserByName(string name);
        Task<int> Create(CreateUserDto dto);
        void Update(UpdateUserDto dto, int id);
        void Delete(int id);
    }
    public class UserService : IUserService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        public UserService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<UserDto>> GetUsers()
        {
            var users = await _context
                .Users
                .ToListAsync();

            if (users == null) throw new Exception("Not found");

            return _mapper.Map<List<UserDto>>(users);
        }
        public async Task<UserDto> GetUserById(int id)
        {
            var user = await _context
                .Users
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (user == null) throw new Exception("Not found");

            return _mapper.Map<UserDto>(user);
        }
        public async Task<UserDto> GetUserByName(string name)
        {
            var user = await _context
                .Users
                .Where(x => x.Name == name)
                .FirstOrDefaultAsync();

            if (user == null) throw new Exception("Not found");

            return _mapper.Map<UserDto>(user);
        }
        public async Task<int> Create(CreateUserDto dto)
        {
            var user = _mapper.Map<User>(dto);
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();

            return user.Id;
        }
        public async void Update(UpdateUserDto dto, int id)
        {
            var user = await _context
                .Users
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (user == null) throw new Exception("Not found");

            user.Email = dto.Email ?? user.Email;
            user.Points = dto.Points ?? user.Points;
            user.Password = dto.Password ?? user.Password;
            user.Name = dto.Name ?? user.Name;
            await _context.SaveChangesAsync();
        }
        public async void Delete(int id)
        {
            var user = await _context
                .Users
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (user == null) throw new Exception("Not found");

            _context.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
