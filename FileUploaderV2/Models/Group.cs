using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploaderV2.Models
{
    [Table("Groups")]
    public class Group
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public Company Company { get; set; }
        public int CompanyId { get; set; }
    }
}
