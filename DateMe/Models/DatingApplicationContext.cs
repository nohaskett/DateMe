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

                new Major { MajorID = 1, MajorName = "Information Systems"},
                new Major { MajorID = 2, MajorName = "Computer Science"},
                new Major { MajorID = 3, MajorName = "Magic"},
                new Major { MajorID = 4, MajorName = "Banana Stand"},
                new Major { MajorID = 5, MajorName = "Business Administration"}
                );
        }
    }
}
