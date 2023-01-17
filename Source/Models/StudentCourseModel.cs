namespace Source.Models
{
    public class StudentCourseModel
    {
        public int ID { get; set; }
        public int StudentID { get; set; }
        public int CourseID { get; set; }
        public bool Enrolled { get; set; }
    }

    // delete all
    public static class StudentCourseModelDb
    {
        //    public static void Enroll(StudentCourseModel model)
        //    {

        //        SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //        SqlCommand cmd = new SqlCommand("StudentCourseEnroll", conn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@studentID", model.StudentID);
        //        cmd.Parameters.AddWithValue("@courseID", model.ClassID);
        //        try
        //        {
        //            conn.Open();
        //            cmd.ExecuteNonQuery();
        //        }
        //        catch (SqlException ex)
        //        {
        //            ErrorModelDb.InsertSqlError(ex.ToString());
        //        }
        //        finally
        //        {
        //            conn.Close();
        //        }
        //    }
        //    public static void Unenroll(StudentCourseModel model)
        //    {
        //        SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //        SqlCommand cmd = new SqlCommand("StudentCourseUnenroll", conn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@studentID", model.StudentID);
        //        cmd.Parameters.AddWithValue("@courseID", model.ClassID);
        //        try
        //        {
        //            conn.Open();
        //            cmd.ExecuteNonQuery();
        //        }
        //        catch (SqlException ex)
        //        {
        //            ErrorModelDb.InsertSqlError(ex.ToString());
        //        }
        //        finally
        //        {
        //            conn.Close();
        //        }
        //    }
    }
}