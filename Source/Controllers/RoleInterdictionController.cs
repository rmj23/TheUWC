using Source.Data;
using Source.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Source.Controllers
{
    public class RoleInterdictionController : Controller
    {
        // GET: UserDenied
        public ActionResult UserNotAllowed()
        {
            return View();
        }
        public ActionResult UpgradeSubscription()
        {
            SubscriptionRequestModel model = new SubscriptionRequestModel();
            model.Prefixes = new List<SelectListItem>();
            model.Prefixes.Add(new SelectListItem { Text = "Mr.", Value = "Mr." });
            model.Prefixes.Add(new SelectListItem { Text = "Mrs.", Value = "Mrs." });
            model.Prefixes.Add(new SelectListItem { Text = "Ms.", Value = "Ms." });
            model.Prefixes.Add(new SelectListItem { Text = "Dr.", Value = "Dr." });

            model.ContinuumTypes = new List<SelectListItem>();
            model.ContinuumTypes.Add(new SelectListItem { Text = "Universal Writing Continuum", Value = "UWC" });
            model.ContinuumTypes.Add(new SelectListItem { Text = "Universal Inquiry Continuum", Value = "UIC" });

            model.Editions = new List<SelectListItem>();
            model.Editions.Add(new SelectListItem { Text = "School", Value = "School" });
            model.Editions.Add(new SelectListItem { Text = "District", Value = "District" });
            return View(model);
        }
        [HttpPost]
        public ActionResult UpgradeSubscription(SubscriptionRequestModel model)
        {
            Repository repo = new Repository();

            repo.SubscriptionRequestModelInsert(model);
            var msg = model.Prefix + " " + model.FirstName + " " + model.LastName + " has requested to upgrade their subscription to " + model.ContinuumType + " - " + model.Edition + ". Please contact them at " +
                "Email: " + model.Email + " or Phone: " + model.Phone;
            EmailModelFunctions.Send("Debbie@thewritingcontinuum.com", msg, "Subscription Upgrade Request");
            return RedirectToAction("Dashboard", "Teacher");
        }
    }
}