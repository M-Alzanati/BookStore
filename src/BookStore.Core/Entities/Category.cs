using BookStore.SharedKernel;
using System.Collections.Generic;

namespace BookStore.Core.Entities
{
    public class Category : BaseEntity
    {
        public string Name { set; get; }

        public string BookId { set; get; }

        public Book Book { set; get; }

        public string TenantId { set; get; }

        public Tenant Tenant { set; get; }
    }
}