using Source.Data;
using System.Collections.Generic;

namespace Source.Models
{
    public class ParentFeedbackViewModel
    {
        public List<MyFeedbackViewModel> StudentsFeedback { get; set; }
        public List<StudentModel> AllStudentsModel { get; set; }
        public ParentFeedbackViewModel(int parentID)
        {
            Repository repo = new Repository();

            List<MyFeedbackViewModel> allStudents = new List<MyFeedbackViewModel>();
            AllStudentsModel = repo.StudentModelSelectAllByParentID(parentID);
            foreach (var student in AllStudentsModel)
            {
                MyFeedbackViewModel feedbackStudent = new MyFeedbackViewModel();
                feedbackStudent.StudentFeedback = repo.PaperResultsModelSelectAllStudentFeedback(student.StudentID);

                allStudents.Add(feedbackStudent);
            }
            StudentsFeedback = allStudents;
        }
    }
}