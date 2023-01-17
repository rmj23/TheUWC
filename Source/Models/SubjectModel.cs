using System.Collections.Generic;
using System.Web.Mvc;

namespace Source.Models
{
    public class SubjectModel
    {
        public int ID { get; set; }
        public string Subject { get; set; }
    }

    // delete all


    public static class SubjectModelDb
    {
        //public static List<SubjectModel> SelectAll()
        //{
        //    var output = new List<SubjectModel>();
        //    var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    var cmd = new SqlCommand("SubjectSelectAll", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        {
        //            while (dtr.Read())
        //            {
        //                output.Add(new SubjectModel()
        //                {
        //                    ID = Convert.ToInt32(dtr["ID"]),
        //                    Subject = dtr["Subject"].ToString()
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
        //}
        //public static SubjectModel SelectByID(int subjectID)
        //{
        //    SubjectModel output = new SubjectModel();
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("SubjectSelectByID", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@subjectID", subjectID);
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        {
        //            while (dtr.Read())
        //            {
        //                output.ID = Convert.ToInt32(dtr["ID"]);
        //                output.Subject = dtr["Subject"].ToString();
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        ErrorModelDb.InsertSqlError(ex.ToString());
        //    }
        //    return output;
        //}
    }
    public static class SubjectModelControls
    {
        public static List<SelectListItem> GetSelectListItems(List<SubjectModel> models)
        {
            List<SelectListItem> output = new List<SelectListItem>();
            foreach (SubjectModel model in models)
            {
                output.Add(new SelectListItem()
                {
                    Text = model.Subject,
                    Value = model.ID.ToString()
                });
            }
            return output;
        }
        public static List<SelectListItem> GetSelectListItems(List<SubjectModel> models, bool HasSelect)
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

