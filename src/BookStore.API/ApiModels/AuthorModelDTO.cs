using BookStore.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace BookStore.API.ApiModels
{
    public class AuthorModelDTO
    {
        [Required(ErrorMessage = "Author Name Is Required")]
        public string Name { set; get; }

        [Required(ErrorMessage = "Nationality Id Is Required")]
        public string NationalityId { set; get; }

        public static AuthorModelDTO FromAuthor(Author item)
        {
            return new AuthorModelDTO
            {
                Name = item.Name,
                NationalityId = item.NationalityId
            };
        }
    }
}