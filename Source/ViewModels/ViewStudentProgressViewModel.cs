using Source.Data;
using System.Collections.Generic;

namespace Source.Models
{
    public class ViewStudentProgressViewModel : ACourseStudentYearSelectionViewModel
    {
        public PaperModel Paper { get; set; }
        public List<PaperModel> AllPapers { get; set; }
        public ViewStudentProgressViewModel(int? teacherID, int? yearID, int? classID)
        {
            Repository repo = new Repository();
            YearID = repo.SelectCurrentYearID();
            YearDropDown = AcademicYearModelControls.GetSelectListItems(repo.SelectAllAcademicYearModels(), true);
            CourseDropDown = ClassModelControls.GetSelectListItems(repo.SelectAllByTeacherAndYear((int)teacherID, YearID), true);
            Students = repo.SelectAllByClass(CourseID);

        }

        public override void getNewPortfolio()
        {
            Repository repo = new Repository();

            AllPapers = repo.PaperModelSelectAllByStudentAndClass(StudentID, CourseID);
        }
        public void refreshCourseDropDown(int teacherID)
        {
            Repository repo = new Repository();
            CourseDropDown = ClassModelControls.GetSelectListItems(repo.SelectAllByTeacherAndYear(teacherID, YearID), true);
        }
        public void getStudents()
        {
            Repository repo = new Repository();
            Students = repo.SelectAllByClass(CourseID);
        }
    }
}

