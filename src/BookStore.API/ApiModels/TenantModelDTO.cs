using BookStore.Core.Entities;

namespace BookStore.API.ApiModels
{
    public class TenantModelDTO
    {
        public string Name { set; get; }

        public string ApiKey { set; get; }

        public static TenantModelDTO FromTenant(Tenant item)
        {
            return new TenantModelDTO
            {
                Name = item.Name,
                ApiKey = item.ApiKey
            };
        }
    }
}