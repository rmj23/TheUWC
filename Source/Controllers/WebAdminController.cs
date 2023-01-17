using Source.Data;
using Source.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Source.Controllers
{
    [Authorize]
    public class WebAdminController : Controller
    {
        private const string PROJECTIDEA = "ProjectIdea";
        private const string CULMINATINGACTIVITY = "CulminatingActivities";
        // GET: WebAdmin
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult AssignView(AGlobalRoleAssignmentSelection.GlobalRoleAssignmentSelectionState? State, int? roleId)
        {
            AssignViewViewModel model;
            if (State == null)
            {
                model = new AssignViewViewModel();
            }
            else
            {
                model = new AssignViewViewModel();
                model.State = State ?? AGlobalRoleAssignmentSelection.GlobalRoleAssignmentSelectionState.Invalid;
                switch (model.State)
                {
                    case (AGlobalRoleAssignmentSelection.GlobalRoleAssignmentSelectionState.Invalid):
                        model.roleId = -1;
                        break;
                    case (AGlobalRoleAssignmentSelection.GlobalRoleAssignmentSelectionState.RoleSelected):
                        model.roleId = roleId ?? -1;
                        model.UpdateViews((int)roleId);
                        break;
                }
                if (TempData.ContainsKey("model"))
                {
                    TempData.Remove("model");
                }
                TempData.Add("model", model);
            }
            return View(model);
        }
        public ActionResult AssignTeacherToRole(ATeacherRoleAssignmentSelection.TeacherRoleAssignmentState? State, int? roleId, int? districtId, int? schoolId)
        {
            AssignRoleToTeacherViewModel model;
            if (State == null)
            {
                model = new AssignRoleToTeacherViewModel();
                model.roleId = 0;
                model.updateTeachers();
            }
            else
            {
                model = (AssignRoleToTeacherViewModel)TempData["model"];
                model.State = State ?? ATeacherRoleAssignmentSelection.TeacherRoleAssignmentState.Invalid;
                switch (model.State)
                {
                    case (ATeacherRoleAssignmentSelection.TeacherRoleAssignmentState.Invalid):
                        model.roleId = 0;
                        break;
                    case (ATeacherRoleAssignmentSelection.TeacherRoleAssignmentState.DistrictSelected):
                        model.districtId = districtId ?? 0;
                        model.schoolId = schoolId ?? 0;
                        model.roleId = roleId ?? 0;
                        model.updateSchools();
                        model.updateTeachers();
                        break;
                    case (ATeacherRoleAssignmentSelection.TeacherRoleAssignmentState.SchoolSelected):
                        model.districtId = districtId ?? 0;
                        model.schoolId = schoolId ?? 0;
                        model.roleId = roleId ?? 0;
                        model.updateTeachers();
                        break;
                    case (ATeacherRoleAssignmentSelection.TeacherRoleAssignmentState.RoleSelected):
                        model.districtId = districtId ?? 0;
                        model.schoolId = schoolId ?? 0;
                        model.roleId = roleId ?? 0;
                        model.updateTeachers();
                        break;
                }
            }
            if (TempData.ContainsKey("model"))
            {
                TempData.Remove("model");
            }
            TempData.Add("model", model);
            if (model.districtId != 0)
            {
                model.readOnly = false;
            }
            else
            {
                model.readOnly = true;
            }
            if (model.roleId != 0)
            {
                ViewBag.assignedTeachersTitle = "Teachers Assigned To Selected Role";
            }
            else
            {
                ViewBag.assignedTeachersTitle = "Teachers Assigned To A Role";
            }
            return View(model);

        }
        public ActionResult UnAssignUserFromRole(int userId, int roleId, int schoolId, int districtId, ATeacherRoleAssignmentSelection.TeacherRoleAssignmentState State)
        {
            Repository repo = new Repository();
            repo.UnAssignUserFromRole(userId);
            return RedirectToAction("AssignTeacherToRole", new { State = State, roleId = roleId, districtId = districtId, schoolId = schoolId });
        }
        public ActionResult UnassignAllUsersFromRole(int districtId, int roleId, int schoolId, ATeacherRoleAssignmentSelection.TeacherRoleAssignmentState State)
        {
            Repository repo = new Repository();
            List<TeacherModel> teachers = repo.TeacherModelSelectTeachersAssignedToRole(roleId, districtId, schoolId);
            foreach (TeacherModel teacher in teachers)
            {
                repo.UnAssignUserFromRole(teacher.ID);
            }
            return RedirectToAction("AssignTeacherToRole", new { State = State, roleId = roleId, districtId = districtId, schoolId = schoolId });
        }
        public ActionResult AssignUserToRole(int roleId, int userId, int schoolId, int districtId, ATeacherRoleAssignmentSelection.TeacherRoleAssignmentState State)
        {
            Repository repo = new Repository();
            repo.AssignUserToRole(roleId, userId);
            return RedirectToAction("AssignTeacherToRole", new { State = State, roleId = roleId, districtId = districtId, schoolId = schoolId });
        }
        public ActionResult AssignAllUsersToRole(int roleId, int districtId, int schoolId, ATeacherRoleAssignmentSelection.TeacherRoleAssignmentState State)
        {
            Repository repo = new Repository();
            List<TeacherModel> teachers = repo.TeacherModelSelectTeachersUnassignedToRole(roleId, districtId, schoolId);
            foreach (TeacherModel teacher in teachers)
            {
                repo.AssignUserToRole(roleId, teacher.ID);
            }
            return RedirectToAction("AssignTeacherToRole", new { State = State, roleId = roleId, districtId = districtId, schoolId = schoolId });
        }
        public ActionResult AssignViewToRole(int roleId, int viewId)
        {
            Repository repo = new Repository();
            repo.AssignViewToRole(viewId, roleId);
            return RedirectToAction("AssignView", new { roleId = roleId, State = AGlobalRoleAssignmentSelection.GlobalRoleAssignmentSelectionState.RoleSelected });
        }
        public ActionResult RemoveViewFromRole(int roleId, int viewId)
        {
            Repository repo = new Repository();
            repo.RemoveViewFromRole(viewId, roleId);
            return RedirectToAction("AssignView", new { roleId = roleId, State = AGlobalRoleAssignmentSelection.GlobalRoleAssignmentSelectionState.RoleSelected });
        }
        public ActionResult InsertRole()
        {
            InsertRoleViewModel model = new InsertRoleViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult InsertRole(InsertRoleViewModel model)
        {
            Repository repo = new Repository();
            repo.InsertGlobalRole(model.role.Role);
            return RedirectToAction("InsertRole");
        }
        public ActionResult EditRole(int roleId)
        {
            Repository repo = new Repository();
            GlobalRoleModel model = repo.GlobalRoleSelectAll().Where(x => x.Id == roleId).FirstOrDefault();
            return View(model);

        }
        [HttpPost]
        public ActionResult EditRole(GlobalRoleModel model)
        {
            Repository repo = new Repository();
            repo.UpdateGlobalRole(model.Id, model.Role);
            return RedirectToAction("InsertRole");
        }
        public ActionResult DeleteRole(int roleId)
        {
            Repository repo = new Repository();
            repo.DeleteGlobalRole(roleId);
            return RedirectToAction("InsertRole");
        }
        public ActionResult ViewDistrict()
        {
            DistrictModelViewModel model = new DistrictModelViewModel(null);
            return View(model);
        }
        public ActionResult ViewIndividualDistrict(int DistrictID)
        {
            DistrictModelViewModel model = new DistrictModelViewModel(DistrictID);
            return View(model);
        }
        public ActionResult AddDistrict()
        {
            DistrictModel model = new DistrictModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult InsertDistrict(DistrictModel model)
        {
            if (ModelState.IsValid)
            {
                Repository repo = new Repository();

                repo.DistrictInsert(model);
            }
            //Add error handling
            return null;
        }

        public ActionResult ContinuumInsert()
        {
            ContinuumBuilderViewModel model = new ContinuumBuilderViewModel();
            return View(model);
        }
        //View the guidelines to edit for now. Will add more things to edit.
        public ActionResult EditContinuum(int ContinuumID)
        {
            ContinuumEditViewModel model = new ContinuumEditViewModel(ContinuumID);
            return View(model);
        }
        //Edit the continuum Guidelines for now. Will add more. Using view model
        [HttpPost]
        public ActionResult EditContinuum(ContinuumEditViewModel model)
        {
            Repository repo = new Repository();

            if (ModelState.IsValid)
            {
                repo.ContinuumEditContinuum(model.Continuum);
                //ContinuumModelDb.EditContinuum(model.Continuum);
                return RedirectToAction("ContinuumInsert");
            }
            return View();
        }
        public ActionResult ContinuumEntryDelete(int ContinuumID)
        {
            Repository repo = new Repository();

            repo.ContinuumEntryDelete(ContinuumID);
            //ContinuumModelDb.ContinuumEntryDelete(ContinuumID);
            return RedirectToAction("ContinuumInsert");
        }
        public ActionResult BulkInsertStudent()
        {
            StudentBulkInsertViewModel model = new StudentBulkInsertViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult BulkInsertStudent(HttpPostedFileBase fileUpload, DistrictModelViewModel model)
        {
            Repository repo = new Repository();

            if (fileUpload == null)
            {
                ViewData["Feedback"] = "Please select a file.";
            }
            else if (Path.GetExtension(fileUpload.FileName).ToLower() != ".csv")
            {
                ViewData["Feedback"] = "Not a CSV File!";
            }
            else
            {
                using (StreamReader sr = new StreamReader(fileUpload.InputStream))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        Console.WriteLine(line);
                    }
                }
            }
            //DataTable dt = new DataTable();
            //if (fileUpload.ContentLength > 0)
            //{
            //    string fileName = Path.GetFileName(fileUpload.FileName);
            //    string path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
            //    try
            //    {
            //        fileUpload.SaveAs(path);
            //        dt = BulkInsertModelDb.ProcessCSV(path); //Function to process the DataTable.
            //        BulkInsertModelDb.StudentBulkInsert(dt, model.SchoolID, repo.SchoolModelSelectOne(model.SchoolID).districtID);
            //    }
            //    catch (Exception ex)
            //    {
            //        ViewData["Feedback"] = ex.Message;
            //    }
            //}
            //else
            //{
            //    //Catch errors
            //    ViewData["Feedback"] = "Please select a file.";
            //}
            //dt.Dispose();
            //return View("BulkInsertStudent", ViewData["Feedback"]);
            return View("Dashboard");
        }
        public ActionResult BulkInsertStudentDistrict()
        {
            DistrictModelViewModel model = new DistrictModelViewModel(null);
            return View(model);
        }
        [HttpPost]
        public ActionResult BulkInsertStudentDistrict(HttpPostedFileBase FileUpload, DistrictModelViewModel model)
        {
            if (FileUpload == null)
            {
                ViewData["Feedback"] = "Please select a file.";
            }
            else if (Path.GetExtension(FileUpload.FileName).ToLower() != ".csv")
            {
                ViewData["Feedback"] = "Not a CSV File!";
            }
            else
            {
                try
                {
                    using (StreamReader sr = new StreamReader(FileUpload.InputStream))
                    {
                        Repository repo = new Repository();
                        int DistrictID = model.DistrictID;

                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            string[] column = line.Split(',');

                            // STUDENT INFO
                            string studentFirstName = column[0];
                            string studentMiddleName = column[1];
                            string studentLastName = column[2];
                            string studentSuffix = column[3];
                            string studentNumber = column[4];
                            string studentEmail = column[5];

                            // INSERT STUDENT
                            int StudentID = repo.StudentInsertDistrict(studentFirstName, studentMiddleName, studentLastName, studentNumber, DistrictID, studentSuffix, studentEmail);
                            if (StudentID == 0)
                            {
                                ViewData["Feedback"] = "Error inserting student";
                                RedirectToAction("BulkInsertStudentDistrict");
                            }

                            // PARENT 1 INFO
                            string parent1Prefix = column[6];
                            string parent1FirstName = column[7];
                            string parent1LastName = column[8];
                            string parent1Suffix = column[9];
                            string parent1Email = column[10];

                            // INSERT PARENT 1
                            if (parent1FirstName != "" && parent1LastName != "" & parent1Email != "")
                            {
                                // MAKING SURE I HAVE DATA IN THESE 3 FIELDS
                                // GO CHECK IF PARENT EXISTS
                                int parentID = repo.DoesParentExist(parent1Email);
                                if (parentID != -1)
                                {
                                    // PARENT ALREADY EXISTS
                                    repo.AssignParentToStudent(parentID, StudentID);
                                }
                                else
                                {
                                    // PARENT DOES NOT EXIST, CREATE ACCOUNT, AND ASSIGN PARENT TO STUDENT
                                    repo.InsertParentAndAssignParentToStudent(parent1Prefix, parent1FirstName, parent1LastName, parent1Email, parent1Suffix, StudentID);
                                }
                                parentID = 0;
                            }

                            // PARENT 2 INFO
                            string parent2Prefix = column[11];
                            string parent2FirstName = column[12];
                            string parent2LastName = column[13];
                            string parent2Suffix = column[14];
                            string parent2Email = column[15];

                            // INSERT PARENT 2
                            if (parent2FirstName != "" && parent2LastName != "" && parent2Email != "")
                            {
                                // MAKING SURE I HAVE DATA IN THESE 3 FIELDS
                                // GO CHECK IF PARENT EXISTS
                                int parentID = repo.DoesParentExist(parent2Email);
                                if (parentID != -1)
                                {
                                    // PARENT ALREADY EXISTS
                                    repo.AssignParentToStudent(parentID, StudentID);
                                }
                                else
                                {
                                    // PARENT DOES NOT EXIST, CREATE ACCOUNT, AND ASSIGN PARENT TO STUDENT
                                    repo.InsertParentAndAssignParentToStudent(parent2Prefix, parent2FirstName, parent2LastName, parent2Email, parent2Suffix, StudentID);
                                }
                                parentID = 0;
                            }

                            // PARENT 3 INFO
                            string parent3Prefix = column[16];
                            string parent3FirstName = column[17];
                            string parent3LastName = column[18];
                            string parent3Suffix = column[19];
                            string parent3Email = column[20];

                            // INSERT PARENT 3
                            if (parent3FirstName != "" && parent3LastName != "" && parent3Email != "")
                            {
                                // MAKING SURE I HAVE DATA IN THESE 3 FIELDS
                                // GO CHECK IF PARENT EXISTS
                                int parentID = repo.DoesParentExist(parent3Email);
                                if (parentID != -1)
                                {
                                    // PARENT ALREADY EXISTS
                                    repo.AssignParentToStudent(parentID, StudentID);
                                }
                                else
                                {
                                    // PARENT DOES NOT EXIST, CREATE ACCOUNT, AND ASSIGN PARENT TO STUDENT
                                    repo.InsertParentAndAssignParentToStudent(parent3Prefix, parent3FirstName, parent3LastName, parent3Email, parent3Suffix, StudentID);
                                }
                                parentID = 0;
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    ViewData["Feedback"] = ex.Message.ToString();
                }
            }
            //DataTable dt = new DataTable();
            //if (FileUpload.ContentLength > 0)
            //{
            //    string fileName = Path.GetFileName(FileUpload.FileName);
            //    string path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
            //    try
            //    {
            //        FileUpload.SaveAs(path);
            //        dt = BulkInsertModelDb.ProcessCSV(path); //Function to process the DataTable.
            //        BulkInsertModelDb.StudentBulkInsertDistrict(dt, model.DistrictID);
            //    }
            //    catch (Exception ex)
            //    {
            //        ViewData["Feedback"] = ex.Message;
            //    }
            //}
            //else
            //{
            //    //Catch errors
            //    ViewData["Feedback"] = "Please select a file.";
            //}
            //dt.Dispose();
            return RedirectToAction("BulkInsertStudentDistrict");
        }
        public ActionResult BulkInsertSchool()
        {
            DistrictModelViewModel model = new DistrictModelViewModel(null);
            return View(model);
        }
        [HttpPost]
        public ActionResult BulkInsertSchool(HttpPostedFileBase file, DistrictModelViewModel model)
        {
            DataTable dt = new DataTable();
            if (file != null)
            {
                string fileName = Path.GetFileName(file.FileName);
                string path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                try
                {
                    file.SaveAs(path);
                    dt = BulkInsertModelDb.ProcessCSV(path);
                    BulkInsertModelDb.DistrictBulkInsert(dt, model.DistrictModel.ID);
                }
                catch (Exception ex)
                {
                    ViewData["Feedback"] = ex.Message + "Please report error to development team.";
                }
            }
            else
            {
                ViewData["Feedback"] = "Insert Failed, no file selected. Please refresh page.";
            }
            dt.Dispose();
            return View("BulkInsertSchool");
        }
        [HttpPost]
        public ActionResult ContinuumInsert(ContinuumBuilderViewModel model)
        {
            Repository repo = new Repository();

            repo.ContinuumInsertGuidlines(model.Continuum.LevelID, model.Continuum.PaperTypeID, model.Continuum.EvaluationTypeID, model.Continuum.Guidelines);
            //ContinuumModelDb.InsertGuidelines(model.Continuum.LevelID, model.Continuum.PaperTypeID, model.Continuum.EvaluationTypeID, model.Continuum.Guidelines);
            return RedirectToAction("ContinuumInsert");
        }
        public ActionResult ProjectHtmlViewer(int continuumID)
        {
            Repository repo = new Repository();

            ProjectContinuumModel model = repo.ProjectContinuumModelSelectByContinuumID(continuumID);
            return View(model);
        }

        [HttpGet]
        [ValidateInput(false)]
        public ActionResult ViewProjectContinuumInsert(int? ElementID, int? CharacteristicID, int? LevelID, string Guideline, ACharacteristicElementSelectionViewModel.CharacteristicElementSelectionState? State)
        {
            Repository repo = new Repository();

            ProjectContinuumInsertViewModel model;
            if (TempData["model"] == null)
            {
                model = new ProjectContinuumInsertViewModel();
            }
            else
            {
                if (State.HasValue && ElementID.HasValue)
                {
                    model = (ProjectContinuumInsertViewModel)TempData["model"];
                    model.ElementID = (int)ElementID;
                    model.State = (ACharacteristicElementSelectionViewModel.CharacteristicElementSelectionState)State;
                    if (ElementID != 0 && CharacteristicID != 0 && LevelID != 0 && Guideline != null)
                    {
                        repo.ProjectContinuumModelInsertGuidelines((int)ElementID, (int)CharacteristicID, (int)LevelID, Guideline);
                        TempData.Remove("model");
                        return RedirectToAction("ViewProjectContinuumInsert");
                    }
                    switch (model.State)
                    {
                        case (ACharacteristicElementSelectionViewModel.CharacteristicElementSelectionState.Invalid):
                            break;
                        case (ACharacteristicElementSelectionViewModel.CharacteristicElementSelectionState.ElementSelected):
                            model.getNewCharacteristics(model.ElementID);
                            break;
                    }
                }
                else
                {
                    model = new ProjectContinuumInsertViewModel();
                }
            }
            if (TempData.ContainsKey("model"))
                TempData.Remove("model");
            TempData.Add("model", model);
            return View(model);
        }
        public ActionResult ProjectContinuumEntryDelete(int ContinuumID)
        {
            Repository repo = new Repository();

            repo.ProjectContinuumModelDeleteEntry(ContinuumID);
            TempData.Remove("model");
            return RedirectToAction("ViewProjectContinuumInsert");
        }
        public ActionResult EditProjectContinuum(int ContinuumID)
        {
            ProjectContinuumEditViewModel model = new ProjectContinuumEditViewModel(ContinuumID);
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditProjectContinuum(ProjectContinuumEditViewModel model)
        {
            Repository repo = new Repository();

            repo.ProjectContinuumModelEditContinuum(model.Continuum.Id, model.ElementID, model.CharacteristicID, model.LevelID, model.Continuum.Guideline);
            TempData.Remove("model");
            return RedirectToAction("ViewProjectContinuumInsert");
        }
        public ActionResult ProjectIdeasInsert()
        {
            Repository repo = new Repository();

            ProjectIdeasCulminatingActivitiesInsertViewModel model = new ProjectIdeasCulminatingActivitiesInsertViewModel();
            model.GradeLevels = GradeLevelModelControls.GetSelectListItems(repo.GradeLevelModelSelectAll());
            model.PICAModel = new ProjectIdeasCulminatingActivitiesModel();
            model.Models = repo.ProjectIdeasModelSelectAll().Where(x => x.Type == PROJECTIDEA).ToList();
            return View(model);
        }
        [HttpPost]
        public JsonResult ProjectIdeasInsert(ProjectIdeasCulminatingActivitiesModel model)
        {
            Repository repo = new Repository();

            var result = false;
            try
            {
                model.Type = PROJECTIDEA;
                repo.ProjectIdeasModelInsert(model);
                result = true;
            }
            catch (Exception ex)
            {
                ErrorModelDb.InsertSqlError(ex.ToString());
            }
            return Json(result);

        }
        [HttpGet]
        public ActionResult GetProjectIdeas()
        {
            Repository repo = new Repository();

            ProjectIdeasCulminatingActivitiesInsertViewModel model = new ProjectIdeasCulminatingActivitiesInsertViewModel();
            model.Models = repo.ProjectIdeasModelSelectAll().Where(x => x.Type == PROJECTIDEA).ToList();
            return PartialView("_ProjectIdeasResult", model);
        }
        public ActionResult CulminatingActivitiesInsert()
        {
            Repository repo = new Repository();

            ProjectIdeasCulminatingActivitiesInsertViewModel model = new ProjectIdeasCulminatingActivitiesInsertViewModel();
            model.GradeLevels = GradeLevelModelControls.GetSelectListItems(repo.GradeLevelModelSelectAll());
            model.PICAModel = new ProjectIdeasCulminatingActivitiesModel();
            model.Models = repo.ProjectIdeasModelSelectAll().Where(x => x.Type == CULMINATINGACTIVITY).ToList();
            return View(model);
        }
        [HttpPost]
        public JsonResult CulminatingActivitiesInsert(ProjectIdeasCulminatingActivitiesModel model)
        {
            Repository repo = new Repository();

            var result = false;
            try
            {
                model.Type = CULMINATINGACTIVITY;
                repo.ProjectIdeasModelInsert(model);
                result = true;
            }
            catch (Exception ex)
            {
                ErrorModelDb.InsertSqlError(ex.ToString());
            }
            return Json(result);
        }
        [HttpGet]
        public ActionResult GetCulminatingActivities()
        {
            Repository repo = new Repository();

            ProjectIdeasCulminatingActivitiesInsertViewModel model = new ProjectIdeasCulminatingActivitiesInsertViewModel();
            model.Models = repo.ProjectIdeasModelSelectAll().Where(x => x.Type == CULMINATINGACTIVITY).ToList();
            return PartialView("_ProjectIdeasResult", model);
        }
        [HttpGet]
        public ActionResult ProjectIdeasCulminatingActivitiesEdit(int ID)
        {
            Repository repo = new Repository();

            ProjectIdeasCulminatingActivitiesInsertViewModel model = new ProjectIdeasCulminatingActivitiesInsertViewModel();
            model.PICAModel = repo.ProjectIdeasModelSelectAll().Where(x => x.ID == ID).FirstOrDefault();
            model.GradeLevels = GradeLevelModelControls.GetSelectListItems(repo.GradeLevelModelSelectAll());
            return View(model);
        }
        [HttpPost]
        public ActionResult ProjectIdeasCulminatingActivitiesEdit(ProjectIdeasCulminatingActivitiesInsertViewModel model)
        {
            Repository repo = new Repository();

            if (ModelState.IsValid)
            {
                repo.ProjectIdeasModelUpdate(model.PICAModel);
                if (model.PICAModel.Type == CULMINATINGACTIVITY)
                {
                    return RedirectToAction("CulminatingActivitiesInsert");
                }
                else
                {
                    return RedirectToAction("ProjectIdeasInsert");
                }
            }
            return View(model);
        }
        public ActionResult ProjectIdeasCulminatingActivitiesDelete(int ID)
        {
            Repository repo = new Repository();

            ProjectIdeasCulminatingActivitiesModel model = repo.ProjectIdeasModelSelectAll().Where(x => x.ID == ID).FirstOrDefault();
            if (model != null)
            {
                repo.ProjectIdeasModelDelete(model);
                if (model.Type == CULMINATINGACTIVITY)
                {
                    return RedirectToAction("CulminatingActivitiesInsert");
                }
                else
                {
                    return RedirectToAction("ProjectIdeasInsert");
                }
            }
            return null; //You'll never hit here.
        }
        public ActionResult EngagementsInsert()
        {
            //EngagementsViewModel model = new EngagementsViewModel();
            //return View(model);
            return View();
        }
        [HttpPost]
        public ActionResult EngagementsInsert(EngagementsViewModel model)
        {
            Repository repo = new Repository();

            repo.EngagementInsert(model.Engagement);
            //EngagementModelDB.Insert(model.Engagement);
            return RedirectToAction("EngagementsInsert");
        }
        public ActionResult EditEngagement(int ID)
        {
            EngagementsViewModel model = new EngagementsViewModel(ID);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditEngagement(EngagementsViewModel model)
        {
            Repository repo = new Repository();

            repo.EngagementEdit(model.Engagement);
            //EngagementModelDB.Edit(model.Engagement);
            return RedirectToAction("EngagementsInsert");
        }
        public ActionResult ViewEngagement(int ID)
        {
            EngagementsViewModel model = new EngagementsViewModel(ID);
            return View(model);
        }
        public ActionResult DeleteEngagement(int ID)
        {
            Repository repo = new Repository();

            repo.EngagementDelete(ID);
            //EngagementModelDB.Delete(ID);
            return RedirectToAction("EngagementsInsert");
        }
        public ActionResult InsertQuote()
        {
            InsertQuoteViewModel model = new InsertQuoteViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult InsertQuote(InsertQuoteViewModel model)
        {
            Repository repo = new Repository();

            repo.QuotesModelInsert(model.Quote);
            return RedirectToAction("InsertQuote");
        }
        public ActionResult EditQuote(int QuoteId)
        {
            Repository repo = new Repository();

            QuoteModel model = repo.QuoteModelSelectOne(QuoteId);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditQuote(QuoteModel model)
        {
            Repository repo = new Repository();

            repo.QuotesModelUpdate(model);
            return RedirectToAction("InsertQuote");
        }
        public ActionResult DeleteQuote(int QuoteId)
        {
            Repository repo = new Repository();

            repo.QuotesModelDelete(QuoteId);
            return RedirectToAction("InsertQuote");
        }
        public ActionResult InsertGlossaryTerm()
        {
            Repository repo = new Repository();
            InsertGlossaryTermViewModel model = new InsertGlossaryTermViewModel();
            model.Glossary = new GlossaryModel();
            model.GlossaryItems = repo.GlossaryModelSelectAll();
            return View(model);
        }
        [HttpPost]
        public ActionResult InsertGlossaryTerm(GlossaryModel model)
        {
            Repository repo = new Repository();

            repo.GlossaryModelInsert(model);
            //GlossaryModelDb.Insert(model);
            return RedirectToAction("InsertGlossaryTerm");
        }
        public ActionResult MonthlyPoints()
        {
            MonthlyPointsViewModel model = new MonthlyPointsViewModel();
            return View(model);
        }
        public ActionResult MonthlyPointsUpdate(int ID)
        {
            Repository repo = new Repository();

            MonthlyPointsModel model = repo.MonthlyPointsModelSelectOne(ID);
            return View(model);
        }
        [HttpPost]
        public ActionResult MonthlyPointsUpdate(MonthlyPointsModel model)
        {
            Repository repo = new Repository();

            repo.MonthlyPointModelUpdateTotal(model);
            return RedirectToAction("MonthlyPoints");
        }
        public ActionResult MonthlyPointsContestants()
        {
            MonthlyPointsContestantsViewModel model = new MonthlyPointsContestantsViewModel();
            return View(model);
        }
        public ActionResult MonthlyWinners()
        {
            MonthlyPointWinnersViewModel model = new MonthlyPointWinnersViewModel();
            return View(model);
        }
        public ActionResult EmailUsers()
        {
            ViewUsersViewModel model = new ViewUsersViewModel(null);
            return View(model);
        }
        [HttpGet]
        public ActionResult ViewUsers(int? RoleID)
        {
            ViewUsersViewModel model = new ViewUsersViewModel(RoleID);
            return View(model);
        }
        public ActionResult ViewContactRequests()
        {
            ContactModelViewModel model = new ContactModelViewModel();
            return View(model);
        }
        public ActionResult AcknowledgeContactRequest(int ContactRequestID)
        {
            Repository repo = new Repository();

            repo.ContactAcknowledgeContactRequest(ContactRequestID);
            //ContactModelDb.AcknowledgeContactRequest(ContactRequestID);
            //Send Email
            return RedirectToAction("ViewContactRequests");

        }
        public ActionResult ResolveContactRequest(int ContactRequestID)
        {
            Repository repo = new Repository();

            ContactModel model = repo.ContactSelectRequestByID(ContactRequestID);
            //ContactModel model = ContactModelDb.SelectByID(ContactRequestID);
            repo.ContactResolveContactRequest(ContactRequestID);
            //ContactModelDb.ResolveContactRequest(ContactRequestID);
            if (model.Reason.Equals("Technical Issues"))
            {
                //Send Email stating that tech issue has been resolved.
                SmtpClient client = DatabaseMetadataModel.smtp;
                MailMessage msg = new MailMessage("noreply@uni-spire.com", model.Email);
                ContactMessage message = new ContactMessage(model);
                msg.Subject = "Technical Issue Resolved";
                msg.Body = message.GetTechnicalIssueResolvedMesage();
                client.Credentials = DatabaseMetadataModel.mailCredential;
                client.Send(msg);

            }
            return RedirectToAction("ViewContactRequests");
        }
        public ActionResult DeleteContactRequest(int ContactRequestID)
        {
            Repository repo = new Repository();

            repo.ContactDeleteContactRequest(ContactRequestID);
            //ContactModelDb.DeleteContactRequest(ContactRequestID);
            return RedirectToAction("ViewContactRequests");
        }
        public ActionResult InsertContactRequestComment(int ContactRequestID)
        {
            Repository repo = new Repository();

            ContactModel model = repo.ContactSelectRequestByID(ContactRequestID);
            //ContactModel model = ContactModelDb.SelectByID(ContactRequestID);
            return View(model);
        }
        [HttpPost]
        public ActionResult InsertContactRequestComment(ContactModel model)
        {
            Repository repo = new Repository();

            repo.ContactInsertWebAdminComment(model.ID, model.WebAdminComments);
            //ContactModelDb.InsertWebAdminComment(model.ID, model.WebAdminComments);
            return RedirectToAction("ViewContactRequests");
        }
        public ActionResult ViewTeachersBySubject(int? subjectId)
        {

            EmailTeacherViewModel model = new EmailTeacherViewModel(subjectId, null, null);
            if (subjectId != null)
            {
                model.subjectId = (int)subjectId;
            }
            return View(model);
        }
        public ActionResult EmailTeachersBySubject(int subjectId)
        {
            EmailTeacherViewModel model = new EmailTeacherViewModel(subjectId, null, null);
            return View(model);
        }
        [HttpPost]
        public ActionResult EmailTeachersBySubject(EmailTeacherViewModel model)
        {
            model.sendEmails();
            return RedirectToAction("EmailSentLandingPage");
        }
        public ActionResult EmailSentLandingPage()
        {
            return View();
        }
        public ActionResult ViewTeachersBySchool(int? schoolId)
        {
            EmailTeacherViewModel model = new EmailTeacherViewModel(null, schoolId, null);
            if (schoolId != null)
            {
                model.schoolId = (int)schoolId;
            }
            return View(model);
        }
        public ActionResult EmailTeachersBySchool(int schoolId)
        {
            EmailTeacherViewModel model = new EmailTeacherViewModel(null, schoolId, null);
            return View(model);
        }
        [HttpPost]
        public ActionResult EmailTeachersBySchool(EmailTeacherViewModel model)
        {
            model.sendEmails();
            return RedirectToAction("EmailSentLandingPage");
        }
        public ActionResult ViewTeachersByDistrict(int? districtId)
        {
            EmailTeacherViewModel model = new EmailTeacherViewModel(null, null, districtId);
            if (null != districtId)
            {
                model.districtId = (int)districtId;
            }
            return View(model);
        }
        public ActionResult EmailTeachersByDistrict(int districtId)
        {
            EmailTeacherViewModel model = new EmailTeacherViewModel(null, null, districtId);
            return View(model);
        }
        [HttpPost]
        public ActionResult EmailTeachersByDistrict(EmailTeacherViewModel model)
        {
            model.sendEmails();
            return RedirectToAction("EmailSentLandingPage");
        }

        public ActionResult EditUserProfile()
        {
            throw new NotImplementedException();
        }

        public ActionResult UpdatePassword(string email)
        {
            PasswordUpdateModel model = new PasswordUpdateModel();
            model.Username = email;
            return PartialView("_UpdatePassword", model);
        }

        [HttpPost]
        public ActionResult ChangePassword(PasswordUpdateModel model)
        {
            Repository repo = new Repository();

            if (ModelState.IsValidField(model.Username) &&
                ModelState.IsValidField(model.NewPassword) &&
                ModelState.IsValidField(model.ConfirmPassword))
            {
                repo.PasswordUpdateModelChangePassword(model);
            }
            return RedirectToAction("ViewTeachersBySubject");
        }
        //TODO: Finish implementation
        public ActionResult ErrorLog(int? errorTypeID)
        {
            ErrorModelViewModel model;
            if (TempData["model"] == null || TempData["model"].GetType() != typeof(ErrorModelViewModel))
            {
                model = new ErrorModelViewModel();
            }
            else
            {
                model = (ErrorModelViewModel)TempData["model"];
                switch (errorTypeID)
                {
                    case 0:
                        break;
                    case 1:
                        model.ErrorTypeID = errorTypeID ?? -1;
                        model.ErrorList();
                        break;
                    case 2:
                        model.ErrorTypeID = errorTypeID ?? -1;
                        model.ErrorList();
                        break;
                }
            }
            if (TempData.ContainsKey("model"))
                TempData.Remove("model");
            TempData.Add("model", model);
            return View(model);
        }

    }
}