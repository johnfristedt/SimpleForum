using AutoMapper;
using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Extensions
{
    public class DbForumRepository : IForumRepository
    {
        const string CONNECTION = "ForumDB";

        public Models.Board[] GetBoards()
        {
            using (var db = new ForumContext(CONNECTION))
            {
                return db.Boards.ToArray();
            }
        }

        public Models.Board GetBoard(int id)
        {
            using (var db = new ForumContext(CONNECTION))
            {
                return db.Boards.Find(id);
            }
        }

        public void AddBoard(Models.Board board)
        {
            using (var db = new ForumContext(CONNECTION))
            {
                db.Boards.Add(board);
                db.SaveChanges();
            }
        }

        public Models.Thread[] GetThreads(int boardId)
        {
            using (var db = new ForumContext(CONNECTION))
            {
                var threads = db.Threads
                    .OrderByDescending(t => t.LastPostTime)
                    .Where(t => t.BoardId == boardId).ToArray();

                return threads;
            }
        }

        public Models.Thread GetThread(int id)
        {
            using (var db = new ForumContext(CONNECTION))
            {
                return db.Threads.Single(t => t.Id == id);
            }
        }

        public void AddThread(CreateThreadViewModel model)
        {
            using (var db = new ForumContext(CONNECTION))
            {
                var thread = Mapper.Map<Thread>(model);
                thread.Posts.Add(new Post(model.Content, thread.LastPoster));
                db.Threads.Add(thread);
                db.SaveChanges();
            }
        }

        public Models.Post[] GetPosts(int threadId)
        {
            using (var db = new ForumContext(CONNECTION))
            {
                return db.Posts
                    .OrderBy(t => t.Id)
                    .Where(p => p.ThreadId == threadId).ToArray();
            }
        }

        public Models.Post GetPost(int id)
        {
            using (var db = new ForumContext(CONNECTION))
            {
                return db.Posts.Single(p => p.Id == id);
            }
        }

        public void AddPost(Models.Post post)
        {
            using (var db = new ForumContext(CONNECTION))
            {
                var thread = db.Threads.Where(p => p.Id == post.ThreadId).First();
                thread.LastPoster = post.Author;
                thread.LastPostTime = post.Time;
                db.Posts.Add(post);
                db.SaveChanges();
            }
        }
    }
}