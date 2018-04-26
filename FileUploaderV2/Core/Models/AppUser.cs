using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploaderV2.Core.Models
{
    [Table("AppUsers")]
    public class AppUser
    {
        public AppUser()
        {
            Groups = new Collection<GroupAppUser>(); ;
        }

        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public ICollection<GroupAppUser> Groups { get; set; }

    }
}
