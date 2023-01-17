using Source.Data;
using Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Source.Controllers
{
    [SessionCheck]
    [Authorize]
    public class SettingsController : Controller
    {

        ////////////////////
        /// AJAX CALLS /////
        ////////////////////
        
        public ActionResult GetClassesByTeacherAndYear(int YearID)
        {
            int TeacherID = Convert.ToInt32(Session["TeacherID"]);

            Repository repo = new Repository();

            List<ClassModel> classes = repo.SelectAllByTeacher(TeacherID).Where(x => x.YearID == YearID).ToList();

            return Json(new { data = classes }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteCourse(int CourseID)
        {
            Repository repo = new Repository();

            int success = repo.CourseDelete(CourseID);

            return Json(success, JsonRequestBehavior.DenyGet);
        }

        ////////////////////////
        /// END AJAX CALLS /////
        ////////////////////////

        // GET: Settings
        public ActionResult ClassSettings()
        {
            return View();
        }

        // GET: EDIT CLASS
        public ActionResult EditClass(int CourseID)
        {
            Repository repo = new Repository();

            // get class data
            ClassModel classData = repo.ClassSelectOneByID(CourseID);
            
            // get data
            List<AcademicYearModel> years = repo.SelectAllAcademicYearModels();
            List<GradeModel> grades = repo.GradeModelSelectAll();
            List<SemesterModel> semesters = repo.SemesterModelSelectAll();
            List<SubjectModel> subjects = repo.SubjectModelSelectAll();
            List<SelectListItem> periods = PeriodModelControls.GetSelectListItems();

            EditClassModel editClassModel = new EditClassModel
            {
                // set course id
                CourseID = classData.ID,

                //grade
                SelectedGradeID = grades.Where(x => x.GradeID == classData.GradeID).FirstOrDefault().GradeID,
                GradeDropDown = grades.Select(x => new SelectListItem
                {
                    Value = x.GradeID.ToString(),
                    Text = x.GradeDescription
                }),

                // year
                SelectedYearID = years.Where(x => x.ID == classData.YearID).FirstOrDefault().ID,
                YearDropDown = years.Select(x => new SelectListItem
                {
                    Value = x.ID.ToString(),
                    Text = x.SchoolYear
                }),

                // course
                SelectedCourseID = semesters.Where(x => x.SemesterID == classData.SemesterType).FirstOrDefault().SemesterID,
                CourseDropDown = semesters.Select(x => new SelectListItem
                {
                    Value = x.SemesterID.ToString(),
                    Text = x.SemesterDescription
                }),

                //subject
                SelectedSubjectID = subjects.Where(x => x.ID == classData.SubjectID).FirstOrDefault().ID,
                SubjectDropdown = subjects.Select(x => new SelectListItem
                {
                    Value = x.ID.ToString(),
                    Text = x.Subject
                }),

                //period
                SelectedPeriodID = Convert.ToInt32(periods.Where(x => x.Value == classData.Period.ToString()).FirstOrDefault().Value),
                PeriodDropdown = periods
            };

            ViewBag.CourseTitle = classData.CourseTitle;

            return View(editClassModel);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditClass(EditClassModel model)
        {
            Repository repo = new Repository();

            // generate course title
            string lastName = Convert.ToString(Session["UserLastName"]);
            string gradeDesc = repo.GradeModelSelectAll().Where(x => x.GradeID == model.SelectedGradeID).FirstOrDefault().GradeDescription.ToString();
            string subject = repo.SubjectModelSelectAll().Where(x => x.ID == model.SelectedSubjectID).FirstOrDefault().Subject.ToString();
            string semester = repo.SemesterModelSelectAll().Where(x => x.SemesterID == model.SelectedCourseID).FirstOrDefault().SemesterDescription.ToString();

            model.CourseTitle = lastName + " - " + gradeDesc + " - " + subject + " - ";

            if (model.SelectedPeriodID == 0)
            {
                model.CourseTitle += semester;
            }
            else
            {
                model.CourseTitle += model.SelectedPeriodID.ToString() + " - " + semester;
            }

            bool success = repo.CourseUpdate(model);

            if (success)
            {
                return RedirectToAction("ClassSettings");

            }

            return RedirectToAction("EditClass", new { msg = "Error" });
        }
    }
}