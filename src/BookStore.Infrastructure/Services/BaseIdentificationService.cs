using System.Collections.Generic;
using BookStore.Core.DTO;
using BookStore.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace BookStore.Infrastructure.Services
{
    public abstract class BaseIdentificationService : ITenantIdentificationService<HttpContext>
    {
        protected readonly TenantMapping _tenants;

        public BaseIdentificationService(IConfiguration configuration)
        {
            this._tenants = configuration.GetTenantMapping();
        }

        public BaseIdentificationService(TenantMapping tenants)
        {
            this._tenants = tenants;
        }

        public IEnumerable<string> GetAllTenants()
        {
            return this._tenants.Tenants.Values;
        }

        public abstract string GetCurrentTenant(HttpContext context);
    }
}