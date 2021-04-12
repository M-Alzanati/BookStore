using BookStore.SharedKernel;
using System.Collections.Generic;

namespace BookStore.Core.Entities
{
    public class Book : BaseEntity
    {
        public string Name { set; get; }

        public decimal Price { set; get; }

        public Author Author { set; get; }

        public Category Category { set; get; }

        public ICollection<Review> Reviews { set; get; }
    }
}