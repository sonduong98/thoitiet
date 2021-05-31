using System.Web.Mvc;
using System.Web.Routing;

namespace BTL_WEB
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Category",
                url: "Category/{title}",
                defaults: new { controller = "Category", action = "Index" },
                new[] { "BTL_WEB.Controllers" }
            );
            routes.MapRoute(
                name: "Acticle",
                url: "News/{title}",
                defaults: new { controller = "News", action = "Index" },
                new[] { "BTL_WEB.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "BTL_WEB.Controllers" }
            );
        }
    }
}
