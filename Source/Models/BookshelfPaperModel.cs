using System;

namespace Source.Models
{
    public class BookshelfPaperModel
    {
        public int Id { get; set; }
        public int paperId { get; set; }
        public int studentId { get; set; }
        public int contentTypeId { get; set; }
        public DateTime date { get; set; }
        public int courseID { get; set; }
    }

    public static class BookshelfPaperModelDb
    {
        //public static void insert(BookshelfPaperModel model)
        //{
        //    var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    var cmd = new SqlCommand("BookshelfPaperInsert", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@paperId", model.paperId);
        //    cmd.Parameters.AddWithValue("@studentId", model.studentId);
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
        //public static List<BookshelfPaperModel> selectAllInClass(int classId)
        //{
        //    List<BookshelfPaperModel> output = new List<BookshelfPaperModel>();
        //    var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    var cmd = new SqlCommand("BookshelfSelectAllInClass", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@classId", classId);
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {
        //                output.Add(new BookshelfPaperModel()
        //                {
        //                    Id = Convert.ToInt32(dtr["Id"]),
        //                    paperId = Convert.ToInt32(dtr["PaperId"]),
        //                    studentId = Convert.ToInt32(dtr["StudentId"]),
        //                    contentTypeId = Convert.ToInt32(dtr["ContentTypeID"]),
        //                    date = Convert.ToDateTime(dtr["Date"])
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
        //public static List<BookshelfPaperModel> SelectAllInDistrict(int districtId)
        //{
        //    List<BookshelfPaperModel> output = new List<BookshelfPaperModel>();
        //    var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    var cmd = new SqlCommand("BookshelfPaperSelectAllInDistrict", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@districtId", districtId);
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {
        //                output.Add(new BookshelfPaperModel()
        //                {
        //                    Id = Convert.ToInt32(dtr["Id"]),
        //                    paperId = Convert.ToInt32(dtr["PaperId"]),
        //                    studentId = Convert.ToInt32(dtr["StudentId"]),
        //                    contentTypeId = Convert.ToInt32(dtr["ContentTypeID"]),
        //                    date = Convert.ToDateTime(dtr["Date"])
        //                });

        //            }
        //            while (dtr.Read());
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

        //public static List<BookshelfPaperModel> SelectAllInSchool(int schoolId)
        //{
        //    List<BookshelfPaperModel> output = new List<BookshelfPaperModel>();
        //    var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    var cmd = new SqlCommand("BookshelfPaperSelectAllInSchool", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@schoolId", schoolId);
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {
        //                output.Add(new BookshelfPaperModel()
        //                {
        //                    Id = Convert.ToInt32(dtr["Id"]),
        //                    paperId = Convert.ToInt32(dtr["PaperId"]),
        //                    studentId = Convert.ToInt32(dtr["StudentId"]),
        //                    contentTypeId = Convert.ToInt32(dtr["ContentTypeID"]),
        //                    date = Convert.ToDateTime(dtr["Date"])
        //                });

        //            }
        //            while (dtr.Read());
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

        //public static List<BookshelfPaperModel> selectAllByStudent(int studentId)
        //{
        //    List<BookshelfPaperModel> output = new List<BookshelfPaperModel>();
        //    var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    var cmd = new SqlCommand("BookshelfSelectAllByStudent", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@studentId", studentId);
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {
        //                output.Add(new BookshelfPaperModel()
        //                {
        //                    Id = Convert.ToInt32(dtr["Id"]),
        //                    paperId = Convert.ToInt32(dtr["PaperId"]),
        //                    studentId = Convert.ToInt32(dtr["StudentId"]),
        //                    contentTypeId = Convert.ToInt32(dtr["ContentTypeID"]),
        //                    date = Convert.ToDateTime(dtr["Date"])
        //                });

        //            }
        //            while (dtr.Read());
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
}