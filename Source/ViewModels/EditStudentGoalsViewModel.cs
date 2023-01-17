using Source.Data;

namespace Source.Models
{
    public class EditStudentGoalsViewModel
    {
        public StudentGoalsModel StudentGoals { get; set; }
        public int YearID { get; set; }
        public int CourseID { get; set; }
        public EditStudentGoalsViewModel(int goalID, int yearID, int courseID)
        {
            Repository repo = new Repository();

            YearID = yearID;
            CourseID = courseID;
            StudentGoals = repo.StudentGoalsModelSelectByGoalID(goalID);
        }
        public EditStudentGoalsViewModel() { }
    }
}