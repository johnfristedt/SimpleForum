using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class CreatePostViewModel
    {
        [Required]
        public int ThreadId { get; set; }

        [Required]
        public string Author { get; set; }
        
        [Required(ErrorMessage="Required field")]
        public string Content { get; set; }
    }
}