using FileUploaderV2.Core;
using FileUploaderV2.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploaderV2.Persistence
{
    public class DBConfigRepository : IDBConfigRepository
    {
        private readonly FileUploaderDbContext context;

        public DBConfigRepository(FileUploaderDbContext context)
        {
            this.context = context;
        }

        public async Task<List<DBConfig>> GetCompanyConfigsAsync(int id)
        {
            return await context.Groups
                .Where(u => u.CompanyId == id)
                .Select(d => d.DBConfig)
                .Distinct()
                .ToListAsync();
        }
    }
}
