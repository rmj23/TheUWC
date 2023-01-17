using Source.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Source.Models
{
    public class ClassDataChartViewModel
    {
        //Student Name, Title, Type o writing
        public List<WritingElementModel> WritingElements { get; set; }
        public List<ProficiencyTypeModel> ProficiencyTypes { get; set; }
        public List<string>[] ReportElements { get; set; }
        public int EvaluationPeriodID { get; set; }
        public int CourseID { get; set; }
        public ClassDataChartViewModel()
        {
            Repository repo = new Repository();

            WritingElements = repo.WritingElementSelectAll();
            ProficiencyTypes = repo.ProficiencyTypeModelSelectAll();
            ReportElements = new List<string>[WritingElements.Count * ProficiencyTypes.Count];
            for (int i = 0; i < ReportElements.Length; i++)
            {
                ReportElements[i] = new List<string>();
            }
        }
        public int GetReportElementIndex(int WritingElementID, int ProficiencyTypeID)
        {
            return WritingElementID * ProficiencyTypes.Count + ProficiencyTypeID;
        }
        public void BindReportElements()
        {
            if (EvaluationPeriodID == 0 || CourseID == 0)
                throw new Exception("Must have EvaluationPeriodID and CourseID to bind report elements");
            var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
            var cmd = new SqlCommand("ClassDataChartSelect", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@courseID", CourseID);
            cmd.Parameters.AddWithValue("@evaluationPeriodID", EvaluationPeriodID);
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                {
                    while (reader.Read())
                    {
                        int ProficiencyTypeID = Convert.ToInt32(reader["ProficiencyTypeID"]);
                        int ScoreTypeID = Convert.ToInt32(reader["ScoreTypeID"]);
                        //rePlacement stands for Report Element Placement
                        //rePlacement represents an index in a flattened array
                        int rePlacement = GetReportElementIndex(ScoreTypeID, ProficiencyTypeID);
                        string reString = reader["FirstName"].ToString() + " ";
                        reString += reader["MiddleName"].ToString().Substring(0, 1) + ". "; //Gets middle initial from middle name
                        reString += reader["LastName"].ToString() + " (";
                        reString += reader["PaperTitle"].ToString() + " - ";
                        reString += reader["PaperType"].ToString() + ")";
                        ReportElements[rePlacement].Add(reString);
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
    }
}