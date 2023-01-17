using Source.Data;

namespace Source.Models
{
    public class AddParentViewModel
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int CourseID { get; set; }
        public ParentModel ParentModel { get; set; }
        public StudentModel Student { get; set; }

        public AddParentViewModel(int ID)
        {
            Repository repo = new Repository();

            Student = repo.StudentModelSelectOne(ID);
            StudentName = Student.FirstName + " " + Student.LastName;
        }
        public AddParentViewModel()
        {

        }
    }
}