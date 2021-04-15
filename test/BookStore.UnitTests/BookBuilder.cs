using System.Collections.Generic;
using BookStore.Core.Entities;
using System.Linq;

namespace BookStore.UnitTests
{
    public class BookBuilder
    {
        private Book _book = new Book() { Reviews = new List<Review>() };

        public BookBuilder Id(string id)
        {
            _book.Id = id;
            return this;
        }

        public BookBuilder Name(string name)
        {
            _book.Name = name;
            return this;
        }

        public BookBuilder Price(decimal price)
        {
            _book.Price = price;
            return this;
        }

        public BookBuilder WithReview(Review review)
        {
            _book.Reviews?.Add(review);
            return this;
        }

        public BookBuilder WithReviews(IEnumerable<Review> reviews)
        {
            foreach (var review in reviews)
            {
                _book.Reviews?.Add(review);
            }

            return this;
        }

        public BookBuilder WithDefalutValues()
        {
            _book = new Book { Id = "1", Name = "MyBook", Price = 10, Reviews = new List<Review>() };
            return this;
        }

        public Book Build() => _book;
    }
}