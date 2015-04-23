using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class BoardViewModel
    {
        public string Name { get; set; }
        public ThreadBoxViewModel[] Threads { get; set; }
    }
}