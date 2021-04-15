using Xunit;
using System.Net;
using BookStore.API;
using System.Net.Http;
using BookStore.IntegrationTests.Base;
using BookStore.API.ApiModels;
using System.Threading.Tasks;

namespace BookStore.IntegrationTests.Api
{
    public class BookApi : BaseTest
    {
        private readonly HttpClient _client;

        public BookApi(CustomWebApplicationLoader<Startup> factory) : base(factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CanAddNewBook()
        {
            await SetToken();

            var repo = new EfMockRepository();
            var author = await repo.AddAuthor();

            var model = new BookModelDTO() { Name = "MyBook", AuthorId = author.Id, };
            var response = await _client.PostAsync("/books/add", ContentHelper.GetStringContent(model));

            Assert.NotNull(response.StatusCode);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task CanGetBookDetails()
        {
            await SetToken();

            var model = new BookModelDTO();
            var response = await _client.PostAsync("/books", ContentHelper.GetStringContent(model));

            Assert.NotNull(response.StatusCode);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}