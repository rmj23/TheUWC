using System.Collections.Generic;
using System.Web.Mvc;

namespace Source.Models
{
    public class SemesterModel
    {
        public int SemesterID { get; set; }
        public string SemesterDescription { get; set; }
    }

    // delete all
    public static class SemesterModelDb
    {
        //public static List<SemesterModel> SelectAll()
        //{
        //    List<SemesterModel> output = new List<SemesterModel>();
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("SemesterSelectAll", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {
        //                output.Add(new SemesterModel()
        //                {
        //                    SemesterID = Convert.ToInt32(dtr["ID"]),
        //                    semesterDescription = dtr["semesterDescription"].ToString()
        //                });
        //            } while (dtr.Read());
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        ErrorModelDb.InsertSqlError(ex.ToString());
        //    }
        //    conn.Close();
        //    return output;   
        //}
        //    public static SemesterModel SelectByID(int semesterID)
        //    {
        //        SemesterModel output = new SemesterModel();
        //        SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //        SqlCommand cmd = new SqlCommand("SemesterSelectByID", conn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@semesterID", semesterID);
        //        try
        //        {
        //            conn.Open();
        //            SqlDataReader dtr = cmd.ExecuteReader();
        //            while (dtr.Read())
        //            {
        //                output.SemesterID = Convert.ToInt32(dtr["ID"]);
        //                output.semesterDescription = dtr["semesterDescription"].ToString();
        //            }
        //        }
        //        catch (SqlException ex)
        //        {
        //            ErrorModelDb.InsertSqlError(ex.ToString());
        //        }
        //        return output;
        //    }
    }
    public static class SemesterModelControls
    {
        public static List<SelectListItem> GetSelectListItems(List<SemesterModel> models, bool hasSelect)
        {
            List<SelectListItem> output = new List<SelectListItem>();
            foreach (var model in models)
            {
                output.Add(new SelectListItem()
                {
                    Text = model.SemesterDescription.ToString(),
                    Value = model.SemesterID.ToString()
                });
            }
            if (hasSelect)
            {
                output.Insert(0, new SelectListItem() { Text = "Please Select", Value = "0", Selected = true });
            }
            return output;
        }
    }
}