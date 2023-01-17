using Source.Data;
using Source.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Source.Controllers
{
    [Authorize]
    [SessionCheck]
    public class TeacherController : Controller
    {

        protected RequestContext UseThisForSessions;

        public TeacherController()
        {
            ViewBag.Layout = "~/Views/Shared/_TeacherLayout.cshtml";
        }

        //******************************* START AJAX CALLS ********************************************//
        public ActionResult GetAcademicYearsForDropDownList()
        {
            Repository repo = new Repository();

            var years = repo.SelectAllAcademicYearModels();

            return Json(years, JsonRequestBehavior.AllowGet);
        }

        // for ajax
        public ActionResult GetClassesByTeacherIDandYearID(int YearID)
        {
            Repository repo = new Repository();

            int TeacherID = Convert.ToInt32(Session["TeacherID"]);
            var courses = repo.SelectAllByTeacherAndYear(TeacherID, YearID);

            return Json(courses, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SetDefaultClass(int CourseID)
        {
            Repository repo = new Repository();
            try
            {
                int TeacherID = Convert.ToInt32(Session["TeacherID"]);
                repo.SetDefaultClass(CourseID, TeacherID);
                var result = new { Success = true };
                return Json(result);
            }
            catch (Exception ex)
            {
                var result = new { Success = false, ErrorMessage = ex.ToString() };
                return Json(result);
            }

        }

        // for ajax
        public ActionResult GetStudentsByYearandCourse(int CourseID)
        {
            Repository repo = new Repository();

            var students = repo.SelectAllByClass(CourseID);

            return Json(new { data = students }, JsonRequestBehavior.AllowGet);
        }

        // for ajax
        // unenroll student from class

        // for ajax 
        // get students to enroll
        public ActionResult GetStudentsToEnroll(int CourseID)
        {
            Repository repo = new Repository();

            var students = repo.StudentModelSelectByDistrict(Convert.ToInt32(Session["DistrictID"]));

            return Json(new { data = students }, JsonRequestBehavior.AllowGet);
        }

        // get grades for dropdown
        public ActionResult GetGradesDropdown()
        {
            Repository repo = new Repository();

            var grades = repo.GradeModelSelectAll();

            return Json(grades, JsonRequestBehavior.AllowGet);
        }

        // get semesters for dropdown
        public ActionResult GetSemestersDropdown()
        {
            Repository repo = new Repository();

            var semesters = repo.SemesterModelSelectAll();

            return Json(semesters, JsonRequestBehavior.AllowGet);
        }

        // get subjects for dropdown
        public ActionResult GetSubjectsDropdown()
        {
            Repository repo = new Repository();

            var subjects = repo.SubjectModelSelectAll();

            return Json(subjects, JsonRequestBehavior.AllowGet);
        }

        // get eval periods for chart 
        // THIS GET THE MONTHS AND BENCHMARK MONTHS
        public ActionResult GetEvalPeriods()
        {
            Repository repo = new Repository();

            var evalPeriods = repo.EvaluationPeriodSelectAll();

            return Json(evalPeriods, JsonRequestBehavior.AllowGet);
        }

        // THIS GET JUST THE BENCHMARK MONTHS
        public ActionResult GetEvalPeriod()
        {
            Repository repo = new Repository();

            var evalPeriod = repo.EvaluationPeriodSelectAllBenchmark();

            return Json(evalPeriod, JsonRequestBehavior.AllowGet);
        }

        // get chart data
        public ActionResult GetChartData(int courseID, int evalPeriod)
        {
            Repository repo = new Repository();

            var chartData = repo.GetChartData(courseID, evalPeriod);

            int below = chartData.Where(x => x.ProficiencyID == 1).Count();
            int basic = chartData.Where(x => x.ProficiencyID == 2).Count();
            int proficient = chartData.Where(x => x.ProficiencyID == 3).Count();
            int advanced = chartData.Where(x => x.ProficiencyID == 4).Count();
            int plus = chartData.Where(x => x.ProficiencyID == 5).Count();

            int[] data = new int[] { below, basic, proficient, advanced, plus };

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        //*************************** END AJAX CALLS *******************************************************//



        // GET: Dashboard
        public ActionResult Dashboard()
        {

            Repository repo = new Repository();
            var currentYear = repo.SelectAllAcademicYearModels().Where(x => x.IsCurrent).FirstOrDefault();
            ViewBag.Quote = repo.QuoteModelSelectDailyQuotes();
            ViewBag.CurrentYear = currentYear.ID;
            return View();
        }

        // GET: Profile
        public new ActionResult Profile()
        {
            return View();
        }
        // GET: Inbox
        public ActionResult Inbox()
        {
            return View();
        }
        // GET: Settings
        public ActionResult Settings()
        {
            Repository repo = new Repository(); 

            ViewBag.CurrentYear = repo.SelectAllAcademicYearModels().Where(x => x.IsCurrent).FirstOrDefault().ID;

            return View();
        }

        public ActionResult ClassCreated()
        {
            return View();
        }
        public ActionResult BulkInsert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BulkInsert(HttpPostedFileBase FileUpload)
        {
            DataTable dt = new DataTable();
            if (FileUpload.ContentLength > 0)
            {
                string fileName = Path.GetFileName(FileUpload.FileName);
                string path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                try
                {
                    FileUpload.SaveAs(path);
                    dt = BulkInsertModelDb.ProcessCSV(path); //Function to process the DataTable.
                    BulkInsertModelDb.StudentBulkInsert(dt, SessionModel.SchoolID(UseThisForSessions), SessionModel.DistrictID(UseThisForSessions));
                }
                catch (Exception ex)
                {
                    ViewData["Feedback"] = ex.Message;
                }
            }
            else
            {
                //Catch errors
                ViewData["Feedback"] = "Please select a file.";
            }
            dt.Dispose();
            return View("BulkInsert", ViewData["Feedback"]);
        }
        public ActionResult BenchmarkReports()
        {
            Repository repo = new Repository();

            ViewBenchmarkReportsViewModel model;

            model = new ViewBenchmarkReportsViewModel(null, Convert.ToInt32(Session["TeacherID"]), null, null, null, null, null);
            //repo.InsertPoints(3, SessionModel.UserID(UseThisForSessions));

            return View(model);
        }

        public ActionResult StudentProgress()
        {

            return View();
        }

        // GET: AddClass
        public ActionResult AddClass()
        {
            ClassModel model = new ClassModel();
            return View(model);
        }
        //POST: AddClass
        [HttpPost]
        public ActionResult AddClass(ClassModel NewClass)
        {
            Repository repo = new Repository();

            NewClass.SchoolID = Convert.ToInt32(Session["SchoolID"]);
            NewClass.TeacherID = Convert.ToInt32(Session["TeacherID"]);

            string lastName = Convert.ToString(Session["UserLastName"]);
            string gradeDesc = repo.GradeModelSelectAll().Where(x => x.GradeID == NewClass.GradeID).FirstOrDefault().GradeDescription.ToString();
            string subject = repo.SubjectModelSelectAll().Where(x => x.ID == NewClass.SubjectID).FirstOrDefault().Subject.ToString();

            NewClass.CourseTitle = lastName + " - " + gradeDesc + " - " + subject + " - ";

            if (NewClass.Period == 0)
            {
                NewClass.CourseTitle += repo.SemesterModelSelectAll().Where(x => x.SemesterID == NewClass.SemesterID).FirstOrDefault().SemesterDescription.ToString();
            }
            else
            {
                NewClass.CourseTitle += NewClass.Period + " - " + repo.SemesterModelSelectAll().Where(x => x.SemesterID == NewClass.SemesterID).FirstOrDefault().SemesterDescription.ToString();
            }

            // insert class
            NewClass.ID = repo.ClassModelCourseInsert(NewClass);
            return RedirectToAction("EnrollStudent");

        }
        // GET: UpdateRoster
        public ActionResult UpdateRoster(string Msg)
        {
            ViewBag.Msg = Msg;

            Repository repo = new Repository();

            UpdateRosterViewModel model = new UpdateRosterViewModel();
            model.AllStudentsInSchool = repo.StudentModelSelectByDistrict(Convert.ToInt32(Session["DistrictID"]));

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertStudent(UpdateRosterViewModel model)
        {
            //old prams -- string FirstName, string MiddleName, string LastName, string StudentNumber
            Repository repo = new Repository();

            model.StudentModel.SchoolID = Convert.ToInt32(Session["SchoolID"]);
            model.StudentModel.DistrictID = Convert.ToInt32(Session["DistrictID"]);
            repo.StudentModelInsert(model.StudentModel);
            string Msg = "Student Added";

            return RedirectToAction("UpdateRoster", new { Msg });
        }

        // GET: EnrollStudent
        [HttpGet]
        public ActionResult EnrollStudent()
        {
            EnrollStudentViewModel model = new EnrollStudentViewModel();

            return View(model);
        }
        [HttpPost]
        public ActionResult EnrollStudentPost(int StudentID, int CourseID)
        {
            Repository repo = new Repository();
            StudentCourseModel model = new StudentCourseModel();
            model.StudentID = StudentID;
            model.CourseID = CourseID;
            repo.StudentCourseModelEnroll(model);
            var result = new { Success = true };
            return Json(result);
        }
        [HttpPost]
        public ActionResult Unenroll(int StudentID, int CourseID)
        {
            Repository repo = new Repository();

            repo.StudentCourseModelUnenroll(new StudentCourseModel() { StudentID = StudentID, CourseID = CourseID });
            var result = new { Success = true };
            return Json(result);
        }
        // GET: ParentStudentAccounts
        public ActionResult ParentStudentAccounts()
        {
            ParentStudentAccountsViewModel model;

            model = new ParentStudentAccountsViewModel(Convert.ToInt32(Session["TeacherID"]));

            return View(model);
        }
        public ActionResult ParentAccountManagement(int ID, int? courseID)
        {
            Repository repo = new Repository();

            if (TempData.ContainsKey("Message"))
                ViewBag.Message = TempData["Message"];
            List<ParentModel> model = repo.ParentModelSelectAllByStudent(ID);
            var student = repo.StudentModelSelectOne(ID);
            ViewBag.CourseID = (int)courseID;
            ViewBag.StudentID = ID;
            ViewBag.Title = student.FirstName + ' ' + student.LastName + "'s Parents";
            return View(model);
        }
        public RedirectToRouteResult DeleteParent(int studentID, int parentID)
        {
            Repository repo = new Repository();

            repo.ParentModelRemoveAssociation(parentID, studentID);
            TempData["Message"] = "Parent Deleted";
            return RedirectToAction("ParentAccountManagement", new { ID = studentID });
        }
        public ActionResult EditParent(int parentID, int studentID, int courseID)
        {
            //ParentModel model = ParentModelDb.SelectOneByUserID(userID);
            EditParentViewModel model = new EditParentViewModel(parentID);
            return View(model);
        }
        [HttpPost]
        public RedirectToRouteResult EditParent(EditParentViewModel model)
        {
            Repository repo = new Repository();

            repo.ParentModelUpdateContactInfo(model.Parent);
            return RedirectToAction("ParentAccountManagement", new { ID = model.StudentID, courseID = model.CourseID });
        }
        public ActionResult UpdateParentPassword(string e)
        {
            string email = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(e));
            UpdatePasswordModel model = new UpdatePasswordModel(email);
            return View(model);
        }
        [HttpPost]
        public RedirectToRouteResult UpdateParentPassword(UpdatePasswordModel model)
        {
            LoginModel login = model.ConvertToLoginModel();
            if (login != null) //They don't match
                login.ResetPassword(login.UserName, login.Password);
            return RedirectToAction("ParentStudentAccounts");
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
            return RedirectToAction("UpdateRoster");
        }
        public ActionResult EditStudent(int studentID, int courseID)
        {

            EditStudentViewModel model = new EditStudentViewModel(studentID, courseID);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditStudent(EditStudentViewModel model)
        {
            Repository repo = new Repository();
            repo.StudentModelUpdateInfo(model.Student);
            return RedirectToAction("ParentStudentAccounts", new { State = ACourseSelectionViewModel.CourseSelectionState.CourseSelected, CourseID = model.CourseID });
        }
        [HttpPost]
        public JsonResult DeleteStudent(int StudentID)
        {
            Repository repo = new Repository();
            repo.StudentModelDeleteByStudentID(StudentID);
            var response = new { Success = true };
            return Json(response);
        }
        public ActionResult UpdateStudentPassword(string e)
        {
            string email = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(e));
            UpdatePasswordModel model = new UpdatePasswordModel(email);
            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateStudentPassword(UpdatePasswordModel model)
        {
            LoginModel login = model.ConvertToLoginModel();
            if (ModelState.IsValid)
            {
                if (login != null) //They don't match
                    login.ResetPassword(login.UserName, login.Password);
                return RedirectToAction("ParentStudentAccounts");
            }
            return View();
        }
        // GET: AnchorPapers
        public ActionResult AnchorPapers()
        {
            return View();
        }
        public ActionResult Glossary()
        {
            Repository repo = new Repository();

            List<GlossaryModel> model = repo.GlossaryModelSelectAll();

            return View(model);
        }
        // GET: Graphic Organizers
        public ActionResult GraphicOrganizers()
        {
            return View();
        }
        // GET: InteractiveMentorTexts
        public ActionResult InteractiveMentorTexts()
        {
            return View();
        }
        // GET: WritingStandards
        public ActionResult WritingStandards()
        {
            return View();
        }
        public ActionResult StudentChecklist()
        {
            return View();
        }

        public ActionResult ViewClass(int? courseID, int? yearID, AYearCourseSelection.YearCourseSelectionState? State)
        {
            Debug.WriteLine("VIEW CLASS FUNCTION IS CALLED");
            ViewClassViewModel model;
            if (TempData["model"] == null || (courseID == null && yearID == null && State == null))
            {
                if (SessionModel.DefaultClassEnabled(UseThisForSessions))
                {
                    model = new ViewClassViewModel(SessionModel.TeacherID(UseThisForSessions), SessionModel.DefaultClassID(UseThisForSessions));
                }
                else
                {
                    model = new ViewClassViewModel(SessionModel.TeacherID(UseThisForSessions));
                }

            }
            else
            {
                model = (ViewClassViewModel)TempData["model"];
                if (model == null)
                {
                    return RedirectToAction("Error", "Shared");
                }
                model.State = State ?? AYearCourseSelection.YearCourseSelectionState.Invalid;
                if (yearID == 0)
                    model.State = AYearCourseSelection.YearCourseSelectionState.Invalid;
                switch (model.State)
                {
                    case (AYearCourseSelection.YearCourseSelectionState.Invalid):
                        model.YearID = -1;
                        model.CourseID = -1;
                        break;
                    case (AYearCourseSelection.YearCourseSelectionState.YearSelected):
                        model.YearID = yearID ?? -1;
                        model.RefreshCourseDropDown();
                        break;
                    case (AYearCourseSelection.YearCourseSelectionState.CourseSelected):
                        model.CourseID = courseID ?? -1;
                        model.RefreshCourse();
                        break;
                }
            }
            if (TempData.ContainsKey("model"))
                TempData.Remove("model");
            TempData.Add("model", model);
            return View(model);
        }
        public ActionResult CustomCriteriaInsert(int projectId)
        {
            return View();
        }
        public ActionResult InsertProject(int? courseId)
        {
            InsertProjectViewModel model;
            if (SessionModel.DefaultClassEnabled(UseThisForSessions))
            {
                model = new InsertProjectViewModel(SessionModel.TeacherID(UseThisForSessions), SessionModel.DefaultClassID(UseThisForSessions));
            }
            else
            {

                model = new InsertProjectViewModel(SessionModel.TeacherID(UseThisForSessions), courseId);


            }

            model.State = ACourseSelectionViewModel.CourseSelectionState.Invalid;
            switch (model.State)
            {
                case (ACourseSelectionViewModel.CourseSelectionState.Invalid):
                    break;
                case (ACourseSelectionViewModel.CourseSelectionState.CourseSelected):
                    model.CourseID = courseId ?? -1;
                    break;
            }
            return View(model);
        }
        // create action that calls the course information and returns the view
        [HttpPost]
        public ActionResult newClassSelected(InsertProjectViewModel insertProjectViewModel)
        {
            return RedirectToAction("InsertProject", new { insertProjectViewModel.CourseID });
        }


        [HttpPost]
        public ActionResult InsertProject(InsertProjectViewModel model)
        {
            Repository repo = new Repository();

            // this sets the selected course id to the newly created project 
            model.project.courseId = model.CourseID;


            model.project.projectId = repo.ProjectModelInsert(model.project);

            TempData.Remove("model");

            // if project is to have a custom criteria
            if (model.project.customCriteria)

            {
                model.CustomContinuum.ProjectId = model.project.projectId;
                CustomContinuumModelDb.InsertCustomCriteria(model.project.projectId, model.CustomContinuum);
            }

            // if project is to have groups 
            if (model.HasGroup)
            {
                return RedirectToAction("AddGroups", new { projectId = model.project.projectId });
            }
            else
            {
                //TODO: If teacher is creating groups for this project.
                return RedirectToAction("MyProjects");
            }
        }
        public ActionResult ViewGroups(int projectId)
        {
            ViewGroupsViewModel model = new ViewGroupsViewModel(projectId);
            return View(model);
        }
        public ActionResult EditGroupInfo(int groupId)
        {
            EditGroupInfoViewModel model = new EditGroupInfoViewModel(groupId);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditGroupInfo(EditGroupInfoViewModel model)
        {
            Repository repo = new Repository();

            repo.GroupModelUpdateGroupInfo(model.group.groupId, model.group.projectSubtitle);
            return RedirectToAction("EditProjects", new { projectId = model.group.projectId });
        }
        public ActionResult UploadGroupMedia(int? projectId, int? groupId)
        {
            UploadGroupMediaViewModel model = new UploadGroupMediaViewModel(projectId, groupId);
            return View(model);
        }
        [HttpPost]
        public ActionResult UploadGroupMedia(UploadGroupMediaViewModel model)
        {
            Repository repo = new Repository();

            model.bindMedia();
            List<StudentModel> students = repo.StudentModelSelectAllInGroup(model.groupId);
            foreach (var student in students)
            {
                repo.GroupMediaModelInsertMedia(student.StudentID, model.projectId, model.media, model.mediaType.ToString(), model.groupId, model.title);
            }
            return RedirectToAction("ViewGroups", "Teacher", new { projectId = model.projectId });
        }
        public ActionResult ViewGroupMedia(int? projectId, int? groupId)
        {
            ViewGroupMediaViewModel model = new ViewGroupMediaViewModel(groupId, projectId);
            return View(model);
        }
        public ActionResult DeleteGroupMedia(int? projectId, int? groupId)
        {
            Repository repo = new Repository();

            repo.GroupMediaModelDelete((int)groupId, (int)projectId);
            return RedirectToAction("ViewGroupMedia", new { projectId = projectId, groupId = groupId });
        }
        public ActionResult ViewIndividualGroupMedia(int mediaId)
        {
            Repository repo = new Repository();

            var groupMedia = repo.GroupMediaModelViewIndividualMedia(mediaId);
            byte[] media = groupMedia.media;
            MemoryStream ms = new MemoryStream(media);
            if (groupMedia.mediaType == "PDF")
            {
                return new FileStreamResult(ms, "application/pdf");
            }
            if (groupMedia.mediaType == "DOC")
            {

                return new FileStreamResult(ms, "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
            }
            if (groupMedia.mediaType == "MOV")
            {
                return new FileStreamResult(ms, "");
            }
            if (groupMedia.mediaType == "IMG_JPEG")
            {
                return new FileStreamResult(ms, "image/jpeg");
            }
            if (groupMedia.mediaType == "IMG_PNG")
            {
                return new FileStreamResult(ms, "image/png");
            }
            if (groupMedia.mediaType == "AUDIO")
            {
                return new FileStreamResult(ms, "audio/mpeg");
            }
            if (groupMedia.mediaType == "MOV_MP4")
            {
                return new FileStreamResult(ms, "video/mp4");
            }
            else // should never hit this, might throw an exception if we do, not sure yet.
            {
                return null;
            }

        }

        /// Project Management -Groups //////////////////////////////////////////////////////////////////////
        [HttpPost]
        public ActionResult SetActiveGroup(string projectJSON)
        {
            //projectJSON.
            //GroupStudentViewModel model = new GroupStudentViewModel(projectId);
            //model.activeGroupId = groupId;
            return View("AddGroups");
        }
        public ActionResult AddGroupPartial(int projectId)
        {
            GroupStudentViewModel model = new GroupStudentViewModel(projectId, null);
            model.AddGroup();
            return View("AddGroups", model);
        }

        public ActionResult RemoveGroupPartial(int projectId, int groupId)
        {
            GroupStudentViewModel model = new GroupStudentViewModel(projectId, null);
            //GroupStudentViewModel model = new GroupStudentViewModel();
            model.RemoveGroup(groupId);
            return View("AddGroups", model);
        }
        public ActionResult AddGroups(int projectId, int? groupId)
        {
            GroupStudentViewModel model = new GroupStudentViewModel(projectId, groupId);
            return View(model);
        }
        public ActionResult EditAddGroups(int projectId, int? groupId)
        {
            GroupStudentViewModel model = new GroupStudentViewModel(projectId, groupId);
            return View(model);
        }

        public ActionResult AddStudentToGroup(int studentId, int groupId, int projectId)
        {
            Repository repo = new Repository();

            repo.GroupModelInsertStudentToGroup(groupId, studentId);
            return RedirectToAction("AddGroups", new { projectId, groupId });
        }
        public ActionResult RemoveStudentFromGroup(int studentId, int groupId, int projectId)
        {
            Repository repo = new Repository();

            repo.GroupModelRemoveStudentFromGroup(groupId, studentId);
            return RedirectToAction("AddGroups", new { projectId, groupId });
        }
        /// Project Management -Groups //////////////////////////////////////////////////////////////////////
        public ActionResult MyProjects(int? courseId, ACourseSelectionViewModel.CourseSelectionState? State, bool? clearTemp)
        {
            Debug.WriteLine("MY PROJECTS FUNC IS CALLED");
            if (null != clearTemp && (bool)clearTemp)
            {
                TempData.Remove("model");
            }
            TeacherProjectsViewModel model;
            if (TempData["model"] == null || courseId == null)
            {
                if (SessionModel.DefaultClassEnabled(UseThisForSessions))
                {
                    model = new TeacherProjectsViewModel(SessionModel.TeacherID(UseThisForSessions), SessionModel.DefaultClassID(UseThisForSessions));
                    courseId = SessionModel.DefaultClassID(UseThisForSessions);
                }
                else
                {
                    model = new TeacherProjectsViewModel(SessionModel.TeacherID(UseThisForSessions));
                }

                if (courseId != null)
                {
                    model.CourseID = (int)courseId;
                    model.CourseSelected();
                }
            }
            else
            {
                model = (TeacherProjectsViewModel)TempData["model"];
                model.State = State ?? ACourseSelectionViewModel.CourseSelectionState.Invalid;
                switch (model.State)
                {
                    case (ACourseSelectionViewModel.CourseSelectionState.Invalid):
                        break;
                    case (ACourseSelectionViewModel.CourseSelectionState.CourseSelected):
                        model.CourseID = (int)courseId;
                        model.CourseSelected();
                        break;
                }
            }
            if (TempData.ContainsKey("model"))
                TempData.Remove("model");
            TempData.Add("model", model);
            return View(model);
        }
        public ActionResult DeleteProject(int projectId, int courseId)
        {
            Repository repo = new Repository();

            repo.ProjectModelDelete(projectId);
            return RedirectToAction("MyProjects", new { courseId = courseId, State = ACourseSelectionViewModel.CourseSelectionState.CourseSelected });
        }
        public ActionResult EditProjects(int projectId)
        {
            Repository repo = new Repository();

            ProjectModel model = repo.ProjectModelSelectOne(projectId);
            ViewGroupsViewModel viewGroupsModel = new ViewGroupsViewModel(model.projectId);
            return View(viewGroupsModel);

        }
        [HttpPost]
        public ActionResult EditProject(ViewGroupsViewModel model)
        {
            Repository repo = new Repository();

            repo.ProjectModelUpdate(model);
            //return Redirect("~/Teacher/MyProjects");
            return RedirectToAction("MyProjects", new { courseId = model.project.courseId, State = ACourseSelectionViewModel.CourseSelectionState.CourseSelected });
        }



        public ActionResult Assignments()
        {
            Repository repo = new Repository();
            List<AssignmentModel> model = repo.AssignmentSelectAllByCourse(3);
            return View(model);
        }
        public ActionResult NewAssignment()
        {
            AssignmentModel model = new AssignmentModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult NewAssignment(AssignmentModel model)
        {
            Repository repo = new Repository();
            model.CourseID = 3;
            if (ModelState.IsValid)
            {
                repo.AssignmentInsert(model);
                return RedirectToAction("Assignments");
            }
            return View();
        }
        public ActionResult EditAssignment(int ID)
        {
            Repository repo = new Repository();
            AssignmentModel model = repo.AssignmentSelectOne(ID);
            TempData.Add("CourseID", model.CourseID);
            TempData.Add("Created", model.Created);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditAssignment(AssignmentModel model)
        {
            Repository repo = new Repository();
            model.CourseID = (int)TempData["CourseID"];
            model.Created = (DateTime)TempData["Created"];
            TempData.Remove("CourseID");
            TempData.Remove("Created");
            if (ModelState.IsValid)
            {
                repo.AssignmentUpdate(model);
            }
            return View(model);
        }

        public ActionResult TestLayout2()
        {
            return View();
        }
        public ActionResult AssignmentDetails(int ID)
        {
            Repository repo = new Repository();
            AssignmentModel model = repo.AssignmentSelectOne(ID);
            return View(model);
        }
        public ActionResult DeleteAssignment(int ID)
        {
            Repository repo = new Repository();
            AssignmentModel model = repo.AssignmentSelectOne(ID);
            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteAssignment(AssignmentModel model)
        {
            Repository repo = new Repository();
            repo.AssignmentDelete(model);
            return RedirectToAction("Assignments");
        }
        // GET: EvaluateWriting
        public ActionResult EvaluateWriting()
        {
            return View();
        }
        // GET: StudentData
        public ActionResult StudentData()
        {
            return View();
        }

        // GET: Teacher Points
        public ActionResult Points()
        {
            return View();
        }

        public ActionResult AddParent(int ID, int? courseID)
        {
            AddParentViewModel model = new AddParentViewModel(ID);
            model.StudentID = ID;
            model.CourseID = (int)courseID;
            return View(model);
        }
        [HttpPost]
        public ActionResult AddParent(AddParentViewModel model)
        {
            Repository repo = new Repository();

            if (ModelState.IsValid)
            {

                model.ParentModel.RoleID = 5;
                //AddParentViewModel.parentModel.RoleID = somevalue;
                repo.ParentModelInsert(model.ParentModel, model.StudentID);
                TempData["Message"] = "A new parent was added. The default password is iLoveWriting!";
                return RedirectToAction("ParentAccountManagement", new { ID = model.StudentID, courseID = model.CourseID });
            }
            return RedirectToAction("Shared", "Error");

        }

        public ActionResult AddStudent()
        {
            StudentModel model = new StudentModel();
            //if (!ModelState.IsValid)
            //{
            //    return View("AddStudent",model);
            //}

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
                return RedirectToAction("UpdateRoster", "Teacher");
            }
            return View();
        }

        /********** Lesson Plans **********/

        public ActionResult InsertLessonPlans()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertLessonPlans(LessonPlanModel model)
        {
            Repository repo = new Repository();

            model.TeacherID = Convert.ToInt32(Session["TeacherID"]);
            model.CourseID = 0;
            model.UploadDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                repo.LessonPlanModelInsert(model);
            }
            else
            {
                foreach (ModelState modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {
                        //Debug.WriteLine(error);
                    }
                }
            }
            return RedirectToAction("LessonPlans");
        }

        public ActionResult DeleteLessonPlan(int lessonPlanId)
        {
            Repository repo = new Repository();

            repo.LessonPlanModelDelete(lessonPlanId);
            return RedirectToAction("LessonPlans", "Teacher");
        }

        public ActionResult LessonPlans()
        {
            Repository repo = new Repository();
            List<LessonPlanModel> model = repo.LessonPlanSelectAllByTeacherID(Convert.ToInt32(Session["TeacherID"]));

            return View(model);
        }

        public ActionResult LessonPlan(int lessonPlanId)
        {
            Repository repo = new Repository();

            var model = repo.LessonPlanModelSelectbyLessonPlanID(lessonPlanId);

            return View(model);
        }

        public ActionResult LessonPlanPrint(int lessonPlanID)
        {
            Repository repo = new Repository();

            var model = repo.LessonPlanModelSelectbyLessonPlanID(lessonPlanID);
            return View(model);
        }
        public ActionResult ViewLessonPlan(ACourseSelectionViewModel.CourseSelectionState? State, int? TeacherID, int? CourseID)
        {
            ViewLessonPlanViewModel model;
            if (TempData["model"] == null || (CourseID == null && State == null))
            {
                if (SessionModel.DefaultClassEnabled(UseThisForSessions))
                {
                    model = new ViewLessonPlanViewModel(SessionModel.TeacherID(UseThisForSessions), SessionModel.DefaultClassID(UseThisForSessions));
                }
                else
                {
                    model = new ViewLessonPlanViewModel(SessionModel.TeacherID(UseThisForSessions));
                }

            }
            else
            {
                model = (ViewLessonPlanViewModel)TempData["model"];
                if (model == null)
                {
                    return RedirectToAction("Error", "Shared");
                }
                model.State = State ?? ACourseSelectionViewModel.CourseSelectionState.Invalid;
                switch (model.State)
                {
                    case (ACourseSelectionViewModel.CourseSelectionState.Invalid):
                        model.CourseID = -1;
                        break;
                    case (ACourseSelectionViewModel.CourseSelectionState.CourseSelected):
                        model.CourseID = CourseID ?? -1;
                        model.CourseSelected();
                        break;
                }
            }
            if (TempData.ContainsKey("model"))
                TempData.Remove("model");
            TempData.Add("model", model);
            return View(model);
        }
        //public PartialViewResult Chart()
        //{
        //    ChartSelectionViewModel model = new ChartSelectionViewModel();            

        //    return PartialView(model);
        //}

        public ActionResult HelpVideos()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CustomCriteriaInsert()
        {
            //TODO: If Group project, go to group, else finish.
            return RedirectToAction("Somewhere");
        }
        public ActionResult NotAllowed()
        {
            return View();
        }
        public new RedirectToRouteResult RedirectToAction(string action, string controller)
        {
            return base.RedirectToAction(action, controller);
        }
        public ActionResult BookshelfRequestQueue()
        {
            Repository repo = new Repository();

            List<TeacherBookshelfRequestModel> model = repo.TeacherBookshelfRequestModelSelectAllByTeacher(Convert.ToInt32(Session["TeacherID"]));

            return View(model);
        }
        public ActionResult ApproveBookshelfRequest(int bookshelfID)
        {
            Repository repo = new Repository();

            repo.TeacherBookshelfRequestModelAcknowledgeRequest(bookshelfID);
            return RedirectToAction("BookshelfRequestQueue");
        }
        public ActionResult DenyBookshelfRequest(int bookshelfID)
        {
            Repository repo = new Repository();

            repo.TeacherBookshelfRequestModelDenyRequest(bookshelfID);
            return RedirectToAction("BookshelfRequestQueue");
        }
        //Methods for the new Inquiry Sections
        //No views added yet
        public ActionResult InquiryClassData()
        {
            return View();
        }
        public ActionResult InquiryStudentProgress()
        {
            return View();
        }
        public ActionResult InquiryBenchmarkReports()
        {
            return View();
        }
        public ActionResult InquiryViewPortfolio()
        {
            return View();
        }
        public ActionResult ComprehensiveViewPortfolio()
        {
            return View();
        }


    }
}
