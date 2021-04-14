using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using BookStore.API.ApiModels;
using BookStore.SharedKernel.Interfaces;
using BookStore.Core.Interfaces;
using BookStore.Core.Entities;

namespace BookStore.API.Controllers
{
    [AllowAnonymous]
    public class BookController : BaseApiController
    {
        private readonly ILogger<BookController> _logger;

        private readonly IRepository _repository;

        private readonly ITenantService _tenantService;

        public BookController(ILogger<BookStoreController> logger, IRepository repository, ITenantService tenantService)
        {
            _logger = logger;
            _repository = repository;
            _tenantService = tenantService;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddBook([FromBody] BookModelDTO model)
        {
            if (ModelState.IsValid)
            {
                var tenantId = _tenantService.GetTenantId();
                var book = BookModelDTO.FromBookDTO(model);
                var addedBook = await _repository.AddAsync<Book>(book);
                return (Ok(addedBook));
            }

            return BadRequest(ModelState);
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var tenantId = _tenantService.GetTenantId();
            var allBooks = await _repository.ListAsync<Book>();
            return Ok(BookModelDTO.FromBook(allBooks));
        }

        [HttpGet]
        [Route("{name}")]
        public async Task<IActionResult> GetBook([FromRoute] string name)
        {
            var tenantId = _tenantService.GetTenantId();
            var myBook = await _repository.GetByIdAsync<Book>(book => book.Name == name);
            return Ok(BookModelDTO.FromBook(myBook));
        }

        [HttpPost]
        [Route("reviews/add")]
        public async Task<IActionResult> AddReview([FromBody] ReviewModelDTO review)
        {
            if (ModelState.IsValid)
            {
                var tenantId = _tenantService.GetTenantId();
                var myReview = ReviewModelDTO.FromReviewDTO(review);
                var addedReview = await _repository.AddAsync<Review>(myReview);
                return Ok(addedReview);
            }

            return BadRequest(ModelState);
        }
    }
}
