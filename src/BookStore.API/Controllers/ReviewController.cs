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
    public class ReviewController : BaseApiController
    {
        private readonly ILogger<ReviewController> _logger;

        private readonly IRepository _repository;

        private readonly ITenantService _tenantService;

        public ReviewController(ILogger<ReviewController> logger, IRepository repository, ITenantService tenantService)
        {
            _logger = logger;
            _repository = repository;
            _tenantService = tenantService;
        }

        [HttpPost]
        [Route("add")]
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