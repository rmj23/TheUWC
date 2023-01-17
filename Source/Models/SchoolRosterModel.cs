using Source.Data;
using System.Collections.Generic;

namespace Source.Models
{
    public class SchoolRosterModel
    {
        public List<StudentModel> AllStudentsInSchool { get; set; }
        public SchoolRosterModel(int SchoolID)
        {
            Repository repo = new Repository();
            AllStudentsInSchool = repo.StudentModelSelectAllBySchool(SchoolID);
        }

        public SchoolRosterModel()
        {

        }
    }
}