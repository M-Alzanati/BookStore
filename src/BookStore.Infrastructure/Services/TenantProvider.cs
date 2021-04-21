using System.Linq;
using BookStore.Core.Entities;
using BookStore.Core.Interfaces;
using BookStore.Infrastructure.Data;

namespace BookStore.Infrastructure.Services
{
    public class TenantProvider : ITenantProvider
    {
        private readonly IdentityDbContext _identityDbContext;

        private readonly ITenantService _tenantService;

        public TenantProvider(IdentityDbContext identityDbContext, ITenantService tenantService)
        {
            _identityDbContext = identityDbContext;
            _tenantService = tenantService;
        }

        public Tenant GetTenant()
        {
            var tenants = _identityDbContext?.Tenants;
            return tenants.FirstOrDefault(r => r.ApiKey == _tenantService.GetTenantId());
        }
    }
}