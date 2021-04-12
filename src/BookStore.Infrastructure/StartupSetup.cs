using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BookStore.Infrastructure.Data;

namespace BookStore.Infrastructure
{
    public static class StartupSetup
    {
        public static void AddDbContext(this IServiceCollection services, string connectionString) =>
            services.AddDbContext<AppDbContext>(options => options.UseMySQL(connectionString));
    }
}
