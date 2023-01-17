using Source.Data;
using System.Collections.Generic;

namespace Source.Models
{
    public class ParentStudentAccountsViewModel
    {
        public int TeacherID { get; set; }
        public List<StudentModel> students { get; set; }
        public ParentStudentAccountsViewModel(int TeacherID)
        {
            this.TeacherID = TeacherID;
        }
        public ParentStudentAccountsViewModel(int TeacherID, int courseID)
        {
            Repository repo = new Repository();
            //this.CourseID = courseID;
            //this.State = AYearCourseSelection.YearCourseSelectionState.CourseSelected;
            //this.TeacherID = TeacherID;
            //YearDropDown = AcademicYearModelControls.GetSelectListItems(repo.SelectAllAcademicYearModels(), false);
            //CourseDropDown = ClassModelControls.GetSelectListItems(repo.SelectAllByTeacher(TeacherID), true);
            students = repo.SelectAllByClass(courseID);
        }
        //public override void RefreshCourseDropDown(int teacherID)
        //{
        //    Repository repo = new Repository();
        //    CourseDropDown = ClassModelControls.GetSelectListItems(repo.SelectAllByTeacherAndYear(teacherID, YearID), true);
        //}
        //    public void GetStudents()
        //    {
        //        Repository repo = new Repository();
        //        students = repo.SelectAllByClass(CourseID);
        //    }
        //}
    }
}