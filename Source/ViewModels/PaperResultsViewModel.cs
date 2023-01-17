using System.Collections.Generic;

namespace Source.Models
{
    public class PaperResultsViewModel
    {
        public List<PaperResultsModel> Reports = new List<PaperResultsModel>();

        public PaperModel Paper = new PaperModel();
        public string HolisticScore { get; set; }
        public string StudentFeedback { get; set; }
        public string Comments { get; set; }
        public int EvaluationID { get; set; }

    }

}