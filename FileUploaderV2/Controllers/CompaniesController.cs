using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FileUploaderV2.Core.Models;
using FileUploaderV2.Controllers.Resources;
using FileUploaderV2.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FileUploaderV2.Core;

namespace FileUploaderV2.Controllers
{
    [Produces("application/json")]
    [Route("api/Companies")]
    public class CompaniesController : Controller
    {
        private readonly IMapper mapper;
        private readonly ICompanyRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public  CompaniesController(IMapper mapper, ICompanyRepository repository, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("/api/companies")]
        public async Task <IEnumerable<CompanyResource>> GetCompanies()
        {
            List<Company> companies = await repository.Get();

            return mapper.Map<List<Company>, List<CompanyResource>>(companies);
        }

        [HttpGet("/api/companies/{id}/users")]
        public async Task<List<AppUserResource>> GetCompanyWithUsers(int id)
        {
            List<AppUser> users = await repository.GetCompanyUsers(id);

            return mapper.Map<List<AppUser>, List<AppUserResource>>(users);
        }
    }
}