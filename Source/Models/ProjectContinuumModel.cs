using System.Web.Mvc;

namespace Source.Models
{
    public class ProjectContinuumModel
    {
        public int Id { get; set; }
        public int ElementID { get; set; }
        public string Elelement { get; set; }
        public string Characteristic { get; set; }
        public int CharacteristicID { get; set; }
        [AllowHtml]
        public string Guideline { get; set; }
        public string Level { get; set; }
        public int LevelID { get; set; }
        public string TimeFrame { get; set; }
    }
    public static class ProjectContinuumModelDb
    {
        //private static SqlCommand cmd;
        // private static SqlConnection conn;
        //private static Dictionary<String, List<ProjectContinuumModel>> characteristicMap;

        // do not delete bottom one only


        //public static List<List<ProjectContinuumModel>> BuildContinuum()
        //{
        //    Repository repo = new Repository();

        //    List<List<ProjectContinuumModel>> output = new List<List<ProjectContinuumModel>>();
        //    characteristicMap = new Dictionary<string, List<ProjectContinuumModel>>();
        //    //Get all the characteristic Id's
        //    List<CharacteristicModel> allCharacteristics = repo.CharacteristicSelectAll();
        //    foreach(var x in allCharacteristics)
        //    {
        //        characteristicMap.Add(x.ID.ToString(), new List<ProjectContinuumModel>());
        //    }
        //    conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    cmd = new SqlCommand("ProjectContinuumSelectAll", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {
        //                String characteristicId = dtr["characteristicID"].ToString();
        //                characteristicMap[characteristicId].Add(new ProjectContinuumModel()
        //                {
        //                    Id = Convert.ToInt32(dtr["ID"]),
        //                    CharacteristicID = Convert.ToInt32(dtr["characteristicId"]),
        //                    Characteristic = dtr["Characteristic"].ToString(),
        //                    Elelement = dtr["Element"].ToString(),
        //                    ElementID = Convert.ToInt32(dtr["elementId"]),
        //                    Guideline = dtr["Guideline"].ToString(),
        //                    Level = dtr["Level"].ToString(),
        //                    TimeFrame = dtr["TimeFrame"].ToString()
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
        //    foreach(KeyValuePair<String, List<ProjectContinuumModel>> entry in characteristicMap)
        //    {
        //        output.Add(entry.Value);
        //    }
        //    return output;
        //}
        //public static void InsertGuideline(int elementID, int characteristicID, int levelID, string guideline)
        //{
        //    conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    cmd = new SqlCommand("ProjectContinuumInsert", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@elementID", elementID);
        //    cmd.Parameters.AddWithValue("@characteristicID", characteristicID);
        //    cmd.Parameters.AddWithValue("@levelID", levelID);
        //    cmd.Parameters.AddWithValue("@guideline", guideline);
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
        //public static void EditContinuum(int continuumID, int elementID, int characteristicID, int levelID, string guideline)
        //{
        //    conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    cmd = new SqlCommand("ProjectContinuumEdit", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@continuumID", continuumID);
        //    cmd.Parameters.AddWithValue("@elementID", elementID);
        //    cmd.Parameters.AddWithValue("@characteristicID", characteristicID);
        //    cmd.Parameters.AddWithValue("@levelID", levelID);
        //    cmd.Parameters.AddWithValue("@guideline", guideline);
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
        //public static void DeleteEntry(int continuumID)
        //{
        //    conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    cmd = new SqlCommand("ProjectContinuumDelete", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@continuumID", continuumID);
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
        //public static ProjectContinuumModel SelectAllByContinuumID(int ContinuumID)
        //{
        //    ProjectContinuumModel output = new ProjectContinuumModel();
        //    conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    cmd = new SqlCommand("ProjectContinuumSelectOneByID", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@continuumID", ContinuumID);
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            output.Id = Convert.ToInt32(dtr["Id"]);
        //            output.Characteristic = dtr["Characteristic"].ToString();
        //            output.CharacteristicID = Convert.ToInt32(dtr["CharacteristicID"]);
        //            output.Elelement = dtr["Element"].ToString();
        //            output.ElementID = Convert.ToInt32(dtr["ElementID"]);
        //            output.Guideline = dtr["Guideline"].ToString();
        //            output.Level = dtr["Level"].ToString();
        //            output.LevelID = Convert.ToInt32(dtr["LevelID"]);
        //            output.TimeFrame = dtr["TimeFrame"].ToString();
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
        //public static int ProjectEvaluationInsert(int projectId, int studentId, int yearId, int proficiencyId, string holisticScore, DateTime evaluationDate, string comments, string feedback)
        //{
        //    int output =-1;
        //    conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    cmd = new SqlCommand("ProjectEvaluationInsert", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@projectId", projectId);
        //    cmd.Parameters.AddWithValue("@studentId", studentId);
        //    cmd.Parameters.AddWithValue("@yearId", yearId);
        //    cmd.Parameters.AddWithValue("@proficiencyId", proficiencyId);
        //    cmd.Parameters.AddWithValue("@holisticScore", holisticScore);
        //    cmd.Parameters.AddWithValue("@evaluationDate", evaluationDate);
        //    cmd.Parameters.AddWithValue("@comments", comments);
        //    cmd.Parameters.AddWithValue("@feedback", feedback);
        //    try
        //    {
        //        conn.Open();
        //        output = Convert.ToInt32(cmd.ExecuteScalar());
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
        //public static List<ProjectContinuumModel> SelectAll()
        //{
        //    List<ProjectContinuumModel> output = new List<ProjectContinuumModel>();
        //    conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    cmd = new SqlCommand("ProjectContinuumSelectAll", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        while (dtr.Read())
        //        {
        //            output.Add(new ProjectContinuumModel()
        //            {
        //                Id = Convert.ToInt32(dtr["Id"]),
        //                Characteristic = dtr["Characteristic"].ToString(),
        //                Elelement = dtr["Element"].ToString(),
        //                Guideline = dtr["Guideline"].ToString(),
        //                Level = dtr["Level"].ToString(),
        //                TimeFrame = dtr["TimeFrame"].ToString()
        //            });
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
}