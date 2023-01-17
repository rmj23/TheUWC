namespace Source.Models
{
    public class ProjectEvaluationScoresModel
    {
        public int Id { get; set; }
        public int projectEvaluationId { get; set; }
        public int characteristicId { get; set; }
        public int elementId { get; set; }
        public int proficiencyId { get; set; }
    }

    public static class ProjectEvaluationScoresModelDb
    {

        // delete all

        //private static SqlConnection conn;
        //private static SqlCommand cmd;

        //public static void ProjectEvaluationScoresInsert(int projectEvaluationId, int characteristicId, int elementId, int proficiencyId, int score)
        //{
        //    conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    cmd = new SqlCommand("ProjectEvaluationScoresInsert", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@projectEvaluationId", projectEvaluationId);
        //    cmd.Parameters.AddWithValue("@characteristicId", characteristicId);
        //    cmd.Parameters.AddWithValue("@elementId", elementId);
        //    cmd.Parameters.AddWithValue("@proficiencyId", proficiencyId);
        //    cmd.Parameters.AddWithValue("@score", score);
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