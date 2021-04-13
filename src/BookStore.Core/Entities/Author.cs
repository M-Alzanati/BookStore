using BookStore.SharedKernel;
using System.Collections.Generic;

namespace BookStore.Core.Entities
{
    public class Author : BaseEntity
    {
        public string Name { set; get; }

        public string NationalityId { set; get; }

        public virtual Nationality Nationality { set; get; }

        public string TenantId { set; get; }

        public Tenant Tenant { set; get; }

        public ICollection<Book> Books { set; get; }
    }
}