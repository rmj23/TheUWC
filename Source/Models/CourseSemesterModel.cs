using System;
using System.ComponentModel.DataAnnotations;

namespace Source.Models
{
    public class CourseSemesterModel
    {
        public int ID { get; set; }
        [Required]
        public int SchoolID { get; set; }
        [Required]
        public int SubjectID { get; set; }
        [Required]
        public int SemesterID { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime MidtermDate { get; set; }
        public string SubjectDescription { get; set; }
        public string SemesterDescription { get; set; }
    }
    public static class CourseSemsterModelDb
    {
        //public static void CourseSemesterInsert(CourseSemesterViewModel model)
        //{
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("CourseSemesterInsert", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@schoolID", model.SchoolID);
        //    cmd.Parameters.AddWithValue("@subjectID", model.SubjectID);
        //    cmd.Parameters.AddWithValue("@semesterID", model.SemesterID);
        //    cmd.Parameters.AddWithValue("@midtermDate", model.CourseSemesterModel.MidtermDate);
        //    try
        //    {
        //        conn.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch(SqlException ex)
        //    {
        //        ErrorModelDb.InsertSqlError(ex.Message.ToString());
        //    }
        //    conn.Close();

        //}
        //public static List<CourseSemesterModel> CourseSemesterSelectAll(int schoolID)
        //{
        //    List<CourseSemesterModel> output = new List<CourseSemesterModel>();
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("CourseSemesterSelectAllBySchoolID", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@schoolID", schoolID);
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {
        //                output.Add(new CourseSemesterModel()
        //                {
        //                    ID = Convert.ToInt32(dtr["ID"]),
        //                    SchoolID = schoolID,
        //                    SubjectID = Convert.ToInt32(dtr["SubjectID"]),
        //                    SemesterID = Convert.ToInt32(dtr["SemesterID"]),
        //                    MidtermDate = Convert.ToDateTime(dtr["MidtermDate"]),
        //                    SubjectDescription = dtr["subjectDescription"].ToString(),
        //                    SemesterDescription = dtr["semesterDescription"].ToString()
        //                });
        //            } while (dtr.Read());                    
        //        }
        //    }
        //    catch(SqlException ex)
        //    {
        //        ErrorModelDb.InsertSqlError(ex.Message.ToString());
        //    }
        //    conn.Close();
        //    return output;
        //}
    }
}
