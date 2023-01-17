using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Source.Models
{

    public class ChartViewModel : AEvalCourseSelectionWithoutNullables
    {
        public List<ClassModel> courses;
        public List<EvaluationPeriodModel> evaluationPeriods;
        public List<paperComponents> papers { get; set; }
        public int EvaluationPeriodID { get; set; }
        public List<int> scores { get; set; }
        public List<List<string>> papersOrdered { get; set; }
        public List<string> percentages { get; set; }
        //public int CourseID { get; set; }
        //public int EvalPeriodID { get; set; }
        //public int YearID { get; set; }


        public ChartViewModel(int CourseID, int EvalPeriodID, int YearID)
        {
            scores = new List<int>() { 0, 0, 0, 0, 0 };
            papers = new List<paperComponents>() { };
            percentages = new List<string>() { };
            papersOrdered = new List<List<string>>() { new List<string>() { }, new List<string>() { }, new List<string>() { }, new List<string>() { }, new List<string>() { } };
            ChartViewModelDb(CourseID, EvalPeriodID, YearID);
        }



        public class paperComponents
        {
            public int ProficiencyID { get; set; }
            public string paperInfo { get; set; }
        }

        public void ChartViewModelDb(int CourseID, int EvalPeriodID, int YearID)
        {
            var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
            var cmd = new SqlCommand("PaperDataForChart", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@courseID", CourseID);
            cmd.Parameters.AddWithValue("@evaluationPeriodID", EvalPeriodID);
            cmd.Parameters.AddWithValue("@yearID", YearID);
            try
            {
                conn.Open();
                var dtr = cmd.ExecuteReader();
                {
                    while (dtr.Read())
                    {
                        var paper = new paperComponents();
                        int sc = Convert.ToInt32(dtr["ProficiencyID"]);
                        paper.ProficiencyID = sc;
                        paper.paperInfo = dtr["LastName"].ToString() + "," + " " + dtr["FirstName"].ToString() + " " + dtr["MiddleName"].ToString().Substring(0, 1) + ". " + " - " + dtr["PaperTitle"].ToString() + ", " + dtr["PaperType"].ToString() + ", " + dtr["Draft"].ToString();
                        scores[sc - 1] += 1;
                        papers.Add(paper);
                    }
                }
            }
            catch (Exception ex)
            {

                ErrorModelDb.InsertSqlError(ex.Message.ToString());
            }
            finally { conn.Close(); }

            int x = 0;
            for (int i = 1; i < 6; i++)   // get score data & percentages
            {
                float numer = scores[i - 1];
                float count = papers.Count();
                float raw = numer / count;
                string percentage = raw.ToString("00%");
                percentages.Add(percentage);
                foreach (var paper in papers.Where(n => n.ProficiencyID == i))
                {
                    papersOrdered[x].Add(paper.paperInfo.ToString());
                }
                x += 1;
            }
        }
    }
}