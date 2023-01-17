using Source.Data;

namespace Source.Models
{
    public class EditStudentViewModel
    {
        public StudentModel Student { get; set; }
        public int CourseID { get; set; }
        public EditStudentViewModel(int studentID)
        {
            Repository repo = new Repository();

            Student = repo.StudentModelSelectOne(studentID);

        }

        public EditStudentViewModel(int studentID, int courseID)
        {
            Repository repo = new Repository();

            Student = repo.StudentModelSelectOne(studentID);
            CourseID = courseID;
        }

        public EditStudentViewModel()
        {

        }
    }
}