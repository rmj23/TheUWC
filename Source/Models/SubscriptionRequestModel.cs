using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Source.Models
{
    public class SubscriptionRequestModel
    {
        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Prefix { get; set; }
        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }
        [Required]
        public string ContinuumType { get; set; }
        [Required]
        public string Edition { get; set; }
        public List<SelectListItem> Prefixes { get; set; }
        public List<SelectListItem> ContinuumTypes { get; set; }
        public List<SelectListItem> Editions { get; set; }
    }

    public static class SubscriptionRequestModelDb
    {
        //public static void Insert(SubscriptionRequestModel model)
        //{
        //    var conn = new SqlConnection(DatabaseMetadataModel.dbconn);
        //    var cmd = new SqlCommand("InsertSubscriptionRequest", conn);
        //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@firstName", model.FirstName);
        //    cmd.Parameters.AddWithValue("@lastName", model.LastName);
        //    cmd.Parameters.AddWithValue("@prefix", model.Prefix);
        //    cmd.Parameters.AddWithValue("@email", model.Email);
        //    cmd.Parameters.AddWithValue("@phone", model.Phone);
        //    cmd.Parameters.AddWithValue("@continuumType", model.ContinuumType);
        //    cmd.Parameters.AddWithValue("@edition", model.Edition);
        //    try
        //    {
        //        conn.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch(SqlException ex)
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