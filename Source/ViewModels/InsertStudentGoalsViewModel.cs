using Source.Data;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Source.Models
{
    public class InsertStudentGoalsViewModel : APaperResultsSelection
    {
        public int YearID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public PaperModel Paper { get; set; }
        public StudentGoalsModel Goal { get; set; }
        public string StudentName { get; set; }
        public string deadlineTime { get; set; }
        public List<PaperResultsModel> Reports { get; set; }
        public List<SelectListItem> ScoreTypes { get; set; }
        public List<ContinuumModel> Continuum { get; set; }
        public InsertStudentGoalsViewModel(int? yearID, int? courseID, int? studentID)
        {
            Repository repo = new Repository();

            if (yearID != null & courseID != null & studentID != null)
            {
                this.YearID = (int)yearID;
                this.CourseID = (int)courseID;
                this.StudentID = (int)studentID;
            }


            deadlineTime = " 00:00:00.00";
            Goal = new StudentGoalsModel();
            var Student = repo.StudentModelSelectOne(StudentID);
            StudentName = Student.FirstName + ' ' + Student.LastName;

            Goal.StudentID = StudentID;

            PaperDropDown = StudentGoalsModelControls.GetSelectListItems(repo.PaperModelSelectAllByStudentAndClass(StudentID, CourseID), true);
            ScoreTypes = EvaluationTypeControls.GetSelectListItems(repo.EvaluationSelectAllWithConventions());
        }
        public InsertStudentGoalsViewModel()
        { }
        public void RefreshReports(int PaperID)
        {
            Repository repo = new Repository();

            Reports = repo.PaperResultsModelSelectReport(PaperID);
        }
        public void RefreshPaper(int PaperID)
        {
            Repository repo = new Repository();

            Paper = repo.PaperModelSelectOneByPaperID(PaperID);
        }
        public void GetScoreTypes()
        {
            Repository repo = new Repository();
            ScoreTypes = EvaluationTypeControls.GetSelectListItems(repo.EvaluationSelectAllWithConventions());
        }

        public void GetPaperDropDown()
        {
            Repository repo = new Repository();

            PaperDropDown = StudentGoalsModelControls.GetSelectListItems(repo.PaperModelSelectAllByStudentAndClass(StudentID, CourseID));
        }
    }
}