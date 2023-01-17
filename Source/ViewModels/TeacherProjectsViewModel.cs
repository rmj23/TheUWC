using Source.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Source.Models
{
    public class TeacherProjectsViewModel : ACourseSelectionViewModel
    {
        public List<ProjectModel> projects { get; set; }
        public TeacherProjectsViewModel(int? teacherId)
        {
            Repository repo = new Repository();
            using (SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn))
            {
                CourseDropDown = ClassModelControls.GetSelectListItems(repo.SelectAllByTeacher((int)teacherId), true);

            }
        }
        public TeacherProjectsViewModel(int? teacherId, int courseID)
        {
            Repository repo = new Repository();
            using (SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn))
            {
                this.CourseID = courseID;
                this.State = ACourseSelectionViewModel.CourseSelectionState.CourseSelected;
                CourseDropDown = ClassModelControls.GetSelectListItems(repo.SelectAllByTeacher((int)teacherId), true);
            }

        }
        public override void CourseSelected()
        {
            Repository repo = new Repository();

            projects = repo.ProjectModelSelectAll(CourseID);
        }
    }
}