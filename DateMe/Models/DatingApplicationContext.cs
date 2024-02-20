using Microsoft.EntityFrameworkCore;

namespace DateMe.Models
{
    public class DatingApplicationContext : DbContext // Liaison from the app to the database
    {
        public DatingApplicationContext(DbContextOptions<DatingApplicationContext> options) : base (options) // Constructor
        {
        }

        public DbSet<Application> Applications { get; set; }
    }
}
