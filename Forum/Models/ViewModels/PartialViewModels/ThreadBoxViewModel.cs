using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class ThreadBoxViewModel
    {
        public int Id { get; set; }
        public int BoardId { get; set; }
        public string Title { get; set; }
        public string LastPoster { get; set; }
        public DateTime LastPostTime { get; set; }
    }
}