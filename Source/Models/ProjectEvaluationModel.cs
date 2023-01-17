using System;

namespace Source.Models
{
    public class ProjectEvaluationModel
    {
        public int Id { get; set; }
        public int projectId { get; set; }
        public int studentId { get; set; }
        public int yearId { get; set; }
        public int proficiencyId { get; set; }
        public string holisticScore { get; set; }
        public DateTime evaluationDate { get; set; }
        public string comments { get; set; }
        public string feedback { get; set; }

        public ProjectEvaluationModel()
        {

        }

    }

    public static class ProjectEvaluationModelDb
    {

        // delete all

        //private static SqlConnection conn;
        //private static SqlCommand cmd;


        //public static int ProjectEvaluationInsert(ProjectEvaluationModel model)
        //{
        //    int output = -1;
        //    conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    cmd = new SqlCommand("ProjectEvaluationInsert", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@projectId", model.projectId);
        //    cmd.Parameters.AddWithValue("@studentId", model.studentId);
        //    cmd.Parameters.AddWithValue("@yearId", model.yearId);
        //    cmd.Parameters.AddWithValue("@proficiencyId", model.proficiencyId);
        //    cmd.Parameters.AddWithValue("@holisticScore", model.holisticScore);
        //    cmd.Parameters.AddWithValue("@evaluationDate", DateTime.Now);
        //    cmd.Parameters.AddWithValue("@comments", model.comments);
        //    cmd.Parameters.AddWithValue("@feedback", model.feedback);
        //    try
        //    {
        //        conn.Open();
        //        output = Convert.ToInt32(cmd.ExecuteScalar());
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

        //public static void InsertHolisticAndProficiency(string holisticScore, int overallProficiency, int projectEvalId)
        //{
        //    conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    cmd = new SqlCommand("ProjectEvaluationInsertHolisticAndProficiency", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@holisticScore", holisticScore);
        //    cmd.Parameters.AddWithValue("@overallProficiency", overallProficiency);
        //    cmd.Parameters.AddWithValue("@projectEvalId", projectEvalId);
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
    }
}
