using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class CreateThreadViewModel
    {
        [Required]
        public int BoardId { get; set; }
        [Required]
        public string LastPoster { get; set; }
        [Required(ErrorMessage = "Required field")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Required field")]
        public string Content { get; set; }
    }
}