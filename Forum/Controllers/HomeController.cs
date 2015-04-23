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
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (!Membership.ValidateUser(model.UserName, model.Password))
                ModelState.AddModelError("UserName", "Invalid username or password");

            if (!ModelState.IsValid)
                return View(model);

            FormsAuthentication.SetAuthCookie(model.UserName, false);

            return RedirectToAction("Index", "Forum");
        }

        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(CreateUserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            MembershipCreateStatus status;
            Membership.CreateUser(model.UserName,
                                  model.Password,
                                  model.EMail,
                                  model.Question,
                                  model.Answer,
                                  true,
                                  out status);

            Roles.AddUserToRole(model.UserName, "Registered");

            return RedirectToAction("Login", "Home");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Forum");
        }

        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            Response.TrySkipIisCustomErrors = true;

            using (var db = new ForumContext("ForumDB"))
            {
                db.Errors.Add(new Error { Message = "404" });
                db.SaveChanges();
            }

            return View();
        }
    }
}