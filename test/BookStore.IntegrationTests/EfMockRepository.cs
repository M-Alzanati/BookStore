using System.Linq;
using System.Threading.Tasks;
using BookStore.Core.Entities;
using BookStore.IntegrationTests.Base;

namespace BookStore.IntegrationTests
{
    public class EfMockRepository : BaseEfRepoTestFixture
    {
        public async Task<Nationality> GetNationality()
        {
            var repo = GetRepository();
            var nationalities = await repo.ListAsync<Nationality>();
            return nationalities.FirstOrDefault();
        }

        public async Task<Category> GetCategory()
        {
            var repo = GetRepository();
            var categories = await repo.ListAsync<Category>();
            return categories.FirstOrDefault();
        }

        public async Task<Tenant> GetTenant()
        {
            var repo = GetRepository();
            var tenants = await repo.ListAsync<Tenant>();
            return tenants.FirstOrDefault();
        }

        public async Task<Author> AddAuthor()
        {
            var nationality = await GetNationality();
            var tenant = await GetTenant();
            var author = new Author { Name = "Mohamed", NationalityId = nationality.Id, TenantId = tenant.Id };

            var repo = GetRepository();
            var addedAuthor = await repo.AddAsync<Author>(author);
            return addedAuthor;
        }
    }
}