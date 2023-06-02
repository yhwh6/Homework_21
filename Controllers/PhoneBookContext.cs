using Homework_19.Models;
using Microsoft.EntityFrameworkCore;

public class PhoneBookContext : DbContext
{
    public DbSet<Contact> Contacts { get; set; }

    public PhoneBookContext(DbContextOptions<PhoneBookContext> options) : base(options)
    {
    }
}