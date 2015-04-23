using AutoMapper;
using Forum.Extensions;
using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Forum.Controllers
{
    [Authorize(Roles="Admin")]
    public class AdminController : Controller
    {
        IForumRepository repository;

        public AdminController(IForumRepository repository)
        {
            this.repository = repository;
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewBoard()
        {
            return View(new CreateBoardViewModel());
        }

        [HttpPost]
        public ActionResult NewBoard(CreateBoardViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            repository.AddBoard(Mapper.Map<CreateBoardViewModel, Board>(model));
            return Content("Board added");
        }

        public ActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateRole(CreateRoleViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            Roles.CreateRole(model.RoleName);
            return RedirectToAction("Index", "Admin");
        }

        public ActionResult ManageRoles()
        {
            return View(new ManageRolesViewModel { Users = Roles.GetUsersInRole("Registered"), Roles = Roles.GetAllRoles() });
        }

        [HttpPost]
        public ActionResult ManageRoles(UpdateUserRole model)
        {
            if (!ModelState.IsValid)
                return Json(false);

            var currentRole = Roles.GetRolesForUser(model.UserName);
            Roles.RemoveUserFromRole(model.UserName, currentRole[0]);
            Roles.AddUserToRole(model.UserName, model.NewRole);
            
            return Json(true);
        }
    }
}