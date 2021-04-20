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

        public ReviewApi(CustomWebApplicationLoader<Startup> factory)
            : base(factory)
        {

        }

        [Fact]
        public async Task CanAddNewReivew()
        {
            // arrange
            await SetToken();

            var book = await Repository.GetBook();
            var model = new ReviewModelDTO() { Rating = 4, BookName = book.Name, Text = "Great Book" };

            // act
            var response = await Client.PostAsync($"/reviews/add?TenantKey={Constants.TENANT_KEY}", ContentHelper.GetStringContent(model));

            // assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}