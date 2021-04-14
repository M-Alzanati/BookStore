using Microsoft.EntityFrameworkCore;
using BookStore.Core.Entities;
using Ardalis.EFCore.Extensions;

namespace BookStore.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyAllConfigurationsFromCurrentAssembly();
        }

        public DbSet<Book> Books { set; get; }

        public DbSet<Author> Authors { set; get; }

        public DbSet<Category> Categories { set; get; }

        public DbSet<Nationality> Nationalities { set; get; }

        public DbSet<Review> Reviews { set; get; }

        public DbSet<Tenant> Tenants { set; get; }
    }
}
