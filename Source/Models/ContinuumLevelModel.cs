using System.Collections.Generic;
using System.Web.Mvc;

namespace Source.Models
{
    public class ContinuumLevelModel
    {
        public int ID { get; set; }
        public string Letter { get; set; }
        public string TimeFrame { get; set; }
    }
    public static class ContinuumLevelModelDb
    {
        //public static List<ContinuumLevelModel> SelectAll()
        //{
        //    List<ContinuumLevelModel> output = new List<ContinuumLevelModel>();
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("twcLevelSelectAll", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {
        //                output.Add(new ContinuumLevelModel()
        //                {
        //                    ID = Convert.ToInt32(dtr["ID"]),
        //                    Letter = dtr["Letter"].ToString(),
        //                    TimeFrame = dtr["TimeFrame"].ToString()
        //                });
        //            } while (dtr.Read());
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        ErrorModelDb.InsertSqlError(ex.Message.ToString());
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return output;
        //}
    }
    public static class ContinuumLevelControls
    {
        public static List<SelectListItem> GetSelectListItems(List<ContinuumLevelModel> models)
        {
            List<SelectListItem> output = new List<SelectListItem>();
            foreach (ContinuumLevelModel model in models)
            {
                output.Add(new SelectListItem()
                {
                    Text = model.Letter.ToString() + "-" + model.TimeFrame.ToString(),
                    Value = model.ID.ToString()
                });
            }
            return output;
        }
        public static List<SelectListItem> GetSelectListItems(List<ContinuumLevelModel> models, bool HasSelect)
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






