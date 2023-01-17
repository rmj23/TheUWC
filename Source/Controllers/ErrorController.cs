using System.Web.Mvc;

namespace Source.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult NotFound()
        {
            return View();
        }
        public ActionResult ServerError()
        {
            return View();
        }
    }
}