using Source.Data;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Source.Models
{
    public class EditScoreViewModel
    {
        public int PaperID { get; set; }
        public int GradeID { get; set; }
        public EvaluationScoreModel Score { get; set; }
        public List<SelectListItem> ProficiencyLevels { get; set; }
        public EditScoreViewModel(int? EvaluationScoreID, int? EvaluationID)
        {
            Repository repo = new Repository();

            if (EvaluationScoreID != null)
            {
                Score = repo.EvaluationScoreSelectByID((int)EvaluationScoreID);
                ProficiencyLevels = ProficiencyTypeModelControls.GetSelectList(repo.ProficiencyTypeModelSelectAll());
            }
            if (EvaluationID != null)
            {
                Score = repo.EvaluationScoreGetCommentsandFeedback((int)EvaluationID);
            }

        }
        public EditScoreViewModel()
        {

        }
    }
}