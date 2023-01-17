using Source.Data;
using System.Collections.Generic;


namespace Source.Models
{
    public class StudentPortfolioViewModel : AYearCourseSelection
    {
        public int studentID { get; set; }
        public PaperModel Paper { get; set; }
        public List<PaperModel> AllPapers { get; set; }

        public StudentPortfolioViewModel(int? studentID, int? yearID, int? classID)
        {
            Repository repo = new Repository();

            if (yearID != null && classID == null) // Class needs to be selected.
            {
                YearDropDown = AcademicYearModelControls.GetSelectListItems(repo.SelectAllAcademicYearModels(), true);
                CourseDropDown = ClassModelControls.GetSelectListItems(repo.ClassModelSelectAllByStudentAndYear((int)studentID, YearID), true);
            }

            else if (yearID != null && classID != null) // Student needs to be selected.
            {
                YearDropDown = AcademicYearModelControls.GetSelectListItems(repo.SelectAllAcademicYearModels(), true);
                CourseDropDown = ClassModelControls.GetSelectListItems(repo.SelectAllByTeacherAndYear((int)studentID, YearID), true);


            }
            else //New page load w/o Class or Year selected
            {
                YearDropDown = AcademicYearModelControls.GetSelectListItems(repo.SelectAllAcademicYearModels(), false);
                CourseDropDown = ClassModelControls.GetSelectListItems(repo.ClassModelSelectAllByStudentAndYear((int)studentID, YearID), true);
            }


        }
        public override void RefreshCourseDropDown(int studentID)
        {
            Repository repo = new Repository();

            CourseDropDown = ClassModelControls.GetSelectListItems(repo.ClassModelSelectAllByStudentAndYear(studentID, YearID), true);
        }



    }
}