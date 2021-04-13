using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookStore.API.Controllers
{
    [Authorize]
    public class BookStoreController : BaseApiController
    {
        private readonly ILogger<BookStoreController> _logger;

        public BookStoreController(ILogger<BookStoreController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("books/add")]
        public async Task<IActionResult> AddBook()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("books")]
        public async Task<IActionResult> GetBooks()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("books/{name}")]
        public async Task<IActionResult> GetBooks([FromRoute] string bookName)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("reviews/add")]
        public async Task<IActionResult> AddReview()
        {
            throw new NotImplementedException();
        }
    }
}
