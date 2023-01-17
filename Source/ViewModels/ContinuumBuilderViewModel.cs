using Source.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;

namespace Source.Models
{
    public class ContinuumBuilderViewModel
    {
        public ContinuumModel Continuum { get; set; }
        [DisplayName("Paper Type")]
        public List<SelectListItem> PaperTypes { get; set; }
        [DisplayName("Element")]
        public List<SelectListItem> EvaluationTypes { get; set; }
        [DisplayName("Level")]
        public List<SelectListItem> Levels { get; set; }
        public List<ContinuumModel> ContinuumData { get; set; }
        public string Guidelines { get; set; }
        public int ContinuumID { get; set; }
        public ContinuumBuilderViewModel()
        {
            Repository repo = new Repository();

            PaperTypes = PaperTypeModelControls.GetSelectListItems(repo.PaperSelectAll());
            EvaluationTypes = EvaluationTypeControls.GetSelectListItems(repo.EvaluationSelectAllWithConventions());
            Levels = ContinuumLevelControls.GetSelectListItems(repo.ContinuumLevelSelectAll());
            ContinuumData = repo.ContinuumViewData();
        }
    }
}
