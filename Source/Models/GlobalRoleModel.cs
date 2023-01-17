using Source.Data;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace Source.Models
{
    public class GlobalRoleModel
    {
        public int Id { get; set; }
        public string Role { get; set; }
        private const string DefaultNotAllowedTeacherView = "UserNotAllowed";

        public static string CanUserAccessView(int roleId, string viewName)
        {
            Repository repo = new Repository();
            int viewId = repo.ViewsSelectAll().Where(x => x.ViewName == viewName).FirstOrDefault().Id;
            bool allowed = repo.CanUserAccessView(roleId, viewId);
            if (allowed)
            {
                return viewName;
            }
            return DefaultNotAllowedTeacherView;
        }
    }

    public static class GlobalRoleModelControls
    {
        private const int UnassignedId = 99;
        public static List<SelectListItem> getSelectListItems(List<GlobalRoleModel> models)
        {
            List<SelectListItem> output = new List<SelectListItem>();
            foreach (var model in models)
            {
                if (model.Id != UnassignedId)
                {
                    output.Add(new SelectListItem()
                    {
                        Text = model.Role,
                        Value = model.Id.ToString()
                    });
                }
            }
            foreach (SelectListItem item in output)
            {
                item.Selected = false;
            }
            output.Insert(0, new SelectListItem() { Text = "Please Select", Value = "0", Selected = true });
            return output;
        }
    }
}