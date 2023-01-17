using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Source.Models
{
    public class StudentGoalsModel
    {
        public int UserID { get; set; }
        public int GoalID { get; set; }
        public string GoalPaperTitle { get; set; }
        [Required(ErrorMessage = "Please enter a goal description.")]
        public string Description { get; set; }
        [Display(Name = "Deadline Date")]
        public DateTime? DeadlineDate { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DateFinished { get; set; }
        public int GoalPaperID { get; set; }
        public int StudentCourseID { get; set; }
        public int TeacherID { get; set; }
        public string TeacherFN { get; set; }
        public string TeacherLN { get; set; }
        public int StudentID { get; set; }
        public string StudentFN { get; set; }
        public string StudentLn { get; set; }
        public string GoalScoreType { get; set; }
        public string CourseTitle { get; set; }
        [Required]
        [Range(1, 50, ErrorMessage = "Please choose a writing element.")]
        public int GoalScoreTypeID { get; set; }
        // addded for GoalsSelectByCourse Function
        public string WritingElement { get; set; }
    }
    public static class StudentGoalsModelControls
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
