using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Source.Models
{
    public class ContinuumTypeModel
    {
        public int Id { get; set; }
        public String continuumType { get; set; }

    }
    public static class ContinuumTypeModelDb
    {
        //public static List<ContinuumTypeModel> SelectAll()
        //{
        //    List<ContinuumTypeModel> output = new List<ContinuumTypeModel>();
        //    var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    var cmd = new SqlCommand("ContinuumTypeSelectAll", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {
        //                output.Add(new ContinuumTypeModel()
        //                {
        //                    Id = Convert.ToInt32(dtr["Id"]),
        //                    continuumType = dtr["continuumType"].ToString()
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
    public static class ContinuumTypeModelControls
    {
        public static List<SelectListItem> GetSelectListItems(List<ContinuumTypeModel> models)
        {
            List<SelectListItem> output = new List<SelectListItem>();
            foreach (var model in models)
            {
                output.Add(new SelectListItem()
                {
                    Text = model.continuumType,
                    Value = model.Id.ToString()
                });
            }
            output.Add(new SelectListItem()
            {
                Text = "Please Select",
                Value = "Please Select",
                Selected = true
            });
            return output;
        }
    }
}