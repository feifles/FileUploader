using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploaderV2.Controllers.Resources
{
    public class GroupResource : KeyValuePairResource
    {
        public GroupResource()
        {
            DataFileTemplates = new Collection<DataFileTemplateResource>();
            AppUsers = new Collection<KeyValuePairResource>();
        }

        public KeyValuePairResource Company { get; set; }

        public KeyValuePairResource DBConfig { get; set; }

        public bool isActive { get; set; }

        public DateTime LastUpdate { get; set; }

        public ICollection<DataFileTemplateResource> DataFileTemplates { get; set; }

        public ICollection<KeyValuePairResource> AppUsers { get; set; }
    }
}
