using BookStore.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace BookStore.API.ApiModels
{
    public class BookModelDTO
    {
        [Required(ErrorMessage = "Book Name Is Required")]
        public string Name { set; get; }

        [Required(ErrorMessage = "Book Price Is Required")]
        public decimal Price { set; get; }

        [Required(ErrorMessage = "Book Author Id Is Required")]
        public string AuthorId { set; get; }

        [Required(ErrorMessage = "Book Category Id Is Required")]
        public string CategoryId { set; get; }

        public static BookModelDTO FromBook(Book item)
        {
            return new BookModelDTO
            {
                Name = item.Name,
                Price = item.Price,
                AuthorId = item.AuthorId,
                CategoryId = item.CategoryId
            };
        }

        public static IEnumerable<BookModelDTO> FromBook(IEnumerable<Book> books)
        {
            var list = new List<BookModelDTO>();
            return books.Select(book => new BookModelDTO
            {
                Name = book.Name,
                Price = book.Price,
                AuthorId = book.AuthorId,
                CategoryId = book.CategoryId
            }).ToList();
        }

        public static Book FromBookDTO(BookModelDTO item)
        {
            return new Book
            {
                Name = item.Name,
                Price = item.Price,
                AuthorId = item.AuthorId,
                CategoryId = item.CategoryId
            };
        }
    }
}