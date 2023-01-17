using Source.Data;
using System.Collections.Generic;

namespace Source.Models
{
    public class GroupWithStudentsViewModel
    {
        public GroupModel group { get; set; }
        public List<StudentModel> groupRoster { get; set; }

        public GroupWithStudentsViewModel(int groupId)
        {
            Repository repo = new Repository();

            group = repo.GroupModelSelectByGroupID(groupId);
            groupRoster = repo.StudentModelSelectAllInGroup(groupId);
        }
    }
}