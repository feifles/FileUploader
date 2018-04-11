using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploaderV2.Controllers.Resources
{
    public class SaveGroupResource
    {
        public SaveGroupResource()
        {
            DataFileTemplates = new Collection<DataFileTemplateResource>();
            AppUsers = new Collection<int>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public int CompanyId { get; set; }

        [Required]
        public int DBConfigId { get; set; }

        public bool isActive { get; set; }

        public ICollection<DataFileTemplateResource> DataFileTemplates { get; set; }

        public ICollection<int> AppUsers { get; set; }
    }
}
