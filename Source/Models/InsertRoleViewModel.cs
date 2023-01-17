using Source.Data;
using System.Collections.Generic;

namespace Source.Models
{
    public class InsertRoleViewModel
    {
        public GlobalRoleModel role { get; set; }
        public List<GlobalRoleModel> allRoles { get; set; }
        public InsertRoleViewModel()
        {
            Repository repo = new Repository();
            allRoles = repo.GlobalRoleSelectAll();
        }
    }
}