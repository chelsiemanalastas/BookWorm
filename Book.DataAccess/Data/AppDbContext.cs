using Book.Models;
using Microsoft.EntityFrameworkCore;

namespace Book.DataAccess
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                    new Category { Id = 1, Name = "Action", DisplayOrder = 20 },
                    new Category { Id = 2, Name = "Thriller", DisplayOrder = 15 },
                    new Category { Id = 3, Name = "Adventure", DisplayOrder = 33 },
                    new Category { Id = 4, Name = "Comedy", DisplayOrder = 45 },
                    new Category { Id = 5, Name = "Educational", DisplayOrder = 27 },
                    new Category { Id = 6, Name = "Self-help", DisplayOrder = 16 }
                );
        }
    }
}
