using System.Collections.Generic;
using BookStore.SharedKernel;

namespace BookStore.Core.Entities
{
    public class Nationality : BaseEntity
    {
        public string Name { set; get; }

        public ICollection<Author> Authors { set; get; }

        public string TenantId { set; get; }

        public Tenant Tenant { set; get; }
    }
}