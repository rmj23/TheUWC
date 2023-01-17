using Source.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Source.Models
{
    public class StudentUploadPaperViewModel
    {
        public HttpPostedFileBase File { get; set; }
        public PaperModel Paper { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Select a Paper Type")]
        public string PaperTypeID { get; set; }
        public List<SelectListItem> PaperTypeDropdown { get; set; }
        [Required(ErrorMessage = "Please Select an Evaluation Period")]
        public string EvaluationPeriodID { get; set; }
        public List<SelectListItem> EvaluationPeriodDropDown { get; set; }
        [Required(ErrorMessage = "Please Select a Course")]
        public string CourseID { get; set; }
        public List<SelectListItem> CourseDropDown { get; set; }

        //public void BindViewModelElements(int studentID)
        //{
        //    Paper.StudentID = studentID;
        //    Paper.CourseID = (int)CourseID;

        //    if (File == null)
        //    {
        //        Paper.Paper = null;
        //        Paper.FileName = null;
        //    }
        //    else
        //    {
        //        Paper.Paper = new byte[File.InputStream.Length];
        //        File.InputStream.Read(Paper.Paper, 0, Paper.Paper.Length);
        //        Paper.FileName = Path.GetFileName(File.FileName);


        //    }
        //    Paper.uploadDate = DateTime.Now;
        //}


    }
}


