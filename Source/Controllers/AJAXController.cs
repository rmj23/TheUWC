
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Source.Models;

namespace Source.Data
{
    [SessionCheck]
    [Authorize]
    public class AJAXController : Controller
    {
        Repository repo = new Repository();

        // student get paper for conference tool
        public JsonResult getPaper(int ConferenceID)
        {
            List<PaperModel> result = repo.PaperModelSelectAllByStudent(Convert.ToInt32(Session["StudentID"]));

            return Json(result, JsonRequestBehavior.AllowGet);

        }

        // STUDENT GET PROJECT FOR CONFERENCE TOOL
        public JsonResult getProject(int ConferenceID)
        {
            List<ProjectModel> result = repo.ProjectModelSelectAllByStudent(Convert.ToInt32(Session["StudentID"]));

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // STUDENT GET ELEMENT (IF PAPER GET EVALUATION MODEL) FOR CONFERENCE TOOL
        public JsonResult getElementEval()
        {
            List<EvaluationTypeModel> result = repo.EvaluationSelectAllWithConventions();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // STUDENT GET ELEMENT (IF PROJECT GET ELEMENT MODEL) FOR CONFERENCE TOOL
        public JsonResult getElementProject()
        {
            List<ElementModel> result = repo.ElementSelectAll();

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}