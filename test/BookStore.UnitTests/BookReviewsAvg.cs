using Xunit;
using BookStore.Core.Entities;

namespace BookStore.UnitTests
{
    public class BookReviewsAvg
    {
        [Fact]
        public void CalculateAvg()
        {
            var review1 = new Review() { Rating = 5 };
            var review2 = new Review() { Rating = 5 };
            var review3 = new Review() { Rating = 5 };
            var reviews = new[] { review1, review2, review3 };

            var book = new BookBuilder()
                .WithDefalutValues()
                .WithReviews(reviews)
                .Build();

            var result = book.GetAvgRating();
            Assert.NotNull(result);
            Assert.Equal(5, result.Value);
        }
    }
}