using FileUploaderV2.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploaderV2.Core
{
    public interface IDataFileRepository
    {
        Task<IEnumerable<DataFile>> GetDataFiles(int userId);
    }
}
