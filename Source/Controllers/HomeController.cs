using Source.Data;
using Source.Models;
using System.Net.Mail;
using System.Web.Mvc;
using System.Web.UI;

namespace Source.Controllers
{
    [OutputCache(Duration = 1800, Location = OutputCacheLocation.Any)]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TermsAndConditions()
        {
            return View();
        }

        public ActionResult PrivacyPolicy()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult LearnMore()
        {
            return View();
        }
        public ActionResult Contact()
        {
            ContactModel model = new ContactModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult Contact(ContactModel model)
        {
            Repository repo = new Repository();

            if (ModelState.IsValid)
            {
                // the database sets the local time, no need for this
                //model.TimeStamp = DateTime.Now.ToLocalTime();
                //Process contact request

                repo.ContactRequestInsert(model);
                //ContactModelDb.Insert(model);


                //Send email
                SmtpClient client = DatabaseMetadataModel.smtp;
                MailMessage msg = new MailMessage("noreply@uni-spire.com", model.Email);
                MailMessage msgToDebbie = new MailMessage("noreply@uni-spire.com", "debbie@thewritingcontinuum.com");
                ContactMessage message = new ContactMessage(model);
                msg.Body = message.GetMessage();
                msgToDebbie.Body = message.GetOurMessage();
                msg.Subject = message.GetSubject();
                msgToDebbie.Subject = message.GetSubject();


                client.Credentials = DatabaseMetadataModel.mailCredential;
                client.Send(msg);
                client.Send(msgToDebbie);

                //If a tech question eamil current Web Dev
                if (model.Reason == "Technical Issues")
                {
                    MailMessage msgToWebDev = new MailMessage("noreply@uni-spire.com", "kreppz7@yahoo.com");
                    msgToWebDev.Body = message.GetOurMessage();
                    msgToWebDev.Subject = "Uni-SPIRE Tech Question";
                    client.Send(msgToWebDev);
                }

                //return RedirectToAction("Contact", "Home", "Success");
                return RedirectToAction("ContactSubmitted");
            }
            return View(model);
        }
        public ActionResult ContactSubmitted()
        {
            return View();
        }

        public ActionResult ElectronicPortfolio()
        {
            return View();
        }

        public ActionResult Educators()
        {
            return View();
        }

        public ActionResult Assessment()
        {
            return View();
        }

        public ActionResult Commoncore()
        {
            return View();
        }

        public ActionResult FormativeWriting()
        {
            return View();
        }

        public ActionResult ProfessionalDevelopment()
        {
            return View();
        }

        public ActionResult Reports()
        {
            return View();
        }

        public ActionResult Research()
        {
            return View();
        }

        public ActionResult Testimonials()
        {
            return View();
        }
    }
}