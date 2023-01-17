using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Source.Models
{
    public class ClassModel
    {
        public int ID { get; set; }
        [StringLength(50)]
        public string CourseTitle { get; set; }
        [StringLength(50)]
        public string CourseDescription { get; set; }
        [Required]
        public int SemesterID { get; set; }
        [Required]
        public int GradeID { get; set; }
        [Required]
        public int YearID { get; set; }
        [Required]
        public int TeacherID { get; set; }
        [Required]
        public int SchoolID { get; set; }
        public int Period { get; set; }
        [Required]
        public int SubjectID { get; set; }

        public int GradeNumber { get; set; }
        public int SemesterType { get; set; }
        public bool IsDefault { get; set; }
    }



    public static class ClassModelControls
    {
        public static List<SelectListItem> GetSelectListItems(List<ClassModel> models)
        {
            List<SelectListItem> output = new List<SelectListItem>();
            foreach (ClassModel model in models)
            {
                output.Add(new SelectListItem()
                {
                    Text = model.CourseTitle,
                    Value = model.ID.ToString()
                });
            }

            return output;
        }

        public static List<SelectListItem> GetSelectListItemsEmpty()
        {
            List<SelectListItem> output = new List<SelectListItem>();
            output.Insert(0, new SelectListItem() { Text = "Please Select", Value = "0", Selected = true });
            return output;
        }

        public static List<SelectListItem> GetSelectListItemsWithAll(List<ClassModel> models)
        {
            List<SelectListItem> output = new List<SelectListItem>();
            foreach (ClassModel model in models)
            {
                output.Add(new SelectListItem()
                {
                    Text = model.CourseTitle,
                    Value = model.ID.ToString()
                });
            }
            foreach (SelectListItem item in output)
            {
                item.Selected = false;
            }
            output.Insert(0, new SelectListItem() { Text = "Please Select", Value = "0", Selected = true });
            output.Insert(1, new SelectListItem() { Text = "All", Value = "-1", Selected = false });
            return output;
        }
        public static List<SelectListItem> GetSelectListItems(List<ClassModel> models, bool HasSelect)
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
        public static List<SelectListItem> GetSelectListItems(List<ClassModel> models, bool hasSelect, int courseId)
        {
            List<SelectListItem> output = new List<SelectListItem>();
            foreach (ClassModel model in models)
            {
                output.Add(new SelectListItem()
                {
                    Text = model.CourseTitle,
                    Value = model.ID.ToString()

                });

            }
            foreach (SelectListItem item in output)
            {
                if (item.Value == courseId.ToString())
                {
                    item.Selected = true;
                }
                else
                {
                    item.Selected = false;
                }
            }
            if (hasSelect)
            {
                output.Insert(0, new SelectListItem() { Text = "Please Select", Value = "0", Selected = false });
            }
            return output;
        }
    }
}