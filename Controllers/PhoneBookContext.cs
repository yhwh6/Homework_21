using Homework_21.Models;
using Microsoft.EntityFrameworkCore;

public class PhoneBookContext : DbContext
{
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<User> Users { get; set; }

    public PhoneBookContext(DbContextOptions<PhoneBookContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed the database with a test user
        modelBuilder.Entity<User>().HasData(
            new User
            {
                ID = 1,
                Username = "test",
                Password = "test",
                Role = "Authorized"
            });
    }
}