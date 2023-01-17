using System.Collections.Generic;
using System.Web.Mvc;

namespace Source.Models
{
    public class GradeLevelModel
    {
        public int ID { get; set; }
        public string GradeLevelRange { get; set; }
    }
    public static class GradeLevelModelDB
    {
        //public static List<GradeLevelModel> SelectAll()
        //{
        //    List<GradeLevelModel> output = new List<GradeLevelModel>();
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("GradeLevelRangeSelectAll", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {
        //                output.Add(new GradeLevelModel()
        //                {
        //                    ID = Convert.ToInt32(dtr["ID"]),
        //                    GradeLevelRange = dtr["GradeLevelRange"].ToString()
        //                });
        //            } while (dtr.Read());
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
        //}
    }
    public static class GradeLevelModelControls
    {
        public static List<SelectListItem> GetSelectListItems(List<GradeLevelModel> models)
        {
            List<SelectListItem> output = new List<SelectListItem>();
            foreach (var model in models)
            {
                output.Add(new SelectListItem()
                {
                    Text = model.GradeLevelRange,
                    Value = model.ID.ToString()
                });
            }
            return output;
        }
    }
}
