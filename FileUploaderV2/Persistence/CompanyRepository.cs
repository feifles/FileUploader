using FileUploaderV2.Core;
using FileUploaderV2.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploaderV2.Persistence
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly FileUploaderDbContext context;

        public CompanyRepository(FileUploaderDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Company>> Get ()
        {
            return await context.Companies
                .Include(g => g.Groups)
                    .ThenInclude(d => d.DBConfig)
                .ToListAsync();
        }

        public async Task<List<AppUser>> GetCompanyUsers (int id)
        {
            //var companyUsers = await context.Users
            //    .Where(u => u.UserGroups.Any(ug => ug.Group.Company.Id == id))
            //    .ToListAsync();

            return await context.Companies
                .Where(c => c.Id == id)
                .SelectMany(g => g.Groups)
                .SelectMany(gau =>
                    gau.AppUsers.Select(au => au.AppUser)).Distinct().ToListAsync();

        }
    }
}
