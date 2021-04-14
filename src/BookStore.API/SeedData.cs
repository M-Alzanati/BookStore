using System;
using System.Linq;
using BookStore.Core.Entities;
using BookStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.API
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = serviceProvider.GetRequiredService<AppDbContext>())
            {
                // Look for default tenants
                if (context.Tenants.Any()) return;

                // add default tenants
                PopulateDb(context);
            }
        }

        private static void PopulateDb(AppDbContext context)
        {
            var store1 = new Tenant
            {
                Name = "bookstore 1",
                ApiKey = "0d00e512-9d25-11eb-8425-c8d3ff93c86f"
            };
            context.Tenants.Add(store1);

            var store2 = new Tenant
            {
                Name = "bookstore 2",
                ApiKey = "3058d2bd-9d25-11eb-8425-c8d3ff93c86f"
            };
            context.Tenants.Add(store2);

            context.SaveChanges();
        }
    }
}