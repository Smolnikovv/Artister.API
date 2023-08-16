using Artister.API.Configs;
using Artister.API.Entities;
using Artister.API.Models.Notification;
using AutoMapper;

namespace Artister.API.Services
{
    public interface INotificationService
    {
        NotificationDto GetById(int id);
        List<NotificationDto> GetByUserId(int userId);
        int Create(CreateNotificationDto dto);
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
        public NotificationDto GetById(int id)
        {
            var notification = _context
                .Notifications
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (notification == null) throw new DirectoryNotFoundException();

            return _mapper.Map<NotificationDto>(notification);

        }
        public List<NotificationDto> GetByUserId(int userId)
        {
            var notification = _context
               .Notifications
               .Where(x => x.UserId == userId)
               .ToList();

            if (notification == null) throw new DirectoryNotFoundException();

            return _mapper.Map<List<NotificationDto>>(notification);
        }
        public int Create(CreateNotificationDto dto)
        {
            var notification = _mapper.Map<Notification>(dto);
            _context.Add(notification);
            _context.SaveChanges();

            return notification.Id;
        }
        public void Delete(int id)
        {
            var notification = _context
                .Notifications
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (notification == null) throw new DirectoryNotFoundException();

            _context.Remove(notification);
            _context.SaveChanges();
        }
        public void Update(UpdateNotificationDto dto, int id)
        {
            var notification = _context
                .Notifications
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (notification == null) throw new DirectoryNotFoundException();

            notification.UserId = dto.UserId ?? notification.UserId;
            notification.Message = dto.Message ?? dto.Message;

            _context.SaveChanges();
        }
    }
}
