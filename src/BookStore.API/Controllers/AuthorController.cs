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
    public class AuthorController : BaseApiController
    {
        private readonly ILogger<AuthorController> _logger;

        private readonly IRepository _repository;

        public AuthorController(ILogger<AuthorController> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
    }
}