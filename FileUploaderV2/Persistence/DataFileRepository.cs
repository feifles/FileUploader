using FileUploaderV2.Core;
using FileUploaderV2.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploaderV2.Persistence
{
    public class DataFileRepository : IDataFileRepository
    {
        private readonly FileUploaderDbContext context;

        public DataFileRepository(FileUploaderDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<DataFile>> GetDataFiles(int userId)
        {
            return await context.DataFiles
                .Where(f => f.AppUserId == userId)
                .ToListAsync();

        }
    }
}
