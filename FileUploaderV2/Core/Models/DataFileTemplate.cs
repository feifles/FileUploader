using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploaderV2.Core.Models
{
    [Table("DataFileTemplates")]
    public class DataFileTemplate
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public string TableName { get; set; }

        [StringLength(255)]
        public string Template { get; set; }

        public Group Group { get; set; }
        public int GroupId { get; set; }

        [StringLength(255)]
        public string LastUpdateUsername { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
