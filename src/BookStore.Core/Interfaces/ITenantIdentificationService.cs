namespace BookStore.Core.Interfaces
{
    public interface ITenantIdentificationService<T>
    {
        string GetCurrentTenant(T context);
    }
}