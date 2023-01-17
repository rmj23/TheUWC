using System.Collections.Generic;
using System.Web.Mvc;

namespace Source.Models
{
    public class DistrictAdminModel : UserModel
    {
        public int DistrictAdminID { get; set; }
    }
    public static class DistrictAdminDB
    {
        //public static DistrictAdminModel SelectOneByUserModel(UserModel userModel)
        //{
        //    DistrictAdminModel output = (DistrictAdminModel)userModel;
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("DistrictAdminSelectByUserID", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@userID", userModel.ID);
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            output.DistrictAdminID = Convert.ToInt32(dtr["ID"]);
        //        }
        //    }
        //    catch
        //    { }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return output;
        //}
    }
    public static class DistrictAdminModelControls
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
    }
}