using Source.Data;
using System.Collections.Generic;

namespace Source.Models
{
    public class MyConferenceNotesViewModel
    {
        public List<ConferenceNotesModel> StudentConferenceNotes { get; set; }
        private int StudentID { get; set; }

        public MyConferenceNotesViewModel(int studentID)
        {
            Repository repo = new Repository();

            StudentID = studentID;
            StudentConferenceNotes = repo.ConferenceNotesSelectNotesByStudentID(StudentID);
        }
    }
}