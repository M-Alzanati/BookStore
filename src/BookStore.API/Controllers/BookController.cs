using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BookStore.API.ApiModels;
using BookStore.SharedKernel.Interfaces;
using BookStore.Core.Interfaces;
using BookStore.Core.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace BookStore.API.Controllers
{
    [Authorize]
    [Route("Books")]
    public class BookController : BaseApiController
    {
        private readonly IRepository _repository;

        private readonly ITenantService _tenantService;

        public BookController(IRepository repository, ITenantService tenantService)
        {
            _repository = repository;
            _tenantService = tenantService;
        }

        [HttpPost]
        [Route("add")]
        [SwaggerOperation(
            Summary = "Create new book",
            OperationId = "books.add")
        ]
        public async Task<IActionResult> AddBook([FromBody] BookModelDTO model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var addedBook = await _repository.AddAsync<Book>(BookModelDTO.FromBookDTO(model));
            return (Ok(BookModelDTO.FromBook(addedBook)));
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Get all books per tenant",
            OperationId = "books.get")
        ]
        public async Task<IActionResult> GetBooks()
        {
            var items = (await _repository.ListAsync<Book>())
                            .Select(BookModelDTO.FromBook);
            return (Ok(items));
        }

        [HttpGet]
        [Route("name/{name}")]
        [SwaggerOperation(
            Summary = "Get a book by name",
            OperationId = "books.name")
        ]
        public async Task<IActionResult> GetBookByName([FromRoute] string name)
        {
            var myBook = await _repository.GetByIdAsync<Book>(
                book => book.Reviews,
                book => book.Name == name
            );
            if (myBook == null) return BadRequest($"Book: {name} not found");

            return (Ok(BookModelDTO.FromBook(myBook)));
        }

        [HttpGet]
        [Route("id/{id}")]
        [SwaggerOperation(
            Summary = "Get a book by id",
            OperationId = "books.id")
        ]
        public async Task<IActionResult> GetBookById([FromRoute] string id)
        {
            var myBook = await _repository.GetByIdAsync<Book>(
                book => book.Id == id
            );

            return (Ok(BookModelDTO.FromBook(myBook)));
        }

        [HttpGet]
        [Route("categories")]
        [SwaggerOperation(
            Summary = "Get all categories per tenant",
            OperationId = "books.categories")
        ]
        public async Task<IActionResult> GetCategories()
        {
            var items = (await _repository.ListAsync<Category>())
                            .Select(CategoryModelDTO.FromCategory);
            return (Ok(items));
        }
    }
}
