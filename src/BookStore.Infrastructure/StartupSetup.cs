using System;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using BookStore.Infrastructure.Data;
using BookStore.Core.Entities;
using BookStore.Core.DTO;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using BookStore.Core.Interfaces;
using BookStore.Infrastructure.Services;

namespace BookStore.Infrastructure
{
    /// <summary>
    /// This class hold extension methods to load database contexts, and a strategy to use tenant
    /// </summary>
    public static class StartupSetup
    {
        // public static void AddDbContext(this IServiceCollection services, string connectionString) =>
        //     services.AddDbContext<AppDbContext>(options => options.UseMySQL(connectionString));
        public static void AddIdentityDbContext(this IServiceCollection services, string connectionString, string defaultTenantConnectionString, string validIssuer, string validKey)
        {
            services.AddDbContext<AppDbContext>(o => { o.UseMySQL(defaultTenantConnectionString); });
            services.AddDbContext<IdentityDbContext>(opts => opts.UseMySQL(connectionString));

            services.AddDefaultIdentity<ApplicationUser>(opts =>
            {
                opts.SignIn.RequireConfirmedAccount = false;
            })
            .AddEntityFrameworkStores<IdentityDbContext>()
            .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = validIssuer,
                    ValidAudience = validIssuer,
                    ClockSkew = TimeSpan.FromMinutes(30),
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(validKey))
                };
            });

            services.AddTransient<ITenantProvider, TenantProvider>();
        }

        public static TenantMapping GetTenantMapping(this IConfiguration configuration)
        {
            var tenantMapping = new TenantMapping();
            configuration.GetSection("Tenants").Bind(tenantMapping);
            return tenantMapping;
        }

        public static void UseTenant(this IServiceCollection services) =>
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    }
}
