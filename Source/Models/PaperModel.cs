using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Source.Models
{
    public class PaperModel
    {
        public int PaperID { get; set; }
        public int StudentID { get; set; }
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public DateTime uploadDate { get; set; }
        public int paperTypeID { get; set; }
        public byte[] Paper { get; set; }
        public string FileName { get; set; }
        [Required(ErrorMessage = "Paper Title is required")]
        public string PaperTitle { get; set; }
        public int EvaluationID { get; set; }
        public int EvaluationPeriodID { get; set; }
        public string HolisticScoreLetter { get; set; }
        [Required(ErrorMessage = "Please enter a draft number")]
        [Range(0, 10, ErrorMessage = "Draft number must be {1} or less than {2}")]
        public int Draft { get; set; }
        public bool Continuing { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string middleName { get; set; }
        public string evalDescription { get; set; }
        public string paperType { get; set; }
        public DateTime? evaluationDate { get; set; }
        public string ProficiencyLevel { get; set; }
        public int YearID { get; set; }
        public bool IsInBookshelf { get; set; }
    }

    public static class PaperModelControls
    {
        public static List<SelectListItem> GetSelectListItems(List<PaperModel> models)
        {
            List<SelectListItem> output = new List<SelectListItem>();
            foreach (PaperModel model in models)
            {
                output.Add(new SelectListItem()
                {
                    Text = model.PaperTitle,
                    Value = model.PaperID.ToString()
                });
            }
            return output;
        }
        public static List<SelectListItem> GetSelectListItems(List<PaperModel> models, bool HasSelect)
        {
            List<SelectListItem> output = new List<SelectListItem>();
            output = GetSelectListItems(models);
            foreach (SelectListItem item in output)
            {
                item.Selected = false;
            }
            output.Insert(0, new SelectListItem() { Text = "Please Select", Value = "0", Selected = true });
            return output;
        }

    }

}
