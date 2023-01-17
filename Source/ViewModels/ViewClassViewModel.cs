using Source.Data;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Source.Models
{
    public class ViewClassViewModel : AYearCourseSelection
    {
        public ClassModel Class { get; set; }
        public List<SelectListItem> GradeDropDown { get; set; }
        public List<SelectListItem> PeriodDropDown { get; set; }
        public List<StudentModel> AllStudentsInClass { get; set; }
        private int TeacherID { get; set; }
        public ViewClassViewModel(int teacherID)
        {
            Repository repo = new Repository();

            this.TeacherID = teacherID;
            GradeDropDown = GradeModelControls.GetSelectListItems(repo.GradeModelSelectAll());
            YearDropDown = AcademicYearModelControls.GetSelectListItems(repo.SelectAllAcademicYearModels(), true);
            this.YearID = 0;
            this.CourseID = 0;
            PeriodDropDown = PeriodModelControls.GetSelectListItems();
        }
        public ViewClassViewModel(int teacherID, int courseID)
        {
            Repository repo = new Repository();

            this.CourseID = courseID;
            this.State = AYearCourseSelection.YearCourseSelectionState.CourseSelected;
            this.TeacherID = teacherID;
            GradeDropDown = GradeModelControls.GetSelectListItems(repo.GradeModelSelectAll());
            YearDropDown = AcademicYearModelControls.GetSelectListItems(repo.SelectAllAcademicYearModels(), true);
            this.YearID = 0;
            this.CourseID = 0;
            PeriodDropDown = PeriodModelControls.GetSelectListItems();
        }
        public void RefreshCourse()
        {
            Repository repo = new Repository();
            AllStudentsInClass = repo.SelectAllByClass(CourseID);
        }
        public void RefreshCourseDropDown()
        {
            Repository repo = new Repository();
            CourseDropDown = ClassModelControls.GetSelectListItems(repo.SelectAllByTeacherAndYear(TeacherID, YearID), true);
        }

        public override void RefreshCourseDropDown(int teacherID)
        {
            throw new NotImplementedException();
        }
    }
}