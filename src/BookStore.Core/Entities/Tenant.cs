using BookStore.SharedKernel;
using System.Collections.Generic;

namespace BookStore.Core.Entities
{
    public class Tenant : BaseEntity
    {
        public string ApiKey { set; get; }

        public string Name { set; get; }

        public bool IsActive { set; get; }

        public Author Author { set; get; }

        public Book Book { set; get; }

        public Category Category { set; get; }

        public Nationality Nationality { set; get; }

        public Review Review { set; get; }
    }
}