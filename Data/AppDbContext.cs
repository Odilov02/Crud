using Crud2.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud2.Data
{
	public class AppDbContext:DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options)
	   : base(options)
		{
		}
		public DbSet<Product> products { get; set; }
		
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<Product>().HasData(
                new Product() { id = 1, name = "olma", salary = 123 },
            new Product() { id = 2, name = "olma2", salary = 123 },
            new Product() { id = 3, name = "olma3", salary = 123 });
        }
    }
}
