using Source.Data;
using System.Data.SqlClient;

namespace Source.Models
{
    public class GroupViewModel : AStudentSelectionViewModel
    {
        public GroupModel Group { get; set; }

        public GroupViewModel(int? teacherId)
        {
            Repository repo = new Repository();
            using (SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn))
            {
                if (teacherId != null)
                {
                    CourseDropDown = ClassModelControls.GetSelectListItems(repo.SelectAllByTeacher((int)teacherId));
                }
            }
        }

        public override void RefreshStudentDropDown()
        {
            Repository repo = new Repository();
            StudentDropDown = StudentModelControls.GetSelectListItems(repo.SelectAllByClass(CourseID));
        }
    }
}