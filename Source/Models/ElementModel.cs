using System.Collections.Generic;
using System.Web.Mvc;

namespace Source.Models
{
    public class ElementModel
    {
        public int ID { get; set; }
        public string Element { get; set; }
    }
    public static class ElementModelDb
    {
        //public static List<ElementModel> SelectAll()
        //{
        //    List<ElementModel> output = new List<ElementModel>();
        //    var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    var cmd = new SqlCommand("ElementSelectAll", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        while (dtr.Read())
        //        {
        //            output.Add(new ElementModel()
        //            {
        //                ID = Convert.ToInt32(dtr["ID"]),
        //                Element = dtr["Element"].ToString()
        //            });
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

        //public static int SelectByCharacteristicId(int characteristicId)
        //{
        //    int output = -1;
        //    var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    var cmd = new SqlCommand("ElementGetIDFromCharacteristic", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@characteristicId", characteristicId);
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            output = Convert.ToInt32(dtr["ElementID"]);
        //        }
        //    }
        //    catch(SqlException ex)
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
    public static class ElementModelControls
    {
        public static List<SelectListItem> GetSelectListItems(List<ElementModel> models)
        {
            List<SelectListItem> output = new List<SelectListItem>();
            foreach (ElementModel model in models)
            {
                output.Add(new SelectListItem()
                {
                    Text = model.Element,
                    Value = model.ID.ToString()
                });
            }
            return output;
        }
        public static List<SelectListItem> GetSelectListItems(List<ElementModel> models, bool HasSelect)
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