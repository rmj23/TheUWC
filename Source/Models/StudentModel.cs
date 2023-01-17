using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Source.Models
{
    public class StudentModel : UserModel
    {
        public int StudentID { get; set; }

        [Required(ErrorMessage = "Student Number is required")]
        public string StudentNumber { get; set; }
        public int UserID { get; set; }
        public int CourseID { get; set; }

        public StudentModel()
        {
        }
        public StudentModel(UserModel model)
        {
            this.Active = model.Active;
            this.DistrictID = model.DistrictID;
            this.Email = model.Email;
            this.FirstName = model.FirstName;
            this.Gender = model.Gender;
            this.ID = model.ID;
            this.LastName = model.LastName;
            this.MiddleName = model.MiddleName;
            this.Participate = model.Participate;
            this.Password = model.Password;
            this.PhoneNumber = model.PhoneNumber;
            this.RoleID = model.RoleID;
            this.SchoolID = model.SchoolID;
            this.TestAccount = model.TestAccount;
            this.Suffix = model.Suffix;
        }
    }



    public static class StudentModelControls
    {
        public static List<SelectListItem> GetSelectListItems(IEnumerable<StudentModel> models)
        {
            List<SelectListItem> output = new List<SelectListItem>();
            foreach (StudentModel model in models)
            {
                output.Add(new SelectListItem()
                {
                    Text = model.FirstName + " " + model.LastName,
                    Value = model.StudentID.ToString()
                });
            }
            return output;
        }
        public static List<SelectListItem> GetSelectListItems(IEnumerable<StudentModel> models, bool HasSelect)
        {

            List<SelectListItem> output = GetSelectListItems(models);

            if (HasSelect)
            {
                foreach (SelectListItem item in output)
                {
                    item.Selected = false;
                }
                output.Insert(0, new SelectListItem() { Text = "Please Select", Value = "-1", Selected = true });
            }
            return output;
        }

    }
}