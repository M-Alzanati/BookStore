using System.Net.Http;
using BookStore.API;
using BookStore.API.ApiModels;
using BookStore.IntegrationTests.Base;
using Xunit;
using System.Threading.Tasks;
using System.Net;

namespace BookStore.IntegrationTests.Api
{
    public class ReviewApi : BaseTest
    {
        private readonly HttpClient _context;

        public ReviewApi(CustomWebApplicationLoader<Startup> factory) : base(factory)
        {
            _context = factory.CreateClient();
        }

        [Fact]
        public async Task CanAddNewReivew()
        {
            await SetToken();

            var model = new ReviewModelDTO();
            var response = await Client.PostAsync("/reviews/add", ContentHelper.GetStringContent(model));

            Assert.NotNull(response.StatusCode);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}