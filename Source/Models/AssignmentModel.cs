using Microsoft.VisualStudio.TestTools.UnitTesting;
using Source.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Source.Models
{
    public class AssignmentModel
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime Created { get; set; }
        [Required]
        public DateTime Due { get; set; }
        [Required]
        public int CourseID { get; set; }
    }

    public static class AssignmentModelDb
    {
        //public static List<AssignmentModel> SelectAllByCourse(int CourseID)
        //{
        //    List<AssignmentModel> output = new List<AssignmentModel>();
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("AssignmentSelectAllByCourse", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@CourseID", CourseID);
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {
        //                output.Add(new AssignmentModel()
        //                {
        //                    ID = Convert.ToInt32(dtr["ID"]),
        //                    Name = dtr["Name"].ToString(),
        //                    Description = dtr["Description"].ToString(),
        //                    Created = Convert.ToDateTime(dtr["Created"]),
        //                    Due = Convert.ToDateTime(dtr["Due"]),
        //                    CourseID = Convert.ToInt32(dtr["CourseID"])
        //                });
        //            } while (dtr.Read());
        //        }
        //    }
        //    catch
        //    {

        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return output;
        //}
        //public static AssignmentModel SelectOne(int ID)
        //{
        //    AssignmentModel output = new AssignmentModel();
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("AssignmentSelectOne", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@ID", ID);
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {
        //                output = new AssignmentModel()
        //                {
        //                    ID = Convert.ToInt32(dtr["ID"]),
        //                    Name = dtr["Name"].ToString(),
        //                    Description = dtr["Description"].ToString(),
        //                    Created = Convert.ToDateTime(dtr["Created"]),
        //                    Due = Convert.ToDateTime(dtr["Due"]),
        //                    CourseID = Convert.ToInt32(dtr["CourseID"])
        //                };
        //            } while (dtr.Read());
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        ErrorModelDb.InsertSqlError(ex.Message.ToString());
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return output;
        //}

        //public static void Insert(AssignmentModel model)
        //{
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("AssignmentInsert", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@Name", model.Name);
        //    cmd.Parameters.AddWithValue("@Description", model.Description);
        //    cmd.Parameters.AddWithValue("@Due", model.Due);
        //    cmd.Parameters.AddWithValue("@CourseID", model.CourseID);
        //    try
        //    {
        //        conn.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch
        //    {

        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}

        //public static void Update(AssignmentModel model)
        //{
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("AssignmentUpdate", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@ID", model.ID);
        //    cmd.Parameters.AddWithValue("@Name", model.Name);
        //    cmd.Parameters.AddWithValue("@Description", model.Description);
        //    cmd.Parameters.AddWithValue("@Due", model.Due);
        //    cmd.Parameters.AddWithValue("@CourseID", model.CourseID);
        //    try
        //    {
        //        conn.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch
        //    {

        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}

        //public static void Delete(AssignmentModel model)
        //{
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("AssignmentDelete", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@ID", model.ID);
        //    try
        //    {
        //        conn.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch
        //    {

        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}
    }
    [TestClass]
    public class AssignmentModelTests
    {
        [TestMethod]
        public void TestSelectAllByTeacher()
        {
            Repository repo = new Repository();
            List<AssignmentModel> output = repo.AssignmentSelectAllByCourse(3);
            Assert.IsTrue(output.Count > 0);
        }
    }
}