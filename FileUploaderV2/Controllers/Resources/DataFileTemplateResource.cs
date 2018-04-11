using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploaderV2.Controllers.Resources
{
    public class DataFileTemplateResource
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string TableName { get; set; }

        public string Template { get; set; }

        public int GroupId { get; set; }

    }
}
