using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Source.Models
{
    public class EditClassModel
    {
        public int SelectedGradeID { get; set; }
        public IEnumerable<SelectListItem> GradeDropDown { get; set; }
        public int SelectedYearID { get; set; }
        public IEnumerable<SelectListItem> YearDropDown { get; set; }
        public int SelectedCourseID { get; set; }
        public IEnumerable<SelectListItem> CourseDropDown { get; set; }
        public int SelectedSubjectID { get; set; }
        public IEnumerable<SelectListItem> SubjectDropdown { get; set; }
        public int SelectedPeriodID { get; set; }
        public IEnumerable<SelectListItem> PeriodDropdown { get; set; }
        public int CourseID { get; set; }
        public String CourseTitle { get; set; }
    }
}