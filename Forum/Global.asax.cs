using AutoMapper;
using Forum.App_Start;
using Forum.Extensions;
using Forum.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Forum
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            Database.SetInitializer<ForumContext>(null);

            Mapper.CreateMap<Board, BoardBoxViewModel>();
            Mapper.CreateMap<Thread, ThreadBoxViewModel>();
            Mapper.CreateMap<Post, PostBoxViewModel>();

            Mapper.CreateMap<CreateBoardViewModel, Board>();
            Mapper.CreateMap<CreateThreadViewModel, Thread>();
            Mapper.CreateMap<CreatePostViewModel, Post>();
        }

        protected void Application_Error()
        {
            using (var db = new ForumContext("ForumDB"))
            {
                db.Errors.Add(new Error { Message = Server.GetLastError().Message });
                db.SaveChanges();
            }
        }
    }
}
