using System;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Core.Entities;
using BookStore.Infrastructure.Data;
using BookStore.IntegrationTests.Base;

namespace BookStore.IntegrationTests
{
    public class EfTestRepository : BaseEfRepoTestFixture
    {
        private readonly EfRepository _repo;

        public EfTestRepository(IServiceProvider context) : base(context)
        {
            _repo = GetRepository();
        }

        public async Task<Nationality> GetNationality()
        {
            var nationalities = await _repo.ListAsync<Nationality>();
            return nationalities.FirstOrDefault();
        }

        public async Task<Category> GetCategory()
        {
            var categories = await _repo.ListAsync<Category>();
            return categories.FirstOrDefault();
        }

        public async Task<Tenant> GetTenant()
        {
            var tenants = await _repo.ListAsync<Tenant>();
            return tenants.FirstOrDefault();
        }

        public async Task<Author> AddAuthor()
        {
            var nationality = await GetNationality();
            var tenant = await GetTenant();
            var author = new Author { Name = "Mohamed", NationalityId = nationality.Id, TenantId = tenant.Id };

            var addedAuthor = await _repo.AddAsync<Author>(author);
            return addedAuthor;
        }

        public async Task<Author> GetAuthor()
        {
            var authors = await _repo.ListAsync<Author>();
            return authors.FirstOrDefault();
        }

        public async Task<Author> AddBook()
        {
            var nationality = await GetCategory();
            var tenant = await GetTenant();
            var author = new Author { Name = "Mohamed", NationalityId = nationality.Id, TenantId = tenant.Id };

            var addedAuthor = await _repo.AddAsync<Author>(author);
            return addedAuthor;
        }

        public async Task<Book> GetBook()
        {
            await AddBook();
            var books = await _repo.ListAsync<Book>();
            return books.FirstOrDefault();
        }
    }
}