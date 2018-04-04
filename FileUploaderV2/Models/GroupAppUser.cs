using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploaderV2.Models
{
    [Table("GroupAppUsers")]
    public class GroupAppUser
    {
        public int AppUserId { get; set; }
        public int GroupId { get; set; }

        public AppUser AppUser { get; set; }
        public Group Group { get; set; }
    }
}
