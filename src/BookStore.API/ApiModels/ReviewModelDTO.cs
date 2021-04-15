using BookStore.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace BookStore.API.ApiModels
{
    public class ReviewModelDTO
    {
        [Required(ErrorMessage = "Review Text Is Required")]
        public string Text { set; get; }

        [Required(ErrorMessage = "Review Rating Is Required"), Range(1, 5)]
        public byte Rating { set; get; }

        [Required(ErrorMessage = "Book Id Is Required")]
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