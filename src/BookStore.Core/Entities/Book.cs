using System.Linq;
using BookStore.SharedKernel;
using System.Collections.Generic;

namespace BookStore.Core.Entities
{
    /// <summary>
    /// Book information like name, category, author
    /// </summary>
    public class Book : BaseEntity
    {
        public string Name { set; get; }

        public decimal Price { set; get; }

        public string AuthorId { set; get; }

        public Author Author { set; get; }

        public string CategoryId { set; get; }

        public Category Category { set; get; }

        public ICollection<Review> Reviews { set; get; }

        public double? GetAvgRating()
        {
            var avg = this.Reviews?.Select(r => r.Rating)?.Average(r => r);
            return avg;
        }
    }
}