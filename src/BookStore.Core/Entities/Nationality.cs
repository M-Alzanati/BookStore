using System.Collections.Generic;
using BookStore.SharedKernel;

namespace BookStore.Core.Entities
{
    public class Nationality : BaseEntity
    {
        public string Name { set; get; }

        public Author Author { set; get; }

        public Tenant Tenant { set; get; }
    }
}