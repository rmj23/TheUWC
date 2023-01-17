using System.Collections.Generic;
using System.Web.Mvc;

namespace Source.Models
{
    public class EvaluationTypeModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
    }
    public static class EvaluationTypeModelDb
    {
        //public static List<EvaluationTypeModel> SelectAll() //Doesnt select Conventions
        //{
        //    List<EvaluationTypeModel> output = new List<EvaluationTypeModel>();
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("ValidEvaluationTypeSelectAll", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {
        //                if (dtr["Title"].ToString() != "Conventions")
        //                {
        //                    output.Add(new EvaluationTypeModel()
        //                    {
        //                        ID = Convert.ToInt32(dtr["ID"]),
        //                        Title = dtr["Title"].ToString()

        //                    });
        //                }                       
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
        //    public static List<EvaluationTypeModel> SelectAllWithConventions() //Selects Conventions
        //    {
        //        List<EvaluationTypeModel> output = new List<EvaluationTypeModel>();
        //        SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //        SqlCommand cmd = new SqlCommand("ValidEvaluationTypeSelectAll", conn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        try
        //        {
        //            conn.Open();
        //            SqlDataReader dtr = cmd.ExecuteReader();
        //            if (dtr.Read())
        //            {
        //                do
        //                {
        //                    output.Add(new EvaluationTypeModel()
        //                    {
        //                        ID = Convert.ToInt32(dtr["ID"]),
        //                        Title = dtr["Title"].ToString()
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
    public static class EvaluationTypeControls
    {
        public static List<SelectListItem> GetSelectListItems(List<EvaluationTypeModel> models)
        {
            List<SelectListItem> output = new List<SelectListItem>();
            output.Add(new SelectListItem()
            {
                Text = "Please Select",
                Value = "0",
                Selected = true
            });
            foreach (EvaluationTypeModel model in models)
            {
                output.Add(new SelectListItem()
                {
                    Text = model.Title,
                    Value = model.ID.ToString()
                });
            }
            return output;
        }
    }
}
