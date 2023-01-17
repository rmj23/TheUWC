using Source.Data;
using System.Collections.Generic;

namespace Source.Models
{
    public class ViewGroupsViewModel
    {
        public List<int> groupIds { get; set; }
        public List<GroupModel> groups { get; set; }
        public List<List<StudentModel>> students { get; set; }
        public ProjectModel project { get; set; }
        public ViewGroupsViewModel(int projectId)
        {
            Repository repo = new Repository();

            project = repo.ProjectModelSelectOne(projectId);
            students = new List<List<StudentModel>>();
            groupIds = repo.GroupModelGetGroupIDsFromProjectID(projectId);
            groups = new List<GroupModel>();
            for (int i = 0; i < groupIds.Count; i++)
            {
                List<StudentModel> tmpStudents = repo.StudentModelSelectAllInGroup(groupIds[i]);
                students.Add(tmpStudents);
                groups.Add(repo.GroupModelSelectByGroupID(groupIds[i]));

            }
        }

        public ViewGroupsViewModel()
        {

        }
    }
}