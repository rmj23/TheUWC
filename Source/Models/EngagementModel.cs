using System.Web.Mvc;

namespace Source.Models
{
    public class EngagementModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int GradeLevelRangeID { get; set; }
        public string GradeLevel { get; set; }
        [AllowHtml]
        public string Text { get; set; }
        [AllowHtml]
        public string Keywords { get; set; }
    }
    public static class EngagementModelDB
    {
        //public static void Insert(EngagementModel model)
        //{
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("EngagementInsert", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@title", model.Title);
        //    cmd.Parameters.AddWithValue("@gradeLevelRangeID", model.GradeLevelRangeID);
        //    cmd.Parameters.AddWithValue("@text", model.Text);
        //    cmd.Parameters.AddWithValue("@keywords", model.Keywords);
        //    try
        //    {
        //        conn.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch (SqlException ex)
        //    {
        //        ErrorModelDb.InsertSqlError(ex.ToString());
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}
        //public static void Edit(EngagementModel model)
        //{
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("EngagementsEdit", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@ID", model.ID);
        //    cmd.Parameters.AddWithValue("@Title", model.Title);
        //    cmd.Parameters.AddWithValue("@GradeLevelRangeID", model.GradeLevelRangeID);
        //    cmd.Parameters.AddWithValue("@Text", model.Text);
        //    cmd.Parameters.AddWithValue("@Keywords", model.Keywords);
        //    try
        //    {
        //        conn.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch (SqlException ex)
        //    {
        //        ErrorModelDb.InsertSqlError(ex.ToString());
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}
        //public static List<EngagementModel> SelectAll()
        //{
        //    List<EngagementModel> output = new List<EngagementModel>();
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("EngagementsSelectAll", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {
        //                output.Add(new EngagementModel()
        //                {
        //                    ID = Convert.ToInt32(dtr["ID"]),
        //                    Title = dtr["Title"].ToString(),
        //                    GradeLevelRangeID = Convert.ToInt32(dtr["GradeLevelRangeID"]),
        //                    GradeLevel = dtr["GradeLevelRange"].ToString(),
        //                    Text = dtr["Text"].ToString(),
        //                    Keywords = dtr["Keywords"].ToString()
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
        //public static List<EngagementModel> SelectByGradeLevelRange(int gradeLevelRangeID)
        //{
        //    List<EngagementModel> output = new List<EngagementModel>();
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("EngagementsSelectAllByGradeRange", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@gradeLevelRangeID", gradeLevelRangeID);
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {
        //                output.Add(new EngagementModel()
        //                {
        //                    ID = Convert.ToInt32(dtr["ID"]),
        //                    Title = dtr["Title"].ToString(),
        //                    GradeLevelRangeID = Convert.ToInt32(dtr["GradeLevelRangeID"]),
        //                    GradeLevel = dtr["GradeLevelRange"].ToString(),
        //                    Text = dtr["Text"].ToString(),
        //                    Keywords = dtr["Keywords"].ToString()
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
        //public static EngagementModel SelectOne(int ID)
        //{
        //    EngagementModel output = new EngagementModel();
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("EngagementsSelectByID", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@ID", ID);
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {
        //                output.ID = Convert.ToInt32(dtr["ID"]);
        //                output.Title = dtr["Title"].ToString();
        //                output.GradeLevelRangeID = Convert.ToInt32(dtr["GradeLevelRangeID"]);
        //                output.GradeLevel = dtr["GradeLevelRange"].ToString();
        //                output.Text = dtr["Text"].ToString();
        //                output.Keywords = dtr["Keywords"].ToString();
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
        //public static void Delete(int ID)
        //{
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("EngagementsDelete", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@ID", ID);
        //    try
        //    {
        //        conn.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch (SqlException ex)
        //    {
        //        ErrorModelDb.InsertSqlError(ex.ToString());
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}
    }
}