using System.Collections.Generic;

namespace Source.Models
{
    public class ViewConferenceNotesViewModel
    {
        public ConferenceNotesModel ConferenceNotes { get; set; }
        public List<ConferenceNotesModel> SelectStudentConf { get; set; }

    }
}