using Source.Data;
using System.Collections.Generic;
using System.Linq;

namespace Source.Models
{
    public class GroupStudentViewModel
    {
        public ProjectModel project { get; set; }
        public List<GroupWithStudentsViewModel> groups { get; set; }
        public List<StudentModel> classRoster { get; set; }
        public int activeGroupId { get; set; }
        public GroupStudentViewModel()
        {

        }
        public GroupStudentViewModel(int projectId, int? _activeGroupId)
        {
            Repository repo = new Repository();

            project = repo.ProjectModelSelectOne(projectId);
            classRoster = repo.StudentModelSelectAllInClassNotInGroup(project.courseId, project.projectId); //students in class not assigned to roster
            groups = new List<GroupWithStudentsViewModel>();
            List<int> listGroupId = repo.GroupModelGetGroupIDsFromProjectID(projectId);
            if (listGroupId == null || listGroupId.Count == 0)//if there are no groups add the first group
            {
                AddGroup();
            }
            else//else there are groups, add them to the groups list
            {
                foreach (var grID in listGroupId)
                {
                    groups.Add(new GroupWithStudentsViewModel(grID));
                }

                activeGroupId = groups.Max(r => r.group.groupId);
            }

            if (_activeGroupId != null)
            {
                activeGroupId = (int)_activeGroupId;
            }

        }

        public void AddGroup()
        {
            Repository repo = new Repository();

            if (groups == null || groups.Count == 0)//there are no groups yet
            {
                int initGroupNum = 1;
                int initGroupId = repo.GroupModelInsert(project.projectId, initGroupNum);//init a new group under the project with the new group num as one, because it it first
                groups.Add(new GroupWithStudentsViewModel(initGroupId)); //add the new group to the groups list
                activeGroupId = initGroupId;//set the group as active for the view
            }
            else //there are groups
            {
                foreach (var group in groups)//if there are groups with no students do not create another group
                {
                    if (group.groupRoster == null || group.groupRoster.Count == 0)
                    {
                        return;
                    }
                }
                int maxGroupNum = -1;//init max group number (NOT GROUP ID)
                foreach (var group in groups)//find the largest group number
                {
                    if (group.group.groupNumber > maxGroupNum)
                    {
                        maxGroupNum = group.group.groupNumber;
                    }
                }
                maxGroupNum += 1; //Add one to make it the biggest
                int initGroupId = repo.GroupModelInsert(project.projectId, maxGroupNum); //init a new group under the project with the new group num
                groups.Add(new GroupWithStudentsViewModel(initGroupId)); //add the new group to the groups list
                activeGroupId = initGroupId;//set the group as active for the view
            }
        }
        public void RemoveGroup(int groupId)
        {
            Repository repo = new Repository();

            foreach (var gr in groups)
            {
                if (gr.group.groupId == groupId)
                {
                    groups.Remove(gr);
                    repo.GroupModelDeleteGroup(groupId);//This removes all students from the group and deletes the group
                    break;
                }
            }
            //Make sure ordering of group numbers is sequential 
            if (groups.Count != 0)//If there are groups
            {
                groups.Sort((x, y) => x.group.groupNumber.CompareTo(y.group.groupNumber));//Sort groups by group number
                if (groups[0].group.groupNumber != 1)//This is dealing with the case that group 1 was deleted. We must set a new group one
                {
                    groups[0].group.groupNumber = 1;
                    repo.GroupModelUpdateGroupNumber(groups[0].group.groupId, 1);
                }
                int lastGroupNum = 0;
                foreach (var gro in groups)//Now check and reset any groups
                {
                    if (gro.group.groupNumber != lastGroupNum + 1)//if the group number is not the next int
                    {
                        gro.group.groupNumber = lastGroupNum + 1; //correct the group number
                        repo.GroupModelUpdateGroupNumber(gro.group.groupId, gro.group.groupNumber);//save the group number
                        activeGroupId = gro.group.groupId;//Set the active groupId (It will land on the last one)
                    }
                    lastGroupNum = gro.group.groupNumber;//increment the group number
                }
                activeGroupId = groups.Max(r => r.group.groupId);//Set the active group as the last one
            }
            else //else there are no groups so add an empty first group
            {
                AddGroup();
            }
            classRoster = repo.StudentModelSelectAllInClassNotInGroup(project.courseId, project.projectId); //students in class not assigned to roster
        }
    }
}