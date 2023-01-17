using Source.Data;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Source.Models
{
    public class ErrorModelViewModel
    {
        public int ErrorTypeID { get; set; }
        public List<SelectListItem> ErrorTypeDropDown { get; set; }
        public List<ErrorModel> Errors { get; set; }
        public ErrorModelViewModel()
        {
            Repository repo = new Repository();

            ErrorTypeDropDown = repo.ErrorTypeDropDownPop();
        }

        public void ErrorList()
        {
            Repository repo = new Repository();

            Errors = repo.ErrorSelectErrorByType(this.ErrorTypeID);
        }
    }
}