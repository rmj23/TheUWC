using System.Collections.Generic;


namespace Source.Models
{
    public class UpdateRosterViewModel
    {
        public List<StudentModel> AllStudentsInSchool { get; set; }
        public StudentModel StudentModel { get; set; }

    }
}