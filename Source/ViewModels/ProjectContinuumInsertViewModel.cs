using Source.Data;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Source.Models
{
    public class ProjectContinuumInsertViewModel : ACharacteristicElementSelectionViewModel
    {
        public List<ElementModel> Elements { get; set; }
        public List<CharacteristicModel> Characteristics { get; set; }
        public List<SelectListItem> LevelDropDown { get; set; }
        public int LevelID { get; set; }
        public string Guideline { get; set; }
        public List<ProjectContinuumModel> ContinuumData { get; set; }

        public ProjectContinuumInsertViewModel()
        {
            Repository repo = new Repository();

            ElementDropDown = ElementModelControls.GetSelectListItems(repo.ElementSelectAll(), false);
            LevelDropDown = ContinuumLevelControls.GetSelectListItems(repo.ContinuumLevelSelectAll(), false);
            CharacteristicDropDown = CharacteristicModelControls.GetSelectListItems(repo.CharacteristicSelectAll(), false);
            ContinuumData = repo.ProjectContinuumModelSelectAll();
            Elements = repo.ElementSelectAll();

        }

        public override void getNewCharacteristics(int elementID)
        {
            Repository repo = new Repository();

            CharacteristicDropDown = CharacteristicModelControls.GetSelectListItems(repo.CharacteristicSelectAllByElementID(elementID), false);
        }
    }
}