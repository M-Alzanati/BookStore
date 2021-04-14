using BookStore.Core.Entities;

namespace BookStore.API.ApiModels
{
    public class AuthorModelDTO
    {
        public string Name { set; get; }

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