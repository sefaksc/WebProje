using BookStore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Database
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<Category> Kategori { get; set; }

        public DbSet<Product> Urunler { get; set; }

        public DbSet<AppUser> Users { get; set; }

        public DbSet<ShoppingCart> ShoppingCart { get; set; }
    }
}
