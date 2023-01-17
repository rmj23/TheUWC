using Source.Data;
using System.Collections.Generic;
using System.Linq;

namespace Source.Models
{
    public class AssignViewViewModel : AGlobalRoleAssignmentSelection
    {
        public List<ViewsModel> AssignedViews { get; set; }
        public List<ViewsModel> UnassignedViews { get; set; }
        public GlobalRoleModel Role { get; set; }
        public AssignViewViewModel()
        {
            Repository repo = new Repository();
            rolesDropDown = GlobalRoleModelControls.getSelectListItems(repo.GlobalRoleSelectAll());
            AssignedViews = repo.ViewsSelectAll().Where(x => x.RoleID == roleId).ToList();
            UnassignedViews = repo.ViewsSelectAll();
        }

        public override void UpdateViews(int roleId)
        {
            Repository repo = new Repository();
            AssignedViews = repo.ViewsSelectAll().Where(x => x.RoleID == roleId).ToList();
            UnassignedViews = repo.ViewsSelectAll().Where(x => x.RoleID != roleId).ToList();
        }
    }
}