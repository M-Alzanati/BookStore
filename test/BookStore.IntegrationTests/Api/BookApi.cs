using Xunit;
using System;
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

        public BookApi(CustomWebApplicationLoader<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task CanAddNewBook()
        {
            // arrange
            await SetToken();

            var author = await Repository.AddAuthor();
            var category = await Repository.GetCategory();
            var model = new BookModelDTO() { Name = $"MyBook-{Guid.NewGuid().ToString()}", AuthorId = author.Id, CategoryId = category.Id };

            // act
            var response = await Client.PostAsync($"/books/add?TenantKey={Constants.TENANT_KEY}", ContentHelper.GetStringContent(model));

            // assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task CanGetBookDetails()
        {
            // arrange
            await SetToken();

            // act
            var response = await Client.GetAsync($"/books?TenantKey={Constants.TENANT_KEY}");

            // assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}