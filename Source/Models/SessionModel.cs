using Source.Data;
using System.Web.Routing;

namespace Source.Models
{
    public class SessionModel
    {
        public static void UserIsTeacher(RequestContext requestContext)
        {
            UserModel sessionUser = (UserModel)requestContext.HttpContext.Session["User"];
            if (sessionUser == null || sessionUser.RoleID != 1)
            {
                if (!requestContext.HttpContext.Response.IsRequestBeingRedirected)
                    requestContext.HttpContext.Response.Redirect("~/authentication/login", true);
            }
        }

        public static void UserIsStudent(RequestContext requestContext)
        {
            UserModel sessionUser = (UserModel)requestContext.HttpContext.Session["User"];
            if (sessionUser == null || sessionUser.RoleID != 2)
            {
                if (!requestContext.HttpContext.Response.IsRequestBeingRedirected)
                    requestContext.HttpContext.Response.Redirect("~/authentication/login", true);
            }
        }
        public static void UserIsDistrictAdmin(RequestContext requestContext)
        {
            UserModel sessionUser = (UserModel)requestContext.HttpContext.Session["User"];
            if (sessionUser == null || sessionUser.RoleID != 4)
            {
                if (!requestContext.HttpContext.Response.IsRequestBeingRedirected)
                    requestContext.HttpContext.Response.Redirect("~/authentication/login", true);
            }
        }
        public static void UserIsParent(RequestContext requestContext)
        {
            UserModel sessionUser = (UserModel)requestContext.HttpContext.Session["User"];
            if (sessionUser == null || sessionUser.RoleID != 5)
            {
                if (!requestContext.HttpContext.Response.IsRequestBeingRedirected)
                    requestContext.HttpContext.Response.Redirect("~/authentication/login", true);
            }
        }
        public static void UserIsSchoolAdmin(RequestContext requestContext)
        {
            UserModel sessionUser = (UserModel)requestContext.HttpContext.Session["User"];
            if (sessionUser == null || sessionUser.RoleID != 6)
            {
                if (!requestContext.HttpContext.Response.IsRequestBeingRedirected)
                    requestContext.HttpContext.Response.Redirect("~/authentication/login", true);
            }
        }
        public static int UserID(RequestContext requestContext)
        {
            return ((UserModel)requestContext.HttpContext.Session["User"]).ID;
        }
        public static int GlobalRoleId(RequestContext requestContext)
        {
            UserModel user = ((UserModel)requestContext.HttpContext.Session["User"]);
            return user.globalRoleId;
        }
        public static int SchoolID(RequestContext requestContext)
        {
            return ((UserModel)requestContext.HttpContext.Session["User"]).SchoolID;
        }
        public static int DistrictID(RequestContext requestContext)
        {
            return ((UserModel)requestContext.HttpContext.Session["User"]).DistrictID;
        }
        private static TeacherModel GetTeacherModel(RequestContext requestContext)
        {
            Repository repo = new Repository();

            if (requestContext.HttpContext.Session["User"] == null)
            {
                if (!requestContext.HttpContext.Response.IsRequestBeingRedirected)
                    requestContext.HttpContext.Response.Redirect("~/authentication/login", true);
                return null;
            }
            else
            {
                if (requestContext.HttpContext.Session["Teacher"] == null)
                {
                    requestContext.HttpContext.Session["Teacher"] = repo.TeacherModelSelectOneByUserModel((UserModel)requestContext.HttpContext.Session["User"]);
                }
            }
            return (TeacherModel)requestContext.HttpContext.Session["Teacher"];
        }
        public static int TeacherID(RequestContext requestContext)
        {
            if (GetTeacherModel(requestContext) == null)
                return -1;
            return GetTeacherModel(requestContext).TeacherID;
        }

