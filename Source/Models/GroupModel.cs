using System.Collections.Generic;
using System.Web.Mvc;

namespace Source.Models
{
    public class GroupModel
    {
        public int groupId { get; set; }
        public int projectId { get; set; }
        public string projectTitle { get; set; }
        public int groupNumber { get; set; }
        public string groupName { get; set; }
        public string projectSubtitle { get; set; }
    }

    public static class GroupModelDb
    {
        //private static SqlConnection conn;
        //private static SqlCommand cmd;

        //returns group id
        //public static int insert(int projectId, int groupNumber)
        //{
        //    int output = 0;
        //    conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    cmd = new SqlCommand("GroupInsert", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@groupNumber", groupNumber);
        //    cmd.Parameters.AddWithValue("@projectId", projectId);
        //    try
        //    {
        //        conn.Open();
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

        //public static GroupModel select(int groupId)
        //{
        //    GroupModel output = new GroupModel();
        //    conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    cmd = new SqlCommand("GroupSelectOne", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@groupId", groupId);
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            output.groupId = groupId;
        //            output.groupName = dtr["groupName"].ToString();
        //            output.groupNumber = Convert.ToInt32(dtr["groupNumber"]);
        //            output.projectId = Convert.ToInt32(dtr["projectId"]);
        //            output.projectSubtitle = dtr["projectSubtitle"].ToString();
        //            output.projectTitle = dtr["projectName"].ToString();
        //        }
        //    }
        //    catch(SqlException ex)
        //    {
        //        ErrorModelDb.InsertSqlError(ex.ToString());
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return output;
        //}

        //Add a student to a group
        //public static void insertStudentGroup(int groupId, int studentId)
        //{
        //    conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    cmd = new SqlCommand("StudentGroupInsert", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@groupId", groupId);
        //    cmd.Parameters.AddWithValue("@studentId", studentId);
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
        //public static void removeStudentGroup(int groupId, int studentId)
        //{
        //    conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    cmd = new SqlCommand("StudentGroupRemoveStudent", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@groupId", groupId);
        //    cmd.Parameters.AddWithValue("@studentId", studentId);
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
        //public static int getGroupId(int groupNumber, int projectId)
        //{
        //    int output = 0;
        //    conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    cmd = new SqlCommand("GroupGetGroupId", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@groupNumber", groupNumber);
        //    cmd.Parameters.AddWithValue("@projectId", projectId);
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            output = Convert.ToInt32(dtr["groupId"]);
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

        //public static List<int> getGroupIdsFromProjectId(int projectId)
        //{
        //    List<int> output = new List<int>();
        //    conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    cmd = new SqlCommand("GroupSelectIDsByProjectID", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@projectId", projectId);
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        while (dtr.Read())
        //        {
        //            output.Add(Convert.ToInt32(dtr["groupId"]));
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

        //public static void updateGroupInfo(int groupId, string projectSubtitle)
        //{
        //    System.Diagnostics.Debug.WriteLine("Update group info, subtitle: " + projectSubtitle);
        //    conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    cmd = new SqlCommand("GroupUpdateGroupInfo", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@groupId", groupId);
        //    cmd.Parameters.AddWithValue("@projectSubtitle", projectSubtitle);
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
        //public static void updateGroupNum(int groupId, int groupNum)
        //{
        //    conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    cmd = new SqlCommand("GroupUpdateGroupNum", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@groupId", groupId);
        //    cmd.Parameters.AddWithValue("@groupNum", groupNum);
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

        //public static void deleteGroup(int groupId)
        //{
        //    conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    cmd = new SqlCommand("GroupDeleteGroup", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@groupId", groupId);
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
    public static class GroupModelControls
    {
        public static List<SelectListItem> getSelectListItems()
        {
            List<SelectListItem> output = new List<SelectListItem>();
            output.Add(new SelectListItem() { Text = "Please Select", Value = "Please Select", Disabled = false });
            for (int i = 1; i < 15; i++)
            {
                output.Add(new SelectListItem()
                {
                    Text = i.ToString(),
                    Value = i.ToString()
                });
            }
            return output;
        }
    }

}