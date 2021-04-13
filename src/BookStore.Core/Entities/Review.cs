using BookStore.SharedKernel;
using System.Collections.Generic;

namespace BookStore.Core.Entities
{
    public class Review : BaseEntity
    {
        public string Text { set; get; }

        public byte Rating { set; get; }

        public ICollection<Book> Books { set; get; }

        public Tenant Tenant { set; get; }
    }
}