using Source.Data;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Source.Models
{
    public class ViewDistrictBenchmarkReportsViewModel : ASchoolGradeEvaluationPeriod
    {
        public int DistrictID { get; set; }
        public BenchmarkReportsModel BenchmarkReports { get; set; }
        public List<SelectListItem> AcademicYearDropdown { get; set; }
        public ViewDistrictBenchmarkReportsViewModel(int? SchoolID, int? GradeID, int? EvalPeriodID, int userID, int DistrictID, int? YearID)
        {
            Repository repo = new Repository();

            this.DistrictID = DistrictID;
            this.UserID = userID;
            YearDropDown = AcademicYearModelControls.GetSelectListItems(repo.SelectAllAcademicYearModels());
            SchoolDropDown = SchoolModelControls.GetSelectListItems(repo.SchoolModelSelectAllByDistrict(DistrictID), true);
            GradeLevelDropDown = GradeModelControls.GetSelectListItems(repo.GradeModelSelectAll(), true);
            EvaluationPeriodDropDown = EvaluationPeriodModelControls.GetSelectListItems(repo.EvaluationPeriodSelectAllBenchmark(), true);
            AcademicYearDropdown = AcademicYearModelControls.GetSelectListItems(repo.SelectAllAcademicYearModels(), true);
            //Use cases for each benchmark.
            if (SchoolID == null && GradeID == null && EvalPeriodID != null) // Get benchmarks for all schools, all grades, all benchmark months.
            {
                BenchmarkReports = repo.BenchmarkReportsSelectAllSchoolsAllGrades((int)EvalPeriodID, userID, (int)YearID);
                // BenchmarkReports = BenchmarkReportsModelDB.AllSchoolsAllGrades((int)EvalPeriodID, userID, (int)YearID);
            }
            else if (SchoolID == null && GradeID != null && EvalPeriodID != null) //Get benchmarks for all schools, a specific grade and a specific benchmark month.
            {
                BenchmarkReports = repo.BenchmarkReportsAllSchoolsSpecificGrade(GradeLevelID, (int)EvalPeriodID, userID, (int)YearID);
                //BenchmarkReports = BenchmarkReportsModelDB.AllSchoolsSpecificGrade(GradeLevelID, (int)EvalPeriodID, userID, (int)YearID);
            }
            else if (GradeID == null && SchoolID != null && EvalPeriodID != null) //Get benchmarks for a specific school, all grades and a sepcific benchmark month.
            {
                BenchmarkReports = repo.BenchmarkReportsSpecificSchoolAllGrades((int)EvalPeriodID, (int)SchoolID, (int)YearID);
                //BenchmarkReports = BenchmarkReportsModelDB.SpecificSchoolAllGrades((int)EvalPeriodID, (int)SchoolID, (int)YearID);
            }
            else if (SchoolID != null && GradeID != null && EvalPeriodID != null) //Get benchmarks for a specific school, a specific grade, and a specific benchmark month.
            {
                BenchmarkReports = repo.BenchmarkReportsSpecificSchoolSpecificGradeYear((int)EvalPeriodID, (int)SchoolID, GradeLevelID, (int)YearID);
                //BenchmarkReports = BenchmarkReportsModelDB.SpecificSchoolSpecificGradeYear((int)EvalPeriodID, (int)SchoolID, GradeLevelID, (int)YearID);
            }
        }

        public void getNewBenchmark() //same cases as a above. (Zach, if you're reading this, these are the cases she originally asked for, sorry if she makes you add more cases.)
        {
            Repository repo = new Repository();

            if (EvalPeriodID == -1)
            {
                throw new Exception("Must have eval period");
            }
            if (SchoolID == -1 && GradeLevelID == -1)
            {
                //Working
                //BenchmarkReports = BenchmarkReportsModelDB.AllSchoolsAllGrades(EvalPeriodID, UserID, YearID);
                BenchmarkReports = repo.BenchmarkReportsSelectAllSchoolsAllGrades(EvalPeriodID, UserID, YearID);
            }
            else if (SchoolID == -1 && GradeLevelID != -1)
            {
                //BenchmarkReports = BenchmarkReportsModelDB.AllSchoolsSpecificGrade(GradeLevelID, EvalPeriodID, UserID, YearID);
                BenchmarkReports = repo.BenchmarkReportsAllSchoolsSpecificGrade(GradeLevelID, EvalPeriodID, UserID, YearID);
            }
            else if (GradeLevelID == -1 && SchoolID != -1)
            {
                BenchmarkReports = repo.BenchmarkReportsSpecificSchoolAllGrades((int)EvalPeriodID, (int)SchoolID, (int)YearID);
                //BenchmarkReports = BenchmarkReportsModelDB.SpecificSchoolAllGrades(EvalPeriodID, SchoolID, YearID);
            }
            else if (GradeLevelID != -1 && SchoolID != -1)
            {
                BenchmarkReports = repo.BenchmarkReportsSpecificSchoolSpecificGradeYear(EvalPeriodID, SchoolID, GradeLevelID, YearID);
                //BenchmarkReports = BenchmarkReportsModelDB.SpecificSchoolSpecificGradeYear(EvalPeriodID, SchoolID, GradeLevelID, YearID);
            }
        }

        public override void RefreshSchoolDropDown()
        {
            getNewBenchmark();
        }

        public override void RefreshGradeDropDown()
        {
            getNewBenchmark();
        }

        public override void RefreshEvalDropDown()
        {
            getNewBenchmark();
        }
    }
}