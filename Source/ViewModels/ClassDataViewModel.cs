using Source.Data;

namespace Source.Models
{
    public class ClassDataViewModel : AEvalCourseSelection
    {
        public ClassModel Class { get; set; }
        public EvaluationPeriodModel Period { get; set; }
        public BenchmarkReportsModel BenchmarkReports { get; set; }
        public ClassDataViewModel(int? classID, int? teacherID, int? evalPeriod, int? gradeID, int? districtID, int? userID, int? schoolID)
        {
            Repository repo = new Repository();

            YearID = repo.SelectCurrentYearID();
            EvaluationPeriodDropDown = EvaluationPeriodModelControls.GetSelectListItems(repo.EvaluationPeriodSelectAllBenchmark(), true);
            YearDropDown = AcademicYearModelControls.GetSelectListItems(repo.SelectAllAcademicYearModels());
            CourseDropDown = ClassModelControls.GetSelectListItems(repo.SelectAllByTeacherAndYear((int)teacherID, (int)YearID), true);
        }
        public void refreshCourseDropDown(int teacherID)
        {
            Repository repo = new Repository();
            CourseDropDown = ClassModelControls.GetSelectListItems(repo.SelectAllByTeacherAndYear(teacherID, (int)YearID), true);
        }
        public void getNewTeacherBenchmark()
        {
            Repository repo = new Repository();
            //BenchmarkReports = repo.BenchmarkReportsSpecificSchoolSpecificCourse((int)CourseID, (int)EvalPeriodID, (int)YearID);
            //BenchmarkReports = BenchmarkReportsModelDB.SpecificSchoolSpecificCourse((int)CourseID, (int)EvalPeriodID, (int)YearID);
        }
    }
}