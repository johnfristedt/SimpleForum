using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Forum
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Index",
                "",
                new { controller = "Forum", action = "Index" }
            );

            routes.MapRoute(
                name: "Login",
                url: "Login",
                defaults: new { controller = "Home", action = "Login" }
            );

            routes.MapRoute(
                "Logout",
                "Logout",
                new { controller = "Home", action = "Logout" }
            );

            routes.MapRoute(
                name: "AdminIndex",
                url: "Admin",
                defaults: new { controller = "Admin", action = "Index" }
            );

            routes.MapRoute(
                name: "AdminPages",
                url: "Admin/{action}",
                defaults: new { controller = "Admin", action = "{action}" }
            );

            routes.MapRoute(
                name: "PublicPages",
                url: "Home/{action}",
                defaults: new { controller = "Home", action = "{action}" }
            );

            routes.MapRoute(
                "ActionId",
                "{action}/{id}",
                new { controller = "Forum", action = "{action}", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "{controller}", action = "{action}", id = UrlParameter.Optional }
            );
        }
    }
}