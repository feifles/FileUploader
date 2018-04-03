using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploaderV2.Models
{
    [Table("Groups")]
    public class Group
    {
        public Group()
        {
            DataFileTemplates = new Collection<DataFileTemplate>();
        }

        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Company Company { get; set; }
        public int CompanyId { get; set; }

        public DBConfig DBConfig { get; set; }
        public int DBConfigId { get; set; }

        public ICollection<DataFileTemplate> DataFileTemplates { get; set; }
        
    }
}
