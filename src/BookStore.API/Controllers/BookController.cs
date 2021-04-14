using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BookStore.API.ApiModels;
using BookStore.SharedKernel.Interfaces;
using BookStore.Core.Interfaces;
using BookStore.Core.Entities;

namespace BookStore.API.Controllers
{
    [Authorize]
    [Route("Books")]
    public class BookController : BaseApiController
    {
        private readonly ILogger<BookController> _logger;

        private readonly IRepository _repository;

        private readonly ITenantService _tenantService;

        public BookController(ILogger<BookController> logger, IRepository repository, ITenantService tenantService)
        {
            _logger = logger;
            _repository = repository;
            _tenantService = tenantService;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddBook([FromBody] BookModelDTO model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var tenantId = await _tenantService.GetTenantIdAsync();
            if (string.IsNullOrEmpty(tenantId)) return BadRequest("Tenant key is not correct");

            var book = BookModelDTO.FromBookDTO(model);
            book.TenantId = tenantId;

            var addedBook = await _repository.AddAsync<Book>(book);
            return (Ok(addedBook));
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var tenantId = _tenantService.GetTenantIdAsync();
            var allBooks = await _repository.ListAsync<Book>();
            return Ok(BookModelDTO.FromBook(allBooks));
        }

        [HttpGet]
        [Route("{name}")]
        public async Task<IActionResult> GetBook([FromRoute] string name)
        {
            var tenantId = _tenantService.GetTenantIdAsync();
            var myBook = await _repository.GetByIdAsync<Book>(book => book.Name == name);
            return Ok(BookModelDTO.FromBook(myBook));
        }
    }
}
