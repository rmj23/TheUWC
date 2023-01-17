using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Source.Models
{
    public class ViewSchoolViewModel : ADistrictSchoolSelection
    {
        public ViewSchoolViewModel(int? DistrictID)
        {
            DistrictDropDown = DistrictModelControls.GetSelectListItems(DistrictModelDb.SelectAll());
            SchoolDropDown = SchoolModelControls.GetSelectListItems(SchoolModelDB.SelectAllByDistrict((int) DistrictID));
        }
    }
}