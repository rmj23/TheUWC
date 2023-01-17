using System.Collections.Generic;
using System.Web.Mvc;

namespace Source.Models
{
    public class EnrollStudentViewModel
    {
        public List<StudentModel> CurrentlyEnrolled { get; set; }
        public List<SelectListItem> SearchType { get; set; }
        public List<SelectListItem> Grade { get; set; }
        public List<StudentModel> ToEnroll { get; set; }

        //public EnrollStudentViewModel(int teacherID, int districtID)
        //{
        //    //Repository repo = new Repository();
        //    //ToEnroll = repo.StudentModelSelectByDistrict(districtID);

        //    //For Testing we need a year drop down
        //    //YearID = repo.SelectCurrentYearID();
        //    //YearDropDown = AcademicYearModelControls.GetSelectListItems(repo.SelectAllAcademicYearModels());
        //    //CourseDropDown = ClassModelControls.GetSelectListItems(repo.SelectAllByTeacherAndYear(teacherID, (int)YearID), true);
        //}

        //public EnrollStudentViewModel(int teacherID, int districtID, int defaultCourseId)
        //{
        //    //Repository repo = new Repository();
        //    //CurrentlyEnrolled = repo.StudentModelSelectAllInClass(CourseID);
        //    //ToEnroll = repo.StudentModelSelectByDistrict(districtID);
        //    ////For Testing we need a year drop down
        //    //YearID = repo.SelectCurrentYearID();
        //    //YearDropDown = AcademicYearModelControls.GetSelectListItems(repo.SelectAllAcademicYearModels());
        //    //CourseDropDown = ClassModelControls.GetSelectListItems(repo.SelectAllByTeacherAndYear(teacherID, (int)YearID), true);

        //    //this.CourseID = defaultCourseId;
        //    //this.State = YearCourseSelectionState.CourseSelected;

        //}
        //public void RefreshStudents(int districtID)
        //{
        //    //Repository repo = new Repository();

        //    //CurrentlyEnrolled = repo.StudentModelSelectAllInClass(CourseID);
        //    //ToEnroll = repo.StudentModelSelectByDistrict(districtID);
        //}

        ////public override void RefreshCourseDropDown(int teacherID)
        ////{
        ////    Repository repo = new Repository();
        ////    CourseDropDown = ClassModelControls.GetSelectListItems(repo.SelectAllByTeacherAndYear(teacherID, (int)YearID), true);
        ////}
    }
}