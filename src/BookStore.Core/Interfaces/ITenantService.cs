using System;
using System.Threading.Tasks;

namespace BookStore.Core.Interfaces
{
    /// <summary>
    /// Represents the tenant service with will retrive tenant id from database
    /// </summary>
    public interface ITenantService
    {
        /// <summary>
        /// Get tenant id async
        /// </summary>
        /// <returns>tenant id</returns>
        Task<string> GetTenantIdAsync();
    }
}