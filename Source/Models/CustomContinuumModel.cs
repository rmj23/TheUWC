using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Source.Models
{
    public class CustomContinuumModel
    {
        public int ProjectId { get; set; }
        public List<ProjectContinuumModel> CustomContinuumRow { get; set; }
    }

    public static class CustomContinuumModelDb
    {
        /// <summary>
        /// Builds an empty Custom Contiuum to be built with custom guidelines
        /// </summary>
        /// <returns></returns>
        //public static List<ProjectContinuumModel> BuildCustomContinuum()
        //{
        //    List<ProjectContinuumModel> output = new List<ProjectContinuumModel>();
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("CustomContinuumBlankBuild", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        while (dtr.Read())
        //        {
        //            output.Add(new ProjectContinuumModel()
        //            {
        //                ElementID = Convert.ToInt32(dtr["elementID"]),
        //                Elelement = dtr["Element"].ToString(),
        //                Characteristic = dtr["characteristic"].ToString(),
        //                CharacteristicID = Convert.ToInt32(dtr["characteristicId"]),
        //                Level = dtr["letter"].ToString(),
        //                LevelID = Convert.ToInt32(dtr["levelID"]),
        //                TimeFrame = dtr["TimeFrame"].ToString(),
        //                Guideline = ""
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
        public static void InsertCustomCriteria(int projectId, CustomContinuumModel customModel)
        {
            SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
            SqlCommand cmd = new SqlCommand("CustomContinuumInsert", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                foreach (var level in customModel.CustomContinuumRow)
                {
                    if (level.Guideline != null)
                    {
                        cmd.Parameters.AddWithValue("@projectId", projectId);
                        cmd.Parameters.AddWithValue("@elementId", level.ElementID);
                        cmd.Parameters.AddWithValue("@characteristicId", level.CharacteristicID);
                        cmd.Parameters.AddWithValue("@guideline", level.Guideline);
                        cmd.Parameters.AddWithValue("@levelId", level.LevelID);
                        try
                        {
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                        catch (SqlException ex)
                        {
                            trans.Rollback();
                            ErrorModelDb.InsertSqlError(ex.ToString());
                        }
                    }
                }
                trans.Commit();
                trans.Dispose();
            }
            catch (SqlException ex)
            {
                ErrorModelDb.InsertSqlError(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
    }
}