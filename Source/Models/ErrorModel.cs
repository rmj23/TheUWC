using System;
using System.Data;
using System.Data.SqlClient;

namespace Source.Models
{
    public class ErrorModel
    {
        public int ErrorID { get; set; }
        public int ErrorTypeID { get; set; }
        public string ErrorType { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime TimeStamp { get; set; }
    }

    public static class ErrorModelDb
    {
        // on repo now
        public static void InsertSqlError(string errorMessage)
        {
            DateTime timeStamp = DateTime.Now;
            SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
            SqlCommand cmd = new SqlCommand("tblErrorInsert", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@errorTypeID", 1);//Error Type for sql errors is 1
            cmd.Parameters.AddWithValue("@errorMessage", errorMessage);
            cmd.Parameters.AddWithValue("@timeStamp", timeStamp);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                errorMessage = ex.Message.ToString();
            }
            finally
            {
                conn.Close();
            }
        }
        public static void InsertApplicationError(string errorMessage)
        {
            DateTime timeStamp = DateTime.Now;
            SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
            SqlCommand cmd = new SqlCommand("tblErrorInsert", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@errorTypeID", 2);//Error Type for application errors is 2
            cmd.Parameters.AddWithValue("@errorMessage", errorMessage);
            cmd.Parameters.AddWithValue("@timeStamp", timeStamp);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                errorMessage = ex.Message.ToString();
            }
            finally
            {
                conn.Close();
            }
        }

    }
}