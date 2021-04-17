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

            var tenantId = await _tenantService.GetTenantIdAsync();
            if (string.IsNullOrEmpty(tenantId)) return BadRequest("Tenant key is not correct");

            var myAuthor = AuthorModelDTO.FromAuthorDTO(model);
            myAuthor.TenantId = tenantId;

            var addedAuthor = await _repository.AddAsync<Author>(myAuthor);
            return (Ok(AuthorModelDTO.FromAuthor(addedAuthor)));
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
            var tenantId = await _tenantService.GetTenantIdAsync();
            var items = (await _repository.ListAsync<Nationality>(n => n.TenantId == tenantId))
                            .Select(NationalityDTO.FromNationality);
            return (Ok(items));
        }
    }
}
