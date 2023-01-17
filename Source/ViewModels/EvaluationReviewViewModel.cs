using Source.Data;
using System.Collections.Generic;

namespace Source.Models
{
    public class EvaluationReviewViewModel
    {
        public StudentModel student { get; set; }
        public PaperModel paper { get; set; }
        public SubmissionModel submission { get; set; }
        public List<ScoreTypeModel> scoreTypes { get; set; }
        public string[,] TableValues { get; set; }
        public EvaluationReviewViewModel()
        {
            Repository repo = new Repository();

            scoreTypes = repo.ScoreTypeModelSelectAll();
        }
        public EvaluationReviewViewModel(int paperID) : this()
        {
            Repository repo = new Repository();

            paper = repo.PaperModelSelectOneByPaperID(paperID);
            student = repo.StudentModelSelectOne(paper.StudentID);
            submission = SubmissionModelDb.SelectOne(paperID);
            TableValues = new string[scoreTypes.Count, 5];
            for (int i = 0; i < TableValues.GetLength(0); i++)
            {
                for (int j = 0; j < TableValues.GetLength(1); j++)
                {
                    TableValues[i, j] = "";
                    foreach (SubmissionItemModel sm in submission.submission)
                    {
                        if (sm.evalTypeIndex == i && sm.proficiencyTypeID + 1 == j)
                        {
                            TableValues[i, j] = sm.gradeLetter + sm.gradeNumber.ToString();
                        }
                    }
                }
            }
        }
    }
}