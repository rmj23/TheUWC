using System;
using System.Collections.Generic;

namespace Source.Models
{
    public class ProjectResultsCharacteristicModel
    {
        public int EvaluationId { get; set; }
        public int CharacteristicId { get; set; }
        public string CharacteristicName { get; set; }//Name of characteristic i.e. Defining the Task, Locating Information in Print & Media, etc...
        public int CharacteristicScore { get; set; }//Integer representation of the score (stored in DB)
        public string CharacteristicHolisticScore { get; set; }//Holistic Score conversion displayed to the user
        public string Proficiency { get; set; }
        //Not sure if we will be using the next three varibles but putting them here because they will most likely be requested 
        public string AssociatedGradedGuideline { get; set; }//The guideline that the characteristic was scored against
        public string AssociatedProficientGuideline { get; set; }//The guideline that would be considerd proficient (maybe the same as the graded if the student was graded proficient)
        public string AssociatedNextLevelGuideline { get; set; }//The guideline that the student should be trying to meet to acheive the next proficieny level.

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

    // delete all

    //public static class ProjectResultsCharacteristicModelDb
    //{
    //    public static List<ProjectResultsCharacteristicModel> SelectCharacteristics(int evaluationId, int elementId)
    //    {
    //        List<ProjectResultsCharacteristicModel> output = new List<ProjectResultsCharacteristicModel>();
    //        SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
    //        SqlCommand cmd = new SqlCommand("ProjectResultsSelectCharacteristics", conn);
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        cmd.Parameters.AddWithValue("@projectEvaluationId", evaluationId);
    //        cmd.Parameters.AddWithValue("@elementId", elementId);
    //        try
    //        {
    //            conn.Open();
    //            SqlDataReader dtr = cmd.ExecuteReader();
    //            if (dtr.Read())
    //            {
    //                do
    //                {
    //                    output.Add(new ProjectResultsCharacteristicModel()
    //                    {
    //                        EvaluationId = evaluationId,
    //                        CharacteristicId = Convert.ToInt32(dtr["characteristicId"]),
    //                        CharacteristicName = dtr["Characteristic"].ToString(),
    //                        CharacteristicScore = Convert.ToInt32(dtr["score"]),
    //                        Proficiency = dtr["Proficiency"].ToString(),

    //                    });
    //                } while (dtr.Read());
    //            }
    //        }
    //        catch (SqlException ex)
    //        {
    //            ErrorModelDb.InsertSqlError(ex.ToString());
    //        }
    //        finally
    //        {
    //            conn.Close();
    //            //Assign the holistic score
    //            foreach (var characteristic in output)
    //            {
    //                characteristic.CharacteristicHolisticScore = GetHolisticScore(characteristic.CharacteristicScore);
    //            }
    //        }
    //        return output;
    //    }
    //    public static string GetHolisticScore(int score)
    //    {
    //        Dictionary<int, String> scoreMap = new Dictionary<int, String>()
    //        {
    //            {0, null }, {1, "A1"}, {2, "A2"}, {3, "A3"}, {4, "B1"}, {5, "B2"}, {6, "B3"},
    //            {7, "C1" }, {8, "C2"}, {9, "C3"}, {10, "D1"}, {11, "D2"}, {12, "D3"}, {13, "E1"},
    //            {14, "E2" }, {15, "E3"}, {16, "F1"}, {17, "F2"}, {18, "F3"}, {19, "G1"}, {20, "G2"},
    //            {21, "G3" }, {22, "H1"}, {23, "H2"}, {24, "H3"}, {25, "I1"}, {26, "I2"}, {27, "I3"},
    //            {28, "J1" }, {29, "J2"}, {30, "J3"}, {31, "K1"}, {32, "K2"}, {33, "K3"}, {34, "L1"},
    //            {35, "L2" }, {36, "L3"}, {37, "M1"}, {38, "M2"}, {39, "M3"}, {40, "N1"}, {41, "N2"},
    //            {42, "N3" }
    //        };
    //        string result;
    //        if (scoreMap.TryGetValue(score, out result))
    //        {
    //            return result;
    //        }
    //        else
    //        {
    //            return "NULL";
    //        }
    //    }
    //}
}
