using Source.Data;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Source.Models
{
    public class EmailTeacherBySchoolViewModel
    {
        public int schoolId { get; set; }
        public List<TeacherModel> teachers { get; set; }
        public List<SelectListItem> schools { get; set; }
        public String emailMessage { get; set; }

        public EmailTeacherBySchoolViewModel(int? schoolId)
        {
            Repository repo = new Repository();

            schools = SchoolModelControls.GetSelectListItems(repo.SchoolModelSelectAll(), true);
            if (null != schoolId)
            {
                teachers = repo.TeacherModelSelectAllBySchool((int)schoolId);
            }
        }
    }
}