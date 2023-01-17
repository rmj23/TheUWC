using Source.Data;
using Source.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace Source.Controllers
{
    [Authorize]
    [SessionCheck]
    public class StudentController : Controller
    {

        //private RequestContext UseThisForSessions;
        //protected override void Initialize(RequestContext requestContext)
        //{
        //    SessionModel.UserIsStudent(requestContext);
        //    UseThisForSessions = requestContext;
        //    base.Initialize(requestContext);
        //}
        // GET: Dashboard
        public ActionResult Dashboard()
        {
            Repository repo = new Repository();
            var quote = repo.QuoteModelSelectDailyQuotes();
            ViewBag.Quote = quote.Description;
            ViewBag.QuoteAuthor = quote.Author;
            return View();
        }

        public ActionResult Glossary(string id)
        {
            Repository repo = new Repository();

            List<GlossaryModel> model;
            if (String.IsNullOrEmpty(id))
            {
                model = repo.GlossaryModelSelectAll();
                //model = GlossaryModelDb.SelectAll();
            }
            else
            {
                model = repo.GlossaryModelSelectByLetter(id.ToCharArray()[0]);
                //model = GlossaryModelDb.SelectByLetter(id.ToCharArray()[0]);
            }
            return View(model);
        }

        public ActionResult GraphicOrganizers()
        {
            return View();
        }
        public ActionResult StudentChecklist()
        {
            return View();
        }

        public ActionResult StudentPortfolio()
        {
            Repository repo = new Repository();
            MyStudentPortfolioViewModel model = new MyStudentPortfolioViewModel();

            model.AllPapers = repo.PaperModelSelectAllByStudent(Convert.ToInt32(Session["StudentID"]));

            return View(model);
        }

        public ActionResult MyFeedback()
        {
            Repository repo = new Repository();
            MyFeedbackViewModel model = new MyFeedbackViewModel();

            model.StudentFeedback = repo.PaperResultsModelSelectAllStudentFeedback(Convert.ToInt32(Session["StudentID"]));

            return View(model);
        }
        public ActionResult MyResults(int paperID)
        {
            Repository repo = new Repository();
            PaperResultsViewModel model = new PaperResultsViewModel();

            model.Reports = repo.PaperResultsModelSelectReport(paperID);
            model.Paper = repo.PaperModelSelectOneByPaperID(paperID);
            model.HolisticScore = model.Reports[0].HolisticScoreLetter;
            model.StudentFeedback = model.Reports[0].StudentFeedback;
            model.Comments = model.Reports[0].Comments;
            model.EvaluationID = model.Reports[0].EvaluationID;

            return View(model);
        }

        public ActionResult ViewIndividualPaper(int id)
        {
            Repository repo = new Repository();

            //string contentType = "";

            PaperModel model = repo.PaperModelViewSpecificPaper(id);
            byte[] paperData = model.Paper;

            return File(paperData, "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        }

        public ActionResult MyGoals()
        {
            MyGoalsViewModel model = new MyGoalsViewModel(Convert.ToInt32(Session["StudentID"]));
            return View(model);
        }

        public ActionResult MyConferenceNotes()
        {
            MyConferenceNotesViewModel model = new MyConferenceNotesViewModel(Convert.ToInt32(Session["StudentID"]));
            return View(model);
        }

        public ActionResult UploadPaper(int? CourseID, ACourseSelectionViewModel.CourseSelectionState? State)
        {
            Repository repo = new Repository();
            StudentUploadPaperViewModel model = new StudentUploadPaperViewModel();

            // GET COURSES
            model.CourseDropDown = repo.ClassModelSelectAllByStudent(Convert.ToInt32(Session["StudentID"])).Select(x => new SelectListItem 
            {
                Value = x.ID.ToString(),
                Text = x.CourseTitle.ToString()
            }).ToList();

            model.CourseDropDown.Insert(0, new SelectListItem()
            {
                Value = null,
                Text = "--- Select Course ---"
            });

            // GET EVALUATION PERIODS
            model.EvaluationPeriodDropDown = repo.EvaluationPeriodSelectAll().Select(x => new SelectListItem 
            {
                Value = x.ID.ToString(),
                Text = x.evalDescription.ToString()
            }).ToList();

            model.EvaluationPeriodDropDown.Insert(0, new SelectListItem()
            {
                Value = null,
                Text = "--- Select Evaluation Period ---"
            });

            // GET PAPER TYPES
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

            //StudentUploadPaperViewModel model;
            //if (State == null & CourseID == null)
            //{
            //    model = new StudentUploadPaperViewModel(Convert.ToInt32(Session["StudentID"]));
            //}
            //else
            //{
            //    model = new StudentUploadPaperViewModel(Convert.ToInt32(Session["StudentID"]));
            //    model.State = State ?? ACourseSelectionViewModel.CourseSelectionState.Invalid;
            //    switch (model.State)
            //    {
            //        case (ACourseSelectionViewModel.CourseSelectionState.Invalid):
            //            model.CourseID = -1;
            //            model.RefreshCourseDropDown(Convert.ToInt32(Session["StudentID"]));
            //            break;
            //        case (ACourseSelectionViewModel.CourseSelectionState.CourseSelected):
            //            model.CourseID = CourseID ?? -1;
            //            model.RefreshCourseDropDown(Convert.ToInt32(Session["StudentID"]));
            //            break;

            //    }
            //    if (TempData.ContainsKey("model"))
            //        TempData.Remove("model");
            //    TempData.Add("model", model);
            //}
            return View(model);
        }
        [HttpPost]
        public ActionResult UploadPaper(StudentUploadPaperViewModel model)
        {
            Repository repo = new Repository();

            StudentUploadPaperViewModel old = (StudentUploadPaperViewModel)TempData["model"];
            //model.CourseID = old.CourseID;
            //model.BindViewModelElements(Convert.ToInt32(Session["StudentID"]));
            if (model.File != null)
            {
                // converts file to bytes
                model.Paper.Paper = new byte[model.File.InputStream.Length];
                model.File.InputStream.Read(model.Paper.Paper, 0, model.Paper.Paper.Length);

                // assigns other needed data to upload
                model.Paper.FileName = Path.GetFileName(model.File.FileName);
                model.Paper.uploadDate = DateTime.Now;


                //Check to see if a paper has a benchmark with the same evalPeriod exists. Set the new paper to benchmark. Set old to that month.
                repo.PaperModelPaperBenckmarkPeriodCheck(model.Paper);
            }
            else
            {
                model.Paper.Paper = null;
                // assigns other needed data to upload
                model.Paper.FileName = model.Paper.PaperTitle;
                model.Paper.uploadDate = DateTime.Now;
                //Check to see if a paper has a benchmark with the same evalPeriod exists. Set the new paper to benchmark. Set old to that month.
                repo.PaperModelPaperBenckmarkPeriodCheck(model.Paper);
            }
           // model.Paper.CourseID = model.CourseID;
            model.Paper.StudentID = Convert.ToInt32(Session["StudentID"]);
            repo.PaperModelPaperUpload(model.Paper);
            return RedirectToAction("StudentPortfolio");

        }
        public ActionResult UploadPaperDataOnlyModal(int paperID)
        {
            UploadPaperDataOnlyViewModel model = new UploadPaperDataOnlyViewModel(paperID, System.Web.HttpContext.Current.Request.UrlReferrer);
            return PartialView("_PaperUploadModal", model);
        }
        //[HttpPost]
        //public ActionResult ModalUploadPaperDataOnly(ViewPaperViewModel model)
        //{
        //    Repository repo = new Repository();

        //    // converts file to bytes
        //    model.Paper.Paper = new byte[model.File.InputStream.Length];
        //    model.File.InputStream.Read(model.Paper.Paper, 0, model.Paper.Paper.Length);

        //    // assigns other needed data to upload
        //    //model.Paper.FileName = Path.GetFileNameWithoutExtension(model.File.FileName);
        //    model.Paper.FileName = Path.GetFileName(model.File.FileName);
        //    model.Paper.uploadDate = DateTime.Now;

        //    // use this later

        //    //    //Check to see if a paper has a benchmark with the same evalPeriod exists. Set the new paper to benchmark. Set old to that month.
        //    repo.PaperModelPaperBenckmarkPeriodCheck(model.Paper);
        //    repo.PaperModelPaperUploadDataOnly(model.Paper);


        //    string msg = "Paper Uploaded!!";
        //    //return new JsonResult(msg);
        //    //return Json(new { data = msg }, JsonRequestBehavior.AllowGet);
        //    return RedirectToAction("ViewPapers", new { studentID = model.Paper.StudentID, courseID = model.Paper.CourseID, yearID = model.Paper.YearID, msg });
        //}
        [HttpPost]
        public ActionResult UploadPaperDataOnly(int StudentID, int CourseID)
        {
            Repository repo = new Repository();

            PaperModel paper = new PaperModel();
            if (Request.Files.Count > 0)
            {
                var files = Request.Files[0];
                var fileName = System.IO.Path.GetFileName(files.FileName);

                paper.Paper = new byte[files.InputStream.Length];
                //model.File.InputStream.Read(paper.Paper, 0, paper.Paper.Length);
        
                paper.FileName = Path.GetFileName(fileName);
                paper.uploadDate = DateTime.Now;
                repo.PaperModelPaperUploadDataOnly(paper);
                //return Json(new { success = true, message = "File uploaded successfully" }, JsonRequestBehavior.AllowGet);
            }
            return RedirectToAction("StudentPortfolio");
        }

        public ActionResult Index()
        {
            return RedirectToAction("Dashboard");
        }
        /// <summary>
        /// Post action for ConferenceTool.
        /// </summary>
        /// <returns></returns>
        public ViewResult ConferenceTool(string? msg)
        {
            Repository repo = new Repository();
            ConferenceToolViewModel model = new ConferenceToolViewModel();

            if (msg != null)
            {
                ViewBag.Msg = msg;
            }

            model.ConferenceTypeDropDown = repo.ConferenceToolSelectAllTypes();
            
            model.ElementDropDown = new List<SelectListItem>();
            model.ElementDropDown.Add( new SelectListItem { Value = null, Text = "--- Please Select Element ---" });

            model.SourceDropDown = new List<SelectListItem>();
            model.SourceDropDown.Add( new SelectListItem { Value = null, Text = "--- Please Select Paper/Project ---" });
            
            model.RoleHelpDropDown = repo.RoleConferenceModelSelectAll().Select(x => new SelectListItem
            {
                Value = x.RoleID.ToString(),
                Text = x.Role.ToString()
            }).ToList();

            model.RoleHelpDropDown.Insert(0, new SelectListItem()
            {
                Value = null,
                Text = "--- Please Select One ---"
            });
            model.ConferenceOpen = repo.ConferenceToolSelectAllByStudentID(Convert.ToInt32(Session["StudentID"]));

            return View(model);
        }

        [HttpPost]
        public ActionResult ConferenceTool(ConferenceToolViewModel model)
        {
            Repository repo = new Repository();
            model.DateCreated = DateTime.Now;
            repo.ConferenceToolUploadConference(model, Convert.ToInt32(Session["StudentID"]));

            
            return RedirectToAction("ConferenceTool", new { msg = "Sent!" });
        }
        public ActionResult InsertPaperBookshelf()
        {
            Repository repo = new Repository();

            InsertBookshelfPaperViewModel model = new InsertBookshelfPaperViewModel(Convert.ToInt32(Session["StudentID"]));
            model.ContentTypes = new List<SelectListItem>();
            model.ContentTypes.AddRange(repo.BookshelfContentSelectAll().Select(x => new SelectListItem() { Text = x.Content, Value = x.ID.ToString() }));
            //model.ContentTypes.AddRange(BookshelfContentDB.SelectAll().Select(x => new SelectListItem() { Text = x.Content, Value = x.ID.ToString() }));
            model.ContentTypes.Add(new SelectListItem { Text = "Please Select", Value = "0", Selected = false });
            List<PaperModel> allPapers = repo.PaperModelSelectAllByStudent(Convert.ToInt32(Session["StudentID"]));
            model.EligiblePapers = new List<SelectListItem>();
            model.EligiblePapers.AddRange(allPapers.Where(x => x.evaluationDate != null && x.IsInBookshelf != true).Select(p => new SelectListItem() { Text = p.PaperTitle, Value = p.PaperID.ToString() }));
            model.EligiblePapers.Add(new SelectListItem { Text = "Please Select", Value = "0", Selected = false });
            return View(model);
        }
        [HttpPost]
        public ActionResult InsertPaperBookshelf(InsertBookshelfPaperViewModel model)
        {
            Repository repo = new Repository();

            //Notify teacher.
            TeacherModel teacher = repo.TeacherModelSelectTeacherFromPaper(model.PaperId);
            StudentModel student = repo.StudentModelSelectOne(model.StudentId);


            EmailModelFunctions.Send(teacher.Email, "You have a new bookshelf request from " + student.FirstName + " " + student.LastName, "New Bookshelf Request");
            repo.PaperModelAddPaperToBookshelf(model.PaperId, model.ContentId);


            model.ContentTypes = new List<SelectListItem>();
            model.ContentTypes.AddRange(repo.BookshelfContentSelectAll().Select(x => new SelectListItem() { Text = x.Content, Value = x.ID.ToString() }));
            //model.ContentTypes.AddRange(BookshelfContentDB.SelectAll().Select(x => new SelectListItem() { Text = x.Content, Value = x.ID.ToString() }));
            model.ContentTypes.Add(new SelectListItem { Text = "Please Select", Value = "0", Selected = true });
            List<PaperModel> allPapers = repo.PaperModelSelectAllByStudent(Convert.ToInt32(Session["StudentID"]));

            model.EligiblePapers = new List<SelectListItem>();
            model.EligiblePapers.AddRange(allPapers.Where(x => x.evaluationDate != null && x.IsInBookshelf != true).Select(p => new SelectListItem() { Text = p.PaperTitle, Value = p.PaperID.ToString() }));
            model.EligiblePapers.Add(new SelectListItem { Text = "Please Select", Value = "0", Selected = true });
            return View(model);
        }
        public ActionResult ViewBookshelf()
        {
            Repository repo = new Repository();

            ViewBookshelfViewModel model = new ViewBookshelfViewModel(Convert.ToInt32(Session["StudentID"]));
            model.BookshelfContentLkp = new List<SelectListItem>();
            var bookshelfContent = repo.BookshelfContentSelectAll();
            //var bookshelfContent = BookshelfContentDB.SelectAll();
            foreach (var content in bookshelfContent)
            {
                model.BookshelfContentLkp.Add(new SelectListItem { Text = content.Content, Value = content.ID.ToString() });
            }
            model.BookshelfContentId = 1;
            model.BookshelfFilter = new List<SelectListItem>();
            model.BookshelfFilter.Add(new SelectListItem { Text = "Please Select", Value = "0" });
            model.BookshelfFilter.Add(new SelectListItem { Text = "Students in my Class", Value = "1" });
            model.BookshelfFilter.Add(new SelectListItem { Text = "Students in my School", Value = "2" });
            model.BookshelfFilter.Add(new SelectListItem { Text = "Students in my District", Value = "3" });
            return View(model);
        }
        [HttpPost]
        public ActionResult ViewBookshelf(ViewBookshelfViewModel model)
        {
            Repository repo = new Repository();

            model.Classes = ClassModelControls.GetSelectListItems(repo.ClassModelSelectAllByStudent(Convert.ToInt32(Session["StudentID"])), true);
            StudentModel student = repo.StudentModelSelectOne(Convert.ToInt32(Session["StudentID"]));
            if (model.PaperFilterID == 1)
            {
                ViewBag.ClassSelected = true;
                if (ViewBag.CourseID != null)
                {
                    model.CourseID = ViewBag.CourseID;
                }
                if (model.CourseID != 0)
                {
                    model.getBookShelfPapersClass(model.CourseID);
                    ViewBag.CourseID = model.CourseID; //saving this so controller remebers what class they selected if they go from class -> district -> class.
                    ViewBag.PaperPanelHeading = "Papers from Students in my Class";
                }
                else
                {
                    model.Papers = new List<PaperModel>();
                }

            }
            if (model.PaperFilterID == 2)
            {
                model.getBookShelfPapersSchool(student.SchoolID);
                ViewBag.PaperPanelHeading = "Papers from Students in my School";
            }
            if (model.PaperFilterID == 3)
            {
                model.getBookShelfPapersDistrict(student.DistrictID);
                ViewBag.PaperPanelHeading = "Papers from Students in my District";
            }
            return View(model);
        }
    }
}