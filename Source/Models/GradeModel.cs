using System.Collections.Generic;
using System.Web.Mvc;

namespace Source.Models
{
    public class GradeModel
    {
        public string GradeDescription { get; set; }
        public int GradeID { get; set; }
    }
    public static class GradeModelDb
    {
        //public static List<GradeModel> SelectAll()
        //{
        //    List<GradeModel> output = new List<GradeModel>();
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("GradeSelectAll", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {
        //                output.Add(new GradeModel()
        //                {
        //                    GradeDescription = dtr["gradeDescription"].ToString(),
        //                    GradeID = Convert.ToInt32(dtr["ID"])
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
        //public static GradeModel SelectOneByID(int gradeID)
        //{
        //    GradeModel output = new GradeModel();
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("GradeSelectOneByID", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@gradeID", gradeID);
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        while (dtr.Read())
        //        {
        //            output.GradeID = Convert.ToInt32(dtr["ID"]);
        //            output.GradeDescription = dtr["gradeDescription"].ToString();
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        ErrorModelDb.InsertSqlError(ex.ToString());
        //    }
        //    return output;
        //}
        //public static int SelectIDByPaper(int PaperID)
        //{
        //    int output = 0;
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("GradeSelectByPaper", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@PaperID", PaperID);
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            output = Convert.ToInt32(dtr["gradeID"]);
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
    public static class GradeModelControls
    {
        public static List<SelectListItem> GetSelectListItems(List<GradeModel> models)
        {
            List<SelectListItem> output = new List<SelectListItem>();
            foreach (GradeModel model in models)
            {
                output.Add(new SelectListItem()
                {
                    Value = model.GradeID.ToString(),
                    Text = model.GradeDescription
                });
            }
            return output;
        }
        public static List<SelectListItem> GetSelectListItems(List<GradeModel> models, bool HasSelect)
        {
            var output = GetSelectListItems(models);
            if (HasSelect)
            {
                foreach (SelectListItem item in output)
                {
                    item.Selected = false;
                }
                if (HasSelect)
                {
                    output.Insert(0, new SelectListItem() { Text = "Please Select", Value = "-1", Selected = true });
                }
            }
            return output;
        }
    }
}