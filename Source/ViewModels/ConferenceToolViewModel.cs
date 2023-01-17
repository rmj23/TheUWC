using Source.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Source.Models
{
    public class ConferenceToolViewModel
    {
        public DateTime DateCreated { get; set; }
        private int studentID { get; set; }
        [Required(ErrorMessage = "Please Add Some Brief Infomation")]
        public string ConfToolSpecifics { get; set; }
        public List<ConferenceToolModel> ConferenceOpen { get; set; }

        // CONFERENCE TYPE DROP DOWN
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Select A Type")]
        public string ConferenceTypeID { get; set; }
        public List<SelectListItem> ConferenceTypeDropDown { get; set; }

        // SOURCE DROP DOWN
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Select A Source")]
        public string SourceID { get; set; }
        public List<SelectListItem> SourceDropDown { get; set; }

        // ELEMENT DROP DOWN
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Select An Element")]
        public string ElementID { get; set; }
        public List<SelectListItem> ElementDropDown { get; set; }

        // ROLE HELP DROP DOWN
        [Required(AllowEmptyStrings =false, ErrorMessage = "Please Select A Role")]
        public string RoleID { get; set; }
        public List<SelectListItem> RoleHelpDropDown { get; set; }


        //public ConferenceToolViewModel(int StudentID)
        //{
        //    Repository repo = new Repository();

        //    studentID = StudentID;
        //    //ConferenceTypeDropDown = repo.ConferenceToolSelectAllTypes();
        //    //SourceDropDown = EmptyModel.GetSelectListItemsEmpty();
        //    ElementDropDown = EmptyModel.GetSelectListItemsEmpty();
        //    RoleHelpDropDown = RoleConferenceModelControls.GetSelectListItems(repo.RoleConferenceModelSelectAll(), true);
        //    //ConferenceOpen = repo.ConferenceToolSelectAllByStudentID(studentID);
        //}


        //public void GetSources()
        //{
        //    Repository repo = new Repository();

        //    switch (ConferenceTypeID)
        //    {
        //        //Paper
        //        case 1:
        //           SourceDropDown = PaperModelControls.GetSelectListItems(repo.PaperModelSelectAllByStudent(studentID), true);
        //            ElementDropDown = EvaluationTypeControls.GetSelectListItems(repo.EvaluationSelectAllWithConventions());
        //            ElementDropDown[0].Selected = true;
        //            break;
        //        //Inquiry
        //        case 2:
        //            SourceDropDown = ProjectModelControls.GetSelectListItems(repo.ProjectModelSelectAllByStudent(studentID), true);
        //            ElementDropDown = ElementModelControls.GetSelectListItems(repo.ElementSelectAll(), true);
        //            ElementDropDown[0].Selected = true;
        //            break;
        //    }

        //    if (SourceDropDown == null)
        //    {
        //        SourceDropDown = EmptyModel.GetSelectListItemsEmpty();
        //    }
        //}
    }
}