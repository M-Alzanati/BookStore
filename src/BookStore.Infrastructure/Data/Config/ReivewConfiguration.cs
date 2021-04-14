using BookStore.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infrastructure.Data.Config
{
    public class ReivewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(r => r.Id);

            builder
                .HasOne<Tenant>(r => r.Tenant)
                .WithOne(t => t.Review)
                .HasForeignKey<Review>(r => r.TenantId)
                .IsRequired();

            builder.HasQueryFilter(a => !string.IsNullOrEmpty(a.TenantId));
        }
    }
}