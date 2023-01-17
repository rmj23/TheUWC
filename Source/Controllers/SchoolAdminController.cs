using Source.Data;
using Source.Models;
using System;
using System.Web.Mvc;

namespace Source.Controllers
{
    //[Authorize]
    public class SchoolAdminController : Controller
    {
        public ActionResult Dashboard()
        {
            Repository repo = new Repository();
            var quote = repo.QuoteModelSelectDailyQuotes();
            ViewBag.Quote = quote.Description;
            ViewBag.Author = quote.Author;
            return View();
        }

        public ActionResult DistrictRoster()
        {
            Repository repo = new Repository();
            UpdateRosterViewModel model = new UpdateRosterViewModel
            {
                AllStudentsInSchool = repo.StudentModelSelectAllBySchool(Convert.ToInt32(Session["SchoolID"]))
            };
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

            model.SchoolID = Convert.ToInt32(Session["SchoolID"]);
            model.DistrictID = Convert.ToInt32(Session["DistrictID"]);
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
                return RedirectToAction("DistrictRoster", "SchoolAdmin");
            }
            return View();
        }
        public ActionResult BenchmarkReports(AGradeEvaluationPeriodViewModel.GradeEvaluationPeriod? State, int? GradeLevelID, int? EvalPeriodID, int? CourseID, int? SchoolID, int? YearID)
        {
            ViewSchoolAdminBenchmarkReportsViewModel model;
            if (TempData["model"] == null || State == null)
            {
                model = new ViewSchoolAdminBenchmarkReportsViewModel(null, null, null, Convert.ToInt32(Session["SchoolID"]));
            }
            else
            {
                model = (ViewSchoolAdminBenchmarkReportsViewModel)TempData["model"];
                model.State = State ?? AGradeEvaluationPeriodViewModel.GradeEvaluationPeriod.Invalid;
                switch (model.State)
                {
                    case (AGradeEvaluationPeriodViewModel.GradeEvaluationPeriod.Invalid):
                        model.CourseID = 0;
                        break;
                    case (AGradeEvaluationPeriodViewModel.GradeEvaluationPeriod.YearSelected):
                        model.CourseID = 0;
                        model.EvalPeriodID = EvalPeriodID ?? -1;
                        model.YearID = YearID ?? -1;
                        model.GradeLevelID = GradeLevelID ?? -1;
                        model.getNewCourses();
                        model.getNewBenchmark();
                        break;
                    case (AGradeEvaluationPeriodViewModel.GradeEvaluationPeriod.EvalPeriodSelected):
                        model.CourseID = CourseID ?? 0;
                        model.YearID = YearID ?? -1;
                        model.EvalPeriodID = EvalPeriodID ?? -1;
                        model.GradeLevelID = GradeLevelID ?? -1;
                        if (model.CourseID == -1)
                        {
                            model.getAllBenchmark();
                        }
                        else
                        {
                            model.getNewBenchmark();
                        }

                        break;
                    case (AGradeEvaluationPeriodViewModel.GradeEvaluationPeriod.GradeLevelSelected):
                        model.CourseID = 0;
                        model.EvalPeriodID = EvalPeriodID ?? -1;
                        model.YearID = YearID ?? -1;
                        model.GradeLevelID = GradeLevelID ?? -1;
                        model.getNewCourses();
                        break;
                    case (AGradeEvaluationPeriodViewModel.GradeEvaluationPeriod.CourseSelected):
                        model.CourseID = CourseID ?? 0;
                        model.EvalPeriodID = EvalPeriodID ?? -1;
                        model.YearID = YearID ?? -1;
                        model.GradeLevelID = GradeLevelID ?? -1;
                        if (model.CourseID == -1)
                        {
                            model.getAllBenchmark();
                        }
                        else
                        {
                            model.getNewBenchmark();
                        }
                        break;
                }
            }
            if (TempData.ContainsKey("model"))
                TempData.Remove("model");
            TempData.Add("model", model);
            return View(model);

        }
        public ActionResult YearlyBenchmarkReports(AYearGradeCourseEvaluationViewModel.YearGradeCoursePeriod? State, int? YearID, int? GradeLevelID, int? CourseID)
        {
            SchoolAdminYearlyBenchmarkReportsViewModel model;
            if (TempData["model"] == null || TempData["model"].GetType() != typeof(SchoolAdminYearlyBenchmarkReportsViewModel))
            {
                model = new SchoolAdminYearlyBenchmarkReportsViewModel(Convert.ToInt32(Session["SchoolID"]));
            }
            else
            {
                model = (SchoolAdminYearlyBenchmarkReportsViewModel)TempData["model"];
                model.State = State ?? AYearGradeCourseEvaluationViewModel.YearGradeCoursePeriod.Invalid;
                switch (model.State)
                {
                    case (AYearGradeCourseEvaluationViewModel.YearGradeCoursePeriod.Invalid):
                        model.CourseID = 0;
                        break;
                    case (AYearGradeCourseEvaluationViewModel.YearGradeCoursePeriod.YearSelected):
                        model.YearID = YearID ?? 0;
                        model.GradeLevelID = GradeLevelID ?? 0;
                        model.ResetCourseDropDown();
                        model.CourseID = 0;
                        break;
                    case (AYearGradeCourseEvaluationViewModel.YearGradeCoursePeriod.GradeLevelSelected):
                        model.YearID = YearID ?? 0;
                        model.GradeLevelID = GradeLevelID ?? 0;
                        model.CourseID = 0;
                        model.GetCourseDropDown();
                        break;
                    case (AYearGradeCourseEvaluationViewModel.YearGradeCoursePeriod.CourseSelected):
                        model.YearID = YearID ?? 0;
                        model.GradeLevelID = GradeLevelID ?? 0;
                        model.CourseID = CourseID ?? 0;
                        if (model.CourseID == -1)
                        {
                            model.GetAllBenchmarks();
                        }
                        else
                        {
                            model.GetBenchmarks();
                        }
                        break;
                }
            }
            if (TempData.ContainsKey("model"))
                TempData.Remove("model");
            TempData.Add("model", model);
            return View(model);
        }
        [HttpGet]
        public ActionResult CourseSemester()
        {
            CourseSemesterViewModel model = new CourseSemesterViewModel(Convert.ToInt32(Session["SchoolID"]));
            ViewBag.Show = false;
            return View(model);
        }
        [HttpPost]
        public ActionResult CourseSemester(CourseSemesterViewModel model)
        {
            Repository repo = new Repository();

            model.SchoolID = Convert.ToInt32(Session["SchoolID"]);
            repo.CourseSemseterInsert(model);
            return RedirectToAction("CourseSemester");
        }
        public ActionResult UsageReports(ASchoolEvalSelectionViewModel.SchoolEvalSelectionState? State, int? UserID, int? SchoolID, int? EvalPeriodID)
        {
            TeacherUsageReportViewModel model;
            SchoolID = Convert.ToInt32(Session["SchoolID"]);
            if (TempData["model"] == null || State == null)
            {
                model = new TeacherUsageReportViewModel(Convert.ToInt32(Session["UserID"]), null, Convert.ToInt32(Session["DistrictID"]), SchoolID);
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
                    case (ASchoolEvalSelectionViewModel.SchoolEvalSelectionState.EvalPeriodSelected):
                        model.EvalPeriodID = EvalPeriodID ?? -1;
                        model.SchoolID = SchoolID ?? -1;
                        model.getTeachers(Convert.ToInt32(Session["UserID"]), (int)SchoolID);
                        break;
                }

            }
            if (TempData.ContainsKey("model"))
                TempData.Remove("model");
            TempData.Add("model", model);
            return View(model);
        }
        [HttpPost]
        public JsonResult DeleteMidtermDate(int ID)
        {
            Repository repo = new Repository();
            var result = new object();
            try
            {
                repo.DeleteMidtermDate(ID);
                result = new { Success = true, ErrorMessage = "" };
            }
            catch (Exception ex)
            {
                result = new { Success = false, ErrorMessage = ex.ToString() };
            }
            return Json(result);

        }
        public ActionResult EditMidtermDates(int ID, int SubjectID, int SemesterID, DateTime MidtermDate)
        {
            CourseSemesterViewModel vm = new CourseSemesterViewModel();
            CourseSemesterModel model = new CourseSemesterModel()
            {
                ID = ID,
                SubjectID = SubjectID,
                MidtermDate = MidtermDate,
                SemesterID = SemesterID
            };
            vm.CourseSemesterModel = model;
            return View(vm);
        }
        //TODO: Handle post for EditMidtermDates
        [HttpPost]
        public ActionResult EditMidtermDates(CourseSemesterViewModel model)
        {
            Repository repo = new Repository();
            repo.CourseSemesterUpdate(model.CourseSemesterModel);
            return RedirectToAction("CourseSemester");

        }
    }
}