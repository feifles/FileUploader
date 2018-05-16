using FileUploaderV2.Core;
using FileUploaderV2.Core.Models;
using FileUploaderV2.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<IEnumerable<Group>> Get(GroupQuery queryObj, bool includeRelated = true)
        {
            var query = context.Groups
                                .Include(x => x.Company)
                                .Include(x => x.DataFileTemplates)
                                .Include(x => x.AppUsers)
                                    .ThenInclude(x => x.AppUser)
                                .Include(x => x.DBConfig)
                                .AsQueryable();

            if (queryObj.CompanyId.HasValue == true && queryObj.CompanyId.Value > 0)
                query = query.Where(g => g.Company.Id == queryObj.CompanyId.Value);

            if (queryObj.DbConfigId.HasValue == true && queryObj.DbConfigId.Value > 0)
                query = query.Where(g => g.DBConfig.Id == queryObj.DbConfigId.Value);

            var columnsMap = new Dictionary<string, Expression<Func<Group, object>>>()
            {
                ["company"] = g => g.Company.Name,
                ["dbconfig"] = g => g.DBConfig.Name
            };

            query = query.ApplyOrdering(queryObj, columnsMap);

            query = query.ApplyPaging(queryObj);

            return await query.ToListAsync();


            //if (!includeRelated)
            //    return await context.Groups.ToListAsync();
            //else
            //    return await context.Groups
            //                    .Include(x => x.Company)
            //                    .Include(x => x.DataFileTemplates)
            //                    .Include(x => x.AppUsers)
            //                        .ThenInclude(x => x.AppUser)
            //                    .Include(x => x.DBConfig)
            //                    .ToListAsync();
        }

        public async Task<IEnumerable<Group>> GetGroupsFromCompany(int companyId)
        {
            return await context.Groups
                .Where(g => g.CompanyId == companyId)
                .Include(x => x.Company)
                .Include(x => x.DataFileTemplates)
                .Include(x => x.AppUsers)
                    .ThenInclude(x => x.AppUser)
                .Include(x => x.DBConfig)
                .ToListAsync();
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
