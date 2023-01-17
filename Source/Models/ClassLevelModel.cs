using System.Collections.Generic;
using System.Web.Mvc;

namespace Source.Models
{
    public class ClassLevelModel
    {
        public int ID { get; set; }
        public string Level { get; set; }
    }
    public static class ClassLevelModelDb
    {
        //public static List<ClassLevelModel> SelectAll()
        //{
        //    var output = new List<ClassLevelModel>();
        //    var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    var cmd = new SqlCommand("ClassLevelSelectAll", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        {
        //            while (dtr.Read())
        //            {
        //                output.Add(new ClassLevelModel()
        //                {
        //                    ID = Convert.ToInt32(dtr["ID"]),
        //                    Level = dtr["Level"].ToString()
        //                });
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        ErrorModelDb.InsertSqlError(ex.ToString());
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return output;
        // }
    }
    public static class ClassLevelControls
    {
        public static List<SelectListItem> GetSelectListItems(List<ClassLevelModel> models)
        {
            List<SelectListItem> output = new List<SelectListItem>();
            foreach (ClassLevelModel model in models)
            {
                output.Add(new SelectListItem()
                {
                    Text = model.Level,
                    Value = model.ID.ToString()
                });
            }
            return output;
        }
        public static List<SelectListItem> GetSelectListItems(List<ClassLevelModel> models, bool HasSelect)
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

