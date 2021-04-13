using BookStore.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infrastructure.Data.Config
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(r => r.Id);

            builder
                .HasOne<Tenant>(c => c.Tenant)
                .WithOne(t => t.Category)
                .HasForeignKey<Category>(c => c.TenantId)
                .IsRequired();
        }
    }
}