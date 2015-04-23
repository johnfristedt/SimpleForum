using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public PostBoxViewModel[] Posts { get; set; }
    }
}