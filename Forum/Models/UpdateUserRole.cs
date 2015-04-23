using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class UpdateUserRole
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string NewRole { get; set; }
    }
}