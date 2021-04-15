using Xunit;
using BookStore.API;
using System.Net.Http;
using BookStore.API.ApiModels;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace BookStore.IntegrationTests.Api
{
    public class BookApi : IClassFixture<CustomWebApplicationLoader<Startup>>
    {
        private readonly HttpClient _client;

        private const string email = "admin@gmail.com";

        private const string password = "P@$$w0rd";

        private string token = string.Empty;

        public BookApi(CustomWebApplicationLoader<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        public async Task SetToken()
        {
            var loginModel = new LoginModelDTO { Email = email, Password = password };
            var response = await _client.PostAsync("/auth/login", ContentHelper.GetStringContent(loginModel));
            var stream = await response.Content.ReadAsStreamAsync();

            if (stream == null) return;

            var readStream = new StreamReader(stream, Encoding.UTF8);
            var text = readStream.ReadToEnd();

            dynamic body = JsonConvert.DeserializeObject<object>(text);
            if (body == null) return;

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", body.token.ToString());
        }

        [Fact]
        public async Task CanAddNewBook()
        {
            await SetToken();

            var model = new BookModelDTO();
            var response = await _client.PostAsync("/books/add", ContentHelper.GetStringContent(model));
            var stringResponse = await response.Content.ReadAsStringAsync();

            Assert.NotNull(stringResponse);
        }

        [Fact]
        public async Task CanGetBookDetails()
        {
            var model = new BookModelDTO();
            var response = await _client.PostAsync("/api/books/add", ContentHelper.GetStringContent(model));
            var stringResponse = await response.Content.ReadAsStringAsync();

            Assert.NotNull(stringResponse);
        }
    }
}