using FileUploaderV2.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploaderV2.Persistence
{
    public class FileUploaderDbContext : DbContext
    {
        public FileUploaderDbContext(DbContextOptions<FileUploaderDbContext> options) : base(options)
        {
            
        }
        public DbSet<Company> Companies { get; set; }
    }
}
