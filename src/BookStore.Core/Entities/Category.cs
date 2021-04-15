using BookStore.SharedKernel;
using System.Collections.Generic;

namespace BookStore.Core.Entities
{
    /// <summary>
    /// Represent the books classifcations 
    /// </summary>
    public class Category : BaseEntity
    {
        public string Name { set; get; }

        public ICollection<Book> Books { set; get; }

        public string TenantId { set; get; }

        public Tenant Tenant { set; get; }
    }
}