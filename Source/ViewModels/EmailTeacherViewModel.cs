using Source.Data;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Source.Models
{
    public class EmailTeacherViewModel
    {
        public int subjectId { get; set; }
        public int schoolId { get; set; }
        public int districtId { get; set; }
        public List<TeacherModel> teachers { get; set; }
        public List<SelectListItem> subjects { get; set; }
        public List<SelectListItem> schools { get; set; }
        public List<SelectListItem> districts { get; set; }
        public String emailMessage { get; set; }
        public String emailSubject { get; set; }

        public EmailTeacherViewModel(int? subjectId, int? schoolId, int? districtId)
        {
            Repository repo = new Repository();

            subjects = SubjectModelControls.GetSelectListItems(repo.SubjectModelSelectAll(), true);
            schools = SchoolModelControls.GetSelectListItems(repo.SchoolModelSelectAll(), true);
            districts = DistrictModelControls.GetSelectListItems(repo.DistrictSelectAll(), true);
            if (subjectId != null)
            {
                teachers = repo.TeacherModelSelectAllBySubject((int)subjectId);
            }
            if (schoolId != null)
            {
                teachers = repo.TeacherModelSelectAllBySchool((int)schoolId);
            }
            if (districtId != null)
            {
                teachers = repo.TeacherModelSelectAllByDistrict((int)districtId);
            }


        }
        public EmailTeacherViewModel()
        {

        }
        public void sendEmails()
        {
            Repository repo = new Repository();

            if (subjectId != 0)
            {
                teachers = repo.TeacherModelSelectAllBySubject(subjectId);
            }
            if (schoolId != 0)
            {
                teachers = repo.TeacherModelSelectAllBySchool(schoolId);
            }
            else
            {
                teachers = repo.TeacherModelSelectAllByDistrict(districtId);
            }
            for (int i = 0; i < teachers.Count; i++)
            {
                EmailModelFunctions.Send(teachers[i].Email, emailMessage, emailSubject);
            }
        }
    }
}