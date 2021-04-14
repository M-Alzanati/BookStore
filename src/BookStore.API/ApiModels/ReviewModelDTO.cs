using BookStore.Core.Entities;

namespace BookStore.API.ApiModels
{
    public class ReviewModelDTO
    {
        public string Text { set; get; }

        public byte Rating { set; get; }

        public string BookId { set; get; }

        public static ReviewModelDTO FromReview(Review item)
        {
            return new ReviewModelDTO
            {
                Text = item.Text,
                Rating = item.Rating,
                BookId = item.BookId
            };
        }

        public static Review FromReviewDTO(ReviewModelDTO item)
        {
            return new Review
            {
                Text = item.Text,
                Rating = item.Rating,
                BookId = item.BookId
            };
        }
    }
}