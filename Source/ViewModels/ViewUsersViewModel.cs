using Source.Data;
using System.Collections.Generic;
using System.Linq;

namespace Source.Models
{
    public class ViewUsersViewModel
    {
        public int RoleID { get; set; }
        public List<UserModel> Users { get; set; }
        public ViewUsersViewModel(int? RoleID)
        {
            if (RoleID != null)
            {
                Repository repo = new Repository();
                Users = repo.UserSelectAll().Where(x => x.RoleID == RoleID).ToList();
            }
        }
    }
}