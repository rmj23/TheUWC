using Source.Data;
using Source.Models;
using System.Web.Mvc;
using System.Web.Routing;

namespace Source.Controllers
{
    [Authorize]
    public class DistrictAdminController : Controller
    {
        private RequestContext UseThisForSessions;
        protected override void Initialize(RequestContext requestContext)
        {
            SessionModel.UserIsDistrictAdmin(requestContext);
            UseThisForSessions = requestContext;
            base.Initialize(requestContext);
        }
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult UsageReports(ASchoolEvalSelectionViewModel.SchoolEvalSelectionState? State, int? UserID, int? SchoolID, int? EvalPeriodID)
        {
            TeacherUsageReportViewModel model;
            if (TempData["model"] == null || State == null)
            {
                model = new TeacherUsageReportViewModel(SessionModel.UserID(UseThisForSessions), null, SessionModel.DistrictID(UseThisForSessions), SchoolID);
            }
            else
            {
                model = (TeacherUsageReportViewModel)TempData["model"];
                if (SchoolID == 0)
                    SchoolID = null;
                if (EvalPeriodID == 0)
                    EvalPeriodID = null;
                if (model == null)
                {
                    return RedirectToAction("Error", "Shared");
                }
                model.State = State ?? ASchoolEvalSelectionViewModel.SchoolEvalSelectionState.Invalid;
                switch (model.State)
                {
                    case (ASchoolEvalSelectionViewModel.SchoolEvalSelectionState.Invalid):
                        model.EvalPeriodID = -1;
                        model.SchoolID = -1;
                        break;

                    case (ASchoolEvalSelectionViewModel.SchoolEvalSelectionState.SchoolSelected):
                        model.EvalPeriodID = EvalPeriodID ?? -1;
                        model.SchoolID = SchoolID ?? -1;
                        model.getTeachers(SessionModel.UserID(UseThisForSessions), (int)SchoolID);
                        break;

                    case (ASchoolEvalSelectionViewModel.SchoolEvalSelectionState.EvalPeriodSelected):
                        model.EvalPeriodID = EvalPeriodID ?? -1;
                        model.SchoolID = SchoolID ?? -1;
                        model.getTeachers(SessionModel.UserID(UseThisForSessions), (int)SchoolID);
                        break;

                }

            }
            if (TempData.ContainsKey("model"))
                TempData.Remove("model");
            TempData.Add("model", model);
            return View(model);
        }

        public ActionResult BenchmarkReports(ASchoolGradeEvaluationPeriod.UseForDistrictAdminBenchmark? State, int? SchoolID, int? GradeLevelID, int? EvalPeriodID, int? YearID)
        {
            ViewDistrictBenchmarkReportsViewModel model;
            if (TempData["model"] == null || State == null)
            {
                model = new ViewDistrictBenchmarkReportsViewModel(null, null, null, SessionModel.UserID(UseThisForSessions), SessionModel.DistrictID(UseThisForSessions), null);
            }
            else
            {
                model = (ViewDistrictBenchmarkReportsViewModel)TempData["model"];
                if (SchoolID == 0)
                    SchoolID = null;
                if (EvalPeriodID == 0)
                    EvalPeriodID = null;
                if (GradeLevelID == 0 || GradeLevelID == -1)
                    GradeLevelID = null;
                if (model == null)
                {
                    return RedirectToAction("Error", "Shared");
                }
                model.State = State ?? ASchoolGradeEvaluationPeriod.UseForDistrictAdminBenchmark.Invalid;
                switch (model.State)
                {
                    case (ASchoolGradeEvaluationPeriod.UseForDistrictAdminBenchmark.Invalid):
                        model.GradeLevelID = -1;
                        model.SchoolID = -1;
                        model.EvalPeriodID = -1;
                        model.YearID = -1;
                        break;
                    case (ASchoolGradeEvaluationPeriod.UseForDistrictAdminBenchmark.YearSelected):
                        model.YearID = YearID ?? -1;
                        model.GradeLevelID = GradeLevelID ?? -1;
                        model.SchoolID = SchoolID ?? -1;
                        model.EvalPeriodID = EvalPeriodID ?? -1;
                        model.getNewBenchmark();
                        break;
                    case (ASchoolGradeEvaluationPeriod.UseForDistrictAdminBenchmark.EvalPeriodSelected):
                        model.YearID = YearID ?? -1;
                        model.GradeLevelID = GradeLevelID ?? -1;
                        model.SchoolID = SchoolID ?? -1;
                        model.EvalPeriodID = EvalPeriodID ?? -1;
                        model.getNewBenchmark();
                        break;
                    case (ASchoolGradeEvaluationPeriod.UseForDistrictAdminBenchmark.GradeLevelSelected):
                        model.YearID = YearID ?? -1;
                        model.GradeLevelID = GradeLevelID ?? -1;
                        model.SchoolID = SchoolID ?? -1;
                        model.EvalPeriodID = EvalPeriodID ?? -1;
                        model.getNewBenchmark();
                        break;
                    case (ASchoolGradeEvaluationPeriod.UseForDistrictAdminBenchmark.SchoolSelected):
                        model.YearID = YearID ?? -1;
                        model.GradeLevelID = GradeLevelID ?? -1;
                        model.SchoolID = SchoolID ?? -1;
                        model.EvalPeriodID = EvalPeriodID ?? -1;
                        model.getNewBenchmark();
                        break;
                }
            }
            if (TempData.ContainsKey("model"))
                TempData.Remove("model");
            TempData.Add("model", model);
            return View(model);
        }
        public ActionResult DistrictRoster()
        {
            //UpdateRosterViewModel model = new UpdateRosterViewModel(SessionModel.DistrictID(UseThisForSessions));
            UpdateRosterViewModel model = new UpdateRosterViewModel();
            return View(model);
        }
        public ActionResult EditStudentDistrict(int studentID)
        {
            EditStudentViewModel model = new EditStudentViewModel(studentID);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditStudentDistrict(EditStudentViewModel model)
        {
            Repository repo = new Repository();

            repo.StudentModelUpdateInfo(model.Student);

            return RedirectToAction("DistrictRoster");
        }
        [HttpPost]
        public ActionResult DeleteStudent(int StudentID)
        {
            Repository repo = new Repository();

            repo.StudentModelDeleteByStudentID(StudentID);
            return RedirectToAction("DistrictRoster");
        }
        public ActionResult AddStudent()
        {
            StudentModel model = new StudentModel();
            //if (!ModelState.IsValid)
            //{
            //    return View("AddStudent",model);
            //}

            //model.SchoolID = SessionModel.SchoolID(UseThisForSessions);
            model.DistrictID = SessionModel.DistrictID(UseThisForSessions);
            return View(model);

        }
        [HttpPost]
        public ActionResult AddStudent(StudentModel model)
        {
            Repository repo = new Repository();

            if (ModelState.IsValid)
            {
                model.RoleID = 2;
                repo.StudentModelInsert(model);
                return RedirectToAction("DistrictRoster");
            }
            return View();
        }
    }
}