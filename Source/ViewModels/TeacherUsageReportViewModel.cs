using Source.Data;
using System;
using System.Collections.Generic;

namespace Source.Models
{
    public class TeacherUsageReportViewModel : ASchoolEvalSelectionViewModel
    {

        public List<TeacherUsageReportModel> TeacherUsageReports { get; set; }
        public TeacherUsageReportViewModel(int userID, int? evalPeriodID, int districtID, int? schoolID)
        {
            Repository repo = new Repository();

            EvaluationPeriodDropDown = EvaluationPeriodModelControls.GetSelectListItems(repo.EvaluationPeriodSelectAll());
            SchoolDropDown = SchoolModelControls.GetSelectListItems(repo.SchoolModelSelectAllByDistrict(districtID));
            TeacherUsageReports = repo.TeacherUsageReportModelGetReports(EvalPeriodID, userID, SchoolID);

        }

        public override void RefreshEvaluationPeriodDropDown()
        {
            throw new NotImplementedException();
        }

        public void getTeachers(int userID, int SchoolID)
        {
            Repository repo = new Repository();

            TeacherUsageReports = repo.TeacherUsageReportModelGetReports(EvalPeriodID, userID, SchoolID);
        }
    }
}