namespace Homework_21.Models
{
    public class User
    {
        public int ID { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Role { get; set; }
    }
}
