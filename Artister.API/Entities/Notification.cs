namespace Artister.API.Entities
{
    public class Notification
    {
        public int UserId { get; set; }
        public string Message { get; set; }
        public User User { get; set; }
    }
}
