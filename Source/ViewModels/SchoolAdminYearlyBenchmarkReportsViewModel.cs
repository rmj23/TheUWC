using Source.Data;
using System.Collections.Generic;

namespace Source.Models
{
    public class SchoolAdminYearlyBenchmarkReportsViewModel : AYearGradeCourseEvaluationViewModel
    {
        public List<EvaluationPeriodModel> AllBenchmarkMonths { get; set; }
        public List<BenchmarkReportsModel> BenchmarkYearReports { get; set; }
        public SchoolAdminYearlyBenchmarkReportsViewModel(int schoolID)
        {
            Repository repo = new Repository();

            SchoolID = schoolID;
            YearDropDown = AcademicYearModelControls.GetSelectListItems(repo.SelectAllAcademicYearModels());
            GradeLevelDropDown = GradeModelControls.GetSelectListItems(repo.GradeModelSelectAll(), true);
            CourseDropDown = ClassModelControls.GetSelectListItemsEmpty();
            AllBenchmarkMonths = repo.EvaluationPeriodSelectAllBenchmark();

        }

        public void GetBenchmarks()
        {
            Repository repo = new Repository();

            var noData = 0;
            BenchmarkYearReports = new List<BenchmarkReportsModel>();
            //get new yearly benchmarks for class
            foreach (var month in AllBenchmarkMonths)
            {
                //BenchmarkReportsModel monthModel = repo.BenchmarkReportsSpecificSchoolSpecificCourse(CourseID, month.ID, YearID);
                //BenchmarkReportsModel monthModel = 
                //BenchmarkReportsModelDB.SpecificSchoolSpecificCourse(CourseID, month.ID, YearID);
                //if (monthModel != null)
                //{
                //    noData += 1;
                //}
                //BenchmarkYearReports.Add(monthModel);
            }
            if (noData == 0)
            {
                BenchmarkYearReports = null;
            }
        }

        public void GetAllBenchmarks()
        {
            Repository repo = new Repository();

            var noData = 0;
            BenchmarkYearReports = new List<BenchmarkReportsModel>();
            //get new yearly benchmarks for every class in grade
            foreach (var month in AllBenchmarkMonths)
            {
                BenchmarkReportsModel monthModel =
                    repo.BenchmarkReportsSpecificSchoolSpecificGrade(month.ID, SchoolID, GradeLevelID);
                //BenchmarkReportsModel monthModel =
                //BenchmarkReportsModelDB.SpecificSchoolSpecificGrade(month.ID, SchoolID, GradeLevelID);
                BenchmarkYearReports.Add(monthModel);
                if (monthModel != null)
                {
                    noData += 1;
                }
            }
            if (noData == 0)
            {
                BenchmarkYearReports = null;
            }
        }

        public void ResetCourseDropDown()
        {
            //reset the course drop down
            CourseDropDown = ClassModelControls.GetSelectListItemsEmpty();
        }

        public void GetCourseDropDown()
        {
            Repository repo = new Repository();

            CourseDropDown = ClassModelControls.GetSelectListItemsWithAll(repo.ClassModelSelectAllBySchoolAndGradeAndYear(SchoolID, GradeLevelID, YearID));
            if (CourseDropDown.Count == 2)
            {
                CourseDropDown = ClassModelControls.GetSelectListItemsEmpty();
            }
        }
    }
}