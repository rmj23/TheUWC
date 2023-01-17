using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace Source.Models
{
    public class DatabaseMetadataModel
    {
        public static string dbconn = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
        public static SmtpClient smtp = new SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587));
        public static NetworkCredential mailCredential = new NetworkCredential("TheWritingContinuum", "ilovewriting1!");
    }
}