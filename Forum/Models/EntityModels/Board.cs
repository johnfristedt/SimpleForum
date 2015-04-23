using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class Board : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Thread> Threads { get; set; }

        public Board()
        {

        }

        public Board(string boardName, string boardDescription)
        {
            Name = boardName;
            Description = boardDescription;
        }
    }
}