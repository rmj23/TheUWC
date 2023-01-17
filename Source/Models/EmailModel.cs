using Microsoft.VisualStudio.TestTools.UnitTesting;
using Source.Data;
using System.Net.Mail;

namespace Source.Models
{
    public class EmailModel
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Message { get; set; }
        public string Subject { get; set; }
    }
    public static class EmailModelFunctions
    {
        public static void Send(string to, string msg, string subject)
        {
            Repository repo = new Repository();

            var message = new MailMessage();
            message.To.Add(to);
            message.From = (new MailAddress("noreply@uni-spire.com"));
            message.Subject = subject;
            message.Body = msg;
            SmtpClient client = DatabaseMetadataModel.smtp;
            client.Credentials = DatabaseMetadataModel.mailCredential;
            try
            {
                client.Send(message);
            }
            catch (SmtpException ex)
            {
                repo.InsertSqlError(ex.Message.ToString());
            }

        }
    }

}