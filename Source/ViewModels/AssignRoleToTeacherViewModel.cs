using Source.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;

namespace Source.Models
{
    public class AssignRoleToTeacherViewModel : ATeacherRoleAssignmentSelection
    {

        public List<TeacherModel> teachersWithNoRoles { get; set; }
        public List<TeacherModel> teachersWithRoles { get; set; }
        [DisplayName("Role")]
        public List<SelectListItem> globalRoles { get; set; }
        [DisplayName("District")]
        public List<SelectListItem> districts { get; set; }
        [DisplayName("School")]
        public List<SelectListItem> schools { get; set; }
        private List<TeacherModel> allTeachers { get; set; }
        public bool readOnly { get; set; }
        private const int unassignedId = 99;

        public AssignRoleToTeacherViewModel()
        {
            Repository repo = new Repository();

            teachersWithNoRoles = new List<TeacherModel>();
            teachersWithRoles = new List<TeacherModel>();
            globalRoles = GlobalRoleModelControls.getSelectListItems(repo.GlobalRoleSelectAll());
            districts = DistrictModelControls.GetSelectListItems(repo.DistrictSelectAll(), true);
            districts.Add(new SelectListItem()
            {
                Text = "All Districts",
                Value = "00"
            });
            schools = SchoolModelControls.GetSelectListItems(repo.SchoolModelSelectAll(), true);
            allTeachers = repo.TeacherModelSelectAll();
        }
        public void updateTeachers()
        {
            Repository repo = new Repository();

            allTeachers = repo.TeacherModelSelectAll();
            if (districtId != 0 && schoolId != 0)
            {
                if (roleId != 0)
                {
                    getTeachersInSchoolRoleSelected();
                }
                else
                {
                    getTeachersInSchoolNoRoleSelected();
                }
            }
            else if (districtId != 0 && schoolId == 0)
            {
                if (roleId != 0)
                {
                    getTeachersInDistrictRoleSelected();
                }
                else
                {
                    getTeachersInDistrictNoRoleSelected();
                }
            }
            else if (districtId == 0 && schoolId == 0)
            {
                if (roleId != 0)
                {
                    getTeachersAllDistrictsRoleSelected();
                }
                else
                {
                    getTeachersAllDistrictsNoRoleSelected();
                }
            }
        }

        public void updateSchools()
        {
            Repository repo = new Repository();

            schools = SchoolModelControls.GetSelectListItems(repo.SchoolModelSelectAllByDistrict(districtId), true);
        }
        private void clearLists()
        {
            if (teachersWithRoles.Count > 0)
            {
                teachersWithRoles.Clear();
            }
            if (teachersWithNoRoles.Count > 0)
            {
                teachersWithNoRoles.Clear();
            }
        }
        private void getTeachersInSchoolRoleSelected()
        {
            clearLists();
            foreach (TeacherModel teacher in allTeachers)
            {
                if (teacher.SchoolID == schoolId && teacher.globalRoleId == roleId)
                {
                    teachersWithRoles.Add(teacher);
                    continue;
                }
                if (teacher.SchoolID == schoolId && teacher.globalRoleId == unassignedId)
                {
                    teachersWithNoRoles.Add(teacher);
                }
            }
        }
        private void getTeachersInSchoolNoRoleSelected()
        {
            clearLists();
            foreach (TeacherModel teacher in allTeachers)
            {
                if (teacher.SchoolID == schoolId && teacher.globalRoleId != unassignedId)
                {
                    teachersWithRoles.Add(teacher);
                    continue;
                }
                if (teacher.SchoolID == schoolId && teacher.globalRoleId == unassignedId)
                {
                    teachersWithNoRoles.Add(teacher);
                }
            }

        }
        private void getTeachersInDistrictRoleSelected()
        {
            clearLists();
            foreach (TeacherModel teacher in allTeachers)
            {
                if (teacher.DistrictID == districtId && teacher.globalRoleId == roleId)
                {
                    teachersWithRoles.Add(teacher);
                    continue;
                }
                if (teacher.DistrictID == districtId && teacher.globalRoleId == unassignedId)
                {
                    teachersWithNoRoles.Add(teacher);
                }
            }
        }
        private void getTeachersInDistrictNoRoleSelected()
        {
            clearLists();
            foreach (TeacherModel teacher in allTeachers)
            {
                if (teacher.DistrictID == districtId && teacher.globalRoleId != unassignedId)
                {
                    teachersWithRoles.Add(teacher);
                    continue;
                }
                if (teacher.DistrictID == districtId && teacher.globalRoleId == unassignedId)
                {
                    teachersWithNoRoles.Add(teacher);
                }

            }
        }
        private void getTeachersAllDistrictsRoleSelected()
        {
            clearLists();
            foreach (TeacherModel teacher in allTeachers)
            {
                if (teacher.globalRoleId == roleId)
                {
                    teachersWithRoles.Add(teacher);
                    continue;
                }
                if (teacher.globalRoleId == unassignedId)
                {
                    teachersWithNoRoles.Add(teacher);
                }
            }
        }
        private void getTeachersAllDistrictsNoRoleSelected()
        {
            foreach (TeacherModel teacher in allTeachers)
            {
                if (teacher.globalRoleId == unassignedId)
                {
                    teachersWithNoRoles.Add(teacher);
                }
            }
        }

    }
}