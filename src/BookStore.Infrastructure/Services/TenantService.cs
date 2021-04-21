using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using BookStore.SharedKernel.Interfaces;
using BookStore.Core.Entities;
using BookStore.Core.Interfaces;

namespace BookStore.Infrastructure.Services
{
    /// <summary>
    /// Implementation of ITenantService, which define the way to retrive tenant id
    /// </summary>
    public class TenantService : ITenantService
    {
        private readonly HttpContext _httpContext;

        private readonly ITenantIdentificationService<HttpContext> _service;

        private readonly IRepository _repository;

        public TenantService(
            IHttpContextAccessor accessor,
            ITenantIdentificationService<HttpContext> tenantIdentification)
        {
            _httpContext = accessor.HttpContext;
            _service = tenantIdentification;
        }

        public string GetTenantId()
        {
            var apiKey = _service?.GetCurrentTenant(_httpContext);

            Guid apiKeyGuid;
            if (!Guid.TryParse(apiKey, out apiKeyGuid))
            {
                return null;
            }

            return apiKey;
        }
    }
}
