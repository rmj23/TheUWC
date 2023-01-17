using Source.Data;
using System.Collections.Generic;

namespace Source.Models
{
    public class BenchmarkReportsModel
    {
        public int? courseID { get; set; }
        public int? gradeID { get; set; }
        public int? schoolID { get; set; }
        public int? evalPeriodID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }

        public int ProficiencyID { get; set; }
        public List<BenchmarkReportsComponent> components { get; set; } // (proficiency, [students])

        public class BenchmarkReportsComponent
        {
            public ProficiencyTypeModel ProfLevel { get; set; }
            public List<string> Students { get; set; }
        }

        public BenchmarkReportsModel()
        {
            Repository repo = new Repository();

            components = new List<BenchmarkReportsComponent>();
            List<ProficiencyTypeModel> ptModels = repo.ProficiencyTypeModelSelectAll();
            foreach (ProficiencyTypeModel pt in ptModels)
            {
                components.Add(new BenchmarkReportsComponent()
                {
                    ProfLevel = pt,
                    Students = new List<string>()
                });
            }
        }

        public BenchmarkReportsComponent SelectByProfID(int ptId)
        {
            // return a list of students given a proficiency Id
            BenchmarkReportsComponent output = null;
            foreach (var comp in components)
            {
                if (comp.ProfLevel.ID == ptId)
                {
                    output = comp;
                }

            }
            return output;
        }
    }

    //public static class BenchmarkReportsModelDB 
    //public static BenchmarkReportsModel AllSchoolsAllGrades(int evalPeriod, int userID, int yearID)
    //{
    //    BenchmarkReportsModel output = null;
    //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
    //    SqlCommand cmd = new SqlCommand("BenchmarkReportsSelectAllSchoolsAllGrades", conn);
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@evalPeriodID", evalPeriod);
    //    cmd.Parameters.AddWithValue("@userID", userID);
    //    cmd.Parameters.AddWithValue("@yearID", yearID);
    //    try
    //    {
    //        conn.Open();
    //        SqlDataReader dtr = cmd.ExecuteReader();
    //        if (dtr.Read())
    //        {
    //            output = new BenchmarkReportsModel()
    //            {
    //                courseID = null,
    //                gradeID = null,
    //                schoolID = null,
    //                evalPeriodID = evalPeriod
    //            };
    //            do
    //            {
    //                string nameTitle = dtr["firstName"].ToString() + " " + dtr["lastName"].ToString();
    //                output.SelectByProfID(Convert.ToInt32(dtr["ProficiencyID"])).Students.Add(nameTitle);
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

    //public static BenchmarkReportsModel AllSchoolsSpecificGrade(int gradeID, int evalPeriod, int userID, int yearID)
    //{
    //    BenchmarkReportsModel output = null;
    //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
    //    SqlCommand cmd = new SqlCommand("BenchmarkReportsAllSchoolsSpecificGrade", conn);
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@gradeID", gradeID);
    //    cmd.Parameters.AddWithValue("@evalPeriodID", evalPeriod);
    //    cmd.Parameters.AddWithValue("@userID", userID);
    //    cmd.Parameters.AddWithValue("@yearID", yearID);
    //    try
    //    {
    //        conn.Open();
    //        SqlDataReader dtr = cmd.ExecuteReader();
    //        if (dtr.Read())
    //        {
    //            output = new BenchmarkReportsModel()
    //            {
    //                courseID = null,
    //                gradeID = gradeID,
    //                schoolID = null,
    //                evalPeriodID = evalPeriod
    //            };
    //            do
    //            {
    //                string nameTitle = dtr["firstName"].ToString() + " " + dtr["lastName"].ToString();
    //                output.SelectByProfID(Convert.ToInt32(dtr["ProficiencyID"])).Students.Add(nameTitle);
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

    //public static BenchmarkReportsModel SpecificSchoolAllGrades(int evalPeriod, int schoolID, int yearID)
    //{
    //    BenchmarkReportsModel output = null;
    //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
    //    SqlCommand cmd = new SqlCommand("BenchmarkReportsSelectSpecificSchoolAllGrades", conn);
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@evalPeriodID", evalPeriod);
    //    cmd.Parameters.AddWithValue("@schoolID", schoolID);
    //    cmd.Parameters.AddWithValue("@yearID", yearID);
    //    try
    //    {
    //        conn.Open();
    //        SqlDataReader dtr = cmd.ExecuteReader();
    //        if (dtr.Read())
    //        {
    //            output = new BenchmarkReportsModel()
    //            {
    //                courseID = null,
    //                gradeID = null,
    //                schoolID = schoolID,
    //                evalPeriodID = evalPeriod
    //            };
    //            do
    //            {
    //                string nameTitle = dtr["firstName"].ToString() + " " + dtr["lastName"].ToString();
    //                output.SelectByProfID(Convert.ToInt32(dtr["ProficiencyID"])).Students.Add(nameTitle);
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
    //public static BenchmarkReportsModel SpecificSchoolSpecificGradeYear(int evalPeriod, int schoolID, int gradeID, int yearID)
    //{
    //    BenchmarkReportsModel output = null;
    //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
    //    SqlCommand cmd = new SqlCommand("BenchmarkReportsSelectAllBySchoolandGradeYear", conn);
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@gradeID", gradeID);
    //    cmd.Parameters.AddWithValue("@evalPeriodID", evalPeriod);
    //    cmd.Parameters.AddWithValue("@schoolID", schoolID);
    //    cmd.Parameters.AddWithValue("@yearID", yearID);
    //    try
    //    {
    //        conn.Open();
    //        SqlDataReader dtr = cmd.ExecuteReader();
    //        if (dtr.Read())
    //        {
    //            output = new BenchmarkReportsModel()
    //            {
    //                courseID = null,
    //                gradeID = gradeID,
    //                schoolID = schoolID,
    //                evalPeriodID = evalPeriod
    //            };
    //            do
    //            {
    //                string nameTitle = dtr["firstName"].ToString() + " " + dtr["lastName"].ToString();
    //                output.SelectByProfID(Convert.ToInt32(dtr["ProficiencyID"])).Students.Add(nameTitle);
    //            } while (dtr.Read());
    //        }
    //    }
    //    catch (SqlException ex)
    //    {
    //        ErrorModelDb.InsertSqlError(ex.Message.ToString());
    //    }
    //    finally
    //    {
    //        conn.Close();
    //    }
    //    return output;
    //}
    //public static BenchmarkReportsModel SpecificSchoolSpecificGrade(int evalPeriod, int schoolID, int gradeID)
    //{
    //    BenchmarkReportsModel output = null;
    //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
    //    SqlCommand cmd = new SqlCommand("BenchmarkReportsSelectAllBySchoolandGrade", conn);
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@gradeID", gradeID);
    //    cmd.Parameters.AddWithValue("@evalPeriodID", evalPeriod);
    //    cmd.Parameters.AddWithValue("@schoolID", schoolID);
    //    try
    //    {
    //        conn.Open();
    //        SqlDataReader dtr = cmd.ExecuteReader();
    //        if (dtr.Read())
    //        {
    //            output = new BenchmarkReportsModel()
    //            {
    //                courseID = null,
    //                gradeID = gradeID,
    //                schoolID = schoolID,
    //                evalPeriodID = Convert.ToInt32(dtr["EvaluationPeriodID"])
    //            };
    //            do
    //            {
    //                string nameTitle = dtr["firstName"].ToString() + " " + dtr["lastName"].ToString();
    //                output.SelectByProfID(Convert.ToInt32(dtr["ProficiencyID"])).Students.Add(nameTitle);
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

    //public static BenchmarkReportsModel SpecificSchoolSpecificCourse(int courseID, int evalPeriodID, int yearID) // specific school - specific course
    //{
    //    BenchmarkReportsModel output = null;
    //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
    //    SqlCommand cmd = new SqlCommand("BenchmarkReportsSelectAllByCourseID", conn);
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@courseID", courseID);
    //    cmd.Parameters.AddWithValue("@evaluationperiodID", evalPeriodID);
    //    cmd.Parameters.AddWithValue("@yearID", yearID);
    //    try
    //    {
    //        conn.Open();
    //        SqlDataReader dtr = cmd.ExecuteReader();
    //        if (dtr.Read())
    //        {
    //            output = new BenchmarkReportsModel()
    //            {
    //                courseID = Convert.ToInt32(dtr["CourseID"]),
    //                gradeID = null,
    //                schoolID = null,
    //                evalPeriodID = Convert.ToInt32(dtr["EvaluationPeriodID"])
    //            };
    //            do
    //            {
    //                string nameTitle = dtr["firstName"].ToString() + " " + dtr["lastName"].ToString();
    //                output.SelectByProfID(Convert.ToInt32(dtr["ProficiencyID"])).Students.Add(nameTitle);
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
