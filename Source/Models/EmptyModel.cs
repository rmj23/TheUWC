using System.Collections.Generic;
using System.Web.Mvc;

namespace Source.Models
{
    public class EmptyModel
    {
        public static List<SelectListItem> GetSelectListItemsEmpty()
        {
            List<SelectListItem> output = new List<SelectListItem>();
            output.Insert(0, new SelectListItem() { Text = "Please Select", Value = "0", Selected = true });
            return output;
        }
    }
}