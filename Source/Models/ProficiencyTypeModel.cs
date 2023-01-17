using System.Collections.Generic;
using System.Web.Mvc;

namespace Source.Models
{
    public class ProficiencyTypeModel
    {
        public int ID { get; set; }
        public string Proficiency { get; set; }
        public string ProficiencyColor { get; set; }
    }

    // delete all
    public static class ProficiencyTypeModelDb
    {
        //public static List<ProficiencyTypeModel> SelectAll()
        //{
        //    var output = new List<ProficiencyTypeModel>();
        //    var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    var cmd = new SqlCommand("ProficiencyTypeSelectAll", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    try
        //    {
        //        conn.Open();
        //        var reader = cmd.ExecuteReader();
        //        {
        //            while (reader.Read())
        //            {
        //                output.Add(new ProficiencyTypeModel()
        //                {
        //                    ID = Convert.ToInt32(reader["ID"]),
        //                    ProficiencyType = reader["Proficiency"].ToString()
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
    }
    public static class ProficiencyTypeModelControls
    {
        public static List<SelectListItem> GetSelectList(List<ProficiencyTypeModel> models)
        {
            List<SelectListItem> output = new List<SelectListItem>();
            foreach (var model in models)
            {
                output.Add(new SelectListItem()
                {
                    Text = model.Proficiency,
                    Value = model.ID.ToString()
                });
            }
            return output;
        }
    }
}
