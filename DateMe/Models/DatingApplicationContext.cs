using Microsoft.EntityFrameworkCore;

namespace DateMe.Models
{
    public class DatingApplicationContext : DbContext // Liaison from the app to the database
    {
        public DatingApplicationContext(DbContextOptions<DatingApplicationContext> options) : base (options) // Constructor
        {
        }

        public DbSet<Application> Applications { get; set; }
        public DbSet<Major> Majors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // Seed data
        {
            modelBuilder.Entity<Major>().HasData(

                new Major { MajorId = 1, MajorName = "Information Systems"},
                new Major { MajorId = 2, MajorName = "Computer Science"},
                new Major { MajorId = 3, MajorName = "Magic"},
                new Major { MajorId = 4, MajorName = "Banana Stand"},
                new Major { MajorId = 5, MajorName = "Business Administration"}
                );
        }
    }
}
