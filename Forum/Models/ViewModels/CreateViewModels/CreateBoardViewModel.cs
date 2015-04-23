using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class CreateBoardViewModel
    {
        [Required(ErrorMessage="Required field")]
        public string Name { get; set; }
        [Required(ErrorMessage="Required field")]
        public string Description { get; set; }
    }
}