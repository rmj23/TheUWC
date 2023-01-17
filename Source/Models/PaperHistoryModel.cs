namespace Source.Models
{
    public class PaperHistoryModel : PaperModel
    {
        public string CourseTitle { get; set; }
        public int Period { get; set; }
    }

    public static class PaperHistoryModelDb
    {
        //public static List<PaperHistoryModel> SelectHistoryAllByStudent(int studentID)
        //{
        //    List<PaperHistoryModel> output = new List<PaperHistoryModel>();
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    //change for DB
        //    SqlCommand cmd = new SqlCommand("PaperHistorySelectAllByStudent", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@studentID", studentID);
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //            do
        //            {

        //                if (dtr["EvaluationDate"] == DBNull.Value & (dtr["Paper"]) == DBNull.Value)  // check to see if eval date and datetime (both have the possibility of being null) are null.
        //                {
        //                    output.Add(new PaperHistoryModel()
        //                    {
        //                        PaperID = Convert.ToInt32(dtr["PaperID"]),
        //                        StudentID = Convert.ToInt32(dtr["StudentID"]),
        //                        CourseID = Convert.ToInt32(dtr["CourseID"]),
        //                        uploadDate = Convert.ToDateTime(dtr["UploadDate"]),
        //                        PaperTypeID = Convert.ToInt32(dtr["PaperType"]),
        //                        Paper = null,
        //                        FileName = dtr["FileName"].ToString(),
        //                        PaperTitle = dtr["PaperTitle"].ToString(),
        //                        EvaluationPeriodID = Convert.ToInt32(dtr["EvaluationPeriodID"]),
        //                        HolisticScoreLetter = dtr["HolisticScoreLetter"].ToString(),
        //                        Draft = Convert.ToInt32(dtr["Draft"]),
        //                        Continuing = Convert.ToBoolean(dtr["Continuing"]),
        //                        firstName = dtr["firstName"].ToString(),
        //                        lastName = dtr["lastName"].ToString(),
        //                        evalDescription = dtr["evalDescription"].ToString(),
        //                        paperTypeDescription = dtr["paperType"].ToString(),
        //                        evaluationDate = null,
        //                        YearID = Convert.ToInt32(dtr["YearID"]),
        //                        CourseTitle = dtr["courseTitle"].ToString(),
        //                        Period = Convert.ToInt32(dtr["period"])


        //                    });
        //                }
        //                else if (dtr["EvaluationDate"] != DBNull.Value & (dtr["Paper"]) == DBNull.Value)
        //                {

        //                    output.Add(new PaperHistoryModel()
        //                    {
        //                        PaperID = Convert.ToInt32(dtr["PaperID"]),
        //                        StudentID = Convert.ToInt32(dtr["StudentID"]),
        //                        CourseID = Convert.ToInt32(dtr["CourseID"]),
        //                        uploadDate = Convert.ToDateTime(dtr["UploadDate"]),
        //                        PaperTypeID = Convert.ToInt32(dtr["PaperType"]),
        //                        Paper = null,
        //                        FileName = dtr["FileName"].ToString(),
        //                        PaperTitle = dtr["PaperTitle"].ToString(),
        //                        EvaluationPeriodID = Convert.ToInt32(dtr["EvaluationPeriodID"]),
        //                        HolisticScoreLetter = dtr["HolisticScoreLetter"].ToString(),
        //                        Draft = Convert.ToInt32(dtr["Draft"]),
        //                        Continuing = Convert.ToBoolean(dtr["Continuing"]),
        //                        firstName = dtr["firstName"].ToString(),
        //                        lastName = dtr["lastName"].ToString(),
        //                        evalDescription = dtr["evalDescription"].ToString(),
        //                        paperTypeDescription = dtr["paperType"].ToString(),
        //                        evaluationDate = Convert.ToDateTime(dtr["EvaluationDate"]),
        //                        //TODO: Remove when we get null years out of the DB
        //                        YearID = (dtr["YearID"]) == DBNull.Value ? 1 : Convert.ToInt32(dtr["YearID"]),
        //                        CourseTitle = dtr["courseTitle"].ToString(),
        //                        Period = Convert.ToInt32(dtr["period"])


        //                    });
        //                }
        //                else if ((dtr["EvaluationDate"] == DBNull.Value & (dtr["Paper"]) != DBNull.Value))
        //                {

        //                    output.Add(new PaperHistoryModel()
        //                    {
        //                        PaperID = Convert.ToInt32(dtr["PaperID"]),
        //                        StudentID = Convert.ToInt32(dtr["StudentID"]),
        //                        CourseID = Convert.ToInt32(dtr["CourseID"]),
        //                        uploadDate = Convert.ToDateTime(dtr["UploadDate"]),
        //                        PaperTypeID = Convert.ToInt32(dtr["PaperType"]),
        //                        Paper = (byte[])(dtr["Paper"]),
        //                        FileName = dtr["FileName"].ToString(),
        //                        PaperTitle = dtr["PaperTitle"].ToString(),
        //                        EvaluationPeriodID = Convert.ToInt32(dtr["EvaluationPeriodID"]),
        //                        HolisticScoreLetter = dtr["HolisticScoreLetter"].ToString(),
        //                        Draft = Convert.ToInt32(dtr["Draft"]),
        //                        Continuing = Convert.ToBoolean(dtr["Continuing"]),
        //                        firstName = dtr["firstName"].ToString(),
        //                        lastName = dtr["lastName"].ToString(),
        //                        evalDescription = dtr["evalDescription"].ToString(),
        //                        paperTypeDescription = dtr["paperType"].ToString(),
        //                        evaluationDate = null,
        //                        YearID = Convert.ToInt32(dtr["YearID"]),
        //                        CourseTitle = dtr["courseTitle"].ToString(),
        //                        Period = Convert.ToInt32(dtr["period"])


        //                    });

        //                }
        //                else if ((dtr["EvaluationDate"] != DBNull.Value & (dtr["Paper"]) != DBNull.Value))
        //                {

        //                    output.Add(new PaperHistoryModel()
        //                    {
        //                        PaperID = Convert.ToInt32(dtr["PaperID"]),
        //                        StudentID = Convert.ToInt32(dtr["StudentID"]),
        //                        CourseID = Convert.ToInt32(dtr["CourseID"]),
        //                        uploadDate = Convert.ToDateTime(dtr["UploadDate"]),
        //                        PaperTypeID = Convert.ToInt32(dtr["PaperType"]),
        //                        Paper = (byte[])(dtr["Paper"]),
        //                        FileName = dtr["FileName"].ToString(),
        //                        PaperTitle = dtr["PaperTitle"].ToString(),
        //                        EvaluationPeriodID = Convert.ToInt32(dtr["EvaluationPeriodID"]),
        //                        HolisticScoreLetter = dtr["HolisticScoreLetter"].ToString(),
        //                        Draft = Convert.ToInt32(dtr["Draft"]),
        //                        Continuing = Convert.ToBoolean(dtr["Continuing"]),
        //                        firstName = dtr["firstName"].ToString(),
        //                        lastName = dtr["lastName"].ToString(),
        //                        evalDescription = dtr["evalDescription"].ToString(),
        //                        paperTypeDescription = dtr["paperType"].ToString(),
        //                        evaluationDate = Convert.ToDateTime(dtr["EvaluationDate"]),
        //                        YearID = Convert.ToInt32(dtr["YearID"]),
        //                        CourseTitle = dtr["courseTitle"].ToString(),
        //                        Period = Convert.ToInt32(dtr["period"])


        //                    });
        //                }


        //            } while (dtr.Read());


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