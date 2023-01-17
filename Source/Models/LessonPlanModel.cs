using System;

namespace Source.Models
{
    public class LessonPlanModel
    {
        public int ID { get; set; }
        public int TeacherID { get; set; }
        public int CourseID { get; set; }
        public DateTime UploadDate { get; set; }
        public string Title { get; set; }
        public string Objective { get; set; }
        public string Standard { get; set; }
        public string EngageDesc { get; set; }
        public string ModelDesc { get; set; }
        public string ExploreDesc { get; set; }
        public string ExplainDesc { get; set; }
        public string ApplyDesc { get; set; }
        public string ShareDesc { get; set; }
    }
    public static class LessonPlanModelDb
    {
        //public static void Insert(LessonPlanModel model)
        //{
        //    var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    var cmd = new SqlCommand("LessonPlanInsert", conn)
        //    {
        //        CommandType = CommandType.StoredProcedure,
        //        Parameters =
        //        {
        //            new SqlParameter("@TeacherID", model.TeacherID),
        //            new SqlParameter("@CourseID", model.CourseID),
        //            new SqlParameter("@title", model.Title),
        //            new SqlParameter("@objective", model.Objective),
        //            new SqlParameter("@standard", model.Standard),
        //            new SqlParameter("@engageDesc", model.EngageDesc),
        //            new SqlParameter("@modelDesc", model.ModelDesc),
        //            new SqlParameter("@exploreDesc", model.ExploreDesc),
        //            new SqlParameter("@explainDesc", model.ExplainDesc),
        //            new SqlParameter("@applyDesc", model.ApplyDesc),
        //            new SqlParameter("@shareDesc", model.ShareDesc)
        //        }
        //    };

        //    try
        //    {
        //        conn.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch (SqlException ex)
        //    {
        //        ErrorModelDb.InsertSqlError(ex.ToString());
        //    }

        //    conn.Close();
        //}

        //public static void Update(LessonPlanModel model)
        //{

        //}

        //public static void Delete(int lessonPlanId)
        //{
        //    var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    var cmd = new SqlCommand("LessonPlanDelete", conn)
        //    {
        //        CommandType = CommandType.StoredProcedure,
        //        Parameters =
        //        {
        //            new SqlParameter("@ID", lessonPlanId)
        //        }
        //    };

        //    try
        //    {
        //        conn.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch (SqlException ex)
        //    {
        //        ErrorModelDb.InsertSqlError(ex.ToString());
        //    }

        //    conn.Close();
        //}

        //public static List<LessonPlanModel> SelectAll()
        //{
        //    var lessonPlanList = new List<LessonPlanModel>();

        //    var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    var cmd = new SqlCommand("LessonPlanSelectAll", conn)
        //    {
        //        CommandType = CommandType.StoredProcedure
        //    };

        //    try
        //    {
        //        conn.Open();

        //        var reader = cmd.ExecuteReader();

        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                lessonPlanList.Add(new LessonPlanModel()
        //                {
        //                    ID = Convert.ToInt32(reader["ID"]),
        //                    TeacherID = (reader["TeacherID"] != DBNull.Value) ? Convert.ToInt32(reader["TeacherID"]) : -1,
        //                    CourseID = (reader["CourseID"] != DBNull.Value) ? Convert.ToInt32(reader["CourseID"]) : -1,
        //                    UploadDate = Convert.ToDateTime(reader["UploadDate"]),
        //                    Title = Convert.ToString(reader["title"]),
        //                    Objective = Convert.ToString(reader["objective"]),
        //                    Standard = Convert.ToString(reader["standard"]),
        //                    EngageDesc = Convert.ToString(reader["engageDesc"]),
        //                    ModelDesc = Convert.ToString(reader["modelDesc"]),
        //                    ExploreDesc = Convert.ToString(reader["exploreDesc"]),
        //                    ExplainDesc = Convert.ToString(reader["explainDesc"]),
        //                    ApplyDesc = Convert.ToString(reader["applyDesc"]),
        //                    ShareDesc = Convert.ToString(reader["shareDesc"])
        //                });
        //            }
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

        //    return lessonPlanList;
        //}

        //public static List<LessonPlanModel> SelectAllByTeacher(int teacherId)
        //{
        //    var lessonPlanList = new List<LessonPlanModel>();

        //    var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    var cmd = new SqlCommand("LessonPlanSelectAllByTeacher", conn)
        //    {
        //        CommandType = CommandType.StoredProcedure,
        //        Parameters =
        //        {
        //            new SqlParameter("@TeacherID", teacherId)
        //        }
        //    };

        //    try
        //    {
        //        conn.Open();

        //        var reader = cmd.ExecuteReader();

        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                lessonPlanList.Add(new LessonPlanModel()
        //                {
        //                    ID = Convert.ToInt32(reader["ID"]),
        //                    TeacherID = (reader["TeacherID"] != DBNull.Value) ? Convert.ToInt32(reader["TeacherID"]) : -1,
        //                    CourseID = (reader["CourseID"] != DBNull.Value) ? Convert.ToInt32(reader["CourseID"]) : -1,
        //                    UploadDate = Convert.ToDateTime(reader["UploadDate"]),
        //                    Title = Convert.ToString(reader["title"]),
        //                    Objective = Convert.ToString(reader["objective"]),
        //                    Standard = Convert.ToString(reader["standard"]),
        //                    EngageDesc = Convert.ToString(reader["engageDesc"]),
        //                    ModelDesc = Convert.ToString(reader["modelDesc"]),
        //                    ExploreDesc = Convert.ToString(reader["exploreDesc"]),
        //                    ExplainDesc = Convert.ToString(reader["explainDesc"]),
        //                    ApplyDesc = Convert.ToString(reader["applyDesc"]),
        //                    ShareDesc = Convert.ToString(reader["shareDesc"])
        //                });
        //            }
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

        //    return lessonPlanList;
        //}

        //public static LessonPlanModel SelectOneByLessonPlanID(int lessonPlanId)
        //{
        //    var model = new LessonPlanModel();

        //    var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    var cmd = new SqlCommand("LessonPlanSelectOneByID", conn)
        //    {
        //        CommandType = CommandType.StoredProcedure,
        //        Parameters =
        //        {
        //            new SqlParameter("@ID", lessonPlanId)
        //        }
        //    };

        //    try
        //    {
        //        conn.Open();

        //        var reader = cmd.ExecuteReader();

        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                model.ID = Convert.ToInt32(reader["ID"]);
        //                model.TeacherID = (reader["TeacherID"] != DBNull.Value)
        //                    ? Convert.ToInt32(reader["TeacherID"])
        //                    : -1;
        //                model.CourseID = (reader["CourseID"] != DBNull.Value) 
        //                    ? Convert.ToInt32(reader["CourseID"]) 
        //                    : -1;
        //                model.UploadDate = Convert.ToDateTime(reader["UploadDate"]);
        //                model.Title = Convert.ToString(reader["title"]);
        //                model.Objective = Convert.ToString(reader["objective"]);
        //                model.Standard = Convert.ToString(reader["standard"]);
        //                model.EngageDesc = Convert.ToString(reader["engageDesc"]);
        //                model.ModelDesc = Convert.ToString(reader["modelDesc"]);
        //                model.ExploreDesc = Convert.ToString(reader["exploreDesc"]);
        //                model.ExplainDesc = Convert.ToString(reader["explainDesc"]);
        //                model.ApplyDesc = Convert.ToString(reader["applyDesc"]);
        //                model.ShareDesc = Convert.ToString(reader["shareDesc"]);
        //            }
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

        //    return model;
        //}

    }

}