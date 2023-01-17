using Source.Controllers;
using System;
using System.Linq;
using System.Security.Authentication;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Source
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ViewEngines.Engines.Add(new CustomViewEngine());
        }
        protected void Application_Error(object sender, EventArgs e) //Global Exception Handler
        {

            var httpContext = ((MvcApplication)sender).Context;

            var currentRouteData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
            var currentController = " ";
            var currentAction = " ";
            var layout = "";

            if (currentRouteData != null)
            {
                if (currentRouteData.Values["controller"] != null &&
                    !String.IsNullOrEmpty(currentRouteData.Values["controller"].ToString()))
                {
                    currentController = currentRouteData.Values["controller"].ToString();
                }

                if (currentRouteData.Values["action"] != null &&
                    !String.IsNullOrEmpty(currentRouteData.Values["action"].ToString()))
                {
                    currentAction = currentRouteData.Values["action"].ToString();
                }
            }

            switch (currentController)
            {
                case "Home":
                    layout = "~/Views/Shared/_Layout.cshtml";
                    break;
                case "Teacher":
                    layout = "~/Views/Shared/_TeacherLayout.cshtml";
                    break;
                case "Parent":
                    layout = "~/Views/Shared/_ParentLayout.cshtml";
                    break;
                case "Student":
                    layout = "~/Views/Shared/_StudentLayout.cshtml";
                    break;
                case "Evaluation":
                    layout = "~/Views/Shared/_TeacherLayout.cshtml";
                    break;
                case "DistrictAdmin":
                    layout = "~/Views/Shared/_DistrictAdminLayout.cshtml";
                    break;
                case "SchoolAdmin":
                    layout = "~/Views/Shared/_SchoolAdminLayout.cshtml";
                    break;
                case "WebAdmin":
                    layout = "~/Views/Shared/_WebAdminLayout.cshtml";
                    break;
                default:
                    layout = "~/Views/Shared/_Layout.cshtml";
                    break;
            }

            var ex = Server.GetLastError();

            if (ex != null)
            {
                //ErrorModelDb.InsertApplicationError(ex.ToString());
                //if (ex.InnerException != null)
                //{
                //    ErrorModelDb.InsertApplicationError(ex.ToString());
                //}
                //Send email.
                //var subject = "Uni-Spire: Error Logged";
                var message = "A new error has been logged: " + ex.ToString();
                //var to = ConfigurationManager.AppSettings["SupportEmails"].ToString();

                //EmailModelFunctions.Send(to, message, subject);
            }

            var controller = new ErrorController();
            var routeData = new RouteData();
            var action = "ServerError";
            var statusCode = 500;

            if (ex is HttpException)
            {
                var httpEx = ex as HttpException;
                statusCode = httpEx.GetHttpCode();

                switch (httpEx.GetHttpCode())
                {

                    case 403:
                        action = "Forbidden";
                        break;

                    case 404:
                        action = "NotFound";
                        break;

                    case 500:
                        action = "ServerError";
                        break;

                    default:
                        action = "ServerError";
                        break;
                }
            }
            else if (ex is AuthenticationException)
            {
                action = "Forbidden";
                statusCode = 403;
            }

            httpContext.ClearError();
            httpContext.Response.Clear();
            HttpContext.Current.Response.Headers.Remove("X-Powered-By");
            HttpContext.Current.Response.Headers.Remove("X-AspNet-Version");
            HttpContext.Current.Response.Headers.Remove("X-AspNetMvc-Version");
            HttpContext.Current.Response.Headers.Remove("Server");
            httpContext.Response.StatusCode = statusCode;
            httpContext.Response.TrySkipIisCustomErrors = true;
            routeData.Values["controller"] = "Error";
            routeData.Values["action"] = action;

            controller.ViewData.Model = new HandleErrorInfo(ex, currentController, currentAction);
            controller.ViewBag.Layout = layout;
            ((IController)controller).Execute(new RequestContext(new HttpContextWrapper(httpContext), routeData));

        }
    }
    public class CustomViewEngine : RazorViewEngine
    {
        public static readonly string[] CUSTOM_PARTIAL_VIEW_FORMATS = new[]
            { "~/Views/Selection/{0}.cshtml" };
        public CustomViewEngine()
        {
            ViewEngines.Engines.Clear();
            base.PartialViewLocationFormats = base.PartialViewLocationFormats.Union(CUSTOM_PARTIAL_VIEW_FORMATS).ToArray();
        }
    }
}
