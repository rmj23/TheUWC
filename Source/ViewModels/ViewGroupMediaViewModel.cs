using Source.Data;
using System.Collections.Generic;

namespace Source.Models
{
    public class ViewGroupMediaViewModel
    {
        public int groupId { get; set; }
        public int projectId { get; set; }
        public List<GroupMediaModel> groupMediaList { get; set; }
        public List<StudentModel> students { get; set; }
        public GroupModel group { get; set; }

        public ViewGroupMediaViewModel(int? groupId, int? projectId)
        {
            Repository repo = new Repository();

            this.groupId = (int)groupId;
            this.projectId = (int)projectId;
            students = new List<StudentModel>();
            groupMediaList = repo.GroupMediaModelSelectAllByGroup(this.groupId, this.projectId);
            group = repo.GroupModelSelectByGroupID(this.groupId);
            foreach (var x in groupMediaList)
            {
                students.Add(repo.StudentModelSelectOne(x.studentId));
            }
        }
    }
}