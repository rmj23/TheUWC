using Source.Data;
using Source.Models;
using System.Web.Mvc;
using System.Web.Routing;

namespace Source.Controllers
{
    [Authorize]
    public class ParentController : Controller
    {
        private RequestContext UseThisForSessions;
        protected override void Initialize(RequestContext requestContext)
        {
            SessionModel.UserIsParent(requestContext);
            UseThisForSessions = requestContext;
            base.Initialize(requestContext);
        }
        // GET: Dashboard
        public ActionResult Dashboard()
        {
            return View();
        }
        //GET: Profile
        public new ActionResult Profile()
        {
            return View();
        }
        //GET: Settings
        public ActionResult Settings()
        {
            return View();
        }
        //GET: Parent Portfolio
        public ActionResult ParentPortfolio()
        {
            //ParentPortfolioViewModel model = new ParentPortfolioViewModel(SessionModel.ParentID(UseThisForSessions));
            //return View(model);
            return View();
        }

        public ActionResult PaperResults(int paperID)
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

        public ActionResult TeacherFeedback()
        {
            ParentFeedbackViewModel model = new ParentFeedbackViewModel(SessionModel.ParentID(UseThisForSessions));
            return View(model);
        }

        public ActionResult Goals()
        {
            ParentGoalsViewModel model = new ParentGoalsViewModel(SessionModel.ParentID(UseThisForSessions));
            return View(model);
        }
    }
}