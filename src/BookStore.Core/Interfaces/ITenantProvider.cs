using BookStore.Core.Entities;

namespace BookStore.Core.Interfaces
{
    public interface ITenantProvider
    {
        Tenant GetTenant();
    }
}