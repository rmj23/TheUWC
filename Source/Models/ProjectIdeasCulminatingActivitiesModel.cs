using System.ComponentModel.DataAnnotations;

namespace Source.Models
{
    public class ProjectIdeasCulminatingActivitiesModel
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int GradeLevelRangeID { get; set; }
        public string GradeLevels { get; set; }
        [Required]
        public string Idea { get; set; }
        [Required]
        public string Keywords { get; set; }
        public string Type { get; set; }
    }

    // delete all


    public static class ProjectIdeasDb
    {
        //public static void Insert(ProjectIdeasCulminatingActivitiesModel model)
        //{
        //    var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    var cmd = new SqlCommand("ProjectIdeas_CulminatingActivitiesInsert", conn);
        //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@Title", model.Title);
        //    cmd.Parameters.AddWithValue("@GradeLevelRangeID", model.GradeLevelRangeID);
        //    cmd.Parameters.AddWithValue("@Idea", model.Idea);
        //    cmd.Parameters.AddWithValue("@Keywords", model.Keywords);
        //    cmd.Parameters.AddWithValue("@Type", model.Type);
        //    try
        //    {
        //        conn.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch(SqlException ex)
        //    {
        //        ErrorModelDb.InsertSqlError(ex.ToString());
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}
        //public static List<ProjectIdeasCulminatingActivitiesModel> SelectAll()
        //{
        //    List<ProjectIdeasCulminatingActivitiesModel> output = new List<ProjectIdeasCulminatingActivitiesModel>();
        //    var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    var cmd = new SqlCommand("ProjectIdeas_CulminatingActivitiesSelectAll", conn);
        //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {
        //                output.Add(new ProjectIdeasCulminatingActivitiesModel
        //                {
        //                    ID = Convert.ToInt32(dtr["ID"]),
        //                    Title = Convert.ToString(dtr["Title"]),
        //                    GradeLevelRangeID = Convert.ToInt32(dtr["GradeLevelRangeID"]),
        //                    Idea = Convert.ToString(dtr["Idea"]),
        //                    GradeLevels = Convert.ToString(dtr["GradeLevels"]),
        //                    Keywords = Convert.ToString(dtr["Keywords"]),
        //                    Type = Convert.ToString(dtr["Type"])
        //                });

        //            } while (dtr.Read());
        //        }
        //    }
        //    catch(SqlException ex)
        //    {
        //        ErrorModelDb.InsertSqlError(ex.ToString());
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return output;
        //}

        //public static void Update(ProjectIdeasCulminatingActivitiesModel model)
        //{
        //    var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    var cmd = new SqlCommand("ProjectIdeas_CulminatingActivitiesUpdate", conn);
        //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@Title", model.Title);
        //    cmd.Parameters.AddWithValue("@GradeLevelRangeID", model.GradeLevelRangeID);
        //    cmd.Parameters.AddWithValue("@Idea", model.Idea);
        //    cmd.Parameters.AddWithValue("@Keywords", model.Keywords);
        //    cmd.Parameters.AddWithValue("@Type", model.Type);
        //    cmd.Parameters.AddWithValue("@ID", model.ID);
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

        //public static void Delete(ProjectIdeasCulminatingActivitiesModel model)
        //{
        //    var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    var cmd = new SqlCommand("ProjectIdeas_CulminatingActivitiesDelete", conn);
        //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@ID", model.ID);
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