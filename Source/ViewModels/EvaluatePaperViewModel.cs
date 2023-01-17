using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Source.Models
{
    public class EvaluatePaperViewModel
    {
        public List<List<ContinuumModel>> Continuum { get; set; }
        public List<ContinuumLevelModel> Levels { get; set; }
        public List<EvaluationTypeModel> EvaluationTypes { get; set; }
        [Display(Name = "Student Feedback:")]
        public string Feedback { get; set; }
        [Display(Name = "Teacher Comments:")]
        public string Comments { get; set; }
        public List<int> Scores { get; set; } //Logic here is the index of the list is the scoretype/writingtype and the value at that index is the score.
        public List<int> Conventions { get; set; }//Since she wants conventions to be seperate for whatever reason.
        public int Paper_ID { get; set; }
        public int FinalScore { get; set; }
        public int CourseID { get; set; }
        public string StringScores { get; set; }
        public string StudentName { get; set; }
        public StudentModel Student { get; set; }
        public PaperModel Paper { get; set; }
        public bool IsFinal { get; set; }
        public ClassModel ClassInfo { get; set; }


    }
}
