using System.Collections.Generic;
using BookStore.SharedKernel;

namespace BookStore.Core.Entities
{
    /// <summary>
    /// Represent nationality of author
    /// </summary>
    public class Nationality : BaseEntity
    {
        public string Name { set; get; }

        public ICollection<Author> Authors { set; get; }
    }
}