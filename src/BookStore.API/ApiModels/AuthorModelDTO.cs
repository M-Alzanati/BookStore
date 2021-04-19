using System.Linq;
using System.Collections.Generic;
using BookStore.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace BookStore.API.ApiModels
{
    public class AuthorModelDTO
    {
        public string Id { set; get; }

        [Required(ErrorMessage = "Author Name Is Required")]
        public string Name { set; get; }

        [Required(ErrorMessage = "Nationality Id Is Required")]
        public string NationalityId { set; get; }

        public IEnumerable<string> Books { set; get; }

        public static AuthorModelDTO FromAuthor(Author item)
        {
            return new AuthorModelDTO
            {
                Name = item.Name,
                NationalityId = item.NationalityId,
                Id = item.Id,
                Books = item.Books?.Select(r => r.Name)
            };
        }

        public static Author FromAuthorDTO(AuthorModelDTO item)
        {
            return new Author
            {
                Name = item.Name,
                NationalityId = item.NationalityId,
                Id = item.Id
            };
        }
    }
}