using Source.Data;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Source.Models
{
    public class DistrictModelViewModel
    {
        public DistrictModel DistrictModel { get; set; }
        public List<DistrictModel> Districts { get; set; }
        public List<SchoolModel> Schools { get; set; }
        public List<SelectListItem> DistrictSelectList { get; set; }
        public int DistrictID { get; set; }
        public int SchoolID { get; set; }
        public List<UserModel> SchoolAdmins { get; set; }
        public DistrictModelViewModel(int? districtID)
        {
            Repository repo = new Repository();

            if (districtID == null)
            {
                Districts = repo.DistrictSelectAll();
                DistrictSelectList = DistrictModelControls.GetSelectListItems(Districts);
            }
            else
            {
                DistrictModel = repo.DistrictSelectIndividualDistrict((int)districtID);
                Schools = repo.SchoolModelSelectAllByDistrict((int)districtID);
            }

        }
        public DistrictModelViewModel()
        {

        }
    }
}