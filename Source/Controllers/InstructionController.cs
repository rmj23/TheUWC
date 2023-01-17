using Source.Data;
using Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace Source.Controllers
{
    [Authorize]
    [SessionCheck]
    public class InstructionController : Controller
    {

#pragma warning disable CS0649 // Field 'InstructionController.UseThisForSessions' is never assigned to, and will always have its default value null
        private RequestContext UseThisForSessions;
#pragma warning restore CS0649 // Field 'InstructionController.UseThisForSessions' is never assigned to, and will always have its default value null

        // ajax
        // get courses
        public ActionResult GetClasses()
        {
            Repository repo = new Repository();

            int Teacherid = Convert.ToInt32(Session["TeacherID"]);

            var year = repo.SelectCurrentYearID();
            var courses = repo.SelectAllByTeacherAndYear(Teacherid, year);

            return Json(courses, JsonRequestBehavior.AllowGet);
        }

        // ajax
        // get class goals
        public ActionResult GetClassGoals(int CourseID)
        {
            Repository repo = new Repository();

            int Teacherid = Convert.ToInt32(Session["TeacherID"]);
            var goals = repo.GoalsSelectByClass(Teacherid, CourseID);

            return Json(new { data = goals }, JsonRequestBehavior.AllowGet);
        }

        //ajax 
        //get student goals
        public ActionResult GetStudentGoals(int StudentID)
        {
            Repository repo = new Repository();

            var studentGoals = repo.GoalsSelectByStudent(StudentID);

            return Json(new { data = studentGoals }, JsonRequestBehavior.AllowGet);
        }

        //ajax
        // get student conference notes
        public ActionResult GetStudentConferenceNotes(int CourseID, int StudentID)
        {
            Repository repo = new Repository();

            var studentNotes = repo.ConferenceNotesSelectNotesByCourseAndStudent(CourseID, StudentID);

            return Json(new { data = studentNotes }, JsonRequestBehavior.AllowGet);
        }

        //AJAX 
        // GET CONTINUUM
        public ActionResult getContinuum(int CourseID, int EvalID, int PaperTypeID)
        {
            Repository repo = new Repository();

            int month = DateTime.Now.Month;
            int gradeId = repo.ClassSelectOneByID(CourseID).GradeID;
            int level = repo.GetLevelByMonthAndGrade(month, gradeId);

            var Continuum = repo.SelectGuidlineByLevelAndType(level, EvalID, PaperTypeID);

            return Json(Continuum, JsonRequestBehavior.AllowGet);
        }

        // GET PAPER TYPES
        public ActionResult getPaperTypes()
        {
            Repository repo = new Repository();

            var paperTypes = repo.PaperSelectAll();

            return Json(paperTypes, JsonRequestBehavior.AllowGet);
        }

        // GET WRITING ELEMENTS
        public ActionResult getWritingElements()
        {
            Repository repo = new Repository();

            var writingElements = repo.EvaluationSelectAllWithoutConventions();

            return Json(writingElements, JsonRequestBehavior.AllowGet);
        }
        // GET: Instruction
        public ActionResult Index()
        {
            return View();
        }

        // GET: Engagements
        public ActionResult Engagements()
        {
            return View();
        }

        // ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // CONFERENCE NOTES
        //GET: ConferenceNotes
        public ActionResult ConferenceNotes(string msg)
        {
            ViewBag.Messsage = msg;
            return View();
        }
        //GET: Insert Conference Notes
        [HttpGet]
        public ActionResult InsertConferenceNotes(int YearID, int CourseID, int StudentID)
        {
            Repository repo = new Repository();
            InsertConferenceNotesViewModel model = new InsertConferenceNotesViewModel();

            model.ConferenceNotes = new ConferenceNotesModel();
            var Student = repo.StudentModelSelectOne(StudentID);
            model.StudentName = Student.FirstName + ' ' + Student.LastName;
            model.ConferenceTypeDescription = ConferenceNotesModelControls.GetSelectListItemsDescription(repo.ConferenceNotesTypeDescriptionSelectAll());
            model.StageOrDraft = ConferenceNotesModelControls.GetSelectListItemsStageOrDraft(repo.ConferenceNotesStageOrDraftSelectAll());
            model.ConferenceNotes.StudentID = StudentID;
            model.ConferenceNotes.CourseID = CourseID;
            model.ReturnDate = DateTime.Now;

            return View(model);
        }

        //POST: Insert Conference Notes
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertConferenceNotes(InsertConferenceNotesViewModel model)
        {
            Repository repo = new Repository();

            if (ModelState.IsValid)
            {
                ModelState.Clear();
                if (model.ConferenceNotes.Comments == null) { model.ConferenceNotes.Comments = "Not Provided"; }
                repo.ConferenceNotesInsertNotes(model);
                //repo.InsertPoints(1, SessionModel.UserID(UseThisForSessions));
                var msg = "Conference Note Added!";
                return RedirectToAction("ConferenceNotes", new { msg });
            }
            else
            {
                return View(model);
            }
        }
        //Delete Conference Note
        public ActionResult DeleteConferenceNotes(int conID, int yearID, int courseID, int studentID)
        {
            Repository repo = new Repository();

            repo.ConferenceNotesDeleteNotes(conID);
            return RedirectToAction("ConferenceNotes", "Instruction", new { State = ACourseStudentYearSelectionListViewModel.CourseStudentYearSelectionListState.StudentSelected, yearID, courseID, studentID });

        }
        //GET: Edit Conference Nots
        [HttpGet]
        public ActionResult EditConferenceNotes(int conID, int yearID)
        {
            Repository repo = new Repository();

            ConferenceNotesModel model = repo.ConferenceNotesSelectNoteByID(conID);
            EditConferenceNotesViewModel editModel = new EditConferenceNotesViewModel(model, yearID);
            return View(editModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditConferenceNotes(EditConferenceNotesViewModel model)
        {
            Repository repo = new Repository();

            repo.ConferenceNotesEditNotes(model.ConferenceNotes);
            return RedirectToAction("ConferenceNotes", "Instruction", new { State = ACourseStudentYearSelectionListViewModel.CourseStudentYearSelectionListState.StudentSelected, model.YearID, model.ConferenceNotes.CourseID, model.ConferenceNotes.StudentID });
        }

        // Print Conference Notes
        public ActionResult PrintConferenceNotes(int courseID, int studentID)
        {
            Repository repo = new Repository();

            List<ConferenceNotesModel> ListOfConferenceNotes;
            ListOfConferenceNotes = repo.ConferenceNotesSelectNotesByCourseAndStudent(courseID, studentID);
            return View(ListOfConferenceNotes);
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // STUDENT GOALS

        //GET: View Student Goals
        //USES DAPPER
        public ActionResult ViewStudentGoals()
        {
            StudentGoalsViewModel model = new StudentGoalsViewModel();

            return View(model);
        }

        //GET: Insert Student Goals
        [HttpGet]
        public ActionResult InsertStudentGoals(APaperResultsSelection.PaperResultSelection? State, int? PaperID, int? CourseID, int? StudentID, int? YearID)
        {
            InsertStudentGoalsViewModel model;
            if (TempData["model"] == null)
            {
                model = new InsertStudentGoalsViewModel((int)YearID, (int)CourseID, (int)StudentID);
            }
            else
            {
                model = new InsertStudentGoalsViewModel((int)YearID, (int)CourseID, (int)StudentID);
                model.State = State ?? APaperResultsSelection.PaperResultSelection.Invalid;
                switch (model.State)
                {
                    case (APaperResultsSelection.PaperResultSelection.Invalid):
                        model.PaperID = -1;
                        break;
                    case (APaperResultsSelection.PaperResultSelection.PaperSelected):
                        model.PaperID = PaperID ?? -1;
                        if (model.PaperID == 0) { model.PaperID = -1; }
                        model.Goal.DateAdded = DateTime.Now;
                        model.RefreshReports((int)PaperID);
                        model.RefreshPaper((int)PaperID);
                        break;
                }
            }
            if (TempData.ContainsKey("model"))
                TempData.Remove("model");
            TempData.Add("model", model);
            return View(model);
        }
        //POST: Insert Student Goals
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertStudentGoals(InsertStudentGoalsViewModel model)
        {
            Repository repo = new Repository();

            if (ModelState.IsValid)
            {
                ModelState.Clear();
                model.Goal.UserID = SessionModel.UserID(UseThisForSessions);
                model.Goal.GoalPaperID = model.PaperID;
                model.Goal.GoalPaperTitle = repo.PaperModelSelectOneByPaperID(model.PaperID).PaperTitle;
                string pdt = model.Goal.DeadlineDate.ToString() + model.deadlineTime;
                model.Goal.DeadlineDate = Convert.ToDateTime(pdt);
                repo.StudentGoalsModelInsertIndividualStudentGoal(model.Goal, model.StudentID, model.CourseID);
                repo.InsertPoints(1, SessionModel.UserID(UseThisForSessions));
                return RedirectToAction("ViewStudentGoals", new RouteValueDictionary(new { @State = Source.Models.ACourseStudentYearSelectionListViewModel.CourseStudentYearSelectionListState.StudentSelected, @YearID = model.YearID, @CourseID = model.CourseID, @StudentID = model.StudentID }));
            }
            else
            {
                model.GetPaperDropDown();
                model.GetScoreTypes();
                model.RefreshReports(model.PaperID);
                model.Goal.DeadlineDate = null;
                return View("InsertStudentGoals", model);
            }
        }

        //Mark Student Goals as Completed
        public ActionResult CompleteStudentGoal(int goalID, int yearID, int courseID, int studentID)
        {
            Repository repo = new Repository();

            DateTime dateNow = DateTime.Now;
            repo.StudentGoalsModelMarkGoalCompleted(goalID, dateNow);
            return RedirectToAction("ViewStudentGoals", "Instruction", new { State = ACourseStudentYearSelectionListViewModel.CourseStudentYearSelectionListState.StudentSelected, yearID, courseID, studentID });
        }
        //Delete Student Goal
        public ActionResult DeleteStudentGoal(int goalID, int yearID, int courseID, int studentID)
        {
            Repository repo = new Repository();

            repo.StudentGoalsModelDeleteGoal(goalID);
            return RedirectToAction("ViewStudentGoals", "Instruction", new { State = ACourseStudentYearSelectionListViewModel.CourseStudentYearSelectionListState.StudentSelected, yearID, courseID, studentID });

        }
        //GET: Edit Student Goal
        [HttpGet]
        public ActionResult EditStudentGoals(int goalID, int yearID, int courseID)
        {
            EditStudentGoalsViewModel editModel = new EditStudentGoalsViewModel(goalID, yearID, courseID);
            return View(editModel);
        }
        //POST: Edit Student Goal
        //Will only update description (model has nulls)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditStudentGoals(EditStudentGoalsViewModel model)
        {
            Repository repo = new Repository();

            repo.StudentGoalsModelUpdateGoal(model.StudentGoals);
            return RedirectToAction("ViewStudentGoals", "Instruction", new { State = ACourseStudentYearSelectionListViewModel.CourseStudentYearSelectionListState.StudentSelected, model.YearID, model.CourseID, model.StudentGoals.StudentID });
        }

        // Print Student Goals
        public ActionResult PrintStudentGoals(int studentID, int courseID)
        {
            Repository repo = new Repository();

            List<StudentGoalsModel> ListOfStudentGoals;

            ListOfStudentGoals = repo.StudentGoalsModelSelectByCourse(studentID, courseID);

            if (ListOfStudentGoals.Count == 0)
            {
                return Redirect("~/Shared/Error");
            }
            else
            {
                return View(ListOfStudentGoals);
            }

        }

        // ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // CLASS GOALS

        //GET: View Class Goals
        // USES DAPPER
        public ActionResult ViewClassGoals()
        {
            ViewClassGoalsViewModel model = new ViewClassGoalsViewModel(Convert.ToInt32(Session["TeacherID"]));

            return View(model);

        }
        //GET: Insert Class Goals
        [HttpGet]
        public ActionResult InsertClassGoals()
        {
            Repository repo = new Repository();
            InsertClassGoalsViewModel model = new InsertClassGoalsViewModel();
            var teacherID = Convert.ToInt32(Session["TeacherID"]);

            //model.CourseDropDown = ClassModelControls.GetSelectListItems(repo.SelectAllByTeacher(teacherID), true);
            //model.PaperTypeDropDown = PaperTypeModelControls.GetSelectListItems(repo.PaperSelectAll());
            //model.EvaluationTypeDropDown = EvaluationTypeControls.GetSelectListItems(repo.EvaluationSelectAllWithoutConventions());
            model.deadlineTime = " 00:00:00.00";

            ViewBag.CurrentYear = repo.SelectAllAcademicYearModels().Where(x => x.IsCurrent).FirstOrDefault().ID;

            return View(model);

        }
        //POST: Insert Class Goals
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertClassGoal(InsertClassGoalsViewModel NewGoal)
        {
            int teacherID = Convert.ToInt32(Session["TeacherID"]);
            Repository repo = new Repository();

            NewGoal.Goal.DateAdded = DateTime.Now;
            string pdt = NewGoal.Goal.DeadlineDate.ToString() + NewGoal.deadlineTime;
            NewGoal.Goal.DeadlineDate = Convert.ToDateTime(pdt);
            NewGoal.Goal.CourseID = NewGoal.CourseID;
            NewGoal.Goal.ShortDescription = NewGoal.EvalTitleTemp;
            if (ModelState.IsValid)
            {
                //repo.InsertPoints(7, SessionModel.UserID(UseThisForSessions));
                NewGoal.Goal.TeacherID = teacherID;
                if (NewGoal.Goal != null)
                {
                    repo.ClassGoalsInsertClassGoals(NewGoal.Goal, teacherID, NewGoal.CourseID);
                    //TempData.Remove("model");
                    return RedirectToAction("ViewClassGoals", "Instruction");

                }
                else
                {
                    return View(NewGoal);
                }
            }
            else
            {
                //NewGoal.GetCourse(SessionModel.TeacherID(UseThisForSessions));
                //NewGoal.GetPaperTypeID();
                //NewGoal.GetScoreTypes();
                return View("InsertClassGoals", NewGoal);
            }

        }
        //Mark Class Goal Complete
        public ActionResult CompleteClassGoal(int goalID, int courseID)
        {
            Repository repo = new Repository();

            DateTime dateNow = DateTime.Now;
            repo.ClassGoalMarkCompleted(goalID, dateNow);
            //ClassGoalsModelDb.MarkCompleted(goalID, dateNow);
            return RedirectToAction("ViewClassGoals", "Instruction", new { CourseID = courseID, State = ACourseSelectionViewModel.CourseSelectionState.CourseSelected });
        }
        //Delete Class Goal
        public ActionResult DeleteClassGoal(int goalID, int courseID)
        {
            Repository repo = new Repository();

            repo.ClassGoalDeleteClassGoal(goalID);
            //ClassGoalsModelDb.DeleteClassGoal(goalID);
            return RedirectToAction("ViewClassGoals", "Instruction", new { CourseID = courseID, State = ACourseSelectionViewModel.CourseSelectionState.CourseSelected });

        }
        //NOT DONE
        //GET: Edit Class Goal
        [HttpGet]
        public ActionResult EditClassGoals(int goalID, int courseID)
        {
            EditClassGoalsViewModel model = new EditClassGoalsViewModel(goalID, courseID);
            return View(model);
        }
        //NOT DONE
        //POST: Edit Class Goal
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditClassGoals(EditClassGoalsViewModel model)
        {
            Repository repo = new Repository();

            repo.ClassGoalUpdateClassGoal(model.ClassGoals);
            //ClassGoalsModelDb.UpdateClassGoal(model.ClassGoals);
            return RedirectToAction("ViewClassGoals", "Instruction", new { CourseID = model.ClassGoals.CourseID, State = ACourseSelectionViewModel.CourseSelectionState.CourseSelected });
        }

        //Print Class Goals
        public ActionResult PrintClassGoals(int courseID)
        {
            Repository repo = new Repository();

            List<ClassGoalsModel> ListOfClassGoals;
            ListOfClassGoals = repo.ClassGoalSelectByCourseID(courseID);
            //ListOfClassGoals = ClassGoalsModelDb.ClassGoalsSelectByCourseID(courseID);
            return View(ListOfClassGoals);
        }

        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Engagements

        //Engagements
        public ActionResult ViewEngagement()
        {
            Repository repo = new Repository();

            List<EngagementModel> model = new List<EngagementModel>();
            model = repo.EngagementSelectAll();

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ViewEngagement(EngagementsViewModel model)
        {
            Repository repo = new Repository();

            if (model.GradeLevelRangeID == 0)
            {
                model.GradeLevelRange = GradeLevelModelControls.GetSelectListItems(repo.GradeLevelModelSelectAll());
                model.Engagements = repo.EngagementSelectByGradeLevelRange(1);
                //model.Engagements = EngagementModelDB.SelectByGradeLevelRange(1);
            }
            else if (model.GradeLevelRangeID == 4)
            {
                model.GradeLevelRange = GradeLevelModelControls.GetSelectListItems(repo.GradeLevelModelSelectAll());
                model.Engagements = repo.EngagementSelectAll();
            }
            else
            {
                model.GradeLevelRange = GradeLevelModelControls.GetSelectListItems(repo.GradeLevelModelSelectAll());
                model.Engagements = repo.EngagementSelectByGradeLevelRange(model.GradeLevelRangeID);
                //model.Engagements = EngagementModelDB.SelectByGradeLevelRange(model.GradeLevelRangeID);

            }

            return View(model);
        }
        public ActionResult ViewIndividualEngagement(int ID)
        {
            EngagementsViewModel model = new EngagementsViewModel(ID);
            return View(model);
        }
        //Mentor Text
        public ActionResult InteractiveMentorTexts()
        {
            return View();
        }
    }
}