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
                .Property(r => r.Id)
                .ValueGeneratedOnAdd();

            builder
                .HasOne<Tenant>(r => r.Tenant)
                .WithMany(t => t.Reviews)
                .IsRequired();

            builder.HasQueryFilter(a => !string.IsNullOrEmpty(a.TenantId));
        }
    }
}