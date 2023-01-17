using Source.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace Source.Models
{
    // need to remove
    public class UploadPaperViewModel
    {
        //[Required]
        public HttpPostedFileBase File { get; set; }
        public PaperModel Paper { get; set; }
        public int teacherID { get; set; }

        // new one - Ruben
        // Paper Types
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Select a Paper Type")]
        public string PaperTypeID { get; set; }
        public List<SelectListItem> PaperTypeDropdown { get; set; }
        // Evaluation Periods
        [Required(ErrorMessage = "Please Select an Evaluation Period")]
        public string EvaluationPeriodID { get; set; }
        public List<SelectListItem> EvaluationPeriodDropdown { get; set; }
        public void BindViewModelElements()
        {
            //Paper.StudentID = (int)StudentID;
            //Paper.CourseID = (int)CourseID;
            //Paper.YearID = (int) YearID;
            //if (File == null)
            //{
            //    Paper.Paper = null;
            //    Paper.FileName = null;
            //}
            //else
            //{
            //    Paper.Paper = new byte[File.InputStream.Length];
            //    File.InputStream.Read(Paper.Paper, 0, Paper.Paper.Length);
            //    Paper.FileName = Path.GetFileName(File.FileName);
            //}
            //Paper.uploadDate = DateTime.Now;
        }
    }
}
