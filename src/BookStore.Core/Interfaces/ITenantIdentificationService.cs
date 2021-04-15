namespace BookStore.Core.Interfaces
{
    /// <summary>
    /// This interface should be used to provide a mechansim for identify service
    /// </summary>
    /// <typeparam name="T">This should be an object that contains an information about how we should indentify our service</typeparam>
    public interface ITenantIdentificationService<T>
    {
        /// <summary>
        /// Get current tenant id based on tenant service
        /// </summary>
        /// <param name="context">context object</param>
        /// <returns>tenant id</returns>
        string GetCurrentTenant(T context);
    }
}