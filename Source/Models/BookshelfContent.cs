namespace Source.Models
{
    public class BookshelfContent
    {
        public int ID { get; set; }
        public string Content { get; set; }
    }
    //public static class BookshelfContentDB
    //{
    //    public static List<BookshelfContent> SelectAll()
    //    {
    //        List<BookshelfContent> output = new List<BookshelfContent>();
    //        var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
    //        var cmd = new SqlCommand("BookshelfContentSelectAll", conn);
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        try
    //        {
    //            conn.Open();
    //            SqlDataReader dtr = cmd.ExecuteReader();
    //            if (dtr.Read())
    //            {
    //                do
    //                {
    //                    output.Add(new BookshelfContent()
    //                    {
    //                        ID = Convert.ToInt32(dtr["ID"]),
    //                        Content = dtr["Content"].ToString()
    //                });

    //                } while (dtr.Read());
    //            }

    //        }
    //        catch(SqlException ex)
    //        {
    //            ErrorModelDb.InsertSqlError(ex.ToString());
    //        }
    //        finally
    //        {
    //            conn.Close();
    //        }
    //        return output;
    //    }
    //}
}