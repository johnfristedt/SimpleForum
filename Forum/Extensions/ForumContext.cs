using Forum.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Forum.Extensions
{
    public class ForumContext : DbContext
    {
        public DbSet<Board> Boards { get; set; }
        public DbSet<Thread> Threads { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Error> Errors { get; set; }

        public ForumContext(string connectionName)
            : base(connectionName)
        {

        }
    }
}