using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploaderV2.Models
{
    public class Company
    {
        public Company()
        {
            Group = new Collection<Group>();
            DataFileTemplates = new Collection<DataFileTemplate>();
        }

        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public ICollection<Group> Group { get; set; }
        public ICollection<DataFileTemplate> DataFileTemplates { get; set; }
    }
}
