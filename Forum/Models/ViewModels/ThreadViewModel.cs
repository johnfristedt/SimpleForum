using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class ThreadViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PostBoxViewModel[] Posts { get; set; }
    }
}