using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<Category> Kategori { get; set; } 
    }
}
