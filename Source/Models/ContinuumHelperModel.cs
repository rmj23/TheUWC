using Source.Data;
using System;
using System.Collections.Generic;

/*
 * Class that contains all of the helper methods for the writing and inquiry continuums. 
 * 
 */
namespace Source.Models
{
    public class ContinuumHelperModel
    {
        //private static SqlConnection conn;
        //private static SqlCommand cmd;

        public ContinuumHelperModel() { }

        private static Dictionary<int, String> scoreMap = new Dictionary<int, String>()
        {
            {0, null }, {1, "A1"}, {2, "A2"}, {3, "A3"}, {4, "B1"}, {5, "B2"}, {6, "B3"},
            {7, "C1" }, {8, "C2"}, {9, "C3"}, {10, "D1"}, {11, "D2"}, {12, "D3"}, {13, "E1"},
            {14, "E2" }, {15, "E3"}, {16, "F1"}, {17, "F2"}, {18, "F3"}, {19, "G1"}, {20, "G2"},
            {21, "G3" }, {22, "H1"}, {23, "H2"}, {24, "H3"}, {25, "I1"}, {26, "I2"}, {27, "I3"},
            {28, "J1" }, {29, "J2"}, {30, "J3"}, {31, "K1"}, {32, "K2"}, {33, "K3"}, {34, "L1"},
            {35, "L2" }, {36, "L3"}, {37, "M1"}, {38, "M2"}, {39, "M3"}, {40, "N1"}, {41, "N2"},
            {42, "N3" }
        };
        private static Dictionary<String, int> characteristicIdMap = new Dictionary<String, int>()
        {
            {"definingTheTask", 1 }, {"locatingTheInformation", 2}, {"acquiringInformation", 3},
            {"organizingInformation", 4 }, {"analyzingInformation", 5}, {"usingInformation", 6},
            {"respectingIntellectualFreedom", 7 }, {"usingElectronicSources", 8}, {"maintainingIntegrity", 9},
            {"askingHigherLevelQuestions", 10 }, {"thinkingCritically", 11}, {"solvingProblems", 12}, {"presentingInVariousFormats", 13},
            {"consideringAudience", 14}, {"demonstratingCreativity", 15}, {"presentingPerspectives", 16}, {"managingTime", 17},
            {"takingResponsibilty", 18 }, {"evaluatingPersonalDevelopment", 19}, {"selectingResources", 20},
            {"participatingInAGroup", 21 }, {"usingGroupEtiquette", 22}, {"achievingCommonGoals", 23}, {"communicatingEffectively", 24},
            {"showingRespect", 25 }
        };
        public static String convertScore(int intScore)
        {
            return scoreMap[intScore];
        }

        public static String getElementFromCharacteristic(string characteristic)
        {
            return null;
        }

        //public static int GetLevelByMonthAndGrade(int monthID, int gradeID) // Function to get the level that's considered proficient for a specific month and grade.
        //{
        //    int output = 0;
        //    conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    cmd = new SqlCommand("ContinuumProficiencyLevelByMonthandGrade", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@monthID", monthID);
        //    cmd.Parameters.AddWithValue("@gradeID", gradeID);
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        while (dtr.Read())
        //        {
        //            output = Convert.ToInt32(dtr["levelID"]);
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        ErrorModelDb.InsertSqlError(ex.ToString());
        //    }
        //    return output;
        //}
        //Helper function to evaluate Inquiry Continuum.
        public static void InquiryContinuumScore(List<ProjectScoreModel> characteristicScores, ProjectEvaluationModel evaluationModel, int monthId, int gradeId)
        {
            Repository repo = new Repository();

            int sum = 0;
            //Step 1, create entry in ProjectEvaluation table, return ID.
            int projectEvaluationId = repo.ProjectEvalModelInsert(evaluationModel);

            //Step 2, iterate through dictionary, insert each entry into ProjectEvaluationGuideline. Also sum the scores.
            foreach (var item in characteristicScores)
            {
                //place an if here to gaurd against scores of 0
                if (item.ScoreInt > 0)
                {
                    repo.ProjectEvalScoresModelInsert(projectEvaluationId, item.CharacteristicID, getElementIdFromCharacteristic(item.CharacteristicID), getProficiency(monthId, gradeId, item.ScoreInt), item.ScoreInt);
                    sum += item.ScoreInt;
                }
            }
            //Step 3, calculate overall score
            int overallScore = sum / characteristicScores.Count;

            //Step 4, calculate proficiency level for overall score
            int overallProficiency = getProficiency(monthId, gradeId, overallScore);

            // Insert overall proficiency, holistic score.
            String holisticScore = scoreMap[overallScore];
            repo.ProjectEvalModelInsertHolisticAndProficiency(holisticScore, overallProficiency, projectEvaluationId);


        }
        //Get proficiency level for a characteristic score
        public static int getProficiency(int monthId, int gradeId, int characteristicScore)
        {
            Repository repo = new Repository();

            int proficiencyLevelByMonth = repo.ContinuumHelperGetLevelByMonthAndGrade(monthId, gradeId);
            int scoreProficiencyLevel = ProficiencyDictionaryConversion(characteristicScore);
            if (proficiencyLevelByMonth == scoreProficiencyLevel)
            {
                return 3;//Proficient
            }
            else if (proficiencyLevelByMonth == scoreProficiencyLevel + 1)
            {
                return 2;//Basic
            }
            else if (proficiencyLevelByMonth == scoreProficiencyLevel - 1)
            {
                return 4;//Advance
            }
            else if (proficiencyLevelByMonth > scoreProficiencyLevel - 1)
            {
                return 1;//Below Basic
            }
            else if (proficiencyLevelByMonth < scoreProficiencyLevel + 1)
            {
                return 5;//Advance+
            }
            else return 0;
        }

        public static int getElementIdFromCharacteristic(int characteristicId)
        {
            Repository repo = new Repository();

            return repo.ElementSelectByCharacteristicID(characteristicId);
            //ElementModelDb.SelectByCharacteristicId(characteristicId);
        }
        //Converts A Score to a Proficiency Level. 
        public static int ProficiencyDictionaryConversion(int score)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>()
            {
                {0, 0 }, {1, 1 }, {2, 1 }, {3, 1 }, {4, 2 }, {5, 2 }, {6, 2 }, {7, 3 }, {8, 3 }, {9, 3 },
                {10, 4 }, {11, 4 }, {12, 4 }, {13, 5 }, {14, 5 }, {15, 5 }, {16, 6 }, {17, 6 }, {18, 6 },
                {19, 7 }, {20, 7 }, {21, 7 }, {22, 8 }, {23, 8 }, {24, 8 }, {25, 9 }, {26, 9 }, {27, 9 },
                {28, 10 }, {29, 10 }, {30, 10 }, {31, 11 }, {32, 11 }, {33, 11 }, {34, 12 }, {35, 12 }, {36, 12 },
                {37, 13 }, {38, 13 }, {39, 13 }, {40, 14 }, {41, 14 }, {42, 14 }
            };
            int integerRepOfAtN = dict[score];
            return integerRepOfAtN;
        }
    }
}