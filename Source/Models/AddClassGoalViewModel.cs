using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Source.Models
{
    public class AddClassGoalViewModel : ACourseSelectionViewModel
    {
        public ClassGoalsModel Goal { get; set; }
        public AddClassGoalViewModel()
        {
            
        }
        public AddClassGoalViewModel(int teacherID)
        {
            CourseDropDown = ClassModelControls.GetSelectListItems((ClassModelDb.SelectAllByTeacher(teacherID)),true);
            
        }

        public override void CourseSelected()
        {
            Goal = new ClassGoalsModel();
            Goal.courseID = CourseID;
        }
    }
}
