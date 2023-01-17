using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Source.Models
{
    public class InsertConferenceNotesViewModel
    {
        public int YearID { get; set; }
        public ConferenceNotesModel ConferenceNotes { get; set; }
        public string StudentName { get; set; }
        //SelectListItems have a key value pair. You select all of the Parameters and then assign an ID 
        public List<SelectListItem> ConferenceTypeDescription { get; set; }
        public List<SelectListItem> StageOrDraft { get; set; }
        public DateTime? ReturnDate { get; set; }

    }

}