using System.Collections.Generic;
using System.Web.Mvc;

namespace Source.Models
{
    public class PeriodModel
    {
    }

    public static class PeriodModelControls
    {
        public static List<SelectListItem> GetSelectListItems()
        {
            List<SelectListItem> output = new List<SelectListItem>();
            output.Add(new SelectListItem { Text = "N/A", Value = "0" });
            output.Add(new SelectListItem { Text = "1", Value = "1" });
            output.Add(new SelectListItem { Text = "2", Value = "2" });
            output.Add(new SelectListItem { Text = "3", Value = "3" });
            output.Add(new SelectListItem { Text = "4", Value = "4" });
            output.Add(new SelectListItem { Text = "5", Value = "5" });
            output.Add(new SelectListItem { Text = "6", Value = "6" });
            output.Add(new SelectListItem { Text = "7", Value = "7" });
            output.Add(new SelectListItem { Text = "8", Value = "8" });
            return output;
        }
    }
}