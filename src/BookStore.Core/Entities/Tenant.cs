using BookStore.SharedKernel;
using System.Collections.Generic;

namespace BookStore.Core.Entities
{
    public class Tenant : BaseEntity
    {
        public string ApiKey { set; get; }

        public string Name { set; get; }

        public bool IsActive { set; get; }

        public ICollection<Author> Authors { set; get; }

        public ICollection<Book> Books { set; get; }

        public ICollection<Category> Categories { set; get; }

        public ICollection<Nationality> Nationalities { set; get; }

        public ICollection<Review> Reviews { set; get; }
    }
}