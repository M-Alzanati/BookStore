using BookStore.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infrastructure.Data.Config
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(r => r.Id);

            builder
                .Property(r => r.Id)
                .ValueGeneratedOnAdd();

            builder
                .HasMany<Book>(a => a.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId)
                .IsRequired();

            builder
                .HasOne<Nationality>(a => a.Nationality)
                .WithMany(n => n.Authors)
                .IsRequired();

            builder
                .HasOne<Tenant>(a => a.Tenant)
                .WithMany(t => t.Authors)
                .IsRequired();

            builder.HasQueryFilter(a => !string.IsNullOrEmpty(a.TenantId));
        }
    }
}