
using System;
using System.ComponentModel.DataAnnotations;

namespace Source.Models
{
    public class ContactModel
    {
        public int ID { get; set; }
        [Required]
        public string Reason { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        //[Required]
        public string Phone { get; set; }
        [Required]
        public string City { get; set; }
        //[Required]
        public string StreetNumber { get; set; }
        //[Required]
        public string StreetName { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public string Message { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Result { get; set; }
        public string WebAdminComments { get; set; }

    }

    public static class ContactModelDb
    {
        //public static void Insert (ContactModel model)
        //{
        //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    SqlCommand cmd = new SqlCommand("ContactRequestInsert", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@Reason", model.Reason);
        //    cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
        //    cmd.Parameters.AddWithValue("@LastName", model.LastName);
        //    cmd.Parameters.AddWithValue("@Email", model.Email);
        //    cmd.Parameters.AddWithValue("@Phone", (object)model.Phone ?? DBNull.Value);
        //    cmd.Parameters.AddWithValue("@City", model.City);
        //    cmd.Parameters.AddWithValue("@StreetNumber", (object)model.StreetNumber ?? DBNull.Value);
        //    cmd.Parameters.AddWithValue("@StreetName", (object)model.StreetName ?? DBNull.Value);
        //    cmd.Parameters.AddWithValue("@Country", model.Country);
        //    cmd.Parameters.AddWithValue("@State", model.State);
        //    cmd.Parameters.AddWithValue("@ZipCode", model.ZipCode);
        //    cmd.Parameters.AddWithValue("@Message", model.Message);
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
        //public static void AcknowledgeContactRequest(int ContactRequestID)
        //{
        //    var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    var cmd = new SqlCommand("ContactRequestAcknowledgeRequest", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@requestID", ContactRequestID);
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
        //public static void ResolveContactRequest(int ContactRequestID)
        //{
        //    var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    var cmd = new SqlCommand("ContactRequestResolveRequest", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@requestID", ContactRequestID);
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
        //public static void DeleteContactRequest(int ContactRequestID)
        //{
        //    var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    var cmd = new SqlCommand("ContactRequestDeleteRequest", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@requestID", ContactRequestID);
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
        //public static void InsertWebAdminComment(int ContactRequestID, string Comment)
        //{
        //    var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    var cmd = new SqlCommand("ContactRequestInsertComment", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@comment", Comment);
        //    cmd.Parameters.AddWithValue("@requestID", ContactRequestID);
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
        //public static List<ContactModel> SelectAll()
        //{
        //    List<ContactModel> output = new List<ContactModel>();
        //    var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    var cmd = new SqlCommand("ContactRequestSelectAll", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        while (dtr.Read())
        //        {
        //            output.Add(new ContactModel()
        //            {
        //                ID = Convert.ToInt32(dtr["ID"]),
        //                Reason = dtr["Reason"].ToString(),
        //                FirstName = dtr["FirstName"].ToString(),
        //                LastName = dtr["LastName"].ToString(),
        //                Email = dtr["Email"].ToString(),
        //                Phone = dtr["Phone"].ToString(),
        //                City = dtr["City"].ToString(),
        //                State = dtr["State"].ToString(),
        //                ZipCode = dtr["ZipCode"].ToString(),
        //                Message = dtr["Message"].ToString(),
        //                StreetNumber = dtr["StreetNumber"].ToString(),
        //                StreetName = dtr["StreetName"].ToString(),
        //                Country = dtr["Country"].ToString(),
        //                TimeStamp = Convert.ToDateTime(dtr["TimeStamp"]),
        //                Result = dtr["Result"].ToString(),
        //                WebAdminComments = dtr["WebAdminComments"].ToString()
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
        //public static ContactModel SelectByID(int ContactRequestID)
        //{
        //    ContactModel output = new ContactModel();
        //    var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    var cmd = new SqlCommand("ContactRequestSelectByID", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@requestID", ContactRequestID);
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader dtr = cmd.ExecuteReader();
        //        if (dtr.Read())
        //        {
        //            output.ID = Convert.ToInt32(dtr["ID"]);
        //            output.Reason = dtr["Reason"].ToString();
        //            output.LastName = dtr["LastName"].ToString();
        //            output.FirstName = dtr["FirstName"].ToString();
        //            output.Email = dtr["Email"].ToString();
        //            output.Phone = dtr["Phone"].ToString();
        //            output.City = dtr["City"].ToString();
        //            output.State = dtr["State"].ToString();
        //            output.ZipCode = dtr["ZipCode"].ToString();
        //            output.Message = dtr["Message"].ToString();
        //            output.StreetNumber = dtr["StreetNumber"].ToString();
        //            output.StreetName = dtr["StreetName"].ToString();
        //            output.Country = dtr["Country"].ToString();
        //            output.TimeStamp = Convert.ToDateTime(dtr["TimeStamp"]);
        //            output.Result = dtr["Result"].ToString();
        //            output.WebAdminComments = dtr["WebAdminComments"].ToString();
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        ErrorModelDb.InsertSqlError(ex.ToString());
        //    }
        //    return output;
        //}
    }
}