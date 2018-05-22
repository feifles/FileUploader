using FileUploaderV2.Core.Models;
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
        public DbSet<Company> Companies { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<DBConfig> DBConfigs { get; set; }
        public DbSet<DataFile> DataFiles { get; set; }

        public FileUploaderDbContext(DbContextOptions<FileUploaderDbContext> options) : base(options)
        {
            
        } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupAppUser>().HasKey(gau =>
                new { gau.GroupId, gau.AppUserId });
        }
    }
}
