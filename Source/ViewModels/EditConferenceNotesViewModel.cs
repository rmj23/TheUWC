using Source.Data;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Source.Models
{
    public class EditConferenceNotesViewModel
    {
        public ConferenceNotesModel ConferenceNotes { get; set; }
        public List<SelectListItem> StageOrDraft { get; set; }
        public int YearID { get; set; }
        public string StudentName { get; set; }
        public EditConferenceNotesViewModel(ConferenceNotesModel model, int yearID)
        {
            Repository repo = new Repository();

            ConferenceNotes = model;
            var Student = repo.StudentModelSelectOne(ConferenceNotes.StudentID);
            StudentName = Student.FirstName + ' ' + Student.LastName;
            StageOrDraft = ConferenceNotesModelControls.GetSelectListItemsStageOrDraft(repo.ConferenceNotesStageOrDraftSelectAll(), ConferenceNotes.StageOrDraftID);
            YearID = yearID;
        }
        public EditConferenceNotesViewModel() { }

    }
}