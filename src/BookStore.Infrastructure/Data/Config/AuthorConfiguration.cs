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
                .HasMany<Book>(a => a.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId)
                .IsRequired();

            builder
                .HasOne<Nationality>(a => a.Nationality)
                .WithOne(n => n.Author)
                .HasForeignKey<Author>(a => a.NationalityId)
                .IsRequired();

            builder
                .HasOne<Tenant>(a => a.Tenant)
                .WithOne(t => t.Author)
                .HasForeignKey<Author>(a => a.TenantId)
                .IsRequired();
        }
    }
}