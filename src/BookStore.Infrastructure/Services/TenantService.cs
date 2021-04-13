using System;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Core.Entities;
using BookStore.Core.Interfaces;
using Microsoft.AspNetCore.Http;

namespace BookStore.Infrastructure.Services
{
    public class TenantService : ITenantService
    {
        private readonly HttpContext _httpContext;

        private readonly ITenantIdentificationService<HttpContext> _service;

        public TenantService(
            IHttpContextAccessor accessor,
            ITenantIdentificationService<HttpContext> tenantIdentification)
        {
            _httpContext = accessor.HttpContext;
            _service = tenantIdentification;
        }

        public async Task<string> GetTenantId()
        {
            return await Task.FromResult(_service.GetCurrentTenant(_httpContext));
        }
    }
}
