using System.Web.Mvc;
using System.Web.Routing;

namespace BTL_WEB.Areas.Administrator.Controllers
{
    public class BaseController : Controller
    {
        // GET: Administrator/Base
        protected override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filterContext)
        {
           // bool val1 = (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            //var a=User.Identity.Name;
            if (Session["UserName"] == null || Session["RememberMe"] !=null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "login", action = "index" }));
            }
            base.OnActionExecuting(filterContext);
        }
        
    }
}