using BookStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BookStore.API;
using System;

namespace BookStore.IntegrationTests.Base
{
    public abstract class BaseEfRepoTestFixture : IDisposable
    {
        protected AppDbContext _dbContext;

        private readonly IServiceScope _serviceScope;

        public BaseEfRepoTestFixture(IServiceProvider serviceProvider)
        {
            _serviceScope = serviceProvider.CreateScope();
            _dbContext = _serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
        }

        protected EfRepository GetRepository()
        {
            return new EfRepository(_dbContext);
        }

        public void Dispose()
        {
            _serviceScope?.Dispose();
        }
    }
}