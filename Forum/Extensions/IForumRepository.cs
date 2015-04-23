using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Extensions
{
    public interface IForumRepository
    {
        Board[] GetBoards();
        Board GetBoard(int id);
        void AddBoard(Board board);

        Thread[] GetThreads(int boardId);
        Thread GetThread(int id);
        void AddThread(CreateThreadViewModel thread);

        Post[] GetPosts(int threadId);
        Post GetPost(int id);
        void AddPost(Post post);
    }
}
