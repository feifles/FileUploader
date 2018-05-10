using System.Collections.Generic;
using System.Threading.Tasks;
using FileUploaderV2.Core.Models;

namespace FileUploaderV2.Core
{
    public interface IGroupRepository
    {
        Task<Group> Get(int id, bool includeRelated = true);
        Task<Group> GetGroupWithoutDBConfig(int id);
        void Add(Group group);
        void Remove(Group group);
        Task<IEnumerable<Group>> GetGroupsFromCompany(int companyId);
        Task<IEnumerable<Group>> Get(Filter filter, bool includeRelated = true);
    }
}