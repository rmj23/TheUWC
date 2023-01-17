using Source.Data;
using System;
using System.Collections.Generic;

namespace Source.Models
{
    /// <summary>
    /// Each jProjectResultsModel
    /// </summary>
    public class ProjectResultsStudentModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StudentId { get; set; }
        public int EvaluationId { get; set; }//ID for the particular entry into project evaluation
        public string Proficiency { get; set; }//Is this proficient for the student
        public string HolisticScore { get; set; }//Overall holistic score held in pe
        public string Comments { get; set; }
        public string StudentFeedback { get; set; }
        //public int EvaluationPeriodId { get; set; }//ID for the month or benchmark month 
        //public string EvaluationPeriod { get; set; }//Name of month or benchmark month
        public DateTime EvaluationDate { get; set; }//Date of evaluation
        public List<ProjectResultsElementModel> ScoredElements { get; set; }//List of the elements that were scored. Contains list of characteristics that were scored
        /// <summary>
        /// Builds the Scored Elements list and its characteristics list based on the student
        /// </summary>
        public void BuildScoreResults()
        {
            Repository repo = new Repository();

            ScoredElements = repo.ProjectResultsElementModelInsertElements(this.EvaluationId);
            foreach (var element in ScoredElements)
            {
                element.CharacteristicResultsList =
                    repo.ProjectResultsCharacteristicModelSelectChar(element.EvaluationId, element.ElementId);
                element.BuildElementScore();
            }

        }
    }

    // delete all


    //public static class ProjectResultsStudentModelDb
    //{
    //public static List<ProjectResultsStudentModel> SelectAllStudents(int groupId)
    //{
    //    List<ProjectResultsStudentModel> output = new List<ProjectResultsStudentModel>();
    //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
    //    SqlCommand cmd = new SqlCommand("ProjectResultsSelectStudents", conn);
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@groupId", groupId);
    //    try
    //    {
    //        conn.Open();
    //        SqlDataReader dtr = cmd.ExecuteReader();
    //        if (dtr.Read())
    //        {
    //            do
    //            {
    //                output.Add(new ProjectResultsStudentModel()
    //                {
    //                    FirstName = dtr["firstName"].ToString(),
    //                    LastName = dtr["lastName"].ToString(),
    //                    StudentId = Convert.ToInt32(dtr["StudentID"]),
    //                    EvaluationId = Convert.ToInt32(dtr["EvaluationID"]),
    //                    Proficiency = dtr["Proficiency"].ToString(),
    //                    HolisticScore = dtr["holisticScore"].ToString(),
    //                    Comments = dtr["comments"].ToString(),
    //                    StudentFeedback = dtr["feedback"].ToString(),
    //                    EvaluationDate = Convert.ToDateTime(dtr["evaluationDate"])
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

    //}
}