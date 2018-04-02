using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploaderV2.Models.Resources
{
    public class CompanyResource
    {
        public CompanyResource()
        {
            Group = new Collection<GroupResource>();
            DataFileTemplates = new Collection<DataFileTemplateResource>();
        }

        public int Id { get; set; }

        public string Name { get; set; }
        public ICollection<GroupResource> Group { get; set; }
        public ICollection<DataFileTemplateResource> DataFileTemplates { get; set; }
    }
}

