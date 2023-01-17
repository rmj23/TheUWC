using DevOne.Security.Cryptography.BCrypt;
using Source.Data;
using System.ComponentModel.DataAnnotations;

namespace Source.Models
{
    public class PasswordUpdateModel
    {
        public string Salt;
        public string Hash;

        [Required]
        [EmailAddress]
        [Display(Name = "Username")]
        public string Username { get; set; }

        //[Required]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
        //[DataType(DataType.Password)]
        //[Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }


        public PasswordUpdateModel Authenticate()
        {
            Repository repo = new Repository();
            this.Salt = repo.RetrieveSalt(this.Username);
            if (this.Salt == null)
            { return null; }
            this.Hash = BCryptHelper.HashPassword(this.NewPassword, this.Salt);
            return (this);
        }
    }
}

public static class PasswordUpdateDB
{

    //public static void ChangePassword(PasswordUpdateModel model)
    //{
    //    SqlConnection conn = new SqlConnection(DatabaseMetadataModel.dbconn);
    //    var cmd = new SqlCommand("PasswordChange", conn);
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@email", model.Username);
    //    string Salt = BCryptHelper.GenerateSalt();
    //    string Hash = BCryptHelper.HashPassword(model.NewPassword, Salt);
    //    cmd.Parameters.AddWithValue("@salt", Salt);
    //    cmd.Parameters.AddWithValue("@passwordHash", Hash);
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