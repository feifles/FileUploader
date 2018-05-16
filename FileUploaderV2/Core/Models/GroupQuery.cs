using FileUploaderV2.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploaderV2.Core.Models
{
    public class GroupQuery : IQueryObject
    {
        public int? CompanyId { get; set; }
        public int? DbConfigId { get; set; }
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
        public int Page { get; set; }
        public Byte PageSize { get; set; }
    }
}
