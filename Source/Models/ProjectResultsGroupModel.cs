using Source.Data;
using System.Collections.Generic;

namespace Source.Models
{
    /// <summary>
    /// Each ProjectGroupResultsModel has basic group information along with a list of ProjectStudentResultsModel
    /// Each ProjectStudentsResultsModel has a list of ProjectElementResultsModel
    /// Each ProjectElementResultsModel has a list of ProjectCharacteristicResultsModel to hold information about the individual characteristic 
    /// </summary>
    public class ProjectResultsGroupModel
    {
        public GroupModel Group { get; set; }//Contains: Group ID, Project ID, Project Title, GroupNumber, GroupName, ProjectSubtitle
        public List<ProjectResultsStudentModel> StudentResults { get; set; }//Contains Name, Overall Holistic score, and Comments/Feedback, Evaluation Date

        public ProjectResultsGroupModel(int groupId)
        {
            Repository repo = new Repository();

            Group = repo.GroupModelSelectByGroupID(groupId);
            StudentResults = repo.ProjectResultsStudentModelSelectAllStudents(groupId);
            foreach (var student in StudentResults)
            {
                student.BuildScoreResults();
            }
        }

    }
}