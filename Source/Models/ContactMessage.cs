using System;

namespace Source.Models
{
    public class ContactMessage
    {
        private const string GENERAL = "General Questions";
        private const string PRICING = "Pricing";
        private const string REQUEST = "Request a Demo";
        private const string TECHNICAL = "Technical Issues";
        public string Reason { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Message { get; set; }
        public string TimeSent { get; set; }
        public ContactMessage(ContactModel model)
        {
            Reason = model.Reason;
            Name = model.FirstName + " " + model.LastName;
            Email = model.Email;
            PhoneNumber = model.Phone;
            Address = model.StreetNumber + " " + model.StreetName + " " + model.City + " " + model.State + " " +
                      model.ZipCode + " " + model.Country;
            Message = model.Message;
            TimeSent = model.TimeStamp.ToString();
        }

        public string GetSubject()
        {
            string subject = "";
            switch (Reason)
            {
                case GENERAL:
                    subject = "Uni- SPIRE" + " " + GENERAL;
                    break;
                case PRICING:
                    subject = "Uni- SPIRE" + " " + PRICING;
                    break;
                case TECHNICAL:
                    subject = "Uni- SPIRE" + " " + TECHNICAL;
                    break;
                case REQUEST:
                    subject = "Uni- SPIRE" + " " + REQUEST;
                    break;
            }
            return subject;
        }
        public string GetMessage()
        {
            string message = "";
            switch (Reason)
            {
                case GENERAL:
                    message = "Hello " + Name + ","
                        + Environment.NewLine + Environment.NewLine + "Thank you for your interest in Uni - SPIRE and our Universal Writing Continuum. We will address your questions and get back to you very soon.In the meantime, please explore our website and the links at the bottom of the homepage." + Environment.NewLine + Environment.NewLine + "Uni-SPIRE Team";
                    break;
                case PRICING:
                    message = "Hello " + Name + ","
                    + Environment.NewLine + Environment.NewLine +
                    "The Universal Writing Continuum is a powerful tool for K - 12 formative writing assessment and instruction.While adoption by school districts, charter schools and independent /private schools will best utilize the features, individual schools or grade levels may also find it useful. " +
                    Environment.NewLine + Environment.NewLine +
                    "The price of Universal Writing Continuum is per teacher license and varies based on the number of the teachers in the unit adopting it—the more teachers, the lower the price per teacher.With each teacher license, a log-in for parents and students is included at no cost.  A log in for school administrators and district administrators is also included.  A teacher license is under $100 per teacher." +
                    Environment.NewLine + Environment.NewLine +
                    "A minimum of one day of professional development is required. The price for the PD is $1500 per day." +
                    Environment.NewLine + Environment.NewLine +
                    "We will contact you soon to learn if you would like to discuss adoption or receive a demonstration." +
                    Environment.NewLine + Environment.NewLine + "Uni-SPIRE Team";
                    break;
                case REQUEST:
                    message = "Hello " + Name + ","
                    + Environment.NewLine + Environment.NewLine +
                    "Thank you for your interest in Uni - SPIRE and our Universal Writing Continuum. A short demo video will be sent to your email.If interested, we will also be available to have a personal walk - through of the website with you and your staff to answer specific questions." +
                    Environment.NewLine + Environment.NewLine + "Uni-SPIRE Team";
                    break;
                case TECHNICAL:
                    message = "Hello " + Name + ","
                   + Environment.NewLine + Environment.NewLine +
                   "Thank you for contacting us about this issue. You will receive a follow - up email soon from our team. We want to make your user experience productive."
                   + Environment.NewLine + Environment.NewLine +
                   "We apologize for any inconvenience and will try to resolve this issue as soon as possible." +
                    Environment.NewLine + Environment.NewLine + "Uni-SPIRE Team";
                    break;
            }
            return message;
        }

        public string GetTechnicalIssueResolvedMesage()
        {
            string message = "Hello, " + Name + Environment.NewLine + Environment.NewLine + "Your technical request submitted on " + TimeSent + " has been resolved! " + "Here's what you sent us: " + Environment.NewLine
                + Environment.NewLine + Message + Environment.NewLine + "Uni-SPIRE Team";
            return message;
        }

        public string GetOurMessage()
        {
            string message = "";
            switch (Reason)
            {
                case GENERAL:
                    message = "Hello," +
                              Environment.NewLine + Environment.NewLine +
                              "There is a GENERAL interest in Uni - SPIRE  from " + Name + "." +
                              Environment.NewLine + Environment.NewLine +
                              "Email : " + Email +
                              Environment.NewLine + Environment.NewLine +
                              "Phone : " + PhoneNumber +
                              Environment.NewLine + Environment.NewLine +
                              "Address : " + Address +
                              Environment.NewLine + Environment.NewLine +
                              "Message : " + Message +
                              Environment.NewLine + Environment.NewLine +
                              "This was sent on : " + TimeSent;
                    break;
                case PRICING:
                    message = "Hello," +
                              Environment.NewLine + Environment.NewLine +
                              "There is a PRICING interest in Uni - SPIRE  from " + Name + "." +
                              Environment.NewLine + Environment.NewLine +
                              "Email : " + Email + Environment.NewLine +
                              Environment.NewLine + Environment.NewLine +
                              "Phone : " + PhoneNumber +
                              Environment.NewLine + Environment.NewLine +
                              "Address : " + Address +
                              Environment.NewLine + Environment.NewLine +
                              "Message : " + Message +
                              Environment.NewLine + Environment.NewLine +
                              "This was sent on : " + TimeSent;

                    break;
                case REQUEST:
                    message = "Hello," +
                              Environment.NewLine + Environment.NewLine +
                              "There is a REQUEST interest in Uni - SPIRE  from " + Name + "." +
                              Environment.NewLine + Environment.NewLine +
                              "Email : " + Email +
                              Environment.NewLine + Environment.NewLine +
                              "Phone : " + PhoneNumber +
                              Environment.NewLine + Environment.NewLine +
                              "Address : " + Address +
                              Environment.NewLine + Environment.NewLine +
                              "Message : " + Message +
                              Environment.NewLine + Environment.NewLine +
                              "This was sent on : " + TimeSent;

                    break;
                case TECHNICAL:
                    message = "Hello," +
                              Environment.NewLine + Environment.NewLine +
                              "There is a TECHNICAL interest in Uni - SPIRE  from " + Name + "." +
                              Environment.NewLine + Environment.NewLine +
                              "Email : " + Email +
                              Environment.NewLine + Environment.NewLine +
                              "Phone : " + PhoneNumber +
                              Environment.NewLine + Environment.NewLine +
                              "Address : " + Address +
                              Environment.NewLine + Environment.NewLine +
                              "Message : " + Message +
                              Environment.NewLine + Environment.NewLine +
                              "This was sent on : " + TimeSent;

                    break;
            }
            return message;
        }
    }
}
