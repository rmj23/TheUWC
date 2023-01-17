using Source.Data;
using Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace Source.Controllers
{
    public class GlobalRoleController : Controller
    {
        private const String DefaultNotAllowedTeacherView = "UserNotAllowed";
        private const String TeacherLayoutInquiryOnly = "~/Views/Shared/_TeacherLayoutInquiryOnly.cshtml";
        private const String TeacherLayoutWritingOnly = "~/Views/Shared/_TeacherLayoutWritingOnly.cshtml";
        private const String TeacherLayout = "~/Views/Shared/_TeacherLayout.cshtml";
        private const int WritingAndPaidRole = 4;
        private const int UnassignedRole = 99;
        private Dictionary<String, String> roleNameViewMapping;
        protected RequestContext UseThisForSessions;
        protected override void Initialize(RequestContext requestContext)
        {
            SessionModel.UserIsTeacher(requestContext);
            UseThisForSessions = requestContext;
            base.Initialize(requestContext);
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            //assign View an Id if it doesn't have one.
            Repository repo = new Repository();
            var viewName = Request.RequestContext.RouteData.Values["action"].ToString();
            var originalController = Request.RequestContext.RouteData.Values["controller"].ToString();
            int roleId = SessionModel.GlobalRoleId(UseThisForSessions);
            var view = repo.ViewsSelectAll().Where(x => x.ViewName == viewName).FirstOrDefault();

            if (originalController != "RoleInterdiction")
            {
                //repo.InsertViewName(viewName, originalController, view.Id, roleId);
            }

            //this handles the check if a user can visit a page

            //step 1: check if the view is in the dB. if it's not, we'll let them view the page.
            //int viewId = ViewsModelDb.selectViewIdFromName(viewName);
            if (view != null)
            {
                int viewId = view.Id;
                if (0 != viewId)
                {

                    if (roleId == UnassignedRole || roleId == WritingAndPaidRole)
                    {
                        filterContext.Controller.ViewBag.Layout = TeacherLayout;
                        return;
                    }
                    String returnedViewName = GlobalRoleModel.CanUserAccessView(roleId, viewName);
                    //If user is not allowed, redirect them to the "not allowed" page.
                    if (returnedViewName.Equals(DefaultNotAllowedTeacherView))
                    {
                        var controller = (GlobalRoleController)filterContext.Controller;
                        var controllerName = "RoleInterdiction";
                        filterContext.Result = controller.RedirectToAction(returnedViewName, controllerName);
                    }
                    //They are allowed, need to modify viewbag to pass in correct view.
                    else
                    {
                        var roleName = repo.GlobalRoleSelectAll().Where(x => x.Id == roleId).FirstOrDefault().Role;
                        createMap();
                        var sharedView = roleNameViewMapping[roleName];
                        filterContext.Controller.ViewBag.Layout = sharedView;
                    }
                }
            }
            filterContext.Controller.ViewBag.Layout = TeacherLayout;

        }
        private void createMap()
        {
            roleNameViewMapping = new Dictionary<string, string>();
            roleNameViewMapping.Add("Writing-Only-Paid", TeacherLayoutWritingOnly);
            roleNameViewMapping.Add("Inquiry-Only-Paid", TeacherLayoutInquiryOnly);
            roleNameViewMapping.Add("Writing and Inquiry-Paid", TeacherLayout);
        }
    }
}