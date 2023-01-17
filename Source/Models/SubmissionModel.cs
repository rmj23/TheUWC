using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Source.Models
{
    public class SubmissionModel
    {
        public int PaperID { get; set; }
        public string Comments { get; set; }
        public string StudentFeedback { get; set; }
        public string SubmissionJson { get; set; }
        public List<SubmissionItemModel> submission { get; set; }
        public void convertJson()
        {
            this.submission = JsonConvert.DeserializeObject<List<SubmissionItemModel>>(this.SubmissionJson);
        }
    }
    public class SubmissionItemModel
    {
        public int? evalTypeIndex { get; set; }
        public string gradeLetter { get; set; }
        public int? gradeNumber { get; set; }
        public int? proficiencyTypeID { get; set; }
    }
    public static class SubmissionModelDb
    {
        public static void Insert(SubmissionModel model)
        {
            //TODO: 
            //Table name in rollback method
            //CommandName for cmd
            var insertedIDs = new List<int>();
            var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
            var EvaluationCmd = new SqlCommand("EvaluationInsert", conn);
            EvaluationCmd.CommandType = CommandType.StoredProcedure;
            EvaluationCmd.Parameters.AddWithValue("@paperID", model.PaperID);
            EvaluationCmd.Parameters.AddWithValue("@comments", model.Comments);
            if (model.StudentFeedback != null)
            {
                EvaluationCmd.Parameters.AddWithValue("StudentFeedback", model.StudentFeedback);
            }
            var EvaluationScoresCmd = new SqlCommand("EvaluationScoreInsert", conn);
            EvaluationScoresCmd.CommandType = CommandType.StoredProcedure;
            EvaluationScoresCmd.Parameters.AddWithValue("@ScoreTypeID", "");
            EvaluationScoresCmd.Parameters.AddWithValue("@ScoreData", "");
            EvaluationScoresCmd.Parameters.AddWithValue("@ProficiencyID", "");
            try
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    EvaluationCmd.Transaction = trans;
                    EvaluationScoresCmd.Transaction = trans;
                    try
                    {
                        EvaluationScoresCmd.Parameters.AddWithValue("@EvaluationID", Convert.ToInt32(EvaluationCmd.ExecuteScalar()));
                        foreach (SubmissionItemModel item in model.submission)
                        {
                            if (item.evalTypeIndex == null || item.gradeLetter == null || item.gradeNumber == null || item.proficiencyTypeID == null)
                            { }
                            else
                            {
                                EvaluationScoresCmd.Parameters["@ScoreTypeID"].Value = item.evalTypeIndex;
                                EvaluationScoresCmd.Parameters["@ScoreData"].Value = item.gradeLetter + item.gradeNumber.ToString();
                                EvaluationScoresCmd.Parameters["@ProficiencyID"].Value = item.proficiencyTypeID;
                                EvaluationScoresCmd.ExecuteNonQuery();
                            }
                        }
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        ErrorModelDb.InsertSqlError(ex.ToString());
                    }
                }
            }
            catch (SqlException ex)
            {
                ErrorModelDb.InsertSqlError(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        public static SubmissionModel SelectOne(int paperID)
        {
            SubmissionModel output = new SubmissionModel();
            var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
            var cmd = new SqlCommand("SubmissionSelectOne", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PaperID", paperID);
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    output.PaperID = Convert.ToInt32(reader["PaperID"]);
                    output.StudentFeedback = reader["StudentFeedback"].ToString();
                    output.submission = new List<SubmissionItemModel>();
                    output.Comments = reader["Comments"].ToString();
                    do
                    {
                        SubmissionItemModel si = new SubmissionItemModel();
                        si.evalTypeIndex = Convert.ToInt32(reader["ScoreTypeID"]);
                        string score = reader["ScoreData"].ToString();
                        si.gradeLetter = score[0].ToString();
                        si.gradeNumber = Convert.ToInt32(score[1].ToString());
                        si.proficiencyTypeID = Convert.ToInt32(reader["ProficiencyTypeID"]);
                        output.submission.Add(si);
                    } while (reader.Read());
                }
            }
            catch (SqlException ex)
            {
                ErrorModelDb.InsertSqlError(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            return output;
        }
    }
}