        public static DefualtClassSettings DefualtClassSettings(RequestContext requestContext)
        {
            Repository repo = new Repository();

            DefualtClassSettings model = new DefualtClassSettings();
            if (GetTeacherModel(requestContext) == null)
            {
                return model;
            }
            else
            {
                model = repo.DefaultClassGetSettingsDefaultClass(GetTeacherModel(requestContext).TeacherID);
                //model = DefualtClassSettingsDb.GetSettingsDefualtClass(GetTeacherModel(requestContext).TeacherID);
                return model;
            }
        }
        public static bool DefaultClassEnabled(RequestContext requestContext)
        {
            Repository repo = new Repository();

            if (GetTeacherModel(requestContext) == null)
            {
                return false;
            }
            bool defaultClass = repo.DefaultClassGetSettingsDefaultClass(GetTeacherModel(requestContext).TeacherID).DefualtEnabled;
            //bool defualtClass = DefualtClassSettingsDb.GetSettingsDefualtClass(GetTeacherModel(requestContext).TeacherID).DefualtEnabled;
            return defaultClass;
        }
        public static int DefaultClassID(RequestContext requestContext)
        {
            Repository repo = new Repository();

            if (GetTeacherModel(requestContext) == null)
                return -1;
            DefualtClassSettings defaultClass = repo.DefaultClassGetSettingsDefaultClass(GetTeacherModel(requestContext).TeacherID);
            //DefualtClassSettings defualtClass = DefualtClassSettingsDb.GetSettingsDefualtClass(GetTeacherModel(requestContext).TeacherID);
            if (defaultClass.DefualtEnabled)
            {
                return defaultClass.DefualtClass;
            }
            else
            {
                return -1;
            }
        }
        public static int DistrictAdminID(RequestContext requestContext)
        {
            if (GetDistrictAdminModel(requestContext) == null)
                return -1;
            return GetDistrictAdminModel(requestContext).DistrictAdminID;
        }
        /// returns ParentID if valid
        public static int ParentID(RequestContext requestContext)
        {
            if (GetParentModel(requestContext) == null)
                return -1;
            return GetParentModel(requestContext).ParentID;
        }
        /// returns StudentID if valid
        public static int StudentID(RequestContext requestContext)
        {
            if (GetStudentModel(requestContext) == null)
                return -1;
            return GetStudentModel(requestContext).StudentID;
        }
        private static DistrictAdminModel GetDistrictAdminModel(RequestContext requestContext)
        {
            Repository repo = new Repository();

            if (requestContext.HttpContext.Session["User"] == null)
            {
                if (!requestContext.HttpContext.Response.IsRequestBeingRedirected)
                    requestContext.HttpContext.Response.Redirect("~/authentication/login", true);
                return null;
            }
            else
            {
                if (requestContext.HttpContext.Session["DistrictAdmin"] == null)
                {
                    requestContext.HttpContext.Session["DistrictAdmin"] = repo.DistrictAdminSelectOneByUserModel((UserModel)requestContext.HttpContext.Session["User"]);
                }
            }
            return (DistrictAdminModel)requestContext.HttpContext.Session["DistrictAdmin"];
        }
        /// <summary>
        /// Get Parent Model
        /// </summary>
        /// <param name="requestContext"></param>
        /// <returns>Parent Session</returns>
        private static ParentModel GetParentModel(RequestContext requestContext)
        {
            Repository repo = new Repository();

            if (requestContext.HttpContext.Session["User"] == null)
            {
                if (!requestContext.HttpContext.Response.IsRequestBeingRedirected)
                    requestContext.HttpContext.Response.Redirect("~/authentication/login", true);
                return null;
            }
            else
            {
                if (requestContext.HttpContext.Session["Parent"] == null)
                {
                    requestContext.HttpContext.Session["Parent"] = repo.ParentModelSelectOneByUserModel((UserModel)requestContext.HttpContext.Session["User"]);
                }
            }
            return (ParentModel)requestContext.HttpContext.Session["Parent"];
        }
        /// <summary>
        /// Get Student Model
        /// </summary>
        /// <param name="requestContext"></param>
        /// <returns>Student Session</returns>
        private static StudentModel GetStudentModel(RequestContext requestContext)
        {
            Repository repo = new Repository();

            if (requestContext.HttpContext.Session["User"] == null)
            {
                if (!requestContext.HttpContext.Response.IsRequestBeingRedirected)
                    requestContext.HttpContext.Response.Redirect("~/authentication/login", true);
                return null;
            }
            else
            {
                if (requestContext.HttpContext.Session["Student"] == null)
                {
                    requestContext.HttpContext.Session["Student"] = repo.StudentModelSelectOneByUserModel((UserModel)requestContext.HttpContext.Session["User"]);
                }
            }
            return (StudentModel)requestContext.HttpContext.Session["Student"];
        }

        public static string GetUserName(RequestContext requestContext)
        {
            try
            {
                UserModel model = (UserModel)requestContext.HttpContext.Session["User"];
                return model.FirstName + " " + model.LastName;
            }
            catch
            {
                return "";
            }
        }
        public static int GetUserPoints(RequestContext requestContext)
        {
            Repository repo = new Repository();
            try
            {
                int points = 0;
                UserModel model = (UserModel)requestContext.HttpContext.Session["User"];
                points = repo.SelectPoints(model.ID);
                return points;

            }
            catch
            {
                return 0;
            }
        }

    }
}