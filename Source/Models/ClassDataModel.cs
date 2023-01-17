using Source.Data;
using System;
using System.Collections.Generic;

namespace Source.Models
{
    public class ClassDataModel
    {
        public int ScoreTypeID { get; set; }
        public string ScoreType { get; set; }
        public int CourseID { get; set; }
        public string ScoreData { get; set; }
        public int PaperID { get; set; }
        public string Proficiency { get; set; }
        public int ProficiencyTypeID { get; set; }
        public string PaperTitle { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Draft { get; set; }
        //Student Name-Paper Title-Paper Type - Draft Number
        public int ClassID { get; set; }
        public List<ClassDataComponent> components { get; set; }
        public string NameTitle { get; set; }
        public ClassDataModel()
        {
            Repository repo = new Repository();

            components = new List<ClassDataComponent>();
            List<ProficiencyTypeModel> ptModels = repo.ProficiencyTypeModelSelectAll();
            List<ScoreTypeModel> stModels = repo.ScoreTypeModelSelectAll();
            foreach (ProficiencyTypeModel pt in ptModels)
            {
                foreach (ScoreTypeModel st in stModels)
                {
                    components.Add(new ClassDataComponent()
                    {
                        ScoreType = st,
                        ProfLevel = pt,
                        Students = new List<string>()
                    });
                }
            }
        }
        public ClassDataComponent SelectByIDs(int stId, int ptId)
        {
            // return a list of students given a Score Type ID and a Prof. ID
            ClassDataComponent output = null;
            foreach (var comp in components)
            {
                if (comp.ScoreType.ID == stId && comp.ProfLevel.ID == ptId)
                {
                    output = comp;
                }

            }
            return output;


            //NOT sure if this work. needs testing.      


        }
        public class ClassDataComponent
        {
            public ScoreTypeModel ScoreType { get; set; }
            public ProficiencyTypeModel ProfLevel { get; set; }
            public List<String> Students { get; set; }
        }
    }
    public static class ClassDataModelDB
    {
        //public static List<ClassDataModel> SelectAllByClassID(int ClassID, int EvalPeriodID, int YearID)
        //{
        //    List<ClassDataModel> output = new List<ClassDataModel>();
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("EvaluationScoresSelectAllByCourseIDNew", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@courseID", ClassID);
        //    cmd.Parameters.AddWithValue("@evalPeriodID", EvalPeriodID);
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {
        //                output.Add(new ClassDataModel()
        //                {
        //                    LastName = dtr["lastName"].ToString(),
        //                    FirstName = dtr["firstName"].ToString(),
        //                    PaperTitle = dtr["PaperTitle"].ToString(),
        //                    Draft = Convert.ToInt32(dtr["Draft"]),
        //                    ProficiencyTypeID = Convert.ToInt32(dtr["ProficiencyTypeID"]),
        //                    ScoreTypeID = Convert.ToInt32(dtr["ScoreTypeID"]),
        //                    PaperID = Convert.ToInt32(dtr["PaperID"])
        //                });
        //            } while (dtr.Read());
        //        }
        //    }
        //    catch (Exception ex) {

        //        ErrorModelDb.InsertSqlError(ex.Message.ToString());
        //    }

        //    finally
        //    {
        //        conn.Close();

        //        for (int item = 0; item < output.Count; item++)
        //        {
        //            output[item].NameTitle =output[item].LastName + "," + " " + output[item].FirstName + " - " + output[item].PaperTitle + " - Draft Number: " + output[item].Draft;
        //        }
        //    }
        //    return output;

        //}

    }

}
