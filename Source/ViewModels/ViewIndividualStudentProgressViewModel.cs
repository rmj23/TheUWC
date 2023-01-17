using Source.Data;
using System.Collections.Generic;

namespace Source.Models
{
    public class ViewIndividualStudentProgressViewModel
    {
        public List<PaperModel> AllStudentPapers { get; set; }
        public List<UserModel> Student { get; set; }
        public int CourseID;

        public ViewIndividualStudentProgressViewModel(int studentID)
        {
            Repository repo = new Repository();

            CourseID = 3;
            AllStudentPapers = repo.PaperModelSelectAllByStudentAndClass(studentID, CourseID);
            Student = repo.StudentModelSelectUserByStudentID(studentID);
        }
    }
}
