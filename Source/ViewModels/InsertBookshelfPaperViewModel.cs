using System.Collections.Generic;
using System.Web.Mvc;

namespace Source.Models
{
    public class InsertBookshelfPaperViewModel
    {
        public List<SelectListItem> EligiblePapers { get; set; }
        public int ContentId { get; set; }
        public int PaperId { get; set; }
        public List<SelectListItem> ContentTypes { get; set; }
        public int StudentId { get; set; }

        public InsertBookshelfPaperViewModel(int studentId)
        {
            this.StudentId = studentId;

        }
        public InsertBookshelfPaperViewModel()
        {

        }
    }
}