using Source.Data;
using System.Collections.Generic;

namespace Source.Models
{
    public class MyClassesViewModel : AYearCourseSelection
    {
        public AcademicYearModel AcademicYear;
        public ClassModel Classes;
        public List<StudentModel> Students;

        public MyClassesViewModel(int? teacherID, int? academicYearID, int? classID)
        {
            Repository repo = new Repository();
            YearDropDown = AcademicYearModelControls.GetSelectListItems(repo.SelectAllAcademicYearModels(), false);
            CourseDropDown = ClassModelControls.GetSelectListItems(repo.SelectAllByTeacherAndYear((int)teacherID, YearID), true);
        }

        public override void RefreshCourseDropDown(int teacherID)
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
