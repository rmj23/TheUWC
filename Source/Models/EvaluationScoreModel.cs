using System;

namespace Source.Models
{
    public class EvaluationScoreModel
    {
        public int ID { get; set; }
        public int ScoreTypeID { get; set; }
        public string ScoreType { get; set; }
        public int EvaluationID { get; set; }
        public string ScoreData { get; set; }
        public int ProficiencyTypeID { get; set; }
        public string Comments { get; set; }
        public string StudentFeedback { get; set; }
        public DateTime? DateScored { get; set; }
        public bool IsFinal { get; set; }
    }
    public static class EvaluationScoreModelDb
    {
        //public static EvaluationScoreModel Select(int ID)
        //{
        //    EvaluationScoreModel output = new EvaluationScoreModel();
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("EvaluationScoresSelectOne", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@ID", ID);
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            output.ID = Convert.ToInt32(dtr["ID"]);
        //            output.ScoreTypeID = Convert.ToInt32(dtr["ScoreTypeID"]);
        //            output.ScoreType = dtr["Title"].ToString();
        //            output.ScoreData = dtr["ScoreData"].ToString();
        //            output.EvaluationID = Convert.ToInt32(dtr["EvaluationID"]);
        //            output.ProficiencyTypeID = Convert.ToInt32(dtr["ProficiencyTypeID"]);
        //            output.IsFinal = Convert.ToBoolean(dtr["IsFinal"]);
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
        //public static void Update(EvaluationScoreModel model, int gradeID)
        //{
        //    //Update proficiency level for new score
        //    List<string> score = new List<string>();
        //    score.Add(model.ScoreData);
        //    List<int> scoreConvert = ContinuumModelDb.ScoreDictionaryConversion(score);
        //    int intScore = scoreConvert[0];
        //    //Get the month of the paper
        //    var monthID = PaperModelDb.GetMonthByEvaluationID(model.EvaluationID);
        //    var proficiencyID = ContinuumHelperModel.getProficiency(monthID, gradeID, intScore);

        //    //Update score
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("EvaluationScoreUpdate", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@ID", model.ID);
        //    cmd.Parameters.AddWithValue("@ScoreData", model.ScoreData);
        //    cmd.Parameters.AddWithValue("@ProficiencyTypeID", proficiencyID);
        //    cmd.Parameters.AddWithValue("@IsFinal", model.IsFinal);
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
        //public static void UpdateCommentsAndFeedback(EvaluationScoreModel model)
        //{
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("EvaluationCommentsandFeedbackUpdate", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@EvaluationID", model.EvaluationID);
        //    cmd.Parameters.AddWithValue("@StudentFeedback", model.StudentFeedback);
        //    cmd.Parameters.AddWithValue("@Comments", model.Comments);
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
        //public static void UpdateConventionScore(EvaluationScoreModel model)
        //{
        //    List<string> ConventionScores = new List<string>();
        //    var spellingScore = "";
        //    var usageScore = "";

        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("EvaluationScoresSelectAllByEvaluationID", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@EvaluationID", model.EvaluationID);
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {
        //                if (Convert.ToInt32(dtr["ScoreTypeID"]) == 7)
        //                {
        //                    spellingScore = dtr["ScoreData"].ToString();
        //                    ConventionScores.Add(spellingScore);
        //                }
        //                if (Convert.ToInt32(dtr["ScoreTypeID"]) == 8)
        //                {
        //                    usageScore = dtr["ScoreData"].ToString();
        //                    ConventionScores.Add(usageScore);
        //                }
        //            }
        //            while (dtr.Read());
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


        //    int ConventionScoreAvg = 0;
        //    List<int> ConventionScoresInt = ContinuumModelDb.ScoreDictionaryConversion(ConventionScores);
        //    for (int i = 0; i < ConventionScoresInt.Count; i++)
        //    {
        //        ConventionScoreAvg += ConventionScoresInt[i];
        //    }
        //    ConventionScoreAvg = ConventionScoreAvg / ConventionScoresInt.Count;

        //    SqlConnection conn2 = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd2 = new SqlCommand("ConventionScoreUpdate", conn2);
        //    cmd2.CommandType = CommandType.StoredProcedure;
        //    cmd2.Parameters.AddWithValue("@EvaluationID", model.EvaluationID);
        //    cmd2.Parameters.AddWithValue("@ScoreData", ContinuumModelDb.ConvertScore(ConventionScoreAvg));
        //    try
        //    {
        //        conn2.Open();
        //        cmd2.ExecuteNonQuery();
        //    }
        //    catch (SqlException ex)
        //    {
        //        ErrorModelDb.InsertSqlError(ex.ToString());
        //    }
        //    finally
        //    {
        //        conn2.Close();
        //    }
        //}
        //public static void UpdateHolisticScore(int EvaluationID, int CourseID)
        //{
        //    Repository repo = new Repository();

        //    List<string> Scores = new List<string>();
        //    List<string> ConventionScores = new List<string>();
        //    var ideasContentScore = "";
        //    var orgStructureScore = "";
        //    var voiceScore = "";
        //    var wordScore = "";
        //    var sentenceScore = "";
        //    var conventionsScore = "";
        //    var spellingScore = "";
        //    var usageScore = "";
        //    var presentationScore = "";
        //    var writingScore = "";
        //    var researchScore = "";
        //    var attitudeScore = "";
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("EvaluationScoresSelectAllByEvaluationID", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@EvaluationID", EvaluationID);
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {
        //                if (Convert.ToInt32(dtr["ScoreTypeID"]) == 1)
        //                {
        //                    ideasContentScore = dtr["ScoreData"].ToString();
        //                    Scores.Add(ideasContentScore);
        //                }
        //                if (Convert.ToInt32(dtr["ScoreTypeID"]) == 2)
        //                {
        //                    orgStructureScore = dtr["ScoreData"].ToString();
        //                    Scores.Add(orgStructureScore);
        //                }
        //                if (Convert.ToInt32(dtr["ScoreTypeID"]) == 3)
        //                {
        //                    voiceScore = dtr["ScoreData"].ToString();
        //                    Scores.Add(voiceScore);
        //                }
        //                if (Convert.ToInt32(dtr["ScoreTypeID"]) == 4)
        //                {
        //                    wordScore = dtr["ScoreData"].ToString();
        //                    Scores.Add(wordScore);
        //                }
        //                if (Convert.ToInt32(dtr["ScoreTypeID"]) == 5)
        //                {
        //                    sentenceScore = dtr["ScoreData"].ToString();
        //                    Scores.Add(sentenceScore);
        //                }
        //                if (Convert.ToInt32(dtr["ScoreTypeID"]) == 6)
        //                {
        //                    conventionsScore = dtr["ScoreData"].ToString();
        //                    Scores.Add(conventionsScore);
        //                }
        //                if (Convert.ToInt32(dtr["ScoreTypeID"]) == 7)
        //                {
        //                    spellingScore = dtr["ScoreData"].ToString();
        //                    //Scores.Add(spellingScore);
        //                }
        //                if (Convert.ToInt32(dtr["ScoreTypeID"]) == 8)
        //                {
        //                    usageScore = dtr["ScoreData"].ToString();
        //                    //Scores.Add(usageScore);
        //                }
        //                if (Convert.ToInt32(dtr["ScoreTypeID"]) == 9)
        //                {
        //                    presentationScore = dtr["ScoreData"].ToString();
        //                    Scores.Add(presentationScore);
        //                }
        //                if (Convert.ToInt32(dtr["ScoreTypeID"]) == 10)
        //                {
        //                    writingScore = dtr["ScoreData"].ToString();
        //                    Scores.Add(writingScore);
        //                }
        //                if (Convert.ToInt32(dtr["ScoreTypeID"]) == 11)
        //                {
        //                    researchScore = dtr["ScoreData"].ToString();
        //                    Scores.Add(researchScore);
        //                }
        //                if (Convert.ToInt32(dtr["ScoreTypeID"]) == 12)
        //                {
        //                    attitudeScore = dtr["ScoreData"].ToString();
        //                    Scores.Add(attitudeScore);
        //                }
        //            }
        //            while (dtr.Read());
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


        //    int holisticInt = 0;
        //    var holisticScore = "";
        //    List<int> intScoresList = ContinuumModelDb.ScoreDictionaryConversion(Scores); //Scores converted to ints
        //    for (int i = 0; i < intScoresList.Count; i++)
        //    {
        //        holisticInt += intScoresList[i];
        //    }
        //    holisticInt = holisticInt / intScoresList.Count;
        //    holisticScore = ContinuumModelDb.ConvertScore(holisticInt);
        //    //Update holistic Band(score)
        //    SqlConnection conn2 = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd2 = new SqlCommand("HolisticScoreUpdate", conn2);
        //    cmd2.CommandType = CommandType.StoredProcedure;
        //    cmd2.Parameters.AddWithValue("@EvaluationID", EvaluationID);
        //    cmd2.Parameters.AddWithValue("@HolisticScore", holisticScore);
        //    try
        //    {
        //        conn2.Open();
        //        cmd2.ExecuteNonQuery();
        //    }
        //    catch (SqlException ex)
        //    {
        //        ErrorModelDb.InsertSqlError(ex.ToString());
        //    }
        //    finally
        //    {
        //        conn2.Close();
        //    }
        //    //Update overall proficiency level     
        //    int proficiencyLevel = repo.ContinuumHelperGetLevelByMonthAndGrade(DateTime.Today.Month, repo.ClassSelectOneByID(CourseID).GradeID);
        //    int newProficiencyLevel = holisticInt / proficiencyLevel;
        //    repo.EvaluationScoreUpdateOverallProficiency(EvaluationID, newProficiencyLevel);


        //}
        //public static EvaluationScoreModel GetCommentsandFeedback(int EvaluationID)
        //{
        //    EvaluationScoreModel output = new EvaluationScoreModel();
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("GetCommentsandFeedback", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@EvaluationID", EvaluationID);
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            output.Comments = dtr["Comments"].ToString();
        //            output.StudentFeedback = dtr["StudentFeedback"].ToString();
        //            output.EvaluationID = Convert.ToInt32(dtr["EvaluationID"]);
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
        //public static int SelectProficienyLevel(int EvaluationID)
        //{
        //    int proficiencyID = 0;
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("EvaluationSelectProficiencyLevel", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@EvaluationID", EvaluationID);
        //    try
        //    {
        //        conn.Open();
        //        proficiencyID = Convert.ToInt32(cmd.ExecuteScalar());
        //    }
        //    catch (SqlException ex)
        //    {
        //        ErrorModelDb.InsertSqlError(ex.ToString());
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return proficiencyID;
        //}
        //public static void UpdateOverallProficiency(int evaluationID, int proficienyLevel)
        //{
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("ProficiencyLevelUpdate", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@EvaluationID", evaluationID);
        //    cmd.Parameters.AddWithValue("@ProficiencyLevel", proficienyLevel);
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