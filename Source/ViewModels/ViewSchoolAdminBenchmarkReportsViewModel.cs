using Source.Data;
using System.Collections.Generic;

namespace Source.Models
{
    public class ViewSchoolAdminBenchmarkReportsViewModel : AGradeEvaluationPeriodViewModel
    {
        public BenchmarkReportsModel BenchmarkReports { get; set; }
        public List<BenchmarkReportsModel> AllBenchmarkReports { get; set; }
        public ViewSchoolAdminBenchmarkReportsViewModel(int? gradeID, int? evalPeriod, int? courseID, int schoolID)
        {
            Repository repo = new Repository();

            SchoolID = schoolID;
            YearDropDown = AcademicYearModelControls.GetSelectListItems(repo.SelectAllAcademicYearModels());
            EvaluationPeriodDropDown = EvaluationPeriodModelControls.GetSelectListItems(repo.EvaluationPeriodSelectAllBenchmark(), true);
            GradeLevelDropDown = GradeModelControls.GetSelectListItems(repo.GradeModelSelectAll(), true);
            CourseDropDown = ClassModelControls.GetSelectListItemsEmpty();

        }
        public void getNewBenchmark()
        {
            Repository repo = new Repository();
            //BenchmarkReports = repo.BenchmarkReportsSpecificSchoolSpecificCourse((int)CourseID, (int)EvalPeriodID, (int)YearID);
            //BenchmarkReports = BenchmarkReportsModelDB.SpecificSchoolSpecificCourse((int)CourseID, (int)EvalPeriodID, (int)YearID);
        }

        public void getNewCourses()
        {
            Repository repo = new Repository();

            CourseDropDown = ClassModelControls.GetSelectListItemsWithAll(repo.ClassModelSelectAllBySchoolAndGradeAndYear(SchoolID, GradeLevelID, YearID));
            CourseID = 0;
        }

        public void getAllBenchmark()
        {
            Repository repo = new Repository();
            BenchmarkReports = repo.BenchmarkReportsSpecificSchoolSpecificGrade(EvalPeriodID, SchoolID, GradeLevelID);

            //BenchmarkReports =
            //BenchmarkReportsModelDB.SpecificSchoolSpecificGrade(EvalPeriodID, SchoolID, GradeLevelID);
        }
    }
}