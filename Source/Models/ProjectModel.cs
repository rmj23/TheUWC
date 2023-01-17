using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Source.Models
{
    public class ProjectModel
    {

        public int projectId { get; set; }
        public int courseId { get; set; }
        [Display(Name = "Project Title")]
        public String projectName { get; set; }
        [Display(Name = "Due Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime dueDate { get; set; }
        public int continuumTypeId { get; set; }
        [Display(Name = "Continuum Type")]
        public string continuumType { get; set; }
        [Display(Name = "Custom Continuum Criteria")]
        public Boolean customCriteria { get; set; }

    }
    public static class ProjectModelDb
    {
        //public static int Insert(ProjectModel model)
        //{

        //    int output = 0;
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("ProjectInsert", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@courseId", model.courseId);
        //    cmd.Parameters.AddWithValue("@projectName", model.projectName);
        //    cmd.Parameters.AddWithValue("@date", model.dueDate);
        //    cmd.Parameters.AddWithValue("@continuumTypeId", model.continuumTypeId);
        //    cmd.Parameters.AddWithValue("@customCriteria", model.customCriteria);
        //    try
        //    {
        //        conn.Open();
        //        // executes query and gets the projectid 
        //        output = Convert.ToInt32(cmd.ExecuteScalar());
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
        //public static void delete(int projectId)
        //{
        //    var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    var cmd = new SqlCommand("ProjectDelete", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@projectId", projectId);
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
        //public static List<ProjectModel> selectAll(int courseId)
        //{
        //    List<ProjectModel> output = new List<ProjectModel>();
        //    var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    var cmd = new SqlCommand("ProjectSelectAll", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@courseId", courseId);
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        while (dtr.Read())
        //        {
        //            output.Add(new ProjectModel
        //            {
        //                projectId = Convert.ToInt32(dtr["projectId"]),
        //                courseId = Convert.ToInt32(dtr["courseId"]),
        //                projectName = dtr["projectName"].ToString(),
        //                dueDate = Convert.ToDateTime(dtr["dueDate"]),
        //                continuumTypeId = Convert.ToInt32(dtr["continuumTypeId"]),
        //                continuumType = dtr["continuumType"].ToString()
        //            });
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
        //public static ProjectModel selectOne(int projectId)
        //{
        //    ProjectModel output = new ProjectModel();
        //    var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    var cmd = new SqlCommand("ProjectSelectOne", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@projectId", projectId);
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            output.projectId = Convert.ToInt32(dtr["projectId"]);
        //            output.courseId = Convert.ToInt32(dtr["courseId"]);
        //            output.projectName = dtr["projectName"].ToString();
        //            output.dueDate = Convert.ToDateTime(dtr["dueDate"]);
        //            output.continuumTypeId = Convert.ToInt32(dtr["continuumTypeId"]);
        //            output.continuumType = dtr["continuumType"].ToString();
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

        //public static List<ProjectModel> selectAllByStudent(int studentID)
        //{
        //    List<ProjectModel> output = new List<ProjectModel>();
        //    var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    var cmd = new SqlCommand("ProjectSelectAllByStudent", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@studentID", studentID);
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        while (dtr.Read())
        //        {
        //            output.Add(new ProjectModel
        //            {
        //                projectId = Convert.ToInt32(dtr["projectId"]),
        //                courseId = Convert.ToInt32(dtr["courseId"]),
        //                projectName = dtr["projectName"].ToString(),
        //                dueDate = Convert.ToDateTime(dtr["dueDate"]),
        //                continuumTypeId = Convert.ToInt32(dtr["continuumTypeId"]),
        //                continuumType = dtr["continuumType"].ToString()
        //        });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorModelDb.InsertSqlError(ex.ToString());
        //    }

        //    return output;
        //}
        //public static void update(ViewGroupsViewModel model)
        //{
        //    var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    var cmd = new SqlCommand("ProjectEdit", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@projectId", model.project.projectId);
        //    cmd.Parameters.AddWithValue("@courseId", model.project.courseId);
        //    cmd.Parameters.AddWithValue("@projectName", model.project.projectName);
        //    cmd.Parameters.AddWithValue("@date", model.project.dueDate);

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

    }
    public static class ProjectModelControls
    {
        public static List<SelectListItem> GetSelectListItems(List<ProjectModel> models)
        {
            List<SelectListItem> output = new List<SelectListItem>();
            foreach (ProjectModel model in models)
            {
                output.Add(new SelectListItem()
                {
                    Text = model.projectName,
                    Value = model.projectId.ToString()
                });
            }
            return output;
        }
        public static List<SelectListItem> GetSelectListItems(List<ProjectModel> models, bool HasSelect)
        {
            List<SelectListItem> output = new List<SelectListItem>();
            output = GetSelectListItems(models);
            foreach (SelectListItem item in output)
            {
                item.Selected = false;
            }
            output.Insert(0, new SelectListItem() { Text = "Please Select", Value = "0", Selected = true });
            return output;
        }
    }
}