using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using BookStore.SharedKernel.Interfaces;
using BookStore.Core.Entities;
using BookStore.Core.Interfaces;

namespace BookStore.Infrastructure.Services
{
    public class TenantService : ITenantService
    {
        private readonly HttpContext _httpContext;

        private readonly ITenantIdentificationService<HttpContext> _service;

        private readonly IRepository _repository;

        public TenantService(
            IHttpContextAccessor accessor,
            ITenantIdentificationService<HttpContext> tenantIdentification,
            IRepository repository)
        {
            _httpContext = accessor.HttpContext;
            _service = tenantIdentification;
            _repository = repository;
        }

        public async Task<string> GetTenantId()
        {
            var apiKey = await Task.FromResult(_service.GetCurrentTenant(_httpContext));

            Guid apiKeyGuid;
            if (!Guid.TryParse(apiKey, out apiKeyGuid))
            {
                return null;
            }

            var tenant = await _repository.GetByIdAsync<Tenant>(r => r.ApiKey == apiKey);
            return tenant.Id;
        }
    }
}
