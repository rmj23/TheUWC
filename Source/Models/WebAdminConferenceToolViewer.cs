using System;
using System.Collections.Generic;

namespace Source.Models
{
    public class WebAdminConferenceToolViewer
    {
        public int ConferenceID { get; set; }
        public string Student { get; set; }
        public int StudentID { get; set; }
        public int ConferenceTypeID { get; set; }
        public string ConferenceType { get; set; }
        public int SourceID { get; set; }
        public string SourceName { get; set; }
        public int ElementID { get; set; }
        public string Element { get; set; }
        public int RoleHelpID { get; set; }
        public string RoleHelp { get; set; }
        public DateTime DateCreated { get; set; }
        public List<WebAdminFeedbackToolViewer> FeedbackToolList { get; set; }

        public WebAdminConferenceToolViewer()
        {

        }
    }

    public class WebAdminFeedbackToolViewer
    {
        public int FeedbackID { get; set; }
        public int ConferenceID { get; set; }
        public int TargetUserID { get; set; }
        public string TargetUser { get; set; }
        public int AcknowldgedFlag { get; set; }
        public DateTime AcknowledgeDate { get; set; }
        public int FeedbackFlag { get; set; }
        public DateTime FeedbackDate { get; set; }
        public string FeedbackDetails { get; set; }
    }
}