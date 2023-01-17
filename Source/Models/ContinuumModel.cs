using Source.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace Source.Models
{
    public class ContinuumModel //Continuum Model probably isn't the best name for this, because really it's a continuum row, but oh well, I'll change it later.
    {
        public int ContinuumID { get; set; }
        public int LevelID { get; set; }
        public int PaperTypeID { get; set; }
        public int EvaluationTypeID { get; set; }
        [AllowHtml]
        public string Guidelines { get; set; }
        public string PaperType { get; set; }
        public string Letter { get; set; }
        public string Timeframe { get; set; }
        public string Title { get; set; }

        // below needs to get deleted after dapper is finished
        public string EvalTitle { get; set; }
    }
    public static class ContinuumModelFunctions
    {
        public static List<List<ContinuumModel>> BuildContinuum(int PaperTypeID)
        // Data is organized on the DB to appear in A-N order. Function returns a 2-D array, each array contains guidelines for that writing type in the order A-N.
        {
            List<ContinuumModel> IdeasContentGuidelines = new List<ContinuumModel>();
            List<ContinuumModel> OrganizationStructure = new List<ContinuumModel>();
            List<ContinuumModel> VoicePointofView = new List<ContinuumModel>();
            List<ContinuumModel> WordChoice = new List<ContinuumModel>();
            List<ContinuumModel> SentenceStructure = new List<ContinuumModel>();
            List<ContinuumModel> Spelling = new List<ContinuumModel>();
            List<ContinuumModel> Conventions = new List<ContinuumModel>();
            List<ContinuumModel> Usage = new List<ContinuumModel>();
            List<ContinuumModel> Presentation = new List<ContinuumModel>();
            List<ContinuumModel> WritingProcess = new List<ContinuumModel>();
            List<ContinuumModel> Research = new List<ContinuumModel>();
            List<ContinuumModel> Attitude = new List<ContinuumModel>();

            List<List<ContinuumModel>> output = new List<List<ContinuumModel>>();
            Repository repo = new Repository();
            var continuumData = repo.ViewAllContinuumData(PaperTypeID);
            foreach (var row in continuumData)
            {
                var evalType = row.EvaluationTypeID;
                switch (evalType)
                {
                    case 1:
                        IdeasContentGuidelines.Add(new ContinuumModel()
                        {
                            Guidelines = row.Guidelines,
                            PaperType = row.PaperType,
                            Letter = row.Letter,
                            Timeframe = row.Timeframe,
                            EvalTitle = row.EvalTitle
                        });
                        break;
                    case 2:
                        OrganizationStructure.Add(new ContinuumModel()
                        {
                            Guidelines = row.Guidelines,
                            PaperType = row.PaperType,
                            Letter = row.Letter,
                            Timeframe = row.Timeframe,
                            EvalTitle = row.EvalTitle
                        });
                        break;
                    case 3:
                        VoicePointofView.Add(new ContinuumModel()
                        {
                            Guidelines = row.Guidelines,
                            PaperType = row.PaperType,
                            Letter = row.Letter,
                            Timeframe = row.Timeframe,
                            EvalTitle = row.EvalTitle
                        });
                        break;
                    case 4:
                        WordChoice.Add(new ContinuumModel()
                        {
                            Guidelines = row.Guidelines,
                            PaperType = row.PaperType,
                            Letter = row.Letter,
                            Timeframe = row.Timeframe,
                            EvalTitle = row.EvalTitle
                        });
                        break;
                    case 5:
                        SentenceStructure.Add(new ContinuumModel()
                        {
                            Guidelines = row.Guidelines,
                            PaperType = row.PaperType,
                            Letter = row.Letter,
                            Timeframe = row.Timeframe,
                            EvalTitle = row.EvalTitle
                        });
                        break;
                    case 7:
                        Spelling.Add(new ContinuumModel()
                        {
                            Guidelines = row.Guidelines,
                            PaperType = row.PaperType,
                            Letter = row.Letter,
                            Timeframe = row.Timeframe,
                            EvalTitle = row.EvalTitle
                        });
                        break;
                    case 8:
                        Usage.Add(new ContinuumModel()
                        {
                            Guidelines = row.Guidelines,
                            PaperType = row.PaperType,
                            Letter = row.Letter,
                            Timeframe = row.Timeframe,
                            EvalTitle = row.EvalTitle
                        });
                        break;
                    case 9:
                        Presentation.Add(new ContinuumModel()
                        {
                            Guidelines = row.Guidelines,
                            PaperType = row.PaperType,
                            Letter = row.Letter,
                            Timeframe = row.Timeframe,
                            EvalTitle = row.EvalTitle
                        });
                        break;
                    case 10:
                        WritingProcess.Add(new ContinuumModel()
                        {
                            Guidelines = row.Guidelines,
                            PaperType = row.PaperType,
                            Letter = row.Letter,
                            Timeframe = row.Timeframe,
                            EvalTitle = row.EvalTitle
                        });
                        break;
                    case 11:
                        Research.Add(new ContinuumModel()
                        {
                            Guidelines = row.Guidelines,
                            PaperType = row.PaperType,
                            Letter = row.Letter,
                            Timeframe = row.Timeframe,
                            EvalTitle = row.EvalTitle
                        });
                        break;
                    case 12:
                        Attitude.Add(new ContinuumModel()
                        {
                            Guidelines = row.Guidelines,
                            PaperType = row.PaperType,
                            Letter = row.Letter,
                            Timeframe = row.Timeframe,
                            EvalTitle = row.EvalTitle
                        });
                        break;
                    default:
                        break;
                }

            }
            output.Add(IdeasContentGuidelines);
            output.Add(OrganizationStructure);
            output.Add(VoicePointofView);
            output.Add(WordChoice);
            output.Add(SentenceStructure);
            output.Add(Conventions);
            output.Add(Spelling);
            output.Add(Usage);
            output.Add(Presentation);
            output.Add(WritingProcess);
            output.Add(Research);
            output.Add(Attitude);

            return output;

        }
        public static List<int> ScoreDictionaryConversion(List<string> scoreList)
        {
            List<int> scoreIntList = new List<int>();
            Dictionary<string, int> dict = new Dictionary<string, int>(){
                {"0", 0 }, {"A1", 1 }, {"A2", 2 }, {"A3", 3 }, {"B1", 4 }, {"B2", 5 }, {"B3", 6 }, {"C1", 7 }, {"C2", 8 }, {"C3", 9 },
                {"D1", 10 }, {"D2", 11 }, {"D3", 12 }, {"E1", 13 }, {"E2", 14 }, {"E3", 15 }, {"F1", 16 }, {"F2", 17 }, {"F3", 18 },
                {"G1", 19 }, {"G2", 20 }, {"G3", 21 }, {"H1", 22 }, {"H2", 23 }, {"H3", 24 }, {"I1", 25 }, {"I2", 26 }, {"I3", 27 },
                {"J1", 28 }, {"J2", 29 }, {"J3", 30 }, {"K1", 31 }, {"K2", 32 }, {"K3", 33 }, {"L1", 34 }, {"L2", 35 }, {"L3", 36 },
                {"M1", 37 }, {"M2", 38 }, {"M3", 39 }, {"N1", 40 }, {"N2", 41 }, {"N3", 42 }
            };
            for (int i = 0; i < scoreList.Count; i++)
            {
                string tempKey = scoreList[i];
                int tempValue = dict[tempKey];
                scoreIntList.Add(tempValue);
            }
            return scoreIntList;

        }
        static public string ConvertScore(int score)
        {
            List<string> Scores = new List<string>()
            {
                "A1","A2","A3","B1","B2","B3","C1","C2","C3",
                "D1","D2","D3","E1","E2","E3","F1","F2","F3",
                "G1","G2","G3","H1","H2","H3","I1","I2","I3",
                "J1","J2","J3","K1","K2","K3","L1","L2","L3",
                "M1","M2","M3","N1","N2","N3"
            };
            return Scores[score - 1];
        }
        static public int FinalScore(List<int> Scores)
        {
            double score = 0;
            int zeroCounter = 0;
            for (int i = 0; i < Scores.Count; i++)
            {
                score += Scores[i];
                if (Scores[i] == 0)
                {
                    zeroCounter += 1;
                }
            }
            score = Math.Round((score / (Scores.Count - zeroCounter)), 0, MidpointRounding.AwayFromZero);
            return (int)score;
        }
        public static void Score(EvaluatePaperViewModel model) //function to score paper.
        {
            Repository repo = new Repository();

            // Handle convention split issue
            int conventions = 0;
            if (model.Conventions[0] == 0)//If spelling was not scored
            {
                conventions = model.Conventions[1];

            }
            else if (model.Conventions[1] == 0)//If usage was not scored
            {
                conventions = model.Conventions[0];
            }
            else
            {
                for (int i = 0; i < model.Conventions.Count; i++)
                {
                    conventions += model.Conventions[i];
                }
                conventions = conventions / model.Conventions.Count;
            }
            model.Scores.Insert(5, conventions);
            model.Scores.Insert(6, model.Conventions[0]);
            model.Scores.Insert(7, model.Conventions[1]);

            int gradeID = repo.ClassSelectOneByID(model.CourseID).GradeID; // need this later.
            int monthID = repo.PaperModelGetMonthByPaperID(model.Paper_ID);
            SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();
            try
            {
                int EvaluationID = -1;
                SqlCommand cmd = new SqlCommand("EvaluationInsert", conn); // Create a new entry in the evaluation table.
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = trans;
                cmd.Parameters.AddWithValue("@PaperID", model.Paper_ID);
                cmd.Parameters.AddWithValue("@Comments", model.Comments);
                cmd.Parameters.AddWithValue("@StudentFeedback", model.Feedback);
                try
                {
                    EvaluationID = Convert.ToInt32(cmd.ExecuteScalar()); // Get the evaluationID, need this later.
                }
                catch (SqlException ex)
                {
                    ErrorModelDb.InsertSqlError(ex.Message.ToString());
                }
                SqlCommand cmd1 = new SqlCommand("EvaluationScoreInsert", conn); //Insert a score for all of the scoretypes/evaltypes
                cmd1.Transaction = trans;
                cmd1.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < model.Scores.Count; i++) //Iterate through scores and insert a score for each index, unless index is 0.
                {
                    if (model.Scores[i] != 0)
                    {
                        cmd1.Parameters.AddWithValue("@ScoreTypeID", i + 1);
                        cmd1.Parameters.AddWithValue("@EvaluationID", EvaluationID);
                        cmd1.Parameters.AddWithValue("@ScoreData", ConvertScore(model.Scores[i])); //function that takes a score value as an int and converts it to score letter (i.e "A3"), scroll up.
                        cmd1.Parameters.AddWithValue("@ProficiencyID", ContinuumHelperModel.getProficiency(monthID, gradeID, model.Scores[i]));
                        cmd1.Parameters.AddWithValue("@IsFinal", model.IsFinal);
                        try
                        {
                            cmd1.ExecuteNonQuery();
                            cmd1.Parameters.Clear();
                        }
                        catch (SqlException ex)
                        {
                            trans.Rollback();
                            ErrorModelDb.InsertSqlError(ex.ToString());
                        }
                    }
                }
                int finalScore = FinalScore(model.Scores);
                SqlCommand cmd2 = new SqlCommand("ScorePaper", conn); //Update paper to reflect the score
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Transaction = trans;
                cmd2.Parameters.AddWithValue("@PaperID", model.Paper_ID);
                cmd2.Parameters.AddWithValue("@EvaluationID", EvaluationID);
                cmd2.Parameters.AddWithValue("@HolisticScoreLetter", ConvertScore(finalScore)); // compute final score and insert it.
                                                                                                //TODO: Need to figure better way, other than adding one to final Score (What happens when 5?)
                cmd2.Parameters.AddWithValue("@ProficiencyLevel", ContinuumHelperModel.getProficiency(monthID, gradeID, finalScore));
                try
                {
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    trans.Rollback();
                    ErrorModelDb.InsertSqlError(ex.ToString());
                }
            }
            catch (SqlException ex)
            {
                trans.Rollback();
                ErrorModelDb.InsertSqlError(ex.ToString());
            }
            trans.Commit();
            trans.Dispose();
            conn.Close();

        }
    }
}