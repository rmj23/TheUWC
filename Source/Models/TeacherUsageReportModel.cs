namespace Source.Models
{
    public class TeacherUsageReportModel
    {
        public int? evalPeriodID { get; set; }
        public string teacherFN { get; set; }
        public string teacherLN { get; set; }
        public string papersScored { get; set; }

    }
    //public static class TeacherUsageReportModelDB
    //{
    //    public static List<TeacherUsageReportModel> GetReports(int evalPeriod, int userID, int schoolID)
    //    {
    //        List<TeacherUsageReportModel> output = new List<TeacherUsageReportModel>();
    //        SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
    //        SqlCommand cmd = new SqlCommand("GetTeacherUsage", conn);
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        cmd.Parameters.AddWithValue("@ID", userID);
    //        cmd.Parameters.AddWithValue("@evalPeriod", evalPeriod);
    //        cmd.Parameters.AddWithValue("@schoolID", schoolID);
    //        try
    //        {
    //            conn.Open();
    //            SqlDataReader dtr = cmd.ExecuteReader();
    //            if (dtr.Read())
    //            {
    //                do
    //                {
    //                    TeacherUsageReportModel report = new TeacherUsageReportModel();
    //                    report.teacherFN = dtr["firstName"].ToString();
    //                    report.teacherLN = dtr["lastName"].ToString();
    //                    report.papersScored = Convert.ToString(dtr["Total Papers Scored"]);
    //                    output.Add(report);
    //                } while (dtr.Read());
    //            }
    //        }
    //        catch (SqlException ex)
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
