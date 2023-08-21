using Artister.API.Configs;
using Artister.API.Entities;
using Artister.API.Models.User;
using AutoMapper;

namespace Artister.API.Services
{
    public interface IUserService
    {
        List<UserDto> GetUsers();
        UserDto GetUserById(int id);
        UserDto GetUserByName(string name);
        int Create(CreateUserDto dto);
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
        public List<UserDto> GetUsers()
        {
            var users = _context
                .Users
                .ToList();

            if (users == null) throw new Exception("Not found");

            return _mapper.Map<List<UserDto>>(users);
        }
        public UserDto GetUserById(int id)
        {
            var user = _context
                .Users
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (user == null) throw new Exception("Not found");

            return _mapper.Map<UserDto>(user);
        }
        public UserDto GetUserByName(string name)
        {
            var user = _context
                .Users
                .Where(x => x.Name == name)
                .FirstOrDefault();

            if (user == null) throw new Exception("Not found");

            return _mapper.Map<UserDto>(user);
        }
        public int Create(CreateUserDto dto)
        {
            var user = _mapper.Map<User>(dto);
            _context.Add(user);
            _context.SaveChanges();

            return user.Id;
        }
        public void Update(UpdateUserDto dto, int id)
        {
            var user = _context
                .Users
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (user == null) throw new Exception("Not found");

            user.Email = dto.Email ?? user.Email;
            user.Points = dto.Points ?? user.Points;
            user.Password = dto.Password ?? user.Password;
            user.Name = dto.Name ?? user.Name;
        }
        public void Delete(int id)
        {
            var user = _context
                .Users
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (user == null) throw new Exception("Not found");

            _context.Remove(user);
            _context.SaveChanges();
        }
    }
}
