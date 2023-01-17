using Source.Data;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Source.Models
{
    public class CourseSemesterViewModel
    {
        public int SubjectID { get; set; }
        public int SemesterID { get; set; }
        public int SchoolID { get; set; }
        public List<CourseSemesterModel> CourseSemesterList { get; set; }
        public List<SelectListItem> SubjectDropDown { get; set; }
        public List<SelectListItem> SemesterDropDown { get; set; }
        public CourseSemesterModel CourseSemesterModel { get; set; }
        public CourseSemesterViewModel(int schoolID)
        {
            Repository repo = new Repository();

            CourseSemesterList = repo.CourseSemesterSelectAll(schoolID);
            SubjectDropDown = SubjectModelControls.GetSelectListItems(repo.SubjectModelSelectAll(), true);
            SemesterDropDown = SemesterModelControls.GetSelectListItems(repo.SemesterModelSelectAll(), true);
            SchoolID = schoolID;
        }
        public CourseSemesterViewModel()
        {
            Repository repo = new Repository();

            SubjectDropDown = SubjectModelControls.GetSelectListItems(repo.SubjectModelSelectAll(), true);
            SemesterDropDown = SemesterModelControls.GetSelectListItems(repo.SemesterModelSelectAll(), true);
        }
    }
}