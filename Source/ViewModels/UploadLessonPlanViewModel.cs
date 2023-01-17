using Source.Data;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Web;

namespace Source.Models
{
    public class UploadLessonPlanViewModel : ACourseSelectionViewModel
    {
        [Required]
        public HttpPostedFileBase File { get; set; }
        public LessonPlanModel LessonPlan { get; set; }
        public UploadLessonPlanViewModel(int TeacherID)
        {
            Repository repo = new Repository();
            using (SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn))
            {
                CourseDropDown = ClassModelControls.GetSelectListItems(repo.SelectAllByTeacher(TeacherID), true);
                CourseID = -1;
            }
        }
        public UploadLessonPlanViewModel()
        { }

        public override void CourseSelected()
        {

        }

    }
}