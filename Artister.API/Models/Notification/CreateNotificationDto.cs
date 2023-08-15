using System.ComponentModel.DataAnnotations;

namespace Artister.API.Models.Notification
{
    public class CreateNotificationDto
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
