using BookStore.SharedKernel;
using System.Collections.Generic;

namespace BookStore.Core.Entities
{
    /// <summary>
    /// Represent review per book per tenant
    /// </summary>
    public class Review : BaseEntity
    {
        public string Text { set; get; }

        public byte Rating { set; get; }

        public string BookId { set; get; }

        public Book Book { set; get; }
    }
}