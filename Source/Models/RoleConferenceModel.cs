using System.Collections.Generic;
using System.Web.Mvc;

namespace Source.Models
{
    public class RoleConferenceModel
    {
        //Role of helper student chooses
        public int RoleID { get; set; }
        //Role (String) of helper student chooses
        public string Role { get; set; }
    }


    // delete all
    public static class RoleConferenceModelDB
    {
        //    public static List<RoleConferenceModel> SelectAll()
        //    {
        //        List<RoleConferenceModel> output = new List<RoleConferenceModel>();
        //        var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //        var cmd = new SqlCommand("ConferenceToolRoleSelectAll", conn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        try
        //        {
        //            conn.Open();
        //            SqlDataReader dtr = cmd.ExecuteReader();
        //            if (dtr.Read())
        //            {
        //                do
        //                {
        //                    output.Add(new RoleConferenceModel
        //                    {
        //                        RoleHelper = dtr["roleDescription"].ToString(),
        //                        RoleHelperID = Convert.ToInt32(dtr["roleID"])
        //                    });
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
    public static class RoleConferenceModelControls
    {
        public static List<SelectListItem> GetSelectListItems(List<RoleConferenceModel> models)
        {
            List<SelectListItem> output = new List<SelectListItem>();
            foreach (RoleConferenceModel model in models)
            {
                output.Add(new SelectListItem()
                {
                    Text = model.Role,
                    Value = model.RoleID.ToString()
                });
            }
            return output;
        }
        public static List<SelectListItem> GetSelectListItems(List<RoleConferenceModel> models, bool HasSelect)
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