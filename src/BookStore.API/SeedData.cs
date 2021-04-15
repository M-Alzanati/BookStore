using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.Core.Entities;
using BookStore.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.API
{
    /// <summary>
    /// Seed the database for the first time, if tenants already exist then this class will not touch the database
    /// </summary>
    public static class SeedData
    {
        private const string adminUser = "admin@gmail.com";

        private const string adminPassword = "P@$$w0rd";

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = serviceProvider.GetRequiredService<AppDbContext>())
            {
                // Look for default tenants
                if (!context.Tenants.Any())
                {
                    // add default tenants
                    PopulateDb(context);
                }
            }

            using (var context = serviceProvider.GetRequiredService<IdentityDbContext>())
            {
                // add admin user
                PopulateIdentityDb(serviceProvider);
            }
        }

        private async static void PopulateIdentityDb(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var user = await userManager.FindByNameAsync(adminUser);

            if (user == null)
            {
                user = new ApplicationUser() { Email = adminUser, UserName = adminUser };
                var result = await userManager.CreateAsync(user, adminPassword);
                if (!result.Succeeded)
                {
                    throw new Exception("Cannot create user: " + result.Errors.FirstOrDefault());
                }
            }
        }

        private static void PopulateDb(AppDbContext context)
        {
            var tenants = GetTenants();
            context.Tenants.AddRange(tenants);

            var nationalities = GetNationalities(tenants);
            context.Set<Nationality>().AddRange(nationalities);

            var categories = GetCategories(tenants);
            context.Set<Category>().AddRange(categories);

            context.SaveChanges();
        }

        private static IEnumerable<Tenant> GetTenants()
        {
            var store1 = new Tenant
            {
                Name = "bookstore 1",
                ApiKey = "0d00e512-9d25-11eb-8425-c8d3ff93c86f"
            };

            var store2 = new Tenant
            {
                Name = "bookstore 2",
                ApiKey = "3058d2bd-9d25-11eb-8425-c8d3ff93c86f"
            };

            var tenants = new List<Tenant>() { store1, store2 };
            return tenants;
        }

        private static IEnumerable<Nationality> GetNationalities(IEnumerable<Tenant> tenants)
        {
            var nationalities = new List<Nationality>();

            foreach (var tenant in tenants)
            {
                var egyptian = new Nationality
                {
                    Name = "Egyptian",
                    TenantId = tenant.Id
                };

                var american = new Nationality
                {
                    Name = "American",
                    TenantId = tenant.Id
                };

                nationalities.Add(egyptian);
                nationalities.Add(american);
            }

            return nationalities;
        }

        private static IEnumerable<Category> GetCategories(IEnumerable<Tenant> tenants)
        {
            var categories = new List<Category>();

            foreach (var tenant in tenants)
            {
                var science = new Category
                {
                    Name = "Science",
                    TenantId = tenant.Id
                };

                var history = new Category
                {
                    Name = "History",
                    TenantId = tenant.Id
                };

                var technology = new Category
                {
                    Name = "Technology",
                    TenantId = tenant.Id
                };

                categories.Add(science);
                categories.Add(history);
                categories.Add(technology);
            }

            return categories;
        }
    }
}