using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class CreateRoleViewModel
    {
        [Required(ErrorMessage="Required field")]
        public string RoleName { get; set; }
    }
}