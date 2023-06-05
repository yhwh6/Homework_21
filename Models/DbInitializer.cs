namespace Homework_21.Models
{
    public static class DbInitializer
    {
        public static void Seed(PhoneBookContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Users.Any())
            {
                var user = new User
                {
                    ID = 1,
                    Username = "test",
                    Password = "test",
                    Role = "Authorized"
                };

                context.Users.Add(user);
                context.SaveChanges();
            }
        }
    }
}
