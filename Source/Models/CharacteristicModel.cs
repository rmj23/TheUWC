using System.Collections.Generic;
using System.Web.Mvc;

namespace Source.Models
{
    public class CharacteristicModel
    {
        public int ID { get; set; }
        public string Characteristic { get; set; }
        public string Element { get; set; }
        public int ElementID { get; set; }
    }
    public static class CharacteristicModelDb
    {
        //public static List<CharacteristicModel> SelectAllByElementID(int elementID)
        //{
        //    List<CharacteristicModel> output = new List<CharacteristicModel>();
        //    var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    var cmd = new SqlCommand("CharacteristicSelectbyElementID", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@elementID", elementID);
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        while (dtr.Read())
        //        {
        //            output.Add(new CharacteristicModel()
        //            {
        //                ID = Convert.ToInt32(dtr["ID"]),
        //                Characteristic = dtr["Characteristic"].ToString(),
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

        //internal static List<CharacteristicModel> SelectAll()
        //{
        //    List<CharacteristicModel> output = new List<CharacteristicModel>();
        //    var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    var cmd = new SqlCommand("CharacteristicSelectAll", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        while (dtr.Read())
        //        {
        //            output.Add(new CharacteristicModel()
        //            {
        //                ID = Convert.ToInt32(dtr["ID"]),
        //                Characteristic = dtr["Characteristic"].ToString(),
        //                Element = dtr["Element"].ToString(),
        //                ElementID = Convert.ToInt32(dtr["ElementID"])
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
    }
    public static class CharacteristicModelControls
    {
        public static List<SelectListItem> GetSelectListItems(List<CharacteristicModel> models)
        {
            List<SelectListItem> output = new List<SelectListItem>();
            foreach (CharacteristicModel model in models)
            {
                output.Add(new SelectListItem()
                {
                    Text = model.Characteristic,
                    Value = model.ID.ToString()
                });
            }
            return output;
        }
        public static List<SelectListItem> GetSelectListItems(List<CharacteristicModel> models, bool HasSelect)
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