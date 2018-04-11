using FileUploaderV2.Core;
using FileUploaderV2.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploaderV2.Persistence
{
    public class GroupRepository : IGroupRepository
    {
        private readonly FileUploaderDbContext context;

        public GroupRepository(FileUploaderDbContext context)
        {
            this.context = context;
        }

        public async Task<Group> Get(int id, bool includeRelated = true)
        {
            if (!includeRelated)
                return await context.Groups.FindAsync(id);
            else
                return await context.Groups
                        .Include(g => g.AppUsers)
                        .ThenInclude(gau => gau.AppUser)
                        .Include(g => g.Company)
                        .Include(g => g.DBConfig)
                        .SingleOrDefaultAsync(g => g.Id == id);
        }

        public async Task<Group> GetGroupWithoutDBConfig(int id)
        {
            return await context.Groups
                .Include(g => g.AppUsers)
                .ThenInclude(gau => gau.AppUser)
                .Include(g => g.Company)
                .SingleOrDefaultAsync(g => g.Id == id);
        }

        public void Add(Group group)
        {
            context.Groups.Add(group);
        }

        public void Remove(Group group)
        {
            context.Remove(group);
        }
    }
}
