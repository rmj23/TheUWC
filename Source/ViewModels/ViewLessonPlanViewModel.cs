using Source.Data;
using System.Collections.Generic;

namespace Source.Models
{
    public class ViewLessonPlanViewModel : ACourseSelectionViewModel
    {
        public LessonPlanModel LessonPlanModel { get; set; }
        public List<LessonPlanModel> LessonPlans { get; set; }
        public int TeacherID { get; set; }
        public ViewLessonPlanViewModel(int teacherID)
        {
            Repository repo = new Repository();
            this.TeacherID = teacherID;
            CourseDropDown = ClassModelControls.GetSelectListItems(repo.SelectAllByTeacher(teacherID), true);
        }
        public ViewLessonPlanViewModel(int teacherID, int courseID)
        {
            Repository repo = new Repository();
            this.CourseID = courseID;
            this.State = ACourseSelectionViewModel.CourseSelectionState.CourseSelected;

            this.TeacherID = teacherID;
            CourseDropDown = ClassModelControls.GetSelectListItems(repo.SelectAllByTeacher(teacherID), true);
        }
        public override void CourseSelected()
        {
        }
        public ViewLessonPlanViewModel()
        {


        }

    }
}
