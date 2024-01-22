using Artister.API.Configs;
using Artister.API.Entities;
using Artister.API.Models.Notification;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Artister.API.Services
{
    public interface INotificationService
    {
        Task<NotificationDto> GetById(int id);
        Task<List<NotificationDto>> GetByUserId(int userId);
        Task<int> Create(CreateNotificationDto dto);
        void Delete(int id);
        void Update(UpdateNotificationDto dto, int id);
    }
    public class NotificationService : INotificationService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        public NotificationService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<NotificationDto> GetById(int id)
        {
            var notification = await _context
                .Notifications
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (notification == null) throw new DirectoryNotFoundException();

            return _mapper.Map<NotificationDto>(notification);

        }
        public async Task<List<NotificationDto>> GetByUserId(int userId)
        {
            var notification = await _context
               .Notifications
               .Where(x => x.UserId == userId)
               .ToListAsync();

            if (notification == null) throw new DirectoryNotFoundException();

            return _mapper.Map<List<NotificationDto>>(notification);
        }
        public async Task<int> Create(CreateNotificationDto dto)
        {
            var notification = _mapper.Map<Notification>(dto);
            await _context.AddAsync(notification);
            await _context.SaveChangesAsync();

            return notification.Id;
        }
        public async void Delete(int id)
        {
            var notification = await _context
                .Notifications
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (notification == null) throw new DirectoryNotFoundException();

            _context.Remove(notification);
            await _context.SaveChangesAsync();
        }
        public async void Update(UpdateNotificationDto dto, int id)
        {
            var notification = await _context
                .Notifications
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (notification == null) throw new DirectoryNotFoundException();

            notification.UserId = dto.UserId ?? notification.UserId;
            notification.Message = dto.Message ?? dto.Message;

            await _context.SaveChangesAsync();
        }
    }
}
