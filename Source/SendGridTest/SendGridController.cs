using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net.Mime;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Source.SendGridTest
{
    public class Program
    {
        public void Main()
        {
            try
            {
                MailMessage mailMsg = new MailMessage();

                // To
                mailMsg.To.Add(new MailAddress("tdg3475@uncw.edu", "Travis Griffin"));

                // From
                mailMsg.From = new MailAddress("info@uni-spire.com", "The Writing Continuum");

                // Subject and multipart/alternative Body
                mailMsg.Subject = "Test For SendGrid";
                string text = "This is a test to see if SendGrid is working properly";
                string html = @"<p>html body</p>";
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

                // Init SmtpClient and send
                SmtpClient smtpClient = new SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587));
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("azure_a9f00bc8e82ee1e04873a5825d2474bc@azure.com", "theWriting1!");
                smtpClient.Credentials = credentials;

                smtpClient.Send(mailMsg);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}