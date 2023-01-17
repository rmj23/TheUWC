using System.Collections.Generic;

namespace Source.Models
{
    public class ViewClassGoalsViewModel
    {
        public ClassGoalsModel ClassGoals { get; set; }
        public List<ClassModel> AllClasses { get; set; }
        public List<ClassGoalsModel> Goals { get; set; }
        public int TeacherID { get; set; }
        public ViewClassGoalsViewModel(int teacherID)
        {

        }

        //public override void CourseSelected()
        //{
        //    throw new NotImplementedException();
        //}
        //public void RefreshGoals(int TeacherID)
        //{
        //    Repository repo = new Repository();
        //    Goals = repo.GoalsSelectByClass(TeacherID, CourseID);
        //}

    }
}