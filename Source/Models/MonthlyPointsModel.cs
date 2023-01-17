namespace Source.Models
{
    public class MonthlyPointsModel
    {
        public int ID { get; set; }
        public string Month { get; set; }
        public int Total { get; set; }
    }
    public static class MonthlyPointsModelDB
    {
        //public static MonthlyPointsModel SelectOne(int ID)
        //{
        //    MonthlyPointsModel output = new MonthlyPointsModel();
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("ptsMontlyGoalSelectOne", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@ID", ID);
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            output.ID = ID;
        //            output.Month = dtr["Month"].ToString();
        //            output.Total = Convert.ToInt32(dtr["Total"]);
        //        }
        //    }
        //    catch(SqlException ex)
        //    {
        //        ErrorModelDb.InsertSqlError(ex.Message.ToString());
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return output;
        //}
        //public static List<MonthlyPointsModel> SelectAll()
        //{
        //    List<MonthlyPointsModel> output = new List<MonthlyPointsModel>();
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("ptsMonthlyGoalSelectAll", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {
        //                output.Add(new MonthlyPointsModel()
        //                {
        //                    ID = Convert.ToInt32(dtr["ID"]),
        //                    Month = dtr["Month"].ToString(),
        //                    Total = Convert.ToInt32(dtr["Total"])
        //                });
        //            }
        //            while (dtr.Read());
        //        }
        //    }
        //    catch(SqlException ex)
        //    {
        //        ErrorModelDb.InsertSqlError(ex.Message.ToString());
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return output;
        //}
        //public static void UpdateTotal(MonthlyPointsModel model)
        //{
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("ptsMonthlyGoalUpdate", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@Month", model.Month);
        //    cmd.Parameters.AddWithValue("@Total", model.Total);
        //    try
        //    {
        //        conn.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch(SqlException ex)
        //    {
        //        ErrorModelDb.InsertSqlError(ex.Message.ToString());
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}
    }

}