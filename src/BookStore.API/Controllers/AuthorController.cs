using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BookStore.API.ApiModels;
using BookStore.SharedKernel.Interfaces;
using BookStore.Core.Interfaces;
using BookStore.Core.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace BookStore.API.Controllers
{
    [Authorize]
    [Route("authors")]
    public class AuthorController : BaseApiController
    {
        private readonly IRepository _repository;

        private readonly ITenantService _tenantService;

        public AuthorController(IRepository repository, ITenantService tenantService)
        {
            _repository = repository;
            _tenantService = tenantService;
        }

        [HttpPost]
        [Route("add")]
        [SwaggerOperation(
            Summary = "Create new author",
            OperationId = "authors.add")
        ]
        public async Task<IActionResult> AddAuthor([FromBody] AuthorModelDTO model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var addedAuthor = await _repository.AddAsync<Author>(AuthorModelDTO.FromAuthorDTO(model));
            return (Ok(AuthorModelDTO.FromAuthor(addedAuthor)));
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Get all authors in tenant",
            OperationId = "authors")
        ]
        public async Task<IActionResult> GetAuthors()
        {
            var authors = (await _repository.ListAsync<Author>()).Select(AuthorModelDTO.FromAuthor);
            return (Ok(authors));
        }

        [HttpGet]
        [Route("withbooks")]
        [SwaggerOperation(
            Summary = "Get all authors in tenant",
            OperationId = "authors")
        ]
        public async Task<IActionResult> GetAuthorsWithBooks()
        {
            var authors = (await _repository.ListAsync<Author>(r => r.Books)).Select(AuthorModelDTO.FromAuthor);
            return (Ok(authors));
        }

        [HttpGet]
        [Route("nationalites")]
        [SwaggerOperation(
            Summary = "Get nationalities per tenant",
            Description = "Get nationalities per tenant",
            OperationId = "authors.nationalites")
        ]
        public async Task<IActionResult> GetNationalites()
        {
            var items = (await _repository.ListAsync<Nationality>())
                            .Select(NationalityDTO.FromNationality);
            return (Ok(items));
        }
    }
}
