using System;

namespace Source.Models
{
    public class ConferenceToolModel
    {
        public int ConferenceToolID { get; set; }
        public int ConferenceTypeID { get; set; }
        public string ConferenceType { get; set; }
        public int StudentID { get; set; }
        public string Student { get; set; }
        public int SourceID { get; set; }
        public string SourceTitle { get; set; }
        public int ElementID { get; set; }
        public string Element { get; set; }
        public int RoleHelpID { get; set; }
        public string Role { get; set; }
        public string ConfSpecifics { get; set; }
        public DateTime DateCreated { get; set; }
        public int ReceivedFeedback { get; set; }
        public byte[] Media { get; set; }
        public ConferenceToolModel()
        {

        }

    }

    public static class ConferenceToolModelDb
    {
        //public static List<SelectListItem> SelectAllTypes()
        //{
        //    List<SelectListItem> output = new List<SelectListItem>();
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("ConferenceToolSelectAllType", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {
        //                SelectListItem selectListItem = new SelectListItem()
        //                {
        //                    Value = dtr["conferenceTypeID"].ToString(),
        //                    Text = dtr["conferenceType"].ToString()
        //                };
        //                output.Add(selectListItem);
        //            } while (dtr.Read());
        //        }
        //        output.Insert(0, new SelectListItem() { Text = "Please Select", Value = "0", Selected = true });
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
        //public static void UploadConference(ConferenceToolViewModel model, int studentID)
        //{
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("ConferenceToolUpload", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@ConferenceTypeID", model.ConferenceTypeID);
        //    cmd.Parameters.AddWithValue("@StudentID", studentID);
        //    cmd.Parameters.AddWithValue("@SourceID", model.SourceID);
        //    cmd.Parameters.AddWithValue("@ElementID", model.ElementID);
        //    cmd.Parameters.AddWithValue("@RoleHelpID", model.RoleHelpID);
        //    cmd.Parameters.AddWithValue("@ConfToolSpecifics", model.ConfToolSpecifics);
        //    cmd.Parameters.AddWithValue("@DateCreated", model.DateCreated);
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
        //public static List<ConferenceToolModel> SelectAllByStudentID(int studentID)
        //{
        //    List<ConferenceToolModel> output = new List<ConferenceToolModel>();
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("ConferenceToolSelectAllByStudentID", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@studentID", studentID);
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {
        //                ConferenceToolModel model = new ConferenceToolModel();
        //                model.ConferenceToolID = Convert.ToInt32(dtr["ConfToolID"]);
        //                model.ConferenceTypeID = Convert.ToInt32(dtr["ConfTypeID"]);
        //                model.ConferenceType = dtr["conferenceType"].ToString();
        //                model.SourceID = Convert.ToInt32(dtr["SourceID"]);
        //                model.SourceTitle = dtr["SourceTitle"].ToString();
        //                model.ElementID = Convert.ToInt32(dtr["ElementID"]);
        //                model.Element = dtr["Element"].ToString();
        //                model.RoleHelpID = Convert.ToInt32(dtr["RoleHelpID"]);
        //                model.RoleHelp = dtr["Role"].ToString();
        //                model.ConfToolSpecifics = dtr["ConfSpecifics"].ToString();
        //                model.DateCreated = Convert.ToDateTime(dtr["DateCreate"]);
        //                model.ReceivedFeedback = Convert.ToInt32(dtr["Feedback"]);
        //                if(model.ConferenceTypeID == 1)
        //                {
        //                    model.Media = PaperModelDb.SelectOne(model.SourceID).Paper;
        //                }
        //                output.Add(model);
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
    }
}