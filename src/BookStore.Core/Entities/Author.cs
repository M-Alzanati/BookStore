using BookStore.SharedKernel;
using System.Collections.Generic;

namespace BookStore.Core.Entities
{
    public class Author : BaseEntity
    {
        public string Name { set; get; }

        public Nationality Nationality { set; get; }

        public ICollection<Book> Books { set; get; }

        public Tenant Tenant { set; get; }
    }
}