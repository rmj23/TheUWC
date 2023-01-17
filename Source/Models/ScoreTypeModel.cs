using System.Collections.Generic;
using System.Web.Mvc;

namespace Source.Models
{
    public class ScoreTypeModel
    {
        public int ID { get; set; }
        public string EvaluationType { get; set; }
    }

    // delete all
    public static class ScoreTypeModelDb
    {
        //    public static List<ScoreTypeModel> SelectAll()
        //    {
        //        var output = new List<ScoreTypeModel>();
        //        var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //        var cmd = new SqlCommand("ScoreTypeSelectAll", conn);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        try
        //        {
        //            conn.Open();
        //            var reader = cmd.ExecuteReader();
        //            {
        //                while (reader.Read())
        //                {
        //                    output.Add(new ScoreTypeModel()
        //                    {
        //                        ID = Convert.ToInt32(reader["ID"]),
        //                        EvaluationType = reader["scoreType"].ToString()
        //                    });
        //                }
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
    }
    public static class ScoreTypeModelControl
    {
        public static List<SelectListItem> GetSelectListItems(List<ScoreTypeModel> models)
        {
            List<SelectListItem> output = new List<SelectListItem>();
            foreach (ScoreTypeModel model in models)
            {
                output.Add(new SelectListItem()
                {
                    Text = model.EvaluationType,
                    Value = model.ID.ToString()
                });
            }
            return output;
        }
        public static List<SelectListItem> GetSelectListItems(List<ScoreTypeModel> models, bool HasSelect)
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