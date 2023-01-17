using System;
using System.Collections.Generic;

namespace Source.Models
{
    public class ProjectResultsElementModel
    {
        public int EvaluationId { get; set; }
        public int ElementId { get; set; }
        public string ElementName { get; set; }//Element name i.e. Knowledge Seeking, Leadership and Ethical Behavior, etc...
        public int ElementScore { get; set; }//Particular integer score for that element
        public string ElementHolisticScore { get; set; }//Conversion of ElementScore into holistic score
        public List<ProjectResultsCharacteristicModel> CharacteristicResultsList { get; set; }//List of characteristics that make up the element
        /// <summary>
        /// The CharacteristicResultsList MUST be built out prior to calling this. The element score and holistic score is not stored in the DB.
        /// Take the individual characteristics and compute what the overall element score is, then compute the holistic score based off of that
        /// </summary>
        public void BuildElementScore()
        {
            var score = 0;
            foreach (var characteristic in CharacteristicResultsList)
            {
                score += characteristic.CharacteristicScore;
            }
            ElementScore = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(score / CharacteristicResultsList.Count)));
            ElementHolisticScore = GetHolisticScore(ElementScore);
        }
        public static string GetHolisticScore(int score)
        {
            Dictionary<int, String> scoreMap = new Dictionary<int, String>()
            {
                {0, null }, {1, "A1"}, {2, "A2"}, {3, "A3"}, {4, "B1"}, {5, "B2"}, {6, "B3"},
                {7, "C1" }, {8, "C2"}, {9, "C3"}, {10, "D1"}, {11, "D2"}, {12, "D3"}, {13, "E1"},
                {14, "E2" }, {15, "E3"}, {16, "F1"}, {17, "F2"}, {18, "F3"}, {19, "G1"}, {20, "G2"},
                {21, "G3" }, {22, "H1"}, {23, "H2"}, {24, "H3"}, {25, "I1"}, {26, "I2"}, {27, "I3"},
                {28, "J1" }, {29, "J2"}, {30, "J3"}, {31, "K1"}, {32, "K2"}, {33, "K3"}, {34, "L1"},
                {35, "L2" }, {36, "L3"}, {37, "M1"}, {38, "M2"}, {39, "M3"}, {40, "N1"}, {41, "N2"},
                {42, "N3" }
            };
            string result;
            if (scoreMap.TryGetValue(score, out result))
            {
                return result;
            }
            else
            {
                return "NULL";
            }
        }
    }

    public static class ProjectResultsElementModelDb
    {
        //public static List<ProjectResultsElementModel> InsertElements(int evalId)
        //{
        //    List<ProjectResultsElementModel> output = new List<ProjectResultsElementModel>();
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("ProjectResultsSelectElements", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@evaluationID", evalId);
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {
        //                output.Add(new ProjectResultsElementModel()
        //                {
        //                    EvaluationId = evalId,
        //                    ElementId = Convert.ToInt32(dtr["elementId"]),
        //                    ElementName = dtr["Element"].ToString()
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