using System.Net.Http;
using BookStore.API;
using Xunit;
using System.Threading.Tasks;

namespace BookStore.IntegrationTests.Api
{
    public class ReviewApi : IClassFixture<CustomWebApplicationLoader<Startup>>
    {
        private readonly HttpClient _context;

        public ReviewApi(CustomWebApplicationLoader<Startup> factory)
        {
            _context = factory.CreateClient();
        }

        [Fact]
        public async Task CanAddNewReivew()
        {

        }
    }
}