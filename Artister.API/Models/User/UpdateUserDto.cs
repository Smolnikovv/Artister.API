namespace Artister.API.Models.User
{
    public class UpdateUserDto
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public double? Points { get; set; }
        public string? Password { get; set; }
        public bool? IsAdmin { get; set; }
    }
}
