using System;
using System.Linq;
using BookStore.Core.DTO;
using BookStore.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace BookStore.Infrastructure.Services
{
    public class QueryStringTenantIdentificationService : BaseIdentificationService
    {
        public QueryStringTenantIdentificationService(IConfiguration configuration)
            : base(configuration)
        {
        }

        public QueryStringTenantIdentificationService(TenantMapping tenants)
            : base(tenants)
        {
        }

        public override string GetCurrentTenant(HttpContext context)
        {
            // api key
            var tenant = context.Request.Query["Tenant"].ToString();

            if (string.IsNullOrWhiteSpace(tenant) || !this._tenants.Tenants.Values.Contains(tenant,
                StringComparer.InvariantCultureIgnoreCase))
            {
                return this._tenants.Default;
            }

            if (this._tenants.Tenants.TryGetValue(tenant, out var mappedTenant))
            {
                return mappedTenant;
            }

            return tenant;
        }
    }
}