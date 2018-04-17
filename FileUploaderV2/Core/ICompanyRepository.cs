using FileUploaderV2.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploaderV2.Core
{
    public interface ICompanyRepository
    {
        Task<List<AppUser>> GetCompanyUsers(int id);
        Task<List<Company>> Get();
    }
}
