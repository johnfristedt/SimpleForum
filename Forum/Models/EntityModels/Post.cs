using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class Post : BaseModel
    {
        public int ThreadId { get; set; }

        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime Time { get; set; }

        public Post()
        {
            Time = DateTime.Now;
        }

        public Post(string postContent, string author)
            : this()
        {
            Content = postContent;
            Author = author;
        }
    }
}