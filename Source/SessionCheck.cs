using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Source
{
    public class SessionCheck : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;
            if (HttpContext.Current.Session["UserID"] == null)
            {
                FormsAuthentication.SignOut();
                HttpContext.Current.Session.Abandon();
                filterContext.Result = new RedirectResult("~/Authentication/Login");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}