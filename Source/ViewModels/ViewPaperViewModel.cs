using System.Collections.Generic;
using System.Web;

namespace Source.Models
{
    public class ViewPaperViewModel
    {
        public PaperModel Paper { get; set; }
        public List<PaperModel> AllPapers { get; set; }
        public StudentModel Student { get; set; }
        public List<PaperHistoryModel> StudentPaperHistory { get; set; } // for view history function on student portfolio.
        public int CourseID { get; set; }
        public int YearID { get; set; }
        public HttpPostedFileBase File { get; set; }
    }
}
