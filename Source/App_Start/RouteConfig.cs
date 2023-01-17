using System.Web.Mvc;
using System.Web.Routing;

namespace Source
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            //routes.MapRoute(
            //    name: "Glossary2",
            //    url: "{controller}/{action}/{letter}",
            //    defaults: new { controller = "Teacher", action = "Glossary2", letter = UrlParameter.Optional }
            //    );

            /* Will need to finish this later.
             * When the contact us form is submitted, it should redirect to Home/Contact/{state}
             * where {state} can be either 'Success' or 'Error', which will display
             * an alert component in the view based on the provided {state}.
             */
            //routes.MapRoute(
            //    name: "ContactSuccess",
            //    url: "{controller}/{action}/{submissionStatus}",
            //    defaults: new { controller = "Home", action = "Contact", submissionStatus = UrlParameter.Optional }
            //    );

            /* Will need to finish this later.
             * When the contact us form is displayed, it should check to see if a reason for contacting
             * us is already set. If it is, it should automatically select the appropriate reason on the
             * dropdown menu.
             */
            //routes.MapRoute(
            //    name: "ContactReason",
            //    url: "{controller}/{action}/{reason}",
            //    defaults: new { controller = "Home", action = "Contact", reason = UrlParameter.Optional }
            //    );


        }
    }
}
