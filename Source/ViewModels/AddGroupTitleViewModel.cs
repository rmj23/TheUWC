using Source.Data;
using System.Collections.Generic;

namespace Source.Models
{
    public class EditGroupInfoViewModel
    {
        public GroupModel group { get; set; }
        public List<StudentModel> studentsInGroup { get; set; }
        public EditGroupInfoViewModel(int groupId)
        {
            Repository repo = new Repository();

            group = repo.GroupModelSelectByGroupID(groupId);
            studentsInGroup = repo.StudentModelSelectAllInGroup(groupId);
        }
        public EditGroupInfoViewModel()
        {

        }
    }
}