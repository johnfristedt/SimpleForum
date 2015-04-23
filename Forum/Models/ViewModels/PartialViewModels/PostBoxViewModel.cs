using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class PostBoxViewModel
    {
        public string Author { get; set; }
        public DateTime Time { get; set; }
        public string Content { get; set; }
    }
}