using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Source.Models
{
    public class ConferenceNotesModel
    {
        public int TeacherID { get; set; }
        public int StudentID { get; set; }
        public int CourseID { get; set; }
        public string CourseTitle { get; set; }
        public int ConferenceID { get; set; }
        public int ConferenceTypeID { get; set; }
        //Description is the Conference Type (Think about changing this in the future)
        public string Description { get; set; }
        public string StageOrDraft { get; set; }
        public int StageOrDraftID { get; set; }
        public string Comments { get; set; }
        public DateTime? Date { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
    }

    public static class ConferenceNotesDb
    {
        //public static List<ConferenceNotesModel> SelectConferenceNotesByCourseAndStudent(int courseID, int studentID)
        //{
        //    List<ConferenceNotesModel> output = new List<ConferenceNotesModel>();
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("ConferenceNotesSelectByStudentAndCourse", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@studentID", studentID);
        //    cmd.Parameters.AddWithValue("@courseID", courseID);
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {
        //                output.Add(new ConferenceNotesModel()
        //                {
        //                    StudentID = Convert.ToInt32(dtr["studentID"]),
        //                    CourseID = Convert.ToInt32(dtr["courseID"]),
        //                    ConferenceID = Convert.ToInt32(dtr["conferenceID"]),
        //                    ConferenceTypeID = Convert.ToInt32(dtr["conferenceTypeID"]),
        //                    Description = dtr["description"].ToString(),
        //                    StageOrDraft = dtr["stageOrDraft"].ToString(),
        //                    StageOrDraftID = Convert.ToInt32(dtr["StageOrDraftId"]),
        //                    Comments = dtr["comments"].ToString(),
        //                    Date = (dtr["date"]) == DBNull.Value ? default(DateTime?) : Convert.ToDateTime(dtr["date"]), // THIS IS HOW TO HANDLE NULL COLUMNS!
        //                    StudentFN = dtr["firstName"].ToString(),
        //                    StudentLN = dtr["lastName"].ToString(),
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

        //public static List<ConferenceNotesModel> SelectConferenceNotesByStudentID(int studentID)
        //{
        //    List<ConferenceNotesModel> output = new List<ConferenceNotesModel>();
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("ConferenceNotesSelectByStudentID", conn);
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
        //                output.Add(new ConferenceNotesModel()
        //                {
        //                    StudentID = studentID,
        //                    Date =
        //                        (dtr["date"]) == DBNull.Value
        //                            ? default(DateTime?)
        //                            : Convert.ToDateTime(dtr["date"]), // THIS IS HOW TO HANDLE NULL COLUMNS!
        //                    ConferenceTypeID = Convert.ToInt32(dtr["conferenceTypeID"]),
        //                    Description = dtr["description"].ToString(),
        //                    Comments = dtr["comments"].ToString(),
        //                    StageOrDraftID = Convert.ToInt32(dtr["stageOrDraftID"]),
        //                    StageOrDraft = dtr["stageOrDraft"].ToString(),
        //                    CourseID = Convert.ToInt32(dtr["courseID"]),
        //                    CourseTitle = dtr["courseTitle"].ToString()
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
        //public static ConferenceNotesModel SelectConferenceNoteByID(int conferenceID)
        //{
        //    ConferenceNotesModel output = new ConferenceNotesModel();
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("ConferenceNotesSelectByID", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@conferenceID", conferenceID);
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            output = new ConferenceNotesModel()
        //            {
        //                ConferenceID = conferenceID,
        //                Date = (dtr["date"]) == DBNull.Value ? default(DateTime?) : Convert.ToDateTime(dtr["date"]), // THIS IS HOW TO HANDLE NULL COLUMNS!
        //                ConferenceTypeID = Convert.ToInt32(dtr["conferenceTypeID"]),
        //                Description = dtr["description"].ToString(),
        //                Comments = dtr["comments"].ToString(),
        //                StageOrDraftID = Convert.ToInt32(dtr["stageOrDraftID"]),
        //                StageOrDraft = dtr["stageOrDraft"].ToString(),
        //                StudentID = Convert.ToInt32(dtr["studentID"]),
        //                CourseID = Convert.ToInt32(dtr["courseID"])
        //            };
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
        //public static void EditConferenceNotes(ConferenceNotesModel model)
        //{
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("ConferenceNotesUpdate", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@conferenceID", model.ConferenceID);
        //    cmd.Parameters.AddWithValue("@stageOrDraftID", model.StageOrDraftID);
        //    cmd.Parameters.AddWithValue("@comments", model.Comments);
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
        //public static void DeleteConferenceNotes(int conID)
        //{
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("ConferenceNotesDeleteByID", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@conID", conID);
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
        //public static void InsertConferenceNotes(InsertConferenceNotesViewModel model)
        //{
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("ConferenceNotesInsert", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@date", model.ReturnDate);
        //    cmd.Parameters.AddWithValue("@studentID", model.ConferenceNotes.StudentID);
        //    cmd.Parameters.AddWithValue("@conferenceTypeID", model.ConferenceNotes.ConferenceTypeID);
        //    cmd.Parameters.AddWithValue("@stageOrDraftID", model.ConferenceNotes.StageOrDraftID);
        //    cmd.Parameters.AddWithValue("@comments", model.ConferenceNotes.Comments);
        //    cmd.Parameters.AddWithValue("@courseID", model.ConferenceNotes.CourseID);
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
        //public static List<ConferenceNotesModel> ConferenceTypeDescriptionSelectAll()
        //{
        //    List<ConferenceNotesModel> output = new List<ConferenceNotesModel>();
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("ConferenceTypeDescriptionSelectAll", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {
        //                output.Add(new ConferenceNotesModel()
        //                {
        //                    Description = dtr["description"].ToString(),
        //                    ConferenceTypeID = Convert.ToInt32(dtr["conferenceTypeID"])
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
        //public static List<ConferenceNotesModel> ConferenceStageOrDraftSelectAll()
        //{
        //    List<ConferenceNotesModel> output = new List<ConferenceNotesModel>();
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("ConferenceStageOrDraftSelectAll", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {
        //                output.Add(new ConferenceNotesModel()
        //                {
        //                    StageOrDraft = dtr["StageOrDraft"].ToString(),
        //                    StageOrDraftID = Convert.ToInt32(dtr["StageOrDraftId"])
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
    }
    public static class ConferenceNotesModelControls
    {
        public static List<SelectListItem> GetSelectListItemsDescription(List<ConferenceNotesModel> models)
        {
            List<SelectListItem> output = new List<SelectListItem>();
            foreach (ConferenceNotesModel model in models)
            {
                output.Add(new SelectListItem()
                {
                    Value = model.ConferenceTypeID.ToString(),
                    Text = model.Description
                });
            }
            return output;
        }
        public static List<SelectListItem> GetSelectListItemsDescription(List<ConferenceNotesModel> models, bool HasSelect)
        {
            var output = GetSelectListItemsDescription(models);
            if (HasSelect)
            {
                foreach (SelectListItem item in output)
                {
                    item.Selected = false;
                }
                if (HasSelect)
                {
                    output.Insert(0, new SelectListItem() { Text = "Please Select", Value = "-1", Selected = true });
                }
            }
            return output;
        }
        public static List<SelectListItem> GetSelectListItemsStageOrDraft(List<ConferenceNotesModel> models)
        {
            List<SelectListItem> output = new List<SelectListItem>();
            foreach (ConferenceNotesModel model in models)
            {
                output.Add(new SelectListItem()
                {
                    Value = model.StageOrDraftID.ToString(),
                    Text = model.StageOrDraft
                });
            }
            return output;
        }
        public static List<SelectListItem> GetSelectListItemsStageOrDraft(List<ConferenceNotesModel> models, bool HasSelect)
        {
            var output = GetSelectListItemsStageOrDraft(models);
            if (HasSelect)
            {
                foreach (SelectListItem item in output)
                {
                    item.Selected = false;
                }
                if (HasSelect)
                {
                    output.Insert(0, new SelectListItem() { Text = "Please Select", Value = "-1", Selected = true });
                }
            }
            return output;
        }
        public static List<SelectListItem> GetSelectListItemsStageOrDraft(List<ConferenceNotesModel> models, int stageOrDraftID)
        {
            var output = GetSelectListItemsStageOrDraft(models);
            foreach (SelectListItem item in output)
            {
                if (item.Value == stageOrDraftID.ToString())
                {
                    item.Selected = true;
                }
            }
            return output;
        }
    }
}