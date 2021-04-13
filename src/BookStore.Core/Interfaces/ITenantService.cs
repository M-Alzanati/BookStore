using System;
using System.Threading.Tasks;

namespace BookStore.Core.Interfaces
{
    public interface ITenantService
    {
        Task<string> GetTenantId();
    }
}