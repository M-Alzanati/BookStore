using BookStore.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infrastructure.Data.Config
{
    public class NationalityConfiguration : IEntityTypeConfiguration<Nationality>
    {
        public void Configure(EntityTypeBuilder<Nationality> builder)
        {
            builder.HasKey(r => r.Id);

            builder
                .HasOne<Tenant>(n => n.Tenant)
                .WithOne(t => t.Nationality)
                .HasForeignKey<Nationality>(n => n.TenantId)
                .IsRequired();

            builder.HasQueryFilter(a => !string.IsNullOrEmpty(a.TenantId));
        }
    }
}