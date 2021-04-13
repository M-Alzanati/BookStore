namespace BookStore.SharedKernel
{
    public abstract class BaseEntity
    {
        public string Id { get; set; }

        public string TenantId { set; get; }
    }
}
