using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using BookStore.API;
using BookStore.API.ApiModels;
using Newtonsoft.Json;
using Xunit;

namespace BookStore.IntegrationTests.Base
{
    public abstract class BaseTest : IClassFixture<CustomWebApplicationLoader<Startup>>
    {
        protected readonly HttpClient Client;

        public BaseTest(CustomWebApplicationLoader<Startup> factory)
        {
            Client = factory.CreateClient();
        }

        public async Task SetToken()
        {
            var loginModel = new LoginModelDTO { Email = Constants.EMAIL, Password = Constants.PASSWORD };
            var response = await Client.PostAsync("/auth/login", ContentHelper.GetStringContent(loginModel));
            var stream = await response.Content.ReadAsStreamAsync();

            if (stream == null) return;

            var readStream = new StreamReader(stream, Encoding.UTF8);
            var text = readStream.ReadToEnd();

            dynamic body = JsonConvert.DeserializeObject<object>(text);
            if (body == null) return;

            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", body.token.ToString());
        }
    }
}