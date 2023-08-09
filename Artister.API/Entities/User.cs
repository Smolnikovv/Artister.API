namespace Artister.API.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public double Points { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
