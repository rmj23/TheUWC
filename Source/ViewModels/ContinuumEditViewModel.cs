using Source.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;

namespace Source.Models
{
    public class ContinuumEditViewModel
    {
        public ContinuumModel Continuum { get; set; }
        [DisplayName("Paper Type")]
        public List<SelectListItem> PaperTypes { get; set; }
        [DisplayName("Element")]
        public List<SelectListItem> EvaluationTypes { get; set; }
        [DisplayName("Level")]
        public List<SelectListItem> Levels { get; set; }
        public List<ContinuumModel> ContinuumData { get; set; }
        public ContinuumEditViewModel(int? ContinuumID)
        {
            Repository repo = new Repository();

            PaperTypes = PaperTypeModelControls.GetSelectListItems(repo.PaperSelectAll());
            EvaluationTypes = EvaluationTypeControls.GetSelectListItems(repo.EvaluationSelectAllWithConventions());
            Levels = ContinuumLevelControls.GetSelectListItems(repo.ContinuumLevelSelectAll());
            ContinuumData = repo.ContinuumViewData();
            Continuum = repo.ContinuumSelectAllByContinuumID((int)ContinuumID);
        }
        public ContinuumEditViewModel()
        {

        }
    }
}
