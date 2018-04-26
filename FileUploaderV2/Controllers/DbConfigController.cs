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
    [Route("api/DbConfig")]
    public class DbConfigController : Controller
    {
        private readonly IMapper mapper;
        private readonly IDBConfigRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public DbConfigController(IMapper mapper, IDBConfigRepository repository, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("/api/DbConfig/Company/{id}")]
        public async Task<IActionResult> GetUsersFromCompany(int id)
        {
            List<DBConfig> dbConfigs = await repository.GetCompanyConfigsAsync(id);

            return Ok(mapper.Map<List<DBConfig>, List<DbConfigResource>>(dbConfigs));
        }
    }
}