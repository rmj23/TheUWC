using System;

namespace Source.Models
{
    public class PaperResultsModel
    {
        public int PaperID { get; set; }
        public int EvaluationID { get; set; }
        public int EvaluationScoresID { get; set; }
        public string PaperTitle { get; set; }
        public int ScoreTypeID { get; set; }
        public string ScoreType { get; set; }
        public string ScoreData { get; set; }
        public string Proficiency { get; set; }
        public string HolisticScoreLetter { get; set; }
        public string EvaluationPeriod { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Comments { get; set; }
        public string StudentFeedback { get; set; }
        public string AssociatedGuideline { get; set; }
        public DateTime? EvaluationDate { get; set; }
        public DateTime? DateScored { get; set; }
        public bool IsFinal { get; set; }
    }
    public static class PaperResultsModelDB
    {
        // LEAVE THIS

        //public static void UpdateScore(PaperResultsModel model)
        //{
        //    var evaluationTypeID = 0;

        //    if (model.ScoreType == "Ideas/Content")
        //    {
        //        evaluationTypeID = 1;
        //    }
        //    if (model.ScoreType == "Organization/Structure")
        //    {
        //        evaluationTypeID = 2;
        //    }
        //    if (model.ScoreType == "Voice/Point of View")
        //    {
        //        evaluationTypeID = 3;
        //    }
        //    if (model.ScoreType == "Word Choice/Description")
        //    {
        //        evaluationTypeID = 4;
        //    }
        //    if (model.ScoreType == "Sentence Structure/Fluency")
        //    {
        //        evaluationTypeID = 5;
        //    }
        //    if (model.ScoreType == "Conventions")
        //    {
        //        evaluationTypeID = 6;
        //    }
        //    if (model.ScoreType == "Spelling")
        //    {
        //        evaluationTypeID = 7;
        //    }
        //    if (model.ScoreType == "Usage/Mechanics")
        //    {
        //        evaluationTypeID = 8;
        //    }
        //    if (model.ScoreType == "Presentation/Publishing")
        //    {
        //        evaluationTypeID = 9;
        //    }
        //    if (model.ScoreType == "WritingProcess")
        //    {
        //        evaluationTypeID = 10;
        //    }
        //    if (model.ScoreType == "Research/Writing to Learn")
        //    {
        //        evaluationTypeID = 11;
        //    }
        //    if (model.ScoreType == "Attitude/Range of Writing")
        //    {
        //        evaluationTypeID = 12;
        //    }
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("PaperResultUpdate", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@ID", model.EvaluationScoreID);
        //    cmd.Parameters.AddWithValue("@scoreTypeID", evaluationTypeID);
        //    cmd.Parameters.AddWithValue("@score", model.ScoreData);
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
        //public static void UpdateHolistic(string comments, string feedback, string holistic, int evaluationID, int paperID)
        //{
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("EvaluationUpdate", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@comments", comments);
        //    cmd.Parameters.AddWithValue("@feedback", feedback);
        //    cmd.Parameters.AddWithValue("@holistic", holistic);
        //    cmd.Parameters.AddWithValue("@evaluationID", evaluationID);
        //    cmd.Parameters.AddWithValue("@paperID", paperID);
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


        // delete this
        //public static List<PaperResultsModel> SelectReport(int PaperID)
        //{
        //    List<PaperResultsModel> output = new List<PaperResultsModel>();
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("PaperResultsSelectAll", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@paperID", PaperID);
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {
        //                output.Add(new PaperResultsModel()
        //                {
        //                    PaperID = Convert.ToInt32(dtr["PaperID"]),
        //                    EvaluationID = Convert.ToInt32(dtr["EvaluationID"]),
        //                    EvaluationScoreID = Convert.ToInt32(dtr["EvaluationScoresID"]),
        //                    PaperTitle = dtr["PaperTitle"].ToString(),
        //                    ScoreType = dtr["scoreType"].ToString(),
        //                    ScoreData = dtr["scoreData"].ToString(),
        //                    Proficiency = dtr["Proficiency"].ToString(),
        //                    HolisticScore = dtr["HolisticScoreLetter"].ToString(),
        //                    EvaluationPeriod = dtr["evalDescription"].ToString(),
        //                    FirstName = dtr["firstName"].ToString(),
        //                    LastName = dtr["lastName"].ToString(),
        //                    Comments = dtr["Comments"].ToString(),
        //                    StudentFeedback = dtr["StudentFeedback"].ToString(),
        //                    AssociatedGuideline = dtr["guidelines"].ToString(),
        //                    DateScored = Convert.ToDateTime(dtr["DateScored"]),
        //                    IsFinal = Convert.ToBoolean(dtr["IsFinal"]),

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
        //public static List<PaperResultsModel> SelectAllStudentFeedback(int studentID)
        //{
        //    List<PaperResultsModel> output = new List<PaperResultsModel>();
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("PaperResultsSelectAllByStudentID", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@studentID", studentID);
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {
        //                output.Add(new PaperResultsModel()
        //                {
        //                    PaperID = Convert.ToInt32(dtr["PaperID"]),
        //                    PaperTitle = dtr["PaperTitle"].ToString(),
        //                    evaluationDate = DBNull.Value.Equals(dtr["EvaluationDate"]) ? (DateTime?)null: Convert.ToDateTime(dtr["EvaluationDate"]),
        //                    StudentFeedback = dtr["StudentFeedback"].ToString()
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

    }
}
