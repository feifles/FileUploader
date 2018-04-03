using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploaderV2.Models
{
    [Table("DBConfigs")]
    public class DBConfig
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Server { get; set; }
        [Required]
        [StringLength(255)]
        public string DatabaseName { get; set; }
        [Required]
        [StringLength(255)]
        public string Username { get; set; }
        [Required]
        [StringLength(255)]
        public string Password { get; set; }
    }
}
