using FileUploaderV2.Core;
using FileUploaderV2.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploaderV2.Persistence
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly FileUploaderDbContext context;

        public AppUserRepository(FileUploaderDbContext context)
        {
            this.context = context;
        }

        public async Task<List<AppUser>> Get()
        {
            return await context.AppUsers
                .ToListAsync();
        }

        public async Task<List<AppUser>> GetUsersFromCompanyAsync(int id)
        {
            return await context.AppUsers
                .Where(u => u.Groups.Any(ug => ug.Group.Company.Id == id))
                .ToListAsync();
        }
    }
}
