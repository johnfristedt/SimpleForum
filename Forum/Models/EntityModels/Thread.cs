using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class Thread : BaseModel
    {
        public int BoardId { get; set; }

        public string Title { get; set; }

        public string LastPoster { get; set; }

        public DateTime LastPostTime { get; set; }

        public virtual List<Post> Posts { get; set; }

        public Thread()
        {
            Posts = new List<Post>();
            LastPostTime = DateTime.Now;
        }
    }
}