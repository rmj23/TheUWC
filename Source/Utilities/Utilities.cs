using System;
using System.Linq;
using System.Web.Mvc;

namespace Source.Utilities
{
    public static class Utilities
    {
        public static string IsActive(this HtmlHelper html,
                                      string action,
                                      string control)
        {
            var routeData = html.ViewContext.RouteData;

            var routeAction = (string)routeData.Values["action"];
            var routeControl = (string)routeData.Values["controller"];

            // both must match
            var returnActive = control == routeControl &&
                               action == routeAction;

            return returnActive ? "active" : "";
        }

        /** Author: Adam Chubbuck
         *  Description: Returns a string value representing the controller and action (view) using camelcase. 
         *               This is primarily used to generate a CSS class representing the controller:action pair.
         *  Parameters: 
         *      html :: a reference to the HtmlHelper used to invoke the function call.
        **/
        public static string ControllerActionCombo(this HtmlHelper html)
        {
            var routeData = html.ViewContext.RouteData;

            var routeAction = (string)routeData.Values["action"];
            var routeController = (string)routeData.Values["controller"];

            return routeController.ToString().ToLower() + routeAction.First().ToString().ToUpper() + String.Join("", routeAction.Skip(1));
        }
    }
}