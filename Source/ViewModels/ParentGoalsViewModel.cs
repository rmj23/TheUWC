using Source.Data;
using System.Collections.Generic;

namespace Source.Models
{
    public class ParentGoalsViewModel
    {
        public List<MyGoalsViewModel> StudentsGoals { get; set; }
        public List<StudentModel> AllStudentsModel { get; set; }

        public ParentGoalsViewModel(int parentID)
        {
            Repository repo = new Repository();

            List<MyGoalsViewModel> allstudents = new List<MyGoalsViewModel>();
            AllStudentsModel = repo.StudentModelSelectAllByParentID(parentID);
            foreach (var student in AllStudentsModel)
            {
                allstudents.Add(new MyGoalsViewModel(student.StudentID));
            }
            StudentsGoals = allstudents;
        }
    }
}