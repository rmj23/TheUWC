using Newtonsoft.Json;
using Source.Data;
using Source.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace Source.Controllers
{
    [Authorize]
    [SessionCheck]
    public class EvaluationController : Controller
    {
        protected RequestContext UseThisForSessions;

        // GET: Evaluation

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StudentPortfolio()
        {
            return View();
        }
        // ajax 
        // get year
        public ActionResult GetYear()
        {
            Repository repo = new Repository();

            var year = repo.SelectAllAcademicYearModels();

            return Json(year, JsonRequestBehavior.AllowGet);
        }

        // ajax
        // get class
        public ActionResult GetClasses(int YearID)
        {
            Repository repo = new Repository();

            int TeacherID = Convert.ToInt32(Session["TeacherID"]);
            var courses = repo.SelectAllByTeacherAndYear(TeacherID, YearID);

            return Json(courses, JsonRequestBehavior.AllowGet);
        }

        //ajax get students
        public ActionResult GetStudents(int CourseID)
        {
            Repository repo = new Repository();

            var students = repo.SelectAllByClass(CourseID);

            return Json(students, JsonRequestBehavior.AllowGet);
        }

        // ajax get paper type
        public ActionResult GetPaperType()
        {
            Repository repo = new Repository();

            var paperType = repo.PaperSelectAll();

            return Json(paperType, JsonRequestBehavior.AllowGet);
        }

        // ajax 
        // get eval months
        public ActionResult GetEvalMonths()
        {
            Repository repo = new Repository();

            var evalMonth = repo.EvaluationPeriodSelectAll();

            return Json(evalMonth, JsonRequestBehavior.AllowGet);
        }

        //ajax
        // get students with course id and month eval
        public ActionResult GetStudentsWithCourseAndMonth(int CourseID, int EvalMonth)
        {
            Repository repo = new Repository();

            var students = repo.PaperModelMonthCheck(CourseID, EvalMonth);

            return Json(new { data = students }, JsonRequestBehavior.AllowGet);
        }

        //ajax
        // get data for class data page
        [HttpGet]
        public ActionResult GetClassData(int CourseID, int EvalPeriod, int Year)
        {
            Repository repo = new Repository();

            var classData = repo.ClassDataSelectAllByClassID(CourseID, EvalPeriod, Year);

            return Json(classData, JsonRequestBehavior.AllowGet);
        }

        //ajax
        // get data for benchmark class chart
        public ActionResult GetChartDataBenchmark(int CourseID, int EvalPeriod, int YearID)
        {
            Repository repo = new Repository();

            var chartData = repo.BenchmarkReportsSpecificSchoolSpecificCourse(CourseID, EvalPeriod, YearID);

            // filter the data to counts
            var belowBasic = chartData.Where(x => x.ProficiencyID == 1).Count();
            var basic = chartData.Where(x => x.ProficiencyID == 2).Count();
            var proficient = chartData.Where(x => x.ProficiencyID == 3).Count();
            var advanced = chartData.Where(x => x.ProficiencyID == 4).Count();
            var advancedPlus = chartData.Where(x => x.ProficiencyID == 5).Count();

            var dataArray = new int[5] { belowBasic, basic, proficient, advanced, advancedPlus };

            return Json(dataArray, JsonRequestBehavior.AllowGet);
        }

        //ajax
        // get data for benchmark report
        public ActionResult GetBenchmarkData(int CourseID, int EvalPeriod, int YearID)
        {
            Repository repo = new Repository();

            var Data = repo.BenchmarkReportsSpecificSchoolSpecificCourse(CourseID, EvalPeriod, YearID);

            return Json(Data, JsonRequestBehavior.AllowGet);
        }

        // THIS GET JUST THE BENCHMARK MONTHS
        public ActionResult GetEvalPeriod()
        {
            Repository repo = new Repository();

            var evalPeriod = repo.EvaluationPeriodSelectAllBenchmark();

            return Json(evalPeriod, JsonRequestBehavior.AllowGet);
        }

        //public string ContinuumGrader(int PaperID)
        //{
        //    int paperTypeID, monthID, gradeID;
        //    PaperModel paper = PaperModelDb.SelectOne(PaperID);
        //    ClassModel course = ClassModelDb.SelectOneByID(paper.CourseID);
        //    paperTypeID = paper.PaperTypeID;
        //    monthID = paper.uploadDate.Month;
        //    gradeID = course.GradeID;
        //    //ContinuumGraderModel model = ContinuumGraderModelDb.GenerateContinuum(paperTypeID, monthID, gradeID);
        //    //return JsonConvert.SerializeObject(model);
        //}
        public ActionResult UploadPaper()
        {
            Repository repo = new Repository();

            UploadPaperViewModel model = new UploadPaperViewModel();
            model.teacherID = Convert.ToInt32(Session["TeacherID"]);

            // get paper type
            model.PaperTypeDropdown = repo.PaperSelectAll().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.paperType.ToString()
            }).ToList();

            model.PaperTypeDropdown.Insert(0, new SelectListItem()
            {
                Value = null,
                Text = "--- Select Paper Type ---"
            });

            // get evaluation periods
            model.EvaluationPeriodDropdown = repo.EvaluationPeriodSelectAll().Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.evalDescription.ToString()
            }).ToList();

            model.EvaluationPeriodDropdown.Insert(0, new SelectListItem()
            {
                Value = null,
                Text = "--- Select Evaluation Period ---"
            });

            

            return View(model);
        }

        [HttpPost]
        public ActionResult UploadPaper(UploadPaperViewModel model)
        {
            Repository repo = new Repository();

            if (model.File != null)
            {
                // converts file to bytes
                model.Paper.Paper = new byte[model.File.InputStream.Length];
                model.File.InputStream.Read(model.Paper.Paper, 0, model.Paper.Paper.Length);


                // assigns other needed data to upload
                model.Paper.FileName = Path.GetFileName(model.File.FileName);
                model.Paper.uploadDate = DateTime.Now;
            }
            else
            {
                // converts file to bytes
                model.Paper.Paper = null;
                //model.File.InputStream.Read(model.Paper.Paper, 0, model.Paper.Paper.Length);

                // assigns other needed data to upload
                model.Paper.FileName = model.Paper.PaperTitle;
                model.Paper.uploadDate = DateTime.Now;
            }

            // convert input data to the paper model
            model.Paper.paperTypeID = Convert.ToInt32(model.PaperTypeID);
            model.Paper.EvaluationPeriodID = Convert.ToInt32(model.EvaluationPeriodID);

            //Check to see if a paper has a benchmark with the same evalPeriod exists. Set the new paper to benchmark. Set old to that month.
            repo.PaperModelPaperBenckmarkPeriodCheck(model.Paper);
            repo.PaperModelPaperUpload(model.Paper);

            return RedirectToAction("ViewPapers", new { studentID = model.Paper.StudentID, model.Paper.CourseID, model.Paper.YearID });

        }

        [HttpPost]
        public ActionResult UploadPaperDataOnly(ViewPaperViewModel model)
        {
            Repository repo = new Repository();

            // converts file to bytes
            model.Paper.Paper = new byte[model.File.InputStream.Length];
            model.File.InputStream.Read(model.Paper.Paper, 0, model.Paper.Paper.Length);

            // assigns other needed data to upload
            //model.Paper.FileName = Path.GetFileNameWithoutExtension(model.File.FileName);
            model.Paper.FileName = Path.GetFileName(model.File.FileName);
            model.Paper.uploadDate = DateTime.Now;

            // use this later

            //    //Check to see if a paper has a benchmark with the same evalPeriod exists. Set the new paper to benchmark. Set old to that month.
            repo.PaperModelPaperBenckmarkPeriodCheck(model.Paper);
            repo.PaperModelPaperUploadDataOnly(model.Paper);


            string msg = "Paper Uploaded!!";
            //return new JsonResult(msg);
            //return Json(new { data = msg }, JsonRequestBehavior.AllowGet);
            return RedirectToAction("ViewPapers", new { studentID = model.Paper.StudentID, courseID = model.Paper.CourseID, yearID = model.Paper.YearID, msg });
        }

        public ActionResult ViewPapers(int studentID, int courseID, int yearID, string msg)
        {
            ViewBag.Message = msg;

            Repository repo = new Repository();

            ViewBag.Upload = true;
            ViewBag.Year = yearID;

            ViewPaperViewModel model = new ViewPaperViewModel();
            //model.StudentPaperHistory = repo.PaperHistoryModelSelectAllByStudent(studentID);
            model.AllPapers = repo.PaperModelSelectAllByStudentAndClass(studentID, courseID).OrderByDescending(x => x.PaperID).ToList();
            model.Student = repo.StudentModelSelectOne(studentID);
            model.CourseID = courseID;
            model.YearID = yearID;
            return View(model);
        }
        public ActionResult ViewPaperHistory(int studentID, int courseID, int yearID)
        {
            Repository repo = new Repository();
            ViewPaperViewModel model = new ViewPaperViewModel();

            model.StudentPaperHistory = repo.PaperHistoryModelSelectAllByStudent(studentID);
            model.Student = repo.StudentModelSelectOne(studentID);

            return View(model);

        }
        public ActionResult ViewResults(int PaperID)
        {
            Repository repo = new Repository();
            PaperResultsViewModel model = new PaperResultsViewModel();

            model.Reports = repo.PaperResultsModelSelectReport(PaperID);
            model.Paper = repo.PaperModelSelectOneByPaperID(PaperID);
            model.HolisticScore = model.Reports.FirstOrDefault().HolisticScoreLetter;
            model.StudentFeedback = model.Reports.FirstOrDefault().StudentFeedback;
            model.Comments = model.Reports.FirstOrDefault().Comments;
            model.EvaluationID = model.Reports.FirstOrDefault().EvaluationID;

            return View(model);
        }
        public ActionResult EditScore(int EvaluationScoreID, int PaperID, bool IsFinal)
        {
            Repository repo = new Repository();

            EditScoreViewModel model = new EditScoreViewModel(EvaluationScoreID, null);
            model.PaperID = PaperID;
            model.GradeID = repo.GradeModelSelectIDByPaper(PaperID);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditScore(EditScoreViewModel model)
        {
            Repository repo = new Repository();

            int CourseID = repo.PaperModelSelectOneByPaperID(model.PaperID).CourseID;
            repo.EvaluationScoreUpdate(model.Score, model.GradeID);
            //EvaluationScoreModelDb.Update(model.Score, model.GradeID);
            if (model.Score.ScoreTypeID == 7 || model.Score.ScoreTypeID == 8)
            {
                repo.EvaluationScoreUpdateConventionScore(model.Score);
                //EvaluationScoreModelDb.UpdateConventionScore(model.Score);
            }
            repo.EvaluationUpdateHolisticScore(model.Score.EvaluationID, CourseID);
            //EvaluationScoreModelDb.UpdateHolisticScore(model.Score.EvaluationID, CourseID);
            return RedirectToAction("ViewResults", "Evaluation", new { PaperID = model.PaperID });
        }
        public ActionResult EditEvaluationInfo(int EvaluationID, int PaperID)
        {
            EditScoreViewModel model = new EditScoreViewModel(null, EvaluationID);
            model.PaperID = PaperID;
            return View(model);
        }
        [HttpPost]
        public ActionResult EditEvaluationInfo(EditScoreViewModel model)
        {
            Repository repo = new Repository();

            repo.EvaluationScoreUpdateCommentsAndFeedback(model.Score);
            return RedirectToAction("ViewResults", "Evaluation", new { PaperID = model.PaperID });

        }
        public ActionResult ViewIndividualPaper(int id)
        {
            Repository repo = new Repository();
            string contentType = "";
            var docExtensions = new[] { ".docx", ".doc" };

            PaperModel model = repo.PaperModelViewSpecificPaper(id);

            var extension = Path.GetExtension(model.FileName).ToLower();

            // if file extension is a doc then set content type
            if (docExtensions.Contains(extension))
            {
                contentType = "application/msword";
            }
            // if file extension is a pdf then set content type
            else if (extension == ".pdf")
            {
                contentType = "application/pdf";
            }
            // if file is a powerpoint
            else if (extension == ".pptx")
            {
                contentType = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
                Response.ContentType = contentType;
            }
            else if (extension == ".jpeg" || extension == ".jpg")
            {
                contentType = "image/jpeg";
            }

            return File(model.Paper, contentType, model.FileName);
        }

        public ActionResult ViewIndividualStudentProgress(int id)
        {
            ViewIndividualStudentProgressViewModel model = new ViewIndividualStudentProgressViewModel(id);
            return View(model);
        }
        public ActionResult ClassData()
        {
            ViewClassDataViewModel model;
            model = new ViewClassDataViewModel(Convert.ToInt32(Session["TeacherID"]));
            //RefreshData(SessionModel.TeacherID(UseThisForSessions));

            return View(model);
        }
        [HttpPost]
        public void Submission(SubmissionModel model)
        {
            model.convertJson();
            SubmissionModelDb.Insert(model);
        }
        public ActionResult EvaluateProject(int? projectId, int? groupId)
        {
            EvaluateProjectViewModel model = new EvaluateProjectViewModel(projectId, groupId);
            return View(model);
        }
        [HttpPost]
        public ActionResult EvaluateProject(EvaluateProjectViewModel model)
        {
            Repository repo = new Repository();
            model.ScoreList = JsonConvert.DeserializeObject<List<ProjectScoreModel>>(model.ScoreStringList);
            model.ScoreList = ProjectScoreModelHelper.GetScoreInt(model.ScoreList);
            model.getStudents(model.Group.groupId);
            model.ProjectEvaluation.projectId = model.Project.projectId;
            ClassModel tmpClass = repo.ClassSelectOneByID(model.Project.courseId);
            int gradeId = tmpClass.GradeID;
            model.ProjectEvaluation.yearId = tmpClass.YearID;
            for (int i = 0; i < model.StudentsInGroup.Count; i++)
            {
                if (model.ProjectEvaluation.comments == null)
                {
                    model.ProjectEvaluation.comments = "";
                }
                if (model.ProjectEvaluation.feedback == null)
                {
                    model.ProjectEvaluation.feedback = "";
                }
                model.ProjectEvaluation.studentId = model.StudentsInGroup[i].StudentID;
                model.ProjectEvaluation.holisticScore = "";
                model.ProjectEvaluation.proficiencyId = 6; //Proficiency Id of 6 = Not assessed.
                ContinuumHelperModel.InquiryContinuumScore(model.ScoreList, model.ProjectEvaluation, DateTime.Today.Month, gradeId);
            }
            return RedirectToAction("ProjectResults", "Evaluation", new { groupId = model.Group.groupId });
        }

        public ActionResult ProjectResults(int groupId)
        {
            ProjectResultsGroupModel model = new ProjectResultsGroupModel(groupId);
            return View(model);
        }
        public ActionResult EvaluatePaper(int PaperID, int PaperTypeID, int ClassID, int StudentID)
        {
            Repository repo = new Repository();
            EvaluatePaperViewModel model = new EvaluatePaperViewModel();

            model.Continuum = ContinuumModelFunctions.BuildContinuum(PaperTypeID);
            model.Levels = repo.ContinuumLevelSelectAll();
            model.EvaluationTypes = repo.EvaluationSelectAllWithConventions();
            model.CourseID = ClassID;
            model.Paper_ID = PaperID;
            model.Scores = new List<int>();
            model.Conventions = new List<int>();
            model.Student = repo.StudentModelSelectOne(StudentID);
            model.StudentName = model.Student.FirstName + ' ' + model.Student.LastName;
            model.ClassInfo = repo.ClassSelectOneByID(ClassID);
            model.Paper = repo.PaperModelSelectOneByPaperID(PaperID);

            ViewBag.PaperID = PaperID;
            return View(model);
        }
        [HttpPost]
        public ActionResult EvaluatePaper(EvaluatePaperViewModel model)
        {
            //This is really inefficient. We take a string with scores that are delimited with commas.
            //Then convert it to a list of strings
            //Then convert it to a list of integers for Scores
            //In the ContinuumModel we use the integer value to pull a string value to be placed in the database.
            //This can be reworked at a later time so we are not makeing so many different conversions.
            List<string> StringList = model.StringScores.Split(',').ToList();
            List<string> ConventionStringList = new List<string>();
            ConventionStringList.Add(StringList[6]);
            ConventionStringList.Add(StringList[7]);
            StringList.RemoveAt(7);
            StringList.RemoveAt(6);
            StringList.RemoveAt(5);
            model.Scores = ContinuumModelFunctions.ScoreDictionaryConversion(StringList);
            model.Conventions = ContinuumModelFunctions.ScoreDictionaryConversion(ConventionStringList);
            ContinuumModelFunctions.Score(model);
            return RedirectToAction("ViewResults", "Evaluation", new { PaperID = model.Paper_ID });
        }
        public ActionResult Goals()
        {
            return View();
        }
        public ActionResult PaperDetails(int id)
        {
            Repository repo = new Repository();

            repo.InsertPoints(5, SessionModel.UserID(UseThisForSessions));
            PaperModel model = repo.PaperModelSelectOneByPaperID(id);
            return View(model);
        }
        public ActionResult DeletePaper(int paperID, int courseID, int studentID, int yearID)
        {
            Repository repo = new Repository();

            repo.PaperModelDelete(paperID);
            return RedirectToAction("ViewPapers", "Evaluation", new { courseID = courseID, studentID = studentID, yearID = yearID });
        }
        public ActionResult EvaluationProcess(int? CourseID, ACourseStudentYearSelectionListViewModel.CourseStudentYearSelectionListState? State, int? StudentID, int? YearID)
        {
            UploadPaperViewModel model = new UploadPaperViewModel();
            model.teacherID = Convert.ToInt32(Session["TeacherID"]);

            return View(model);
        }
        [HttpPost]
        public ActionResult EvaluationProcess(UploadPaperViewModel model)
        {
            Repository repo = new Repository();

            UploadPaperViewModel old = (UploadPaperViewModel)TempData["model"];
            //model.CourseID = old.CourseID;
            //model.StudentID = old.StudentID;
            model.BindViewModelElements();

            repo.PaperModelPaperUpload(model.Paper);
            return RedirectToAction("EvaluatePaper", new { id = model.Paper.PaperID, NP = "Review" });
        }

        public ActionResult EvaluationReview(int id)
        {
            EvaluationReviewViewModel model = new EvaluationReviewViewModel(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult EvaluationReview(EvaluationReviewViewModel model)
        {
            Repository repo = new Repository();

            //Update paper details
            repo.PaperModelUpdate(model.paper);
            return View(model);
        }
        public ActionResult ViewPortfolio()
        {
            return View();
        }

        public ActionResult MyClasses(AYearCourseSelection.YearCourseSelectionState? State, int? CourseID, int? YearID)
        {
            MyClassesViewModel model;
            if (TempData["model"] == null || (CourseID == null && State == null))
            {
                model = new MyClassesViewModel(SessionModel.TeacherID(UseThisForSessions), YearID, CourseID);
            }
            else
            {
                model = (MyClassesViewModel)TempData["model"];
                model.State = State ?? AYearCourseSelection.YearCourseSelectionState.Invalid;
                switch (model.State)
                {
                    case (AYearCourseSelection.YearCourseSelectionState.Invalid):
                        model.CourseID = -1;
                        model.YearID = YearID ?? -1;
                        model.RefreshCourseDropDown(SessionModel.TeacherID(UseThisForSessions));
                        break;
                    case (AYearCourseSelection.YearCourseSelectionState.YearSelected):
                        model.YearID = YearID ?? -1;
                        model.CourseID = CourseID ?? -1;
                        model.RefreshCourseDropDown(SessionModel.TeacherID(UseThisForSessions));
                        break;
                    case (AYearCourseSelection.YearCourseSelectionState.CourseSelected):
                        model.YearID = YearID ?? -1;
                        model.CourseID = CourseID ?? -1;
                        model.getStudents();
                        break;
                }

            }
            if (TempData.ContainsKey("model"))
                TempData.Remove("model");
            TempData.Add("model", model);
            Repository repo = new Repository();
            repo.InsertPoints(3, SessionModel.UserID(UseThisForSessions));
            return View(model);
        }
    }
}