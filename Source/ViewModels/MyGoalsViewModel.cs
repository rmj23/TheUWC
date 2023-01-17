using Source.Data;
using System.Collections.Generic;

namespace Source.Models
{
    public class MyGoalsViewModel
    {
        public List<StudentGoalsModel> SelectStudentGoals { get; set; }
        private int StudentID { get; set; }

        public MyGoalsViewModel(int studentId)
        {
            Repository repo = new Repository();
            StudentID = studentId;
            SelectStudentGoals = repo.GoalsSelectByStudent(StudentID);
        }
    }
}