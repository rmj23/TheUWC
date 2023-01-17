namespace Source.Models
{
    public class GlossaryModel
    {
        public int glossaryID { get; set; }
        public string Term { get; set; }
        public string Definition { get; set; }


    }


    public static class GlossaryModelDb
    {
        //public static List<GlossaryModel> SelectAll()
        //{
        //    List<GlossaryModel> output = new List<GlossaryModel>();
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("GlossarySelectAll", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {
        //                output.Add(new GlossaryModel()
        //                {
        //                    glossaryID = Convert.ToInt32(dtr["glossaryID"]),
        //                    Term = dtr["term"].ToString(),
        //                    Definition = dtr["definition"].ToString()
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
        //public static List<GlossaryModel> SelectByLetter(char letter)
        //{
        //    List<GlossaryModel> output = new List<GlossaryModel>();
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("GlossarySelectByLetter", conn);
        //    cmd.Parameters.AddWithValue("@letter", letter);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {
        //                output.Add(new GlossaryModel()
        //                {
        //                    glossaryID = Convert.ToInt32(dtr["glossaryID"]),
        //                    Term = dtr["term"].ToString(),
        //                    Definition = dtr["definition"].ToString()
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
        //public static List<GlossaryModel> SelectByTerm(string term)
        //{
        //    List<GlossaryModel> output = new List<GlossaryModel>();
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("GlossarySelectByTerm", conn);
        //    cmd.Parameters.AddWithValue("@letter", term);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {
        //                output.Add(new GlossaryModel()
        //                {
        //                    glossaryID = Convert.ToInt32(dtr["glossaryID"]),
        //                    Term = dtr["term"].ToString(),
        //                    Definition = dtr["definition"].ToString()
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
        //public static void Insert(GlossaryModel model)
        //{
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("GlossaryInsert", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@term", model.Term);
        //    cmd.Parameters.AddWithValue("@definition", model.Definition);
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

    }

}