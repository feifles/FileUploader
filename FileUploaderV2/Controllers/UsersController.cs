using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FileUploaderV2.Controllers.Resources;
using FileUploaderV2.Core;
using FileUploaderV2.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileUploaderV2.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private readonly IMapper mapper;
        private readonly IAppUserRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public UsersController(IMapper mapper, IAppUserRepository repository, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("/api/users/company/{id}")]
        public async Task<IActionResult> GetUsersFromCompany(int id)
        {
            List<AppUser> users = await repository.GetUsersFromCompanyAsync(id);

            return Ok(mapper.Map<List<AppUser>, List<AppUserResource>>(users));
        }
    }
}