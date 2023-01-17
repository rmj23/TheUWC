using Source.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;

namespace Source.Models
{
    public class InsertProjectViewModel : ACourseSelectionViewModel
    {
        public ProjectModel project { get; set; }
        public List<SelectListItem> continuumType { get; set; }
        [DisplayName("Will your students work in groups?")]
        public bool HasGroup { get; set; }
        public CustomContinuumModel CustomContinuum { get; set; }
        public ClassModel ClassInfo { get; set; }

        public InsertProjectViewModel(int teacherId)
        {
            Repository repo = new Repository();

            CustomContinuum = new CustomContinuumModel();
            CustomContinuum.CustomContinuumRow = repo.ProjectContinuumBuildCustomContinuum();
            project = new ProjectModel();
            project.customCriteria = false;
            CourseDropDown = ClassModelControls.GetSelectListItems(repo.SelectAllByTeacher(teacherId), true);
            continuumType = ContinuumTypeModelControls.GetSelectListItems(repo.ContinuumTypeSelectAll());
            project.dueDate = DateTime.Now;
            ClassInfo = repo.ClassModelSelectAllByTeacherAndCourse(teacherId, 0);
            //ClassInfo = ClassModelDb.SelectAllByTeacherAndCourse(teacherId, 0);

        }
        public InsertProjectViewModel(int teacherId, int? courseID)
        {
            Repository repo = new Repository();

            CustomContinuum = new CustomContinuumModel();
            CustomContinuum.CustomContinuumRow = repo.ProjectContinuumBuildCustomContinuum();
            project = new ProjectModel();
            project.customCriteria = false;
            CourseDropDown = ClassModelControls.GetSelectListItems(repo.SelectAllByTeacher(teacherId), true, courseID ?? 0);
            continuumType = ContinuumTypeModelControls.GetSelectListItems(repo.ContinuumTypeSelectAll());
            project.dueDate = DateTime.Now;

            //change this
            if (courseID == null)
            {
                courseID = Convert.ToInt32(CourseDropDown[1].Value);
            }
            ClassInfo = repo.ClassModelSelectAllByTeacherAndCourse(teacherId, (int)courseID);
            //ClassInfo = ClassModelDb.SelectAllByTeacherAndCourse(teacherId, courseID);
            CourseID = courseID ?? 0;

        }

        public override void CourseSelected()
        {
            throw new NotImplementedException();
        }

        public InsertProjectViewModel()
        {

        }


    }
}