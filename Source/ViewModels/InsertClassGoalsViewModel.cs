using Source.Data;
using System.Collections.Generic;

namespace Source.Models
{
    public class InsertClassGoalsViewModel : ACoursePaperEvaluationViewModel
    {
        public ClassGoalsModel ClassGoals { get; set; }
        public List<ClassModel> AllClasses { get; set; }
        public List<ContinuumModel> Continuum { get; set; }
        public ClassModel Class { get; set; }
        public ClassGoalsModel Goal { get; set; }
        public int TeacherID { get; set; }
        public string deadlineTime { get; set; }
        public string EvalTitleTemp { get; set; }

        //public int getLevel(int CourseID)
        //{
        //    Repository repo = new Repository();
        //    int monthID = System.DateTime.Now.Month;
        //    int gradeID = repo.ClassSelectOneByID(CourseID).GradeID;
        //    int level = repo.GetLevelByMonthAndGrade(monthID, gradeID);
        //    return level;
        //}
        //public void getContinuum(int levelID)
        //{
        //    Repository repo = new Repository();
        //    Continuum = repo.SelectGuidlineByLevelAndType(levelID, EvaluationTypeID, PaperTypeID);
        //}
        public void GetCourse(int teacherID)
        {
            Repository repo = new Repository();
            CourseDropDown = ClassModelControls.GetSelectListItems(repo.SelectAllByTeacher(teacherID), true);
        }
        public void GetPaperTypeID()
        {
            Repository repo = new Repository();
            PaperTypeDropDown = PaperTypeModelControls.GetSelectListItems(repo.PaperSelectAll());
        }
        public void GetScoreTypes()
        {
            Repository repo = new Repository();
            EvaluationTypeDropDown = EvaluationTypeControls.GetSelectListItems(repo.EvaluationSelectAllWithConventions());
        }

    }
}
