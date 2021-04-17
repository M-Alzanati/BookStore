using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BookStore.API.ApiModels;
using BookStore.SharedKernel.Interfaces;
using BookStore.Core.Interfaces;
using BookStore.Core.Entities;

namespace BookStore.API.Controllers
{
    [Authorize]
    [Route("tenants")]
    public class TenantController : BaseApiController
    {
        private readonly IRepository _repo;

        public TenantController(IRepository repository)
        {
            _repo = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetTenants()
        {
            return (Ok((await _repo.ListAsync<Tenant>()).Select(TenantModelDTO.FromTenant)));
        }
    }
}
