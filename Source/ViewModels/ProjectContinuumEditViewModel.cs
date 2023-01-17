using Source.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;

namespace Source.Models
{
    public class ProjectContinuumEditViewModel
    {
        public ProjectContinuumModel Continuum { get; set; }
        [DisplayName("Element Type")]
        public List<SelectListItem> ElementTypes { get; set; }
        [DisplayName("Characteristic")]
        public List<SelectListItem> Characteristics { get; set; }
        [DisplayName("Level")]
        public List<SelectListItem> Levels { get; set; }
        public List<ProjectContinuumModel> ContinuumData { get; set; }
        public int ElementID { get; set; }
        public int CharacteristicID { get; set; }
        public int LevelID { get; set; }
        public ProjectContinuumEditViewModel(int? ContinuumID)
        {
            Repository repo = new Repository();

            ElementTypes = ElementModelControls.GetSelectListItems(repo.ElementSelectAll());
            Levels = ContinuumLevelControls.GetSelectListItems(repo.ContinuumLevelSelectAll());
            ContinuumData = repo.ProjectContinuumModelSelectAll();
            Continuum = repo.ProjectContinuumModelSelectByContinuumID((int)ContinuumID);
            Characteristics = CharacteristicModelControls.GetSelectListItems(repo.CharacteristicSelectAllByElementID(Continuum.ElementID));
        }
        public ProjectContinuumEditViewModel()
        {

        }
    }
}