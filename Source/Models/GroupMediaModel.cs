namespace Source.Models
{
    public class GroupMediaModel
    {
        public int Id { get; set; }
        public int studentId { get; set; }
        public int projectId { get; set; }
        public int groupId { get; set; }
        public byte[] media { get; set; }
        public string mediaType { get; set; }
    }
    public static class GroupMediaModelDb
    {
        //private static SqlConnection conn;
        //private static SqlCommand cmd;
        //private static SqlDataReader dtr;

        //public static void insertMedia(int studentId, int projectId, byte[] media, string mediaType, int groupId, string title)
        //{
        //    conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    cmd = new SqlCommand("GroupMediaUpload", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@studentId", studentId);
        //    cmd.Parameters.AddWithValue("@projectId", projectId);
        //    cmd.Parameters.AddWithValue("@mediaType", mediaType);
        //    cmd.Parameters.AddWithValue("@media", media);
        //    cmd.Parameters.AddWithValue("@groupId", groupId);
        //    cmd.Parameters.AddWithValue("@title", title);
        //    cmd.Parameters.AddWithValue("@uploadTimestamp", DateTime.Now.ToLocalTime());
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
        //public static List<GroupMediaModel> selectAllByGroup(int groupId, int projectId)
        //{
        //    List<GroupMediaModel> output = new List<GroupMediaModel>();
        //    conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    cmd = new SqlCommand("GroupMediaSelectAllByGroup", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@groupId", groupId);
        //    cmd.Parameters.AddWithValue("@projectId", projectId);
        //    try
        //    {
        //        conn.Open();
        //        dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {
        //                output.Add(new GroupMediaModel()
        //                {
        //                    Id = Convert.ToInt32(dtr["Id"]),
        //                    studentId = Convert.ToInt32(dtr["studentId"]),
        //                    projectId = Convert.ToInt32(dtr["projectId"]),
        //                    groupId = Convert.ToInt32(dtr["groupId"]),
        //                    media = (byte[])(dtr["media"]),
        //                    mediaType = dtr["mediaType"].ToString()

        //                });

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

        //public static GroupMediaModel viewIndividualMedia(int Id)
        //{
        //    GroupMediaModel output = new GroupMediaModel();
        //    conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    cmd = new SqlCommand("GroupMediaSelectOne", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@Id", Id);
        //    try
        //    {
        //        conn.Open();
        //        dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            output.Id = Convert.ToInt32(dtr["Id"]);
        //            output.groupId = Convert.ToInt32(dtr["groupId"]);
        //            output.projectId = Convert.ToInt32(dtr["projectId"]);
        //            output.mediaType = dtr["mediaType"].ToString();
        //            output.media = (byte[])dtr["media"];
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
        //public static void delete(int groupId, int projectId)
        //{
        //    conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    cmd = new SqlCommand("GroupMediaDelete", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@groupId", groupId);
        //    cmd.Parameters.AddWithValue("@projectId", projectId);
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
    }
}