using System;

namespace Source.Models
{
    public class TeacherBookshelfRequestModel
    {
        public int Id { get; set; }
        public int BookshelfPaperId { get; set; }
        public bool Acknowledged { get; set; }
        public int TeacherID { get; set; }
        public int PaperID { get; set; }
        public string PaperTitle { get; set; }
        public byte[] Paper { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StudentID { get; set; }
        public DateTime Date { get; set; }
        public int CourseID { get; set; }
        public int ContentTypeID { get; set; }

    }
    public static class TeacherBookshelfRequestModelDB
    {
        //public static List<TeacherBookshelfRequestModel> SelectAllByTeacher(int teacherID)
        //{
        //    var output = new List<TeacherBookshelfRequestModel>();
        //    var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    var cmd = new SqlCommand("TeacherBookshelfViewQueue", conn);
        //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@teacherID", teacherID);
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {
        //                output.Add(new TeacherBookshelfRequestModel()
        //                {
        //                    Id = Convert.ToInt32(dtr["Id"]),
        //                    BookshelfPaperId = Convert.ToInt32(dtr["BookshelfPaperId"]),
        //                    TeacherID = Convert.ToInt32(dtr["TeacherId"]),
        //                    PaperID = Convert.ToInt32(dtr["PaperID"]),
        //                    PaperTitle = dtr["PaperTitle"].ToString(),
        //                    FirstName = dtr["firstName"].ToString(),
        //                    LastName = dtr["lastName"].ToString(),
        //                    StudentID = Convert.ToInt32(dtr["StudentID"]),
        //                    Date = Convert.ToDateTime(dtr["Date"]),
        //                    CourseID = Convert.ToInt32(dtr["CourseID"]),
        //                    ContentTypeID = Convert.ToInt32(dtr["ContentTypeID"]),
        //                    Acknowledged = Convert.ToBoolean(dtr["Acknowledged"])
        //                });
        //            }
        //            while (dtr.Read());
        //        }
        //    }
        //    catch(SqlException ex)
        //    {
        //        ErrorModelDb.InsertSqlError(ex.ToString());
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return output;

        //}
        //public static void AcknowledgeRequest(int Id)
        //{
        //    var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    var cmd = new SqlCommand("AcknowledgeBookshelfRequest", conn);
        //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@Id", Id);
        //    try
        //    {
        //        conn.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch(SqlException ex)
        //    {
        //        ErrorModelDb.InsertSqlError(ex.ToString());
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}
        //public static void DenyRequest(int Id)
        //{
        //    var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    var cmd = new SqlCommand("DenyBookshelfRequest", conn);
        //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@Id", Id);
        //    try
        //    {
        //        conn.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch (SqlException ex)
        //    {
        //        ErrorModelDb.InsertSqlError(ex.ToString());
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}
    }
}