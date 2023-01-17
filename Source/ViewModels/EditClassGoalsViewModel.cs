using Source.Data;

namespace Source.Models
{

    public class EditClassGoalsViewModel
    {
        public ClassGoalsModel ClassGoals { get; set; }
        public EditClassGoalsViewModel(int goalID, int courseID)
        {
            Repository repo = new Repository();
            ClassGoals = repo.ClassGoalsSelectByID(goalID, courseID);
            //ClassGoals = ClassGoalsModelDb.GoalsSelectByID(goalID, courseID);
        }
        public EditClassGoalsViewModel() { }
    }
}