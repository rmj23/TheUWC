using DevOne.Security.Cryptography.BCrypt;
using Source.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace Source.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "The Email Address field is required.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "The Password field is required.")]
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Hash { get; set; }
        public string ReturnUrl { get; set; }
        [Required(ErrorMessage = "The School Code field is required.")]
        public int schoolCode { get; set; }
        public LoginModel()
        {

        }
        public LoginModel(string Username, string Password)
        {
            this.UserName = Username;
            this.Password = Password;
        }
        public UserModel Authenticate()
        {
            Repository repo = new Repository();
            Salt = repo.RetrieveSalt(this.UserName);
            if (Salt == null)
            {
                return null;
            }
            this.Hash = BCryptHelper.HashPassword(Password, Salt);
            var loginModel = repo.Login(this);
            return loginModel;
        }
        public UserModel NewUser(string UserName, string Password, int SchoolCode, UserModel user)
        {
            Repository repo = new Repository();
            this.UserName = UserName;
            this.Password = Password;
            this.schoolCode = SchoolCode;
            this.Salt = BCryptHelper.GenerateSalt();
            this.Hash = BCryptHelper.HashPassword(this.Password, this.Salt);
            return repo.InsertUser(this, user);
        }
        public UserModel NewUserParent(string UserName, string Password, UserModel user)
        {
            Repository repo = new Repository();
            this.UserName = UserName;
            this.Password = Password;
            this.Salt = BCryptHelper.GenerateSalt();
            this.Hash = BCryptHelper.HashPassword(this.Password, this.Salt);
            return repo.InsertUser(this, user);
        }
        public void ResetPassword(string UserName, string NewPassword)
        {
            Repository repo = new Repository();
            this.UserName = UserName;
            this.Password = NewPassword;
            this.Salt = BCryptHelper.GenerateSalt();
            this.Hash = BCryptHelper.HashPassword(this.Password, this.Salt);
            repo.ResetPassword(this);
        }
    }


}