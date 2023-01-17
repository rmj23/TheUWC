using System.Collections.Generic;
using System.Web.Mvc;

namespace Source.Models
{
    public class WritingElementModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
    }
    public static class WritingElementModelControls
    {
        public static List<SelectListItem> GetSelectListItems(List<WritingElementModel> models)
        {
            List<SelectListItem> output = new List<SelectListItem>();
            foreach (WritingElementModel model in models)
            {
                output.Add(new SelectListItem()
                {
                    Text = model.Title,
                    Value = model.ID.ToString()
                });
            }
            return output;
        }
        public static List<SelectListItem> GetSelectListItems(List<WritingElementModel> models, bool HasSelect)
        {
            List<SelectListItem> output = new List<SelectListItem>();
            output = GetSelectListItems(models);
            foreach (SelectListItem item in output)
            {
                item.Selected = false;
            }
            output.Insert(0, new SelectListItem() { Text = "Please Select", Value = "0", Selected = true });
            return output;
        }

    }
}