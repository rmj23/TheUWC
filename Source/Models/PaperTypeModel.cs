using System.Collections.Generic;
using System.Web.Mvc;

namespace Source.Models
{
    public class PaperTypeModel
    {
        public int ID { get; set; }
        public string paperType { get; set; }
    }
    // public static class PaperTypeModelDb
    //{
    //    public static List<PaperTypeModel> SelectAll()
    //    {
    //        List<PaperTypeModel> output = new List<PaperTypeModel>();
    //        SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
    //        SqlCommand cmd = new SqlCommand("PaperTypeSelectAll", conn);
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        try
    //        {
    //            conn.Open();
    //            SqlDataReader dtr = cmd.ExecuteReader();
    //            if (dtr.Read())
    //            {
    //                do
    //                {
    //                    output.Add(new PaperTypeModel()
    //                    {
    //                        ID = Convert.ToInt32(dtr["ID"]),
    //                        paperType = dtr["paperType"].ToString()
    //                    });
    //                } while (dtr.Read());
    //            }
    //        }
    //        catch (SqlException ex)
    //        {
    //            ErrorModelDb.InsertSqlError(ex.ToString());
    //        }
    //        finally
    //        {
    //            conn.Close();
    //        }
    //        return output;
    //    }
    //}

    public static class PaperTypeModelControls
    {
        public static List<SelectListItem> GetSelectListItems(List<PaperTypeModel> models)
        {
            List<SelectListItem> output = new List<SelectListItem>();
            output.Add(new SelectListItem()
            {
                Text = "Please Select a Paper Type",
                Value = "-1"
            });
            foreach (PaperTypeModel model in models)
            {
                output.Add(new SelectListItem()
                {
                    Text = model.paperType,
                    Value = model.ID.ToString()
                });
            }
            return output;
        }

        public static List<SelectListItem> GetSelectListItems(List<PaperTypeModel> models, bool hasSelect)
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