using System.Linq;
using Microsoft.EntityFrameworkCore;
using BookStore.Core.Entities;
using Ardalis.EFCore.Extensions;
using BookStore.Core.Interfaces;

namespace BookStore.Infrastructure.Data
{
    /// <summary>
    /// The application dbcontext
    /// </summary>
    public class AppDbContext : DbContext
    {
        private readonly ITenantProvider _tenantProvider;

        public AppDbContext(DbContextOptions<AppDbContext> options, ITenantProvider tenantProvider)
            : base(options)
        {
            _tenantProvider = tenantProvider;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var tenant = _tenantProvider?.GetTenant();
            if (tenant != null)
                optionsBuilder.UseMySQL(tenant?.DatabaseConnectionString);

            base.OnConfiguring(optionsBuilder);
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
    }
}
