using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using BookStore.Core.Interfaces;
using BookStore.Core.DTO;

namespace BookStore.Infrastructure.Services
{
    /// <summary>
    /// Using host name to retrive tenant key from application.json
    /// </summary>
    public sealed class HostTenantIdentificationService : BaseIdentificationService
    {
        public HostTenantIdentificationService(IConfiguration configuration)
            : base(configuration)
        {
        }

        public HostTenantIdentificationService(TenantMapping tenants)
            : base(tenants)
        {
        }

        public override string GetCurrentTenant(HttpContext context)
        {
            if (!this._tenants.Tenants.TryGetValue(context.Request.Host.Host, out var tenant))
            {
                tenant = this._tenants.Default;
            }

            return tenant;
        }
    }
}