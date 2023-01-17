using System.Collections.Generic;
using System.Web.Mvc;

namespace Source.Models
{
    public class AcademicYearModel
    {
        public int ID { get; set; }
        public string SchoolYear { get; set; }
        public bool IsCurrent { get; set; }
    }
    public static class AcademicYearModelDb
    {
        //public static List<AcademicYearModel> SelectAll()
        //{
        //    List<AcademicYearModel> output = new List<AcademicYearModel>();
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("AcademicYearSelectAll", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {
        //                output.Add(new AcademicYearModel()
        //                {
        //                    ID = Convert.ToInt32(dtr["ID"]),
        //                    AcademicYear = dtr["SchoolYear"].ToString(),
        //                    IsCurrent = Convert.ToBoolean(dtr["IsCurrent"])
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
        //public static int SelectCurentYearID()
        //{
        //    var output = 0;
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("SelectCurrentYearID", conn);
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            output = Convert.ToInt32(dtr["ID"]);
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        ErrorModelDb.InsertSqlError(ex.ToString());
        //    }
        //    conn.Close();
        //    return output;
        //}
    }
    public static class AcademicYearModelControls
    {
        public static List<SelectListItem> GetSelectListItems(List<AcademicYearModel> models)
        {
            List<SelectListItem> output = new List<SelectListItem>();
            for (int i = models.Count - 1; i > -1; i--)
            {
                output.Add(new SelectListItem()
                {
                    Text = models[i].SchoolYear,
                    Value = models[i].ID.ToString(),
                    Selected = models[i].IsCurrent
                });

            }
            return output;
        }

        public static List<SelectListItem> GetSelectListItems(List<AcademicYearModel> models, bool HasSelect)
        {
            List<SelectListItem> output = new List<SelectListItem>();
            output = GetSelectListItems(models);
            foreach (SelectListItem item in output)
            {
                item.Selected = false;
            }
            if (HasSelect)
            {
                output.Insert(0, new SelectListItem() { Text = "Please Select", Value = "0", Selected = true });
            }
            return output;
        }
    }
}