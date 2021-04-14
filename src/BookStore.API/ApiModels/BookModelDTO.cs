using BookStore.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.API.ApiModels
{
    public class BookModelDTO
    {
        public string Name { set; get; }

        public decimal Price { set; get; }

        public string AuthorId { set; get; }

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