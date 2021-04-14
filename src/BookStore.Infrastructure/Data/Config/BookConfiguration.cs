using BookStore.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infrastructure.Data.Config
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(r => r.Id);

            builder
                .Property(r => r.Id)
                .ValueGeneratedOnAdd();

            builder
                .HasMany<Review>(b => b.Reviews)
                .WithOne(r => r.Book)
                .HasForeignKey(r => r.BookId);

            builder
                .HasMany<Category>(b => b.Categories)
                .WithOne(c => c.Book)
                .HasForeignKey(c => c.BookId);

            builder
                .HasOne<Tenant>(b => b.Tenant)
                .WithMany(t => t.Books)
                .IsRequired();

            builder.HasQueryFilter(a => !string.IsNullOrEmpty(a.TenantId));

            builder.HasIndex(b => b.Name).IsUnique();
        }
    }
}
