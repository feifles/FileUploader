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

namespace FileUploaderV2.Controllers
{
    [Produces("application/json")]
    [Route("api/Companies")]
    public class CompaniesController : Controller
    {
        private readonly FileUploaderDbContext context;
        private readonly IMapper mapper;

        public  CompaniesController(FileUploaderDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("/api/companies")]
        public async Task <IEnumerable<CompanyResource>> GetCompanies()
        {
            List<Company> companies = await context.Companies.Include(m => m.Groups).ToListAsync();

            return mapper.Map<List<Company>, List<CompanyResource>>(companies);
        }
    }
}