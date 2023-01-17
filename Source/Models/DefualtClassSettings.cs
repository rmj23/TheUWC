using Source.Data;
using System;
using System.Data.SqlClient;

namespace Source.Models
{
    public class DefualtClassSettings : ACourseSelectionViewModel
    {
        public int SettingDefualtId { get; set; }
        public bool DefualtEnabled { get; set; }
        public int DefualtClass { get; set; }
        /// <summary>
        /// Going to need to check and see if there is a course selected if there is defualt to that selection. If not defualt to please select.
        /// </summary>
        public DefualtClassSettings()
        {
        }
        public void SetDropDowns(int teacherId)
        {
            Repository repo = new Repository();
            using (SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn))
            {
                if (DefualtEnabled == false)
                {
                    CourseDropDown = ClassModelControls.GetSelectListItems(repo.SelectAllByTeacher(teacherId), true);
                }
                else
                {
                    CourseDropDown = ClassModelControls.GetSelectListItems(repo.SelectAllByTeacher(teacherId), false, DefualtClass);
                }
            }

        }
        public void UpdateDefualtClassSettings(DefualtClassSettings model)
        {
            Repository repo = new Repository();

            repo.DefaultClassSetDefaultSettings(model);
            //DefualtClassSettingsDb.SetDefualtSettings(model);
        }
        public override void CourseSelected()
        {
            throw new NotImplementedException();
        }
    }

    public static class DefualtClassSettingsDb
    {
        /// <summary>
        /// This method will return the Defualt class settings from the DB. This gets called on ANY teacher layout page.
        /// If the teacher has not logged in yet, it will automatcally insert a record in the SettingsClassDefualt table.
        /// 
        /// </summary>
        /// <param name="teacherId"></param>
        /// <returns></returns>
        //public static DefualtClassSettings GetSettingsDefualtClass(int teacherId)
        //{
        //    DefualtClassSettings output = new DefualtClassSettings();
        //    var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    var cmd = new SqlCommand("SettingsDefualtEnabledGet", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@teacherID", teacherId);
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            do
        //            {
        //                output.SettingDefualtId = Convert.ToInt32(dtr["ID"]);
        //                output.DefualtEnabled = Convert.ToBoolean(dtr["IsDefualtEnabled"]);
        //                output.DefualtClass = (dtr["courseID"]) == DBNull.Value ? 0 : Convert.ToInt32(dtr["courseID"]); //Handle Null courseID
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
        //        output.SetDropDowns(teacherId);
        //    }
        //    return output;
        //}
        //public static void SetDefualtSettings(DefualtClassSettings model)
        //{
        //    var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    var cmd = new SqlCommand("SettingsDefualtEnabledSet", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@ID", model.SettingDefualtId);
        //    cmd.Parameters.AddWithValue("@courseID", model.DefualtClass);
        //    cmd.Parameters.AddWithValue("@IsDefualtEnabled", Convert.ToBoolean(model.DefualtEnabled));
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
}