using Book.Models;
using Book.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Book.DataAccess
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

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

            modelBuilder.Entity<Product>().HasData(
                    new Product { Id = 1, Title = "The Laws of Human Nature", Description="Unwritten rules of life that will guide you through your journey as a human being.", ISBN="123-ABC-4567-89D", Author="Robert Greene", ListPrice=28.5, Price=25, Price50=23, Price100=19.75},
                    new Product { Id = 2, Title = "48 Laws of Power", Description = "48 Laws to become powerful.", ISBN = "07-222-ABCD-8F", Author = "Robert Greene", ListPrice = 32, Price = 30, Price50 = 28, Price100 = 25 },
                    new Product { Id = 3, Title = "Crime and Punishment", Description = "An individual's morality is shaped by one's nature.", ISBN = "022-77GKL-54321", Author = "Fyodor Dostoevsky", ListPrice = 22, Price = 21, Price50 = 19, Price100 = 17 }
                );
        }
    }
}
