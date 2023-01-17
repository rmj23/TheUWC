using System.Collections.Generic;

namespace Source.Models
{
    public class StudentGoalsViewModel
    {
        public PaperModel Paper { get; set; }
        public StudentGoalsModel StudentGoals { get; set; }
        public List<StudentGoalsModel> SelectStudentGoals { get; set; }

    }

}