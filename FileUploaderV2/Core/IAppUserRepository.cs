using FileUploaderV2.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploaderV2.Core
{
    public interface IAppUserRepository
    {
        Task<List<AppUser>> Get();
        Task<AppUser> Get(int id, bool includeRelated = true);
        Task<List<AppUser>> GetUsersFromCompanyAsync(int id);
    }
}
