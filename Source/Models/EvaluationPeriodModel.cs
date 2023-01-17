using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Source.Models
{
    public class EvaluationPeriodModel
    {
        public int ID { get; set; }
        public string evalDescription { get; set; }
        public int monthOrder { get; set; }
        public int monthConverter { get; set; }
    }
    public static class EvaluationPeriodModelDb
    {
        //public static List<EvaluationPeriodModel> SelectAll()
        //{
        //    List<EvaluationPeriodModel> output = new List<EvaluationPeriodModel>();
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("EvaluationPeriodSelectAll", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {
        //                output.Add(new EvaluationPeriodModel()
        //                {
        //                    ID = Convert.ToInt32(dtr["ID"]),
        //                    evalDescription = dtr["evalDescription"].ToString(),
        //                    monthOrder = Convert.ToInt32(dtr["monthOrder"]),
        //                    monthConverter = Convert.ToInt32(dtr["monthConverter"])
        //                });
        //            } while (dtr.Read());
        //        }
        //    }
        //    catch
        //    {

        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return output;
        //}
        //public static List<EvaluationPeriodModel> SelectAllBenchmark()
        //{
        //    List<EvaluationPeriodModel> output = new List<EvaluationPeriodModel>();
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("EvaluationPeriodSelectAllBenchmark2", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {
        //                output.Add(new EvaluationPeriodModel()
        //                {
        //                    ID = Convert.ToInt32(dtr["ID"]),
        //                    evalDescription = dtr["evalDescription"].ToString(),
        //                    monthOrder = Convert.ToInt32(dtr["monthOrder"]),
        //                    monthConverter = Convert.ToInt32(dtr["monthConverter"])
        //                });
        //            } while (dtr.Read());
        //        }
        //    }
        //    catch
        //    {

        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return output;
        //}
    }
    public static class EvaluationPeriodModelControls
    {
        public static List<SelectListItem> GetSelectListItems(List<EvaluationPeriodModel> models)
        {
            List<SelectListItem> output = new List<SelectListItem>();
            foreach (EvaluationPeriodModel model in models)
            {
                output.Add(new SelectListItem()
                {
                    Text = model.evalDescription,
                    Value = model.ID.ToString()
                });
            }
            return output;
        }
        public static List<SelectListItem> GetSelectListItems(List<EvaluationPeriodModel> models, bool HasSelect)
        {
            var date = DateTime.Now.ToString("MMMM");
            var output = GetSelectListItems(models);
            if (HasSelect)
            {
                foreach (SelectListItem item in output)
                {
                    item.Selected = false;
                }
                if (HasSelect)
                {
                    foreach (SelectListItem item in output)
                    {
                        if (item.Text == date)
                        {
                            item.Selected = true;
                        }
                    }
                }
            }
            return output;
        }
    }
    public static class EvaluationModelControls
    {
        public static List<SelectListItem> GetSelectListItems(List<EvaluationPeriodModel> models)
        {
            List<SelectListItem> output = new List<SelectListItem>();
            foreach (EvaluationPeriodModel model in models)
            {
                output.Add(new SelectListItem()
                {
                    Text = model.evalDescription,
                    Value = model.ID.ToString()
                });
            }
            return output;
        }
        public static List<SelectListItem> GetSelectListItems(List<EvaluationPeriodModel> models, bool HasSelect)
        {
            List<SelectListItem> output = new List<SelectListItem>();
            output = GetSelectListItems(models);
            foreach (SelectListItem item in output)
            {
                item.Selected = false;
            }
            output.Insert(0, new SelectListItem() { Text = "Optional", Value = "0", Selected = true });
            return output;
        }
    }
}
