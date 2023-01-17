using System.Collections.Generic;
using System.Web.Mvc;

namespace Source.Models
{
    public class SchoolModel
    {
        public int ID { get; set; }
        public string schoolName { get; set; }
        public int addressID { get; set; }
        public string Phone { get; set; }
        public string schoolCode { get; set; }
        public int districtID { get; set; }
        public bool Period { get; set; }
        public string schoolAdminExt { get; set; }
        public string secretaryLastName { get; set; }
        public string secretaryFirstName { get; set; }
        public string gradeLevels { get; set; }
        public string admin2Phone { get; set; }
        public string admin2Ext { get; set; }

    }

    //delete all
    public static class SchoolModelDB
    {
        //public static List<SchoolModel> SelectAllByDistrict(int DistrictID)
        //{
        //    List<SchoolModel> output = new List<SchoolModel>();
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("SchoolSelectAllByDistrict", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@districtID", DistrictID);
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {

        //                var newModel = new SchoolModel();
        //                newModel.ID = Convert.ToInt32(dtr["ID"]);
        //                newModel.schoolName = dtr["schoolName"].ToString();
        //                newModel.addressID = Convert.ToInt32(dtr["addressID"]);
        //                newModel.Phone = dtr["phone"].ToString();
        //                newModel.schoolCode = dtr["schoolCode"].ToString();
        //                newModel.distrtictID = Convert.ToInt32(dtr["districtID"]);
        //                newModel.Period = Convert.ToBoolean(dtr["period"]);
        //                newModel.schoolAdminExt = dtr["schoolAdminExt"].ToString();
        //                newModel.secretaryLastName = dtr["secretaryLastName"].ToString();
        //                newModel.secretaryFirstName = dtr["secretaryFirstName"].ToString();
        //                newModel.gradeLevels = dtr["gradeLevels"].ToString();
        //                newModel.admin2Phone = dtr["admin2Phone"].ToString();
        //                newModel.admin2Ext = dtr["admin2Ext"].ToString();
        //                output.Add(newModel);
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
        //public static SchoolModel SelectOne(int schoolID)
        //{
        //    SchoolModel output = new SchoolModel();
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("SchoolSelectOne", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@ID", schoolID);
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {

        //                var newModel = new SchoolModel();
        //                output.ID = Convert.ToInt32(dtr["ID"]);
        //                output.schoolName = dtr["schoolName"].ToString();
        //                output.addressID = Convert.ToInt32(dtr["addressID"]);
        //                output.Phone = dtr["phone"].ToString();
        //                output.schoolCode = dtr["schoolCode"].ToString();
        //                output.distrtictID = Convert.ToInt32(dtr["districtID"]);
        //                output.Period = Convert.ToBoolean(dtr["period"]);
        //                output.schoolAdminExt = dtr["schoolAdminExt"].ToString();
        //                output.secretaryLastName = dtr["secretaryLastName"].ToString();
        //                output.secretaryFirstName = dtr["secretaryFirstName"].ToString();
        //                output.gradeLevels = dtr["gradeLevels"].ToString();
        //                output.admin2Phone = dtr["admin2Phone"].ToString();
        //                output.admin2Ext = dtr["admin2Ext"].ToString();
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
        //    public static List<SchoolModel> SelectAll()
        //    {
        //        List<SchoolModel> output = new List<SchoolModel>();
        //        SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //        SqlCommand cmd = new SqlCommand("SchoolSelectAll", conn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        try
        //        {
        //            conn.Open();
        //            SqlDataReader dtr = cmd.ExecuteReader();
        //            if (dtr.Read())
        //            {
        //                do
        //                {

        //                    var newModel = new SchoolModel();
        //                    newModel.ID = Convert.ToInt32(dtr["ID"]);
        //                    newModel.schoolName = dtr["schoolName"].ToString();
        //                    newModel.addressID = Convert.ToInt32(dtr["addressID"]);
        //                    newModel.Phone = dtr["phone"].ToString();
        //                    newModel.schoolCode = dtr["schoolCode"].ToString();
        //                    newModel.distrtictID = Convert.ToInt32(dtr["districtID"]);
        //                    newModel.Period = Convert.ToBoolean(dtr["period"]);
        //                    newModel.schoolAdminExt = dtr["schoolAdminExt"].ToString();
        //                    newModel.secretaryLastName = dtr["secretaryLastName"].ToString();
        //                    newModel.secretaryFirstName = dtr["secretaryFirstName"].ToString();
        //                    newModel.gradeLevels = dtr["gradeLevels"].ToString();
        //                    newModel.admin2Phone = dtr["admin2Phone"].ToString();
        //                    newModel.admin2Ext = dtr["admin2Ext"].ToString();
        //                    output.Add(newModel);
        //                } while (dtr.Read());
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
    public static class SchoolModelControls
    {
        public static List<SelectListItem> GetSelectListItems(List<SchoolModel> models)
        {
            List<SelectListItem> output = new List<SelectListItem>();
            foreach (SchoolModel model in models)
            {
                output.Add(new SelectListItem()
                {
                    Text = model.schoolName,
                    Value = model.ID.ToString()
                });
            }
            return output;
        }
        public static List<SelectListItem> GetSelectListItems(List<SchoolModel> models, bool HasSelect)
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
                    output.Insert(0, new SelectListItem() { Text = "Please Select", Value = "0", Selected = true });
                }
            }
            return output;
        }
    }
}