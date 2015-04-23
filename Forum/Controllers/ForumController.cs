using AutoMapper;
using Forum.Extensions;
using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forum.Controllers
{
    [Authorize(Roles="Members, Admin")]
    public class ForumController : Controller
    {
        IForumRepository repository;

        public ForumController(IForumRepository repository)
        {
            this.repository = repository;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(new IndexViewModel { Boards = Mapper.Map<BoardBoxViewModel[]>(repository.GetBoards()) });
        }

        public ActionResult Board(int id)
        {
            TempData["BoardId"] = id;

            return View(new BoardViewModel { Name = repository.GetBoard(id).Name, Threads = Mapper.Map<ThreadBoxViewModel[]>(repository.GetThreads(id)) });
        }

        public ActionResult Thread(int id)
        {
            return View(new ThreadViewModel { Id = id, Name = repository.GetThread(id).Title, Posts = Mapper.Map<PostBoxViewModel[]>(repository.GetPosts(id)) });
        }

        public ActionResult NewThread(int id)
        {
            return View(new CreateThreadViewModel { BoardId = id, LastPoster = User.Identity.Name });
        }

        [HttpPost]
        public ActionResult NewThread(CreateThreadViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            repository.AddThread(model);
            return Redirect("/Board/" + model.BoardId);
        }
        public ActionResult NewPost(int id)
        {
            return View(new CreatePostViewModel { ThreadId = id, Author = User.Identity.Name });
        }

        [HttpPost]
        public ActionResult NewPost(CreatePostViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            repository.AddPost(Mapper.Map<CreatePostViewModel, Post>(model));
            return Redirect("/Thread/" + model.ThreadId);
        }
    }
}