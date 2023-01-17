using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Source.Models
{
    public class EvaluateWriting_ViewStudentProgressViewModel : AYearCourseSelection
    {
        public StudentModel student { get; set; }
        public List<PaperModel> papers { get; set; }
        public override void RefreshCourseDropDown()
        {
            throw new NotImplementedException();
        }
        public EvaluateWriting_ViewStudentProgressViewModel()
        {

        }
        public EvaluateWriting_ViewStudentProgressViewModel(int studentID) : this()
        {
            student = StudentModelDb.SelectOne(studentID);
            papers = PaperModelDb.SelectAllByStudent(studentID);
        }
    }
}