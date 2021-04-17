using System;
using System.Linq;
using BookStore.Core.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace BookStore.Infrastructure.Services
{
    /// <summary>
    /// get tenant key from query string
    /// </summary>
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
            // tenant key
            var tenant = context.Request.Query["TenantKey"].ToString();

            if (string.IsNullOrWhiteSpace(tenant) ||
                !this._tenants.Tenants.Keys.Contains(tenant, StringComparer.InvariantCultureIgnoreCase))
            {
                return this._tenants.Default;
            }

            if (this._tenants.Tenants.TryGetValue(tenant, out var mappedTenantDate))
            {
                var tenantExpirationDate = DateTime.Parse(mappedTenantDate);
                if (DateTime.Now > tenantExpirationDate) {
                    return null;
                }

                return tenant;
            }

            return null;
        }
    }
}
