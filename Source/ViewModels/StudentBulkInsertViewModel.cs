using Source.Data;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Source.Models
{
    public class StudentBulkInsertViewModel
    {
        public int SchoolID { get; set; }
        public SchoolModel School { get; set; }
        public List<SelectListItem> Schools { get; set; }
        public StudentBulkInsertViewModel()
        {
            Repository repo = new Repository();
            Schools = SchoolModelControls.GetSelectListItems(repo.SchoolModelSelectAll());
        }

    }
}